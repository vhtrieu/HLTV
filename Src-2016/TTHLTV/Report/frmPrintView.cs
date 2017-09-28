using System;
using System.Data;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using System.Globalization;
using CrystalDecisions.Windows.Forms;
namespace TTHLTV.Report
{
    public partial class frmPrintView : XtraForm
    {
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        BO_CAP_CHUNGCHI boCcc = new BO_CAP_CHUNGCHI();
        public int mChungChiId = -1;
        public int mLopId = -1;
        public int mLanThi = -1;
        public int mIndex = -1;
        public string mSoHieuDoi = string.Empty;
        public int mCheckDoi = -1;
        public int StatustDoi = -1;
        private string mSoQT = string.Empty;
        public int mChungChiStatic = -1;
        public frmPrintView()
        {
            InitializeComponent();
        }
        private void frmInGiayChungNhan_Load(object sender, EventArgs e)
        {
            printReport();

        }
        private void printReport()
        {
            DataSet ds1 = new DataSet();
            /*mCheckDoi ==1: Cap moi*/
            if (mCheckDoi == 1)
            {
                #region Mat trong
                if (mIndex == 1)
                {
                    if (mChungChiStatic == 1 || mChungChiStatic == 2)
                    {
                        if (mChungChiId == 23)
                        {
                            RpInGCN_MatTrong_English rpt = new RpInGCN_MatTrong_English();
                            ds1 = bidingDataSet_Mattrong_English();
                            rpt.SetDataSource(ds1);
                            InGcnViewer.ReportSource = rpt;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                        }
                        else
                        {
                            RpInGCN_MatTrong rpt = new RpInGCN_MatTrong();
                            ds1 = bidingDataSet_Mattrong();
                            rpt.SetDataSource(ds1);
                            InGcnViewer.ReportSource = rpt;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                        }
                        
                    }
                    else if (mChungChiStatic == 3)
                    {
                        RpInGCN_MatTrong_DacBiet rpt = new RpInGCN_MatTrong_DacBiet();
                        ds1 = bidingDataSet_Mattrong();
                        rpt.SetDataSource(ds1);
                        InGcnViewer.ReportSource = rpt;
                        InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                        this.InGcnViewer.RefreshReport();
                    }
                    else if (mChungChiStatic == 4)
                    {
                        Private_RpInGCN_MatTrong _rpt = new Private_RpInGCN_MatTrong();
                        ds1 = bidingDataSet_Mattrong();
                        _rpt.SetDataSource(ds1);
                        InGcnViewer.ReportSource = _rpt;
                        InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                        InGcnViewer.RefreshReport();
                    }
                    else if (mChungChiStatic == 5)
                    {

                        Private_matTrong_Mau2 _rpt = new Private_matTrong_Mau2();
                        ds1 = bidingDataSet_Mattrong();
                        _rpt.SetDataSource(ds1);
                        InGcnViewer.ReportSource = _rpt;
                        InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                        InGcnViewer.RefreshReport();
                    }
                }
                
                #endregion
                #region Mat ngoai

                else if (mIndex == 2)
                {
                    /*2017-07-25 - TrieuVH update start*/
                    switch (mChungChiStatic)
                    {
                        case 1:
                        case 2:
                            RpInGCN_MatNgoai rpt = new RpInGCN_MatNgoai();
                            ds1 = bidingDataSet_Matngoai();
                            rpt.SetDataSource(ds1);
                            InGcnViewer.ReportSource = rpt;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                            break;
                        case 3:
                            RpInGCN_MatNgoai_DacBiet rpt3 = new RpInGCN_MatNgoai_DacBiet();
                            ds1 = bidingDataSet_Matngoai();
                            rpt3.SetDataSource(ds1);
                            InGcnViewer.ReportSource = rpt3;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                            break;
                        case 4:
                            Private_RpInGCN_MatNgoai _rpt = new Private_RpInGCN_MatNgoai();
                            ds1 = bidingDataSet_Matngoai();
                            _rpt.SetDataSource(ds1);
                            InGcnViewer.ReportSource = _rpt;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                            break;
                    }
                    //if (mChungChiStatic == 1 || mChungChiStatic == 2 || mChungChiStatic == 3)
                    //{
                    //    RpInGCN_MatNgoai rpt = new RpInGCN_MatNgoai();
                    //    ds1 = bidingDataSet_Matngoai();
                    //    rpt.SetDataSource(ds1);
                    //    InGcnViewer.ReportSource = rpt;
                    //    InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                    //    this.InGcnViewer.RefreshReport();
                    //}
                    //else if (mChungChiStatic==4)
                    //{
                    //    Private_RpInGCN_MatNgoai _rpt = new Private_RpInGCN_MatNgoai();
                    //    ds1 = bidingDataSet_Matngoai();
                    //    _rpt.SetDataSource(ds1);
                    //    InGcnViewer.ReportSource = _rpt;
                    //    InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                    //    this.InGcnViewer.RefreshReport();

                    //}
                    /*2017-07-25 - TrieuVH update end*/
                    // DataSet ds1 = new DataSet();
                    //if (mChungChiId == 31 || mChungChiId == 32 || mChungChiId == 33 || mChungChiId == 34 || mChungChiId == 14 || mChungChiId == 38 || mChungChiId == 39 || mChungChiId == 42)
                    //{
                    //    Private_RpInGCN_MatNgoai _rpt = new Private_RpInGCN_MatNgoai();
                    //    ds1 = bidingDataSet_Matngoai();
                    //    _rpt.SetDataSource(ds1);
                    //    InGcnViewer.ReportSource = _rpt;
                    //    InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                    //    this.InGcnViewer.RefreshReport();
                    //}
                    //else
                    //{
                    //    RpInGCN_MatNgoai rpt = new RpInGCN_MatNgoai();
                    //    ds1 = bidingDataSet_Matngoai();
                    //    rpt.SetDataSource(ds1);
                    //    InGcnViewer.ReportSource = rpt;
                    //    InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                    //    this.InGcnViewer.RefreshReport();

                    //}

                }
                #endregion
            }
            else
            {
                #region Mat trong

                // In mat trong cua report
                if (mIndex == 1)
                {
                    if (mChungChiStatic == 1 || mChungChiStatic == 2)
                    {
                        if (mChungChiId ==23)
                        {
                            RpInGCN_MatTrong_English rpt = new RpInGCN_MatTrong_English();
                            ds1 = bidingDataSet_Mattrong_English();
                            rpt.SetDataSource(ds1);
                            InGcnViewer.ReportSource = rpt;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                        }
                        else
                        {
                            RpInGCN_MatTrong rpt = new RpInGCN_MatTrong();
                            //DataSet ds1 = new DataSet();
                            ds1 = bidingDataSet_Mattrong_Doi();
                            rpt.SetDataSource(ds1);
                            //rpt.SetParameterValue("SoQT", mSoQT);
                            InGcnViewer.ReportSource = rpt;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                        }
                        
                    }
                    else if (mChungChiStatic == 3)
                    {
                        RpInGCN_MatTrong_DacBiet rpt = new RpInGCN_MatTrong_DacBiet();
                        //DataSet ds1 = new DataSet();
                        ds1 = bidingDataSet_Mattrong_Doi();
                        rpt.SetDataSource(ds1);
                        //rpt.SetParameterValue("SoQT", mSoQT);
                        InGcnViewer.ReportSource = rpt;
                        InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                        this.InGcnViewer.RefreshReport();
                    }
                    else if (mChungChiStatic == 4)
                    {
                        Private_RpInGCN_MatTrong _rpt = new Private_RpInGCN_MatTrong();
                        ds1 = bidingDataSet_Mattrong_Doi();
                        _rpt.SetDataSource(ds1);
                        InGcnViewer.ReportSource = _rpt;
                        InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                        InGcnViewer.RefreshReport();
                    }
                   
                }
                #endregion
                #region Mat ngoai

                else if (mIndex == 2)
                {
                    switch (mChungChiStatic)
                    {
                        case 1:
                        case 2:
                            RpInGCN_MatNgoai rpt = new RpInGCN_MatNgoai();
                            ds1 = bidingDataSet_Matngoai_Doi();
                            rpt.SetDataSource(ds1);
                            InGcnViewer.ReportSource = rpt;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                            break;
                        case 3:
                            RpInGCN_MatNgoai_DacBiet rpt3 = new RpInGCN_MatNgoai_DacBiet();
                            ds1 = bidingDataSet_Matngoai_Doi();
                            rpt3.SetDataSource(ds1);
                            InGcnViewer.ReportSource = rpt3;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                            break;
                        case 4:
                            Private_RpInGCN_MatNgoai _rpt = new Private_RpInGCN_MatNgoai();
                            ds1 = bidingDataSet_Matngoai_Doi();
                            _rpt.SetDataSource(ds1);
                            InGcnViewer.ReportSource = _rpt;
                            InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                            this.InGcnViewer.RefreshReport();
                            break;

                    }
                    //if (mChungChiStatic == 1 || mChungChiStatic == 2 || mChungChiStatic == 3)
                    //{
                    //    RpInGCN_MatNgoai rpt = new RpInGCN_MatNgoai();
                    //    //DataSet ds1 = new DataSet();
                    //    ds1 = bidingDataSet_Matngoai_Doi();
                    //    rpt.SetDataSource(ds1);
                    //    InGcnViewer.ReportSource = rpt;
                    //    InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                    //    this.InGcnViewer.RefreshReport();  
                    //}
                    //else if (mChungChiStatic==4)
                    //{
                    //    Private_RpInGCN_MatNgoai _rpt = new Private_RpInGCN_MatNgoai();
                    //    ds1 = bidingDataSet_Matngoai_Doi();
                    //    _rpt.SetDataSource(ds1);
                    //    InGcnViewer.ReportSource = _rpt;
                    //    InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                    //    this.InGcnViewer.RefreshReport();

                    //}

                    //if (mChungChiId == 31 || mChungChiId == 32 || mChungChiId == 33 || mChungChiId == 34 || mChungChiId == 14 || mChungChiId == 38 || mChungChiId == 39 || mChungChiId == 42)
                    //{

                    //    Private_RpInGCN_MatNgoai _rpt = new Private_RpInGCN_MatNgoai();
                    //    ds1 = bidingDataSet_Matngoai_Doi();
                    //    _rpt.SetDataSource(ds1);
                    //    InGcnViewer.ReportSource = _rpt;
                    //    InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                    //    this.InGcnViewer.RefreshReport();

                    //}
                    //else
                    //{

                    //    RpInGCN_MatNgoai rpt = new RpInGCN_MatNgoai();
                    //    //DataSet ds1 = new DataSet();
                    //    ds1 = bidingDataSet_Matngoai_Doi();
                    //    rpt.SetDataSource(ds1);
                    //    InGcnViewer.ReportSource = rpt;
                    //    InGcnViewer.ToolPanelView = ToolPanelViewType.None;
                    //    this.InGcnViewer.RefreshReport();
                    //}
                }
                #endregion
            }

        }

