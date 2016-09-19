using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using TTHLTV.DTO;
using TTHLTV.Report;
namespace TTHLTV
{
    public partial class frmBaoCaoThongKe : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCaoThongKe()
        {
            InitializeComponent();
        }
        BO_CHUNG_CHI BoCc;
        CHUNG_CHI vDto;
        DataTable tbl;
        DataTable rptbl;
        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            getCurrentMonth();
            vLoadChungChi();
        }

        private void getCurrentMonth()
        {
            DateTime vDate = DateTime.Now;
            vDate = new DateTime(vDate.Year, vDate.Month, 1);
            dateFrom.EditValue = vDate;
            dateEnd.EditValue = vDate.AddMonths(1).AddDays(-1);
        }
        private void vLoadChungChi()
        {
            BoCc = new BO_CHUNG_CHI();
            tbl = new DataTable();
            tbl = BoCc.getChungChi_All();
            if (tbl.Rows.Count > 0)
            {
                lookKhoaHoc_InGCN.Properties.DataSource = tbl.DefaultView;
                lookKhoaHoc_InGCN.Properties.DisplayMember = "CHC_Name";
                lookKhoaHoc_InGCN.Properties.ValueMember = "CHC_ID";
            }
        }
        private DataTable vGetCapChungChiGeneral()
        {
            tbl = new DataTable();
            BoCc = new BO_CHUNG_CHI();
            vDto = new CHUNG_CHI();
            rptbl = new DataTable();
            DataColumn colSTT = new DataColumn("STT");
            DataColumn colCHCName = new DataColumn("CHC_Name");
            DataColumn colCapMoi = new DataColumn("TotlaCapMoi");
            DataColumn colCapDoi = new DataColumn("TotalCapDoi");
            DataColumn colCapLai = new DataColumn("TotalCapLai");
            rptbl.Columns.Add(colSTT);
            rptbl.Columns.Add(colCHCName);
            rptbl.Columns.Add(colCapMoi);
            rptbl.Columns.Add(colCapDoi);
            rptbl.Columns.Add(colCapLai);
            vDto.CHC_ID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
            tbl = BoCc.vGetCapChungChiGeneral(vDto,dateFrom.DateTime,dateEnd.DateTime);
            DataTable tblCcName = new DataTable();
           
            
            
            if (tbl.Rows.Count>0)
            {
                tblCcName= tbl.DefaultView.ToTable(true,"CHC_Name","CHC_ID");
                if (tblCcName.Rows.Count>0)
	            {
                    for (int i = 0; i < tblCcName.Rows.Count; i++)
                    {
                        
                    }
                    DataRow vRow = rptbl.NewRow();
                     vRow[colSTT] = 1;




                    for (int i  = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow [] xxcolCapLai = tbl.Select("CCC_Status=1");
                       
                    }   
		 
	            }
                     
            }            
            
            int ccx = 0;
            //ccx = xx.Length;
            return tbl;
        }

        private DataTable initTable()
        {
            return rptbl;
        }
        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            vGetCapChungChiGeneral();
        }
    }
}