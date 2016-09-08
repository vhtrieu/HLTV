using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
namespace TTHLTV
{
    public partial class frmStatistics : DevExpress.XtraEditors.XtraForm
    {
        BO_CHUNG_CHI boCc = new BO_CHUNG_CHI();
        public frmStatistics()
        {
            InitializeComponent();
        }
        #region Events
        private void frmStatistics_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridStudent.MainView, new Font("Tahoma", 11));

        }
        private void init()
        {
            BO_CHUNG_CHI chungchi = new BO_CHUNG_CHI();
            DataTable tbl_chungchi = chungchi.getChungChi_All();
            if (tbl_chungchi.Rows.Count > 0)
            {
                for (int i = 0; i < tbl_chungchi.Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = tbl_chungchi.Rows[i]["CHC_Name"].ToString();
                    node.Tag = "CHC";
                    node.Name = tbl_chungchi.Rows[i]["CHC_ID"].ToString();
                    treeChungchi.Nodes.Add(node);
                    DateTime fromDates = dateFrom.DateTime;
                    DateTime endDates = dateEnd.DateTime;
                    BO_LOP lop = new BO_LOP();
                    DataTable tbl_lop = lop.getLopByChungChiIDFromTo(Convert.ToInt32(node.Name), fromDates, endDates);
                    if (tbl_lop.Rows.Count > 0)
                    {
                        for (int j = 0; j < tbl_lop.Rows.Count; j++)
                        {
                            TreeNode childNode = new TreeNode();
                            childNode.Text = tbl_lop.Rows[j]["LOP_Name"].ToString();
                            childNode.Tag = "LOP";
                            childNode.Name = tbl_lop.Rows[j]["LOP_ID"].ToString();// +" KHÓA " + tbl_lop.Rows[j]["LOP_Khoa"].ToString();
                            node.Nodes.Add(childNode);
                        }
                    }
                }
            }
        }
        private void nodeClick(TreeNode node)
        {

            if (node.Tag.Equals("CHC"))
            {
                lbl_totalHocvien.Text = "Tổng số lớp : " + node.Nodes.Count;
            }
            else if (node.Tag.Equals("LOP"))
            {
                string LOP_ID = node.Name;
                BO_DANG_KI_HOC dangkihoc = new BO_DANG_KI_HOC();
                DataTable tbl_hocvien = dangkihoc.getHocvienByLopID(Convert.ToInt32(LOP_ID));
                gridStudent.DataSource = tbl_hocvien;
                lbl_totalHocvien.Text = "Tổng số học viên : " + tbl_hocvien.Rows.Count;
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            treeChungchi.Nodes.Clear();

            if (checkDate())
            {
                init();
            }
                      
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region check
       
        private bool checkDate()
        {
            if (string.IsNullOrEmpty(dateFrom.Text) || string.IsNullOrEmpty(dateEnd.Text))
            {
                MessageBox.Show("Cần chọn thời gian thống kê");
                return false;
            }
            DateTime DTfrom = new DateTime();
            DateTime DTend = new DateTime();
            DTfrom = DateTime.ParseExact(dateFrom.Text, "mm/dd/yyyy", null);
            DTend = DateTime.ParseExact(dateEnd.Text, "mm/dd/yyyy", null);
            if (DTend < DTfrom)
            {
                MessageBox.Show("Thời gian thống kê không hợp lệ");
                return false;
            }
            return true;
        }
        #endregion
        private void treeChungchi_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            nodeClick(node);
            
        }
        private void btnInThongKe_Click(object sender, EventArgs e)
        {
            frmBaoCaoThongKe frm = new frmBaoCaoThongKe();
            frm.ShowDialog();
            //if (checkDate())
            //{
            //    frmPrintStatics frm = new frmPrintStatics();
            //    frm.mfromDates = dateFrom.DateTime;
            //    frm.mendDates = dateEnd.DateTime;
            //    frm.prmFromDate = dateFrom.Text;
            //    frm.prmEndDate = dateEnd.Text;
            //    frm.ShowDialog();
                
            //}
            
        }
    }
}