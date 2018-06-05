using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TTHLTV.BAL;
using TTHLTV.DTO;
using DevExpress.XtraRichEdit.Utils;
using System.Web.UI.WebControls;

namespace TTHLTV
{
    public partial class frmWebDangKi : Form
    {
        public frmWebDangKi()
        {
            InitializeComponent();
        }
        private GridCheckMarksSelection sselection;
        WEB_DANGKIHOC vDto;
        BO_WEB_DANGKIHOC vBo;
        DataTable vtbl;
        private void frmWebDangKi_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(grdWebListHocVien.MainView, new Font("Tahoma", 11));
            initCheckBoxList();
        }
        private void initCheckBoxList()
        {
            DataTable tbl = new DataTable();

            vDto = new WEB_DANGKIHOC();
            vDto.DKW_Active = 1;
            vDto.DKW_Status = 3;
            vBo = new BO_WEB_DANGKIHOC();
            vtbl = new DataTable();
            vtbl = vBo.vLoadData(vDto);

            if (vtbl.Rows.Count > 0)
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID", typeof(int));
                table.Columns.Add("Name", typeof(string));
                DataRow vRow;
                for (int i = 0; i < vtbl.Rows.Count; i++)
                {
                    vDto.DKW_CHCID = int.Parse(vtbl.Rows[i]["DKW_CHCID"].ToString());

                    tbl = vBo.vLoadTotalHocVienDangKi(vDto);
                    if (tbl.Rows.Count > 0)
                    {
                        vRow = table.NewRow();
                        vRow["ID"] = int.Parse(vtbl.Rows[i]["DKW_CHCID"].ToString());
                        vRow["Name"] = tbl.Rows[0]["CHC_Name"] + " (" + tbl.Rows.Count + ")";
                        table.Rows.Add(vRow);
                    }
                }

                cklWebDkh.DataSource = table;
                cklWebDkh.ValueMember = "ID";
                cklWebDkh.DisplayMember = "Name";

            }
        }
        private void cklWebDkh_Click(object sender, EventArgs e)
        {
            vDto = new WEB_DANGKIHOC();
            vDto.DKW_Active = 1;
            vDto.DKW_Status = 3;
            vBo = new BO_WEB_DANGKIHOC();
            vtbl = new DataTable();

            object vIdChungChi = -1;
            if (cklWebDkh.SelectedIndex > -1)
            {
                vDto.DKW_CHCID = int.Parse(cklWebDkh.SelectedValue.ToString());
                vtbl = vBo.vLoadListHocVienByChungChiID(vDto);

                grvWebListHocVien.Columns.Clear();
                grdWebListHocVien.DataSource = vtbl.DefaultView;
                grvWebListHocVien.Columns["DKW_ID"].VisibleIndex = -1;
                grvWebListHocVien.Columns["DKW_Status"].VisibleIndex = -1;
                grvWebListHocVien.Columns["DKW_Code"].VisibleIndex = -1;
                grvWebListHocVien.Columns["DKW_TINID"].VisibleIndex = -1;
                grvWebListHocVien.Columns["DKW_DONID"].VisibleIndex = -1;
                grvWebListHocVien.Columns["DKW_CHUID"].VisibleIndex = -1;
                sselection = new GridCheckMarksSelection(grvWebListHocVien);
                sselection.CheckMarkColumn.VisibleIndex = 0;
                sselection.CheckMarkColumn.Width = 8;
                for (int i = 0; i < vtbl.Rows.Count; i++)
                {
                    if (int.Parse(vtbl.Rows[i]["DKW_Status"].ToString())==2)
                    {
                        sselection.SelectRow(i, true);
                    }
                }
               
            }
            
        }
        private Boolean updateStatusCall()
        {
            vDto = new WEB_DANGKIHOC();
            vBo = new BO_WEB_DANGKIHOC();
            try
            {
                for (int i = 0; i < grvWebListHocVien.RowCount; i++)
                {
                    DataRow dr = grvWebListHocVien.GetDataRow(i);
                    vDto.DKW_ID = int.Parse(dr["DKW_ID"].ToString());
                    if (sselection.IsRowSelected(i))
                    {
                        vDto.DKW_Status = 2;
                        vBo.updateStatus(vDto);
                    }
                    //else
                    //{
                    //    vDto.DKW_Status = 1;
                    //    vBo.updateStatus(vDto);
                    //}
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
            
        }
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (sselection.SelectedCount==0)
            {
                MessageBox.Show("Chưa chọn học viên", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(updateStatusCall())
            {
                MessageBox.Show("Cập nhật danh sách học viên đã gọi thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Có lỗi cập nhật danh sách học viên đã gọi điện", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnMoveStudents_Click(object sender, EventArgs e)
        {
            frmWebNhapHocVien frm = new frmWebNhapHocVien();
            if (cklWebDkh.CheckedItems.Count>1)
	        {
                MessageBox.Show("Chỉ được phép chọn một chứng chỉ","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
	        }
            else if (cklWebDkh.CheckedItems.Count==0)
            {
                MessageBox.Show("Chưa chọn chứng chỉ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                for (int i = 0; i < cklWebDkh.ItemCount; i++)
                {
                    if (cklWebDkh.GetItemChecked(i))
                    {
                        frm.gChungChiID = int.Parse(cklWebDkh.GetItemValue(i).ToString());
                    }

                }
                frm.ShowDialog();
            }
            
           
           
        }

    }
}
