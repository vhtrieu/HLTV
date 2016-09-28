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
        BO_LOP lop;
        DataTable tblNhomChungChi;
        int _SumCapMoi = 0;
        int _SumCapLai = 0;
        int _SumCapDoi = 0;
        int _SumTotal = 0;
        private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
        {
            getCurrentMonth();
            vLoadChungChi();
            initComBoboxNhomChungChi();
            lookKhoaHoc_InGCN.Enabled = false;
            radCapDoi.Enabled = false;
            radCapDoi.SelectedIndex = -1;
            lookupNhomCc.Enabled = false;
            lookChungChiTK.Enabled = false;
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
            if (radCapDoi.SelectedIndex < 0)
            {
                _rpThongKeCapGCN.SetDataSource(vDsThongKeCapGCN());
            }
            else
            {
                _rpThongKeCapGCN.SetDataSource(vDsThongKeWithRadCap());
            }
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
            if (lookKhoaHoc_InGCN.ItemIndex > -1 && lookKhoaHoc_InGCN.Enabled==true)
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
            lookupNhomCc.Properties.DataSource = tblLoaiChungChi();
            lookupNhomCc.Properties.DisplayMember = "LOA_Name";
            lookupNhomCc.Properties.ValueMember = "LOA_ID";
        }
        private DataTable tblLoaiChungChi()
        {
            tblNhomChungChi = new DataTable();
            tblNhomChungChi.Columns.Add("LOA_ID", typeof(int));
            tblNhomChungChi.Columns.Add("LOA_Name", typeof(string));
            tblNhomChungChi.Rows.Add(1, "Huấn luyện NV cơ bản (HLNVCB)");
            tblNhomChungChi.Rows.Add(2, "Huấn luyện NV chuyên môn (HLNVCM)");
            tblNhomChungChi.Rows.Add(3, "Huấn luyện NV Đặc biệt (HLNVĐB)");
            tblNhomChungChi.Rows.Add(5, "Cập nhật STCW 2010 (CNSTCW)");
            tblNhomChungChi.Rows.Add(4, "Huấn luyện khác");
            return tblNhomChungChi;
        }
        private void initComboboxChungChi(int _nhomCcID)
        {
            BoCc = new BO_CHUNG_CHI();
            lookChungChiTK.Properties.DataSource = BoCc.getChungChiByNhomCcID(_nhomCcID);
            lookChungChiTK.Properties.DisplayMember = "CHC_Name";
            lookChungChiTK.Properties.ValueMember = "CHC_ID";
        }
        private void lookupNhomCc_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupNhomCc.ItemIndex > -1)
            {
                initComboboxChungChi(int.Parse(lookupNhomCc.GetColumnValue("LOA_ID").ToString()));
            }
        }
        private void initThongKe()
        {
            int _nhomCcID = 0;
            string _nhomCcName = string.Empty;
            DataTable tblChungChi = new DataTable();
            lop = new BO_LOP();
            boCapChungChi = new BO_CAP_CHUNGCHI();
            _vDsThongKeCapGCN = new BcChungChi();
            int _ChcID = -1;
            if (lookupNhomCc.ItemIndex > -1 && lookupNhomCc.Enabled==true)
            {
                _nhomCcID = int.Parse(lookupNhomCc.GetColumnValue("LOA_ID").ToString());
                _nhomCcName = lookupNhomCc.Text;
                if (lookChungChiTK.ItemIndex > -1 && lookChungChiTK.Enabled==true)
                {
                    _ChcID = int.Parse(lookChungChiTK.GetColumnValue("CHC_ID").ToString());
                    tblChungChi = lop.getChungChiThongKeWithCcID(dateFrom.DateTime, dateEnd.DateTime, _nhomCcID, _ChcID);
                    initDataSetThongKeCapGCN(tblChungChi, _nhomCcName);
                }
                else
                {
                    tblChungChi = lop.getChungChiThongKe(dateFrom.DateTime, dateEnd.DateTime, _nhomCcID);
                    initDataSetThongKeCapGCN(tblChungChi, _nhomCcName);
                }
            }
            else
            {
                for (int iNhomCc = 0; iNhomCc < tblNhomChungChi.Rows.Count; iNhomCc++)
                {
                    _nhomCcID = int.Parse(tblNhomChungChi.Rows[iNhomCc]["LOA_ID"].ToString());
                    _nhomCcName = tblNhomChungChi.Rows[iNhomCc]["LOA_Name"].ToString();
                    tblChungChi = lop.getChungChiThongKe(dateFrom.DateTime, dateEnd.DateTime, _nhomCcID);
                    initDataSetThongKeCapGCN(tblChungChi, _nhomCcName);
                }
            }
            rpThongKeCapGCN rpt = new rpThongKeCapGCN();
            rpt.SetDataSource(_vDsThongKeCapGCN.Tables["ThongKeCapChungChi"]);
            rpt.SetParameterValue("_fromDate", dateFrom.Text);
            rpt.SetParameterValue("_toDate", dateEnd.Text);
            rpt.SetParameterValue("_SumCapDoi", _SumCapDoi.ToString("#,##0"));
            rpt.SetParameterValue("_SumCapMoi", _SumCapMoi.ToString("#,##0"));
            rpt.SetParameterValue("_SumCapLai", _SumCapLai.ToString("#,##0"));
            rpt.SetParameterValue("_SumTotal", _SumTotal.ToString("#,##0"));
            crytalThongKe.ReportSource = rpt;
            crytalThongKe.ToolPanelView = ToolPanelViewType.None;
            _SumCapDoi = 0;
            _SumCapMoi = 0;
            _SumCapLai = 0;
            _SumTotal = 0;
        }
        private void initDataSetThongKeCapGCN(DataTable _tblChungChi, string _nhomCcName)
        {
            int _CcID = 0;
            int _totalCapMoi = 0;
            int _totalCapLai = 0;
            int _totalCapDoi = 0;
            int _Summary = 0;
            for (int idxCc = 0; idxCc < _tblChungChi.Rows.Count; idxCc++)
            {
                _CcID = int.Parse(_tblChungChi.Rows[idxCc]["CHC_ID"].ToString());
                tbl = boCapChungChi.vLoadDataCapChungChiByCHCID(_CcID, dateFrom.DateTime, dateEnd.DateTime);
                if (tbl.Rows.Count > 0)
                {
                    for (int i = 0; i < tbl.Rows.Count; i++)
                    {
                        if (int.Parse(tbl.Rows[i]["CCC_Status"].ToString()) == 1)
                        {
                            //vRow["CCC_StatusCap"] = "Cấp mới";
                            _totalCapMoi++;
                        }
                        else if (int.Parse(tbl.Rows[i]["CCC_Status"].ToString()) == 2)
                        {
                            //vRow["CCC_StatusCap"] = "Cấp lại";
                            _totalCapLai++;
                        }
                        else
                        {
                            //vRow["CCC_StatusCap"] = "Cấp đổi";
                            _totalCapDoi++;
                        }
                        _Summary = _totalCapMoi + _totalCapLai + _totalCapDoi;

                    }
                    _SumCapMoi += _totalCapMoi;
                    _SumCapLai += _totalCapLai;
                    _SumCapDoi += _totalCapDoi;
                    _SumTotal += _Summary;
                }
                vRow = _vDsThongKeCapGCN.ThongKeCapChungChi.NewRow();

                vRow["CHC_Name"] = _tblChungChi.Rows[idxCc]["CHC_Name"];
                vRow["NhomChungChi"] = _nhomCcName;
                vRow["CCC_CapMoi"] = _totalCapMoi;
                vRow["CCC_CapLai"] = _totalCapLai;
                vRow["CCC_CapDoi"] = _totalCapDoi;
                vRow["Summary"] = _Summary;
                _vDsThongKeCapGCN.ThongKeCapChungChi.Rows.Add(vRow);
                _Summary = 0;
                _totalCapDoi = 0;
                _totalCapLai = 0;
                _totalCapMoi = 0;
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (rdThongKe.SelectedIndex ==0)
            {
                initThongKeDangKiHoc();
            }
            else
            {
                initThongKe();
            }
            
        }
        private void initThongKeDangKiHoc()
        {
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
            DataTable tableHocvien = new DataTable(); ;
            lop = new BO_LOP();
            int _SoHvChuaCapCC = 0;
            int _SoHvDaCapCc = 0;
            DataTable TableChungChi = new DataTable();
            DataTable tableLop = new DataTable();
            string _NhomCc = string.Empty;
            int _nhomCcID = 0;
            for (int iLoaiCc = 1; iLoaiCc < tblLoaiChungChi().Rows.Count + 1; iLoaiCc++)
            {
                _NhomCc = tblLoaiChungChi().Rows[iLoaiCc - 1]["LOA_Name"].ToString();
                _nhomCcID = int.Parse(tblLoaiChungChi().Rows[iLoaiCc - 1]["LOA_ID"].ToString());
                TableChungChi = lop.getChungChiThongKe(dateFrom.DateTime, dateEnd.DateTime, _nhomCcID);
                totalChungchi += TableChungChi.Rows.Count;

                for (int iChcID = 0; iChcID < TableChungChi.Rows.Count; iChcID++)
                {
                    CHC_Name = TableChungChi.Rows[iChcID]["CHC_Name"].ToString();
                    CHC_ID = int.Parse(TableChungChi.Rows[iChcID]["CHC_ID"].ToString());
                    tableLop = lop.getLopThongKe(CHC_ID, dateFrom.DateTime, dateEnd.DateTime);
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
            rpt.SetParameterValue("totalChungChi", totalChungchi.ToString("#,##0"));
            rpt.SetParameterValue("numHocChuaCapCc", numHocChuaCapCc.ToString("#,##0"));
            rpt.SetParameterValue("totalLop", numLop.ToString("#,##0"));
            rpt.SetParameterValue("totalHocvien", numHocvien.ToString("#,##0"));
            rpt.SetParameterValue("fromDate", dateFrom.Text);
            rpt.SetParameterValue("endDate", dateEnd.Text);
            crytalThongKe.ReportSource = rpt;
            crytalThongKe.ToolPanelView = ToolPanelViewType.None;
        }

        private void isCheck1_CheckedChanged(object sender, EventArgs e)
        {
            if (isCheck1.Checked == true)
            {
                lookKhoaHoc_InGCN.Enabled = true;
            }
            else
                lookKhoaHoc_InGCN.Enabled = false;
        }

        private void isCheck2_CheckedChanged(object sender, EventArgs e)
        {
            if (isCheck2.Checked == true)
            {
                lookupNhomCc.Enabled = true;
            }
            else
                lookupNhomCc.Enabled = false;
        }

        private void isCheck3_CheckedChanged(object sender, EventArgs e)
        {
            if (isCheck3.Checked == true)
            {
                lookChungChiTK.Enabled = true;
            }
            else
                lookChungChiTK.Enabled = false;
        }
    }
}