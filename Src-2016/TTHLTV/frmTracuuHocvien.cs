using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using System.IO;
namespace TTHLTV
{
    public partial class frmTracuuHocvien : DevExpress.XtraEditors.XtraForm
    {
        BO_CHUNG_CHI bal = new BO_CHUNG_CHI();
        BO_HOCVIEN boHv = new BO_HOCVIEN();
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        private int studentsId = -1;
        public frmTracuuHocvien()
        {
            InitializeComponent();
        }
        private void frmTracuuHocvien_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridStudentsList.MainView, new Font("Tahoma", 11));
            Utilities.setFontSize.SetGridFont(gridMarks.MainView, new Font("Tahoma", 11));
            Utilities.setFontSize.SetGridFont(gridTeached.MainView, new Font("Tahoma", 11));

            loadKhoaHoc();
            acticeSearch();
            loadDefaultImage();
            lookLopHoc.Enabled = false;
        }
        private DataTable getKhoaHoc()
        {
            return bal.getChungChi_All();
        }
        private void loadKhoaHoc()
        {
            lookChungChi.Properties.DataSource = getKhoaHoc();
            lookChungChi.Properties.ValueMember = "CHC_ID";
            lookChungChi.Properties.DisplayMember = "CHC_Name";
            //lookChungChi.ItemIndex = 0;
        }
        private DataTable getLopHoc()
        {
            BAL.BO_LOP bal = new BO_LOP();
            //return bal.getLop_Alls();
            return bal.getLOP_ByCcID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
        }
        private void loadLopHoc()
        {
            lookLopHoc.Properties.DataSource = getLopHoc();
            lookLopHoc.Properties.ValueMember = "LOP_ID";
            lookLopHoc.Properties.DisplayMember = "LOP_Name";
            //lookLopHoc.ItemIndex = 0;
        }
        private void acticeSearch()
        {
            // Biding data to search tool
            lookSearchBy.Properties.DataSource = sLookupName().Tables["sSearchTable"];
            lookSearchBy.Properties.ValueMember = "ID";
            lookSearchBy.Properties.DisplayMember = "Name";
            lookSearchBy.ItemIndex = 0;

            lookCondition.Properties.DataSource = sLookupCondition().Tables["sConditionTable"];
            lookCondition.Properties.ValueMember = "ID";
            lookCondition.Properties.DisplayMember = "Name";
            lookCondition.ItemIndex = 0;
        }
        private DataSet sLookupName()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sSearchTable");

            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "Họ và tên");
            sTable.Rows.Add(2, "Tên");
            sTable.Rows.Add(3, "Họ");
            sTable.Rows.Add(4, "Ngày sinh");
            sTable.Rows.Add(5, "Nơi sinh");
            sTable.Rows.Add(6, "Điện thoại");
            sTable.Rows.Add(7, "Số chứng chỉ");
            return sDataset;

        }
        private DataSet sLookupCondition()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sConditionTable");

            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "Có chứa");
            sTable.Rows.Add(2, "Bắt đầu");

            return sDataset;

        }
        private void lookChungChi_EditValueChanged(object sender, EventArgs e)
        {
            gridStudentsList.DataSource = null;
            gridMarks.DataSource=null;
            gridTeached.DataSource =null;
            lookLopHoc.Enabled = true;
            loadLopHoc();
        }
        private void lookLopHoc_EditValueChanged(object sender, EventArgs e)
        {
            // Show học viên da dang ki hoc tai trung tam
            getStudents();

        }
        private void getStudents()
        {
            int ChungChi_ID = int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString());
            int LOP_ID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            gridStudentsList.DataSource = boDkh.getDangKiHoc_ByLopID(LOP_ID);
        }
        private void searchHocVien( string textSearch)
        {
          DataTable tbHocVien = new DataTable();
            //1. Full name
            if ( int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 1)
            {
                tbHocVien = boHv.searchHocVienByFullName(textSearch);
            }
            //2. Last name
            else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 2)
            {
                tbHocVien = boHv.searchHocVienByLastName(textSearch);
            }
            //3. Firstname
            else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 3)
            {
                tbHocVien = boHv.searchHocVienByFirstName(textSearch);
            }
            //4.Ngay sinh
            else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 4)
            {
                tbHocVien = boHv.searchHocVienByBirthday(textSearch);
            }
            //5. Noi sinh
            else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 5)
            {
                tbHocVien = boHv.searchHocVienByNoiSinh(textSearch);
            }
            //6. Dien thoai
            else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 6)
            {
                tbHocVien = boHv.searchHocVienByDienThoai(textSearch);
            }
            //7.Theo số chứng chỉ
            else if (int.Parse(lookSearchBy.GetColumnValue("ID").ToString()) == 7)
            {
                tbHocVien = boHv.searchHocVienBySoCC(textSearch+" GTVT");
            }
            gridStudentsList.DataSource = tbHocVien;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gridStudentContent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow currentRow = gridStudentContent.GetDataRow(e.RowHandle);
            studentsId = int.Parse(currentRow["HOV_ID"].ToString());
            loadImage(currentRow);
            // Tim kiem diem, mon hoc, lan thi
            gridMarks.DataSource = boHv.search_Diem_ByHocVienId(studentsId);
            // Tim kiem so chung chi, ngay cap
            gridTeached.DataSource = vTable(studentsId);// boHv.search_CCC_ByHocVienId(studentsId);
        }
        private void txtSearchText_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (txtSearchText.Text != string.Empty)
            {
                searchHocVien(txtSearchText.Text);
            }
            else
            {
                gridStudentsList.DataSource = null;
                gridMarks.DataSource = null;
                gridTeached.DataSource = null;
                loadDefaultImage();
            }
        }
        private DataTable vTable( int stdentId )
        {
            DataTable tb = boHv.search_CCC_ByHocVienId(stdentId);
            DataTable tbDkh = boDkh.get_DKH_By_HvID(stdentId);

            DataTable vTemTable = new DataTable();
            vTemTable.Columns.Add("CCC_ID", typeof(int));
            vTemTable.Columns.Add("LOP_ShortName", typeof(string));
            vTemTable.Columns.Add("CCC_CHCID", typeof(int));
            vTemTable.Columns.Add("CCC_SoCC", typeof(string));
            vTemTable.Columns.Add("CCC_NgayCap", typeof(DateTime));
            vTemTable.Columns.Add("CCC_NgayHetHan", typeof(DateTime));
            vTemTable.Columns.Add("CCC_LOPID", typeof(int));
            vTemTable.Columns.Add("CCC_SoHieuDoi", typeof(string));
            vTemTable.Columns.Add("NGAY_KG", typeof(DateTime));
            vTemTable.Columns.Add("NGAY_KT", typeof(DateTime));

            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {

                    DataRow row = vTemTable.NewRow();
                    row["CCC_ID"] = tb.Rows[i]["CCC_ID"].ToString();
                    if (tb.Rows[i]["LOP_ShortName"].ToString() == "")
                    {
                        row["LOP_ShortName"] = tb.Rows[i]["CCC_SoHieuDoi"].ToString();
                    }
                    else
                    {
                        row["LOP_ShortName"] = tb.Rows[i]["LOP_ShortName"].ToString();
                    }
                    row["CCC_CHCID"] = tb.Rows[i]["CCC_CHCID"].ToString();
                    if (tb.Rows[i]["LOP_Ngay_KG"].ToString() != "")
                    {
                        row["NGAY_KG"] = tb.Rows[i]["LOP_Ngay_KG"].ToString();
                        row["NGAY_KT"] = tb.Rows[i]["LOP_Ngay_KT"].ToString();
                    }
                    else
                    {
                        row["NGAY_KG"] = System.DBNull.Value;
                        row["NGAY_KT"] = System.DBNull.Value;
                    }
                    if ( tb.Rows[i]["CCC_NgayCap"].ToString()!=string.Empty)
                    {
                        row["CCC_NgayCap"] = tb.Rows[i]["CCC_NgayCap"].ToString();
                    }
                    else
                    {
                        row["CCC_NgayCap"] = System.DBNull.Value;
                    }
                    row["CCC_SoCC"] = tb.Rows[i]["CCC_SoCC"].ToString();
                    row["CCC_LOPID"] = tb.Rows[i]["CCC_LOPID"].ToString();

                    vTemTable.Rows.Add(row);
                }
            }
            else if (tbDkh.Rows.Count>0)
            {
                for (int i = 0; i < tbDkh.Rows.Count; i++)
                {
                    DataRow row = vTemTable.NewRow();
                    row["CCC_ID"] = tbDkh.Rows[i]["DKH_ID"].ToString();
                    row["LOP_ShortName"] = tbDkh.Rows[i]["LOP_ShortName"].ToString();
                    row["CCC_CHCID"] = tbDkh.Rows[i]["DKH_ID"].ToString();
                    if (tbDkh.Rows[i]["LOP_Ngay_KG"].ToString()!="")
                    {
                        row["NGAY_KG"] = tbDkh.Rows[i]["LOP_Ngay_KG"].ToString();
                        row["NGAY_KT"] = tbDkh.Rows[i]["LOP_Ngay_KT"].ToString();
                    }
                    else
                    {
                        row["NGAY_KG"] = System.DBNull.Value;
                        row["NGAY_KT"] = System.DBNull.Value;
                    }
                    if ( tbDkh.Rows[i]["LOP_ID"].ToString()!="")
                    {
                        row["CCC_LOPID"] = tbDkh.Rows[i]["LOP_ID"].ToString();
                    }
                    else
                    {
                        row["CCC_LOPID"] = -1;
                    }

                    vTemTable.Rows.Add(row);
                }
            }
            return vTemTable;
        }
        private void btnSearchScc_Click(object sender, EventArgs e)
        {
            
            DataTable tbHocVien = new DataTable();
            string textSearch = string.Empty;
            if (txtSoCC.Text=="")
            {
                MessageBox.Show("Chưa nhập số chứng chỉ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtSoCC.Text.Length != 5)
            {
                MessageBox.Show("Số chứng chỉ có 5 chữ số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                textSearch = txtSoCC.Text + " " + txtText.Text;
                tbHocVien = boHv.searchHocVienBySoCC(textSearch);
                gridStudentsList.DataSource = null;
                gridStudentsList.DataSource = tbHocVien;
 
            }
            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearchText.Text != string.Empty)
            {
                searchHocVien(txtSearchText.Text);
            }
            else
            {
                gridStudentsList.DataSource = null;
                gridMarks.DataSource = null;
                gridTeached.DataSource = null;
            }
        }
        private void gridTeachedContent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow currentRow = gridTeachedContent.GetDataRow(e.RowHandle);
            int vLopID = int.Parse(currentRow["CCC_LOPID"].ToString());
            gridMarks.DataSource = boDkh.Search_MonHoc_By_Lop_HvienID(vLopID, studentsId);
        }
        private void loadImage(DataRow vRow)
        {
            try
            {
                if (vRow["IMG_Image"] != DBNull.Value)
                {
                    imgArray = (byte[])vRow["IMG_Image"];
                    using (MemoryStream ms = new MemoryStream(imgArray, 0, imgArray.Length))
                    {
                        ms.Write(imgArray, 0, imgArray.Length);
                        Img = Image.FromStream(ms, true);
                    }
                    picHocVien.Image = Img;
                    resizeImage(Img, 106, 140);
                }
                else
                {
                    loadDefaultImage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void resizeImage(Image _img, float _width, float _height)
        {
            Bitmap bm_source = new Bitmap(_img);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_width), Convert.ToInt32(_height));
            Graphics gr_dest = Graphics.FromImage(bm_dest);
            gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width, bm_dest.Height);
            // Display the result.
            picHocVien.Image = bm_dest;
            picHocVien.Width = bm_dest.Width;
            picHocVien.Height = bm_dest.Height;
        }
        byte[] imgArray;
        private Image Img;
        string vImgFileName;
    }
}