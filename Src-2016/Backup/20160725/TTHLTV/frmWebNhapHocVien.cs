using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TTHLTV.BAL;
using TTHLTV.DTO;
namespace TTHLTV
{
    public partial class frmWebNhapHocVien : Form
    {
        public frmWebNhapHocVien()
        {
            InitializeComponent();
          
        }
        private GridCheckMarksSelection sselection;
        BO_CHUNG_CHI boChungChi;
        CHUNG_CHI dtoChungChi;
        public int gChungChiID;
        BO_LOP boLop;
        BO_DANG_KI_HOC boDangKiHoc;
        WEB_DANGKIHOC vDto;
        BO_WEB_DANGKIHOC vBo;
        DataTable vtbl;
        BO_TINH boTinh;
        BO_DONVI boDv;
        BO_HOCVIEN boHocVien;
        HOCVIEN hocvien;
        DANG_KI_HOC dtoDkHoc;
        BO_DIEM boDiem;
        DIEM dtoDiem;
        //MONHOC dtoMonHoc;
        BO_MONHOC boMonHoc;
        int gHocVienID;
        int gDangkiHocID;
        bool flagSave = false;
        bool flagExitse = false;
        private bool vLoadChungChi()
        {
            DataTable vtb = new System.Data.DataTable();
            dtoChungChi = new CHUNG_CHI();
            boChungChi = new BO_CHUNG_CHI();
            vtb = boChungChi.getChungChi_All();
            if (vtb.Rows.Count > 0)
            {
                lookCcID.Properties.DataSource = vtb.DefaultView;
                lookCcID.Properties.ValueMember = "CHC_ID";
                lookCcID.Properties.DisplayMember = "CHC_Name";
                lookCcID.EditValue = gChungChiID;
                return true;
            }
            else
                return false;
           
        }
        private bool vLoadTinhThanh()
        {
            boTinh = new BO_TINH();
            DataTable tbl = new DataTable();
            tbl = boTinh.getTinh_All();
            if (tbl.Rows.Count > 0)
            {
                lookUpBirthPlace.Properties.DataSource = tbl.DefaultView;
                lookUpBirthPlace.Properties.ValueMember = "TIN_ID";
                lookUpBirthPlace.Properties.DisplayMember = "TIN_Name";
                return true;
            }
            else
                return false;
            
        }
        private bool vLoadDonVi()
        {
            boDv  = new BO_DONVI();
            DataTable tbl = new DataTable();
            tbl = boDv.getAll();
            if (tbl.Rows.Count > 0)
            {
                lookUpDonvi.Properties.DataSource = tbl.DefaultView;
                lookUpDonvi.Properties.ValueMember = "DON_ID";
                lookUpDonvi.Properties.DisplayMember = "DON_Name";
                return true;
            }
            else
                return false;
           
        }
        private void frmWebNhapHocVien_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridRegister.MainView, new Font("Tahoma", 11));
            Utilities.setFontSize.SetGridFont(grdWebListHocVien.MainView, new Font("Tahoma", 11));
            Utilities.setFontSize.SetGridFont(gridStudents.MainView, new Font("Tahoma", 11));
            if (vLoadChungChi())
            {
                vLoadLopHoc();
                initSubjectList();
                vLoadChungChi();
                vLoadDonVi();
                vLoadListHocVien();
            }
            btnDangKiHvMoi.Enabled = false;
            vCheckEnable(1);
        }
        private void vLoadLopHoc()
        {
            boLop = new BO_LOP();
            DataTable vtb = new System.Data.DataTable();
            vtb = boLop.getLOP_ByCcID(gChungChiID);
            if (vtb.Rows.Count>0)
            {
                lookUpLop.Properties.DataSource = vtb.DefaultView;
                lookUpLop.Properties.ValueMember = "LOP_ID";
                lookUpLop.Properties.DisplayMember = "LOP_Name";
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp học","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
        }
        private void vLoadThoiGianHoc()
        {
            boLop = new BO_LOP();
            DataRow row = boLop.getLOP_ByID(int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString())).Rows[0];// search by ID, so there is only one row
            DateTime DateAllocate = Convert.ToDateTime(row["LOP_Ngay_KG"].ToString());
            DateTime DateExpire = Convert.ToDateTime(row["LOP_Ngay_KT"].ToString());
            txtDateAllocate.Text = DateAllocate.ToString("dd/MM/yyyy");
            txtDateExpire.Text = DateExpire.ToString("dd/MM/yyyy");
        }
        private void lookUpLop_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpLop.ItemIndex > -1)
            {
                // load dateAllocate and dateExpire
                vLoadThoiGianHoc();
                // load data to grid
                vLoadData();
                //txtFirstName.Focus();
            }
        }
        private void vLoadData()
        {
            boDangKiHoc = new BO_DANG_KI_HOC();
            dtoDkHoc = new DANG_KI_HOC();

            dtoDkHoc.DKH_LOPID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            DataTable vtb = new DataTable();
            vtb = boDangKiHoc.getCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC(dtoDkHoc );
            if (vtb.Rows.Count>0)
            {
                gridRegister.DataSource = vtb;
                lblCounter.Text = " Tổng số học viên trong lớp: " + grvRegisterContent.RowCount + " ";
                lblCounter.BackColor = Color.White;
                lblCounter.ForeColor = Color.Red;
            }
        }
        private void vLoadListHocVien()
        {
            vDto = new WEB_DANGKIHOC();
            vDto.DKW_Active = 1;
            vDto.DKW_Status = 3;
            vBo = new BO_WEB_DANGKIHOC();
            vtbl = new DataTable();
            vDto.DKW_CHCID = gChungChiID;
            vtbl = vBo.vLoadListHocVienByChungChiID(vDto);

            grvWebListHocVien.Columns.Clear();
            grdWebListHocVien.DataSource = vtbl.DefaultView;
            grvWebListHocVien.Columns["DKW_ID"].VisibleIndex = -1;
            grvWebListHocVien.Columns["DKW_Status"].VisibleIndex = -1;
            grvWebListHocVien.Columns["DKW_Code"].VisibleIndex = -1;
            grvWebListHocVien.Columns["DKW_TINID"].VisibleIndex = -1;
            grvWebListHocVien.Columns["DKW_DONID"].VisibleIndex = -1;
            grvWebListHocVien.Columns["DKW_CHUID"].VisibleIndex = -1;
            sselection = new GridCheckMarksSelection(grvWebListHocVien);
            sselection.CheckMarkColumn.VisibleIndex = 0;
            sselection.CheckMarkColumn.Width = 8;
            //for (int i = 0; i < vtbl.Rows.Count; i++)
            //{
            //    if (int.Parse(vtbl.Rows[i]["DKW_Status"].ToString()) == 2)
            //    {
            //        sselection.SelectRow(i, true);
            //    }
            //}
        }
        private bool vCheckHocVienTonTai(string vString)
        {
            DataTable tbl = new DataTable();
            boHocVien = new BO_HOCVIEN();
            tbl =boHocVien.searchHocVienByFullName(vString);
            if (tbl.Rows.Count > 0)
            {
                gridStudents.DataSource = tbl.DefaultView;
                btnDangKiHvMoi.Enabled = false;
                flagExitse = true;
            }
            else
            {
                gridStudents.DataSource = null;
                btnDangKiHvMoi.Enabled = true;
                flagExitse = false;
            }
            return flagExitse;
        }
        private void grvWebListHocVien_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //DataRow currentRow = grvWebListHocVien.GetDataRow(e.RowHandle);
            //txtStudentCode.Text = currentRow["DKW_Code"].ToString();
            //txtFirstName.Text = currentRow["Họ"].ToString();
            //txtLastName.Text = currentRow["Tên"].ToString();
            //txtBirthDay.EditValue = currentRow["Ngày sinh"].ToString();
            //txtPhone.Text = currentRow["Điện thoại"].ToString();
            //if (vLoadTinhThanh())
            //{
            //    lookUpBirthPlace.EditValue = int.Parse(currentRow["DKW_TINID"].ToString());
            //}
            //if (vLoadDonVi())
            //{
            //    lookUpDonvi.EditValue = int.Parse(currentRow["DKW_DONID"].ToString());
            //}
            //if (vLoadChucDanh())
            //{
            //    lookUpChucDanh.EditValue = int.Parse(currentRow["DKW_CHUID"].ToString());
            //}
        }
        private void btnCheckHvTonTai_Click(object sender, EventArgs e)
        {
            if (sselection.SelectedCount > 1)
            {
                MessageBox.Show("Chỉ chọn một học viên cho một lần kiểm tra","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < grvWebListHocVien.RowCount; i++)
            {
                DataRow dr = grvWebListHocVien.GetDataRow(i);
                if (sselection.IsRowSelected(i))
                {
                    vDto.DKW_FullName = dr["Họ"].ToString() + " " + dr["Tên"].ToString();
                    vCheckHocVienTonTai(vDto.DKW_FullName);
                }
                
            }
        }
        private void gridContentStudents_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow currentRow = gridContentStudents.GetDataRow(e.RowHandle);
            gHocVienID = int.Parse(currentRow["HOV_ID"].ToString());
            txtStudentCode.Text = currentRow["HOV_Code"].ToString();
            txtFirstName.Text = currentRow["HOV_FirstName"].ToString();
            txtLastName.Text = currentRow["HOV_LastName"].ToString();
            txtBirthDay.EditValue = currentRow["HOV_BirthDay"].ToString();
            txtPhone.Text = currentRow["HOV_Phone"].ToString();
            txtAddress.Text = currentRow["HOV_Address"].ToString();
            if (vLoadTinhThanh())
            {
                 lookUpBirthPlace.EditValue = int.Parse(currentRow["HOV_NoiSinh"].ToString());
            }
            if (vLoadDonVi())
            {
                lookUpDonvi.EditValue = int.Parse(currentRow["HOV_DonVi"].ToString());
            }
            //btnEdit.Enabled = true;
            //btnEdit.Focus();
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            //btnDelete.Enabled = true;
            //btnNew.Enabled = false;
            //sGeneralCodeHocVien();
        }
        private void vCreateCode()
        {
            DataTable tb = new DataTable();
            boHocVien = new BO_HOCVIEN();
            tb = boHocVien.get_HocCVien_LastCode();
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
        }
        private void btnDangKiHvMoi_Click(object sender, EventArgs e)
        {
            if (sselection.SelectedCount > 1)
            {
                MessageBox.Show("Chỉ chọn một học viên cho một lần nhập", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 0; i < grvWebListHocVien.RowCount; i++)
            {
                DataRow dr = grvWebListHocVien.GetDataRow(i);
                if (sselection.IsRowSelected(i))
                {
                    //txtStudentCode.Text = currentRow["DKW_Code"].ToString();
                    vCreateCode();
                    txtFirstName.Text = dr["Họ"].ToString();
                    txtLastName.Text = dr["Tên"].ToString();
                    txtBirthDay.EditValue = dr["Ngày sinh"].ToString();
                    txtPhone.Text = dr["Điện thoại"].ToString();
                    if (vLoadTinhThanh())
                    {
                        lookUpBirthPlace.EditValue = int.Parse(dr["DKW_TINID"].ToString());
                    }
                    if (vLoadDonVi())
                    {
                        lookUpDonvi.EditValue = int.Parse(dr["DKW_DONID"].ToString());
                    }
                    //if (vLoadChucDanh())
                    //{
                    //    lookUpChucDanh.EditValue = int.Parse(dr["DKW_CHUID"].ToString());
                    //}
                }

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (vCheckNull())
            {
                if (flagExitse==true)
                {
                    string messages = "Học viên này đã đăng kí học ở trung tâm,\n bạn có muốn tạo mới không? ";
                    string caption = " THÔNG BÁO ";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(messages, caption, button);
                    if (result== DialogResult.Yes)
                    {
                        if (vSaveStudents(1)) //Đồng ý tạo học viên mới và đăng kí học
                        {
                            vSaveRegisterCoures(1);
                        }
                    }
                    else if(checkIdStudentBothGrid())
                    {//Không tạo học viên mới - Chỉ nhập vào thông tin đăng kí học
                        vSaveRegisterCoures(1);
                    }
                    else
                    {
                        MessageBox.Show("Mã học viên này đã được đăng kí vào lớp ( " + lookUpLop.GetColumnValue("LOP_Name") + " )");
                        clearInputData(1);
                        return;
                    }
                }
                else
                {//Đăng kí một học viên mới hoàn toàn
                    if (vSaveStudents(1)) 
                    {
                        vSaveRegisterCoures(1);
                    }
                }
                clearInputData(1);
                vLoadData();
            }
        }
        private bool vCheckNull()
        {
            if (lookCcID.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại chứng chỉ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lookUpLop.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn lớp", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtBirthDay.Text == string.Empty)
            {
                MessageBox.Show("Ngày sinh học viên không được trống", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lookUpBirthPlace.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn nơi sinh", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lookUpDonvi.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn đơn vị", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool vSaveStudents(int vCheck)
        {
            boHocVien = new BO_HOCVIEN();
            hocvien = new HOCVIEN();
            hocvien.HOV_Code = txtStudentCode.Text;
            hocvien.HOV_FirstName = txtFirstName.Text.Trim();
            hocvien.HOV_LastName = txtLastName.Text.Trim();
            hocvien.HOV_FullName = txtFirstName.Text.Trim() + " " + txtLastName.Text.Trim();
            hocvien.HOV_BirthDay = txtBirthDay.Text;
            hocvien.HOV_Address = txtAddress.Text;
            hocvien.HOV_Phone = txtPhone.Text;
            hocvien.HOV_GhiChu = memoRemarks.Text.Trim();
            hocvien.HOV_QuocTich = txtQuocTich.Text.Trim();
            hocvien.HOV_NoiSinh = lookUpBirthPlace.GetColumnValue("TIN_ID").ToString();
            hocvien.HOV_DonVi = lookUpDonvi.GetColumnValue("DON_ID").ToString();

            if (vCheck == 1)
            {
               gHocVienID = boHocVien.insert(hocvien);
               flagSave = true;
            }
            else if (vCheck == 2)
            {
                //hocvien.HOV_ID = mIdStudents;
                //boHocVien.update(hocvien);
                ////mIdStudents lấy lúc selectRow
                //loadDataToGrid();
            }
            return flagSave;
        }
        private void initSubjectList()
        {
            boMonHoc = new BO_MONHOC();
            dtoChungChi = new CHUNG_CHI();
            DataTable tb = new DataTable();
            dtoChungChi.CHC_ID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
            tb = boMonHoc.getSubjectName(dtoChungChi);
            if (tb.Rows.Count>0)
            {
                listSubject.DataSource = tb.DefaultView;
                listSubject.ValueMember = "MON_ID";
                listSubject.DisplayMember = "MON_Name";
                listSubject.CheckAll();
            }
        }
        private void vSaveRegisterCoures(int vCheck)
        {
            dtoDkHoc = new DANG_KI_HOC();
            boDangKiHoc = new BO_DANG_KI_HOC();
            dtoDiem = new DIEM();
            boDiem = new BO_DIEM();
            dtoDkHoc.DKH_Code = txtDKHCode.Text;
            dtoDkHoc.DKH_BienLai = txtSoBienLai.Text;
            dtoDkHoc.DKH_Diem = null;
            dtoDkHoc.DKH_LanThi = null;
            dtoDkHoc.DKH_LOPID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            dtoDkHoc.DKH_HOVID = gHocVienID;
            if (vCheck == 1)
            {
                //Lưu vào bảng đăng kí học
                boDangKiHoc.insert(dtoDkHoc);
                dtoDiem.DIE_CHCID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
                dtoDiem.DIE_LOPID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
                dtoDiem.DIE_HOVID = gHocVienID;
                dtoDiem.DIE_Diem = null;
                dtoDiem.DIE_LanThi = 1;
                dtoDiem.DIE_NgayNhapDiem = null;
                for (int ii = 0; ii < listSubject.ItemCount; ii++)
                {
                    if (listSubject.GetItemChecked(ii))
                    {
                        // Luu vao table Diem
                        dtoDiem.DIE_MONID = int.Parse(listSubject.GetItemValue(ii).ToString());
                        boDiem.insert(dtoDiem);
                    }
                }
            }
        }
        private void vCheckEnable(int vCheck)
        {
            if (vCheck == 1)
            {
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtPhone.Enabled = false;
                txtSoBienLai.Enabled = false;
                txtBirthDay.Enabled = false;
                lookUpBirthPlace.Enabled = false;
                lookUpDonvi.Enabled = false;
                txtAddress.Enabled = false;
                memoRemarks.Enabled = false;
                txtBirthDay.Enabled = false;
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;

                txtFirstName.BackColor = Color.White;
                txtLastName.BackColor = Color.White;
                txtPhone.BackColor = Color.White;
                txtSoBienLai.BackColor = Color.White;
                lookUpBirthPlace.BackColor = Color.White;
                lookUpDonvi.BackColor = Color.White;
                txtAddress.BackColor = Color.White;
                memoRemarks.BackColor = Color.White;
                txtBirthDay.BackColor = Color.White;
            }
            else
                if(vCheck == 2)
                {
                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                    txtPhone.Enabled = true;
                    txtSoBienLai.Enabled = true;
                    lookUpBirthPlace.Enabled = true;
                    lookUpDonvi.Enabled = true;
                    txtAddress.Enabled = true;
                    memoRemarks.Enabled = true;
                    txtBirthDay.Enabled = true;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                }
        }
        private void clearInputData(int vCheck)
        {
            if (vCheck == 1)
            {
                txtStudentCode.Text = string.Empty;
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtSoBienLai.Text = string.Empty;
                txtBirthDay.Text = string.Empty;
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.EditValue = null;
                //lookCcID.EditValue = string.Empty;
                memoRemarks.Text = string.Empty;
                //lookUpLop.EditValue = null;
            }
            if (vCheck == 2)
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtSoBienLai.Text = string.Empty;
                txtBirthDay.Text = string.Empty;
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.EditValue = null;
                //lookCcID.EditValue = null;
                memoRemarks.Text = string.Empty;
                //lookUpLop.EditValue = null;
            }
            if (vCheck == 3)
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtSoBienLai.Text = string.Empty;
                txtBirthDay.Text = string.Empty;
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.EditValue = null;
                memoRemarks.Text = string.Empty;
                //lookUpLop.EditValue = null;
            }
        }
        private void vCreateCodeHocVien()
        {
            boHocVien = new BO_HOCVIEN();
            DataTable tb = new DataTable();
            tb = boHocVien.get_HocCVien_LastCode();
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
            //mHvStatust = int.Parse(hVCode.ToString());
        }
        private void vGeneralCodeDangKiHocVien()
        {
            DataTable tb = new DataTable();
            boDangKiHoc = new BO_DANG_KI_HOC();
            tb = boDangKiHoc.getDanKiHoc_LastCode();
            string dkhCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                dkhCode = "000000";

            }
            else
            {
                dkhCode = tb.Rows[0]["DKH_Code"].ToString();
                dkhCode = dkhCode.Substring(3, 5);
            }

            txtDKHCode.Text = ("DKH" + Utilities.quydinh.LaySTT(int.Parse(dkhCode.ToString()) + 1)).ToString();
            //mDkhStatust = int.Parse(dkhCode.ToString());
        }
        private bool checkIdStudentBothGrid()
        {
            int scheck = 0;
            Dictionary<int, int> sTemList = new Dictionary<int, int>();
            for (int i = 0; i < grvRegisterContent.RowCount; i++)
            {
                sTemList.Add(int.Parse(grvRegisterContent.GetRowCellValue(i, "HOV_ID").ToString()), i);
            }
            foreach (var item in sTemList)
            {
                if (item.Key == gHocVienID)
                {
                    scheck++;
                }
            }
            if (scheck > 0)
            {
                return false;
            }
            else

                return true;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            vCheckEnable(2);
            vCreateCodeHocVien();
            vGeneralCodeDangKiHocVien();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputData(1);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void grvRegisterContent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow currentRow = grvRegisterContent.GetDataRow(e.RowHandle);
            gDangkiHocID = int.Parse(currentRow["DKH_ID"].ToString());
            gHocVienID = int.Parse(currentRow["HOV_ID"].ToString());
            txtStudentCode.Text = currentRow["HOV_Code"].ToString();
            txtFirstName.Text = currentRow["HOV_FirstName"].ToString();
            txtLastName.Text = currentRow["HOV_LastName"].ToString();
            txtBirthDay.EditValue = currentRow["HOV_BirthDay"].ToString();
            txtPhone.Text = currentRow["HOV_Phone"].ToString();
            txtSoBienLai.Text = currentRow["DKH_BienLai"].ToString();
            memoRemarks.Text = currentRow["HOV_GhiChu"].ToString();
            txtAddress.Text = currentRow["HOV_Address"].ToString();
            txtDKHCode.Text = currentRow["DKH_Code"].ToString();
            if (vLoadTinhThanh())
            {
                lookUpBirthPlace.EditValue = int.Parse(currentRow["HOV_NoiSinh"].ToString());
            }
            if (vLoadDonVi())
            {
                lookUpDonvi.EditValue = int.Parse(currentRow["HOV_DonVi"].ToString());
            }
            vCheckEnable(1);
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnEdit.Focus();
            btnCancel.Enabled = true;
            btnDelete.Enabled = true;
           
        }
    }
}
