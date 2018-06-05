using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TTHLTV.BAL;

namespace TTHLTV.InBieuMau
{
    public partial class frmInBieuMau : Form
    {
        public frmInBieuMau()
        {
            InitializeComponent();
        }
        BO_CHUNG_CHI bal;
        BO_LOP balLop;
        BO_CAP_CHUNGCHI boCcc;
        BO_DIEM boDiem;
        DataTable tb;
        BO_HOCVIEN boHv;
        DataRow vRow;
        DsInBieuMau vDsBieuMau;
        string vLopName = string.Empty;

        private void initComboxKhoaHoc()
        {
            bal = new BO_CHUNG_CHI();
            lookKhoaHoc_InGCN.Properties.DataSource = bal.getChungChi_All();
            lookKhoaHoc_InGCN.Properties.ValueMember = "CHC_ID";
            lookKhoaHoc_InGCN.Properties.DisplayMember = "CHC_Name";
        }
        private void initComboboxLopHoc(int vChungChiID)
        {
            balLop = new BO_LOP();
            lookLop_InGCN.Properties.DataSource = balLop.getLOP_ByCcID(vChungChiID);
            lookLop_InGCN.Properties.ValueMember = "LOP_ID";
            lookLop_InGCN.Properties.DisplayMember = "LOP_Name";
        }
        private void frmInBieuMau_Load(object sender, EventArgs e)
        {
            initComboxKhoaHoc();
            radBieuMau_SelectedIndexChanged(sender, e);
            btnPrint.Enabled = false;
        }
        private void initComboboxSoHieuDoi(int vChungChiID)
        {
            int sCap = -1;
            boCcc = new BO_CAP_CHUNGCHI();
            if (lookKhoaHoc_InGCN.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn chứng chỉ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (radCapQ.SelectedIndex == 1)
                {
                    sCap = 2;
                }
                else if (radCapQ.SelectedIndex == 2)
                {
                    sCap = 3;
                }
                lookUpSoHieuDoi.Properties.DataSource = boCcc.get_SoHieuDoi_Cc(vChungChiID, sCap);
                lookUpSoHieuDoi.Properties.ValueMember = "CCC_SoHieuDoi";
                lookUpSoHieuDoi.Properties.DisplayMember = "CCC_SoHieuDoi";
            }
        }
        private void initComboboxMonHoc()
        {
            BO_DANG_KI_HOC dao_dangki_hoc = new BO_DANG_KI_HOC();
            lookMonHoc.Properties.DataSource = dao_dangki_hoc.getSubjectName(int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()));
            lookMonHoc.Properties.ValueMember = "MON_ID";
            lookMonHoc.Properties.DisplayMember = "MON_Name";
        }
        private void initComboboxLanThi(int vLopID, int vMonID)
        {
            boDiem = new BO_DIEM();
            lookLanThi.Properties.DataSource = boDiem.lanThi(vLopID, vMonID);
            lookLanThi.Properties.ValueMember = "DIE_LanThi";
            lookLanThi.Properties.DisplayMember = "DIE_LanThi";
            lookLanThi.ItemIndex = 0;
        }
        private void lookKhoaHoc_InGCN_EditValueChanged(object sender, EventArgs e)
        {
            int vChungChiID = -1;
            if (lookKhoaHoc_InGCN.ItemIndex > -1)
            {
                vChungChiID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
                initComboboxLopHoc(vChungChiID);
                initComboboxSoHieuDoi(vChungChiID);
                lookMonHoc.EditValue = null;
                lookLanThi.EditValue = null;
                radCapQ.SelectedIndex = -1;
                vCheckEnableButtonPrint(radBieuMau.SelectedIndex);
            }
        }
        private void lookLop_InGCN_EditValueChanged(object sender, EventArgs e)
        {
            if (lookKhoaHoc_InGCN.ItemIndex > -1)
            {
                initComboboxMonHoc();
                vCheckEnableButtonPrint(radBieuMau.SelectedIndex);
            }
        }
        private void radCapQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int vChungChiID = -1;
            if (radCapQ.SelectedIndex == 1 || radCapQ.SelectedIndex == 2)
            {
                vChungChiID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
                lookUpSoHieuDoi.Visible = true;
                lookLop_InGCN.Visible = false;
                lookUpSoHieuDoi.Enabled = true;
                initComboboxSoHieuDoi(vChungChiID);
                vCheckEnableButtonPrint(radBieuMau.SelectedIndex);
            }
            else
            {
                lookUpSoHieuDoi.Visible = false;
                lookLop_InGCN.Visible = true;
            }
        }
        private void vCheckRadCap()
        {
            if (radBieuMau.SelectedIndex == 3 || radBieuMau.SelectedIndex == 4)
            {
                radCapQ.Enabled = true;
            }
            else
            {
                radCapQ.Enabled = false;
            }
        }
        private void lookMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (lookMonHoc.ItemIndex > -1)
            {
                int vLopID = int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString());
                int vMonID = int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString());
                initComboboxLanThi(vLopID,vMonID);
                vCheckEnableButtonPrint(radBieuMau.SelectedIndex);
            }
        }
        private void radBieuMau_SelectedIndexChanged(object sender, EventArgs e)
        {
            lookKhoaHoc_InGCN.EditValue = null;
            lookLop_InGCN.EditValue = null;
            lookLanThi.EditValue = null;
            lookUpSoHieuDoi.EditValue = null;
            btnPrint.Enabled = false;
            vCheckRadCap();
            vCheckRadioBieuMau(radBieuMau.SelectedIndex);
        }
        private void vCheckRadioBieuMau(int vIndex)
        {
            
            if (vIndex == 0 || vIndex == 3 || vIndex == 4)
            {
                lookMonHoc.Enabled = false;
                lookLanThi.Enabled = false;
            }
            else
            {
                lookMonHoc.Enabled = true;
                lookLanThi.Enabled = true;
            }

        }
        private void vCheckEnableButtonPrint(int vIndex)
        {
            if (vIndex==0)
            {
                if (lookLop_InGCN.ItemIndex>-1)
                {
                    btnPrint.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
                }
            }
            if (vIndex == 1|| vIndex==2)
            {
                if (lookMonHoc.ItemIndex > -1)
                {
                    btnPrint.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
                }
            }
            if (vIndex == 3|| vIndex ==4)
            {
                if (radCapQ.SelectedIndex>0)
                {
                    if (lookUpSoHieuDoi.ItemIndex > -1)
                    {
                        btnPrint.Enabled = true;
                    }
                    else
                    {
                        btnPrint.Enabled = false;
                    }
                }
                else
                {
                    if (lookLop_InGCN.ItemIndex > -1)
                    {
                        btnPrint.Enabled = true;
                    }
                    else
                    {
                        btnPrint.Enabled = false;
                    }
                }
                
            }

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lookKhoaHoc_InGCN.ItemIndex>-1)
            {
                initPrintReport(radBieuMau.SelectedIndex);
            }
        }
        private void initPrintReport(int vIndex)
        {
            switch (vIndex)
            {
                case 0:
                    {
                        rpDanhSachHocVien();
                        break;
                    }
                case 1:
                    {
                        rpDiemDanhHocVien();
                        break;
                    }
                case 2:
                    {
                        if (lookMonHoc.ItemIndex < 0)
                        {
                            MessageBox.Show("Phải chọn môn học!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            rpKetQuaHocTap();
                        }
                        break;
                    }
                case 3:
                    {
                        if (radCapQ.SelectedIndex == 1 || radCapQ.SelectedIndex == 2)
                        {
                            lookUpSoHieuDoi.Refresh();
                            rpDsHocVienDuocCapGCNDoi();
                        }
                        else
                        {
                            rpDsHvDuocCapGCN();
                        }
                        //radCapQ.SelectedIndex = -1;
                        break;
                    }
                case 4:
                    {
                        if (radCapQ.SelectedIndex == 1 || radCapQ.SelectedIndex == 2)
                        {
                            lookUpSoHieuDoi.Refresh();
                            rpSoTheoDoiCapGCNDoi();
                        }
                        else
                        {
                            rpSoTheoDoiCapGCN();
                        }
                        //radCapQ.SelectedIndex = -1;
                        break;
                    }
            }
        }
        private void rpDanhSachHocVien()
        {
            rpDanhSachHocVien _rpDanhSachHocVien = new rpDanhSachHocVien();
            _rpDanhSachHocVien.SetDataSource(vDsDanhSachHocVien());
            //_rpDanhSachHocVien.SetParameterValue("parLopName", vLopName);
            inBieuMauViewer.ReportSource = _rpDanhSachHocVien;
            inBieuMauViewer.ToolPanelView = ToolPanelViewType.None;
            inBieuMauViewer.RefreshReport();
        }
        private void rpDiemDanhHocVien()
        {
            rpDiemDanhHocVien _rpDiemDanhHocVien = new rpDiemDanhHocVien();
            _rpDiemDanhHocVien.SetDataSource(vDsDiemDanhHocVien());
            inBieuMauViewer.ReportSource = _rpDiemDanhHocVien;
            inBieuMauViewer.ToolPanelView = ToolPanelViewType.None;
            inBieuMauViewer.RefreshReport();
        }
        private void rpKetQuaHocTap()
        {
            rpKetQuaHocTap _rpKetQuaHocTap = new rpKetQuaHocTap();
            _rpKetQuaHocTap.SetDataSource(vDsKetQuaHocTap());
            inBieuMauViewer.ReportSource = _rpKetQuaHocTap;
            inBieuMauViewer.ToolPanelView = ToolPanelViewType.None;
            inBieuMauViewer.RefreshReport();
        }
        private void rpDsHvDuocCapGCN()
        {
            rpDsHocVienDuocCapGCN _rpDsHcDuocCapGCN = new rpDsHocVienDuocCapGCN();
            _rpDsHcDuocCapGCN.SetDataSource(vDsDanhSachHocVienCapGCN());
            inBieuMauViewer.ReportSource = _rpDsHcDuocCapGCN;
            inBieuMauViewer.ToolPanelView = ToolPanelViewType.None;
            inBieuMauViewer.RefreshReport();
        }
        private void rpDsHocVienDuocCapGCNDoi()
        {
            rpDsHvDuocCapGCNDoi _rpDsHcDuocCapGCNDoi = new rpDsHvDuocCapGCNDoi();
            _rpDsHcDuocCapGCNDoi.SetDataSource(vDsSanhSachHocVienCapGCNDoi());
            inBieuMauViewer.ReportSource = _rpDsHcDuocCapGCNDoi;
            inBieuMauViewer.ToolPanelView = ToolPanelViewType.None;
            inBieuMauViewer.RefreshReport();
        }
        private void rpSoTheoDoiCapGCN()
        {
            rpSoTheoDoiCapGCN _rpSoTheoDoiCapGCN = new rpSoTheoDoiCapGCN();
            _rpSoTheoDoiCapGCN.SetDataSource(vDsSoTheoDoiCapGCN());
            inBieuMauViewer.ReportSource = _rpSoTheoDoiCapGCN;
            inBieuMauViewer.ToolPanelView = ToolPanelViewType.None;
            inBieuMauViewer.RefreshReport();
        }
        private void rpSoTheoDoiCapGCNDoi()
        {
            rpSoTheoDoiCapGCN _rpSoTheoDoiCapGCNDoi = new rpSoTheoDoiCapGCN();
            _rpSoTheoDoiCapGCNDoi.SetDataSource(vDsSoTheoDoiCapGCNDoi());
            inBieuMauViewer.ReportSource = _rpSoTheoDoiCapGCNDoi;
            inBieuMauViewer.ToolPanelView = ToolPanelViewType.None;
            inBieuMauViewer.RefreshReport();
        }
        private DataSet vDsDanhSachHocVien()
        {
            tb = new DataTable();
            boHv = new BO_HOCVIEN();
            vDsBieuMau = new DsInBieuMau();
            int i;
            tb = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));
            if (tb.Rows.Count > 0)
            {
                for (i = 0; i < tb.Rows.Count; i++)
                {
                    vRow = vDsBieuMau.DanhSachHocVien.NewRow();
                    vRow["STT"] = i + 1;
                    vRow["HOV_FirstName"] = tb.Rows[i]["HOV_FirstName"].ToString();
                    vRow["HOV_LastName"] = tb.Rows[i]["HOV_LastName"].ToString();
                    vRow["HOV_BirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    vRow["TIN_Name"] = tb.Rows[i]["TIN_Name"].ToString();
                    vRow["HOV_Phone"] = tb.Rows[i]["HOV_Phone"].ToString();
                    vRow["HOV_ChucDanh"] = tb.Rows[i]["HOV_ChucDanh"].ToString();
                    vRow["DON_Name"] = tb.Rows[i]["DON_Name"].ToString();
                    vRow["DKH_BienLai"] = tb.Rows[i]["DKH_BienLai"].ToString();
                    vRow["HOV_GhiChu"] = tb.Rows[i]["HOV_GhiChu"].ToString();
                    vRow["vLopName"] = lookLop_InGCN.GetColumnValue("LOP_Name").ToString();
                    vDsBieuMau.DanhSachHocVien.Rows.Add(vRow);
                }
            }
            return vDsBieuMau;
        }
        private DataSet vDsDiemDanhHocVien()
        {
            tb = new DataTable();
            boHv = new BO_HOCVIEN();
            vDsBieuMau = new DsInBieuMau();
            tb = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    vRow = vDsBieuMau.DiemDanhHocVien.NewRow();
                    vRow["STT"] = i + 1;
                    vRow["HOV_FirstName"] = tb.Rows[i]["HOV_FirstName"].ToString();
                    vRow["HOV_LastName"] = tb.Rows[i]["HOV_LastName"].ToString();
                    vRow["HOV_BirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    vRow["vLopName"] = lookLop_InGCN.GetColumnValue("LOP_Name").ToString();
                    vRow["vMonName"] = lookMonHoc.GetColumnValue("MON_Name").ToString();
                    vDsBieuMau.DiemDanhHocVien.Rows.Add(vRow);
                }
            }
            return vDsBieuMau;
        }
        private DataSet vDsKetQuaHocTap()
        {
            tb = new DataTable();
            boHv = new BO_HOCVIEN();
            vDsBieuMau = new DsInBieuMau();
            int vLopID = int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString());
            int vMonID = int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString());
            int vLanThi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
            tb = boHv.ExportExcel_DiemThi(vLopID, vMonID, vLanThi);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    vRow = vDsBieuMau.DiemDanhHocVien.NewRow();
                    vRow["STT"] = i + 1;
                    vRow["HOV_FirstName"] = tb.Rows[i]["HOV_FirstName"].ToString();
                    vRow["HOV_LastName"] = tb.Rows[i]["HOV_LastName"].ToString();
                    vRow["HOV_BirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    vRow["TIN_Name"] = tb.Rows[i]["TIN_Name"].ToString();
                    vRow["vLopName"] = lookLop_InGCN.GetColumnValue("LOP_Name").ToString();
                    vRow["vMonName"] = lookMonHoc.GetColumnValue("MON_Name").ToString();
                    vDsBieuMau.DiemDanhHocVien.Rows.Add(vRow);
                }
            }
            return vDsBieuMau;
        }
        private DataSet vDsDanhSachHocVienCapGCN()
        {
            tb = new DataTable();
            boCcc = new BO_CAP_CHUNGCHI();
            vDsBieuMau = new DsInBieuMau();
            object vDateCapChungChi;
            int vChungChiID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
            int vLopID = int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString());
            tb = boCcc.ExportExcel_DsHV_DuocCapCC(vChungChiID, vLopID);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    vRow = vDsBieuMau.DsHvDuocCapGCN.NewRow();
                    vRow["STT"] = i + 1;
                    vRow["HOV_FirstName"] = tb.Rows[i]["HOV_FirstName"].ToString();
                    vRow["HOV_LastName"] = tb.Rows[i]["HOV_LastName"].ToString();
                    vRow["HOV_BirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    vRow["TIN_Name"] = tb.Rows[i]["TIN_Name"].ToString();
                    vRow["DON_Name"] = tb.Rows[i]["DON_Name"].ToString();
                    vRow["CCC_SoCC"] = tb.Rows[i]["CCC_SoCC"].ToString();
                    vDateCapChungChi = DateTime.Parse(tb.Rows[i]["CCC_NgayCap"].ToString());
                    vRow["CCC_NgayCap"] = string.Format("{0:dd/MM/yyyy}", vDateCapChungChi).ToString().Substring(0, 10);
                    vRow["vLopName"] = lookLop_InGCN.GetColumnValue("LOP_Name").ToString();
                    vDsBieuMau.DsHvDuocCapGCN.Rows.Add(vRow);
                }
            }
            return vDsBieuMau;
        }
        private DataSet vDsSanhSachHocVienCapGCNDoi()
        {
            tb = new DataTable();
            boCcc = new BO_CAP_CHUNGCHI();
            vDsBieuMau = new DsInBieuMau();
            object vDateCapChungChi;
            int vChungChiID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
            int sCap = -1;
            if (radCapQ.SelectedIndex == 1)
            {
                sCap = 2;
            }
            else
                if (radCapQ.SelectedIndex == 2)
            {
                sCap = 3;
            }
            tb = boCcc.ExportExcel_DsHV_DuocCapCC_Doi(vChungChiID, sCap, lookUpSoHieuDoi.Text);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    vRow = vDsBieuMau.DsHvDuocCapGCN.NewRow();
                    vRow["STT"] = i + 1;
                    vRow["HOV_FirstName"] = tb.Rows[i]["HOV_FirstName"].ToString();
                    vRow["HOV_LastName"] = tb.Rows[i]["HOV_LastName"].ToString();
                    vRow["HOV_BirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    vRow["TIN_Name"] = tb.Rows[i]["TIN_Name"].ToString();
                    vRow["DON_Name"] = tb.Rows[i]["DON_Name"].ToString();
                    vRow["CCC_SoCC"] = tb.Rows[i]["CCC_SoCC"].ToString();
                    vDateCapChungChi = DateTime.Parse(tb.Rows[i]["CCC_NgayCap"].ToString());
                    vRow["CCC_NgayCap"] = string.Format("{0:dd/MM/yyyy}", vDateCapChungChi).ToString().Substring(0, 10);
                    vRow["vLopName"] = lookKhoaHoc_InGCN.GetColumnValue("CHC_Name").ToString();
                    vDsBieuMau.DsHvDuocCapGCN.Rows.Add(vRow);
                }
            }
            return vDsBieuMau;
        }
        private DataSet vDsSoTheoDoiCapGCN()
        {
            tb = new DataTable();
            boCcc = new BO_CAP_CHUNGCHI();
            vDsBieuMau = new DsInBieuMau();
            object vDateCapChungChi;
            int vLopID = int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString());
            int vChungChiID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
            tb = boCcc.ExportExcel_Phat_CHUNGCHI(vChungChiID, vLopID);
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    vRow = vDsBieuMau.SoTheoDoiCapGCN.NewRow();
                    vRow["STT"] = i + 1;
                    //vRow["HOV_FirstName"] = tb.Rows[i]["HOV_FirstName"].ToString();
                    vRow["HOV_FirstName"] = tb.Rows[i]["HOV_FullName"].ToString();
                    vRow["HOV_LastName"] = tb.Rows[i]["HOV_LastName"].ToString();
                    vRow["HOV_BirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    vRow["IMG_Image"] = tb.Rows[i]["IMG_Image"];
                    //vRow["DON_Name"] = tb.Rows[i]["DON_Name"].ToString();
                    vRow["CCC_SoCC"] = tb.Rows[i]["CCC_SoCC"].ToString();
                    vDateCapChungChi = DateTime.Parse(tb.Rows[i]["CCC_NgayCap"].ToString());
                    vRow["CCC_NgayCap"] = string.Format("{0:dd/MM/yyyy}", vDateCapChungChi).ToString().Substring(0, 10);
                    //int status = int.Parse(tb.Rows[i]["CCC_Status"].ToString());
                    //if (status == 1)
                    //{
                    //    vRow["CCC_Status"] = "Cấp mới";// "Khóa " + tb.Rows[i]["LOP_Khoa"].ToString();
                    //}
                    //else if (status == 2)
                    //{
                    //    vRow["CCC_Status"] = " Gia hạn";
                    //}
                    //else if (status == 3)
                    //{
                    //    vRow["CCC_Status"] = " Đổi";
                    //}
                    vRow["CCC_Status"] = "Cấp mới";
                    vRow["vChungChiName"] = lookKhoaHoc_InGCN.GetColumnValue("CHC_Name").ToString()+ " - Khóa: " + tb.Rows[i]["LOP_Khoa"].ToString(); ;
                    vDsBieuMau.SoTheoDoiCapGCN.Rows.Add(vRow);
                }
            }
            return vDsBieuMau;
        }
        private DataSet vDsSoTheoDoiCapGCNDoi()
        {
            tb = new DataTable();
            boCcc = new BO_CAP_CHUNGCHI();
            vDsBieuMau = new DsInBieuMau();
            object vDateCapChungChi;
            string vSoHieuDoi = lookUpSoHieuDoi.Text;
            int vChungChiID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
            int sCap = -1;
            if (radCapQ.SelectedIndex == 1)
            {
                sCap = 2;
            }
            else if (radCapQ.SelectedIndex == 2)
            {
                sCap = 3;
            }
            tb = boCcc.ExportExcel_Phat_Doi_CHUNGCHI(vChungChiID, sCap, vSoHieuDoi); 
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    vRow = vDsBieuMau.SoTheoDoiCapGCN.NewRow();
                    vRow["STT"] = i + 1;
                    vRow["HOV_FirstName"] = tb.Rows[i]["HOV_FullName"].ToString();
                    vRow["HOV_LastName"] = tb.Rows[i]["HOV_LastName"].ToString();
                    vRow["HOV_BirthDay"] = tb.Rows[i]["HOV_BirthDay"].ToString();
                    vRow["IMG_Image"] = tb.Rows[i]["IMG_Image"];
                    vRow["CCC_SoCC"] = tb.Rows[i]["CCC_SoCC"].ToString();
                    vDateCapChungChi = DateTime.Parse(tb.Rows[i]["CCC_NgayCap"].ToString());
                    vRow["CCC_NgayCap"] = string.Format("{0:dd/MM/yyyy}", vDateCapChungChi).ToString().Substring(0, 10);
                    int status = int.Parse(tb.Rows[i]["CCC_Status"].ToString());
                    if (status == 2)
                    {
                        vRow["CCC_Status"] = " Gia hạn";
                        vSoHieuDoi = "Số hiệu gia hạn: "+ vSoHieuDoi;
                    }
                    else if (status == 3)
                    {
                        vRow["CCC_Status"] = " Đổi";
                        vSoHieuDoi = "Số hiệu đổi: " + vSoHieuDoi;
                    }
                    //if (status == 1)
                    //{
                    //    vRow["CCC_Status"] = "Khóa " + tb.Rows[i]["LOP_Khoa"].ToString();
                    //}
                    //else if (status == 2)
                    //{
                    //    vRow["CCC_Status"] = " Gia hạn";
                    //}
                    //else if (status == 3)
                    //{
                    //    vRow["CCC_Status"] = " Đổi";
                    //}
                    vRow["vChungChiName"] = lookKhoaHoc_InGCN.GetColumnValue("CHC_Name").ToString()+" - "+ vSoHieuDoi;
                    vDsBieuMau.SoTheoDoiCapGCN.Rows.Add(vRow);
                }
            }
            return vDsBieuMau;
        }

        private void lookUpSoHieuDoi_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpSoHieuDoi.ItemIndex>-1)
            {
                if (lookUpSoHieuDoi.ItemIndex > -1)
                {
                    btnPrint.Enabled = true;
                }
                else
                {
                    btnPrint.Enabled = false;
                }
            }
        }
    }
}
