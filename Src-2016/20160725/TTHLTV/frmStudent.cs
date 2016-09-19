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
    public partial class frmStudent : DevExpress.XtraEditors.XtraForm
    {
        BO_HOCVIEN boHv = new BO_HOCVIEN();
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        public frmStudent()
        {
            InitializeComponent();
        }

        #region Variable
        

#endregion

        #region Events
        private void frmStudent_Load(object sender, EventArgs e)
        {
            loadHocVien();
            Utilities.setFontSize.SetGridFont(gridTrainee.MainView, new Font("Tahoma", 11));
            btnStuDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnStuAddNew.Enabled = false;
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

        private void btnStuAddNew_Click(object sender, EventArgs e)
        {

            //txtStuCode.Text = "HV" + Utilities.quydinh.LaySTT(gvTrainees.RowCount + 1);
            //frmAddNewStudent  = new frmAddNewStudent();
            //frmDeStu.sGetGridViewIndex = gvTrainees.RowCount + 1;
            //DialogResult result = frmDeStu.ShowDialog();
         

            SimpleButton btnAddNews = (SimpleButton)sender;
            frmAddNewStudent frmDeStu = new frmAddNewStudent();
            frmDeStu.btnSender = btnAddNews.Text;
            frmDeStu.sGetGridViewIndex = gvTrainees.RowCount + 1;
            DialogResult result = frmDeStu.ShowDialog();
            loadHocVien();

        }

        private void gvTrainees_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            btnStuDelete.Enabled = true;

        }

        private void btnStuDelete_Click(object sender, EventArgs e)
        {
            DataTable tbl_HvDoi = new DataTable();
            DataTable tbl_HvDkh = new DataTable();

            DataRow selectedRow = gvTrainees.GetDataRow(gvTrainees.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa học viên này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //trainee_DTO = new ENT_Trainees();
                    //trainee_DTO.TRE_ID = int.Parse(selectedRow["TRE_ID"].ToString());
                    //selectedRow.Delete();
                    //clearInputData();
                    //ctrlTrainee.deleteTrainee(trainee_DTO);
                    int hvID = int.Parse(selectedRow["HOV_ID"].ToString());
                    // Check ton tai hoc vien co ton tai trong lop hoc, hoac cap doi, cap lai khong duoc xoa ( 2013.03.30 )
                    tbl_HvDkh = boHv.vCheck_Delete_Hv_Dang_Ki_Hoc(hvID);
                    tbl_HvDoi = boHv.vCheck_Delete_HvDoi(hvID);
                    if (tbl_HvDkh.Rows.Count>0)
                    {
                        MessageBox.Show("Học viên này đang tồn tại trong lớp " + tbl_HvDkh.Rows[0]["LOP_Name"].ToString() + " khóa " + tbl_HvDkh.Rows[0]["LOP_Khoa"].ToString() + "", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (tbl_HvDoi.Rows.Count>0)
                    {
                        MessageBox.Show("Học viên này đang tồn tại trong lớp cấp đổi","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        selectedRow.Delete();
                        boHv.delete(hvID);
                        boDkh.getDANG_KI_HOC_By_HocVien_ID(hvID);
                        boHv.Delete_DiemHocVien_by_HvId(hvID);
                        loadHocVien();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //trainee_DTO = new ENT_Trainees();
            //trainee_DTO.TRE_ID = 1;
            //trainee_DTO.TRE_Code = txtStuCode.Text;
            //trainee_DTO.TRE_FullName = txtStuName.Text;
            //trainee_DTO.TRE_BirthDate = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", deBrithdate.Text));
            //trainee_DTO.TRE_Certificates = txtCer.Text;
            //trainee_DTO.TRE_GraduatedSpeciality = txtGraSpec.Text;
            //trainee_DTO.TRE_Phone = txtPhone.Text;
            //trainee_DTO.TRE_PlaceOfBirth = txtStuProvice.Text;
            //trainee_DTO.TRE_GraduatedYear = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", deGraYear.Text));
            //trainee_DTO.TRE_Address = txtAddress.Text;
            //ctrlTrainee.insertTrainee(trainee_DTO);
            loadHocVien();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = gvTrainees.GetDataRow(gvTrainees.FocusedRowHandle);
            //trainee_DTO = new ENT_Trainees();
            //trainee_DTO.TRE_ID = int.Parse(selectedRow["TRE_ID"].ToString());
            //trainee_DTO.TRE_Code = txtStuCode.Text;
            //trainee_DTO.TRE_FullName = txtStuName.Text;
            //trainee_DTO.TRE_BirthDate = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", deBrithdate.Text));
            //trainee_DTO.TRE_Certificates = txtCer.Text;
            //trainee_DTO.TRE_GraduatedSpeciality = txtGraSpec.Text;
            //trainee_DTO.TRE_Phone = txtPhone.Text;
            //trainee_DTO.TRE_PlaceOfBirth = txtStuProvice.Text;
            //trainee_DTO.TRE_GraduatedYear = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", deGraYear.Text));
            //trainee_DTO.TRE_Address = txtAddress.Text;
            //ctrlTrainee.updateTrainee(trainee_DTO);
            loadHocVien();
        }

        private void btnStuSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                //gridTrainee.DataSource = ctrlTrainee.getTraineeByFullName(txtSearch.Text, 0);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadHocVien();
        }

        private void btnStuDetail_Click(object sender, EventArgs e)
        {
            SimpleButton btnDetails = (SimpleButton)sender;
            frmAddNewStudent frmDeStu = new frmAddNewStudent();
            frmDeStu.btnSender = btnDetails.Text;
            frmDeStu.vRow = gvTrainees.GetDataRow(gvTrainees.FocusedRowHandle);
            DialogResult result = frmDeStu.ShowDialog();
            loadHocVien();
        }

        #endregion

        #region Methods

        void loadHocVien()
        {
            gridTrainee.DataSource = boHv.getAll(); 
        }
        void clearInputData()
        {
            txtStuCode.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtGraSpec.Text = string.Empty;
            txtStuName.Text = string.Empty;
            txtStuProvice.Text = string.Empty;
            deBrithdate.Text = string.Empty;
            deGraYear.Text = string.Empty;
            txtCer.Text = string.Empty;
            txtPhone.Text = string.Empty;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
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
            sTable.Rows.Add(1, "Tên học viên");
            sTable.Rows.Add(2, "Họ");
            sTable.Rows.Add(3, "Ngày sinh");
            sTable.Rows.Add(4, "Nơi sinh");
            sTable.Rows.Add(5, "Điện thoại");
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
        private void searchHocVien(string textSearch)
        {
            DataTable tbHocVien = new DataTable();
            //1. Lastname
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 1)
            {
                //tbHocVien = boHv.searchHocVienByLastName(textSearch);
                tbHocVien = boHv.searchHocVienByFullName(textSearch);
            }
            //2. Firstname
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 2)
            {
                tbHocVien = boHv.searchHocVienByFirstName(textSearch);
            }
            //3.Ngay sinh
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 3)
            {
                tbHocVien = boHv.searchHocVienByBirthday(textSearch);
            }
            //4. Noi sinh
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 4)
            {
                tbHocVien = boHv.searchHocVienByNoiSinh(textSearch);
            }
            //Dien thoai
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 5)
            {
                tbHocVien = boHv.searchHocVienByDienThoai(textSearch);
            }

            gridTrainee.DataSource = tbHocVien;
        }
        #endregion

        private void txtSearch_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                searchHocVien(txtSearch.Text);
            }
            else
            {
                //gridTrainee.DataSource = null;
                loadHocVien();
               
            }
        }

        
    }
}