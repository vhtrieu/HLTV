using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TTHLTV.BAL;
namespace TTHLTV
{
    public partial class frmUpdateDoiID : Form
    {
        public frmUpdateDoiID()
        {
            InitializeComponent();
        }
        BAL.BO_CHUNG_CHI boCc = new BO_CHUNG_CHI();
        BAL.BO_CAP_CHUNGCHI boCcs = new BO_CAP_CHUNGCHI();
        BAL.BO_LOP boLop = new BO_LOP();
        BO_MONHOC boMonHoc = new BO_MONHOC();
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        BO_DIEM boDiem = new BO_DIEM();
        private void vLoadChungChi()
        {
            lookChungChi.Properties.DataSource =  boCc.getChungChi_All();
            lookChungChi.Properties.ValueMember = "CHC_ID";
            lookChungChi.Properties.DisplayMember = "CHC_Name";
        }

        private void frmUpdateDoiID_Load(object sender, EventArgs e)
        {
            vLoadChungChi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void lookChungChi_EditValueChanged(object sender, EventArgs e)
        {
            int CcId = -1;
            DataTable tb = new DataTable();
            if (lookChungChi.ItemIndex > -1)
            {
                CcId = int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString());
                tb = boCcs.vLoadIdDoi(CcId);
                if (tb.Rows.Count > 0)
                {
                    gridStudents.DataSource = tb.DefaultView;

                }
                else
                    gridStudents.DataSource = null;
            }
            label1.Text = tb.Rows.Count.ToString();
        }
        private bool vUpdateDoiID()
        {
            bool flagUpdate = false;
            int vDoiID;
            int vCccID;
            if (gridContentStudents.RowCount > 0)
            {
                for (int i = 0; i < gridContentStudents.RowCount; i++)
                {
                    DataRow dr = gridContentStudents.GetDataRow(i);
                    vDoiID = int.Parse(dr["DOI_ID"].ToString());
                    vCccID = int.Parse(dr["CCC_ID"].ToString());
                    boCcs.vUpdateDoiID(vDoiID, vCccID);
                }
                flagUpdate = true;
            }
            return flagUpdate;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vUpdateDoiID())
            {
                MessageBox.Show("Update complet");
            }
            else
                MessageBox.Show("Update error");

        }
    }
}
