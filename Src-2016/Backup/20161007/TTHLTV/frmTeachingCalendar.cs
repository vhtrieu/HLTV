using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using TTHLTV.BAL;
using TTHLTV.Utilities;
namespace TTHLTV
{
    public partial class frmLichGiang : DevExpress.XtraEditors.XtraForm
    {
        BO_MON_LOP boMonLop = new BO_MON_LOP();
        BO_GIANGVIEN boGvien = new BO_GIANGVIEN();
        BO_DANG_KI_HOC dao_dangki_hoc = new BO_DANG_KI_HOC();
        public frmLichGiang()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set font to extraGrid
        /// </summary>
        /// <param name="baseView"></param>
        /// <param name="sFont"></param>
        private void SetGridFont(DevExpress.XtraGrid.Views.Base.BaseView baseView, Font sFont)
        {
            foreach (AppearanceObject ap in baseView.Appearance)
            {
                ap.Font = sFont;
            }

        }

        private void frmTeachingCalendar_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridLicHoc.MainView, new Font("Tahoma", 11));
            loadKhoaHoc();
            loadGiangVien();
            loadLichHoc();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadDuration()
        {
            int LOP_ID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            BAL.BO_LOP dao_lop = new BO_LOP();
            DataRow row = dao_lop.getLOP_ByID(LOP_ID).Rows[0];// search by ID, so there is only one row
            txtFromDate.Text = Convert.ToDateTime(row["LOP_Ngay_KG"].ToString()).ToShortDateString();
            txtEndDate.Text = Convert.ToDateTime(row["LOP_Ngay_KT"].ToString()).ToShortDateString();

        }

        #region Load lookup chung chi
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

        #endregion
        #region Load lookup lop hoc
        private DataTable getLopHoc(int lookCcID_selected_index)
        {
            BAL.BO_LOP bal = new BO_LOP();
            //return bal.getLop_Alls();
            return bal.getLOP_ByCcID(lookCcID_selected_index);
        }
        private void loadLopHoc(int lookCcID_selected_index)
        {
            lookLopHoc.Properties.DataSource = getLopHoc(lookCcID_selected_index);
            lookLopHoc.Properties.ValueMember = "LOP_ID";
            lookLopHoc.Properties.DisplayMember = "LOP_Name";
            //lookLopHoc.ItemIndex = 0;
        }
        #endregion
        private void sLoadMonHoc()
        {
            lookMonHoc.Properties.DataSource = dao_dangki_hoc.getSubjectName(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            lookMonHoc.Properties.ValueMember = "MON_ID";
            lookMonHoc.Properties.DisplayMember = "MON_Name";
        }
        private void loadGiangVien()
        {
            DataTable tb = new DataTable();
            tb = boGvien.getGianngVien_All();
            lookGiangVien.Properties.DataSource = tb;
            lookGiangVien.Properties.ValueMember = "GIV_ID";
            lookGiangVien.Properties.DisplayMember = "GIV_Name";
 
        }
        private void loadDataToGrid()
        {
            gridLicHoc.DataSource = getData();
          
        }

        private DataTable getData()
        {
            DataTable tabel = new DataTable();
            int sMonID = int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString());
            int sLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            //tabel = boMonLop.Get_Lop_GiangVien(sLopID, sMonID);
            return tabel;
        }

        private void lookChungChi_EditValueChanged(object sender, EventArgs e)
        {
            if (lookChungChi.ItemIndex > -1)
            {
                loadLopHoc(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
                sLoadMonHoc();
            }
        }

        private void lookLopHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (lookLopHoc.ItemIndex > -1)
            {
                loadDuration();
                LoadLichHoc_ByLopId(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
                lookMonHoc.Enabled = true;
                
            }
        }

        private void lookMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            //sLoadLanThi();
            loadDataToGrid();
            btnSave.Enabled = true;
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            // Update Ma Giang vien va So tiet vao table MON_LOP
            UpdateLop_MonHoc();
        }
        private void UpdateLop_MonHoc()
        {
            int LopId = -1;
            int MonId = -1;
            int GiangVienID = -1;
            int SoTiet = -1;

            LopId = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            MonId = int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString());
            GiangVienID = int.Parse(lookGiangVien.GetColumnValue("GIV_ID").ToString());
           // SoTiet = int.Parse(txtSoTiet.ToString());
           boMonLop.update_By_LopId_MonId(LopId, MonId, GiangVienID);
        }

        private void loadLichHoc()
        {
            DataTable tbLichHoc = new DataTable();
            gridLicHoc.DataSource = boMonLop.Select_LichGiang_All();
        }

        private void LoadLichHoc_ByLopId(int lopId)
        {
            gridLicHoc.DataSource = boMonLop.Select_LichGiang_ByLopId(lopId);
        }
    }
}