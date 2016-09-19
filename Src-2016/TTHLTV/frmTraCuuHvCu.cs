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
    public partial class frmTraCuuHvCu : DevExpress.XtraEditors.XtraForm
    {
        BO_HOCVIEN boHv = new BO_HOCVIEN();
        private string vHvID = string.Empty;
        public frmTraCuuHvCu()
        {
            InitializeComponent();
        }
        private DataSet sLookupName()
        {
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sSearchTable");

            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            sTable.Rows.Add(1, "Họ và tên");
            sTable.Rows.Add(2, "Tên");
            sTable.Rows.Add(3, "Họ");
            sTable.Rows.Add(4, "Ngày sinh");
            sTable.Rows.Add(5, "Nơi sinh");
            sTable.Rows.Add(6, "Điện thoại");
            sTable.Rows.Add(7, "Số chứng chỉ");
            return sDataset;

        }
        private DataSet sLookupCondition()
        {
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sConditionTable");

            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            sTable.Rows.Add(1, "Có chứa");
            sTable.Rows.Add(2, "Bắt đầu");

            return sDataset;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmTraCuuHvCu_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridStudentsList.MainView, new Font("Tahoma", 11));
            Utilities.setFontSize.SetGridFont(gridMarks.MainView, new Font("Tahoma", 11));
            Utilities.setFontSize.SetGridFont(gridLop.MainView, new Font("Tahoma", 11));
            acticeSearch();
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
        private void txtSearchText_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (txtSearchText.Text != string.Empty)
            {
                searchHocVien(txtSearchText.Text);
            }
            else
            {
                gridStudentsList.DataSource = null;
                gridMarks.DataSource = null;
                gridLop.DataSource = null;
            }
        }
        private void searchHocVien(string textSearch)
        {
            DataTable tbHocVien = new DataTable();
            if (grpChungChi.SelectedIndex==0)
            {
                //1. Full name
                if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 1)
                {
                    tbHocVien = boHv.searchHocVienByFullName_1(textSearch);
                }
                //2. Last name
                else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 2)
                {
                    tbHocVien = boHv.searchHocVienByLastName_1(textSearch);
                }
                //3. Firstname
                else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 3)
                {
                    tbHocVien = boHv.searchHocVienByFirstName_1(textSearch);
                }
                //7.Theo số chứng chỉ
                else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 7)
                {
                    tbHocVien = boHv.searchHocVienBySoCC_1(textSearch + " GTVT");
                }
            }
            else if (grpChungChi.SelectedIndex==1)
            {
                //1. Full name
                if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 1)
                {
                    tbHocVien = boHv.searchHocVienByFullName_1_Doi(textSearch);
                }
                //2. Last name
                else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 2)
                {
                    tbHocVien = boHv.searchHocVienByLastName_1_Doi(textSearch);
                }
                //3. Firstname
                else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 3)
                {
                    tbHocVien = boHv.searchHocVienByFirstName_1_Doi(textSearch);
                }
                //7.Theo số chứng chỉ
                else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 7)
                {
                    tbHocVien = boHv.searchHocVienBySoCC_1_Doi(textSearch + " GTVT");
                }
            }

            gridStudentsList.DataSource = tbHocVien;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchText.Text != string.Empty)
            {
                searchHocVien(txtSearchText.Text);
            }
            else
            {
                gridStudentsList.DataSource = null;
                gridMarks.DataSource = null;
                gridLop.DataSource = null;
            }
            

        }
        private void btnSearchScc_Click(object sender, EventArgs e)
        {
            DataTable tbHocVien = new DataTable();
            string textSearch = string.Empty;
            if (txtSoCC.Text == "")
            {
                MessageBox.Show("Chưa nhập số chứng chỉ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtSoCC.Text.Length != 5)
            {
                MessageBox.Show("Số chứng chỉ có 5 chữ số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                textSearch = txtSoCC.Text + " " + txtText.Text;
                tbHocVien = boHv.searchHocVienBySoCC_1_Doi(textSearch);
                gridStudentsList.DataSource = null;
                gridStudentsList.DataSource = tbHocVien;
            }
        }
        private void gridStudentContent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow currentRow = gridStudentContent.GetDataRow(e.RowHandle);
            if (true)
            {
                
            }
            if (grpChungChi.SelectedIndex==0)
            {
                vHvID = currentRow["MAHOCVIEN"].ToString();
                gridMarks.DataSource = boHv.search_Diem_ByHocVienId_1(vHvID);
                gridLop.DataSource = vLopTable(vHvID);
            }
            else if (grpChungChi.SelectedIndex == 1)
            {
                vHvID = currentRow["MAHOCVIEN"].ToString();
                gridLop.DataSource = vLopTable(vHvID);
                gridMarks.DataSource = null;
            }
        }
        private DataTable vLopTable(string strSeach)
        {
            DAL.DAL_HOCVIEN vDal = new DAL.DAL_HOCVIEN();
            DataTable vTable = new DataTable();
            if (grpChungChi.SelectedIndex == 0)
            {
                vTable = vDal.searchLop_By_MaHocVien_1(strSeach);
                if (vTable.Rows.Count<1)
                {
                    vTable = vDal.searchLop_By_MaHocVien_1_Doi(strSeach.ToString());
                }
            }
            else if (grpChungChi.SelectedIndex == 1)
            {
                vTable = vDal.searchLop_By_MaHocVien_1_Doi(strSeach.ToString());
            }
            return vTable;
        }

        
    }
}