using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using TTHLTV.Report;
using CrystalDecisions.Windows.Forms;

namespace TTHLTV
{
    public partial class frmPrintStatics : DevExpress.XtraEditors.XtraForm
    {
        BO_CHUNG_CHI chungchi = new BO_CHUNG_CHI();
        BO_LOP lop = new BO_LOP();
        public DateTime mfromDates;
        public DateTime mendDates;
        public string prmFromDate;
        public string prmEndDate;
        public frmPrintStatics()
        {
            InitializeComponent();
        }
      private DataTable tblNhomChungChi()
        {
            DataTable vTable = new DataTable();
            vTable.Columns.Add("LOA_ID", typeof(int));
            vTable.Columns.Add("LOA_Name", typeof(string));

            vTable.Rows.Add(1, "Huấn luyện NV cơ bản (HLNVCB)");
            vTable.Rows.Add(2, "Huấn luyện NV chuyên môn (HLNVCM)");
            vTable.Rows.Add(3, "Huấn luyện NV Đặc biệt (HLNVĐB)");
            vTable.Rows.Add(5, "Cập nhật STCW 2010 (CNSTCW)");
            vTable.Rows.Add(4, "Huấn luyện khác");
            return vTable;
        }
        private void init()
        {
            //DataTable tableReport = new DataTable();
            //DataColumn colSTT = new DataColumn("STT");
            //DataColumn colCHCName = new DataColumn("CHC_Name");
            //DataColumn colTotalLop = new DataColumn("TotalLop");
            //DataColumn colLopName = new DataColumn("LopName");
            //DataColumn coltotalHocvien = new DataColumn("TotalHocvien");
            //DataColumn coltotalHocvienChuaCapCc = new DataColumn("coltotalHocvienChuaCapCc");
            //DataColumn coltotalHocvienDaCapCc = new DataColumn("coltotalHocvienDaCapCc");
            //DataColumn colNhomCC = new DataColumn("NhomChungChi");
            //tableReport.Columns.Add(colSTT);
            //tableReport.Columns.Add(colCHCName);
            //tableReport.Columns.Add(colTotalLop);
            //tableReport.Columns.Add(colLopName);
            //tableReport.Columns.Add(coltotalHocvien);
            //tableReport.Columns.Add(coltotalHocvienChuaCapCc);
            //tableReport.Columns.Add(coltotalHocvienDaCapCc);
            //tableReport.Columns.Add(colNhomCC);
            vDsThongKeLopHoc _dsThongKeLopHoc = new vDsThongKeLopHoc();
            int totalChungchi = 0;
            int numLop = 0;
            int numHocvien = 0;
            int numHocChuaCapCc = 0;
            int index = 1;
            int CHC_ID = 0;
            string CHC_Name = string.Empty;
            int totalLop = 0;
            int LOP_ID = 0;
            string LOP_Name = string.Empty;
            DataTable tableHocvien =new DataTable(); ;
            //int totalhhocvien = 0;
            int _SoHvChuaCapCC = 0;
            int _SoHvDaCapCc = 0;
            DateTime fromDates = mfromDates;
            DateTime endDates = mendDates;
            DataTable TableChungChi = new DataTable();
            DataTable tableLop = new DataTable();
            string _NhomCc = string.Empty;
            int _nhomCcID = 0;
            for (int iLoaiCc = 1; iLoaiCc < tblNhomChungChi().Rows.Count+1; iLoaiCc++)
            {
                _NhomCc = tblNhomChungChi().Rows[iLoaiCc-1]["LOA_Name"].ToString();
                _nhomCcID = int.Parse(tblNhomChungChi().Rows[iLoaiCc - 1]["LOA_ID"].ToString());
                TableChungChi = lop.getChungChiThongKe(fromDates, endDates, _nhomCcID);
                totalChungchi += TableChungChi.Rows.Count;
                for (int iChcID = 0; iChcID < TableChungChi.Rows.Count; iChcID++)
                {
                    CHC_Name = TableChungChi.Rows[iChcID]["CHC_Name"].ToString();
                    CHC_ID = int.Parse(TableChungChi.Rows[iChcID]["CHC_ID"].ToString());
                    tableLop = lop.getLopThongKe(CHC_ID, fromDates, endDates);
                    totalLop += tableLop.Rows.Count;
                    numLop += totalLop;
                    for (int iLopID = 0; iLopID < tableLop.Rows.Count; iLopID++)
                    {
                        LOP_ID = int.Parse(tableLop.Rows[iLopID]["LOP_ID"].ToString());
                        LOP_Name = tableLop.Rows[iLopID]["LOP_ShortName"].ToString();
                        tableHocvien = lop.getHocVienThongKe(LOP_ID);
                        numHocvien += tableHocvien.Rows.Count;
                        for (int i = 0; i < tableHocvien.Rows.Count; i++)
                        {
                            if (tableHocvien.Rows[i]["CCC_SoCc"].ToString() == string.Empty)
                            {
                                _SoHvChuaCapCC++;
                            }
                            else
                            {
                                _SoHvDaCapCc++;
                            }
                        }

                        DataRow row = _dsThongKeLopHoc.tblThongKeLopHoc.NewRow();
                        row["STT"] = (index).ToString();
                        row["CHC_Name"] = CHC_Name;
                        row["TotalLop"] = totalLop;
                        row["LopName"] = LOP_Name;
                        row["TotalHocvien"] = tableHocvien.Rows.Count;
                        //row[coltotalHocvienChuaCapCc] = _SoHvChuaCapCC;
                        row["TotalHocVienDaCapCc"] = _SoHvDaCapCc;
                        row["NhomChungChi"] = _NhomCc;
                        _dsThongKeLopHoc.tblThongKeLopHoc.Rows.Add(row);
                        index++;
                        numHocChuaCapCc += _SoHvDaCapCc;
                        _SoHvChuaCapCC = 0;
                        _SoHvDaCapCc = 0;
                        totalLop = 0;
                    }
                }
            }
            
            rptStatistics rpt = new rptStatistics();
            rpt.SetDataSource(_dsThongKeLopHoc);
            rpt.SetParameterValue("totalChungChi", totalChungchi);
            rpt.SetParameterValue("numHocChuaCapCc", numHocChuaCapCc);
            rpt.SetParameterValue("totalLop", numLop);
            rpt.SetParameterValue("totalHocvien", numHocvien);
            rpt.SetParameterValue("fromDate", prmFromDate);
            rpt.SetParameterValue("endDate", prmEndDate);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            
        }

        private void frmPrintStatics_Load(object sender, EventArgs e)
        {
            init();
        }
    }
}