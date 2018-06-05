using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using System.Globalization;
using TTHLTV.Utilities;
using System.Drawing;

namespace TTHLTV
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        BO_CAP_CHUNGCHI boCcc = new BO_CAP_CHUNGCHI();
        BO_CHUNG_CHI boCc = new BO_CHUNG_CHI();
        BO_DANG_KI_HOC boDkh= new BO_DANG_KI_HOC();
        BO_HOCVIEN boHv=new BO_HOCVIEN();
        BO_MONHOC boMh = new BO_MONHOC();
        BO_DIEM boDiem = new BO_DIEM();
        public Excel.Application xlsApp;
        public Excel.Workbook xlsWorkbook;
        public Excel.Worksheet xlsWorksheet;
        
        public frmPrint()
        {
            InitializeComponent();
        }
        private void btnPrint_InDsHv_Click(object sender, EventArgs e)
        {
            if (lookKhoaHoc_InGCN.ItemIndex < 0 && lookLop_InGCN.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn khóa học, và lớp học", "THÔNG BÁO");

            }
            else
            {
                inDanhSachHocVien();
            }

        }
        private void btnPhieuDiemDanh_Click(object sender, EventArgs e)
        {
            if (lookKhoaHoc_InGCN.ItemIndex < 0 && lookLop_InGCN.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn khóa học, và lớp học", "THÔNG BÁO");

            }
            else
            {
                inPhieuDiemDanh();
            }
           

        }
        private void btnPhieuDiem_Click(object sender, EventArgs e)
        {
            if (lookKhoaHoc_InGCN.ItemIndex < 0 && lookLop_InGCN.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn khóa học, và lớp học", "THÔNG BÁO");
            }
            else
                if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) == 30)
                {
                    DsVaoPhongThi();
                }
             else
                if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) == 29)
                {
                    DsThiSQQLBoong();
                }
                else
                    if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) == 27)
                    {
                        dsThiSQVH_Boong();
                        
                    }
                    else
                        {
                            inKetQuaHocTap();
                        }
           
        }
        private void btnDsHvCapGCN_Click(object sender, EventArgs e)
        {
            if (lookKhoaHoc_InGCN.ItemIndex < 0 && lookLop_InGCN.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn khóa học, và lớp học", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (lookUpSoHieuDoi.ItemIndex < 0 && radioSelect.SelectedIndex < 3)
            {
                MessageBox.Show("Chưa chọn số hiệu đổi", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radCapQ.SelectedIndex == 1 || radCapQ.SelectedIndex==2)
            {
                lookUpSoHieuDoi.Refresh();
                inDsHvDuocCapGCN_Doi();
            }
            else
            {
                inDsHvDuocCapGCN();
            }
            radCapQ.SelectedIndex = -1;
        }
        private void btnPrint_InGCN_Click(object sender, EventArgs e)
        {
            if (lookKhoaHoc_InGCN.ItemIndex < 0 && lookLop_InGCN.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn khóa học, và lớp học", "THÔNG BÁO");
            }
            else if (lookUpSoHieuDoi.ItemIndex < 0 && radioSelect.SelectedIndex < 3)
            {
                MessageBox.Show("Chưa chọn số hiệu đổi", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radCapQ.SelectedIndex == 1 || radCapQ.SelectedIndex==2)
            {
                inDsCapGCN_Doi();
                lookUpSoHieuDoi.Refresh();
            }
            else
            {
                inDsCapGCN();
            }
            radCapQ.SelectedIndex = -1;

        }
        private void btbPrintGCN_Click(object sender, EventArgs e)
        {
            if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) < 0 && int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()) < 0)
            {
                MessageBox.Show("Chưa chọn khóa học, và lớp học", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //else if (lookUpSoHieuDoi.ItemIndex<0)
            //{
            //     MessageBox.Show("Chưa chọn số hiệu đổi", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            else
            {
                inDsCapGCN(); 
            }
        }
        private void btnBbChamThi_Click(object sender, EventArgs e)
        {
            if (lookKhoaHoc_InGCN.ItemIndex < 0 && lookLop_InGCN.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn khóa học, và lớp học", "THÔNG BÁO");

            }
            else if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) == 30)
            {
                DsThiSQQL(); //SQQL Máy

            }
            else if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) == 29)
            {
                BienBanChamThiSQQLBoong();
                
            }
            else if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) == 27)
            {
                BienbanChamThiSQVHBoong();
            }
        }
        private void frmPrint_Load(object sender, EventArgs e)
        {
            sCheckVisible();
            radioSelect.SelectedIndex = -1;
            loadKhoaHoc();
        }
        private void lookKhoaHoc_InGCN_EditValueChanged(object sender, EventArgs e)
        {
            lookLop_InGCN.Enabled = true;
           // lookLop_InGCN.Refresh();
            loadLopHoc();
          
           // lookUpSoHieuDoi.Refresh();
            LoadSoHieuDoi();
           
        }
        private void lookLop_InGCN_EditValueChanged(object sender, EventArgs e)
        {
            if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) == 29)
            {
                bindingMonHoc_SQQLBoong();
                lookMonHoc.Enabled = true;
            }
            else if (int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()) == 30)
            {
                bindingMonHoc_SQQL();
                lookMonHoc.Enabled = true;
            }
            else
            {
                loadMonHoc();
            }
        }
        private void radioSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            sCheckRadioSlected();

            lookKhoaHoc_InGCN.Enabled = true;
            lookLop_InGCN.Enabled = true;
            lookKhoaHoc_InGCN.ItemIndex = -1;
            lookLop_InGCN.ItemIndex = -1;
            lookMonHoc.ItemIndex = -1;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lookMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            sLoadLanThi();
        }

        #region Danh sah hoc vien
        private void inDanhSachHocVien()
        {
           
           int currentRow = 11;
           xlsApp = new Excel.Application();
           xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DanhSachHocVien.xlt");
           xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable dt = new DataTable();
            dt = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));
            xlsWorksheet.Cells[5, ExcelColumns.colC] = "Lớp: " + lookLop_InGCN.GetColumnValue("LOP_Name");
                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < dt.Rows.Count+4; i++)
                    {
                        if (i < dt.Rows.Count)
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 10;
                            xls.Cells[currentRow, ExcelColumns.colB] = dt.Rows[i]["HOV_FirstName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = dt.Rows[i]["HOV_LastName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colD] = dt.Rows[i]["HOV_BirthDay"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colE] = dt.Rows[i]["TIN_Name"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colF] = dt.Rows[i]["HOV_Phone"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colG] = dt.Rows[i]["HOV_ChucDanh"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colH] = dt.Rows[i]["DON_Name"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colI] = dt.Rows[i]["DKH_BienLai"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colJ] = dt.Rows[i]["HOV_GhiChu"].ToString();
                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 10;
                        }
                        currentRow++;
                    }
                }
            
            if (currentRow>11)
            {
                drawBorder("D12:J" + (currentRow -1).ToString());
                drawBorderOneColumn("A12:A" + (currentRow - 1).ToString());
                drawBorderNone("B12:C" + (currentRow - 1).ToString());
            }
            xls.Cells[currentRow + 1, ExcelColumns.colB] = "Người lập danh sách: .............................................";
            //xls.Cells[currentRow + 2, ExcelColumns.colH] = "Tp HCM, ngày ........ tháng ........ năm 201.....";
            //xls.Cells[currentRow + 3, ExcelColumns.colH] = "Cán bộ giáo vụ";
            xlsApp.Visible = true;
            dt = null;
            xlsApp = null;
            xlsWorkbook = null;
            xlsWorksheet = null;
            
        }
        #endregion
        #region Phiếu điểm danh
        private void inPhieuDiemDanh()
        {
           
            int currentRow = 11;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DiemDanhHocVien.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            table = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));
            if (table.Rows.Count < 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
            {
              
                xlsWorksheet.Cells[6, ExcelColumns.colB] = "LỚP: " + lookLop_InGCN.GetColumnValue("LOP_Name");
                xlsWorksheet.Cells[6, ExcelColumns.colE] = "MÔN: " + lookMonHoc.GetColumnValue("MON_Name");
                //object sS = table.Rows[0]["LOP_Ngay_KG"].ToString();
                //object sS1 = table.Rows[0]["LOP_Ngay_KG"].ToString();
                DateTime sS = DateTime.Parse( table.Rows[0]["LOP_Ngay_KG"].ToString());
                DateTime sS1 = DateTime.Parse(  table.Rows[0]["LOP_Ngay_KT"].ToString());
               
                string formattedS = sS.ToString("dd/MM/yyyy");
                string formattedS1 = sS1.ToString("dd/MM/yyyy");

                xlsWorksheet.Cells[6, ExcelColumns.colH] = "Từ ngày:                Đến ngày:";
               // xlsWorksheet.Cells[6, ExcelColumns.colI] = "Đến ngày: ";// +"  " + formattedS1.ToString();
               // Add chon mon hoc 
                if (lookMonHoc.ItemIndex<0)
                {
                    MessageBox.Show("Chưa chọn môn học","THÔNG BÁO");
                    return;
                }
                table2 = boDkh.ExportExcel_Info_DiemDanh(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()));
                if (table2.Rows.Count > 0)
                {
                    xlsWorksheet.Cells[7, ExcelColumns.colE] = "Giáo viên: " + table2.Rows[0]["GIV_Name"].ToString();
                }
                else
                {
                    xlsWorksheet.Cells[7, ExcelColumns.colE] = "Giáo viên: " + "........................................";
                    
                }
                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < table.Rows.Count + 4; i++)
                    {
                        if (i < table.Rows.Count)
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 10;
                            xls.Cells[currentRow, ExcelColumns.colB] = table.Rows[i]["HOV_FirstName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = table.Rows[i]["HOV_LastName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colD] = table.Rows[i]["HOV_BirthDay"].ToString();
                            
                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 10;
                            //xls.Cells[currentRow, ExcelColumns.colB] = "";
                            //xls.Cells[currentRow, ExcelColumns.colC] = "";
                            //xls.Cells[currentRow, ExcelColumns.colD] = "";
                            
                        }
                        currentRow++;
                    }
                }

                if (currentRow > 11)
                {
                    drawBorder("D12:J" + (currentRow - 1).ToString());
                    drawBorderOneColumn("A12:A" + (currentRow - 1).ToString());
                    drawBorderNone("B12:C" + (currentRow - 1).ToString());
                }
                xls.Cells[currentRow + 1, ExcelColumns.colA] = "Ghi chú: Nếu 1 ngày học hai buổi thì ghi rõ S (sáng) hay C (chiều).";
                xls.Cells[currentRow + 3, ExcelColumns.colB] = "Chữ kí giáo viên";
                xls.Cells[currentRow + 3, ExcelColumns.colH] = "Cán bộ giáo vụ";
                xlsApp.Visible = true;
                table = null;
                xlsApp = null;
                xlsWorkbook = null;
                xlsWorksheet = null;
            }
            
        }
        #endregion
        #region Ket qua hoc tap
        private void inKetQuaHocTap()
        {

            int currentRow = 10;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\KetQuaHuanLuyen.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            table = boHv.ExportExcel_DiemThi(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()), int.Parse( lookLanThi.GetColumnValue("DIE_LanThi").ToString()));
            //dt = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));
            if (table.Rows.Count < 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
            {

                xlsWorksheet.Cells[6, ExcelColumns.colC] = "LỚP: " + lookLop_InGCN.GetColumnValue("LOP_Name");
                xlsWorksheet.Cells[6, ExcelColumns.colH] = "MÔN: " + lookMonHoc.GetColumnValue("MON_Name");
                
                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < table.Rows.Count + 4; i++)
                    {
                        if (i < table.Rows.Count)
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                            xls.Cells[currentRow, ExcelColumns.colB] = table.Rows[i]["HOV_FirstName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = table.Rows[i]["HOV_LastName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colD] = table.Rows[i]["HOV_BirthDay"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colE] = table.Rows[i]["TIN_Name"].ToString();

                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 9;
                        }
                        currentRow++;
                    }
                }

                if (currentRow > 10)
                {
                    drawBorder("D11:K" + (currentRow - 1).ToString());
                    drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                    drawBorderNone("B11:C" + (currentRow - 1).ToString());
                }
                xls.Cells[currentRow + 1, ExcelColumns.colB] = "Giáo viên:";
                xls.Cells[currentRow + 3, ExcelColumns.colB] = "1 ....................................";
                xls.Cells[currentRow + 1, ExcelColumns.colD] = "Giám thị:";
                xls.Cells[currentRow + 1, ExcelColumns.colF] = "Giáo vụ:";
                xls.Cells[currentRow + 1, ExcelColumns.colI] = "Tp. HCM, ngày "+ "...."+ " tháng "+ "....."+" năm "+ "201..." +" ";
                xls.Cells[currentRow + 2, ExcelColumns.colI] = "Giám đốc / Trưởng ban giám khảo";
                xls.Cells[currentRow + 3, ExcelColumns.colC] = "1 ....................................";
                xls.Cells[currentRow + 3, ExcelColumns.colF] = "1 ....................................";
                xls.Cells[currentRow + 6, ExcelColumns.colC] = "2 ....................................";
                xls.Cells[currentRow + 6, ExcelColumns.colB] = "2 ....................................";
                xlsApp.Visible = true;
                table = null;
                xlsApp = null;
                xlsWorkbook = null;
                xlsWorksheet = null;
            }
        }
        private void DsThiSQQLBoong()
        {
            // Declare variables
            Excel.Application xlsApp;
            Excel.Workbook xlsWorkbook;
            Excel.Worksheet xlsWorksheet;
            Excel.Worksheet xlsWorksheet2;
            Excel.Range xlsRange = null;
            Excel.Range xlsRange2 = null;
            int rowCurrent = 1;
            DataTable dt = new DataTable();

            //Open save file dialog
            SaveFileDialog DialogSave = new SaveFileDialog();
            DialogSave.DefaultExt = "xls";
            DialogSave.Filter = "Excel file (*.xls)|*.xls|All files (*.*)|*.*";
            DialogSave.AddExtension = true;
            DialogSave.RestoreDirectory = true;
            DialogSave.Title = "Where do you want to save the file ?";
            DialogSave.InitialDirectory = @"C:/";
            DialogSave.FileName = "Dsthi_HHTH_AV_" + DateTime.Today.ToString("ddMMyyyy");
            dt = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
                //=============Start exporting report
                if (DialogSave.ShowDialog() == DialogResult.OK)
                {
                    Application.DoEvents();
                    this.Refresh();
                    Cursor.Current = Cursors.WaitCursor;

                    string appPath = AppDomain.CurrentDomain.BaseDirectory;
                    int indexOfProjectName = appPath.LastIndexOf("TTHLTV");
                    string sourceFile = appPath + "Report\\DsthiHHTH_AV.xls";
                    string destFile = DialogSave.FileName;

                    try
                    {
                        File.Copy(sourceFile, destFile, true);
                    }
                    catch (IOException io)
                    {
                        MessageBox.Show(io.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Start Excel and get Application object.
                    xlsApp = new Excel.Application();
                    xlsApp.Visible = false;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    // Create new workbook.
                    xlsWorkbook = (Excel.Workbook)(xlsApp.Workbooks.Open(destFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                    xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
                    try
                    {
                        // Get worksheets
                        xlsWorksheet = (Excel.Worksheet)xlsWorkbook.Worksheets[1];      // downloaded sheet
                        xlsWorksheet2 = (Excel.Worksheet)xlsWorkbook.Worksheets[2];     // template sheet

                        // Delete all content of sheet
                        xlsWorksheet.Cells.Clear();
                        // Output title to excel file
                        xlsRange = xlsWorksheet.get_Range("A1", "H55");//sheet download
                        xlsRange2 = xlsWorksheet2.get_Range("A1", "H55");//sheet template
                        xlsRange2.Copy(xlsRange);

                        //DataTable tb2 = new DataTable();
                        //tb2 = boDkh.ExportExcel_Info_DiemDanh(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()));
                        xlsRange.Cells[8, 2] = "LỚP: " + lookMonHoc.GetColumnValue("MON_Name");
                        //xlsRange.Cells[6, 6] = "MÔN: " + lookMonHoc.GetColumnValue("MON_Name");

                        //object sS = tb2.Rows[0]["LOP_Ngay_KG"].ToString();
                        //object sS1 = tb2.Rows[0]["LOP_Ngay_KG"].ToString();

                        //string datesS = sS.ToString();
                        //string datesS1 = sS1.ToString();
                        //DateTimeFormatInfo dateTimeFormatterProviderS = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                        //dateTimeFormatterProviderS.ShortDatePattern = "MM/dd/yyyy";
                        //DateTime dateTimeS = DateTime.Parse(datesS, dateTimeFormatterProviderS);
                        //DateTime dateTimeS1 = DateTime.Parse(datesS1, dateTimeFormatterProviderS);
                        //string formattedS = dateTimeS.ToString("dd/MM/yyyy");
                        //string formattedS1 = dateTimeS1.ToString("dd/MM/yyyy");

                        //xlsRange.Cells[8, 6] = "Từ ngày: " + "  " + formattedS.ToString();
                        //xlsRange.Cells[8, 8] = "Đến ngày: " + "  " + formattedS1.ToString();
                        //xlsRange.Cells[9, 4] = "Giáo viên: " + tb2.Rows[0]["GIV_Name"].ToString();
                        //fill data
                        rowCurrent = 13;
                        int index = 0;
                        int sCount = dt.Rows.Count + 4;
                        int i;
                        for (i = 0; i < sCount; i++)
                        {
                            // Border title
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.Value = 1;
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.LineStyle = BorderStyle.FixedSingle;

                            rowCurrent = rowCurrent + 1;
                            index = index + 1;
                            xlsRange = xlsWorksheet.get_Range("A" + (rowCurrent).ToString(), "H" + (rowCurrent).ToString());//sheet download
                            int ts = dt.Rows.Count;
                            if (i < ts)
                            {
                                //object s = dt.Rows[i]["HOV_BirthDay"].ToString();
                                //string dates = s.ToString();
                                //DateTimeFormatInfo dateTimeFormatterProvider = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                                //dateTimeFormatterProvider.ShortDatePattern = "MM/dd/yyyy";
                                //DateTime dateTime = DateTime.Parse(dates, dateTimeFormatterProvider);
                                //string formatted = dateTime.ToString("dd/MM/yyyy");

                                xlsRange.Cells[1, 1] = index;
                                xlsRange.Cells[1, 2] = dt.Rows[i]["HOV_FirstName"].ToString(); // +" " + dt.Rows[i]["HOV_LastName"].ToString();
                                xlsRange.Cells[1, 3] = dt.Rows[i]["HOV_LastName"].ToString();
                                xlsRange.Cells[1, 4] = dt.Rows[i]["HOV_BirthDay"].ToString();// formatted.ToString();//dt.Rows[i]["FullName"].ToString();
                                xlsRange.Cells[1, 5] = dt.Rows[i]["HOV_NoiSinh"].ToString();
                                //xlsRange.Cells[1, 5] = dt.Rows[i]["HOV_Phone"].ToString();
                                //xlsRange.Cells[1, 6] = dt.Rows[i]["HOV_ChucDanh"].ToString();
                                //xlsRange.Cells[1, 7] = dt.Rows[i]["HOV_DonVi"].ToString();
                                //xlsRange.Cells[1, 8] = dt.Rows[i]["DKH_BienLai"].ToString();
                                //xlsRange.Cells[1, 9] = dt.Rows[i]["HOV_GhiChu"].ToString();

                            }
                            else
                            {
                                xlsRange.Cells[1, 1] = index;
                                xlsRange.Cells[1, 2] = "";
                                xlsRange.Cells[1, 3] = "";
                                xlsRange.Cells[1, 4] = "";
                                xlsRange.Cells[1, 5] = "";
                                xlsRange.Cells[1, 6] = "";
                                xlsRange.Cells[1, 7] = "";
                                xlsRange.Cells[1, 8] = "";
                                xlsRange.Cells[1, 9] = "";

                            }

                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).RowHeight = 17;
                            //Ve border cho rows cuoi cung.
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.Value = 1;
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Font.Name = "Times New Roman";
                        }
                        // =====Delete templete sheet====
                        xlsApp.DisplayAlerts = true;
                        ((Excel.Worksheet)xlsWorkbook.Sheets[2]).Delete();

                        // Save and close workbook
                        xlsWorkbook.Save();

                        MessageBox.Show("Xuất file thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //xlsApp.ActiveWorkbook.PrintPreview(); //Tai sao khong PrintPreview duoc?
                        // =======   end exporting report ==============

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        xlsWorkbook.Save();
                        //File.Delete(destFile);
                    }
                    finally
                    {
                        //xlsWorksheet2.Delete();

                        xlsWorkbook.Close(false, false, false);
                        xlsApp.Workbooks.Close();
                        xlsApp.Quit();

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                        Cursor.Current = Cursors.Default;
                    }
                }

        }
        private void DsThiSQQL()
        {
            int currentRow = 11;
            xlsApp = new Excel.Application();
            if (lookMonHoc.ItemIndex>2)
            {
                xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\BBCT_SQQL_Mon_3.xlt");
            }
            else
            {
                xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\BBCT_SQQL_Mon_1.xlt");
            }
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            //table = boHv.ExportExcel_DiemThi(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()), int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString()));
            table = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));
            if (table.Rows.Count < 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
            {

                xlsWorksheet.Cells[6, ExcelColumns.colC] = "LỚP: " + lookLop_InGCN.GetColumnValue("LOP_Name");
                xlsWorksheet.Cells[6, ExcelColumns.colH] = "MÔN: " + lookMonHoc.GetColumnValue("MON_Name");

                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < table.Rows.Count + 4; i++)
                    {
                        if (i < table.Rows.Count)
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 10;
                            xls.Cells[currentRow, ExcelColumns.colB] = table.Rows[i]["HOV_FirstName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = table.Rows[i]["HOV_LastName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colD] = table.Rows[i]["HOV_BirthDay"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colE] = table.Rows[i]["HOV_NoiSinh"].ToString();

                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 10;
                        }
                        currentRow++;
                    }
                }

                if (currentRow > 11)
                {
                    if (lookMonHoc.ItemIndex>2)
                    {
                        drawBorder("D11:Q" + (currentRow - 1).ToString());
                    }
                    else
                    {
                        drawBorder("D11:K" + (currentRow - 1).ToString());
                    }
                    
                    drawBorderOneColumn("A11:A" + (currentRow - 1).ToString());
                    drawBorderNone("B11:C" + (currentRow - 1).ToString());
                }
                xls.Cells[currentRow + 1, ExcelColumns.colB] = "Giáo viên:";
                xls.Cells[currentRow + 3, ExcelColumns.colB] = "1 ....................................";
                xls.Cells[currentRow + 1, ExcelColumns.colD] = "Giám thị:";
                xls.Cells[currentRow + 1, ExcelColumns.colE] = "Giáo vụ:";
                xls.Cells[currentRow + 1, ExcelColumns.colG] = "Tp. HCM, ngày " + "...." + " tháng " + "....." + " năm " + "201..." + " ";
                xls.Cells[currentRow + 2, ExcelColumns.colG] = "Giám đốc / Trưởng ban giám khảo";
                xls.Cells[currentRow + 3, ExcelColumns.colC] = "1 ....................................";
                xls.Cells[currentRow + 3, ExcelColumns.colE] = "1 ....................................";
                xls.Cells[currentRow + 6, ExcelColumns.colC] = "2 ....................................";
                xls.Cells[currentRow + 6, ExcelColumns.colB] = "2 ....................................";
                xlsApp.Visible = true;
                table = null;
                xlsApp = null;
                xlsWorkbook = null;
                xlsWorksheet = null;
            }
        }
        #endregion
        #region Danh sach hoc vien duoc cap giay chung nhan
        private void inDsHvDuocCapGCN()
        {
            int currentRow = 6;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DsHvDuocCapGCN.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
           
            table = boCcc.ExportExcel_DsHV_DuocCapCC(int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()), int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));
            if (table.Rows.Count < 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            else 
            {
                xlsWorksheet.Cells[2, ExcelColumns.colA] = "LỚP: " + lookLop_InGCN.GetColumnValue("LOP_Name");
                xlsWorksheet.Cells[3, ExcelColumns.colA] = "(Kèm theo Quyết định số" + " ..............." + "/QĐTN/HLTV ngày .... tháng .... năm ........)";
                
                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < table.Rows.Count + 4; i++)
                    {
                        if (i < table.Rows.Count)
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 5;
                            xls.Cells[currentRow, ExcelColumns.colB] = table.Rows[i]["HOV_FirstName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = table.Rows[i]["HOV_LastName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colD] = table.Rows[i]["HOV_BirthDay"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colE] = table.Rows[i]["TIN_Name"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colF] = table.Rows[i]["DON_Name"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colG] = table.Rows[i]["CCC_SoCC"].ToString();
                            DateTime temDate = DateTime.Parse(table.Rows[i]["CCC_NgayCap"].ToString());
                            xls.Cells[currentRow, ExcelColumns.colH] = string.Format("{0:dd/MM/yyyy}", temDate).ToString().Substring(0, 10);
                            xls.Cells[currentRow, ExcelColumns.colI] = table.Rows[i]["HOV_GhiChu"].ToString();
                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 5;
                        }
                        currentRow++;
                    }
                }

                if (currentRow > 5)
                {
                    drawBorder("D6:I" + (currentRow - 1).ToString());
                    drawBorderOneColumn("A6:A" + (currentRow - 1).ToString());
                    drawBorderNone("B6:C" + (currentRow - 1).ToString());
                }
                xls.Cells[currentRow + 1, ExcelColumns.colA] = "Người lập danh sách:";
                xls.Cells[currentRow + 1, ExcelColumns.colG] = "Ngày cấp: ......../......./ 201...... ";
                xls.Cells[currentRow + 2, ExcelColumns.colG] = "Giám đốc ";
             
                xlsApp.Visible = true;
                table = null;
                xlsApp = null;
                xlsWorkbook = null;
                xlsWorksheet = null;
            }
        }
        private void inDsHvDuocCapGCN_Doi()
        {
            int currentRow = 6;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DsHvDuocCapGCN_Doi.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            int sCap = -1;
            if (radCapQ.SelectedIndex==1)
            {
                sCap = 2;
            }
            else
                if (radCapQ.SelectedIndex==2)
                {
                    sCap = 3;
                }
            table = boCcc.ExportExcel_DsHV_DuocCapCC_Doi(int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()), sCap, lookUpSoHieuDoi.Text);
            if (table.Rows.Count < 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                xlsWorksheet.Cells[3, ExcelColumns.colA] = "CỦA GIẤY CHỨNG NHẬN: " + lookKhoaHoc_InGCN.GetColumnValue("CHC_Name").ToString() + " ( " + lookUpSoHieuDoi.GetColumnValue("CCC_SoHieuDoi") + " )";
                //xlsWorksheet.Cells[7, ExcelColumns.colC] = "(Kèm theo Quyết định số" + " ..............." + "/QĐGĐ/HLTV ngày .... tháng .... năm ........)";
                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < table.Rows.Count + 4; i++)
                    {
                        if (i < table.Rows.Count)
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 5;
                            xls.Cells[currentRow, ExcelColumns.colB] = table.Rows[i]["HOV_FirstName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = table.Rows[i]["HOV_LastName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colD] = table.Rows[i]["HOV_BirthDay"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colE] = table.Rows[i]["TIN_Name"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colF] = table.Rows[i]["DON_Name"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colG] = table.Rows[i]["CCC_SoCC"].ToString();
                            DateTime temDate = DateTime.Parse(table.Rows[i]["CCC_NgayCap"].ToString());
                            xls.Cells[currentRow, ExcelColumns.colH] = string.Format("{0:dd/MM/yyyy}", temDate).ToString().Substring(0,10) ;
                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 5;
                        }
                        currentRow++;
                    }
                }

                if (currentRow > 5)
                {
                    drawBorder("D6:I" + (currentRow - 1).ToString());
                    drawBorderOneColumn("A6:A" + (currentRow - 1).ToString());
                    drawBorderNone("B6:C" + (currentRow - 1).ToString());
                }
                xls.Cells[currentRow + 1, ExcelColumns.colA] = "Người lập danh sách:";
                xls.Cells[currentRow + 1, ExcelColumns.colG] = "Ngày cấp: ......../......./ 201...... ";
                xls.Cells[currentRow + 2, ExcelColumns.colG] = "Giám đốc ";

                xlsApp.Visible = true;
                table = null;
                xlsApp = null;
                xlsWorkbook = null;
                xlsWorksheet = null;
            }
        }
        #endregion
        #region Danh sach cap giay chung nhan
        private void inDsCapGCN()
        {
            int currentRow = 7;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\SoTheoDoiCapGCN.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            table = boCcc.ExportExcel_Phat_CHUNGCHI(int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()), int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString())); // Tem data.
            xlsWorksheet.Cells[4, ExcelColumns.colC] = "LỚP: " + lookLop_InGCN.GetColumnValue("LOP_Name");
            if (table.Rows.Count < 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
            {
                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < table.Rows.Count ; i++)
                    {
                        if (i < table.Rows.Count)
                        {
                            DateTime sS1 = DateTime.Parse(table.Rows[i]["CCC_NgayCap"].ToString());
                            string formatted = sS1.ToString("dd/MM/yyyy");
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 6;
                            xls.Cells[currentRow, ExcelColumns.colB] = table.Rows[i]["CCC_SoCC"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = table.Rows[i]["HOV_FullName"].ToString();
                            Excel.Range range = xls.get_Range((Excel.Range)xls.Cells[currentRow, ExcelColumns.colC], (Excel.Range)xls.Cells[currentRow, ExcelColumns.colC]);
                            Image oImage = loadImage(table.Rows[i]);
                            System.Windows.Forms.Clipboard.SetImage(oImage);
                            xlsWorksheet.Paste(range, false);
                            Microsoft.Office.Interop.Excel.Pictures pictures = xlsWorksheet.Pictures(System.Reflection.Missing.Value) as Microsoft.Office.Interop.Excel.Pictures;
                            Excel.Picture pic = pictures.Item(pictures.Count) as Excel.Picture;
                            pic.Top = range.Top+14;
                            pic.Left = range.Left + 35;
                            pic.Width = 96;
                            pic.Height = 110;
                            xls.Cells[currentRow, ExcelColumns.colD] = formatted;
                            int status = int.Parse(table.Rows[i]["CCC_Status"].ToString());
                            if (status==1)
                            {
                                xls.Cells[currentRow, ExcelColumns.colE] = "Khóa " + table.Rows[i]["LOP_Khoa"].ToString();
                            }
                            else if (status ==2)
                            {
                                xls.Cells[currentRow, ExcelColumns.colE] = " Gia hạn";
                            }
                            else if (status ==3)
                            {
                                xls.Cells[currentRow, ExcelColumns.colE] = " Đổi";
                            }
                           
                        }
                        xls.Rows[currentRow, Type.Missing].RowHeight = 130; 
                        currentRow++;
                    }
                }
                if (currentRow > 7)
                {
                    drawBorder("A7:F" + (currentRow - 1).ToString());
                }
                xlsApp.Visible = true;
                table = null;
                xlsApp = null;
                xlsWorkbook = null;
                xlsWorksheet = null;
            }
        }
        private void inDsCapGCN_Doi()
        {
            int currentRow = 7;
            xlsApp = new Excel.Application();
            xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\SoTheoDoiCapGCN.xlt");
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            int sCap = -1;
            if (radCapQ.SelectedIndex==1)
            {
                sCap = 2;
            }
            else if (radCapQ.SelectedIndex==2)
            {
                sCap = 3;
            }
            table = boCcc.ExportExcel_Phat_Doi_CHUNGCHI(int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()), sCap, lookUpSoHieuDoi.Text); // Tem data.
            xlsWorksheet.Cells[4, ExcelColumns.colC] = "LỚP: " + lookUpSoHieuDoi.Text;
            if (table.Rows.Count < 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
            {

                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < table.Rows.Count+2; i++)
                    {
                        if (i < table.Rows.Count)
                        {
                            DateTime sS1 = DateTime.Parse(table.Rows[i]["CCC_NgayCap"].ToString());
                            string formatted = sS1.ToString("dd/MM/yyyy");
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 6;
                            xls.Cells[currentRow, ExcelColumns.colB] = table.Rows[i]["CCC_SoCC"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = table.Rows[i]["HOV_FullName"].ToString();
                            Excel.Range range = xls.get_Range((Excel.Range)xls.Cells[currentRow, ExcelColumns.colC], (Excel.Range)xls.Cells[currentRow, ExcelColumns.colC]);
                            Image oImage = loadImage(table.Rows[i]);
                            System.Windows.Forms.Clipboard.SetImage(oImage);
                            xlsWorksheet.Paste(range, false);
                            Microsoft.Office.Interop.Excel.Pictures pictures = xlsWorksheet.Pictures(System.Reflection.Missing.Value) as Microsoft.Office.Interop.Excel.Pictures;
                            Excel.Picture pic = pictures.Item(pictures.Count) as Excel.Picture;
                            pic.Top = range.Top + 14;
                            pic.Left = range.Left + 35;
                            pic.Width = 96;
                            pic.Height = 110;
                            xls.Cells[currentRow, ExcelColumns.colD] = formatted;
                            int status = int.Parse(table.Rows[i]["CCC_Status"].ToString());
                            if (status == 1)
                            {
                                xls.Cells[currentRow, ExcelColumns.colE] = "Khóa " + table.Rows[i]["LOP_Khoa"].ToString();
                            }
                            else if (status == 2)
                            {
                                xls.Cells[currentRow, ExcelColumns.colE] = " Gia hạn";
                            }
                            else if (status == 3)
                            {
                                xls.Cells[currentRow, ExcelColumns.colE] = " Cấp đổi";
                            }
                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 6;
                        }
                        xls.Rows[currentRow, Type.Missing].RowHeight = 130;
                        currentRow++;
                    }
                }

                if (currentRow > 7)
                {
                    drawBorder("A7:F" + (currentRow - 1).ToString());
                }

                xlsApp.Visible = true;
                table = null;
                xlsApp = null;
                xlsWorkbook = null;
                xlsWorksheet = null;
            }

        }
        #endregion
        #region Bien ban cham thi
        private void BienBanChamThiSQQLBoong()
        {
            // Declare variables
            Excel.Application xlsApp;
            Excel.Workbook xlsWorkbook;
            Excel.Worksheet xlsWorksheet;
            Excel.Worksheet xlsWorksheet2;
            Excel.Range xlsRange = null;
            Excel.Range xlsRange2 = null;
            int rowCurrent = 1;
            DataTable dt = new DataTable();

            //Open save file dialog
            SaveFileDialog DialogSave = new SaveFileDialog();
            DialogSave.DefaultExt = "xls";
            DialogSave.Filter = "Excel file (*.xls)|*.xls|All files (*.*)|*.*";
            DialogSave.AddExtension = true;
            DialogSave.RestoreDirectory = true;
            DialogSave.Title = "Where do you want to save the file ?";
            DialogSave.InitialDirectory = @"C:/";
            DialogSave.FileName = "BbanChamThiTNSQQLBoong_" + DateTime.Today.ToString("ddMMyyyy");
            dt = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
                //=============Start exporting report
                if (DialogSave.ShowDialog() == DialogResult.OK)
                {
                    Application.DoEvents();
                    this.Refresh();
                    Cursor.Current = Cursors.WaitCursor;

                    string appPath = AppDomain.CurrentDomain.BaseDirectory;
                    int indexOfProjectName = appPath.LastIndexOf("TTHLTV");
                    string sourceFile = appPath + "Report\\BbanChamThiTNSQQLBoong.xls";
                    string destFile = DialogSave.FileName;

                    try
                    {
                        File.Copy(sourceFile, destFile, true);
                    }
                    catch (IOException io)
                    {
                        MessageBox.Show(io.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Start Excel and get Application object.
                    xlsApp = new Excel.Application();
                    xlsApp.Visible = false;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    // Create new workbook.
                    xlsWorkbook = (Excel.Workbook)(xlsApp.Workbooks.Open(destFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                    xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
                    try
                    {
                        // Get worksheets
                        xlsWorksheet = (Excel.Worksheet)xlsWorkbook.Worksheets[1];      // downloaded sheet
                        xlsWorksheet2 = (Excel.Worksheet)xlsWorkbook.Worksheets[2];     // template sheet

                        // Delete all content of sheet
                        xlsWorksheet.Cells.Clear();
                        // Output title to excel file
                        xlsRange = xlsWorksheet.get_Range("A1", "Q55");//sheet download
                        xlsRange2 = xlsWorksheet2.get_Range("A1", "Q55");//sheet template
                        xlsRange2.Copy(xlsRange);

                        //DataTable tb2 = new DataTable();
                        //tb2 = boDkh.ExportExcel_Info_DiemDanh(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()));
                        xlsRange.Cells[6, 4] = "BIÊN BẢN CHẤM THI TỐT NGHIỆP LỚP " + lookLop_InGCN.GetColumnValue("LOP_Name");
                        xlsRange.Cells[8, 4] = "MÔN THI: " + lookMonHoc.GetColumnValue("MON_Name");

                        //object sS = tb2.Rows[0]["LOP_Ngay_KG"].ToString();
                        //object sS1 = tb2.Rows[0]["LOP_Ngay_KG"].ToString();

                        //string datesS = sS.ToString();
                        //string datesS1 = sS1.ToString();
                        //DateTimeFormatInfo dateTimeFormatterProviderS = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                        //dateTimeFormatterProviderS.ShortDatePattern = "MM/dd/yyyy";
                        //DateTime dateTimeS = DateTime.Parse(datesS, dateTimeFormatterProviderS);
                        //DateTime dateTimeS1 = DateTime.Parse(datesS1, dateTimeFormatterProviderS);
                        //string formattedS = dateTimeS.ToString("dd/MM/yyyy");
                        //string formattedS1 = dateTimeS1.ToString("dd/MM/yyyy");

                        //xlsRange.Cells[8, 6] = "Từ ngày: " + "  " + formattedS.ToString();
                        //xlsRange.Cells[8, 8] = "Đến ngày: " + "  " + formattedS1.ToString();
                        //xlsRange.Cells[9, 4] = "Giáo viên: " + tb2.Rows[0]["GIV_Name"].ToString();
                        //fill data
                        rowCurrent = 13;
                        int index = 0;
                        int sCount = dt.Rows.Count + 4;
                        int i;
                        for (i = 0; i < sCount; i++)
                        {
                            // Border title
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.Value = 1;
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.LineStyle = BorderStyle.FixedSingle;

                            rowCurrent = rowCurrent + 1;
                            index = index + 1;
                            xlsRange = xlsWorksheet.get_Range("A" + (rowCurrent).ToString(), "H" + (rowCurrent).ToString());//sheet download
                            int ts = dt.Rows.Count;
                            if (i < ts)
                            {
                                //object s = dt.Rows[i]["HOV_BirthDay"].ToString();
                                //string dates = s.ToString();
                                //DateTimeFormatInfo dateTimeFormatterProvider = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                                //dateTimeFormatterProvider.ShortDatePattern = "MM/dd/yyyy";
                                //DateTime dateTime = DateTime.Parse(dates, dateTimeFormatterProvider);
                                //string formatted = dateTime.ToString("dd/MM/yyyy");

                                xlsRange.Cells[1, 1] = index;
                                xlsRange.Cells[1, 2] = dt.Rows[i]["HOV_FirstName"].ToString(); // +" " + dt.Rows[i]["HOV_LastName"].ToString();
                                xlsRange.Cells[1, 3] = dt.Rows[i]["HOV_LastName"].ToString();
                                //xlsRange.Cells[1, 4] = dt.Rows[i]["HOV_BirthDay"].ToString();// formatted.ToString();//dt.Rows[i]["FullName"].ToString();
                                //xlsRange.Cells[1, 5] = dt.Rows[i]["HOV_NoiSinh"].ToString();
                                //xlsRange.Cells[1, 5] = dt.Rows[i]["HOV_Phone"].ToString();
                                //xlsRange.Cells[1, 6] = dt.Rows[i]["HOV_ChucDanh"].ToString();
                                //xlsRange.Cells[1, 7] = dt.Rows[i]["HOV_DonVi"].ToString();
                                //xlsRange.Cells[1, 8] = dt.Rows[i]["DKH_BienLai"].ToString();
                                //xlsRange.Cells[1, 9] = dt.Rows[i]["HOV_GhiChu"].ToString();

                            }
                            else
                            {
                                xlsRange.Cells[1, 1] = index;
                                xlsRange.Cells[1, 2] = "";
                                xlsRange.Cells[1, 3] = "";
                                xlsRange.Cells[1, 4] = "";
                                xlsRange.Cells[1, 5] = "";
                                xlsRange.Cells[1, 6] = "";
                                xlsRange.Cells[1, 7] = "";
                                xlsRange.Cells[1, 8] = "";
                                xlsRange.Cells[1, 9] = "";

                            }

                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).RowHeight = 17;
                            //Ve border cho rows cuoi cung.
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.Value = 1;
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Font.Name = "Times New Roman";
                        }
                        // =====Delete templete sheet====
                        xlsApp.DisplayAlerts = true;
                        ((Excel.Worksheet)xlsWorkbook.Sheets[2]).Delete();

                        // Save and close workbook
                        xlsWorkbook.Save();

                        MessageBox.Show("Xuất file thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //xlsApp.ActiveWorkbook.PrintPreview(); //Tai sao khong PrintPreview duoc?
                        // =======   end exporting report ==============

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        xlsWorkbook.Save();
                        //File.Delete(destFile);
                    }
                    finally
                    {
                        //xlsWorksheet2.Delete();

                        xlsWorkbook.Close(false, false, false);
                        xlsApp.Workbooks.Close();
                        xlsApp.Quit();

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                        Cursor.Current = Cursors.Default;
                    }
                }
 
        }
        private void BienbanChamThiSQVHBoong()
        {
            // Declare variables
            Excel.Application xlsApp;
            Excel.Workbook xlsWorkbook;
            Excel.Worksheet xlsWorksheet;
            Excel.Worksheet xlsWorksheet2;
            Excel.Range xlsRange = null;
            Excel.Range xlsRange2 = null;
            int rowCurrent = 1;
            DataTable dt = new DataTable();

            //Open save file dialog
            SaveFileDialog DialogSave = new SaveFileDialog();
            DialogSave.DefaultExt = "xls";
            DialogSave.Filter = "Excel file (*.xls)|*.xls|All files (*.*)|*.*";
            DialogSave.AddExtension = true;
            DialogSave.RestoreDirectory = true;
            DialogSave.Title = "Where do you want to save the file ?";
            DialogSave.InitialDirectory = @"C:/";
            DialogSave.FileName = "BbanChamThiSQVHBoong_" + DateTime.Today.ToString("ddMMyyyy");
            dt = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
                //=============Start exporting report
                if (DialogSave.ShowDialog() == DialogResult.OK)
                {
                    Application.DoEvents();
                    this.Refresh();
                    Cursor.Current = Cursors.WaitCursor;

                    string appPath = AppDomain.CurrentDomain.BaseDirectory;
                    int indexOfProjectName = appPath.LastIndexOf("TTHLTV");
                    string sourceFile = appPath + "Report\\BbanChamThiSQVHBoong.xls";
                    string destFile = DialogSave.FileName;

                    try
                    {
                        File.Copy(sourceFile, destFile, true);
                    }
                    catch (IOException io)
                    {
                        MessageBox.Show(io.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Start Excel and get Application object.
                    xlsApp = new Excel.Application();
                    xlsApp.Visible = false;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    // Create new workbook.
                    xlsWorkbook = (Excel.Workbook)(xlsApp.Workbooks.Open(destFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                    xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
                    try
                    {
                        // Get worksheets
                        xlsWorksheet = (Excel.Worksheet)xlsWorkbook.Worksheets[1];      // downloaded sheet
                        xlsWorksheet2 = (Excel.Worksheet)xlsWorkbook.Worksheets[2];     // template sheet

                        // Delete all content of sheet
                        xlsWorksheet.Cells.Clear();
                        // Output title to excel file
                        xlsRange = xlsWorksheet.get_Range("A1", "R55");//sheet download
                        xlsRange2 = xlsWorksheet2.get_Range("A1", "R55");//sheet template
                        xlsRange2.Copy(xlsRange);

                        //DataTable tb2 = new DataTable();
                        //tb2 = boDkh.ExportExcel_Info_DiemDanh(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()));
                        xlsRange.Cells[4, 12] = "Tp HCM, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                        xlsRange.Cells[6, 4] = "LỚP " + lookLop_InGCN.GetColumnValue("LOP_Name");
                        //xlsRange.Cells[8, 4] = "MÔN THI: " + lookMonHoc.GetColumnValue("MON_Name");

                        //object sS = tb2.Rows[0]["LOP_Ngay_KG"].ToString();
                        //object sS1 = tb2.Rows[0]["LOP_Ngay_KG"].ToString();

                        //string datesS = sS.ToString();
                        //string datesS1 = sS1.ToString();
                        //DateTimeFormatInfo dateTimeFormatterProviderS = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                        //dateTimeFormatterProviderS.ShortDatePattern = "MM/dd/yyyy";
                        //DateTime dateTimeS = DateTime.Parse(datesS, dateTimeFormatterProviderS);
                        //DateTime dateTimeS1 = DateTime.Parse(datesS1, dateTimeFormatterProviderS);
                        //string formattedS = dateTimeS.ToString("dd/MM/yyyy");
                        //string formattedS1 = dateTimeS1.ToString("dd/MM/yyyy");

                        //xlsRange.Cells[8, 6] = "Từ ngày: " + "  " + formattedS.ToString();
                        //xlsRange.Cells[8, 8] = "Đến ngày: " + "  " + formattedS1.ToString();
                        //xlsRange.Cells[9, 4] = "Giáo viên: " + tb2.Rows[0]["GIV_Name"].ToString();
                        //fill data
                        rowCurrent = 13;
                        int index = 0;
                        int sCount = dt.Rows.Count + 4;
                        int i;
                        for (i = 0; i < sCount; i++)
                        {
                            // Border title
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.Value = 1;
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.LineStyle = BorderStyle.FixedSingle;

                            rowCurrent = rowCurrent + 1;
                            index = index + 1;
                            xlsRange = xlsWorksheet.get_Range("A" + (rowCurrent).ToString(), "H" + (rowCurrent).ToString());//sheet download
                            int ts = dt.Rows.Count;
                            if (i < ts)
                            {
                                //object s = dt.Rows[i]["HOV_BirthDay"].ToString();
                                //string dates = s.ToString();
                                //DateTimeFormatInfo dateTimeFormatterProvider = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                                //dateTimeFormatterProvider.ShortDatePattern = "MM/dd/yyyy";
                                //DateTime dateTime = DateTime.Parse(dates, dateTimeFormatterProvider);
                                //string formatted = dateTime.ToString("dd/MM/yyyy");

                                xlsRange.Cells[1, 1] = index;
                                xlsRange.Cells[1, 2] = dt.Rows[i]["HOV_FirstName"].ToString(); // +" " + dt.Rows[i]["HOV_LastName"].ToString();
                                xlsRange.Cells[1, 3] = dt.Rows[i]["HOV_LastName"].ToString();
                                //xlsRange.Cells[1, 4] = dt.Rows[i]["HOV_BirthDay"].ToString();// formatted.ToString();//dt.Rows[i]["FullName"].ToString();
                                //xlsRange.Cells[1, 5] = dt.Rows[i]["HOV_NoiSinh"].ToString();
                                //xlsRange.Cells[1, 5] = dt.Rows[i]["HOV_Phone"].ToString();
                                //xlsRange.Cells[1, 6] = dt.Rows[i]["HOV_ChucDanh"].ToString();
                                //xlsRange.Cells[1, 7] = dt.Rows[i]["HOV_DonVi"].ToString();
                                //xlsRange.Cells[1, 8] = dt.Rows[i]["DKH_BienLai"].ToString();
                                //xlsRange.Cells[1, 9] = dt.Rows[i]["HOV_GhiChu"].ToString();

                            }
                            else
                            {
                                xlsRange.Cells[1, 1] = index;
                                xlsRange.Cells[1, 2] = "";
                                xlsRange.Cells[1, 3] = "";
                                xlsRange.Cells[1, 4] = "";
                                xlsRange.Cells[1, 5] = "";
                                xlsRange.Cells[1, 6] = "";
                                xlsRange.Cells[1, 7] = "";
                                xlsRange.Cells[1, 8] = "";
                                xlsRange.Cells[1, 9] = "";

                            }

                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).RowHeight = 17;
                            //Ve border cho rows cuoi cung.
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.Value = 1;
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Font.Name = "Times New Roman";
                        }
                        // =====Delete templete sheet====
                        xlsApp.DisplayAlerts = true;
                        ((Excel.Worksheet)xlsWorkbook.Sheets[2]).Delete();

                        // Save and close workbook
                        xlsWorkbook.Save();

                        MessageBox.Show("Xuất file thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //xlsApp.ActiveWorkbook.PrintPreview(); //Tai sao khong PrintPreview duoc?
                        // =======   end exporting report ==============

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        xlsWorkbook.Save();
                        //File.Delete(destFile);
                    }
                    finally
                    {
                        //xlsWorksheet2.Delete();

                        xlsWorkbook.Close(false, false, false);
                        xlsApp.Workbooks.Close();
                        xlsApp.Quit();

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                        Cursor.Current = Cursors.Default;
                    }
                }
 
        }
        #endregion
        #region SQVH BOONG
        private void dsThiSQVH_Boong()
        {
            // Declare variables
            Excel.Application xlsApp;
            Excel.Workbook xlsWorkbook;
            Excel.Worksheet xlsWorksheet;
            Excel.Worksheet xlsWorksheet2;
            Excel.Range xlsRange = null;
            Excel.Range xlsRange2 = null;
            int rowCurrent = 1;
            DataTable dt = new DataTable();

            //Open save file dialog
            SaveFileDialog DialogSave = new SaveFileDialog();
            DialogSave.DefaultExt = "xls";
            DialogSave.Filter = "Excel file (*.xls)|*.xls|All files (*.*)|*.*";
            DialogSave.AddExtension = true;
            DialogSave.RestoreDirectory = true;
            DialogSave.Title = "Where do you want to save the file ?";
            DialogSave.InitialDirectory = @"C:/";
            DialogSave.FileName = "DsthiSQVH_BOONG_" + DateTime.Today.ToString("ddMMyyyy");
            dt = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
                //=============Start exporting report
                if (DialogSave.ShowDialog() == DialogResult.OK)
                {
                    Application.DoEvents();
                    this.Refresh();
                    Cursor.Current = Cursors.WaitCursor;

                    string appPath = AppDomain.CurrentDomain.BaseDirectory;
                    int indexOfProjectName = appPath.LastIndexOf("TTHLTV");
                    string sourceFile = appPath + "Report\\DsthiSQVH_BOONG.xls";
                    string destFile = DialogSave.FileName;

                    try
                    {
                        File.Copy(sourceFile, destFile, true);
                    }
                    catch (IOException io)
                    {
                        MessageBox.Show(io.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Start Excel and get Application object.
                    xlsApp = new Excel.Application();
                    xlsApp.Visible = false;
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    // Create new workbook.
                    xlsWorkbook = (Excel.Workbook)(xlsApp.Workbooks.Open(destFile, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value));
                    xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
                    try
                    {
                        // Get worksheets
                        xlsWorksheet = (Excel.Worksheet)xlsWorkbook.Worksheets[1];      // downloaded sheet
                        xlsWorksheet2 = (Excel.Worksheet)xlsWorkbook.Worksheets[2];     // template sheet

                        // Delete all content of sheet
                        xlsWorksheet.Cells.Clear();
                        // Output title to excel file
                        xlsRange = xlsWorksheet.get_Range("A1", "H55");//sheet download
                        xlsRange2 = xlsWorksheet2.get_Range("A1", "H55");//sheet template
                        xlsRange2.Copy(xlsRange);

                        //DataTable tb2 = new DataTable();
                        //tb2 = boDkh.ExportExcel_Info_DiemDanh(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()));
                        xlsRange.Cells[4, 5] = "Tp HCM, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                        xlsRange.Cells[8, 2] = "LỚP: " + lookLop_InGCN.GetColumnValue("LOP_Name");
                        //xlsRange.Cells[6, 6] = "MÔN: " + lookMonHoc.GetColumnValue("MON_Name");

                        //object sS = tb2.Rows[0]["LOP_Ngay_KG"].ToString();
                        //object sS1 = tb2.Rows[0]["LOP_Ngay_KG"].ToString();

                        //string datesS = sS.ToString();
                        //string datesS1 = sS1.ToString();
                        //DateTimeFormatInfo dateTimeFormatterProviderS = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                        //dateTimeFormatterProviderS.ShortDatePattern = "MM/dd/yyyy";
                        //DateTime dateTimeS = DateTime.Parse(datesS, dateTimeFormatterProviderS);
                        //DateTime dateTimeS1 = DateTime.Parse(datesS1, dateTimeFormatterProviderS);
                        //string formattedS = dateTimeS.ToString("dd/MM/yyyy");
                        //string formattedS1 = dateTimeS1.ToString("dd/MM/yyyy");

                        //xlsRange.Cells[8, 6] = "Từ ngày: " + "  " + formattedS.ToString();
                        //xlsRange.Cells[8, 8] = "Đến ngày: " + "  " + formattedS1.ToString();
                        //xlsRange.Cells[9, 4] = "Giáo viên: " + tb2.Rows[0]["GIV_Name"].ToString();
                        //fill data
                        rowCurrent = 13;
                        int index = 0;
                        int sCount = dt.Rows.Count + 4;
                        int i;
                        for (i = 0; i < sCount; i++)
                        {
                            // Border title
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.Value = 1;
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.LineStyle = BorderStyle.FixedSingle;

                            rowCurrent = rowCurrent + 1;
                            index = index + 1;
                            xlsRange = xlsWorksheet.get_Range("A" + (rowCurrent).ToString(), "H" + (rowCurrent).ToString());//sheet download
                            int ts = dt.Rows.Count;
                            if (i < ts)
                            {
                                //object s = dt.Rows[i]["HOV_BirthDay"].ToString();
                                //string dates = s.ToString();
                                //DateTimeFormatInfo dateTimeFormatterProvider = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                                //dateTimeFormatterProvider.ShortDatePattern = "MM/dd/yyyy";
                                //DateTime dateTime = DateTime.Parse(dates, dateTimeFormatterProvider);
                                //string formatted = dateTime.ToString("dd/MM/yyyy");

                                xlsRange.Cells[1, 1] = index;
                                xlsRange.Cells[1, 2] = dt.Rows[i]["HOV_FirstName"].ToString(); // +" " + dt.Rows[i]["HOV_LastName"].ToString();
                                xlsRange.Cells[1, 3] = dt.Rows[i]["HOV_LastName"].ToString();
                                xlsRange.Cells[1, 4] = dt.Rows[i]["HOV_BirthDay"].ToString();// formatted.ToString();//dt.Rows[i]["FullName"].ToString();
                                xlsRange.Cells[1, 5] = dt.Rows[i]["HOV_NoiSinh"].ToString();
                                //xlsRange.Cells[1, 5] = dt.Rows[i]["HOV_Phone"].ToString();
                                //xlsRange.Cells[1, 6] = dt.Rows[i]["HOV_ChucDanh"].ToString();
                                //xlsRange.Cells[1, 7] = dt.Rows[i]["HOV_DonVi"].ToString();
                                //xlsRange.Cells[1, 8] = dt.Rows[i]["DKH_BienLai"].ToString();
                                //xlsRange.Cells[1, 9] = dt.Rows[i]["HOV_GhiChu"].ToString();

                            }
                            else
                            {
                                xlsRange.Cells[1, 1] = index;
                                xlsRange.Cells[1, 2] = "";
                                xlsRange.Cells[1, 3] = "";
                                xlsRange.Cells[1, 4] = "";
                                xlsRange.Cells[1, 5] = "";
                                xlsRange.Cells[1, 6] = "";
                                xlsRange.Cells[1, 7] = "";
                                xlsRange.Cells[1, 8] = "";
                                xlsRange.Cells[1, 9] = "";

                            }

                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).RowHeight = 17;
                            //Ve border cho rows cuoi cung.
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Borders.Value = 1;
                            //((Excel.Range)xlsWorksheet.Rows[rowCurrent, Type.Missing]).Font.Name = "Times New Roman";
                        }
                        // =====Delete templete sheet====
                        xlsApp.DisplayAlerts = true;
                        ((Excel.Worksheet)xlsWorkbook.Sheets[2]).Delete();

                        // Save and close workbook
                        xlsWorkbook.Save();

                        MessageBox.Show("Xuất file thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //xlsApp.ActiveWorkbook.PrintPreview(); //Tai sao khong PrintPreview duoc?
                        // =======   end exporting report ==============

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        xlsWorkbook.Save();
                        //File.Delete(destFile);
                    }
                    finally
                    {
                        //xlsWorksheet2.Delete();

                        xlsWorkbook.Close(false, false, false);
                        xlsApp.Workbooks.Close();
                        xlsApp.Quit();

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                        Cursor.Current = Cursors.Default;
                    }
                }

        }
        #endregion
        private void DsVaoPhongThi()
        {
            int currentRow = 11;
            xlsApp = new Excel.Application();
            if (lookMonHoc.ItemIndex==1)
            {
                xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DS_vao_phong_thi.xlt");
            }
            else if (lookMonHoc.ItemIndex == 2)
            {
                xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DS_vao_phong_thi_2.xlt");
            }
            else if (lookMonHoc.ItemIndex == 3)
            {
                xlsWorkbook = xlsApp.Workbooks.Open(Application.StartupPath + "\\Template\\DS_vao_phong_thi_3.xlt");
            }
            
            
            xlsWorksheet = (Excel.Worksheet)xlsWorkbook.ActiveSheet;
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();
            table = boHv.ExportExcel_DsHocVien_ByLopID(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()));
            if (table.Rows.Count < 0)
            {
                MessageBox.Show(" Lớp học này chưa có học viên", "THÔNG BÁO");
                return;
            }
            else
            {
                xlsWorksheet.Cells[6, ExcelColumns.colB] = "LỚP: " + lookLop_InGCN.GetColumnValue("LOP_Name");
                xlsWorksheet.Cells[6, ExcelColumns.colE] = "MÔN: " + lookMonHoc.GetColumnValue("MON_Name");
                if (lookMonHoc.ItemIndex < 0)
                {
                    MessageBox.Show("Chưa chọn môn học", "THÔNG BÁO");
                    return;
                }
                table2 = boDkh.ExportExcel_Info_DiemDanh(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()));
                var xls = xlsWorksheet;
                {
                    for (int i = 0; i < table.Rows.Count + 4; i++)
                    {
                        if (i < table.Rows.Count)
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 10;
                            xls.Cells[currentRow, ExcelColumns.colB] = table.Rows[i]["HOV_FirstName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colC] = table.Rows[i]["HOV_LastName"].ToString();
                            xls.Cells[currentRow, ExcelColumns.colD] = table.Rows[i]["HOV_BirthDay"].ToString();
                        }
                        else
                        {
                            xls.Cells[currentRow, ExcelColumns.colA] = currentRow - 10;
                        }
                        currentRow++;
                    }
                }

                if (currentRow > 11)
                {
                    drawBorder("D12:H" + (currentRow - 1).ToString());
                    drawBorderOneColumn("A12:A" + (currentRow - 1).ToString());
                    drawBorderNone("B12:C" + (currentRow - 1).ToString());
                }
                xls.Cells[currentRow + 2, ExcelColumns.colB] = "Giám thị 2";
                xls.Cells[currentRow + 2, ExcelColumns.colE] = "Giám thị 1";
                xlsApp.Visible = true;
                table = null;
                xlsApp = null;
                xlsWorkbook = null;
                xlsWorksheet = null;
            }
        }
        private void sLoadLanThi()
        {
            lookLanThi.Properties.DataSource = boDiem.lanThi(int.Parse(lookLop_InGCN.GetColumnValue("LOP_ID").ToString()),int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()));
            lookLanThi.Properties.ValueMember = "DIE_LanThi";
            lookLanThi.Properties.DisplayMember = "DIE_LanThi";
            lookLanThi.ItemIndex = 0;
        }
        private DataSet initMonHoc_SQQL()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("MonHoc");

            //-- Add columns to the data table
            sTable.Columns.Add("MON_ID", typeof(int));
            sTable.Columns.Add("MON_Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "                    ");
            sTable.Rows.Add(2, "Diesel và Khai thác máy tàu");
            sTable.Rows.Add(3, "Điện và Tự động");
            sTable.Rows.Add(4, "Thực hành tổng hợp và Anh văn ");
            return sDataset;

        }
        private void bindingMonHoc_SQQL()
        {
            // Biding data to search tool
            lookMonHoc.Properties.DataSource = initMonHoc_SQQL().Tables["MonHoc"];
            lookMonHoc.Properties.ValueMember = "MON_ID";
            lookMonHoc.Properties.DisplayMember = "MON_Name";
            lookMonHoc.ItemIndex = 0;

        }
        private DataSet initMonHoc_SQQLBoong()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("MonHoc");

            //-- Add columns to the data table
            sTable.Columns.Add("MON_ID", typeof(int));
            sTable.Columns.Add("MON_Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "                    ");
            sTable.Rows.Add(2, "HÀNG HẢI TỔNG HỢP-ANH VĂN");
            sTable.Rows.Add(3, "NGHIỆP VỤ TỔNG HỢP-ANH VĂN");
            sTable.Rows.Add(4, "THỰC HÀNH TỔNG HỢP-ANH VĂN ");
            return sDataset;
           
        }
        private void bindingMonHoc_SQQLBoong()
        {
            // Biding data to search tool
            lookMonHoc.Properties.DataSource = initMonHoc_SQQLBoong().Tables["MonHoc"];
            lookMonHoc.Properties.ValueMember = "MON_ID";
            lookMonHoc.Properties.DisplayMember = "MON_Name";
            lookMonHoc.ItemIndex = 0;
 
        }
        #region Load lookup chung chi
        private DataTable getKhoaHoc()
        {
            BAL.BO_CHUNG_CHI bal = new BO_CHUNG_CHI();
            return bal.getChungChi_All();
        }
        private void loadKhoaHoc()
        {
            lookKhoaHoc_InGCN.Properties.DataSource = getKhoaHoc();
            lookKhoaHoc_InGCN.Properties.ValueMember = "CHC_ID";
            lookKhoaHoc_InGCN.Properties.DisplayMember = "CHC_Name";
        }
        #endregion
        #region Load lookup lop hoc
        private DataTable getLopHoc()
        {
            BAL.BO_LOP bal = new BO_LOP();
            return bal.getLOP_ByCcID(int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()));
        }
        private void loadLopHoc()
        {
            lookLop_InGCN.ItemIndex = 0;
            lookLop_InGCN.Refresh();
            
            lookLop_InGCN.Properties.DataSource = getLopHoc();
            lookLop_InGCN.Properties.ValueMember = "LOP_ID";
            lookLop_InGCN.Properties.DisplayMember = "LOP_Name";
        }
        #endregion
        #region Load lookup Mon hoc
        private void loadMonHoc()
        {
            BO_DANG_KI_HOC dao_dangki_hoc = new BO_DANG_KI_HOC();
            lookMonHoc.Properties.DataSource = dao_dangki_hoc.getSubjectName(int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString()));
            lookMonHoc.Properties.ValueMember = "MON_ID";
            lookMonHoc.Properties.DisplayMember = "MON_Name";
           
        }
        #endregion
        private void sCheckVisible()
        {
            btnDsHvCapGCN.Enabled = false;
            btnPhieuDiem.Enabled = false;
            btnPhieuDiemDanh.Enabled = false;
            btnPrint_InDsHv.Enabled = false;
            btnBbChamThi.Enabled = false;
            lookLop_InGCN.Enabled = false;
            btnPrint_InGCN.Enabled = false;
            lookKhoaHoc_InGCN.Enabled = false;
            lookMonHoc.Enabled = false;
            lookLanThi.Enabled = false;
            lookUpSoHieuDoi.Visible = false;
        }
        private void sCheckRadioSlected()
        {
            //co the dung usecase
            if (radioSelect.SelectedIndex == 0)
            {
                sCheckVisible();
                btnPrint_InDsHv.Enabled = true;
                lookLop_InGCN.Visible = true;
                radCapQ.Enabled = false;
                return;
            }
            else
                if (radioSelect.SelectedIndex == 1)
                {
                    sCheckVisible();
                    lookMonHoc.Enabled = true;
                    btnPhieuDiemDanh.Enabled = true;
                    lookLop_InGCN.Visible = true;
                    radCapQ.Enabled = false;
                    return;
                }
                else
                    if (radioSelect.SelectedIndex == 2)
                    {
                        sCheckVisible();
                        lookMonHoc.Enabled = true;
                        btnPhieuDiem.Enabled = true;
                        lookLanThi.Enabled = true;
                        lookLop_InGCN.Visible = true;
                        radCapQ.Enabled = false;
                        return;
                    }
                    else
                        if (radioSelect.SelectedIndex == 3)
                        {
                            sCheckVisible();
                            btnDsHvCapGCN.Enabled = true;
                            lookLop_InGCN.Visible = true;
                            radCapQ.Enabled = true;
                            radCapQ.SelectedIndex = 0;
                            return;
                        }
                        else
                            if (radioSelect.SelectedIndex == 4)
                            {
                                sCheckVisible();
                                btnPrint_InGCN.Enabled = true;
                                radCapQ.Enabled = true;
                                lookLop_InGCN.Visible = true;
                                radCapQ.SelectedIndex = 0;
                                return;
                            }
                            else if (radioSelect.SelectedIndex == 5)
                            {
                                sCheckVisible();
                                btnBbChamThi.Enabled = true;
                                lookLop_InGCN.Visible = true;
                                return;
                            }
        }
        enum ExcelColumns
        {
            colA = 1,
            colB = 2,
            colC = 3,
            colD = 4,
            colE = 5,
            colF = 6,
            colG = 7,
            colH = 8,
            colI = 9,
            colJ = 10,
            colK = 11,
            colL = 12,
            colM = 13,
            colN = 14,
            colO = 15,
            colP = 16

        };
        public void drawBorder(string _range)
        {
            //excelWS.Range(_range).Select()

            //excelWS.Cells.Range(_range).Borders ()

            var _with1 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeLeft];
           _with1.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with1.Weight = Excel.XlBorderWeight.xlHairline;
            _with1.ColorIndex = Excel.Constants.xlAutomatic;
            var _with2 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeTop];
            _with2.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with2.Weight = Excel.XlBorderWeight.xlHairline;
            _with2.ColorIndex = Excel.Constants.xlAutomatic;
            var _with3 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeBottom];
            _with3.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with3.Weight = Excel.XlBorderWeight.xlHairline;
            _with3.ColorIndex = Excel.Constants.xlAutomatic;
            var _with4 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeRight];
            _with4.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with4.Weight = Excel.XlBorderWeight.xlHairline;
            _with4.ColorIndex = Excel.Constants.xlAutomatic;
            var _with5 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideVertical];
            _with5.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with5.Weight = Excel.XlBorderWeight.xlHairline;
            _with5.ColorIndex = Excel.Constants.xlAutomatic;
            var _with6 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideHorizontal];
            _with6.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with6.Weight = Excel.XlBorderWeight.xlHairline;
            _with6.ColorIndex = Excel.Constants.xlAutomatic;
        }
        public void drawBorderOneColumn(string _range)
        {

            var _with1 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeLeft];
            _with1.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with1.Weight = Excel.XlBorderWeight.xlHairline;
            _with1.ColorIndex = Excel.Constants.xlAutomatic;
            var _with2 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeTop];
            _with2.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with2.Weight = Excel.XlBorderWeight.xlHairline;
            _with2.ColorIndex = Excel.Constants.xlAutomatic;
            var _with3 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeBottom];
            _with3.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with3.Weight = Excel.XlBorderWeight.xlHairline;
            _with3.ColorIndex = Excel.Constants.xlAutomatic;
            var _with4 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeRight];
            _with4.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with4.Weight = Excel.XlBorderWeight.xlHairline;
            _with4.ColorIndex = Excel.Constants.xlAutomatic;
            //var _with5 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideVertical];
            //_with5.LineStyle = Excel.XlLineStyle.xlContinuous;
            //_with5.Weight = Excel.XlBorderWeight.xlHairline;
            //_with5.ColorIndex = Excel.Constants.xlAutomatic;
            var _with6 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideHorizontal];
            _with6.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with6.Weight = Excel.XlBorderWeight.xlHairline;
            _with6.ColorIndex = Excel.Constants.xlAutomatic;
        }
        public void drawBorderNone(string _range)
        {

            //var _with1 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeLeft];
            //_with1.LineStyle = Excel.XlLineStyle.xlContinuous;
            //_with1.Weight = Excel.XlBorderWeight.xlMedium;
            //_with1.ColorIndex = Excel.Constants.xlAutomatic;
            var _with2 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeTop];
            _with2.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with2.Weight = Excel.XlBorderWeight.xlHairline;
            _with2.ColorIndex = Excel.Constants.xlAutomatic;
            var _with3 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeBottom];
            _with3.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with3.Weight = Excel.XlBorderWeight.xlHairline;
            _with3.ColorIndex = Excel.Constants.xlAutomatic;
            //var _with4 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlEdgeRight];
            //_with4.LineStyle = Excel.XlLineStyle.xlContinuous;
            //_with4.Weight = Excel.XlBorderWeight.xlMedium;
            //_with4.ColorIndex = Excel.Constants.xlAutomatic;
            //var _with5 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideVertical];
            //_with5.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            //_with5.Weight = Excel.XlBorderWeight.xlHairline;
            //_with5.ColorIndex = Excel.Constants.xlAutomatic;
            var _with6 = xlsWorksheet.Cells.Range[_range].Borders[Excel.XlBordersIndex.xlInsideHorizontal];
            _with6.LineStyle = Excel.XlLineStyle.xlContinuous;
            _with6.Weight = Excel.XlBorderWeight.xlHairline;
            _with6.ColorIndex = Excel.Constants.xlAutomatic;
        }
        private void radCapQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radCapQ.SelectedIndex == 1|| radCapQ.SelectedIndex==2)
            {
                lookUpSoHieuDoi.Visible = true;
                lookLop_InGCN.Visible = false;
                lookUpSoHieuDoi.Enabled = true;
                LoadSoHieuDoi();
            }
            else
            {
                lookUpSoHieuDoi.Visible = false;
                lookLop_InGCN.Visible = true;
            }
           
        }
        private void LoadSoHieuDoi()
        {
            if (lookKhoaHoc_InGCN.ItemIndex < 0)
            {
                MessageBox.Show("Chưa chọn chứng chỉ", "THÔNG BÁO");
                return;

            }
            else
            {
                lookUpSoHieuDoi.Properties.DataSource = getSoHieuDoi();
                lookUpSoHieuDoi.Properties.ValueMember = "CCC_SoHieuDoi";
                lookUpSoHieuDoi.Properties.DisplayMember = "CCC_SoHieuDoi";
            }
        }
        private DataTable getSoHieuDoi()
        {
            int mChungChiID = -1;
            int sCap = -1;
            mChungChiID = int.Parse(lookKhoaHoc_InGCN.GetColumnValue("CHC_ID").ToString());
            if (radCapQ.SelectedIndex==1)
            {
                sCap = 2;
            }
            else if (radCapQ.SelectedIndex==2)
            {
                sCap = 3;
            }
            return boCcc.get_SoHieuDoi_Cc(mChungChiID, sCap);



        }
        private Image loadImage(DataRow vRow)
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
            return Img;
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
        private static Image resizeImage(Image _img, int _width, int _height)
        {
            Bitmap new_image = new Bitmap(_width, _height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.DrawImage(_img, 20, 20, _width, _height);
            return new_image;
        }
        byte[] imgArray;
        private Image Img;
        string vImgFileName;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TTHLTV.InBieuMau.frmInBieuMau frm = new InBieuMau.frmInBieuMau();
            frm.ShowDialog();
        }
    }
}