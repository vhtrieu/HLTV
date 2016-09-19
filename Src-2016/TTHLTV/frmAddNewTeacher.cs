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
    public partial class frmAddNewTeacher : DevExpress.XtraEditors.XtraForm
    {
        BO_GIANGVIEN boGV = new BO_GIANGVIEN();
        public int sGetGridViewIndex;
        public string btnSender = string.Empty;
        public string sCode = string.Empty;
        public string sName = string.Empty;
        public string sDienThoai = string.Empty;
        public string sDiaChi = string.Empty;
        public string sKhoa = string.Empty;
        public int sId;
        public frmAddNewTeacher()
        {
            InitializeComponent();
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {

            if (btnSender == "Xem chi tiết" || btnSender == "Appearance")
            {
                updateData();

            }
            else
                if (btnSender == "Thêm mới")
                {
                    saveData();
                }

            DataTable tb = new DataTable();
            tb = getGiangVienCode();
            string lCode = String.Empty;
            string fCode = string.Empty;
            lCode = tb.Rows[0]["GIV_Code"].ToString();
            fCode = lCode.Substring(0, 7);
            lCode = lCode.Substring(7, 1);

            txtCode.Text = (fCode + (int.Parse(lCode.ToString()) + 1).ToString());
            clearInputData();
        }

        private void updateData()
        {
            string ssCode = string.Empty;
            string ssName = string.Empty;
            string ssAddress = string.Empty;
            string ssFone = string.Empty;
            string ssKhoa = string.Empty;

            ssCode = txtCode.Text;
            ssName = txtName.Text;
            ssAddress = txtAddress.Text;
            ssFone = txtFone.Text;
            ssKhoa = txtKhoa.Text;

            boGV.update(sId, ssCode, ssName,ssFone, ssAddress, ssKhoa);

        }
        private void saveData()
        {
            string ssCode = string.Empty;
            string ssName = string.Empty;
            string ssAddress = string.Empty;
            string ssFone = string.Empty;
            string ssKhoa = string.Empty;

            ssCode = txtCode.Text;
            ssName = txtName.Text;
            ssAddress = txtAddress.Text;
            ssFone = txtFone.Text;
            ssKhoa = txtKhoa.Text;

            boGV.insert(ssCode, ssName, ssFone, ssAddress, ssKhoa);

        }

        private DataTable getGiangVienCode()
        {
            DataTable tb = new DataTable();
            return tb = boGV.getGianngVien_LastCode();

        }

        void clearInputData()
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtFone.Text = string.Empty;
            txtKhoa.Text = string.Empty;

        }

        private void frmAddNewTeacher_Load(object sender, EventArgs e)
        {
             if (btnSender == "Xem chi tiết" || btnSender == "Appearance")
            {
                loadDataEdit();
            }
            else
                if (btnSender == "Thêm mới")
                {
                    sLoadNewCode();
                }
        }

        private void loadDataEdit()
        {
            txtCode.Text = sCode.ToString();
            txtName.Text = sName.ToString();
            txtAddress.Text = sDiaChi.ToString();
            txtFone.Text = sDienThoai.ToString();
            txtKhoa.Text = sKhoa.ToString();
           
        }

        private void sLoadNewCode()
        {
            txtCode.Text = "GV" + Utilities.quydinh.LaySTT(sGetGridViewIndex);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveClose_Click(object sender, EventArgs e)
        {

            if (btnSender == "Xem chi tiết" || btnSender == "Appearance")
            {
                updateData();

            }
            else
                if (btnSender == "Thêm mới")
                {
                    saveData();
                }

            this.Close();
            this.DialogResult = DialogResult.OK;

        }
        
    }
}