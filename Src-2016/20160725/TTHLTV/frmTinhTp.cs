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
    public partial class frmTinhTp : DevExpress.XtraEditors.XtraForm
    {
        BO_TINH boTinh = new BO_TINH();
        public frmTinhTp()
        {
            InitializeComponent();
        }

        #region Extenal function
        private void sSave()
        {
            string sCode;
            string sName;
            sCode = txtCode.Text;
            sName = txtName.Text;

            boTinh.insert(sCode, sName);
        }
        private void sLoadChucDanh()
        {
            gridTinh.DataSource = boTinh.getTinh_All();
        }
        private void sGeneralCode()
        {
            DataTable tb = new DataTable();
            tb = boTinh.getTinh_LastCode();
            string lCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                lCode = "000000";
            }
            else
                if (tb.Rows.Count > 0)
                {
                    lCode = tb.Rows[0]["TIN_Code"].ToString();
                }

            txtCode.Text = ("TIN" + quydinh.LaySTT(int.Parse(lCode.ToString().Substring(3, 5)) + 1)).ToString();
            //sStatust = int.Parse(lCode.ToString());
        }
        private void sClearControl()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;

        }

        private void sCheckEnableControl(int sCheck)
        {
            if (sCheck == 1)
            {
                // txtCode.Enabled = false;
                txtName.Enabled = false;

                //txtCode.BackColor = Color.White;
                txtName.BackColor = Color.White;

            }
            else if (sCheck == 2)
            {
                //txtCode.Enabled = true;
                txtName.Enabled = true;

                // txtCode.BackColor = Color.White;
                txtName.BackColor = Color.White;
            }

        }
        #endregion
        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            sClearControl();
            sGeneralCode();
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            sCheckEnableControl(2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sSave();
            sLoadChucDanh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            sClearControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTinhTp_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridTinh.MainView, new Font("Tahoma", 11));
            sLoadChucDanh();
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
        }

        private void grivTinh_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow sSelectRow = grivTinh.GetDataRow(e.RowHandle);

            txtCode.Text = sSelectRow["TIN_Code"].ToString();
            txtName.Text = sSelectRow["TIN_Name"].ToString();

            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnCancel.Enabled = false;
            sCheckEnableControl(1);
        }
        #endregion

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnStuDelete_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = grivTinh.GetDataRow(grivTinh.FocusedRowHandle);
            int tinhID = int.Parse(selectedRow["TIN_ID"].ToString());
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa học viên này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    selectedRow.Delete();
                    boTinh.delete(tinhID);
                }
            }
           
        }
    }
}