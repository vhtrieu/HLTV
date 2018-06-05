using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using TTHLTV.BAL;
//using Entetities;

namespace TTHLTV
{
    public partial class frmSubject : DevExpress.XtraEditors.XtraForm
    {
       // BO_Subjects ctrlSubject = new BO_Subjects();
        BO_MONHOC mHoc = new BO_MONHOC();
        public frmSubject()
        {
            InitializeComponent();
           
        }

        #region Events
        private void frmSubject_Load(object sender, EventArgs e)
        {
            
            loadSubject();
            SetGridFont(gridSubjects.MainView, new Font("Tahoma", 11));
            // Biding data to search tool
            lookSearchBy.Properties.DataSource = sLookupName().Tables["sSearchTable"];
            lookSearchBy.Properties.ValueMember = "ID";
            lookSearchBy.Properties.DisplayMember = "Name";
            lookSearchBy.ItemIndex = 0;

            lookCondition.Properties.DataSource = sLookupCondition().Tables["sConditionTable"];
            lookCondition.Properties.ValueMember = "ID";
            lookCondition.Properties.DisplayMember = "Name";
            lookCondition.ItemIndex = 0;

        }
                     
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SimpleButton btnAddNews = (SimpleButton)sender;
            frmAddNewSubject frmNSubject = new frmAddNewSubject();
            frmNSubject.btnSender = btnAddNews.Text;
            frmNSubject.sgetIndexGrid = gvSubject.RowCount + 1;
            DialogResult result = frmNSubject.ShowDialog();
            loadSubject();
        }
        #endregion

        #region Extenal functions

        void loadSubject()
        {
            gridSubjects.DataSource = mHoc.getMonHoc_All();

        }

        private void SetGridFont(DevExpress.XtraGrid.Views.Base.BaseView baseView , Font sFont)
        {
            foreach (AppearanceObject ap in baseView.Appearance)
            {
                ap.Font = sFont;
            }

        }

        private DataSet sLookupName()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sSearchTable");

            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "Tên giảng viên");
            sTable.Rows.Add(2, "Mã giảng viên");
            sTable.Rows.Add(3, "Khóa học");

            return sDataset;

        }
        private DataSet sLookupCondition()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sConditionTable");

            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "Có chứa");
            sTable.Rows.Add(2, "Bắt đầu");

            return sDataset;

        }

        #endregion

        private void btnDetail_Click(object sender, EventArgs e)
        {
            SimpleButton btnDetails = (SimpleButton)sender;
            frmAddNewSubject frmNSubject = new frmAddNewSubject();

            frmNSubject.btnSender = btnDetails.Text;
            DataRow selectedRow = gvSubject.GetDataRow(gvSubject.FocusedRowHandle);
            string Codes = selectedRow["MON_Code"].ToString();
            string Names = selectedRow["MON_Name"].ToString();
           int SoTiets = int.Parse( selectedRow["MON_SoTiet"].ToString());
            int ids = int.Parse(selectedRow["MON_ID"].ToString());

            frmNSubject.sCode = Codes;
            frmNSubject.sName = Names;
            frmNSubject.sSoTiet = SoTiets;
            frmNSubject.sId = ids;

            DialogResult result = frmNSubject.ShowDialog();
            loadSubject();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = gvSubject.GetDataRow(gvSubject.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa môn học này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = int.Parse(selectedRow["MON_ID"].ToString());
                    selectedRow.Delete();
                    mHoc.delete(id);
                    loadSubject();
                }
            }
        }

        private void gvSubject_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView btnDetails = (DevExpress.XtraGrid.Views.Grid.GridView)sender;

            frmAddNewSubject frmAddSubject = new frmAddNewSubject();
            frmAddSubject.btnSender = btnDetails.Appearance.ViewCaption.ToString();
            DataRow selectedRow = gvSubject.GetDataRow(gvSubject.FocusedRowHandle);
            string Codes = selectedRow["MON_Code"].ToString();
            string Names = selectedRow["MON_Name"].ToString();
            int sotiet = int.Parse( selectedRow["MON_SoTiet"].ToString());
            int ids = int.Parse(selectedRow["MON_ID"].ToString());
            frmAddSubject.sCode = Codes;
            frmAddSubject.sName = Names;
            frmAddSubject.sSoTiet = sotiet;
            frmAddSubject.sId = ids;
            //frmAddCoures.ShowDialog();
            DialogResult result = frmAddSubject.ShowDialog();
            loadSubject();
        }
    }
}