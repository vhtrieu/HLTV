using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using TTHLTV.Utilities;
using System.IO;
using System.Reflection;
using System.Globalization;
namespace TTHLTV
{
    public partial class frmGeneralMark : DevExpress.XtraEditors.XtraForm
    {
        BO_CHUNG_CHI boChungChi = new BO_CHUNG_CHI();
        BO_CAP_CHUNGCHI boCcc = new BO_CAP_CHUNGCHI();
        BO_LOP boLop = new BO_LOP();
        BO_MONHOC boMonHoc = new BO_MONHOC();
        BO_DIEM boDiem = new BO_DIEM();
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        private int mCheckLopDaCap = -1;
        private DataTable tbst;
        private DataTable tableDiem;
        private int vCheck = 0;
        DataTable tb2 = new DataTable();
        public Excel.Application xlsApp;
        public Excel.Workbook xlsWorkbook;
        public Excel.Worksheet xlsWorksheet;
        public frmGeneralMark()
        {
            InitializeComponent();
        }

        #region Events
        private void frmGeneralMark_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridStudents.MainView, new Font("Tahoma", 11));
            loadKhoaHoc();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lookChungChi_EditValueChanged(object sender, EventArgs e)
        {
            lookLopHoc.Enabled = true;
            loadLopHoc();
        }
        private void lookLopHoc_EditValueChanged(object sender, EventArgs e)
        {
            sLoadLanThi();
            if (vCheck==1)
            {
                showData();
            }
            else
            {
                vShowData_Befor_CapCc();
            }
        }
        private void lookLanThi_EditValueChanged(object sender, EventArgs e)
        {
            DataTable tb1 = new DataTable();
            tb1 = getData();
            vShowData_Befor_CapCc();
            //int sLanthi = -1;
            //int sLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            //sLanthi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
            //gridStudents.DataSource = boDiem.get_GeneralMark(sLopID, sLanthi);

        }
        private void txtSearchText_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (int.Parse(lookChungChi.ItemIndex.ToString()) < 0 && int.Parse(lookLopHoc.ItemIndex.ToString()) < 0)
            {
                MessageBox.Show("Chọn khóa học, và lớp học muốn tìm kiếm học viên", "THÔNG BÁO");
                return;
            }
            else
            {
                DataTable temTb = new DataTable();
                temTb = boDiem.get_GeneralMark(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), int.Parse(lookLanThi.EditValue.ToString()));
                if (temTb.Rows.Count > 0)
                {
                    if (txtSearchText.Text == string.Empty)
                    {
                        // ((DataTable)gridCertificate.DataSource).Rows.Clear();
                        showData();
                    }
                    else
                        if (txtSearchText.Text != string.Empty)
                        {
                            gridStudents.DataSource = searchGeneralMarkResultTable();
                            gridContentStudents.Columns["HvID"].VisibleIndex = -1;
                            gridContentStudents.Columns["Tên lớp"].VisibleIndex = -1;
                            gridContentStudents.Columns["Ngày KG"].VisibleIndex = -1;
                            gridContentStudents.Columns["Ngày KT"].VisibleIndex = -1;
                            gridContentStudents.Columns["Ngày QĐ"].VisibleIndex = -1;
                        }
                }

            }

        }
        private void btnInBdth_Click(object sender, EventArgs e)
        {
            if (lookChungChi.ItemIndex < 0 || lookLopHoc.ItemIndex < 0)
            {
                MessageBox.Show(" Chưa chọn lớp cần in bảng điểm hợp");

            }
            else
                if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 1)
                {
                    ExportExcel_HLCB();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 26)
                {
                    ExportExcel_HoaTieuNangCao();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 33)
                {
                    ExportExcel_NangCaoNvBoong();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 17)
                {
                    ExportExcel_CSYT();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 15)
                {
                    ExportExcel_CHNC();
                }
                //Làm quen tàu dầu
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 2)
                {
                    ExportExcel_LamQuenTauDau();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 3)
                {
                    ExportExcel_KTTD();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 4)
                {
                    ExportExcel_LamQuenTauHoaChat();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 5)
                {
                    ExportExcel_KhaiThacTauHoaChat();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 6)
                {
                    ExportExcel_LamQuenTauGas();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 7)
                {
                    ExportExcel_KhaiThacTauGas();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 12)
                {
                    ExportExcel_QSvDGRaDa();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 21)
                {
                    ExportExcel_QLNLBuongLai();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 22)
                {
                    ExportExcel_QLNLBuongMay();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 35)
                {
                    ExportExcel_BeCuSinh();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 36)
                {
                    ExportExcel_DogiaiTranhVa();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 37)
                {
                    ExportExcel_ShipHandling();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 38)
                {
                    ExportExcel_RuaKhoangHang();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 32)
                {
                    ExportExcel_TraiNganhMay();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 39)
                {
                    ExportExcel_Solas();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 14)
                {
                    ExportExcel_Goc();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 42)
                {
                    ExportExcel_TND();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 24)
                {
                    ExportExcel_HDDT();
                }
                else if (int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()) == 41)
                {
                    ExportExcel_HDDT2();
                }

        }
        #endregion

        #region Extenal function
        private DataTable vTableBefor_CapCc()
        {
            DataTable vtbl = new DataTable();
            int sLanthi = -1;
            int sLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            if (lookLanThi.ItemIndex<1)
            {
                sLanthi = 1;
            }
            else
            {
                sLanthi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
            }
            vtbl = boDiem.get_GeneralMark(sLopID, sLanthi);
            return vtbl;
        }
        private DataTable vCreateTableBefor_CapCc()
        {
            string DD = string.Empty;
            DataTable cCMhTable = new DataTable();
            DataTable pTable = new DataTable();
            //tableDiem = new DataTable("TempDiem");
            DataColumn column = new DataColumn();
            pTable.Columns.Add("HvID", typeof(int));
            pTable.Columns.Add("Họ", typeof(string));
            pTable.Columns.Add("Tên", typeof(string));
            pTable.Columns.Add("Ngày sinh", typeof(string));
            cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < cCMhTable.Rows.Count; i++)
            {
                pTable.Columns.Add(cCMhTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            pTable.Columns.Add("LOP_Name", typeof(string));
            pTable.Columns.Add("Ngày KG", typeof(DateTime));
            pTable.Columns.Add("Ngày KT", typeof(DateTime));
            pTable.Columns.Add("Ngày QĐ", typeof(DateTime));
          

            DataTable tbs = new DataTable();
            //tbs = boCcc.GetData_For_CAP_CHUNGCHI_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            tbs = vTableBefor_CapCc();
            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = pTable.NewRow();
                newRow.ItemArray = dr.ItemArray;
                pTable.Rows.Add(newRow);
            }
            return pTable;
 
        }
        private void vShowData_Befor_CapCc()
        {
            DataTable tbCcc = new DataTable();
            DataTable tbst = new DataTable();

            if (vCreateTableBefor_CapCc() != null)
            {
                tbCcc = vCreateTableBefor_CapCc();
                if (tbCcc.Rows.Count < 1)
                {
                    gridContentStudents.Columns.Clear();
                }
                else
                {
                    tbst = tbCcc.Clone();
                    for (int i = 0; i < tbCcc.Rows.Count; i++)
                    {
                        string StringDate = string.Empty;
                        int tb1ColCount = tbCcc.Columns.Count;
                        DataRow tbstRow = tbst.NewRow();

                        tbstRow[0] = tbCcc.Rows[i][0].ToString();
                        tbstRow[1] = tbCcc.Rows[i][1].ToString();
                        tbstRow[2] = tbCcc.Rows[i][2].ToString();
                        tbstRow[3] = tbCcc.Rows[i][3].ToString();
                        int subColTotal = tb1ColCount - 7;
                        for (int isd = 4; isd < tb1ColCount - 3; isd++)
                        {
                            tbstRow[isd] = tbCcc.Rows[i][isd].ToString();
                        }
                        tbstRow[tb1ColCount - 3] = tbCcc.Rows[i][tb1ColCount - 3].ToString();
                       // tbstRow[tb1ColCount - 2] = tbCcc.Rows[i][tb1ColCount - 2].ToString();// StringDate.ToString(); // tb1.Rows[i][tb1ColCount - 3].ToString();
                        if (tbCcc.Rows[i][tb1ColCount - 2].ToString()!=string.Empty)
                        {
                             tbstRow[tb1ColCount - 2] = tbCcc.Rows[i][tb1ColCount - 2].ToString();
                        }
                        else
                        {
                            tbstRow[tb1ColCount - 2] = DateTime.Now;
                        }
                        if (tbCcc.Rows[i][tb1ColCount - 1].ToString() != "")
                        {
                            tbstRow[tb1ColCount - 1] = tbCcc.Rows[i][tb1ColCount - 1].ToString();
                        }
                        else
                            tbstRow[tb1ColCount - 1] = DateTime.Now;

                        tbst.Rows.Add(tbstRow);
                    }
                    //if (gridContentStudents.RowCount>0)
                    //{
                    gridContentStudents.Columns.Clear();

                    gridStudents.DataSource = tbst;
                    gridContentStudents.Columns["HvID"].VisibleIndex = -1;
                    gridContentStudents.Columns["LOP_Name"].VisibleIndex = -1;
                    //gridContentStudents.Columns["Ngày sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    //gridContentStudents.Columns["Ngày sinh"].DisplayFormat.FormatString = "dd/MM/yyyy";

                    //gridContentStudents.Columns["Ngày KG"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    //gridContentStudents.Columns["Ngày KG"].DisplayFormat.FormatString = "dd/MM/yyyy";
                    gridContentStudents.Columns["Ngày KG"].VisibleIndex = -1;
                   // gridContentStudents.Columns["Ngày KT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    gridContentStudents.Columns["Ngày KT"].VisibleIndex = -1;
                    //gridContentStudents.Columns["Ngày QĐ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    gridContentStudents.Columns["Ngày QĐ"].VisibleIndex = -1;
                    //}
                }

            }
            else
            {
                gridContentStudents.Columns.Clear();
            }

        }
        #region Load lookup chung chi
        private DataTable getKhoaHoc()
        {
            return boChungChi.getChungChi_All();
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

            //return bal.getLop_Alls();
            return boLop.getLOP_ByCcID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
        }
        private void loadLopHoc()
        {
            lookLopHoc.Properties.DataSource = getLopHoc();
            lookLopHoc.Properties.ValueMember = "LOP_ID";
            lookLopHoc.Properties.DisplayMember = "LOP_Name";
            //lookLopHoc.ItemIndex = 0;
        }
        #endregion
        private void showData()
        {
            DataTable tbCcc = new DataTable();
            DataTable tbst = new DataTable();
           
            if (GetTable() != null)
            {
              tbCcc = GetTable();
              if (tbCcc.Rows.Count < 1)
              {
                  gridContentStudents.Columns.Clear();
              }
              else
              {
                  tbst = tbCcc.Clone();
                  for (int i = 0; i < tbCcc.Rows.Count; i++)
                  {
                      string StringDate = string.Empty;
                      int tb1ColCount = tbCcc.Columns.Count;
                      DataRow tbstRow = tbst.NewRow();

                      tbstRow[0] = tbCcc.Rows[i][0].ToString();
                      tbstRow[1] = tbCcc.Rows[i][1].ToString();
                      tbstRow[2] = tbCcc.Rows[i][2].ToString();
                      tbstRow[3] = tbCcc.Rows[i][3].ToString();
                      int subColTotal = tb1ColCount - 7;
                      for (int isd = 4; isd < tb1ColCount - 3; isd++)
                      {
                          tbstRow[isd] = tbCcc.Rows[i][isd].ToString();
                      }
                      tbstRow[tb1ColCount - 3] = tbCcc.Rows[i][tb1ColCount - 3].ToString();
                      tbstRow[tb1ColCount - 2] = tbCcc.Rows[i][tb1ColCount - 2].ToString();// StringDate.ToString(); // tb1.Rows[i][tb1ColCount - 3].ToString();
                      if (tbCcc.Rows[i][tb1ColCount - 1].ToString() != "")
                      {
                          tbstRow[tb1ColCount - 1] = tbCcc.Rows[i][tb1ColCount - 1].ToString();
                      }
                      else
                          tbstRow[tb1ColCount - 1] = -1;

                      tbst.Rows.Add(tbstRow);
                  }
                  //if (gridContentStudents.RowCount>0)
                  //{
                  gridContentStudents.Columns.Clear();

                  gridStudents.DataSource = tbst;
                  gridContentStudents.Columns["HvID"].VisibleIndex = -1;
                  gridContentStudents.Columns["CCC_LOPID"].VisibleIndex = -1;
                  gridContentStudents.Columns["Ngày sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                  gridContentStudents.Columns["Ngày sinh"].DisplayFormat.FormatString = "dd/MM/yyyy";
                  //}
              }
            
            }
            else
            {
                gridContentStudents.Columns.Clear();
            }
            
        }
        private DataTable getLopDaCapCC()
        {
            int vLopID = -1;
            int vLanThi = -1;
            vLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            vLanThi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
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
            tbs = boDkh.getDangKiHoc_Name_ByLopID(vLopID,vLanThi);

            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = dsHvDaCapCC.NewRow();
                newRow.ItemArray = dr.ItemArray;
                dsHvDaCapCC.Rows.Add(newRow);
            }
            return dsHvDaCapCC;

        }
        private DataTable sGetTable()
        {
            string DD = string.Empty;
            DataTable cCMhTable = new DataTable();
            tableDiem = new DataTable("TempDiem");
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
        private DataTable GetTable()
        {

            DataTable temTb = new DataTable();
            DataTable tb1 = new DataTable();
            int vLopID = -1;
            int vLanThi = -1;
            vLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            vLanThi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
            temTb = boDkh.getDangKiHoc_Name_ByLopID(vLopID,vLanThi);
            mCheckLopDaCap = temTb.Rows.Count;
            // Lớp này đã có cấp chứng chỉ cho học viên
            if (mCheckLopDaCap > 0)
            {
                btnSave.Enabled = true;
                tb1 = getLopDaCapCC();
                tb2 = sGetTable();
                foreach (DataRow item in tb2.Rows)
                {
                    DataRow newRow = tb1.NewRow();
                    newRow.ItemArray = item.ItemArray;
                    tb1.Rows.Add(newRow);
                }
                tbst = new DataTable();
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
                    tbstRow[tb1ColCount - 2] = StringDate.ToString(); 
                    if (tb1.Rows[i][tb1ColCount - 1].ToString() != "")
                    {
                        tbstRow[tb1ColCount - 1] = tb1.Rows[i][tb1ColCount - 1].ToString();
                    }
                    else
                        tbstRow[tb1ColCount - 1] = -1;

                    tbst.Rows.Add(tbstRow);
                }
                vCheck = 1;
            }
            else
            {
                //tbst = null;
                MessageBox.Show("Lớp này chưa cấp số chứng chỉ", " THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return tbst;
           

            //DataTable cCMhTable = new DataTable();
            //DataTable dsHvDaCapCC = new DataTable("dsHvDaCapCC");
            //DataColumn column = new DataColumn();
            //dsHvDaCapCC.Columns.Add("HvID", typeof(int));
            //dsHvDaCapCC.Columns.Add("Họ", typeof(string));
            //dsHvDaCapCC.Columns.Add("Tên", typeof(string));
            //dsHvDaCapCC.Columns.Add("Ngày sinh", typeof(string));
            //cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            //for (int i = 0; i < cCMhTable.Rows.Count; i++)
            //{
            //    dsHvDaCapCC.Columns.Add(cCMhTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            //}
            //dsHvDaCapCC.Columns.Add("Số CC", typeof(string));
            //dsHvDaCapCC.Columns.Add("Ngày cấp", typeof(string));
            //dsHvDaCapCC.Columns.Add("CCC_LOPID", typeof(int));
            //DataTable tbs = new DataTable();
            //tbs = boDkh.getDangKiHoc_Name_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));

            //foreach (DataRow dr in tbs.Rows)
            //{
            //    DataRow newRow = dsHvDaCapCC.NewRow();
            //    newRow.ItemArray = dr.ItemArray;
            //    dsHvDaCapCC.Rows.Add(newRow);
            //}
            //return dsHvDaCapCC;
        }
        #region Lookup LanThi
        private void sLoadLanThi()
        {
            lookLanThi.Properties.DataSource = boDiem.LanThi_generalMark(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            lookLanThi.Properties.ValueMember = "DIE_LanThi";
            lookLanThi.Properties.DisplayMember = "DIE_LanThi";
            lookLanThi.ItemIndex = 0;
        }
        #endregion
        private void loadDataToGrid()
        {
            DataTable tabel = new DataTable();
            int sLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            tabel = boDiem.get_GeneralMark(sLopID, int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString()));
            gridStudents.DataSource = tabel;
        }
        private DataTable getData()
        {
            DataTable tabel = new DataTable();
            int sLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            tabel = boDiem.get_GeneralMark(sLopID, 1);
            return tabel;
        }
        private DataTable searchGeneralMarkResultTable()
        {
            string DD = string.Empty;
            DataTable sResultTable = new DataTable();
            DataTable sResult = new DataTable("SearchCCCResult");
            DataColumn column = new DataColumn();
            sResult.Columns.Add("HvID", typeof(int));
            sResult.Columns.Add("Họ", typeof(string));
            sResult.Columns.Add("Tên", typeof(string));
            sResult.Columns.Add("Ngày sinh", typeof(string));
            sResultTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < sResultTable.Rows.Count; i++)
            {
                sResult.Columns.Add(sResultTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            sResult.Columns.Add("Tên lớp", typeof(string));
            sResult.Columns.Add("Ngày KG", typeof(DateTime));
            sResult.Columns.Add("Ngày KT", typeof(DateTime));
            sResult.Columns.Add("Ngày QĐ", typeof(DateTime));

            DataTable tbs = new DataTable();
            //tbs = boDiem.searchHocVien_GeneralMark_ByName(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString()), txtSearchText.Text);
            tbs = boDiem.searchHocVien_GeneralMark_ByName(txtSearchText.Text);
            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = sResult.NewRow();
                newRow.ItemArray = dr.ItemArray;
                sResult.Rows.Add(newRow);
            }
            return sResult;

        }
        enum ExcelColumns
        {
            colA = 1,
            colB = 2,
            colC = 3,
            colD = 4,
            colE = 5,
            colF = 6,
            colG = 7,
            colH = 8,
            colI = 9,
            colJ = 10,
            colK = 11,
            colL = 12,
            colM = 13,
            colN = 14,
            colO = 15,
            colP = 16,
            colQ = 17,
            colR = 18,
            colS = 19,
            colT = 20,
            colU = 21

        };
        public void drawBorder(string _range)
        {

            var _with1 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeLeft];
            _with1.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with1.Weight = Excel.XlBorderWeight.xlHairline;
            _with1.ColorIndex = Excel.Constants.xlAutomatic;
            var _with2 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeTop];
            _with2.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with2.Weight = Excel.XlBorderWeight.xlHairline;
            _with2.ColorIndex = Excel.Constants.xlAutomatic;
            var _with3 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeBottom];
            _with3.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with3.Weight = Excel.XlBorderWeight.xlHairline;
            _with3.ColorIndex = Excel.Constants.xlAutomatic;
            var _with4 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeRight];
            _with4.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with4.Weight = Excel.XlBorderWeight.xlHairline;
            _with4.ColorIndex = Excel.Constants.xlAutomatic;
            var _with5 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideVertical];
            _with5.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with5.Weight = Excel.XlBorderWeight.xlHairline;
            _with5.ColorIndex = Excel.Constants.xlAutomatic;
            var _with6 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideHorizontal];
            _with6.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with6.Weight = Excel.XlBorderWeight.xlHairline;
            _with6.ColorIndex = Excel.Constants.xlAutomatic;
        }
        public void drawBorderOneColumn(string _range)
        {

            var _with1 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeLeft];
            _with1.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with1.Weight = Excel.XlBorderWeight.xlHairline;
            _with1.ColorIndex = Excel.Constants.xlAutomatic;
            var _with2 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeTop];
            _with2.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with2.Weight = Excel.XlBorderWeight.xlHairline;
            _with2.ColorIndex = Excel.Constants.xlAutomatic;
            var _with3 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeBottom];
            _with3.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with3.Weight = Excel.XlBorderWeight.xlHairline;
            _with3.ColorIndex = Excel.Constants.xlAutomatic;
            var _with4 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeRight];
            _with4.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with4.Weight = Excel.XlBorderWeight.xlHairline;
            _with4.ColorIndex = Excel.Constants.xlAutomatic;
            //var _with5 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideVertical];
            //_with5.LineStyle = Excel.XlLineStyle.xlContinuous;
            //_with5.Weight = Excel.XlBorderWeight.xlHairline;
            //_with5.ColorIndex = Excel.Constants.xlAutomatic;
            var _with6 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideHorizontal];
            _with6.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with6.Weight = Excel.XlBorderWeight.xlHairline;
            _with6.ColorIndex = Excel.Constants.xlAutomatic;
        }
        public void drawBorderNone(string _range)
        {

            var _with2 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeTop];
            _with2.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with2.Weight = Excel.XlBorderWeight.xlHairline;
            _with2.ColorIndex = Excel.Constants.xlAutomatic;
            var _with3 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeBottom];
            _with3.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with3.Weight = Excel.XlBorderWeight.xlHairline;
            _with3.ColorIndex = Excel.Constants.xlAutomatic;

            var _with6 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideHorizontal];
            _with6.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with6.Weight = Excel.XlBorderWeight.xlHairline;
            _with6.ColorIndex = Excel.Constants.xlAutomatic;
        }
        private void ExportExcel_HoaTieuNangCao()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\BDTH_HoaTieuNangCao.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Điều động"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Vùng hoa tiêu"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Luật Hàng hải"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colH] = dt.Rows[i]["Anh văn ( Goc )"].ToString();

                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:I" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colH] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colI] = "Giám đốc .................................... ";

            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;
        }
        private void ExportExcel_NangCaoNvBoong()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\BDTH_NangCaoBoong.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Địa văn"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Mã thư Quốc tế"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Khí tượng"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colH] = dt.Rows[i]["La bàn từ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colI] = dt.Rows[i]["Tin học ứng dụng"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colJ] = dt.Rows[i]["Máy điện hàng hải"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colK] = dt.Rows[i]["Máy VTĐ HH"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Pháp luật và Bảo hiểm"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colM] = dt.Rows[i]["Công ước Quốc tế"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colN] = dt.Rows[i]["Xếp dỡ hàng hóa"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colO] = dt.Rows[i]["Điều động"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colP] = dt.Rows[i]["Khai thác thương vụ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colQ] = dt.Rows[i]["Tìm kiếm cứu nạn"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colR] = dt.Rows[i]["Quy tắc tránh va"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colS] = dt.Rows[i]["Anh văn"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colT] = dt.Rows[i]["Thiên văn"].ToString();

                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:U" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colH] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colI] = "Giám đốc .................................... ";

            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_HLCB()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\BDTH_HLCB.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Lý thuyết cứu sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Thực hành cưu sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Lý thuyết cứu hỏa"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colH] = dt.Rows[i]["Thực hành cứu hỏa"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colI] = dt.Rows[i]["ATSM & TNXH"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colJ] = dt.Rows[i]["Sơ cứu"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colK] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:L" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colH] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colI] = "Giám đốc .................................... ";

            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;
        }
        private void ExportExcel_SQVHBoong()
        {

            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\BDTH_SQVHBoong.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Lý thuyết cứu sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Thực hành cưu sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Lý thuyết cứu hỏa"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colH] = dt.Rows[i]["Thực hành cứu hỏa"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colI] = dt.Rows[i]["ATSM & TNXH"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colJ] = dt.Rows[i]["Sơ cứu"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colK] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:L" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colH] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colI] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_CSYT()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_CSYT.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Chăm sóc y tế"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();// sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_CHNC()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_CCNC.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Lý thuyết cứu hỏa"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;
        }
        private void ExportExcel_LamQuenTauDau()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_LQTD.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Làm quen tàu dầu"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();// sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_KTTD()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_KTTD.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Khai thác tàu dầu"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                       // DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colH] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colI] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;
        }
        private void ExportExcel_LamQuenTauHoaChat()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_LQTHC.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Làm quen tàu hóa chất"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();// sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colB] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_KhaiThacTauHoaChat()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_KTTHC.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Khai thác tàu hóa chất"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colB] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        } 
        private void ExportExcel_LamQuenTauGas()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_LQTG.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Làm quen tàu gas"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colB] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_KhaiThacTauGas()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_KTTGas.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Khai thác tàu gas"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();// sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colB] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_QSvDGRaDa()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_QSvDGRadar.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Quan sát và đồ giải radar"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                       // DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colH] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colI] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_QLNLBuongLai()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_QLNLBuongLai.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Quản lý buồng lái"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();// sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_QLNLBuongMay()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_QLNLBuongMay.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count + 4; i++)
                    {
                        if (i < dt.Rows.Count)
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                            xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Khai thác máy tàu"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                            // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                            // DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                            xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                        }
                        currentRow++;
                    }
                }
                
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_BeCuSinh()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_BCSXCN.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Sử dụng xuồng cứu sinh và bè cứu nạn"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();// sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "......" + " tháng " + "......." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_SDMTB()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_SDMT.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Tổng Hợp SD MT"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();// sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colH] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colI] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_DogiaiTranhVa()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_DoGiaiTranhva.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Thực hành arpa"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "......" + " tháng " + "......." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_ShipHandling()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_ShiphandLing.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Shiphandling"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_RuaKhoangHang()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_RuaKhoangHang.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Rửa khoang hàng"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                       // DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString(); //sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_TraiNganhMay()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_TNM.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                if (dt==null)
                {
                    return;
                }
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Anh văn"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Điện tử tàu thủy"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Diesel"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colH] = dt.Rows[i]["Khai thác hệ động lực"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colI] = dt.Rows[i]["Luật & An toàn"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colJ] = dt.Rows[i]["Lý thuyết và kết cấu tàu"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colK] = dt.Rows[i]["Máy lạnh & Điều hòa"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Máy phụ tàu thủy"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colM] = dt.Rows[i]["Nhiên liệu"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colN] = dt.Rows[i]["Nồi hơi - Tua bin"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colO] = dt.Rows[i]["Trực ca"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colP] = dt.Rows[i]["Hệ thống tự động tàu thủy"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colQ] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colR] = dt.Rows[i]["Ngày cấp"].ToString();// sNgayCap.ToString("dd/MM/yyyy");
                    }
                    else
                     {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:R" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colN] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colN] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_Solas()
        {
            int vStatic = 0;
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_SOLAS.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            if (GetTable()!=null)
            {
                dt = GetTable();
                vStatic = 1;
            }
            else
            {
                dt = vCreateTableBefor_CapCc();
                vStatic = 2;
            }
            
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Bồi dưỡng nghiệp vụ công ước hàng hải quốc tế"].ToString();
                        if (vStatic==1)
                        {
                            xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                            // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                            //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                            xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();
                        }
                        else
                        {
                            //xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                            //xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();
                        }
                        
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_Goc()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_GOC.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Anh văn ( Goc )"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Thực hành inmarsat (Goc)"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Lý thuyết ( Goc )"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colH] = dt.Rows[i]["Tin học ( Goc ) "].ToString();
                        xls.Cells[currentRow, ExcelColumns.colI] = dt.Rows[i]["Thực hành MF/HF (Goc)"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colJ] = dt.Rows[i]["Thực hành VHF ( Goc )"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colK] = dt.Rows[i]["Số CC"].ToString();
                        // xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                        //DateTime sNgayCap = DateTime.Parse(dt.Rows[i]["Ngày cấp"].ToString());
                        xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Ngày cấp"].ToString();
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:L" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colI] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colI] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_TND()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_TND.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Hệ thống điều khiển từ xa Diesel tàu thuỷ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Kết cấu tàu thuỷ và bố trí thiết bị điện trên tàu thủy"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Máy tàu thuỷ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colH] = dt.Rows[i]["Nghiệp vụ thợ điện tàu thuỷ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colI] = dt.Rows[i]["Vận hành khai thác các hệ thống tự động tàu thuỷ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colJ] = dt.Rows[i]["Vận hành khai thác các thiết bị điện buồng lái"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colK] = dt.Rows[i]["Vận hành khai thác hệ thống trạm phát điện tàu thuỷ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colL] = dt.Rows[i]["Vận hành khai thác hệ thống truyền động điện tàu thuỷ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colM] = dt.Rows[i]["Số CC"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colN] = dt.Rows[i]["Ngày cấp"].ToString();
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:N" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colK] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colK] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_HDDT()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_HDDT.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Hải đồ điện tử "].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        private void ExportExcel_HDDT2()
        {
            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DTH_HDDT.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = GetTable();
            xlsWorksheet.Cells[5, ExcelColumns.colB] = "Lớp: " + lookLopHoc.GetColumnValue("LOP_Name");
            var xls = xlsWorksheet;
            {
                for (int i = 0; i < dt.Rows.Count + 4; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["Họ"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["Tên"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["Ngày sinh"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["Hải đồ điện tử "].ToString();
                        xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["Số CC"].ToString();
                        xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["Ngày cấp"].ToString();
                    }
                    else
                    {
                        xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;

                    }
                    currentRow++;
                }
            }

            if (currentRow > 10)
            {
                drawBorder("D11:G" + (currentRow - 1).ToString());
                drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                drawBorderNone("B11:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 5, ExcelColumns.colA] = "Cán bộ giáo vụ .................................... ";
            xls.Cells[currentRow + 1, ExcelColumns.colF] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
            xls.Cells[currentRow + 5, ExcelColumns.colF] = "Giám đốc .................................... ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;

        }
        #endregion

    }
}