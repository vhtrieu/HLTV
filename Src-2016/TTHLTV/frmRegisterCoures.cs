using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using TTHLTV.BAL;
using DevExpress.Utils;
using TTHLTV.Utilities;
using TTHLTV.DTO;
using System.IO;
namespace TTHLTV
{
    public partial class frmRegisterChangeCertificate : DevExpress.XtraEditors.XtraForm
    {
        //BO_DANG_KI_HOC dao_dangki_hoc = new BO_DANG_KI_HOC();
        BO_HOCVIEN boHv;
        HOCVIEN hocvien;
        BO_CAP_CHUNGCHI boCcc = new BO_CAP_CHUNGCHI();
        BO_DANG_KI_HOC boDkHoc;
        DANG_KI_HOC dtoDkHoc;
        BO_DIEM boDiem;
        DIEM dtoDiem;
        private int gIDHocVien = -1;
        bool flagSave = false;
        private const int id = -1;
        private int mHvStatust;
        private int mDkhStatust;
        private int mDkhId = -1;
        private SimpleButton mStatusSave ;
        static DataTable hvTable = new DataTable();
        public bool vFlagSave = false;
        private Image Img;
        bool vFlagSaveImg = false;
        HOCVIEN_IMG DtoImg;
        BO_HOCVIEN_IMG BoImg;
        private int ImgID;
        byte[] imgArray;
        string vImgFileName;
        private bool ExistImg = false;
        private bool vFlagNewImg = false;
        public frmRegisterChangeCertificate()
        {
            InitializeComponent();
        }

        #region Events
        private void frmRegisterStudent_Load(object sender, EventArgs e)
        {
            sCheckEnable(1);
            if (loadKhoaHoc())
            {
                sLoadDonVi();
                sLoadTinh();
            }
            sGeneralCodeDangKiHocVien(); 
            sSearchTool();
            setFontSize.SetGridFont(gridRegister.MainView, new Font("Tahoma", 11));
            setFontSize.SetGridFont(gridStudents.MainView, new Font("Tahoma", 11));
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            loadDefaultImage();
        }

        private void lookCcID_EditValueChanged(object sender, EventArgs e)
        {
            if (lookCcID.ItemIndex > id)
            {
                loadLopHoc(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()));
                sLoadSubject();
            }
        }

