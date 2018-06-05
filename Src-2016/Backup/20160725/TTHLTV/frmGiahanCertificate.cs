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
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Globalization;
namespace TTHLTV
{
    public partial class frmGiahanCertificate : DevExpress.XtraEditors.XtraForm
    {
        BO_CAP_CHUNGCHI boCcc = new BO_CAP_CHUNGCHI();
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        BO_MONHOC boMonHoc = new BO_MONHOC();
        private string mSoCc = string.Empty;
        private GridCheckMarksSelection sselection;
        int sAge = 0;

        public frmGiahanCertificate()
        {
            InitializeComponent();
        }
        #region events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void radNgayCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkDate();
        }
        private void frmGiahanCertificate_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridCertificate.MainView, new Font("Tahoma", 11));

            loadKhoaHoc();
            //loadLopHoc();
            checkDate();
            //checkAge();
            acticeSearch();
            checkInvisible();
            lookLopHoc.Enabled = false;
        }
        private void lookChungChi_EditValueChanged(object sender, EventArgs e)
        {
            lookLopHoc.Enabled = true;
            loadLopHoc();
            
        }
        private void lookLopHoc_EditValueChanged(object sender, EventArgs e)
        {
            loadDataToGrid();
         
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sselection.SelectedCount == 0)
            {
                MessageBox.Show("Chưa chọn học viên muốn gia hạn chứng chỉ", "THÔNG BÁO");
                return ;
            }
            
            string messages = "";
            string caption = "";
            messages = " Chắc chắn muốn gia hạn chứng chỉ cho học viên này ";
            caption = " THÔNG BÁO ";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(messages, caption, button);
            if (result == DialogResult.Yes)
            {

                if (SaveData())
                {
                    messages = " Cấp chứng chỉ thành công ";
                    caption = " THÔNG BÁO";
                    button = MessageBoxButtons.OK;
                    MessageBox.Show(messages, caption, button);
                    //showData();
                    loadDataToGrid();
                    this.Refresh();

                }
                else
                {
                   // MessageBox.Show("Gia hạn chứng chỉ không thành công","THÔNG BÁO");
                    return;
                }

               
            }
          
        }
        #endregion

        #region extenal function

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
        private DataTable getLopHoc()
        {
            BAL.BO_LOP bal = new BO_LOP();
            //return bal.getLop_Alls();
            return bal.getLOP_ByCcID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
        }
        private void loadLopHoc()
        {
            lookLopHoc.Properties.DataSource = getLopHoc();
            lookLopHoc.Properties.ValueMember = "LOP_ID";
            lookLopHoc.Properties.DisplayMember = "LOP_Name";
            //lookLopHoc.ItemIndex = 0;
        }
        private void checkDate()
        {
            if (radNgayCap.SelectedIndex == 0)
            {
                dateNgayCap.Enabled = false;
                dateNgayHetHan.Enabled = false;
                dateNgayCap.DateTime = DateTime.Now;
                dateNgayHetHan.DateTime = new DateTime(dateNgayCap.DateTime.Year + 5, dateNgayCap.DateTime.Month, dateNgayCap.DateTime.Day, dateNgayCap.DateTime.Hour, dateNgayCap.DateTime.Minute, dateNgayCap.DateTime.Second, dateNgayCap.DateTime.Millisecond);

            }
            else
                if (radNgayCap.SelectedIndex == 1)
                {
                    dateNgayCap.Enabled = true;
                    dateNgayHetHan.Enabled = false;
                    dateNgayHetHan.DateTime = new DateTime(dateNgayCap.DateTime.Year + 5, dateNgayCap.DateTime.Month, dateNgayCap.DateTime.Day, dateNgayCap.DateTime.Hour, dateNgayCap.DateTime.Minute, dateNgayCap.DateTime.Second, dateNgayCap.DateTime.Millisecond);
                }

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
        private void checkInvisible()
        {
            if (radioTimKiem.SelectedIndex == 0)
            {
                groupTK_CaNhan.Enabled = false;

            }
            else
            {
                groupTK_CaNhan.Enabled = true;

            }
        }
        private DataTable getLopDaCapCC()
        {
            //DataTable spTable = new DataTable("LopDaCaCC");
            //spTable = boDkh.getDangKiHoc_Name_ByLopID( int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            //spTable.TableName = "LopDaCaCC";

            DataTable cCMhTable = new DataTable();
            DataTable dsHvDaCapCC = new DataTable("dsHvDaCapCC");
            DataColumn column = new DataColumn();
            dsHvDaCapCC.Columns.Add("HvID", typeof(int));
            dsHvDaCapCC.Columns.Add("Họ", typeof(string));
            dsHvDaCapCC.Columns.Add("Tên", typeof(string));
            dsHvDaCapCC.Columns.Add("Ngày sinh", typeof(string));
            cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < cCMhTable.Rows.Count; i++)
            {
                dsHvDaCapCC.Columns.Add(cCMhTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            dsHvDaCapCC.Columns.Add("Số CC", typeof(string));
            dsHvDaCapCC.Columns.Add("Ngày cấp", typeof(string));
            dsHvDaCapCC.Columns.Add("CCC_LOPID", typeof(int));
            DataTable tbs = new DataTable();
            tbs = boDkh.getDangKiHoc_Name_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));

            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = dsHvDaCapCC.NewRow();
                newRow.ItemArray = dr.ItemArray;
                dsHvDaCapCC.Rows.Add(newRow);
            }
            return dsHvDaCapCC;

        }
        private void showLopDaCapCC()
        {
            gridContentCertificate.Columns.Clear();
            gridCertificate.DataSource = getLopDaCapCC();

            gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            gridContentCertificate.Columns["CCC_LOPID"].VisibleIndex = -1;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatString = "dd/MM/yyyy";
            gridContentCertificate.Columns["Ngày cấp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            gridContentCertificate.Columns["Ngày cấp"].DisplayFormat.FormatString = "dd/MM/yyyy";

        }
        private void showData()
        {
            gridContentCertificate.Columns.Clear();
            gridCertificate.DataSource = GetTable();

            gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            gridContentCertificate.Columns["CCC_LOPID"].VisibleIndex = -1;
            gridContentCertificate.Columns.Add();
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatString = "dd/MM/yyyy";
        }
        private DataTable GetTable()
        {
            string DD = string.Empty;
            DataTable cCMhTable = new DataTable();
            DataTable tableDiem = new DataTable("TempDiem");
            DataColumn column = new DataColumn();
            tableDiem.Columns.Add("HvID", typeof(int));
            tableDiem.Columns.Add("Họ", typeof(string));
            tableDiem.Columns.Add("Tên", typeof(string));
            tableDiem.Columns.Add("Ngày sinh", typeof(string));
            cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < cCMhTable.Rows.Count; i++)
            {
                tableDiem.Columns.Add(cCMhTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            tableDiem.Columns.Add("Số CC", typeof(string));
            tableDiem.Columns.Add("Ngày cấp", typeof(string));
            tableDiem.Columns.Add("CCC_LOPID", typeof(int));

            DataTable tbs = new DataTable();
            tbs = boCcc.GetData_For_CAP_CHUNGCHI_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            // For testing start

            //for (int ii = 0; ii < tbs.Rows.Count - 1; ii++)
            //{
            //    DataRow newRow = tableDiem.NewRow();
            //    newRow["HvID"] = tbs.Rows[ii]["TEM_HOVID"].ToString();
            //    newRow["Họ"] = tbs.Rows[ii]["TEM_HOVFIRSTNAME"].ToString();
            //    newRow["Tên"] = tbs.Rows[ii]["TEM_HOVLASTNAME"].ToString();
            //    newRow["Ngày sinh"] = tbs.Rows[ii]["TEM_HOVBIRTHDAY"].ToString();
            //    for (int ik = 0; ik < cCMhTable.Rows.Count; ik++)
            //    {
            //        string sFiledName = cCMhTable.Rows[ik]["MonHoc"].ToString();
            //        newRow[sFiledName] = tbs.Rows[ii][sFiledName].ToString();
            //    }
            //    newRow["Số CC"] = "";
            //    newRow["Ngày cấp"] = "";
            //    tableDiem.Rows.Add(newRow);
            //}

            // Testing end.
            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = tableDiem.NewRow();
                newRow.ItemArray = dr.ItemArray;
                tableDiem.Rows.Add(newRow);
            }
            return tableDiem;
        }
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return sselection;
            }
        }
        private void loadDataToGrid()
        {
            DataTable temTb = new DataTable();
            DataTable tb1 = new DataTable();
            DataTable tb2 = new DataTable();
            temTb = boDkh.getDangKiHoc_Name_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            if (temTb.Rows.Count > 0)
            {

                tb1 = getLopDaCapCC();
                tb2 = GetTable();

                foreach (DataRow item in tb2.Rows)
                {
                    DataRow newRow = tb1.NewRow();
                    newRow.ItemArray = item.ItemArray;
                    tb1.Rows.Add(newRow);
                }
                DataTable tbst = new DataTable();
                tbst = tb1.Clone();
                for (int i = 0; i < tb1.Rows.Count; i++)
                {
                    DateTime datetime;
                    string StringDate = string.Empty;
                    int tb1ColCount = tb1.Columns.Count;
                    if (tb1.Rows[i][tb1ColCount - 2].ToString() != "")
                    {
                        datetime = Convert.ToDateTime(tb1.Rows[i][tb1ColCount - 2].ToString());
                        datetime = Convert.ToDateTime(datetime.ToShortDateString());
                        StringDate = datetime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        StringDate = StringDate.ToString().Substring(0, 2) + "/" + StringDate.ToString().Substring(3, 2) + "/" + StringDate.ToString().Substring(6, 4);

                    }
                    DataRow tbstRow = tbst.NewRow();

                    tbstRow[0] = tb1.Rows[i][0].ToString();
                    tbstRow[1] = tb1.Rows[i][1].ToString();
                    tbstRow[2] = tb1.Rows[i][2].ToString();
                    tbstRow[3] = tb1.Rows[i][3].ToString();
                    int subColTotal = tb1ColCount - 7;
                    for (int isd = 4; isd < tb1ColCount - 3; isd++)
                    {
                        tbstRow[isd] = tb1.Rows[i][isd].ToString();
                    }
                    tbstRow[tb1ColCount - 3] = tb1.Rows[i][tb1ColCount - 3].ToString();
                    tbstRow[tb1ColCount - 2] = StringDate.ToString(); // tb1.Rows[i][tb1ColCount - 3].ToString();
                    if (tb1.Rows[i][tb1ColCount - 1].ToString() != "")
                    {
                        tbstRow[tb1ColCount - 1] = tb1.Rows[i][tb1ColCount - 1].ToString();

                        tbst.Rows.Add(tbstRow);
                    }

                }
                gridContentCertificate.Columns.Clear();
                gridCertificate.DataSource = tbst;

                gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
                gridContentCertificate.Columns["CCC_LOPID"].VisibleIndex = -1;
                sselection = new GridCheckMarksSelection(gridContentCertificate);
                sselection.CheckMarkColumn.VisibleIndex = 0;
                sselection.CheckMarkColumn.Width = 8;
            }
            else
            {
                showData();

                sselection = new GridCheckMarksSelection(gridContentCertificate);
                sselection.CheckMarkColumn.VisibleIndex = 0;
            }
            DataTable lastSoCc = new DataTable();
            lastSoCc = boCcc.getLast_SoCc(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            if (lastSoCc.Rows.Count <= 0)
            {
                txtSoCcCuoi.Text = " 000000GTVT";
                return;
            }
            else
            {
                txtSoCcCuoi.Text = lastSoCc.Rows[0]["SoCc"].ToString() + "GTVT";
                // mSoCc = lastSoCc.Rows[0]["SoCc"].ToString();
                mSoCc = txtSoCcCuoi.Text;
            }
        }
        private Boolean SaveData()
        {
            DateTime CCC_NgayCaps = DateTime.Now;
            DateTime CCC_NgayHetHan = DateTime.Now;
            if (sselection.SelectedCount > 0)
            {
                for (int i = 0; i < gridContentCertificate.RowCount; i++)
                {

                    if (sselection.IsRowSelected(i))
                    {
                        // Update coder
                        DataRow dr = gridContentCertificate.GetDataRow(i);
                        int HvId = int.Parse(dr["HvId"].ToString());
                        int LopId = int.Parse(dr["CCC_LOPID"].ToString());
                        object sNgayCap;
                        object sNgayHetHan;
                        sNgayCap = dateNgayCap.Text.Substring(3, 2) + "/" + dateNgayCap.Text.Substring(0, 2) + "/" + dateNgayCap.Text.Substring(6, 4);
                        sNgayHetHan = dateNgayHetHan.Text.Substring(3, 2) + "/" + dateNgayHetHan.Text.Substring(0, 2) + "/" + dateNgayHetHan.Text.Substring(6, 4);
                        CCC_NgayCaps = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", sNgayCap.ToString()));
                        CCC_NgayHetHan = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", sNgayHetHan.ToString()));
                        boCcc.CapLaiChungChi(HvId, LopId, CCC_NgayCaps, CCC_NgayHetHan, 3);
                    }

                }
            }
            return true;
 
        }
        #endregion

      
    }

  
}