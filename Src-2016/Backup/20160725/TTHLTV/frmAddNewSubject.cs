using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
//using Entetities;
using DevExpress.XtraEditors.Mask;

namespace TTHLTV
{
    public partial class frmAddNewSubject : DevExpress.XtraEditors.XtraForm
    {
        BO_MONHOC boMh = new BO_MONHOC();
        public string btnSender = string.Empty;
        public int sgetIndexGrid;
        public string sCode = string.Empty;
        public string sName = string.Empty;
        public int sSoTiet;
        public int sId;

        public frmAddNewSubject()
        {
            InitializeComponent();
        }

        public void sGeneralSubjectCode()
        {
             
            txtCode.Text = "MH" + Utilities.quydinh.LaySTT(sgetIndexGrid);
        }

        private void frmAddNewSubject_Load(object sender, EventArgs e)
        {
            if (btnSender == "Xem chi tiết" || btnSender == "Appearance")
            {
                loadDataEdit();
            }
            else
                if (btnSender == "Thêm mới")
                {
                    sGeneralSubjectCode();
                }

            sCheckNumber();
        }

       

        private void loadDataEdit()
        {
            txtCode.Text = sCode.ToString();
            txtName.Text = sName.ToString();
            txtSoTiet.Text = sSoTiet.ToString();
        }

        private Boolean sCheckNumber()
        {
            // Only allow input numberic
            txtSoTiet.Properties.Mask.MaskType = MaskType.Numeric;
            return true;

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
        private void updateData()
        {
            string sCode = string.Empty;
            string sName = string.Empty;
            int sSotiet;

            sCode = txtCode.Text;
            sName = txtName.Text;
            sSotiet = int.Parse( txtSoTiet.Text);
            boMh.update( sId, sCode, sName, sSotiet);

        }

        private void saveData()
        {
            string sCode = string.Empty;
            string sName = string.Empty;
            int sSotiet;

            sCode = txtCode.Text;
            sName = txtName.Text;
            sSotiet = int.Parse(txtSoTiet.Text);

            boMh.insert(sCode, sName, sSotiet);

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

            //this.Close();
            //this.DialogResult = DialogResult.OK;
            //sLoadDataToControl();
            DataTable tb = new DataTable();
            tb = getMonHocCode();
            string lCode = String.Empty;
            string fCode = string.Empty;
            lCode = tb.Rows[0]["MON_Code"].ToString();
            fCode = lCode.Substring(0, 7);
            lCode = lCode.Substring(7, 1);

            txtCode.Text = (fCode + (int.Parse(lCode.ToString()) + 1).ToString());
            txtName.Text = "";
            txtSoTiet.Text = "";
        }

        private DataTable getMonHocCode()
        {
            DataTable tb = new DataTable();
            return tb = boMh.getMonHoc_LastCode();

        }
    }
}