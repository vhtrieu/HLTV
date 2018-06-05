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
    public partial class frmReCertification : DevExpress.XtraEditors.XtraForm
    {
        BO_DANG_KI_HOC dkHoc = new BO_DANG_KI_HOC();
        BO_CAP_CHUNGCHI bo_Cap_ChungChi = new BO_CAP_CHUNGCHI();
        DataTable table_cap_chung_chi = new DataTable();
        public frmReCertification()
        {
            InitializeComponent();
        }
        #region Load lookup chung chi
        private DataTable getKhoaHoc()
        {
            BAL.BO_CHUNG_CHI bal = new BO_CHUNG_CHI();
            return bal.getChungChi_All();
        }
        private void loadKhoaHoc()
        {
            lookChungChi.Properties.DataSource = getKhoaHoc();
            lookChungChi.Properties.ValueMember = "CHC_ID";
            lookChungChi.Properties.DisplayMember = "CHC_Name";
            //lookChungChi.ItemIndex = 0;
        }

        #endregion
        #region Load lookup lop hoc
        private DataTable getLopHoc()
        {
            BAL.BO_LOP bal = new BO_LOP();
            return bal.getLop_Alls();
        }
        private void loadLopHoc()
        {
            lookLopHoc.Properties.DataSource = getLopHoc();
            lookLopHoc.Properties.ValueMember = "LOP_ID";
            lookLopHoc.Properties.DisplayMember = "LOP_Name";
            //lookLopHoc.ItemIndex = 0;
        }
        #endregion


        private void searchCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC_NAME_CONTAIN(int KHOAHOC_ID,int LOP_ID,string lastName)
        {
            table_cap_chung_chi = bo_Cap_ChungChi.searchCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC_NAME_CONTAIN(KHOAHOC_ID, LOP_ID, lastName);
            gridStudentsList.DataSource = table_cap_chung_chi;
        }
        private void acticeSearch()
        {
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
            sTable.Rows.Add(2, "Mã học viên");
            sTable.Rows.Add(3, "Lớp học");

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
        #region event
        private void frmReCertification_Load(object sender, EventArgs e)
        {
            loadKhoaHoc();
            loadLopHoc();
            acticeSearch();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC_NAME_CONTAIN(Convert.ToInt32(lookChungChi.GetColumnValue("")), Convert.ToInt32(lookLopHoc.GetColumnValue("")), txtSearchText.Text);
        }

        private void gridStudentContent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //MessageBox.Show(e.RowHandle.ToString());
            //int Ma_HocVien = Convert.ToInt32(gridStudentContent.GetRowCellValue(e.RowHandle, "HOV_ID"));
            if (table_cap_chung_chi.Rows.Count > 0)
            {

                int Ma_HocVien = Convert.ToInt32(table_cap_chung_chi.Rows[e.RowHandle]["HOV_ID"]);
                BO_DANG_KI_HOC bo_dangki_hoc = new BO_DANG_KI_HOC();
                gridMarks.DataSource = bo_dangki_hoc.getDANG_KI_HOC_By_HocVien_ID(Ma_HocVien);
                BO_CAP_CHUNGCHI bo_cap_chungchi = new BO_CAP_CHUNGCHI();
                gridTeached.DataSource = bo_cap_chungchi.getCAP_CHUNG_CHI_By_HocVienID(Ma_HocVien);
                #region left panel info
                txtStudentName.Text = table_cap_chung_chi.Rows[e.RowHandle]["FirstName"].ToString() + table_cap_chung_chi.Rows[e.RowHandle]["LastName"].ToString();
                dateBirthDay.DateTime = Convert.ToDateTime(table_cap_chung_chi.Rows[e.RowHandle]["BirthDay"].ToString());
                txtCerNumber.Text = table_cap_chung_chi.Rows[e.RowHandle]["SoCC"].ToString();
                //dateAllocate.DateTime = Convert.ToDateTime(table_cap_chung_chi.Rows[e.RowHandle]["BirthDay"].ToString());
                //dateExpire.DateTime = Convert.ToDateTime(table_cap_chung_chi.Rows[e.RowHandle]["BirthDay"].ToString());
                checkDate();
                #endregion
            }

        }

        private void checkDate()
        {
            dateNewAllocate.DateTime = DateTime.Now;
            dateNewExpire.DateTime = new DateTime(dateNewAllocate.DateTime.Year + 5, dateNewAllocate.DateTime.Month, dateNewAllocate.DateTime.Day, dateNewAllocate.DateTime.Hour, dateNewAllocate.DateTime.Minute, dateNewAllocate.DateTime.Second, dateNewAllocate.DateTime.Millisecond);
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}