        private DataSet bidingDataSet_Mattrong_English()
        {
            DataTable tb = new DataTable();
            DsInGCN Ds = new DsInGCN();
            int CHC_ID = -1;
            DateTime fromDate;
            DateTime endDate;
            string sFromDate;
            string sEndDate;
            tb = boDkh.getDataInGCN_English(mLopId);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow row = Ds.TableInGcn_MatTrong.NewRow();
                    CHC_ID = Int32.Parse(tb.Rows[i]["CHC_ID"].ToString());
                    row["TrungTam"] = " ĐẠI HỌC GIAO THÔNG VẬN TẢI TPHCM";
                    row["TrungTamE"] = "HOCHIMINH CITY UNIVERSITY OF TRANSPORT ";
                    row["FullName"] = tb.Rows[i]["HvFirstName"].ToString() + " " + tb.Rows[i]["HvLastName"].ToString();
                    row["HvBirthDay"] = tb.Rows[i]["HvBirthDay"].ToString();
                    row["HOV_QuocTich"] = tb.Rows[i]["HOV_QuocTich"].ToString();
                    row["HvSoCc"] = tb.Rows[i]["HvSoCc"].ToString();
                    fromDate = DateTime.Parse(tb.Rows[i]["HvNgayCapSoCc"].ToString());
                    sFromDate = fromDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    row["HvNgayCapSoCc"] = sFromDate.ToString().Substring(0, 2) + "/" + sFromDate.ToString().Substring(3, 2) + "/" + sFromDate.ToString().Substring(6, 4);
                    endDate = DateTime.Parse(tb.Rows[i]["HvNgayHetHan"].ToString());
                    sEndDate = endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    row["HvNgayHetHan"] = sEndDate.ToString().Substring(0, 2) + "/" + sEndDate.ToString().Substring(3, 2) + "/" + sEndDate.ToString().Substring(6, 4);
                    row["CHC_Name"] = tb.Rows[i]["CHC_Name"].ToString();
                    row["HvNoiSinh"] = tb.Rows[i]["TIN_Name"].ToString();
                    row["CHC_Content1"] = tb.Rows[i]["CHC_Content1"].ToString();
                    row["CHC_Content2"] = tb.Rows[i]["CHC_Content2"].ToString();
                    row["CHC_Content3"] = tb.Rows[i]["CHC_Content3"].ToString();
                    row["CHC_Content4"] = tb.Rows[i]["CHC_Content4"].ToString();
                    row["SoQT"] = tb.Rows[i]["LEV_Number"].ToString();
                    row["LocationCenter"] = tb.Rows[i]["CHC_QuyDinh"].ToString();
                    row["Regulation"] = tb.Rows[i]["CHC_QuyDinhEngl"].ToString();
                    row["CHC_FontSize1"] = tb.Rows[i]["CHC_FontSize1"].ToString();
                    row["CHC_FontSize2"] = tb.Rows[i]["CHC_FontSize2"].ToString();
                    row["CHC_FontSize3"] = tb.Rows[i]["CHC_FontSize3"].ToString();
                    row["CHC_FontSize4"] = tb.Rows[i]["CHC_FontSize4"].ToString();
                    row["Img"] = tb.Rows[i]["IMG_Image"];
                    Ds.TableInGcn_MatTrong.Rows.Add(row);
                }
            }

