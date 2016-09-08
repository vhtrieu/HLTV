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

        private void init()
        {
            //create datatable
            DataTable tableReport = new DataTable();
            DataColumn colSTT = new DataColumn("STT");
            DataColumn colCHCName = new DataColumn("CHC_Name");
            DataColumn colTotalLop = new DataColumn("TotalLop");
            DataColumn colLopName = new DataColumn("LopName");
            DataColumn coltotalHocvien = new DataColumn("TotalHocvien");
            tableReport.Columns.Add(colSTT);
            tableReport.Columns.Add(colCHCName);
            tableReport.Columns.Add(colTotalLop);
            tableReport.Columns.Add(colLopName);
            tableReport.Columns.Add(coltotalHocvien);

            int totalChungchi = 0;
            int numLop = 0;
            int numHocvien = 0;
            int index = 1;

            DateTime fromDates = mfromDates;
            DateTime endDates = mendDates;
            DataTable TableChungChi = new DataTable();
            DataTable tableLop = new DataTable();
            TableChungChi = lop.getChungChiThongKe(fromDates, endDates);

            if (TableChungChi.Rows.Count > 0)
            {
                 int totalLop = 0;
                 totalChungchi = TableChungChi.Rows.Count;// get total chung_chi
                for (int i = 0; i < totalChungchi; i++)
                {
                    int CHC_ID = int.Parse( TableChungChi.Rows[i]["CHC_ID"].ToString());
                    string CHC_Name = TableChungChi.Rows[i]["CHC_Name"].ToString();
                    tableLop = lop.getLopThongKe(CHC_ID, fromDates, endDates);
                    if (tableLop.Rows.Count > 0)
                    {
                         totalLop = tableLop.Rows.Count;// get total Lop for each chung_chi
                        numLop += totalLop;
                        for (int j = 0; j < totalLop; j++)
                        {
                            int LOP_ID = int.Parse( tableLop.Rows[j]["LOP_ID"].ToString());//LOP_ID
                            string LOP_Name = tableLop.Rows[j]["LOP_Name"].ToString();//LOP_Name
                            DataTable tableHocvien = new DataTable();
                            tableHocvien = lop.getHocVienThongKe(LOP_ID);
                            int totalhhocvien = Convert.ToInt32(tableHocvien.Rows[0][0].ToString());
                            numHocvien += totalhhocvien;

                            DataRow row = tableReport.NewRow();
                            row[colSTT] = (index).ToString();
                            row[colCHCName] = CHC_Name;
                            row[colTotalLop] = totalLop;
                            row[colLopName] = LOP_Name;
                            row[coltotalHocvien] = totalhhocvien.ToString();
                            tableReport.Rows.Add(row);
                            index++;
 
                        }
                    }
 
                }
 
            }
        
            // To do
            rptStatistics rpt = new rptStatistics();
            rpt.SetDataSource(tableReport);
            rpt.SetParameterValue("totalChungChi", totalChungchi);
            rpt.SetParameterValue("totalLop", numLop);
            rpt.SetParameterValue("totalHocvien", numHocvien);
            rpt.SetParameterValue("fromDate", prmFromDate);
            rpt.SetParameterValue("endDate", prmEndDate);
            crystalReportViewer1.ReportSource = rpt;
            // add cho no cai parameter cho nay
           // this.crystalReportViewer1.ReportRefresh();
        }

        private void frmPrintStatics_Load(object sender, EventArgs e)
        {
            init();
        }
    }
}