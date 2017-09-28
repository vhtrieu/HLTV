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
using TTHLTV.DAL;
using System.IO;
namespace TTHLTV
{
    public partial class frmChangeCerificate : DevExpress.XtraEditors.XtraForm
    {
        #region variable
        BO_HOCVIEN boHv = new BO_HOCVIEN();
        HOCVIEN hocvien;
        BO_CAP_CHUNGCHI boCcc;
        BO_DIEM boDiem = new BO_DIEM();
        BO_DOI_CHUNGCHI boDoiCc;
        DOI_CHUNGCHI dtoDoiCC;
        CAP_CHUNGCHI dtoCapCc;
        private const int id = -1;
        private int mHvStatust;
        private int mDoiStatust;
        int gIDHocVien = -1;
        bool flagSaveHocVien = false;
        bool flagSaveDoi = false;
        int vDoiCcID = -1;// For update;
        private string mSoCc = string.Empty;
        int sAge = 0;
        private SimpleButton mStatusSave;
        private SimpleButton mSaveSender;
        private DateTime mNgayKG = DateTime.Now;
        private DateTime mNgayKT = DateTime.Now;
        private DateTime mNgayQD = DateTime.Now;
        private DateTime mNgayCapMoi = DateTime.Now;
        private DateTime? mNgayCapCu = DateTime.Now;
        private GridCheckMarksSelection sselection;
        private int mCccID = -1;
        static DataTable hvTable = new DataTable();
        private DataTable mTableChungChiDoi = new DataTable();
        string sSoHieu = string.Empty;
        public bool vFlagSave = false;
        private Image Img;
        bool vFlagSaveImg = false;
        HOCVIEN_IMG DtoImg;
        BO_HOCVIEN_IMG BoImg;
        private int ImgID;
        byte[] imgArray;
        string vImgFileName;
        private bool ExistImg = false;
        DataTable tblLevel;
        private int LevelID;
        BO_LOP boLop;
        #endregion
        public frmChangeCerificate()
        {
            InitializeComponent();
        }
        #region Events
        private void frmChangeCerificate_Load(object sender, EventArgs e)
        {
            sCheckEnable(1);
            sLoadChucDanh();
            sLoadDonVi();
            sLoadTinh();
            // checkDate();
            sGeneralCodeDangKiHocVien(); // Khoi tao code cho table DANG_KI_HOC
            sSearchTool();
            loadKhoaHoc();
            Utilities.setFontSize.SetGridFont(gridRegister.MainView, new Font("Tahoma", 11));
            Utilities.setFontSize.SetGridFont(gridStudents.MainView, new Font("Tahoma", 11));
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            radCapDoi.SelectedIndex = -1;
            loadDefaultImage();
            initLevel();
            lookLevel.Visible = false;
            lblLevel.Visible = false;
        }
        private void lookCcID_EditValueChanged(object sender, EventArgs e)
        {
            if (lookCcID.ItemIndex > -1)
            {
                gridRegister.DataSource = null;
                generalSoHieu();
                // loadDataToGrid();
                sCounter();
                txtSohieuText.Focus();
                getSoHieuByCHCID();
                txtSoCcCu.Enabled = true;
                if (int.Parse(lookCcID.EditValue.ToString()) == 23)
                {
                    lookLevel.Visible = true;
                    lblLevel.Visible = true;
                }
                else
                {
                    lookLevel.Visible = false;
                    lblLevel.Visible = false;
                }
            }
        }
        private void LoadSoCC()
        {
            boCcc = new BO_CAP_CHUNGCHI();
            DataTable lastSoCc = new DataTable();
            int ChungChi_ID = -1;
            if (lookCcID.ItemIndex > -1)
            {
                ChungChi_ID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
            }
            lastSoCc = boCcc.getLast_SoCc(ChungChi_ID);
            if (lastSoCc.Rows.Count <= 0)
            {
                txtSoCC_Cuoi.Text = " 00000";
                return;
            }
            else
            {
                txtSoCC_Cuoi.Text = lastSoCc.Rows[0]["SoCc"].ToString();
                string[] ss = txtSoCC_Cuoi.Text.Split(' ');
                string msSoCc = ss[0].ToString();
                txtSoCC_Cuoi.Text = msSoCc;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SimpleButton statusInsert = (SimpleButton)sender;
            mStatusSave = statusInsert;
            sCheckEnable(2);
            clearInputData(1);
            txtFirstName.Focus();
            sGeneralCodeHocVien();// Khoi tao code cho hoc vien moi.
            sGeneralCodeDangKiHocVien();  // Khoi tao code cho table DANG_KI_HOC
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            SimpleButton sBtn = (SimpleButton)sender;
            if (sBtn.Text == "Thêm mới")
            {
                lookUpBirthPlace.ClosePopup();
                lookUpBirthPlace.EditValue = null;
                //lookUpChucDanh.ClosePopup();
                //lookUpChucDanh.EditValue = null;
                lookUpDonvi.ClosePopup();
                lookUpDonvi.EditValue = null;
                return;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = grvRegisterContent.GetDataRow(grvRegisterContent.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa học viên này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // int lopId = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
                    int hvId = int.Parse(selectedRow["HOV_ID"].ToString());
                    int cCcID = int.Parse(selectedRow["CCC_ID"].ToString());
                    int zDoiID = int.Parse(selectedRow["DOI_ID"].ToString());
                    selectedRow.Delete();
                    // 1. Delete in DOI_CHUNG_CHI Table
                    //boDoiCc.delete_Doi_CC_byHvID(hvId, txtSoCcCu.Text+" "+ txtSoCcText.Text); //2014-15-7
                    dtoDoiCC = new DOI_CHUNGCHI();
                    dtoDoiCC.DOI_ID = zDoiID;
                    boDoiCc.deleteDoiChungChiByID(dtoDoiCC);
                    //2. Delete in CAP_CHUNG_CHI table.
                    //boDoiCc.delete_CAP_CC_Doi_byHvID(cCcID, hvId, txtSoCcCu.Text + " " + txtSoCcText.Text);
                    dtoCapCc = new CAP_CHUNGCHI();
                    dtoCapCc.CCC_ID = cCcID;
                    boDoiCc.DeleteHocVienCapChungChiDoiByID(dtoCapCc);
                    clearInputData(1);
                    //loadDataToGrid();
                    GetDataBySoHieuDoi();
                    lookUpBirthPlace.ClosePopup();
                    lookUpDonvi.ClosePopup();
                    lookUpBirthPlace.EditValue = null;
                    //lookUpChucDanh.EditValue = null;
                    //lookUpChucDanh.ClosePopup();
                    lookUpDonvi.EditValue = null;
                    txtSoBienLai.BackColor = Color.White;
                    sResultSearchByFirstName();
                    txtFirstName.Enabled = false;
                    txtLastName.Enabled = false;
                    sCounter();
                    LoadSoCC();
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SimpleButton statustUpdate = (SimpleButton)sender;
            mStatusSave = statustUpdate;
            sCheckEnable(2);
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            object sdate = txtBirthDay.EditValue;
            SimpleButton sBtn = (SimpleButton)sender;
            mSaveSender = sBtn;
            if (checkControl() == false)
            {
                return;
            }
            if (int.Parse(lookCcID.EditValue.ToString())==23)
            {
                if (lookLevel.ItemIndex<0)
                {
                    MessageBox.Show("Chưa chọn cấp độ.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Phải thêm một điều kiện check HOV_ID ở đây 2012.08.27 checkFullName()==false && 
            if (mStatusSave.Text == "Thêm mới")
            {
                if (checkSoChungChi() == false) //Kiểm tra số chứng chỉ đã nhập trong loại chứng chỉ đào tạo đã được cấp chưa?
                {
                    MessageBox.Show("Số chứng chỉ này đã được nhập!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoCcCu.Focus();
                    txtSoCcCu.SelectAll();
                    return;
                }
                if (checkFullName() && int.Parse(txtStudentCode.Text.Substring(3, 5).ToString()) == mHvStatust + 1)
                {
                    if (vSaveStudents(1))
                    {
                        if (vSaveChangeCerificate(1))
                        {
                            if (vSaveCapChungChi(1))
                                SaveLevel(LevelID,int.Parse(lookLevel.EditValue.ToString()), vDoiCcID);
                        }
                    }
                    else
                        return;
                }
                else
                {
                    if (vCheckHocVienDaDangKiDoi())
                    {
                        if (vSaveChangeCerificate(1)) // ID học viên được lấy khi click vào gridContentStudent
                        {
                            if(vSaveCapChungChi(1))
                                SaveLevel(LevelID, int.Parse(lookLevel.EditValue.ToString()), vDoiCcID);
                        }
                    }
                }
            }
            else if (mStatusSave.Text == "Sửa thông tin")
            {
                vSaveStudents(2);
                vSaveChangeCerificate(2);
                if(vSaveCapChungChi(2))
                    SaveLevel(LevelID, int.Parse(lookLevel.EditValue.ToString()), vDoiCcID);
            }
            if (flagSaveDoi == true && vImgFileName != null)
            {
                if (ExistImg == true)
                {
                    updateImg();
                }
                else
                    insertImg();
            }
            sGeneralCodeHocVien();
            sGeneralCodeDangKiHocVien();
            ClearControl();
            CheckRadiDonVi();
            LoadSoCC();
            GetDataBySoHieuDoi();
            loadDefaultImage();
        }

        private bool SaveLevel(object levelID, int LevelNumber, int vDoiCcID)
        {
            boLop = new BO_LOP();
            try
            {
                boLop.SaveLevel(LevelID, -1, LevelNumber, vDoiCcID);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu cấp độ: " + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputData(1);
            lookCcID.Properties.NullText = "Chọn khóa học";

            SimpleButton sBtn = (SimpleButton)sender;
            if (sBtn.Text == "Không lưu")
            {
                sCheckEnable(1);
                lookCcID.CancelPopup();
                lookCcID.EditValue = null;
                lookUpBirthPlace.CancelPopup();
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.CancelPopup();
                lookUpDonvi.EditValue = null;
                btnNew.Enabled = true;
                btnDelete.Enabled = false;
                sGeneralCodeHocVien();
                txtSohieuText.Text = string.Empty;
                txtSohieuYear.Text = string.Empty;
                txtSohieuMonth.Text = string.Empty;
                txtSohieuNumber.Text = string.Empty;
                return;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void radCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckRadiDonVi();
        }
        private void txtSearchText_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (int.Parse(lookCcID.ItemIndex.ToString()) < 0)
            {
                MessageBox.Show("Chọn khóa học, và lớp học muốn tìm kiếm học viên", "THÔNG BÁO");
                return;
            }
            else
            {
                if (txtSearchText.Text == string.Empty)
                {
                    GetDataBySoHieuDoi();
                }
                else
                    if (txtSearchText.Text != string.Empty)
                {
                    if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 1)
                    {
                        gridRegister.DataSource = boDoiCc.search_DoiCC_byLastName(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()), txtSearchText.Text, sSoHieu);
                    }
                    else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 2)
                    {
                        gridRegister.DataSource = boDoiCc.search_DoiCC_byFullName(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()), txtSearchText.Text, sSoHieu);
                    }
                }

            }
        }
        private void txtFirstName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (txtFirstName.Text == string.Empty)
            {
                sGeneralCodeHocVien();
                return;

            }
            else
            {
                sResultSearchByFirstName();
            }
        }
        private void gridContentStudents_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow currentRow = gridContentStudents.GetDataRow(e.RowHandle);
            gIDHocVien = int.Parse(currentRow["HOV_ID"].ToString());
            //txtTemHvID.Text = smIdStudents.ToString();
            txtStudentCode.Text = currentRow["HOV_Code"].ToString();
            txtFirstName.Text = currentRow["HOV_FirstName"].ToString();
            txtLastName.Text = currentRow["HOV_LastName"].ToString();
            txtBirthDay.EditValue = currentRow["HOV_BirthDay"].ToString();
            if (sLoadTinh())
            {
                if (currentRow["HOV_NoiSinh"].ToString() != string.Empty && currentRow["HOV_NoiSinh"].ToString() != " ")
                {
                    lookUpBirthPlace.EditValue = int.Parse(currentRow["HOV_NoiSinh"].ToString());
                }
            }
            if (sLoadDonVi())
            {
                if (currentRow["HOV_DonVi"].ToString() != string.Empty && currentRow["HOV_DonVi"].ToString() != " ")
                {
                    lookUpDonvi.EditValue = int.Parse(currentRow["HOV_DonVi"].ToString());
                }
            }
            txtAddress.Text = currentRow["HOV_Address"].ToString();
            txtPhone.Text = currentRow["HOV_Phone"].ToString();
            memoRemarks.Text = currentRow["HOV_GhiChu"].ToString();
            loadImage(currentRow);
            btnEdit.Enabled = false;
            btnSave.Focus();
            btnSave.Enabled = true;
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;

        }
        private void grvRegisterContent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow currentRow = grvRegisterContent.GetDataRow(e.RowHandle);
            vDoiCcID = int.Parse(currentRow["DOI_ID"].ToString());
            gIDHocVien = int.Parse(currentRow["DOI_HOVID"].ToString());
            mCccID = int.Parse(currentRow["CCC_ID"].ToString());
            txtStudentCode.Text = currentRow["HOV_Code"].ToString();
            txtFirstName.Text = currentRow["HOV_FirstName"].ToString();
            txtLastName.Text = currentRow["HOV_LastName"].ToString();
            txtBirthDay.EditValue = currentRow["HOV_BirthDay"].ToString();
            txtAddress.Text = currentRow["HOV_Address"].ToString();
            txtPhone.Text = currentRow["HOV_Phone"].ToString();
            if (sLoadTinh())
            {
                lookUpBirthPlace.EditValue = int.Parse(currentRow["HOV_NoiSinh"].ToString());
            }
            if (sLoadDonVi())
            {
                lookUpDonvi.EditValue = int.Parse(currentRow["HOV_DonVi"].ToString());
            }
            string stemp = currentRow["DOI_SoCC"].ToString();
            string[] ss = stemp.Split(' ');
            txtSoCcCu.Text = ss[0].ToString();
            memoRemarks.Text = currentRow["HOV_GhiChu"].ToString();
            txtDKHCode.Text = currentRow["DOI_Code"].ToString();
            dateNgayKG.EditValue = Convert.ToDateTime(currentRow["DOI_Ngay_KG"].ToString());
            dateNgayKT.EditValue = Convert.ToDateTime(currentRow["DOI_Ngay_KT"].ToString());
            dateNgayQD.EditValue = Convert.ToDateTime(currentRow["DOI_Ngay_QD"].ToString());
            //Load image hocvien
            loadImage(currentRow);
            LoadLevelByDoiID(vDoiCcID);

            btnEdit.Enabled = true;
            btnEdit.Focus();
            btnSave.Enabled = false;
            btnCancel.Enabled = true;
            btnDelete.Enabled = true;
            sCheckEnable(1);

        }

        private void LoadLevelByDoiID(int vDoiCcID)
        {
            boDoiCc = new BO_DOI_CHUNGCHI();
            DataTable tbl = new DataTable();
            try
            {
                tbl = boDoiCc.LoadLevelByDoiID(vDoiCcID);
                if (tbl.Rows.Count > 0)
                {
                    LevelID = int.Parse(tbl.Rows[0]["LEV_ID"].ToString());
                    lookLevel.EditValue = tbl.Rows[0]["LEV_Number"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị cấp độ: " + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void radNgayCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkDate();
        }
        private void dateNgayCapMoi_EditValueChanged(object sender, EventArgs e)
        {
            checkDate();
        }
        private void txtSoCcCu_Leave(object sender, EventArgs e)
        {
            if (txtSoCcCu.Text != "" && txtSoCcCu.Text.Length < 5)
            {
                MessageBox.Show("Phải nhập số chứng chỉ có 5 chữ số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCcCu.Focus();
            }
        }
        private void txtSohieuText_Leave(object sender, EventArgs e)
        {
            LoadSoCC();
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            int iCheckd = 0;
            btnCnNgayCap.Enabled = true;
            if (checkEdit1.Checked)
            {
                sselection = new GridCheckMarksSelection(grvRegisterContent);
                sselection.CheckMarkColumn.VisibleIndex = 0;
                sselection.CheckMarkColumn.Width = 8;
                iCheckd++;
                btnSave.Enabled = true;
            }
            else if (grvRegisterContent.RowCount > 0 && iCheckd > 0)
            {
                sselection.CheckMarkColumn.Dispose();
            }
            else if (checkEdit1.Checked == false)
            {
                sselection.CheckMarkColumn.Dispose();
            }


        }
        private void btnCnNgayCap_Click(object sender, EventArgs e)
        {
            if (dateNgayCapMoi.EditValue == null)
            {
                MessageBox.Show("Chưa nhập ngày cấp", "THÔNG BÁO");
                dateNgayCapMoi.Focus();
                return;
            }
            else
            {
                updateSoCC_NgayCap();
                loadDataToGrid();
            }

        }
        private void txtSohieuNumber_Leave(object sender, EventArgs e)
        {
            GetDataBySoHieuDoi();

        }
        private void radCapDoi_EditValueChanged(object sender, EventArgs e)
        {
            GetDataBySoHieuDoi();
        }
        private void txtLastName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (txtLastName.Text == string.Empty)
            {
                sGeneralCodeHocVien();
                return;

            }
            else
            {
                sResultSearchByFirstName();
            }

        }
        #endregion
        #region Extenal functions
        private void sCounter()
        {
            lblCount.Text = "Có " + int.Parse(grvRegisterContent.RowCount.ToString()) + " học viên đã đăng kí";
        }
        private bool sLoadTinh()
        {
            BO_TINH boTinh = new BO_TINH();
            DataTable vtb = new DataTable();
            vtb = boTinh.getTinh_All();
            if (vtb.Rows.Count > 0)
            {
                lookUpBirthPlace.Properties.DataSource = vtb.DefaultView;
                lookUpBirthPlace.Properties.ValueMember = "TIN_ID";
                lookUpBirthPlace.Properties.DisplayMember = "TIN_Name";
                return true;
            }
            else
                return false;

        }
        private bool sLoadDonVi()
        {
            BO_DONVI boDv = new BO_DONVI();
            DataTable vtb = new DataTable();
            vtb = boDv.getAll();
            if (vtb.Rows.Count > 0)
            {
                lookUpDonvi.Properties.DataSource = vtb.DefaultView;
                lookUpDonvi.Properties.ValueMember = "DON_ID";
                lookUpDonvi.Properties.DisplayMember = "DON_Name";
                return true;
            }
            else
                return false;

        }
        private void sLoadChucDanh()
        {
            BO_CHUCDANH boCd = new BO_CHUCDANH();

            //lookUpChucDanh.Properties.DataSource = boCd.getAll();
            //lookUpChucDanh.Properties.ValueMember = "CHU_ID";
            //lookUpChucDanh.Properties.DisplayMember = "CHU_Name";
        }
        private DataTable getKhoaHoc()
        {
            BAL.BO_CHUNG_CHI bal = new BO_CHUNG_CHI();
            return bal.getChungChi_All();
        }
        private void loadKhoaHoc()
        {
            lookCcID.Properties.DataSource = getKhoaHoc();
            lookCcID.Properties.ValueMember = "CHC_ID";
            lookCcID.Properties.DisplayMember = "CHC_Name";
            //lookChungChi.ItemIndex = 0;
        }
        private DataTable getLopHoc(int lookCcID_selected_index)
        {
            BAL.BO_LOP bal = new BO_LOP();
            //return bal.getLop_Alls();
            return bal.getLOP_ByCcID(lookCcID_selected_index);
        }
        private void CheckRadiDonVi()
        {
            if (radCheck.EditValue == null)
            {
                return;
            }
            else

            if (int.Parse(radCheck.EditValue.ToString()) == 1)
            {
                frmDonViList frm = new frmDonViList();
                frm.ShowDialog();
            }
            else
                if (int.Parse(radCheck.EditValue.ToString()) == 2)
            {
                lookUpDonvi.Enabled = false;
                string text = lookUpDonvi.Text;
                this.lookUpDonvi.Text = text;
            }
            else
                    if (int.Parse(radCheck.EditValue.ToString()) == 3)
            {

                lookUpDonvi.Enabled = true;
            }
        }
        private void loadDataToGrid()
        {
            int ChungChi_ID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
            mTableChungChiDoi = boDoiCc.getDOI_CHUNGCHI_ByHocCCID(ChungChi_ID);
            if (mTableChungChiDoi.Rows.Count > 0)
            {
                gridRegister.DataSource = mTableChungChiDoi.DefaultView;
            }
            else
            {
                gridRegister.DataSource = null;
            }
        }
        private void checkDate()
        {
            if (dateNgayCapMoi.Text != string.Empty)
            {
                dateNgayCapMoi.Enabled = true;
                dateNgayHetHan.Enabled = false;
                //dateNgayCapMoi.DateTime = DateTime.Now;
                dateNgayHetHan.DateTime = new DateTime(dateNgayCapMoi.DateTime.Year + 5, dateNgayCapMoi.DateTime.Month, dateNgayCapMoi.DateTime.Day, dateNgayCapMoi.DateTime.Hour, dateNgayCapMoi.DateTime.Minute, dateNgayCapMoi.DateTime.Second, dateNgayCapMoi.DateTime.Millisecond);

            }
            //if (radNgayCap.SelectedIndex == 0)
            //{
            //    dateNgayCapMoi.Enabled = true;
            //    dateNgayHetHan.Enabled = false;
            //    dateNgayCapMoi.DateTime = DateTime.Now;
            //    dateNgayHetHan.DateTime = new DateTime(dateNgayCapMoi.DateTime.Year + 5, dateNgayCapMoi.DateTime.Month, dateNgayCapMoi.DateTime.Day, dateNgayCapMoi.DateTime.Hour, dateNgayCapMoi.DateTime.Minute, dateNgayCapMoi.DateTime.Second, dateNgayCapMoi.DateTime.Millisecond);

            //}
            //else
            //    if (radNgayCap.SelectedIndex == 1)
            //    {
            //        dateNgayCapMoi.Enabled = true;
            //        dateNgayHetHan.Enabled = false;
            //        dateNgayHetHan.DateTime = new DateTime(dateNgayCapMoi.DateTime.Year + 5, dateNgayCapMoi.DateTime.Month, dateNgayCapMoi.DateTime.Day, dateNgayCapMoi.DateTime.Hour, dateNgayCapMoi.DateTime.Minute, dateNgayCapMoi.DateTime.Second, dateNgayCapMoi.DateTime.Millisecond);
            //    }



        }
        private void sCheckEnable(int sCheck)
        {
            if (sCheck == 1)
            {
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtPhone.Enabled = false;
                txtSoBienLai.Enabled = false;
                //dateBirthDay.Enabled = false;
                txtBirthDay.Enabled = false;
                lookUpBirthPlace.Enabled = false;
                //lookUpChucDanh.Enabled = false;
                lookUpDonvi.Enabled = false;
                txtAddress.Enabled = false;
                memoRemarks.Enabled = false;
                txtBirthDay.Enabled = false;
                txtSoCcCu.Enabled = false;

                txtFirstName.BackColor = Color.White;
                txtLastName.BackColor = Color.White;
                txtPhone.BackColor = Color.White;
                txtSoBienLai.BackColor = Color.White;
                //dateBirthDay.BackColor = Color.White;
                lookUpBirthPlace.BackColor = Color.White;
                //lookUpChucDanh.BackColor = Color.White;
                lookUpDonvi.BackColor = Color.White;
                txtAddress.BackColor = Color.White;
                memoRemarks.BackColor = Color.White;
                txtBirthDay.BackColor = Color.White;
                txtSoCcCu.BackColor = Color.White;

            }
            else
                if (sCheck == 2)
            {
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                txtPhone.Enabled = true;
                txtSoBienLai.Enabled = true;
                //dateBirthDay.Enabled = true;
                lookUpBirthPlace.Enabled = true;
                //lookUpChucDanh.Enabled = true;
                lookUpDonvi.Enabled = true;
                txtAddress.Enabled = true;
                memoRemarks.Enabled = true;
                txtBirthDay.Enabled = true;
                //txtSoCcCu.Enabled = true;
            }

        }
        private DataSet sLookupName()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sSearchTable");
            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));
            //-- Add rows to the data table
            sTable.Rows.Add(1, "Tên");
            sTable.Rows.Add(2, "Họ và tên");
            sTable.Rows.Add(3, "Mã học viên");
            sTable.Rows.Add(4, "Ngày sinh");
            return sDataset;
        }
        private DataSet sLookupCondition()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sConditionTable");
            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));
            //-- Add rows to the data table
            sTable.Rows.Add(1, "Có chứa");
            sTable.Rows.Add(2, "Bắt đầu");
            return sDataset;
        }
        private void sSearchTool()
        {
            // Biding data to search tool
            lookSearchBy.Properties.DataSource = sLookupName().Tables["sSearchTable"];
            lookSearchBy.Properties.ValueMember = "ID";
            lookSearchBy.Properties.DisplayMember = "Name";
            lookSearchBy.ItemIndex = 0;

            lookCondition.Properties.DataSource = sLookupCondition().Tables["sConditionTable"];
            lookCondition.Properties.ValueMember = "ID";
            lookCondition.Properties.DisplayMember = "Name";
            lookCondition.ItemIndex = 0;
        }
        private bool vSaveStudents(int vCheck)
        {
            hocvien = new HOCVIEN();
            hocvien.HOV_Code = txtStudentCode.Text;
            hocvien.HOV_FirstName = txtFirstName.Text.Trim();
            hocvien.HOV_LastName = txtLastName.Text.Trim();
            hocvien.HOV_FullName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            hocvien.HOV_Address = txtAddress.Text;
            hocvien.HOV_Phone = txtPhone.Text;
            hocvien.HOV_GhiChu = memoRemarks.Text.Trim();
            hocvien.HOV_QuocTich = txtQuocTich.Text.Trim();

            if (txtBirthDay.Text == string.Empty)
            {
                MessageBox.Show("Nhập ngày sinh của học viên", "THÔNG BÁO");
                return false;
            }
            else
            {
                hocvien.HOV_BirthDay = txtBirthDay.Text;
            }
            if (lookUpBirthPlace.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn nơi sinh", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                hocvien.HOV_NoiSinh = lookUpBirthPlace.GetColumnValue("TIN_ID").ToString();
            }
            if (lookUpDonvi.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn đơn vị", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                hocvien.HOV_DonVi = lookUpDonvi.GetColumnValue("DON_ID").ToString();
            }

            if (vCheck == 1)
            {
                gIDHocVien = boHv.insert(hocvien);
                flagSaveHocVien = true;
            }
            else// Không update thông tin học viên tại form đăng kí học -> Vào form quản lý học viên để cập nhật thông tin cho học viên
                if (vCheck == 2)
            {
                hocvien.HOV_ID = gIDHocVien;
                boHv.update(hocvien);
                loadDataToGrid();
            }
            return flagSaveHocVien;
        }
        private bool vSaveChangeCerificate(int vCheck)
        {
            boDoiCc = new BO_DOI_CHUNGCHI();
            dtoDoiCC = new DOI_CHUNGCHI();
            dtoDoiCC.DOI_Ngay_KG = dateNgayKG.DateTime;
            dtoDoiCC.DOI_Ngay_KT = dateNgayKT.DateTime;
            dtoDoiCC.DOI_Ngay_QD = dateNgayQD.DateTime;
            dtoDoiCC.DOI_NgayCap = dateNgayCapMoi.DateTime;
            dtoDoiCC.DOI_Code = txtDKHCode.Text;
            dtoDoiCC.DOI_CHCID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
            dtoDoiCC.DOI_HOVID = gIDHocVien;
            dtoDoiCC.DOI_ID = vDoiCcID;

            if (txtSoCcCu.Text == "")
            {
                MessageBox.Show("Chưa nhập số chứng chi.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCcCu.Focus();
                return false;
            }
            else
            {
                dtoDoiCC.DOI_SoCC = txtSoCcCu.Text + " " + txtSoCcText.Text;
            }
            if (vCheck == 1) // Có insert hoc vien moi
            {
                try
                {
                    vDoiCcID = boDoiCc.insert(dtoDoiCC);
                    flagSaveDoi = true;
                }
                catch (Exception)
                {

                    flagSaveDoi = false;
                }

            }
            if (vCheck == 2) // Khong tao hoc vien moi
            {
                try
                {
                    boDoiCc.update(dtoDoiCC);
                    flagSaveDoi = true;
                }
                catch (Exception)
                {

                    flagSaveDoi = false;
                }

            }
            // Lấy ID chứng chỉ đổi mới nhất
            //vDoiId = int.Parse(boDoiCc.getLastId_Doi_ChungChi().Rows[0]["DOI_ID"].ToString());
            return flagSaveDoi;
        }
        private Boolean checkControl()
        {
            if (lookCcID.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại chứng chỉ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateNgayKG.EditValue == null)
            {
                MessageBox.Show("Chưa nhập ngày khai giảng", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateNgayKT.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập ngày kết thúc", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateNgayQD.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập ngày quyết định", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dateNgayCapMoi.Text == string.Empty)
            {
                MessageBox.Show("Ngày cấp chứng chỉ trống", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dateNgayCapCu.EditValue == null)
            {
                mNgayCapCu = DateTime.Now;
            }
            else
            {
                mNgayCapCu = dateNgayCapCu.DateTime;
            }
            if (radCapDoi.SelectedIndex < 0)
            {
                MessageBox.Show("Chưa chọn tiêu chí cấp lại, hay cấp đổi", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtSohieuNumber.Text == string.Empty || txtSohieuText.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập số hiệu đổi", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSohieuNumber.Focus();
                return false;
            }
            return true;
        }
        private void sGeneralCodeHocVien()
        {
            DataTable tb = new DataTable();
            tb = boHv.get_HocCVien_LastCode();
            string hVCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                hVCode = "000000";
            }
            else
            {
                hVCode = tb.Rows[0]["HOV_Code"].ToString();
                hVCode = hVCode.Substring(3, 5);
            }

            txtStudentCode.Text = ("HOV" + Utilities.quydinh.LaySTT(int.Parse(hVCode.ToString()) + 1)).ToString();
            mHvStatust = int.Parse(hVCode.ToString());
        }
        private void sGeneralCodeDangKiHocVien()
        {
            boDoiCc = new BO_DOI_CHUNGCHI();
            DataTable tb = new DataTable();
            tb = boDoiCc.getDoiCC_LastCode();
            string dkhCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                dkhCode = "000000";
            }
            else
            {
                dkhCode = tb.Rows[0]["DOI_Code"].ToString();
                dkhCode = dkhCode.Substring(3, 5);
            }
            txtDKHCode.Text = ("DOI" + Utilities.quydinh.LaySTT(int.Parse(dkhCode.ToString()) + 1)).ToString();
            mDoiStatust = int.Parse(dkhCode.ToString());
        }
        private void sResultSearchByFirstName()
        {
            string fullName = string.Empty;
            if (txtFirstName.Text != "")
            {
                fullName = txtFirstName.Text + " " + txtLastName.Text;
                hvTable = boHv.searchHocVienByFullName(fullName);
                //hvTable = boHv.searchHocVienByFirstName(txtFirstName.Text);// +" "+ txtLastName.Text);
                gridStudents.DataSource = hvTable;
            }
            else
            {
                return;
            }


        }
        private void clearInputData(int sCheck)
        {
            if (sCheck == 1)
            {
                txtStudentCode.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtSoBienLai.Text = string.Empty;
                txtBirthDay.Text = string.Empty;
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.EditValue = string.Empty;
                txtAddress.Text = string.Empty;
                txtSoCcCu.Text = string.Empty;
                dateNgayKG.Text = string.Empty;
                dateNgayKT.Text = string.Empty;
                dateNgayQD.Text = string.Empty;
                lookCcID.EditValue = string.Empty;
                memoRemarks.Text = string.Empty;
                txtSoCcCu.Text = string.Empty;
                dateNgayCapCu.Text = string.Empty;
                dateNgayKG.EditValue = null;
                dateNgayKT.EditValue = null;
                dateNgayQD.EditValue = null;

            }
            if (sCheck == 2)
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtSoBienLai.Text = string.Empty;
                txtBirthDay.Text = string.Empty;
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.EditValue = null;
                txtAddress.Text = string.Empty;
                lookCcID.EditValue = null;
                memoRemarks.Text = string.Empty;
                txtSoCcCu.Text = string.Empty;
                dateNgayCapCu.Text = string.Empty;
                dateNgayKG.EditValue = null;
                dateNgayKT.EditValue = null;
                dateNgayQD.EditValue = null;

            }
            if (sCheck == 3)
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtSoBienLai.Text = string.Empty;
                txtBirthDay.Text = string.Empty;
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.EditValue = null;
                txtAddress.Text = string.Empty;
                memoRemarks.Text = string.Empty;
                dateNgayKG.Text = string.Empty;
                dateNgayKT.Text = string.Empty;
                dateNgayQD.Text = string.Empty;
            }
            loadDefaultImage();

        }
        private bool vCheckHocVienDaDangKiDoi()
        {
            int scheck = 0;
            Dictionary<int, int> sTemList = new Dictionary<int, int>();
            sTemList.Clear();
            if (grvRegisterContent.RowCount > 0)
            {
                for (int i = 0; i < grvRegisterContent.RowCount; i++)
                {
                    try
                    {
                        sTemList.Add(int.Parse(grvRegisterContent.GetRowCellValue(i, "DOI_HOVID").ToString()), i);
                    }
                    catch (Exception)
                    {
                        //MessageBox.Show("Có hai học viên trùng nhau trong lớp", " THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new ArgumentException("Có hai học viên trùng nhau trong lớp này!", " THÔNG BÁO");
                    }
                }
                foreach (var item in sTemList)
                {
                    if (item.Key == gIDHocVien)
                    {
                        scheck++;
                    }
                    if (scheck > 0)
                    {
                        MessageBox.Show("Học viên này đã có trong danh sách đổi chứng chỉ " + lookCcID.GetColumnValue("CHC_Name").ToString() +
                            " \n Khóa: " + txtSohieuText.Text + "." + txtSohieuYear.Text + "." + txtSohieuMonth.Text + "." + txtSohieuNumber.Text, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                return true;
            }
            else
                return true;
        }
        private void ClearControl()
        {

            if (mStatusSave.Text == "Sửa thông tin")
            {
                //vSaveStudents(2);
                //vSaveChangeCerificate(2);
                clearInputData(1);
                sCheckEnable(1);
            }
            clearInputData(3);
            txtSoCcCu.Text = string.Empty;
            //loadDataToGrid(); // Chi load lai theo lop Cap lai hay Doi 
            GetDataBySoHieuDoi();
            //sCounter();

            if (mSaveSender.Text == "Lưu")
            {
                lookUpBirthPlace.CancelPopup();
                lookUpBirthPlace.EditValue = null;
                txtBirthDay.Text = string.Empty;
                btnNew.Enabled = true;
                return;
            }
        }
        private bool vSaveCapChungChi(int vCheck)
        {
            boCcc = new BO_CAP_CHUNGCHI();
            dtoCapCc = new CAP_CHUNGCHI();
            DataTable cCMhTable = new DataTable();
            DataTable tb1 = new DataTable();
            DateTime vBirthDayYear = DateTime.Now;
            string vStrDate = txtBirthDay.Text;
            vBirthDayYear = ConvertToDate(vStrDate, "dd/MM/yyyy");
            sAge = dateNgayCapMoi.DateTime.Year + 5 - vBirthDayYear.Year;
            dtoCapCc.CCC_SoHieuDoi = txtSohieuText.Text + "." + txtSohieuYear.Text + "." + txtSohieuMonth.Text + "." + txtSohieuNumber.Text;
            dtoCapCc.CCC_HOVID = gIDHocVien;
            dtoCapCc.CCC_SoCC = txtSoCcCu.Text + " " + txtSoCcText.Text;
            dtoCapCc.CCC_CHCID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
            dtoCapCc.CCC_LOPID = -1;
            dtoCapCc.CCC_DOIID = vDoiCcID;
            dtoCapCc.CCC_NgayCapLai = DateTime.Now;
            DataTable lastSoCcC = new DataTable();
            lastSoCcC = boCcc.getLast_SoCc(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()));
            if (lastSoCcC.Rows.Count <= 0)
            {
                dtoCapCc.CCC_Code = "CCC" + Utilities.quydinh.LaySTT(1);
            }
            else // Phai lay so chung chi cuoi cung, sau do moi cong them vao;
            {
                dtoCapCc.CCC_Code = "CCC" + Utilities.quydinh.LaySTT(int.Parse(txtSoCcCu.Text.ToString()) + 1);
            }
            if (radCapDoi.SelectedIndex == 0)
            {
                dtoCapCc.CCC_Status = 2; //Cap lai
            }
            else if (radCapDoi.SelectedIndex == 1)
            {
                dtoCapCc.CCC_Status = 3; // Cap doi
            }
            try
            {
                if (sAge < 60)
                {
                    dtoCapCc.CCC_NgayCap = dateNgayCapMoi.DateTime;
                    dtoCapCc.CCC_NgayHetHan = new DateTime(dateNgayCapMoi.DateTime.Year + 5, dateNgayCapMoi.DateTime.Month, dateNgayCapMoi.DateTime.Day);
                    if (vCheck == 1)
                    {
                        boCcc.insert(dtoCapCc);
                    }
                    if (vCheck == 2)
                    {
                        dtoCapCc.CCC_ID = mCccID;
                        boCcc.update(dtoCapCc);
                    }

                }
                else
                {
                    int vAgeYear = 0;
                    int vYearEnd = 0;
                    vAgeYear = dateNgayCapMoi.DateTime.Year - vBirthDayYear.Year;
                    vYearEnd = 60 - vAgeYear;
                    vYearEnd = dateNgayCapMoi.DateTime.Year + vYearEnd;

                    dtoCapCc.CCC_NgayCap = dateNgayCapMoi.DateTime;
                    dtoCapCc.CCC_NgayHetHan = new DateTime(vYearEnd, vBirthDayYear.Date.Month, vBirthDayYear.Date.Day);//, vBirthDayYear.Date.Hour, vBirthDayYear.Date.Minute, vBirthDayYear.Date.Second, vBirthDayYear.Date.Millisecond);


                    if (vCheck == 1)
                    {
                        boCcc.insert(dtoCapCc);
                    }
                    if (vCheck == 2)
                    {
                        boCcc.update(dtoCapCc);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu số chứng chỉ: " + ex.Message, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        private void generalSoHieu()
        {
            string year = string.Empty;
            string month = string.Empty;
            txtSohieuYear.Text = DateTime.Now.Year.ToString().Substring(2, 2);
            txtSohieuMonth.Text = DateTime.Now.Month.ToString();
        }
        private Boolean checkRadioDoi()
        {
            if (radCapDoi.SelectedIndex < 0)
            {
                return false;
            }
            else
                return true;
        }
        private void updateSoCC_NgayCap()
        {
            if (sselection.SelectedCount == 0)
            {
                MessageBox.Show("Chưa chọn học viên", "THÔNG BÁO");
                return;
            }
            else
            {
                DateTime CCC_NgayCaps = dateNgayCapMoi.DateTime;
                dateNgayHetHan.DateTime = new DateTime(dateNgayCapMoi.DateTime.Year + 5, dateNgayCapMoi.DateTime.Month, dateNgayCapMoi.DateTime.Day, dateNgayCapMoi.DateTime.Hour, dateNgayCapMoi.DateTime.Minute, dateNgayCapMoi.DateTime.Second, dateNgayCapMoi.DateTime.Millisecond);
                DateTime CCC_NgayHetHan = dateNgayHetHan.DateTime;
                for (int i = 0; i < grvRegisterContent.RowCount; i++)
                {
                    if (sselection.IsRowSelected(i))
                    {
                        DataRow dr = grvRegisterContent.GetDataRow(i);
                        int CccID = int.Parse(dr["CCC_ID"].ToString());
                        string NgaySinh = dr["HOV_BirthDay"].ToString();

                        DateTime sBirthDay = ConvertToDate(NgaySinh, "dd/MM/yyyy");

                        int years = -1;
                        //years = dateNgayHetHan.DateTime.Year - sBirthDay.Year;
                        object newYear;
                        newYear = years = dateNgayCapMoi.DateTime.Year - sBirthDay.Year;

                        if (int.Parse(newYear.ToString()) >= 60)
                        {
                            MessageBox.Show("Học viên này đã quá 60 tuổi", "THÔNG BÁO");
                            return;
                        }
                        years = 60 - years;
                        int yearEnd = -1;
                        if (years > 5)
                        {
                            CCC_NgayHetHan = new DateTime(dateNgayCapMoi.DateTime.Year + 5, dateNgayCapMoi.DateTime.Month, dateNgayCapMoi.DateTime.Day, dateNgayCapMoi.DateTime.Hour, dateNgayCapMoi.DateTime.Minute, dateNgayCapMoi.DateTime.Second, dateNgayCapMoi.DateTime.Millisecond);
                        }
                        else
                        {
                            yearEnd = dateNgayCapMoi.DateTime.Year + years;
                            sBirthDay = new DateTime(yearEnd, sBirthDay.Date.Month, sBirthDay.Date.Day, sBirthDay.Date.Hour, sBirthDay.Date.Minute, sBirthDay.Date.Second, sBirthDay.Date.Millisecond);
                            CCC_NgayHetHan = sBirthDay;
                        }

                        boDoiCc.update_NgayCap_Doi(CccID, CCC_NgayCaps, CCC_NgayHetHan);
                    }

                }

            }
        }
        private static DateTime ConvertToDate(string Date, string Format)
        {
            DateTime date = DateTime.MinValue;
            try
            {
                string[] s = Date.Split(new char[] { '/', '-' });
                int d = date.Day;
                int m = date.Month;
                int y = date.Year;
                //for (int i = 0; i < s.Length; i++)
                //{
                if (Format == "dd/MM/yyyy" || Format == "dd-MM-yyyy")
                {
                    if (s.Length == 2)
                    {
                        int.TryParse(s[0], out m);
                        int.TryParse(s[1], out y);
                    }
                    else if (s.Length == 3)
                    {
                        int.TryParse(s[0], out d);
                        int.TryParse(s[1], out m);
                        int.TryParse(s[2], out y);
                    }
                    else if (s.Length == 1)
                    {
                        int.TryParse(s[0], out y);
                    }
                }
                else if (Format == "MM/dd/yyyy" || Format == "MM-dd-yyyy")
                {
                    if (s.Length == 2)
                    {
                        int.TryParse(s[0], out m);
                        int.TryParse(s[1], out y);
                    }
                    else if (s.Length == 3)
                    {
                        int.TryParse(s[0], out d);
                        int.TryParse(s[1], out m);
                        int.TryParse(s[2], out y);
                    }
                    else if (s.Length == 1)
                    {
                        int.TryParse(s[0], out y);
                    }
                }


                //}

                date = new DateTime(y, m, d);
            }
            catch { }
            return date;
        }
        private void GetDataBySoHieuDoi()
        {
            int idx = -1;
            sSoHieu = txtSohieuText.Text + "." + txtSohieuYear.Text + "." + txtSohieuMonth.Text + "." + txtSohieuNumber.Text;
            if (lookCcID.ItemIndex > -1)
            {
                if (radCapDoi.SelectedIndex == 0)
                {
                    idx = 2;
                }
                else if (radCapDoi.SelectedIndex == 1)
                {
                    idx = 3;
                }
                gridRegister.DataSource = boDoiCc.Get_DsHV_DuocCapCC_Doi(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()), idx, sSoHieu);
                sCounter();
            }

        }
        private void getSoHieuByCHCID()
        {
            if (lookCcID.ItemIndex > -1)
            {
                DataTable tbl = boDoiCc.Get_SoHieuDoi_ByCHCID(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()));

                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];
                    string SohieuText = string.Empty;
                    SohieuText = row["CCC_SoHieuDoi"].ToString();
                    string[] ss = SohieuText.Split('.');
                    txtSohieuText.Text = ss[0].ToString();
                }
            }

        }
        private bool checkFullName()
        {
            string strFirstName = txtFirstName.Text.Trim();
            string strLastName = txtLastName.Text.Trim();
            string strFullName = strFirstName + " " + strLastName;
            string strNgaySinh = txtBirthDay.Text;
            DataTable tb;// = hvTable;// mTableChungChiDoi;
            // mTableChungChiDoi phải là dữ liệu của toàn bộ học viên đã có tại trung tâm
            tb = ((DataView)gridContentStudents.DataSource).ToTable();
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    strFirstName = tb.Rows[i]["HOV_FirstName"].ToString();
                    strLastName = tb.Rows[i]["HOV_LastName"].ToString();
                    string mStrFullname = strFirstName.Trim() + " " + strLastName.Trim();
                    string sNgaySinh = tb.Rows[i]["HOV_BirthDay"].ToString();
                    if (strFullName == mStrFullname && strNgaySinh == sNgaySinh)
                    {
                        if (DialogResult.No == MessageBox.Show("Học viên " + strFullName + ", sinh ngày " + strNgaySinh + " đã tồn tại trong hệ thống.\n Bạn có muốn tạo mới không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        {
                            //checkIdStudentBothGrid();
                            return false;
                        }
                    }
                }

            }
            return true;
        }
        private Boolean checkSoChungChi()
        {
            DataTable vTable = new DataTable();
            DataTable tblDoi = new DataTable();
            int ChungChi_ID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
            string vSoCC = txtSoCcCu.Text + " " + txtSoCcText.Text;
            if (radCapDoi.SelectedIndex == 1)
            {// Chi kiem tra doi voi so cap doi
                vTable = boDoiCc.vCheckSoChungChi(ChungChi_ID, vSoCC);
                tblDoi = boDoiCc.vCheckSoChungChi2(ChungChi_ID, vSoCC);
                if (vTable.Rows.Count > 0 || tblDoi.Rows.Count > 0)
                {
                    return false;
                }
                else return true;
            }
            else
                return true;

        }
        #endregion
        #region image
        private void resizeImage(Image _img, float _width, float _height)
        {
            Bitmap bm_source = new Bitmap(_img);
            // Make a bitmap for the result.
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_width), Convert.ToInt32(_height));
            // Make a Graphics object for the result Bitmap.
            Graphics gr_dest = Graphics.FromImage(bm_dest);
            // Copy the source image into the destination bitmap.
            gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width, bm_dest.Height);
            // Display the result.
            picHocVien.Image = bm_dest;
            picHocVien.Width = bm_dest.Width;
            picHocVien.Height = bm_dest.Height;
        }
        private void btnBrowsImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                vImgFileName = open.FileName;
                Img = new Bitmap(vImgFileName);
                resizeImage(Img, 106, 140);
            }
        }
        private bool insertImg()
        {
            DtoImg = new HOCVIEN_IMG();
            BoImg = new BO_HOCVIEN_IMG();
            DtoImg.IMG_HOVID = gIDHocVien;
            DtoImg.IMG_Name = vImgFileName;
            try
            {
                if (picHocVien.Image != null)
                {
                    imgArray = ReadFile(vImgFileName);
                    DtoImg.IMG_Image = imgArray;
                    BoImg.insert(DtoImg);
                    vFlagSaveImg = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return vFlagSaveImg;
        }
        private bool updateImg()
        {
            DtoImg = new HOCVIEN_IMG();
            BoImg = new BO_HOCVIEN_IMG();
            DtoImg.IMG_ID = ImgID;
            DtoImg.IMG_HOVID = gIDHocVien;
            DtoImg.IMG_Name = vImgFileName;
            try
            {
                if (picHocVien.Image != null)
                {
                    imgArray = ReadFile(vImgFileName);
                    DtoImg.IMG_Image = imgArray;
                    BoImg.update(DtoImg);
                    vFlagSaveImg = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return vFlagSaveImg;
        }
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        private void loadDefaultImage()
        {
            try
            {
                vImgFileName = Environment.CurrentDirectory + @"\No-Image.jpg";
                Img = new Bitmap(vImgFileName);
                resizeImage(Img, 106, 140);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadImage(DataRow vRow)
        {
            if (vRow["IMG_Image"] != DBNull.Value)
            {
                ImgID = int.Parse(vRow["IMG_ID"].ToString());
                imgArray = (byte[])vRow["IMG_Image"];
                //Read image data into a memory stream
                using (MemoryStream ms = new MemoryStream(imgArray, 0, imgArray.Length))
                {
                    ms.Write(imgArray, 0, imgArray.Length);
                    //Set image variable value using memory stream.
                    Img = Image.FromStream(ms, true);
                }
                //set picture
                picHocVien.Image = Img;
                resizeImage(Img, 106, 140);
                vImgFileName = vRow["IMG_Name"].ToString();
                ExistImg = true;
            }
            else
            {
                loadDefaultImage();
                ExistImg = false;
            }
        }
        #endregion
        private string previousText;
        private void vCheckOnlyNumber(object sender)
        {
            if (string.IsNullOrEmpty(((TextEdit)sender).Text))
                previousText = "";
            else
            {
                double num = 0;
                bool success = double.TryParse(((TextEdit)sender).Text, out num);
                if (success & num >= 0)
                {
                    ((TextEdit)sender).Text.Trim();
                    previousText = ((TextEdit)sender).Text;
                }
                else
                {
                    ((TextEdit)sender).Text = previousText;
                    ((TextEdit)sender).SelectionStart = ((TextEdit)sender).Text.Length;
                }
            }
        }
        private void txtSoCcCu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Chỉ được nhập số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCcCu.Text = string.Empty;
            }
        }
        protected void initLevel()
        {
            tblLevel = new DataTable();
            tblLevel.Columns.Add("ID");
            tblLevel.Columns.Add("Name");
            for (int i = 1; i < 4; i++)
            {
                tblLevel.Rows.Add(i, i);
            }
            lookLevel.Properties.DataSource = tblLevel.DefaultView;
            lookLevel.Properties.DisplayMember = "Name";
            lookLevel.Properties.ValueMember = "ID";
            lookLevel.ItemIndex = -1;
        }
    }
}