        private void lookUpLop_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpLop.ItemIndex > id)
            {
                // load dateAllocate and dateExpire
                loadDuration();
                // load data to grid
                loadDataToGrid();
                txtFirstName.Focus();
                sCounter();
                loadDefaultImage();
            }
        }

        private void grvRegisterContent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow currentRow = grvRegisterContent.GetDataRow(e.RowHandle);
            mDkhId = int.Parse(currentRow["DKH_ID"].ToString());
            gIDHocVien = int.Parse(currentRow["HOV_ID"].ToString());
            txtStudentCode.Text = currentRow["HOV_Code"].ToString();
            txtFirstName.Text = currentRow["HOV_FirstName"].ToString();
            txtLastName.Text = currentRow["HOV_LastName"].ToString();
            txtBirthDay.EditValue = currentRow["HOV_BirthDay"].ToString();
            txtPhone.Text = currentRow["HOV_Phone"].ToString();
            txtSoBienLai.Text = currentRow["DKH_BienLai"].ToString();
            memoRemarks.Text = currentRow["HOV_GhiChu"].ToString();
            txtAddress.Text = currentRow["HOV_Address"].ToString();
            txtDKHCode.Text = currentRow["DKH_Code"].ToString();
            if (sLoadTinh())
            {
                lookUpBirthPlace.EditValue = int.Parse(currentRow["HOV_NoiSinh"].ToString());
            }
            if (sLoadDonVi())
            {
                lookUpDonvi.EditValue = int.Parse(currentRow["HOV_DonVi"].ToString());
            }
            //Load image hocvien
            loadImage(currentRow);

            sCheckEnable(1);
            btnEdit.Enabled = true;
            btnEdit.Focus();
            btnSave.Enabled = false;
            btnCancel.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                lookCcID.ClosePopup();
                lookCcID.EditValue = null;
                lookUpLop.ClosePopup();
                lookUpLop.EditValue = null;
                lookUpBirthPlace.ClosePopup();
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.ClosePopup();
                lookUpDonvi.EditValue = null;
                txtDateAllocate.Enabled = false;
                txtDateAllocate.BackColor = Color.White;
                txtDateExpire.Enabled = false;
                txtDateExpire.BackColor = Color.White;
                txtDateAllocate.Text = string.Empty;
                txtDateExpire.Text = string.Empty;
                //dateBirthDay.Text = string.Empty;
                gridRegister.DataSource = null;
                return;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SimpleButton statustUpdate = (SimpleButton)sender;
            mStatusSave = statustUpdate;
            sCheckEnable(2);
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            txtDateExpire.Enabled = false;
            txtDateExpire.BackColor = Color.White;
            txtDateAllocate.Enabled = false;
            txtDateAllocate.BackColor = Color.White;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lookCcID.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn loại chứng chỉ", "THÔNG BÁO");
                return;
            }
            if (lookUpLop.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn một lớp học", "THÔNG BÁO");
            }
            if (txtBirthDay.Text == string.Empty)
            {
                MessageBox.Show("Nhập ngày sinh của học viên", "THÔNG BÁO");
            }
            if (mStatusSave.Text == "Thêm mới")
            {
                // Them mot hoc vien moi hoan toan
                if (int.Parse(txtStudentCode.Text.Substring(3, 5).ToString()) == mHvStatust + 1 && checkFullName())
                {
                    if (sSaveStudents(1))
                    {
                        sSaveRegisterCoures(1);
                    }
                    else
                        return;
                }
                else
                {
                    string messages = "Học viên này đã đăng kí học ở trung tâm,\n bạn có chắc chắn muốn thêm mới không? ";
                    string caption = " THÔNG BÁO ";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(messages, caption, button);
                    if (result == DialogResult.Yes)
                    {
                        // Dong y them moi vao table HOCVIEN
                        sSaveStudents(1);
                        sSaveRegisterCoures(1);
                    }
                    else
                    {// Không thêm học viên mới - thì đăng kí học viên cũ vào DANG_KI_HOC và bảng DIEM
                        if (checkIdStudentBothGrid() == true)
                        {
                            sSaveRegisterCoures(1);
                        }
                        else
                        {
                            MessageBox.Show("Mã học viên này đã được đăng kí vào lớp ( " + lookUpLop.GetColumnValue("LOP_Name") + " )");
                            return;
                        }
                    }
                }
                sGeneralCodeHocVien();
                sGeneralCodeDangKiHocVien();
            }
            else if (mStatusSave.Text == "Sửa thông tin")
            {
                sSaveStudents(2); // Hãy cập nhật từ danh sách học viên
                sSaveRegisterCoures(2); // Update học viên đăng kí học
                //clearInputData(1);
            }
            if (vFlagNewImg==true)
            {
                if (ExistImg == true)
                {
                    updateImg();
                }
                else
                {
                    insertImg();
                }
                vFlagNewImg = false;
                ExistImg = false;
            }
            clearInputData(2);
            loadDataToGrid();
            sCounter();
            sCheckEnable(2);
            txtFirstName.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputData(1);
            lookCcID.Properties.NullText = "Chọn khóa học";

            SimpleButton sBtn = (SimpleButton)sender;
            if (sBtn.Text == "Không lưu")
            {
                lookCcID.CancelPopup();
                lookCcID.EditValue = null;
                lookUpLop.CancelPopup();
                lookUpLop.EditValue = null;
                lookUpBirthPlace.CancelPopup();
                lookUpBirthPlace.EditValue = null;
                lookUpDonvi.CancelPopup();
                lookUpDonvi.EditValue = null;
                btnNew.Enabled = true;
                btnDelete.Enabled = false;
                sGeneralCodeHocVien();
                loadDefaultImage();
                return;
            }

        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckRadiDonVi();
           
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            boDkHoc = new BO_DANG_KI_HOC();
            boDiem = new BO_DIEM();
            DataRow selectedRow = grvRegisterContent.GetDataRow(grvRegisterContent.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa học viên này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int lopId = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
                    int hvId = int.Parse(selectedRow["HOV_ID"].ToString());
                    int vDkhID = int.Parse(selectedRow["DKH_ID"].ToString());
                    selectedRow.Delete();
                    boDkHoc.vDeletedHvInDangKiHoc(vDkhID);
                    boDiem.delete_DIEM_By_HVID(lopId, hvId);
                    //Call  Delete in table CAP_CHUNGCHI
                    boDkHoc.DeleteCAP_CHUNGCHI_By_HovID(lopId, hvId);
                    clearInputData(1);
                    loadDataToGrid();
                    lookUpLop.ClosePopup();
                    lookUpBirthPlace.ClosePopup();
                    lookUpDonvi.ClosePopup();
                    lookUpBirthPlace.EditValue = null;
                    lookUpDonvi.EditValue = null;
                    sResultSearchByFirstName();
                    sCounter();
                }
            }
        }
        private void txtSearchText_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            boDkHoc = new BO_DANG_KI_HOC();
            //if ( int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()) <-1 && int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString()) < -1)
            if (int.Parse(lookCcID.ItemIndex.ToString()) < 0 && int.Parse(lookUpLop.ItemIndex.ToString()) < 0)
            {
                MessageBox.Show("Chọn khóa học, và lớp học muốn tìm kiếm học viên", "THÔNG BÁO");
                return;
            }
            else
            {
                if (txtSearchText.Text == string.Empty)
                {
                    // ((DataTable)gridCertificate.DataSource).Rows.Clear();
                    loadDataToGrid();

                }
                else
                    if (txtSearchText.Text != string.Empty)
                    {
                        gridRegister.DataSource = boDkHoc.search_StudentLastName_In_DKH_New(int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text);
                    }

            }

        }
        private void txtFirstName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (txtFirstName.Text == string.Empty)
            {
                return;

            }
            else
            {
                sResultSearchByFirstName();
            }

        }
        private void txtLastName_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (txtLastName.Text == string.Empty)
            {
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
            txtStudentCode.Text = currentRow["HOV_Code"].ToString();
            txtFirstName.Text = currentRow["HOV_FirstName"].ToString();
            txtLastName.Text = currentRow["HOV_LastName"].ToString();
            txtBirthDay.EditValue = currentRow["HOV_BirthDay"].ToString();
            txtPhone.Text = currentRow["HOV_Phone"].ToString();
            txtAddress.Text = currentRow["HOV_Address"].ToString();
            if (sLoadTinh())
            {
                if (currentRow["HOV_NoiSinh"].ToString()!=string.Empty && currentRow["HOV_NoiSinh"].ToString() != " ")
                {
                    lookUpBirthPlace.EditValue = int.Parse(currentRow["HOV_NoiSinh"].ToString());
                }
                
            }
            if (sLoadDonVi())
            {
                if (currentRow["HOV_DonVi"].ToString()!=string.Empty && currentRow["HOV_DonVi"].ToString() != " ")
                {
                    lookUpDonvi.EditValue = int.Parse(currentRow["HOV_DonVi"].ToString());
                }
                
            }
            //Load image hocvien
            loadImage(currentRow);
            btnSave.Enabled = true;
            btnSave.Focus();
            btnCancel.Enabled = true;
        }
        #endregion

        #region Extenal functions

        private void sCounter()
        {
            lblCounter.Text = " Tổng số học viên trong lớp: " + grvRegisterContent.RowCount + " ";
            lblCounter.BackColor = Color.White;
            lblCounter.ForeColor = Color.Red;
        }
        private void CheckRadiDonVi()
        {
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
        private bool loadKhoaHoc()
        {
            BAL.BO_CHUNG_CHI bal = new BO_CHUNG_CHI();
            DataTable vtb = new DataTable();
            vtb = bal.getChungChi_All();
            if (vtb.Rows.Count > 0)
            {
                lookCcID.Properties.DataSource = vtb.DefaultView;
                lookCcID.Properties.ValueMember = "CHC_ID";
                lookCcID.Properties.DisplayMember = "CHC_Name";
                return true;
            }
            else
                return false;
        }
        private DataTable getLopHoc(int lookCcID_selected_index)
        {
            BAL.BO_LOP bal = new BO_LOP();
            return bal.getLOP_ByCcID(lookCcID_selected_index);
        }
        private void loadLopHoc(int lookCcID_selected_index)
        {
            lookUpLop.Properties.DataSource = getLopHoc(lookCcID_selected_index);
            lookUpLop.Properties.ValueMember = "LOP_ID";
            lookUpLop.Properties.DisplayMember = "LOP_Name";
        }
        private void loadDuration()
        {
            int LOP_ID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            BAL.BO_LOP dao_lop = new BO_LOP();
            DataRow row = dao_lop.getLOP_ByID(LOP_ID).Rows[0];// search by ID, so there is only one row
            DateTime DateAllocate = Convert.ToDateTime(row["LOP_Ngay_KG"].ToString());
            DateTime DateExpire = Convert.ToDateTime(row["LOP_Ngay_KT"].ToString());
            txtDateAllocate.Text = DateAllocate.ToString("dd/MM/yyyy");
            txtDateExpire.Text = DateExpire.ToString("dd/MM/yyyy");

        }
        private void loadDataToGrid()
        {
            boDkHoc = new BO_DANG_KI_HOC();
            dtoDkHoc = new DANG_KI_HOC();
            DataTable vtb = new DataTable();
            dtoDkHoc.DKH_LOPID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            vtb = boDkHoc.getCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC(dtoDkHoc);
            if (vtb.Rows.Count > 0)
            {
                gridRegister.DataSource = vtb.DefaultView;
            }
            else
                gridRegister.DataSource = null;
           
        }
        private void sCheckEnable(int sCheck)
        {
            if (sCheck == 1)
            {
                txtDateAllocate.Enabled = false;
                txtDateExpire.Enabled = false;
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
                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                    
                txtDateAllocate.BackColor = Color.White;
                txtDateExpire.BackColor = Color.White;
                txtFirstName.BackColor = Color.White;
                txtLastName.BackColor = Color.White;
                txtPhone.BackColor = Color.White;
                txtSoBienLai.BackColor = Color.White;
                //dateBirthDay.BackColor = Color.White;
                lookUpBirthPlace.BackColor = Color.White;
                lookUpDonvi.BackColor = Color.White;
                txtAddress.BackColor = Color.White;
                memoRemarks.BackColor = Color.White;
                txtBirthDay.BackColor = Color.White;

            }
            else
                if (sCheck == 2)
                {
                    txtDateAllocate.Enabled = true;
                    txtDateExpire.Enabled = true;
                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                    txtPhone.Enabled = true;
                    txtSoBienLai.Enabled = true;
                    lookUpBirthPlace.Enabled = true;
                    lookUpDonvi.Enabled = true;
                    txtAddress.Enabled = true;
                    memoRemarks.Enabled = true;
                    txtBirthDay.Enabled = true;
                }
        }
        private void sLoadSubject()
        {
            boDkHoc = new BO_DANG_KI_HOC();
            listSubject.DataSource = boDkHoc.getSubjectName(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()));
            listSubject.ValueMember = "MON_ID";
            listSubject.DisplayMember = "MON_Name";
            listSubject.CheckAll();

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
            sTable.Rows.Add(1, "Tên học viên");
            sTable.Rows.Add(2, "Họ và tên đệm");
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
        private bool sSaveStudents(int sCheck)
        {
            hocvien = new HOCVIEN();
            boHv = new BO_HOCVIEN();
            hocvien.HOV_Code = txtStudentCode.Text;
            hocvien.HOV_FirstName = txtFirstName.Text.Trim();
            hocvien.HOV_LastName = txtLastName.Text.Trim();
            hocvien.HOV_FullName = txtFirstName.Text.Trim() +" " + txtLastName.Text.Trim();
            hocvien.HOV_BirthDay = txtBirthDay.Text;
            hocvien.HOV_Address = txtAddress.Text;
            hocvien.HOV_Phone = txtPhone.Text;
            hocvien.HOV_GhiChu = memoRemarks.Text.Trim();
            hocvien.HOV_QuocTich = txtQuocTich.Text.Trim();
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
            
            if (sCheck == 1)
            {
               gIDHocVien= boHv.insert(hocvien);
               flagSave = true;
            }
            else
                if (sCheck == 2)
                {
                    hocvien.HOV_ID = gIDHocVien;
                    boHv.update(hocvien);
                    loadDataToGrid();
                }
            return flagSave;
        }
        private void sSaveRegisterCoures(int sCheck)
        {
            dtoDkHoc = new DANG_KI_HOC();
            boDkHoc = new BO_DANG_KI_HOC();
            dtoDiem = new DIEM();
            boDiem = new BO_DIEM();
            dtoDkHoc.DKH_Code = txtDKHCode.Text;
            dtoDkHoc.DKH_BienLai = txtSoBienLai.Text;
            dtoDkHoc.DKH_Diem = null;
            dtoDkHoc.DKH_LanThi = null;
            dtoDkHoc.DKH_LOPID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            dtoDkHoc.DKH_HOVID = gIDHocVien;
            if (sCheck == 1)
            {
                // Lay lai ID hoc vien o day de insert vao bang diem.
                boDkHoc.insert(dtoDkHoc);

                dtoDiem.DIE_CHCID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
                dtoDiem.DIE_LOPID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
                dtoDiem.DIE_HOVID = gIDHocVien;
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
            else if (sCheck == 2)
                {
                    dtoDkHoc.DKH_ID = mDkhId;
                    boDkHoc.update(dtoDkHoc);
                    MessageBox.Show("Cập nhập thông tin thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
        private void sGeneralCodeHocVien()
        {
            boHv = new BO_HOCVIEN();
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
            DataTable tb = new DataTable();
            boDkHoc = new BO_DANG_KI_HOC();
            tb = boDkHoc.getDanKiHoc_LastCode();
            string dkhCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                dkhCode = "000000";

            }
            else if(tb.Rows[0]["DKH_Code"].ToString()!=string.Empty)
            {
                dkhCode = tb.Rows[0]["DKH_Code"].ToString();
                dkhCode = dkhCode.Substring(3, 5);
                txtDKHCode.Text = ("DKH" + Utilities.quydinh.LaySTT(int.Parse(dkhCode.ToString()) + 1)).ToString();
                mDkhStatust = int.Parse(dkhCode.ToString());
            }
        }
        private void sResultSearchByFirstName()
        {
            boHv = new BO_HOCVIEN();
            string fullName = string.Empty;
            if (txtFirstName.Text != "")
            {
                fullName = txtFirstName.Text + " " + txtLastName.Text;
                hvTable = boHv.searchHocVienByFullName(fullName);
                gridStudents.DataSource = hvTable;
            }
            else
            {
                return;
            }
            

        }
        private void clearInputData(int sCheck)
        {
            if (sCheck==1)
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtDateExpire.Text = string.Empty;
                txtDateAllocate.Text = string.Empty;
                txtStudentCode.Text = string.Empty;
                if (chckDienThoai.Checked==false)
                {
                    txtPhone.Text = string.Empty;
                }
                txtAddress.Text = string.Empty;
                if (chckBienLai.Checked ==false)
                {
                    txtSoBienLai.Text = string.Empty;
                }
                txtBirthDay.Text = string.Empty;
                lookUpBirthPlace.CancelPopup();
                lookUpDonvi.CancelPopup();
                txtAddress.Text = string.Empty;
                lookUpLop.CancelPopup();
                lookCcID.CancelPopup();
                if (chckRemark.Checked==false)
                {
                    memoRemarks.Text = string.Empty;
                }
                
            }
            else
                if (sCheck==2)
                {
                    txtFirstName.Text = string.Empty;
                    txtLastName.Text = string.Empty;
                    txtPhone.Text = string.Empty;
                    txtBirthDay.Text = string.Empty;
                    //txtDateExpire.Text = string.Empty;
                    //txtDateAllocate.Text = string.Empty;
                    //txtStudentCode.Text = string.Empty;
                    //txtDKHCode.Text = string.Empty;
                    if (chckDienThoai.Checked == false)
                    {
                        txtPhone.Text = string.Empty;
                    }
                    txtAddress.Text = string.Empty;
                    if (chckBienLai.Checked == false)
                    {
                        txtSoBienLai.Text = string.Empty;
                    }
                    lookUpBirthPlace.CancelPopup();
                    lookUpBirthPlace.EditValue = -1;
                    lookUpDonvi.CancelPopup();
                    lookUpDonvi.EditValue = -1;
                    txtAddress.Text = string.Empty;
                    lookUpLop.CancelPopup();
                    lookCcID.CancelPopup();
                    if (chckRemark.Checked==false)
                    {
                        memoRemarks.Text = string.Empty;   
                    }
                }
            loadDefaultImage();
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
                if (item.Key == gIDHocVien)
                {
                    scheck++;
                }
            }
            if (scheck>0)
            {
                return false;
            }
            else

            return true;
        }
        private bool checkFullName()
        {
            string strFirstName = txtFirstName.Text.Trim();
            string strLastName = txtLastName.Text.Trim();
            string strFullName = strFirstName + " " + strLastName;
            string strNgaySinh = txtBirthDay.Text;
            DataTable tb = hvTable;// mTableChungChiDoi;
            // mTableChungChiDoi phải là dữ liệu của toàn bộ học viên đã có tại trung tâm
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
                        //if (DialogResult.No == MessageBox.Show("Học viên " + strFullName + ", sinh ngày " + strNgaySinh + " đã tồn tại trong hệ thống.", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                        //{
                            return false;
                        //}
                    }
                }

            }
            return true;
        }
        private bool vCheckIsNumber(string vStr)
        {
            if (Tool.isNumber(vStr))
                return true;
            else
                return false;
            
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
                vFlagNewImg = true;
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
                ExistImg = true;
            }
            else
            {
                loadDefaultImage();
                ExistImg = false;
            }
        }
        #endregion

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
   
}
