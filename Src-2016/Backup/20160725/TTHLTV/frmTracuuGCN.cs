using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using System.Globalization;
namespace TTHLTV
{
    public partial class frmTracuuGCN : DevExpress.XtraEditors.XtraForm
    {
        #region Variable
        BO_CAP_CHUNGCHI boCcc = new BO_CAP_CHUNGCHI();
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        BO_MONHOC boMonHoc = new BO_MONHOC();
        private int mStatus=1;
        #endregion

        public frmTracuuGCN()
        {
            InitializeComponent();
        }

        #region Events
        private void frmTracuuGCN_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridCertificate.MainView, new Font("Tahoma", 11));

            loadKhoaHoc();
            acticeSearch();
            //checkInvisible();
            lookLopHoc.Enabled = false;
        }
        private void lookChungChi_EditValueChanged(object sender, EventArgs e)
        {

            lookLopHoc.Enabled = true;
            loadLopHoc();
        }
        private void lookLopHoc_EditValueChanged(object sender, EventArgs e)
        {
            showLopDaCapCC();
        }
        private void txtSearchText_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if (int.Parse(lookChungChi.ItemIndex.ToString()) < 0 && int.Parse(lookLopHoc.ItemIndex.ToString()) < 0)
            if (int.Parse(lookLopHoc.ItemIndex.ToString()) < 0)
            {
                MessageBox.Show("Chọn khóa học, và lớp học muốn tìm kiếm học viên", "THÔNG BÁO");
                return;
            }
            else
            {
                DataTable temTb = new DataTable();
                // temTb = boDkh.getDangKiHoc_Name_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
                temTb = boCcc.Search_CCC_Status(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), mStatus);
                if (temTb.Rows.Count > 0)
                {
                    if (txtSearchText.Text == string.Empty)
                    {
                        showLopDaCapCC();
                    }
                    else
                        if (txtSearchText.Text != string.Empty)
                        {
                            gridCertificate.DataSource = searchCCCResultTable();
                            gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
                        }
                }
                else
                {
                    gridCertificate.DataSource = null;

                }

                // 1. Tim chung chi cap moi
                if (radioSearch.SelectedIndex == 1)
                {
                    //temTb = boDkh.getDangKiHoc_Name_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
                    //if (temTb.Rows.Count > 0)
                    //{
                    //    if (txtSearchText.Text == string.Empty)
                    //    {
                    //        showLopDaCapCC();
                    //    }
                    //    else
                    //        if (txtSearchText.Text != string.Empty)
                    //        {
                    //            gridCertificate.DataSource = searchCCCResultTable();
                    //            gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
                    //        }
                    //}
                }
                // 2. Tim kiem chung cho gia han
                if (radioSearch.SelectedIndex == 2)
                {

                }
                // 3. Tim kiem chung chi doi
                if (radioSearch.SelectedIndex == 3)
                {

                }
                //else
                //{
                //    if (txtSearchText.Text == string.Empty)
                //    {
                //        showData();
                //    }
                //    else
                //        if (txtSearchText.Text != string.Empty)
                //        {
                //            gridCertificate.DataSource = SearchTableResult();
                //            gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
                //        }
                //}
            }
        }
        private void radioSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lookChungChi.ItemIndex < 0 || lookLopHoc.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại chứng chỉ, hoặc lớp ", "THÔNG BÁO");
                return;
            }
            else
            {
                if (radioSearch.SelectedIndex == 0)
                {
                    // Goi ham lay du lieu chung chi cap moi
                    mStatus = 1;
                    showLopDaCapCC();
                }
                else if (radioSearch.SelectedIndex == 1)
                {
                    // Goi ham lay du lieu chung chi cap gia han
                    mStatus = 2;
                    showLopDaCapCC();

                }
                else if (radioSearch.SelectedIndex == 2)
                {
                    // Goi ham lay du lieu chung chi cap doi
                    mStatus = 3;
                    showLopDaCapCC();
                }

            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lookSearchBy_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Extenal functions
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
        private void searchByLastNameContrain()
        {
            gridCertificate.DataSource = boDkh.getCAP_CHUNGCHI_HV_ByLastNameContrain(txtSearchText.Text);

        }
        private DataTable getLopDaCapCC()
        {
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
            //tbs = boDkh.getDangKiHoc_Name_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            tbs = boCcc.Search_CCC_Status(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), mStatus);

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
            DataTable temTb = new DataTable();
            DataTable tb1 = new DataTable();
            //temTb = boDkh.getDangKiHoc_Name_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            temTb = boCcc.Search_CCC_Status(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), mStatus);
            if (temTb.Rows.Count > 0)
            {
                tb1 = getLopDaCapCC();
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
            }
            else
            {
                gridCertificate.DataSource = null;
            }
        }
        private DataTable SearchTableResult()
        {
            string DD = string.Empty;
            DataTable sResultTable = new DataTable();
            DataTable tableDiem = new DataTable("SearchResult");
            DataColumn column = new DataColumn();
            tableDiem.Columns.Add("HvID", typeof(int));
            tableDiem.Columns.Add("Họ", typeof(string));
            tableDiem.Columns.Add("Tên", typeof(string));
            tableDiem.Columns.Add("Ngày sinh", typeof(string));
            sResultTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < sResultTable.Rows.Count; i++)
            {
                tableDiem.Columns.Add(sResultTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            tableDiem.Columns.Add("Số CC", typeof(string));
            tableDiem.Columns.Add("Ngày cấp", typeof(string));

            DataTable tbs = new DataTable();
            //1. Search bat lastname
            tbs = boCcc.searchHocVien_In_DKH_ByName(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text);
            //2. Search by firstname
            //3. Search by birthday
            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = tableDiem.NewRow();
                newRow.ItemArray = dr.ItemArray;
                tableDiem.Rows.Add(newRow);
            }
            return tableDiem;
        }
        private DataTable searchCCCResultTable()
        {
            DataTable tbst = new DataTable();
            string DD = string.Empty;
            DataTable sTableMonHoc = new DataTable();
            DataTable sResult = new DataTable("SearchCCCResult");
            DataColumn column = new DataColumn();
            sResult.Columns.Add("HvID", typeof(int));
            sResult.Columns.Add("Họ", typeof(string));
            sResult.Columns.Add("Tên", typeof(string));
            sResult.Columns.Add("Ngày sinh", typeof(string));
            sTableMonHoc = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < sTableMonHoc.Rows.Count; i++)
            {
                sResult.Columns.Add(sTableMonHoc.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            sResult.Columns.Add("Số CC", typeof(string));
            sResult.Columns.Add("Ngày cấp", typeof(string));

            DataTable tbs = new DataTable();
            //1. Search bat lastname
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 1)
            {
                tbs = boCcc.searchHocVien_In_CCC_ByName(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text);
            }
            //2. Search by firstname
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 2)
            {
                tbs = boCcc.searchHocVien_In_CCC_ByFirstName(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text); 
            }
            //3. Search by birthday
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 3)
	        {
                tbs = boCcc.searchHocVien_In_CCC_ByBirthday(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text); 
	        } 

            if (tbs.Rows.Count>0)
            {
                 tbst = sResult.Clone();
                for (int i = 0; i < tbs.Rows.Count; i++)
                {
                    DateTime datetime;
                    string StringDate = string.Empty;
                    int tb1ColCount = tbs.Columns.Count;
                    if (tbs.Rows[i][tb1ColCount - 2].ToString() != "")
                    {
                        datetime = Convert.ToDateTime(tbs.Rows[i][tb1ColCount - 1].ToString());
                        datetime = Convert.ToDateTime(datetime.ToShortDateString());
                        StringDate = datetime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        StringDate = StringDate.ToString().Substring(0, 2) + "/" + StringDate.ToString().Substring(3, 2) + "/" + StringDate.ToString().Substring(6, 4);
                    }
                    DataRow tbstRow = tbst.NewRow();

                    tbstRow[0] = tbs.Rows[i][0].ToString();
                    tbstRow[1] = tbs.Rows[i][1].ToString();
                    tbstRow[2] = tbs.Rows[i][2].ToString();
                    tbstRow[3] = tbs.Rows[i][3].ToString();
                    int subColTotal = tb1ColCount - 7;
                    for (int isd = 4; isd < tb1ColCount - 3; isd++)
                    {
                        tbstRow[isd] = tbs.Rows[i][isd].ToString();
                    }
                    tbstRow[tb1ColCount - 3] = tbs.Rows[i][tb1ColCount - 3].ToString();
                    tbstRow[tb1ColCount - 2] =  tbs.Rows[i][tb1ColCount - 2].ToString();
                    if (tbs.Rows[i][tb1ColCount - 1].ToString() != "")
                    {
                        tbstRow[tb1ColCount - 1] = StringDate.ToString(); //tbs.Rows[i][tb1ColCount - 1].ToString();

                        tbst.Rows.Add(tbstRow);
                    }
                }
                gridContentCertificate.Columns.Clear();
                gridCertificate.DataSource = tbst;

                gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            }

            return tbst;

        }
        private DataTable searchChungChiGiaHan()
        {
            DataTable tbgh = new DataTable();
            string DD = string.Empty;
            DataTable sTableMonHoc = new DataTable();
            DataTable sResult = new DataTable("SearchCCCResult");
            DataColumn column = new DataColumn();
            sResult.Columns.Add("HvID", typeof(int));
            sResult.Columns.Add("Họ", typeof(string));
            sResult.Columns.Add("Tên", typeof(string));
            sResult.Columns.Add("Ngày sinh", typeof(string));
            sTableMonHoc = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < sTableMonHoc.Rows.Count; i++)
            {
                sResult.Columns.Add(sTableMonHoc.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            sResult.Columns.Add("Số CC", typeof(string));
            sResult.Columns.Add("Ngày cấp", typeof(string));

            DataTable tbs = new DataTable();
            //1. Search bat lastname
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 1)
            {
                tbs = boCcc.searchHocVien_In_CCC_ByName(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text);
            }
            //2. Search by firstname
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 2)
            {
                tbs = boCcc.searchHocVien_In_CCC_ByFirstName(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text);
            }
            //3. Search by birthday
            if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 3)
            {
                tbs = boCcc.searchHocVien_In_CCC_ByBirthday(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text);
            }

            if (tbs.Rows.Count > 0)
            {
                tbgh = sResult.Clone();
                for (int i = 0; i < tbs.Rows.Count; i++)
                {
                    DateTime datetime;
                    string StringDate = string.Empty;
                    int tb1ColCount = tbs.Columns.Count;
                    if (tbs.Rows[i][tb1ColCount - 2].ToString() != "")
                    {
                        datetime = Convert.ToDateTime(tbs.Rows[i][tb1ColCount - 1].ToString());
                        datetime = Convert.ToDateTime(datetime.ToShortDateString());
                        StringDate = datetime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        StringDate = StringDate.ToString().Substring(0, 2) + "/" + StringDate.ToString().Substring(3, 2) + "/" + StringDate.ToString().Substring(6, 4);
                    }
                    DataRow tbstRow = tbgh.NewRow();

                    tbstRow[0] = tbs.Rows[i][0].ToString();
                    tbstRow[1] = tbs.Rows[i][1].ToString();
                    tbstRow[2] = tbs.Rows[i][2].ToString();
                    tbstRow[3] = tbs.Rows[i][3].ToString();
                    int subColTotal = tb1ColCount - 7;
                    for (int isd = 4; isd < tb1ColCount - 3; isd++)
                    {
                        tbstRow[isd] = tbs.Rows[i][isd].ToString();
                    }
                    tbstRow[tb1ColCount - 3] = tbs.Rows[i][tb1ColCount - 3].ToString();
                    tbstRow[tb1ColCount - 2] = tbs.Rows[i][tb1ColCount - 2].ToString();
                    if (tbs.Rows[i][tb1ColCount - 1].ToString() != "")
                    {
                        tbstRow[tb1ColCount - 1] = StringDate.ToString(); //tbs.Rows[i][tb1ColCount - 1].ToString();

                        tbgh.Rows.Add(tbstRow);
                    }
                }
                gridContentCertificate.Columns.Clear();
                gridCertificate.DataSource = tbgh;

                gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            }

            return tbgh;
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
            
            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = tableDiem.NewRow();
                newRow.ItemArray = dr.ItemArray;
                tableDiem.Rows.Add(newRow);
            }
            return tableDiem;
        }
        private void searchBySoCC()
        {
 
        }
        #endregion

        
    }
}