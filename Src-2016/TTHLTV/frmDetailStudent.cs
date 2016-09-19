using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TTHLTV
{
    public partial class frmDetailStudentOLD : DevExpress.XtraEditors.XtraForm
    {
        DataRow traineeRow;
        public frmDetailStudentOLD(DataRow row)
        {
            traineeRow = row;
            InitializeComponent();
        }
        public frmDetailStudentOLD()
        {
            InitializeComponent();
        }
    

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetailStudent_Load(object sender, EventArgs e)
        {
            sLoadDataToControl();
            
        }
        /// <summary>
        /// Load data to all control on form
        /// </summary>
        private void sLoadDataToControl()
        {
            //txtStuCode.Text = traineeRow["TRE_Code"].ToString();
            //txtStuName.Text = traineeRow["TRE_FullName"].ToString();
            //txtStuCertify.Text = traineeRow["TRE_Certificates"].ToString();
            //txtStuFone.Text = traineeRow["TRE_Phone"].ToString();
            //txtStuPlaceOfBirth.Text = traineeRow["TRE_PlaceOfBirth"].ToString();
            //txtStuAddress.Text = traineeRow["TRE_Address"].ToString();
 
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }
    }
}