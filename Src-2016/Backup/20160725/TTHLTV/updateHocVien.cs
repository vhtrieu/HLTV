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
    public partial class updateHocVien : DevExpress.XtraEditors.XtraForm
    {
        DAL.DAL_HOCVIEN hv = new DAL.DAL_HOCVIEN();
        public updateHocVien()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //loadIds();
            updateIdDoiChungChiHocVien();
        }
        private void loadIds()
        {
            DataTable tb = new DataTable();
            string fullName = "";
            tb = hv.getAll_HOCVIEN_1();
            listBox1.DataSource = tb;
            //listBox1.DisplayMember = "HOV_ID";
            //listBox1.ValueMember = "HOV_ID";
            if (tb.Rows.Count>0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    fullName = tb.Rows[i]["HO"].ToString().Trim() + " " + tb.Rows[i]["TEN"].ToString();
                    hv.updateFullName(tb.Rows[i]["MAHOCVIEN"].ToString(), fullName);
                }
            }
            
        }
        private void updateIdDoiChungChiHocVien()
        {
            BO_CAP_CHUNGCHI bo = new BO_CAP_CHUNGCHI();
            //1. Load list need update
            
            DataTable vtb = new DataTable();
            vtb = bo.ListNeedUpdate();
            //2. Load list ID for update
            DataTable vtb2 = new DataTable();
            vtb2 = bo.ListForUpdate();
            for (int i = 0; i < vtb.Rows.Count; i++)
            {
                for (int j = 0; j < vtb2.Rows.Count; j++)
                {
                    if (int.Parse(vtb.Rows[i]["CCC_ID"].ToString()) == int.Parse(vtb2.Rows[j]["CCC_ID"].ToString()))
                    {
                        //3. Execute update 
                        //string c = string.Empty;
                        bo.updateChungChiDoiIDToCapChungChi(int.Parse(vtb2.Rows[j]["DOI_ID"].ToString()));
                    }
                }
            }

        }
    }
}