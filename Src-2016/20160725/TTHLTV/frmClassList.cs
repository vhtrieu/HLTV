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

namespace TTHLTV
{
    public partial class frmClassList : DevExpress.XtraEditors.XtraForm
    {
        BO_LOP boLop = new BO_LOP();
        public frmClassList()
        {
            InitializeComponent();
        }

        #region Events
        private void frmCertificate_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridClass.MainView, new Font("Tahoma", 11));
            loadClass();
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
            //SimpleButton btnAddNews = (SimpleButton)sender;
            //frmAddNewClass frmAddClass = new frmAddNewClass();
            //frmAddClass.btnSender = btnAddNews.Text;
            //DataRow selectedRow = gridClassContent.GetDataRow(gridClassContent.FocusedRowHandle);
            //frmAddClass.sGridIndexCoures = gridClassContent.RowCount + 1;
            //int CcIds = int.Parse(selectedRow["LOP_CHCID"].ToString());
            //frmAddClass.sCcId = CcIds;
            //DialogResult result = frmAddClass.ShowDialog();
            //loadClass();
        }

        #endregion

        #region Extenal functions

      
        private void loadClass()
        {
            gridClass.DataSource = boLop.getLop_Alls_WhithCouresName();
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
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = gridClassContent.GetDataRow(gridClassContent.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa lớp học này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = int.Parse(selectedRow["LOP_ID"].ToString());
                    selectedRow.Delete();
                    boLop.delete(id);
                    loadClass();
                }
            }
        }

       
    }
}