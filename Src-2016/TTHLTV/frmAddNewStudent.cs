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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace TTHLTV
{
    public partial class frmAddNewStudent : DevExpress.XtraEditors.XtraForm
    {
        BO_HOCVIEN boHv;
        HOCVIEN hocvien;
        public string btnSender = string.Empty;
        int sId;
        DataRow traineeRow;
        public DataRow vRow;
        public int sGetGridViewIndex;
        public bool vFlagSave = false;
        private Image Img;
        bool vFlagSaveImg = false;
        HOCVIEN_IMG DtoImg;
        BO_HOCVIEN_IMG BoImg;
        private int ImgID;
        byte[] imgArray;
        string vImgFileName;
        private bool ExistImg = false;
        public frmAddNewStudent(DataRow row)
        {
            traineeRow = row;
            InitializeComponent();
        }
        public frmAddNewStudent()
        {
            InitializeComponent();
        }

        private void frmDetailStudent_Load(object sender, EventArgs e)
        {

            if (btnSender == "Xem chi tiết" || btnSender == "Appearance")
            {

                sLoadTinh();
                sLoadDonVi();
                loadDataEdit();
            }
            else
                if (btnSender == "Thêm mới")
                {
                    sLoadDataToControl();
                }
        }
        private void loadDataByID()
        {
            boHv = new BO_HOCVIEN();
            hocvien = new HOCVIEN();
            hocvien.HOV_ID = sId = int.Parse(vRow["HOV_ID"].ToString());
            try
            {
                boHv.getHocVienByID(hocvien);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDataEdit()
        {
            sId = int.Parse(vRow["HOV_ID"].ToString());
            if (vRow["IMG_ID"].ToString() != string.Empty)
            {
                ImgID = int.Parse(vRow["IMG_ID"].ToString());
            }
            txtCode.Text = vRow["HOV_Code"].ToString();
            txtNameF.Text = vRow["HOV_FirstName"].ToString();
            txtNameL.Text = vRow["HOV_LastName"].ToString();
            txtBirthDay.Text = vRow["HOV_BirthDay"].ToString();
            txtAddress.Text = vRow["HOV_Address"].ToString();
            txtFone.Text = vRow["HOV_Phone"].ToString();
            txtGhiChu.Text = vRow["HOV_GhiChu"].ToString();
            if (sLoadTinh())
            {
                if (vRow["HOV_NoiSinh"].ToString() != string.Empty && vRow["HOV_NoiSinh"].ToString() != " ")
                {
                    lookUpBirthPlace.EditValue = int.Parse(vRow["HOV_NoiSinh"].ToString());
                }
            }
            if (sLoadDonVi())
            {
                if (vRow["HOV_DonVi"].ToString() != string.Empty && vRow["HOV_DonVi"].ToString() != " ")
                {
                    lookUpDonvi.EditValue = int.Parse(vRow["HOV_DonVi"].ToString());
                }
            }
            if (vRow["IMG_Image"] != DBNull.Value)
            {
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
        private void sLoadDataToControl()
        {
            txtCode.Text = "HV" + Utilities.quydinh.LaySTT(sGetGridViewIndex);

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {

            if (btnSender == "Xem chi tiết" || btnSender == "Appearance")
            {
                updateData();
            }
            else if (btnSender == "Thêm mới")
            {
                saveData();
                
            }
            if (vFlagSave == true && vImgFileName != null)
            {
                if (ExistImg == true)
                {
                    updateImg();
                }
                else
                    insertImg();
            }
            getHocVienCode();
            clearInputData();
        }
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (btnSender == "Xem chi tiết" || btnSender == "Appearance")
            {
                updateData();
            }
            else if (btnSender == "Thêm mới")
            {
                saveData();
            }
            if (vFlagSave == true && vImgFileName != null)
            {
                if (ExistImg == true)
                {
                    updateImg();
                }
                else
                    insertImg();
            }
            this.Close();
        }
        private bool updateData()
        {
            hocvien = new HOCVIEN();
            boHv = new BO_HOCVIEN();
            hocvien.HOV_Code = txtCode.Text;
            hocvien.HOV_FirstName = txtNameF.Text.Trim();
            hocvien.HOV_LastName = txtNameL.Text.Trim();
            hocvien.HOV_FullName = txtNameF.Text.Trim() + " " + txtNameL.Text.Trim();
            hocvien.HOV_BirthDay = txtBirthDay.Text;
            hocvien.HOV_Address = txtAddress.Text;
            hocvien.HOV_Phone = txtFone.Text;
            if (lookUpBirthPlace.ItemIndex < 0)
            {
                //sQueQuan = " ";
                MessageBox.Show("Chưa chọn nơi sinh", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return vFlagSave; ;
            }
            else
            {
                hocvien.HOV_NoiSinh = lookUpBirthPlace.GetColumnValue("TIN_ID").ToString();
            }
            if (lookUpDonvi.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn đơn vị", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return vFlagSave;
            }
            else
            {
                hocvien.HOV_DonVi = lookUpDonvi.GetColumnValue("DON_ID").ToString();
            }
            hocvien.HOV_GhiChu = txtGhiChu.Text.Trim();
            hocvien.HOV_QuocTich = txtQuocTich.Text.Trim();
            hocvien.HOV_ID = sId;
            try
            {
                boHv.update(hocvien);
                vFlagSave = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                vFlagSave = false;
            }
            return vFlagSave;
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
        private bool saveData()
        {
            hocvien = new HOCVIEN();
            boHv = new BO_HOCVIEN();
            hocvien.HOV_Code = txtCode.Text;
            hocvien.HOV_FirstName = txtNameF.Text.Trim();
            hocvien.HOV_LastName = txtNameL.Text.Trim();
            hocvien.HOV_FullName = txtNameF.Text.Trim() + " " + txtNameL.Text.Trim();
            hocvien.HOV_BirthDay = txtBirthDay.Text;
            hocvien.HOV_Address = txtAddress.Text;
            hocvien.HOV_Phone = txtFone.Text;
            if (lookUpBirthPlace.ItemIndex < 0)
            {
                //sQueQuan = " ";
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
            hocvien.HOV_GhiChu = txtGhiChu.Text.Trim();
            hocvien.HOV_QuocTich = txtQuocTich.Text.Trim();
            try
            {
                boHv.insert(hocvien);
                vFlagSave = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
            return vFlagSave;
        }
        private void getHocVienCode()
        {
            boHv = new BO_HOCVIEN();
            DataTable tb = new DataTable();
            tb = boHv.get_HocCVien_LastCode();
            string lCode = String.Empty;
            string fCode = string.Empty;
            lCode = tb.Rows[0]["HOV_Code"].ToString();
            fCode = lCode.Substring(0, 7);
            lCode = lCode.Substring(7, 1);
            txtCode.Text = (fCode + (int.Parse(lCode.ToString()) + 1).ToString());
        }
        void clearInputData()
        {
            txtNameF.Text = string.Empty;
            txtNameL.Text = string.Empty;
            txtBirthDay.Text = string.Empty;
            txtAddress.Text = string.Empty;
            lookUpBirthPlace.Text = string.Empty;
            txtFone.Text = string.Empty;
            lookUpDonvi.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }
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
            DtoImg.IMG_HOVID = sId;
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
            DtoImg.IMG_HOVID = sId;
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
        #endregion
    }
}