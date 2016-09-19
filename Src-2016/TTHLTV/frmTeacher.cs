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
using DevExpress.XtraGrid.Views.Base;
using TTHLTV.BAL;
//using Entetities;

namespace TTHLTV
{
    public partial class frmTeacher : DevExpress.XtraEditors.XtraForm
    {
        #region "private Object"
        BO_GIANGVIEN boGV = new BO_GIANGVIEN();
        //ENT_Trainers tranier_ENT;
        #endregion
        public frmTeacher()
        {
            InitializeComponent();
        }

        #region "EVENT"
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = gridContentTeacher.GetDataRow(gridContentTeacher.FocusedRowHandle);
            //tranier_ENT = new ENT_Trainers();
            //tranier_ENT.TRR_ID = int.Parse(selectedRow["TRR_ID"].ToString());
            //tranier_ENT.TRR_Code = txtTeachCode.Text;
            //tranier_ENT.TRR_FullName = txtTeachName.Text;
            //tranier_ENT.TRR_Degree = txtDegree.Text;
            //tranier_ENT.TRR_Rank = txtTeachRank.Text;
            //tranier_ENT.TRR_TeachingSubjects = txtTeachSubject.Text;
            //tranier_ENT.TRR_Address = txtAddress.Text;
            //tranier_ENT.TRR_CellPhone = txtCellPhone.Text;
            //teacher.updateTrainer(tranier_ENT);
            loadTrainerList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //tranier_ENT = new ENT_Trainers();
            //tranier_ENT.TRR_ID = 1;
            //tranier_ENT.TRR_Code = txtTeachCode.Text;
            //tranier_ENT.TRR_FullName = txtTeachName.Text;
            //tranier_ENT.TRR_Degree = txtDegree.Text;
            //tranier_ENT.TRR_Rank = txtTeachRank.Text;
            //tranier_ENT.TRR_TeachingSubjects = txtTeachSubject.Text;
            //tranier_ENT.TRR_Address = txtAddress.Text;
            //tranier_ENT.TRR_CellPhone = txtCellPhone.Text;
            //teacher.insertTrainer(tranier_ENT);
            loadTrainerList();           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            clearInputData();
            int count = (gridContentTeacher.RowCount > 0) ? gridContentTeacher.RowCount : 0;
            txtTeachCode.Text = "GV" + Utilities.quydinh.LaySTT(gridContentTeacher.RowCount + 1);
            txtTeachName.Focus();
            btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }


        private void frmTeacher_Load(object sender, EventArgs e)
        {
            loadTrainerList();
            SetGridFont(gridTeacher.MainView, new Font("Tahoma", 11));
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
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


       
        private void gridContentTeacher_RowClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //DataRow selectedRow = gridContentTeacher.GetDataRow(gridContentTeacher.FocusedRowHandle);
            //txtTeachName.Text = selectedRow["TRR_FullName"].ToString();
            //txtDegree.Text = selectedRow["TRR_Degree"].ToString();
            //txtTeachRank.Text = selectedRow["TRR_Rank"].ToString();
            //txtTeachSubject.Text = selectedRow["TRR_TeachingSubjects"].ToString();
            //txtAddress.Text = selectedRow["TRR_Address"].ToString(); ;
            //txtCellPhone.Text = selectedRow["TRR_CellPhone"].ToString();
            //txtTeachCode.Text = selectedRow["TRR_Code"].ToString();
            //btnSave.Enabled = false;
            //btnEdit.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadTrainerList();
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {

            SimpleButton btnAddNews = (SimpleButton)sender;
            frmAddNewTeacher frmDeTeacher = new frmAddNewTeacher();
            frmDeTeacher.btnSender = btnAddNews.Text;
            frmDeTeacher.sGetGridViewIndex = gridContentTeacher.RowCount + 1;
            DialogResult result = frmDeTeacher.ShowDialog();
            loadTrainerList();

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = gridContentTeacher.GetDataRow(gridContentTeacher.FocusedRowHandle);
            SimpleButton btnDetails = (SimpleButton)sender;
            frmAddNewTeacher frmDeTeacher = new frmAddNewTeacher();

            frmDeTeacher.btnSender = btnDetails.Text;
            int ids = int.Parse(selectedRow["GIV_ID"].ToString());
            string Codes = selectedRow["GIV_Code"].ToString();
            string NamesF = selectedRow["GIV_Name"].ToString();
            string Fones = selectedRow["GIV_Phone"].ToString();
            string DiaChis = selectedRow["GIV_Address"].ToString();
            string Khoas = selectedRow["GIV_Khoa"].ToString();

            frmDeTeacher.sId = ids;
            frmDeTeacher.sCode = Codes;
            frmDeTeacher.sName = NamesF;
            frmDeTeacher.sDienThoai = Fones;
            frmDeTeacher.sDiaChi = DiaChis;
            frmDeTeacher.sKhoa = Khoas;

            DialogResult result = frmDeTeacher.ShowDialog();
            loadTrainerList();

        }
        #endregion

        #region "Internal function"

        void loadTrainerList()
        {
            gridTeacher.DataSource = boGV.getGianngVien_All();
        }
        void clearInputData()
        {
            txtTeachCode.Text       = string.Empty;
            txtTeachName.Text       = string.Empty;
            txtDegree.Text          = string.Empty;
            txtTeachSubject.Text    = string.Empty;
            txtTeachRank.Text       = string.Empty;
            txtCellPhone.Text       = string.Empty;
            txtAddress.Text         = string.Empty;
            btnEdit.Enabled         = false;
            btnSave.Enabled         = false;
        }


       
        private void SetGridFont(DevExpress.XtraGrid.Views.Base.BaseView baseView, Font sFont)
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

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            DataRow selectedRow = gridContentTeacher.GetDataRow(gridContentTeacher.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa giảng viên này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int gvID = int.Parse(selectedRow["GIV_ID"].ToString());
                    selectedRow.Delete();
                    boGV.delete(gvID);                   
                    loadTrainerList();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

     

    }
}