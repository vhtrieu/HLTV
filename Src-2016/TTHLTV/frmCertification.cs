using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using Microsoft.Office.Core;
using Microsoft.ApplicationBlocks.Data;

//using CrystalDecisions.CrystalReports.Engine;

using TTHLTV.BAL;
using System.Diagnostics;
using DevExpress.XtraBars;


namespace TTHLTV
{
    public partial class frmCertification : DevExpress.XtraEditors.XtraForm
    {
        BO_CAP_CHUNGCHI ccc = new BO_CAP_CHUNGCHI();
       // BO_DANG_KI_HOC dkHoc = new BO_DANG_KI_HOC();
        public frmCertification()
        {
            InitializeComponent();
        }

        #region EVENTS
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddNewCertificate frm = new frmAddNewCertificate();
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = gridContentCertificate.GetDataRow(gridContentCertificate.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa chứng chỉ đã cấp này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = int.Parse(selectedRow["CCC_ID"].ToString());
                    selectedRow.Delete();
                    ccc.delete(id);
                    ShowData();
                }
            }
        }

        private void frmCertification_Load(object sender, EventArgs e)
        {
            SetGridFont(gridCertificate.MainView, new Font("Tahoma", 11));
            acticeSearch();
            ShowData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // TO DO
        }


        #endregion

        #region Extenal function
        private void ShowData()
        {
           // getCAP_CHUNGCHI_WithName
            gridCertificate.DataSource = ccc.getCAP_CHUNGCHI_WithName();
           
        }

       
        private void SetGridFont(DevExpress.XtraGrid.Views.Base.BaseView baseView, Font sFont)
        {
            foreach (AppearanceObject ap in baseView.Appearance)
            {
                ap.Font = sFont;
            }

        }
        private void searchByLastNameContrain()
        {
            gridCertificate.DataSource = ccc.getCAP_CHUNGCHI_HV_SearchLastName(txtSearchText.Text);

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
            sTable.Rows.Add(1, "Tên học viên");
            sTable.Rows.Add(2, "Mã học viên");
            sTable.Rows.Add(3, "Lớp học");

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
        #endregion

        #region ExportToExcel Not Use Template
        /// <summary>
        /// Handles the Click event of the btnExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>

        private void btnExcel_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }


        /// <summary>
        /// Generates the report.
        /// </summary>
        private static void GenerateReport()
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                //set the workbook properties and add a default sheet in it
                SetWorkbookProperties(p);
                //Create a sheet
                ExcelWorksheet ws = CreateSheet(p, "DS Cap CC");
                DataTable dt = CreateDataTable(); //My Function which generates DataTable

                //Merging cells and create a center heading for out table
                ws.Cells[1, 1].Value = "TRƯỜNG ĐẠI HỌC GIAO THÔNG VẬN TẢI THÀNH PHỐ HỒ CHÍ MINH";
                ws.Cells[1, 1, 1, dt.Columns.Count].Merge = true;
                ws.Cells[1, 1, 1, dt.Columns.Count].Style.Font.Bold = true;
                ws.Cells[1, 1, 1, dt.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ws.Cells[2, 1].Value = "TRUNG TÂM HUẤN LUYỆN THUYỀN VIÊN";
                ws.Cells[2, 1, 2, dt.Columns.Count].Merge = true;
                ws.Cells[2, 1, 2, dt.Columns.Count].Style.Font.Bold = true;
                ws.Cells[2, 1, 2, dt.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                int rowIndex = 6;

                CreateHeader(ws, ref rowIndex, dt);
                CreateData(ws, ref rowIndex, dt);
                CreateFooter(ws, ref rowIndex, dt);

                AddComment(ws, 5, 10, "Zeeshan Umar's Comments", "Zeeshan Umar");

                string path = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)), "Zeeshan Umar.jpg");
                AddImage(ws, 10, 0, path);

                AddCustomShape(ws, 10, 7, eShapeStyle.Ellipse, "Text inside Ellipse.");

                //Generate A File with Random name
                Byte[] bin = p.GetAsByteArray();
                string file = Guid.NewGuid().ToString() + ".xlsx";
                File.WriteAllBytes(file, bin);

                //These lines will open it in Excel
                ProcessStartInfo pi = new ProcessStartInfo(file);
                Process.Start(pi);
            }
        }

        private static ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName)
        {
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = sheetName; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet
            
            return ws;
        }

        /// <summary>
        /// Sets the workbook properties and adds a default sheet.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private static void SetWorkbookProperties(ExcelPackage p)
        {
            //Here setting some document properties
            p.Workbook.Properties.Author = "SPINET";
            p.Workbook.Properties.Title = "TTHLTV";


        }

        private static void CreateHeader(ExcelWorksheet ws, ref int rowIndex, DataTable dt)
        {
            int colIndex = 1;
            foreach (DataColumn dc in dt.Columns) //Creating Headings
            {
                var cell = ws.Cells[rowIndex, colIndex];

                //Setting the background color of header cells to Gray
                var fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(Color.Gray);

                //Setting Top/left,right/bottom borders.
                var border = cell.Style.Border;
                border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

                //Setting Value in cell
                cell.Value =  dc.ColumnName;

                colIndex++;
            }
        }

        private static void CreateData(ExcelWorksheet ws, ref int rowIndex, DataTable dt)
        {
            int colIndex = 0;
            foreach (DataRow dr in dt.Rows) // Adding Data into rows
            {
                colIndex = 1;
                rowIndex++;
               //Excel.Workbook workbook = new Excel.Workbook();
               //Excel.Worksheet worksheet = workbook.Worksheets.Add( "Sheet1" );
               //worksheet.Rows[rowIndex].Hieght = 900;
               
                foreach (DataColumn dc in dt.Columns)
                {
                    var cell = ws.Cells[rowIndex, colIndex];

                    //Setting Value in cell
                    cell.Value =dr[dc.ColumnName];
                    
                    //Setting borders of cell
                    var border = cell.Style.Border;
                    border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
                    colIndex++;
                }
               
            }
        }

        private static void CreateFooter(ExcelWorksheet ws, ref int rowIndex, DataTable dt)
        {
            int colIndex = 0;
            foreach (DataColumn dc in dt.Columns) //Creating Formula in footers
            {
                colIndex++;
                var cell = ws.Cells[rowIndex, colIndex];

                //Setting Sum Formula
                cell.Formula = "Sum(" + ws.Cells[3, colIndex].Address + ":" + ws.Cells[rowIndex - 1, colIndex].Address + ")";

                //Setting Background fill color to Gray
                cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                cell.Style.Fill.BackgroundColor.SetColor(Color.Gray);
            }
        }

        /// <summary>
        /// Adds the custom shape.
        /// </summary>
        /// <param name="ws">Worksheet</param>
        /// <param name="colIndex">Column Index</param>
        /// <param name="rowIndex">Row Index</param>
        /// <param name="shapeStyle">Shape style</param>
        /// <param name="text">Text for the shape</param>
        private static void AddCustomShape(ExcelWorksheet ws, int colIndex, int rowIndex, eShapeStyle shapeStyle, string text)
        {
            ExcelShape shape = ws.Drawings.AddShape("cs" + rowIndex.ToString() + colIndex.ToString(), shapeStyle);
            shape.From.Column = colIndex;
            shape.From.Row = rowIndex;
            shape.From.ColumnOff = Pixel2MTU(5);
            shape.SetSize(100, 100);
            shape.RichText.Add(text);
        }

        /// <summary>
        /// Adds the image in excel sheet.
        /// </summary>
        /// <param name="ws">Worksheet</param>
        /// <param name="colIndex">Column Index</param>
        /// <param name="rowIndex">Row Index</param>
        /// <param name="filePath">The file path</param>
        private static void AddImage(ExcelWorksheet ws, int columnIndex, int rowIndex, string filePath)
        {
            //How to Add a Image using EP Plus
            Bitmap image = new Bitmap(filePath);
            ExcelPicture picture = null;
            if (image != null)
            {
                picture = ws.Drawings.AddPicture("pic" + rowIndex.ToString() + columnIndex.ToString(), image);
                picture.From.Column = columnIndex;
                picture.From.Row = rowIndex;
                picture.From.ColumnOff = Pixel2MTU(2); //Two pixel space for better alignment
                picture.From.RowOff = Pixel2MTU(2);//Two pixel space for better alignment
                picture.SetSize(100, 100);
            }
        }

        /// <summary>
        /// Adds the comment in excel sheet.
        /// </summary>
        /// <param name="ws">Worksheet</param>
        /// <param name="colIndex">Column Index</param>
        /// <param name="rowIndex">Row Index</param>
        /// <param name="comments">Comment text</param>
        /// <param name="author">Author Name</param>
        private static void AddComment(ExcelWorksheet ws, int colIndex, int rowIndex, string comment, string author)
        {
            //Adding a comment to a Cell
            var commentCell = ws.Cells[rowIndex, colIndex];
            commentCell.AddComment(comment, author);
        }

        /// <summary>
        /// Pixel2s the MTU.
        /// </summary>
        /// <param name="pixels">The pixels.</param>
        /// <returns></returns>
        public static int Pixel2MTU(int pixels)
        {
            int mtus = pixels * 9525;
            return mtus;
        }

        /// <summary>
        /// Creates the data table with some dummy data.
        /// </summary>
        /// <returns>DataTable</returns>
        private static DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            //for (int i = 0; i < 10; i++)
            //{
            //    dt.Columns.Add(i.ToString());
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    DataRow dr = dt.NewRow();
            //    foreach (DataColumn dc in dt.Columns)
            //    {
            //        dr[dc.ToString()] = i;
            //    }

            //    dt.Rows.Add(dr);
            //}
            BO_CAP_CHUNGCHI ccc = new BO_CAP_CHUNGCHI();
            return dt = ccc.getCAP_CHUNGCHI_WithName(); 
        }

        #endregion
               
        #region ExPortToExcel use Templalte
        //private void ExPortToExcel(DataTable vData, params string[] bindingPath)
        //{
        //    Microsoft.Office.Interop.Excel.Application oApp = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbook oBook =  oApp.Workbooks.Add(Directory.GetCurrentDirectory() + "\\Templates\\iBaseInfrastructureAttach.xlt");
        //   // Microsoft.Office.Interop.Excel.Worksheet oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets(1);
        //    Microsoft.Office.Interop.Excel.Worksheet oSheet =  oBook.Worksheets[1];// oBook.Worksheets(1);
        //    oApp.Visible = true;
        //    int mIDD;
        //   //long c = Strings.Asc("A");
        //    long c = long.Parse("A");
        //    int vColumnCount = int.Parse(bindingPath.ToString());
        //    string[] vField = new string[vColumnCount + 1];
        //    for ( int i = 0; i <= vColumnCount - 1; i++)
        //    {
        //        vField[i] = bindingPath[i].Substring(0, bindingPath[i].Length);
        //    }
        //    DataTable vTable = new DataTable();
        //    DataView vDataView = new DataView();
        //    int vRowBegin = 17;
        //    int vStt = 1;
        //   // double vTotal = 0;
        //   // double vTemp = 0;
        //    vDataView = vData.DefaultView;
        //    vTable = vDataView.Table;
        //    if (vTable.Rows.Count > 0)
        //    {
               

        //        for (int i = 0; i <= vTable.Rows.Count - 1; i++)
        //        {
        //            c = long.Parse("A");
        //           // vTemp = double.Parse( vTable.Rows[i]["CIS_MoneyTotal"].ToString()) ; // check lại filed chứa data

        //            for (int j = 0; j <= vColumnCount - 1; j++)
        //            {
        //                try
        //                {
        //                    if (j == 0)
        //                    {
        //                        oSheet.Range[string.Concat(c) + vRowBegin].Value = vStt;
        //                    }
        //                    else
        //                    {
        //                        oSheet.Range[string.Concat(c) + vRowBegin].Value = vTable.Rows[i][vField[j]].ToString();
        //                    }


        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //                c = c + 1;
        //            }
        //            //vTotal = vTotal + vTemp;
        //            vRowBegin = vRowBegin + 1;
        //            vStt = vStt + 1;
        //            //if (i == vTable.Rows.Count - 1)
        //            //{
        //            //    vRowBegin = vRowBegin + 2;
        //            //    c = long.Parse("F");
        //            //    oSheet.Range[string.Concat(c) + vRowBegin].Value = "Tổng cộng";
        //            //    oSheet.Range[string.Concat(c) + vRowBegin].Font.Bold = true;
        //            //    oSheet.Range[string.Concat(c) + vRowBegin].Font.Size = 11;
        //            //    c =long.Parse("G");
        //            //    oSheet.Range[string.Concat(c) + vRowBegin].Value = vTotal.ToString();
        //            //    oSheet.Range[string.Concat(c) + vRowBegin].Font.Bold = true;
        //            //    oSheet.Range[string.Concat(c) + vRowBegin].Font.Size = 11;


        //            //}
        //        }
        //    }
        //    oApp.ActiveWorkbook.PrintPreview();

        //}
#endregion


        




    }
}