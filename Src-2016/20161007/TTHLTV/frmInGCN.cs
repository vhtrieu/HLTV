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
    public partial class frmInGCN : DevExpress.XtraEditors.XtraForm
    {
        public frmInGCN()
        {
            InitializeComponent();
        }

        private void frmInGCN_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
       
    }
}