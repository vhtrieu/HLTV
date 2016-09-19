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
    public partial class frmChucDanh : DevExpress.XtraEditors.XtraForm
    {
        BO_CHUCDANH boCd = new BO_CHUCDANH();
        public frmChucDanh()
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

            boCd.insert(sCode, sName);
        }
        private void sLoadChucDanh()
        {
            gridChucDanh.DataSource = boCd.getAll();
        }
        private void sGeneralCode()
        {
            DataTable tb = new DataTable();
            tb = boCd.getChucDanh_LastCode();
            string lCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                lCode = "000000";
            }
            else
                if (tb.Rows.Count > 0)
                {
                    lCode = tb.Rows[0]["CHU_Code"].ToString();
                }

            txtCode.Text = ("CHU" + quydinh.LaySTT(int.Parse(lCode.ToString().Substring(3, 5)) + 1)).ToString();
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
        private void frmChucDanh_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridChucDanh.MainView, new Font("Tahoma", 11));
            sLoadChucDanh();
            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
        }
        private void grivChucDanh_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow sSelectRow = grivChucDanh.GetDataRow(e.RowHandle);

            txtCode.Text = sSelectRow["CHU_Code"].ToString();
            txtName.Text = sSelectRow["CHU_Name"].ToString();

            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnCancel.Enabled = false;
            sCheckEnableControl(1);
        }
        #endregion

      
    }
}