            return Ds;
        }
        #region Chứng chỉ cấp mới
        private DataSet bidingDataSet_Matngoai()
        {
            DataTable tb = new DataTable();
            DsInGCN Ds = new DsInGCN();
            tb = boDkh.getDataInGCN(mLopId, mLanThi);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                int CHC_ID = Int32.Parse(tb.Rows[i]["CHC_ID"].ToString());
                DataRow row = Ds.TableInGcn_MatNgoai.NewRow();
                row["StaticNumber"] = tb.Rows[i]["CHC_ModleCode"].ToString();
                DateTime fromDate = DateTime.Parse(tb.Rows[i]["LOP_Ngay_KG"].ToString());
                string sFromDate = fromDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                row["FromDate"] = sFromDate.ToString().Substring(0, 2) + "/" + sFromDate.ToString().Substring(3, 2) + "/" + sFromDate.ToString().Substring(6, 4);
                DateTime endDate = DateTime.Parse(tb.Rows[i]["LOP_Ngay_KT"].ToString());
                string sEndDate = endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                row["ToDate"] = sEndDate.ToString().Substring(0, 2) + "/" + sEndDate.ToString().Substring(3, 2) + "/" + sEndDate.ToString().Substring(6, 4);
                row["At"] = " TT HUẤN LUYỆN THUYỀN VIÊN "; //\n SEMAN TRAINING CENTER \n ĐẠI HỌC GIAO THÔNG VẬN TẢI TP HCM \n HOCIMINH CITY UNIVERSITY OF TRANSPORT";
                                                           // row["At1"] = "SEMAN TRAINING CENTER";
                row["At1"] = "MARITIME TRAINING CENTER";
                row["At2"] = "ĐẠI HỌC GIAO THÔNG VẬN TẢI TP HCM";
                row["At3"] = "HOCIMINH CITY UNIVERSITY OF TRANSPORT";
                row["ShortName"] = tb.Rows[i]["LOP_ShortName"].ToString();
                row["HvSoCc"] = tb.Rows[i]["HvSoCc"].ToString();
                DateTime sQdDate = DateTime.Parse(tb.Rows[i]["LOP_Ngay_QD"].ToString());
                string sSQdDate = sQdDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                row["DateQd"] = sSQdDate.ToString().Substring(0, 2);
                row["MonthQd"] = sSQdDate.ToString().Substring(3, 2);
                row["YearQd"] = sSQdDate.ToString().Substring(6, 4);
                // row["Img"] = tb.Rows[i]["IMG_Image"];
                Ds.TableInGcn_MatNgoai.Rows.Add(row);
            }

            return Ds;
        }
        private DataSet bidingDataSet_Mattrong()
        {
            DataTable tb = new DataTable();
            DsInGCN Ds = new DsInGCN();
            int CHC_ID = -1;
            DateTime fromDate;
            DateTime endDate;
            string sFromDate;
            string sEndDate;
            tb = boDkh.getDataInGCN(mLopId, mLanThi);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow row = Ds.TableInGcn_MatTrong.NewRow();
                    CHC_ID = Int32.Parse(tb.Rows[i]["CHC_ID"].ToString());
                    row["TrungTam"] = " ĐẠI HỌC GIAO THÔNG VẬN TẢI TPHCM";
                    row["TrungTamE"] = "HOCHIMINH CITY UNIVERSITY OF TRANSPORT ";
                    row["FullName"] = tb.Rows[i]["HvFirstName"].ToString() + " " + tb.Rows[i]["HvLastName"].ToString();
                    row["HvBirthDay"] = tb.Rows[i]["HvBirthDay"].ToString();
                    row["HOV_QuocTich"] = tb.Rows[i]["HOV_QuocTich"].ToString();
                    row["HvSoCc"] = tb.Rows[i]["HvSoCc"].ToString();
                    fromDate = DateTime.Parse(tb.Rows[i]["HvNgayCapSoCc"].ToString());
                    sFromDate = fromDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    row["HvNgayCapSoCc"] = sFromDate.ToString().Substring(0, 2) + "/" + sFromDate.ToString().Substring(3, 2) + "/" + sFromDate.ToString().Substring(6, 4);
                    endDate = DateTime.Parse(tb.Rows[i]["HvNgayHetHan"].ToString());
                    sEndDate = endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    row["HvNgayHetHan"] = sEndDate.ToString().Substring(0, 2) + "/" + sEndDate.ToString().Substring(3, 2) + "/" + sEndDate.ToString().Substring(6, 4);
                    row["CHC_Name"] = tb.Rows[i]["CHC_Name"].ToString();
                    row["HvNoiSinh"] = tb.Rows[i]["TIN_Name"].ToString();
                    row["CHC_Content1"] = tb.Rows[i]["CHC_Content1"].ToString();
                    row["CHC_Content2"] = tb.Rows[i]["CHC_Content2"].ToString();
                    row["CHC_Content3"] = tb.Rows[i]["CHC_Content3"].ToString();
                    row["CHC_Content4"] = tb.Rows[i]["CHC_Content4"].ToString();
                    row["SoQT"] = tb.Rows[i]["CHC_QuyTac"].ToString();
                    row["LocationCenter"] = tb.Rows[i]["CHC_QuyDinh"].ToString();
                    row["Regulation"] = tb.Rows[i]["CHC_QuyDinhEngl"].ToString();
                    row["CHC_FontSize1"] = tb.Rows[i]["CHC_FontSize1"].ToString();
                    row["CHC_FontSize2"] = tb.Rows[i]["CHC_FontSize2"].ToString();
                    row["CHC_FontSize3"] = tb.Rows[i]["CHC_FontSize3"].ToString();
                    row["CHC_FontSize4"] = tb.Rows[i]["CHC_FontSize4"].ToString();
                    row["Img"] = tb.Rows[i]["IMG_Image"];
                    Ds.TableInGcn_MatTrong.Rows.Add(row);
                }
            }

            return Ds;
        }
        #endregion
        #region Chung chi doi
        private DataSet bidingDataSet_Matngoai_Doi()
        {
            DataTable tb = new DataTable();

            DsInGCN Ds = new DsInGCN();
            tb = boCcc.get_Print_CcDoi(mChungChiId, StatustDoi, mSoHieuDoi);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                int CHC_ID = Int32.Parse(tb.Rows[i]["CHC_ID"].ToString());
                DataRow row = Ds.TableInGcn_MatNgoai.NewRow();
                row["StaticNumber"] = tb.Rows[i]["CHC_ModleCode"].ToString();
                DateTime fromDate = DateTime.Parse(tb.Rows[i]["DOI_Ngay_KG"].ToString());
                string sFromDate = fromDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                row["FromDate"] = sFromDate.ToString().Substring(0, 2) + "/" + sFromDate.ToString().Substring(3, 2) + "/" + sFromDate.ToString().Substring(6, 4);
                DateTime endDate = DateTime.Parse(tb.Rows[i]["DOI_Ngay_KT"].ToString());
                string sEndDate = endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                row["ToDate"] = sEndDate.ToString().Substring(0, 2) + "/" + sEndDate.ToString().Substring(3, 2) + "/" + sEndDate.ToString().Substring(6, 4);
                row["At"] = " TT HUẤN LUYỆN THUYỀN VIÊN \n MARITIME TRAINING CENTER \n ĐẠI HỌC GIAO THÔNG VẬN TẢI TP HCM \n HOCIMINH CITY UNIVERSITY OF TRANSPORT";
                row["ShortName"] = tb.Rows[i]["CCC_SoHieuDoi"].ToString();
                row["HvSoCc"] = tb.Rows[i]["CCC_SoCC"].ToString();
                DateTime sQdDate = DateTime.Parse(tb.Rows[i]["DOI_Ngay_QD"].ToString());
                string sSQdDate = sQdDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                row["DateQd"] = sSQdDate.ToString().Substring(0, 2);
                row["MonthQd"] = sSQdDate.ToString().Substring(3, 2);
                row["YearQd"] = sSQdDate.ToString().Substring(6, 4);
                Ds.TableInGcn_MatNgoai.Rows.Add(row);
            }

            return Ds;
        }
        private DataSet bidingDataSet_Mattrong_Doi()
        {
            DataTable tb = new DataTable();

            DsInGCN Ds = new DsInGCN();
            tb = boCcc.get_Print_CcDoi(mChungChiId, StatustDoi, mSoHieuDoi);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow row = Ds.TableInGcn_MatTrong.NewRow();
                    int CHC_ID = Int32.Parse(tb.Rows[i]["CHC_ID"].ToString());
                    row["TrungTam"] = "ĐẠI HỌC GIAO THÔNG VẬN TẢI TPHCM";
                    row["TrungTamE"] = "HOCHIMINH CITY UNIVERSITY OF TRANSPORT";
                    row["FullName"] = tb.Rows[i]["HOV_FirstName"].ToString() + " " + tb.Rows[i]["HOV_LastName"].ToString();
                    row["HvBirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    row["HOV_QuocTich"] = tb.Rows[i]["HOV_QuocTich"].ToString();
                    row["HvSoCc"] = tb.Rows[i]["CCC_SoCC"].ToString();
                    DateTime fromDate = DateTime.Parse(tb.Rows[i]["CCC_NgayCap"].ToString());
                    string sFromDate = fromDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    row["HvNgayCapSoCc"] = sFromDate.ToString().Substring(0, 2) + "/" + sFromDate.ToString().Substring(3, 2) + "/" + sFromDate.ToString().Substring(6, 4);
                    DateTime endDate = DateTime.Parse(tb.Rows[i]["CCC_NgayHetHan"].ToString());
                    string sEndDate = endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    row["HvNgayHetHan"] = sEndDate.ToString().Substring(0, 2) + "/" + sEndDate.ToString().Substring(3, 2) + "/" + sEndDate.ToString().Substring(6, 4);
                    row["CHC_Name"] = tb.Rows[i]["CHC_Name"].ToString();
                    row["HvNoiSinh"] = tb.Rows[i]["TIN_Name"].ToString();
                    row["CHC_Content1"] = tb.Rows[i]["CHC_Content1"].ToString();
                    row["CHC_Content2"] = tb.Rows[i]["CHC_Content2"].ToString();
                    row["CHC_Content3"] = tb.Rows[i]["CHC_Content3"].ToString();
                    row["CHC_Content4"] = tb.Rows[i]["CHC_Content4"].ToString();
                    row["SoQT"] = tb.Rows[i]["CHC_QuyTac"].ToString();
                    row["LocationCenter"] = tb.Rows[i]["CHC_QuyDinh"].ToString();
                    row["Regulation"] = tb.Rows[i]["CHC_QuyDinhEngl"].ToString();
                    row["CHC_FontSize1"] = tb.Rows[i]["CHC_FontSize1"].ToString();
                    row["CHC_FontSize2"] = tb.Rows[i]["CHC_FontSize2"].ToString();
                    row["CHC_FontSize3"] = tb.Rows[i]["CHC_FontSize3"].ToString();
                    row["CHC_FontSize4"] = tb.Rows[i]["CHC_FontSize4"].ToString();
                    row["Img"] = tb.Rows[i]["IMG_Image"];
                    Ds.TableInGcn_MatTrong.Rows.Add(row);
                }
            }

            return Ds;
        }
        private DataSet bidingDataSet_Mattrong_Doi_English()
        {
            DataTable tb = new DataTable();

            DsInGCN Ds = new DsInGCN();
            tb = boCcc.get_Print_CcDoi_English(mChungChiId, StatustDoi, mSoHieuDoi);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow row = Ds.TableInGcn_MatTrong.NewRow();
                    int CHC_ID = Int32.Parse(tb.Rows[i]["CHC_ID"].ToString());
                    row["TrungTam"] = "ĐẠI HỌC GIAO THÔNG VẬN TẢI TPHCM";
                    row["TrungTamE"] = "HOCHIMINH CITY UNIVERSITY OF TRANSPORT";
                    row["FullName"] = tb.Rows[i]["HOV_FirstName"].ToString() + " " + tb.Rows[i]["HOV_LastName"].ToString();
                    row["HvBirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    row["HOV_QuocTich"] = tb.Rows[i]["HOV_QuocTich"].ToString();
                    row["HvSoCc"] = tb.Rows[i]["CCC_SoCC"].ToString();
                    DateTime fromDate = DateTime.Parse(tb.Rows[i]["CCC_NgayCap"].ToString());
                    string sFromDate = fromDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    row["HvNgayCapSoCc"] = sFromDate.ToString().Substring(0, 2) + "/" + sFromDate.ToString().Substring(3, 2) + "/" + sFromDate.ToString().Substring(6, 4);
                    DateTime endDate = DateTime.Parse(tb.Rows[i]["CCC_NgayHetHan"].ToString());
                    string sEndDate = endDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    row["HvNgayHetHan"] = sEndDate.ToString().Substring(0, 2) + "/" + sEndDate.ToString().Substring(3, 2) + "/" + sEndDate.ToString().Substring(6, 4);
                    row["CHC_Name"] = tb.Rows[i]["CHC_Name"].ToString();
                    row["HvNoiSinh"] = tb.Rows[i]["TIN_Name"].ToString();
                    row["CHC_Content1"] = tb.Rows[i]["CHC_Content1"].ToString();
                    row["CHC_Content2"] = tb.Rows[i]["CHC_Content2"].ToString();
                    row["CHC_Content3"] = tb.Rows[i]["CHC_Content3"].ToString();
                    row["CHC_Content4"] = tb.Rows[i]["CHC_Content4"].ToString();
                    row["SoQT"] = tb.Rows[i]["LEV_Number"].ToString();
                    row["LocationCenter"] = tb.Rows[i]["CHC_QuyDinh"].ToString();
                    row["Regulation"] = tb.Rows[i]["CHC_QuyDinhEngl"].ToString();
                    row["CHC_FontSize1"] = tb.Rows[i]["CHC_FontSize1"].ToString();
                    row["CHC_FontSize2"] = tb.Rows[i]["CHC_FontSize2"].ToString();
                    row["CHC_FontSize3"] = tb.Rows[i]["CHC_FontSize3"].ToString();
                    row["CHC_FontSize4"] = tb.Rows[i]["CHC_FontSize4"].ToString();
                    row["Img"] = tb.Rows[i]["IMG_Image"];
                    Ds.TableInGcn_MatTrong.Rows.Add(row);
                }
            }

            return Ds;
        }
        #endregion
    }
}