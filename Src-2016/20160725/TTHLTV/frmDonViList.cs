using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using TTHLTV.Utilities;

namespace TTHLTV
{
    public partial class frmDonViList : DevExpress.XtraEditors.XtraForm
    {
        BO_DONVI boDonvi = new BO_DONVI();
        public frmDonViList()
        {
            InitializeComponent();
        }
        
        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDonViList_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridDonVi.MainView, new Font("Tahoma", 11));
            sLoadDonVi();
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            sSave();
            sLoadDonVi();
        }
        private void grivDonvi_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow sSelectRow = grivDonvi.GetDataRow(e.RowHandle);

            txtCode.Text = sSelectRow["DON_Code"].ToString();
            txtName.Text = sSelectRow["DON_Name"].ToString();
            txtDiaChi.Text = sSelectRow["DON_DiaChi"].ToString();
            txtDienThoai.Text = sSelectRow["DON_Phone"].ToString();
            txtFax.Text = sSelectRow["DON_Fax"].ToString();
            txtGhiChu.Text = sSelectRow["DON_GhiChu"].ToString();
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            sCheckEnableControl(1);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            sClearControl();
            sGeneralCode();
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            sClearControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            sCheckEnableControl(2);
        }

        #endregion

        #region Extenal function
        private void sSave()
        {
            string sCode;
            string sName;
            string sDiaChi;
            string sFone;
            string sFax;
            string sGhichu;
            sCode = txtCode.Text;
            sName = txtName.Text;
            sDiaChi = txtDiaChi.Text;
            sFone = txtDienThoai.Text;
            sFax = txtFax.Text;
            sGhichu = txtGhiChu.Text;

            boDonvi.insert(sCode, sName, sDiaChi, sFone, sFax, sGhichu);
        }
        private void sLoadDonVi()
        {
            gridDonVi.DataSource = boDonvi.getAll();
        }
        private void sGeneralCode()
        {
            DataTable tb = new DataTable();
            tb = boDonvi.getDonVi_LastCode();
            string lCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                lCode = "000000";
            }
            else
                if (tb.Rows.Count > 0)
                {
                    lCode = tb.Rows[0]["DON_Code"].ToString();
                }

            txtCode.Text = ("DOV" + quydinh.LaySTT(int.Parse(lCode.ToString().Substring(3, 5)) + 1)).ToString();
            //sStatust = int.Parse(lCode.ToString());
        }
        private void sClearControl()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }


        private void sCheckEnableControl(int sCheck)
        {
            if (sCheck == 1)
            {
                //txtCode.Enabled = false;
                txtName.Enabled = false;
                txtDiaChi.Enabled = false;
                txtDienThoai.Enabled = false;
                txtFax.Enabled = false;
                txtGhiChu.Enabled = false;

                //txtCode.BackColor = Color.White;
                txtName.BackColor = Color.White;
                txtDiaChi.BackColor = Color.White;
                txtDienThoai.BackColor = Color.White;
                txtFax.BackColor = Color.White;
                txtGhiChu.BackColor = Color.White;

            }
            else if (sCheck == 2)
            {
                //txtCode.Enabled = true;
                txtName.Enabled = true;
                txtDiaChi.Enabled = true;
                txtDienThoai.Enabled = true;
                txtFax.Enabled = true;
                txtGhiChu.Enabled = true;

                //txtCode.BackColor = Color.White;
                txtName.BackColor = Color.White;
                txtDiaChi.BackColor = Color.White;
                txtDienThoai.BackColor = Color.White;
                txtFax.BackColor = Color.White;
                txtGhiChu.BackColor = Color.White;
            }

        }
        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = grivDonvi.GetDataRow(grivDonvi.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn đơn vị này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int dvId = int.Parse(selectedRow["DON_ID"].ToString());
                    selectedRow.Delete();
                    boDonvi.delete(dvId);
                    sLoadDonVi();
                }
            }
        }


    }
}