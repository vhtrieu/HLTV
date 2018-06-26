using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
namespace TTHLTV
{
    public partial class frmPrintCertificate : DevExpress.XtraEditors.XtraForm
    {

        BAL.BO_CHUNG_CHI boCc = new BO_CHUNG_CHI();
        BAL.BO_CAP_CHUNGCHI boCcs = new BO_CAP_CHUNGCHI();
        BAL.BO_LOP boLop = new BO_LOP();
        BO_MONHOC boMonHoc = new BO_MONHOC();
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        BO_DIEM boDiem = new BO_DIEM();
        private int mChungChiID = -1;
        private int mLanThi = -1;
        private int vStatic = -1;
        private int mLopHocID = -1;
        private string mSoHieuDoi = string.Empty;
        private int mCheckDoi = 1;
        private int mRadioIndex = 1;
        public frmPrintCertificate()
        {
            InitializeComponent();
        }

        #region Event
        private void lookChungChi_EditValueChanged(object sender, EventArgs e)
        {
            if (radCapQ.SelectedIndex == 0)
            {
                sLoadKhoaHoc();
            }
            else if (radCapQ.SelectedIndex == 1)
            {
                LoadSoHieuDoi();
            }

        }
        private void frmPrintCertificate_Load(object sender, EventArgs e)
        {
            lookUpSoHieuDoi.Visible = false;
            lookLopHoc.Visible = true;
            sLoadLop();
            Utilities.setFontSize.SetGridFont(gridCertificate.MainView, new Font("Tahoma", 11));
        }
        private void lookLopHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (lookLopHoc.ItemIndex > -1)
            {
                sLoadLanThi();
                loadDuration();
                showLopDaCapCC();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnInGCN_Click(object sender, EventArgs e)
        {
            Report.frmPrintView frm = new Report.frmPrintView();
            frm.mChungChiId = mChungChiID;
            frm.mLopId = mLopHocID;
            frm.mIndex = mRadioIndex;
            frm.ShowDialog();

        }
        private void rdMatIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdMatIn.SelectedIndex == 0)
            {
                mRadioIndex = 1;// mat trong
            }
            else
                if (rdMatIn.SelectedIndex == 1)
            {
                mRadioIndex = 2; // mat ngoai
            }

        }
        private void lookUpSoHieuDoi_EditValueChanged(object sender, EventArgs e)
        {
            if (lookChungChi.ItemIndex > -1)
            {
                showCccDoi();
            }

        }
        private void radCapQ_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lookChungChi.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại chứng chỉ", "THÔNG BÁO");
                return;
            }
            if (radCapQ.SelectedIndex == 0)
            {
                lookUpSoHieuDoi.Visible = false;
                lookLopHoc.Visible = true;
                gridCertificate.DataSource = null;
                mCheckDoi = 1;
                sLoadKhoaHoc();
            }
            else if (radCapQ.SelectedIndex == 1)
            {
                lookUpSoHieuDoi.Visible = true;
                lookUpSoHieuDoi.ResetText();
                lookLopHoc.Visible = false;
                txtDateAllocate.Text = string.Empty;
                txtDateExpire.Text = string.Empty;
                gridCertificate.DataSource = null;
                mCheckDoi = 2;
                LoadSoHieuDoi();
                showCccDoi();
            }
            else if (radCapQ.SelectedIndex == 2)
            {
                lookUpSoHieuDoi.Visible = true;
                lookUpSoHieuDoi.ResetText();
                lookLopHoc.Visible = false;
                txtDateAllocate.Text = string.Empty;
                txtDateExpire.Text = string.Empty;
                gridCertificate.DataSource = null;
                mCheckDoi = 3;
                LoadSoHieuDoi();
                showCccDoi();
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            Report.frmPrintView frm = new Report.frmPrintView();
            frm.mChungChiStatic = vStatic;
            frm.mLopId = mLopHocID;
            frm.mLanThi = mLanThi;
            frm.mSoHieuDoi = mSoHieuDoi;
            frm.mCheckDoi = mCheckDoi;
            frm.mIndex = mRadioIndex;
            frm.mChungChiId = mChungChiID;
            if (radCapQ.SelectedIndex == 1)
            {
                frm.StatustDoi = 2;
            }
            else if (radCapQ.SelectedIndex == 2)
            {
                frm.StatustDoi = 3;
            }
            frm.ShowDialog();

        }
        private void lookLanThi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                showLopDaCapCC();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Extenal function

        private void sLoadLop()
        {
            lookChungChi.Properties.DataSource = getKhoaHoc();
            lookChungChi.Properties.ValueMember = "CHC_ID";
            lookChungChi.Properties.DisplayMember = "CHC_Name";
        }

        #region Load lookup chung chi
        private DataTable getKhoaHoc()
        {

            return boCc.getChungChi_All();
        }

        #endregion
        #region Load lookup lop hoc
        private void sLoadKhoaHoc()
        {
            DataTable vtable = new DataTable();
            mChungChiID = int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString());
            vtable = boLop.getLOP_ByCcID(mChungChiID);
            if (vtable.Rows.Count > 0)
            {
                vStatic = int.Parse(vtable.Rows[0]["CHC_Static"].ToString());
                lookLopHoc.Properties.DataSource = vtable;
                lookLopHoc.Properties.ValueMember = "LOP_ID";
                lookLopHoc.Properties.DisplayMember = "LOP_Name";
            }
            else
                lookLopHoc.Properties.DataSource = null;
        }
        private void LoadSoHieuDoi()
        {
            if (lookChungChi.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn chứng chỉ", "THÔNG BÁO");
                return;
            }
            else
            {

                lookUpSoHieuDoi.Properties.DataSource = getSoHieuDoi();
                lookUpSoHieuDoi.Properties.ValueMember = "CCC_SoHieuDoi";
                lookUpSoHieuDoi.Properties.DisplayMember = "CCC_SoHieuDoi";
            }
        }
        private DataTable getLopHoc()
        {
            //return bal.getLop_Alls();
            mChungChiID = int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString());
            return boLop.getLOP_ByCcID(mChungChiID);

        }
        private DataTable getSoHieuDoi()
        {

            mChungChiID = int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString());
            int status = -1;
            if (radCapQ.SelectedIndex == 1)
            {
                status = 2;
            }
            else if (radCapQ.SelectedIndex == 2)
            {
                status = 3;
            }

            return boCcs.get_SoHieuDoi_Cc(mChungChiID, status);


        }
        #endregion
        private void sLoadLanThi()
        {
            DataTable vtb = new DataTable();
            vtb = boDiem.LanThi_generalMark(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            if (vtb.Rows.Count > 0)
            {
                lookLanThi.Properties.DataSource = vtb;
                lookLanThi.Properties.ValueMember = "DIE_LanThi";
                lookLanThi.Properties.DisplayMember = "DIE_LanThi";
                lookLanThi.ItemIndex = 0;
            }
            else
            {
                MessageBox.Show("Lớp này chưa nhập điểm", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookLanThi.ItemIndex = -1;
                return;
            }

        }
        private void loadDuration()
        {
            int LOP_ID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());

            DataRow row = boLop.getLOP_ByID(LOP_ID).Rows[0];// search by ID, so there is only one row
            DateTime DateAllocate = Convert.ToDateTime(row["LOP_Ngay_KG"].ToString());
            DateTime DateExpire = Convert.ToDateTime(row["LOP_Ngay_KT"].ToString());
            txtDateAllocate.Text = DateAllocate.ToString("dd/MM/yyyy");
            txtDateExpire.Text = DateExpire.ToString("dd/MM/yyyy");
            txtDateAllocate.BackColor = Color.White;
            txtDateExpire.BackColor = Color.White;
        }
        private void showLopDaCapCC()
        {
            gridContentCertificate.Columns.Clear();
            if (lookLanThi.ItemIndex < 0)
            {
                return;
            }
            gridCertificate.DataSource = getLopDaCapCC();

            gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            gridContentCertificate.Columns["CCC_LOPID"].VisibleIndex = -1;
            gridContentCertificate.Columns["CCC_ID"].VisibleIndex = -1;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatString = "dd/MM/yyyy";
            gridContentCertificate.Columns["Ngày cấp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridContentCertificate.Columns["Ngày cấp"].DisplayFormat.FormatString = "dd/MM/yyyy";
        }
        private void showCccDoi()
        {
            gridContentCertificate.Columns.Clear();
            if (lookUpSoHieuDoi.ItemIndex > -1)
            {
                mSoHieuDoi = lookUpSoHieuDoi.GetColumnValue("CCC_SoHieuDoi").ToString();
            }
            else
            {
                MessageBox.Show("Chưa chọn số hiệu đổi", "THÔNG BÁO");
                return;
            }
            gridCertificate.DataSource = getCapCcDoi();
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatString = "dd/MM/yyyy";
            gridContentCertificate.Columns["Ngày cấp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridContentCertificate.Columns["Ngày cấp"].DisplayFormat.FormatString = "dd/MM/yyyy";
        }
        private DataTable getLopDaCapCC()
        {
            int vLanThi = -1;

            vLanThi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
            mLanThi = vLanThi;
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
            dsHvDaCapCC.Columns.Add("CCC_ID", typeof(int));
            dsHvDaCapCC.Columns.Add("Số CC", typeof(string));
            dsHvDaCapCC.Columns.Add("Ngày cấp", typeof(DateTime));
            dsHvDaCapCC.Columns.Add("CCC_LOPID", typeof(int));
            DataTable tbs = new DataTable();
            mLopHocID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            tbs = boDkh.getDangKiHoc_Name_ByLopID(mLopHocID, vLanThi);

            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = dsHvDaCapCC.NewRow();
                if (int.Parse(lookChungChi.EditValue.ToString()) == 1 && dsHvDaCapCC.Columns.Count > tbs.Columns.Count)
                {
                    newRow["HvID"] = dr["DAC_HOVID"];
                    newRow["Họ"] = dr["DAC_HOVFIRSTNAME"];
                    newRow["Tên"] = dr["DAC_HOVLASTNAME"];
                    newRow["Ngày sinh"] = dr["DAC_HOVBIRTHDAY"];
                    newRow[4] = dr[4];
                    newRow[5] = dr[5];
                    newRow[6] = dr[6];
                    newRow[7] = dr[7];
                    newRow[8] = dr[8];
                    newRow[9] = dr[9];
                    newRow[10] = string.Empty;
                    newRow["CCC_ID"] = dr["DAC_ID"];
                    newRow["Số CC"] = dr["DAC_CCCSoCC"];
                    newRow["Ngày cấp"] = dr["DAC_CCCNgayCap"];
                    newRow["CCC_LOPID"] = dr["DAC_LOPID"];
                }
                else
                    newRow.ItemArray = dr.ItemArray;
                dsHvDaCapCC.Rows.Add(newRow);
            }
            return dsHvDaCapCC;

        }
        private DataTable getCapCcDoi()
        {
            DataTable cCMhTable = new DataTable();
            DataTable dsHvDaCapCC = new DataTable("dsHvDaCapCC");
            DataColumn column = new DataColumn();
            //dsHvDaCapCC.Columns.Add("HvID", typeof(int));
            dsHvDaCapCC.Columns.Add("Họ", typeof(string));
            dsHvDaCapCC.Columns.Add("Tên", typeof(string));
            dsHvDaCapCC.Columns.Add("Ngày sinh", typeof(string));
            dsHvDaCapCC.Columns.Add("Số CC", typeof(string));
            dsHvDaCapCC.Columns.Add("Ngày cấp", typeof(DateTime));
            //dsHvDaCapCC.Columns.Add("CCC_LOPID", typeof(int));
            DataTable tbs = new DataTable();
            //tbs = boDkh.getDangKiHoc_Name_ByLopID(mLopHocID);
            int status = -1;
            if (radCapQ.SelectedIndex == 1)
            {
                status = 2;
            }
            else if (radCapQ.SelectedIndex == 2)
            {
                status = 3;
            }
            tbs = boCcs.get_CccDoi(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()), status, mSoHieuDoi);
            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = dsHvDaCapCC.NewRow();
                newRow.ItemArray = dr.ItemArray;
                dsHvDaCapCC.Rows.Add(newRow);
            }
            return dsHvDaCapCC;

        }
        #endregion












    }
}