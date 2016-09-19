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
using CrystalDecisions.Windows.Forms;

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
        BO_CAP_CHUNGCHI boCapChungChi;
        BcChungChi _vDsThongKeCapGCN;
        DataRow vRow;
        int vChcID;
        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            getCurrentMonth();
            vLoadChungChi();
            initComBoboxNhomChungChi();
            radCapDoi.Enabled = false;
            radCapDoi.SelectedIndex = -1;
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
            tbl = BoCc.vGetCapChungChiGeneral(vDto, dateFrom.DateTime, dateEnd.DateTime);
            DataTable tblCcName = new DataTable();
            if (tbl.Rows.Count > 0)
            {
                tblCcName = tbl.DefaultView.ToTable(true, "CHC_Name", "CHC_ID");
                if (tblCcName.Rows.Count > 0)
                {
                    for (int i = 0; i < tblCcName.Rows.Count; i++)
                    {

                    }
                    DataRow vRow = rptbl.NewRow();
                    vRow[colSTT] = 1;
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        DataRow[] xxcolCapLai = tbl.Select("CCC_Status=1");

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
            
            rpThongKeCapGCN();
            if (lookKhoaHoc_InGCN.ItemIndex > -1)
            {
                vGetCapChungChiGeneral();
            }
        }
        private void rpThongKeCapGCN()
        {
            CsDLCapGCN _rpThongKeCapGCN = new CsDLCapGCN();
            if (radCapDoi.SelectedIndex<0)
            {
                _rpThongKeCapGCN.SetDataSource(vDsThongKeCapGCN());
            }
            else
            {
                _rpThongKeCapGCN.SetDataSource(vDsThongKeWithRadCap());
            }
            //_rpThongKeCapGCN.SetParameterValue("fromDate", dateFrom.DateTime.ToShortDateString());
            //_rpThongKeCapGCN.SetParameterValue("toDate", dateEnd.DateTime.ToShortDateString());
            crytalThongKe.ReportSource = _rpThongKeCapGCN;
            crytalThongKe.ToolPanelView = ToolPanelViewType.None;
            crytalThongKe.RefreshReport();
        }
        private DataSet vDsThongKeCapGCN()
        {
            boCapChungChi = new BO_CAP_CHUNGCHI();
            tbl = new DataTable();
            _vDsThongKeCapGCN = new BcChungChi();
            object vDateCapChungChi;
            if (lookKhoaHoc_InGCN.ItemIndex > -1)
            {
                vChcID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
                tbl = boCapChungChi.vLoadDataCapChungChiByCHCID(vChcID, dateFrom.DateTime, dateEnd.DateTime);
            }
            else
            {
                tbl = boCapChungChi.vLoadDataCapChungChiByDate(dateFrom.DateTime, dateEnd.DateTime);
            }

            if (tbl.Rows.Count > 0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    vRow = _vDsThongKeCapGCN.TkCapGCN.NewRow();
                    vRow["STT"] = i + 1;
                    vRow["CHC_Name"] = tbl.Rows[i]["CHC_Name"];
                    vRow["HOV_FirstName"] = tbl.Rows[i]["HOV_FullName"];
                    vRow["HOV_LastName"] = tbl.Rows[i]["HOV_LastName"];
                    vRow["HOV_BirthDay"] = tbl.Rows[i]["HOV_BirthDay"];
                    vRow["TIN_Name"] = tbl.Rows[i]["TIN_Name"];
                    vRow["CCC_SoCC"] = tbl.Rows[i]["CCC_SoCC"];
                    vRow["IMG_Image"] = tbl.Rows[i]["IMG_Image"];
                    if (int.Parse(tbl.Rows[i]["CCC_LOPID"].ToString()) > -1)
                    {
                        vRow["LOP_ShortName"] = tbl.Rows[i]["LOP_ShortName"];
                    }
                    else
                    {
                        vRow["LOP_ShortName"] = tbl.Rows[i]["CCC_SoHieuDoi"];
                    }
                    if (int.Parse(tbl.Rows[i]["CCC_Status"].ToString()) == 1)
                    {
                        vRow["CCC_StatusCap"] = "Cấp mới";
                    }
                    else if (int.Parse(tbl.Rows[i]["CCC_Status"].ToString()) == 2)
                    {
                        vRow["CCC_StatusCap"] = "Cấp lại";
                    }
                    else
                    {
                        vRow["CCC_StatusCap"] = "Cấp đổi";
                    }
                    vDateCapChungChi = DateTime.Parse(tbl.Rows[i]["CCC_NgayCap"].ToString());
                    vRow["CCC_NgayCap"] = string.Format("{0:dd/MM/yyyy}", vDateCapChungChi).ToString().Substring(0, 10);
                    vRow["fromDate"] = dateFrom.DateTime.ToShortDateString();
                    vRow["toDate"] = dateEnd.DateTime.ToShortDateString();
                    _vDsThongKeCapGCN.TkCapGCN.Rows.Add(vRow);
                }
            }
            return _vDsThongKeCapGCN;
        }
        private DataSet vDsThongKeWithRadCap()
        {
            _vDsThongKeCapGCN = new BcChungChi();
            object vDateCapChungChi;
            if (radCapDoi.SelectedIndex == 0)
            {
                vLoadDataThongKeWithRadCap(1);
            }
            else if (radCapDoi.SelectedIndex == 1)
            {
                vLoadDataThongKeWithRadCap(2);
            }
            else
            {
                vLoadDataThongKeWithRadCap(3);
            }
            if (tbl.Rows.Count>0)
            {
                for (int i = 0; i < tbl.Rows.Count; i++)
                {
                    vRow = _vDsThongKeCapGCN.TkCapGCN.NewRow();
                    vRow["STT"] = i + 1;
                    vRow["CHC_Name"] = tbl.Rows[i]["CHC_Name"];
                    vRow["HOV_FirstName"] = tbl.Rows[i]["HOV_FullName"];
                    vRow["HOV_LastName"] = tbl.Rows[i]["HOV_LastName"];
                    vRow["HOV_BirthDay"] = tbl.Rows[i]["HOV_BirthDay"];
                    vRow["TIN_Name"] = tbl.Rows[i]["TIN_Name"];
                    vRow["CCC_SoCC"] = tbl.Rows[i]["CCC_SoCC"];
                    vRow["IMG_Image"] = tbl.Rows[i]["IMG_Image"];
                    if (int.Parse(tbl.Rows[i]["CCC_LOPID"].ToString()) > -1)
                    {
                        vRow["LOP_ShortName"] = tbl.Rows[i]["LOP_ShortName"];
                    }
                    else
                    {
                        vRow["LOP_ShortName"] = tbl.Rows[i]["CCC_SoHieuDoi"];
                    }
                    if (int.Parse(tbl.Rows[i]["CCC_Status"].ToString()) == 1)
                    {
                        vRow["CCC_StatusCap"] = "Cấp mới";
                    }
                    else if (int.Parse(tbl.Rows[i]["CCC_Status"].ToString()) == 2)
                    {
                        vRow["CCC_StatusCap"] = "Cấp lại";
                    }
                    else
                    {
                        vRow["CCC_StatusCap"] = "Cấp đổi";
                    }
                    vDateCapChungChi = DateTime.Parse(tbl.Rows[i]["CCC_NgayCap"].ToString());
                    vRow["CCC_NgayCap"] = string.Format("{0:dd/MM/yyyy}", vDateCapChungChi).ToString().Substring(0, 10);
                    vRow["fromDate"] = dateFrom.DateTime.ToShortDateString();
                    vRow["toDate"] = dateEnd.DateTime.ToShortDateString();
                    _vDsThongKeCapGCN.TkCapGCN.Rows.Add(vRow);
                }
            }
            return _vDsThongKeCapGCN;
        }
        private void vLoadDataThongKeWithRadCap(int vStatusCap)
        {
            boCapChungChi = new BO_CAP_CHUNGCHI();
            tbl = new DataTable();
            if (lookKhoaHoc_InGCN.ItemIndex > -1)
            {
                vChcID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
                tbl = boCapChungChi.vLoadDataCapChungChiByChcIDWithStatus(vStatusCap, vChcID, dateFrom.DateTime, dateEnd.DateTime);
            }
            else
            {
                tbl = boCapChungChi.vLoadDataCapChungChiByDateWithStatus(vStatusCap, dateFrom.DateTime, dateEnd.DateTime);
            }
        }
        private void chckEnableRadCapDoi_CheckedChanged(object sender, EventArgs e)
        {
            if (chckEnableRadCapDoi.Checked)
            {
                radCapDoi.Enabled = true;
            }
            else
            {
                radCapDoi.Enabled = false;
                radCapDoi.SelectedIndex = -1;
            }
        }
        private void initComBoboxNhomChungChi()
        {
            lookupNhomCc.Properties.DataSource = vLookupLoaiChungChi();
            lookupNhomCc.Properties.DisplayMember = "LOA_Name";
            lookupNhomCc.Properties.ValueMember = "LOA_ID";
        }
        private DataTable vLookupLoaiChungChi()
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

        private void lookupNhomCc_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupNhomCc.ItemIndex>-1)
            {
                int a = int.Parse(lookupNhomCc.GetColumnValue("LOA_ID").ToString());
            }
        }

        private void btnThongKeLopHoc_Click(object sender, EventArgs e)
        {

        }
    }
}