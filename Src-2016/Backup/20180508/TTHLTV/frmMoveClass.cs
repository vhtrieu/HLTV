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

using TTHLTV.BAL;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TTHLTV.DTO;
namespace TTHLTV
{
    public partial class frmMoveClass : DevExpress.XtraEditors.XtraForm
    {
        //private DevExpress.XtraGrid.GridControl gridControl1;
       // private DevExpress.XtraGrid.Views.Grid.GridView gridView1; 
        private GridCheckMarksSelection sselection;
        BO_DANG_KI_HOC boDkh;
        DANG_KI_HOC dtoDkHoc;
        BO_DIEM boDiem;
        DIEM dtoDiem;
        public frmMoveClass()
        {
            InitializeComponent();
        }

        #region Extenal functions

        private DataSet sLookupName()
        {
            //-- Instantiate the data set and table
            DataSet sDataset = new DataSet();
            DataTable sTable = sDataset.Tables.Add("sSearchTable");

            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "Tên giảng viên");
            sTable.Rows.Add(2, "Mã giảng viên");
            sTable.Rows.Add(3, "Khóa học");
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
        #region Load lookup chung chi
        private DataTable getKhoaHoc()
        {
            BAL.BO_CHUNG_CHI bal = new BO_CHUNG_CHI();
            return bal.getChungChi_All();
        }
        private void loadKhoaHoc()
        {
            lookCcID.Properties.DataSource = getKhoaHoc();
            lookCcID.Properties.ValueMember = "CHC_ID";
            lookCcID.Properties.DisplayMember = "CHC_Name";
            //lookChungChi.ItemIndex = 0;
        }

        private void loadKhoaHocNew()
        {
            lookChungChiNew.Properties.DataSource = getKhoaHoc();
            lookChungChiNew.Properties.ValueMember = "CHC_ID";
            lookChungChiNew.Properties.DisplayMember = "CHC_Name";
            //lookChungChi.ItemIndex = 0;
        }
        #endregion
        #region Load lookup lop hoc
        private DataTable getLopHoc(int lookCcID_selected_index)
        {
            BAL.BO_LOP bal = new BO_LOP();
            //return bal.getLop_Alls();
            return bal.getLOP_ByCcID(lookCcID_selected_index);
        }
        private void loadLopHoc(int lookCcID_selected_index)
        {
            lookUpLop.Properties.DataSource = getLopHoc(lookCcID_selected_index);
            lookUpLop.Properties.ValueMember = "LOP_ID";
            lookUpLop.Properties.DisplayMember = "LOP_Name";
            //lookLopHoc.ItemIndex = 0;
        }

        private void loadLopHocNew(int lookCcID_selected_index)
        {
            lookLopNew.Properties.DataSource = getLopHoc(lookCcID_selected_index);
            lookLopNew.Properties.ValueMember = "LOP_ID";
            lookLopNew.Properties.DisplayMember = "LOP_Name";
            //lookLopHoc.ItemIndex = 0;
        }

        #endregion
        private void loadDuration()
        {
            int LOP_ID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            BAL.BO_LOP dao_lop = new BO_LOP();
            DataRow row = dao_lop.getLOP_ByID(LOP_ID).Rows[0];// search by ID, so there is only one row
            txtDateAllocate.Text = Convert.ToDateTime(row["LOP_Ngay_KG"].ToString()).ToShortDateString();
            txtDateExpire.Text = Convert.ToDateTime(row["LOP_Ngay_KT"].ToString()).ToShortDateString();
            txtDateAllocate.BackColor = Color.White;
            txtDateExpire.BackColor = Color.White;
        }
        private void loadDurationNew()
        {
            int LOP_ID = int.Parse(lookLopNew.GetColumnValue("LOP_ID").ToString());
            BAL.BO_LOP dao_lop = new BO_LOP();
            DataRow row = dao_lop.getLOP_ByID(LOP_ID).Rows[0];// search by ID, so there is only one row
            txtNgayKg.Text = Convert.ToDateTime(row["LOP_Ngay_KG"].ToString()).ToShortDateString();
            txtNgayKt.Text = Convert.ToDateTime(row["LOP_Ngay_KT"].ToString()).ToShortDateString();
            txtNgayKg.BackColor = Color.White;
            txtNgayKt.BackColor = Color.White;
        }
        private void loadDataToGrid()
        {
            grvRegisterContent.OptionsBehavior.ReadOnly = false;

            if (grvRegisterContent.RowCount > 0)
            {
                sselection.CheckMarkColumn.Dispose();
            }
            boDkh = new BO_DANG_KI_HOC();
            dtoDkHoc = new DANG_KI_HOC();
            //int ChungChi_ID = int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString());
            dtoDkHoc.DKH_LOPID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            gridRegister.DataSource = boDkh.getCAP_CHUNG_CHI_FILTER_BY_KHOAHOC_LOPHOC(dtoDkHoc);
            
           // new DevExpress.XtraGrid.Design.XViewsPrinting(gridControl1);
            //grvRegisterContent.Columns["iSCheck"].GroupIndex = 0;
            //grvRegisterContent.ExpandAllGroups();
            
            sselection = new GridCheckMarksSelection(grvRegisterContent);
            sselection.CheckMarkColumn.VisibleIndex = 0;
            sselection.CheckMarkColumn.Width = 8;
        }
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return sselection;
            }
        }
        private void saveStudentIntoNewClass()
        {
            dtoDkHoc = new DANG_KI_HOC();
            dtoDiem = new DIEM();
            boDiem = new BO_DIEM();
            boDkh = new BO_DANG_KI_HOC();
            //int sCcId = -1;
            //int sIdMon = -1;
            //int sClassId = -1;
            //int sStudenstId = -1;
            dtoDkHoc.DKH_BienLai = string.Empty;
            dtoDiem.DIE_LOPID = dtoDkHoc.DKH_LOPID = int.Parse(lookLopNew.GetColumnValue("LOP_ID").ToString());
            dtoDkHoc.DKH_Diem = null;
            dtoDkHoc.DKH_LanThi = null;
            dtoDiem.DIE_CHCID = int.Parse(lookChungChiNew.GetColumnValue("CHC_ID").ToString());
            for (int i = 0; i < grvNewClass.RowCount; i++)
            {
               dtoDkHoc.DKH_Code = sGeneralCodeDangKiHocVien().ToString();
                // ID hoc vien o day moi chi lay la ID cuoi, nen khong dam bao insert dung hoc vien vao bang diem
                dtoDiem.DIE_HOVID = dtoDkHoc.DKH_HOVID = int.Parse(grvNewClass.GetRowCellValue(i,"HOV_ID").ToString());
                boDkh.insert(dtoDkHoc);

                dtoDiem.DIE_Diem = null;
                dtoDiem.DIE_LanThi = 1;
                dtoDiem.DIE_NgayNhapDiem = null;
                for (int ii = 0; ii < listSubject.ItemCount; ii++)
                {
                    if (listSubject.GetItemChecked(ii))
                    {
                        // Luu vao table Diem
                        dtoDiem.DIE_MONID = int.Parse(listSubject.GetItemValue(ii).ToString());
                        boDiem.insert(dtoDiem);
                    }
                }
            }
            
        }
        private string sGeneralCodeDangKiHocVien()
        {
            string sDkhCode = string.Empty;
            DataTable tb = new DataTable();
            tb = boDkh.getDanKiHoc_LastCode();
            string dkhCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                dkhCode = "00000";

            }
            else
            {
                dkhCode = tb.Rows[0]["DKH_Code"].ToString();
                dkhCode = dkhCode.Substring(3, 5);
            }

            sDkhCode = ("DKH" + Utilities.quydinh.LaySTT(int.Parse(dkhCode.ToString()) + 1)).ToString();
            return sDkhCode;
        }
        private void sLoadSubject()
        {
            listSubject.DataSource = boDkh.getSubjectName(int.Parse(lookChungChiNew.GetColumnValue("CHC_ID").ToString()));
            listSubject.ValueMember = "MON_ID";
            listSubject.DisplayMember = "MON_Name";
            listSubject.CheckAll();

        }
        #endregion

        #region Events
        private void frmMoveClass_Load(object sender, EventArgs e)
        {
            loadKhoaHoc();
            loadKhoaHocNew();
            Utilities.setFontSize.SetGridFont(gridRegister.MainView, new Font("Tahoma", 11));
            Utilities.setFontSize.SetGridFont(gridNewClass.MainView, new Font("Tahoma", 11));

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lookCcID_EditValueChanged(object sender, EventArgs e)
        {

            if (lookCcID.ItemIndex > -1)
            {
                loadLopHoc(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()));

            }
        }
        private void lookUpLop_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpLop.ItemIndex > -1)
            {
                // load dateAllocate and dateExpire
                loadDuration();
                // load data to grid
                loadDataToGrid();
                //txtFirstName.Focus();
                //sCounter();
            }
        }
        private void lookChungChiNew_EditValueChanged(object sender, EventArgs e)
        {
            if (lookChungChiNew.ItemIndex > -1)
            {
                loadLopHocNew(int.Parse(lookChungChiNew.GetColumnValue("CHC_ID").ToString()));

                sLoadSubject();
            }

        }
        private void lookMonLopNew_EditValueChanged(object sender, EventArgs e)
        {
            if (lookLopNew.ItemIndex > -1)
            {
                // load dateAllocate and dateExpire
                loadDurationNew();
                // load data to grid
                //loadDataToGrid();
                //txtFirstName.Focus();
                //sCounter();
            }

        }
        private void btnMoveStudents_Click(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            DataRow row;
           tb.Columns.Add("DKH_ID", typeof (System.Int32));
           tb.Columns.Add("HOV_ID", typeof(System.Int32));
           tb.Columns.Add("HOV_Code", typeof(System.String));
           tb.Columns.Add("HOV_FirstName", typeof(System.String));
           tb.Columns.Add("HOV_LastName", typeof(System.String));
           tb.Columns.Add("HOV_BirthDay", typeof(System.String));
           tb.Columns.Add("TIN_Name", typeof(System.String));
           tb.Columns.Add("HOV_ChucDanh", typeof(System.String));
           tb.Columns.Add("DON_Name", typeof(System.String));
           tb.Columns.Add("HOV_Phone", typeof(System.String));
           tb.Columns.Add("DKH_BienLai", typeof(System.String));
           tb.Columns.Add("HOV_GhiChu", typeof(System.String));
           tb.Columns.Add("HOV_Address", typeof(System.String));
           tb.Columns.Add("DKH_Code", typeof(System.String));
           tb.Columns.Add("DKH_Diem", typeof(System.Int32));
           tb.Columns.Add("DKH_HOVID", typeof(System.Int32));
           tb.Columns.Add("DKH_LanThi", typeof(System.Int32));

            if (sselection.SelectedCount > 0)
            {
                for (int i = 0; i < grvRegisterContent.RowCount; i++)
                {
                    if (sselection.IsRowSelected(i))
                    {
                        row = tb.NewRow();
                        DataRow dr = grvRegisterContent.GetDataRow(i);
                        tb.ImportRow(dr);
                    }
                    gridNewClass.DataSource = tb;

                }
            }
          
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (lookChungChiNew.ItemIndex < 0 || lookLopNew.ItemIndex < 0)
            {
                MessageBox.Show(" Chưa chọn lớp học mới", "THỐN BÁO");
            }
            else
            {
                if (grvNewClass.RowCount > 0)
                {
                    saveStudentIntoNewClass();
                    MessageBox.Show("Lưu thành công", "THÔNG BÁO");
                }
                else
                    MessageBox.Show("Chưa có học viên", "THÔNG BÁO");
 
            }
            
        }
        #endregion

      
    }

    public class GridCheckMarksSelection
    {
        protected GridView view;
        protected ArrayList selection;
        private GridColumn column;
        private RepositoryItemCheckEdit edit;
        
        public GridCheckMarksSelection()
            : base()
        {
            selection = new ArrayList();
        }

        public GridCheckMarksSelection(GridView view)
            : this()
        {
            View = view;
        }

        protected virtual void Attach(GridView view)
        {
            
            if (view == null) return;
            selection.Clear();
            this.view = view;
            edit = view.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            edit.EditValueChanged += new EventHandler(edit_EditValueChanged);
            //view.Columns.Clear();
            column = view.Columns.Add();
            column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            column.VisibleIndex = int.MaxValue;
            column.FieldName = "CheckMarkSelection";
            column.Caption = "Mark";
            column.OptionsColumn.ShowCaption = false;
            column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            column.ColumnEdit = edit;

            view.CustomDrawColumnHeader += new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
            view.CustomDrawGroupRow += new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
            view.CustomUnboundColumnData += new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
            view.RowStyle += new RowStyleEventHandler(view_RowStyle);
            view.MouseDown += new MouseEventHandler(view_MouseDown); // clear selection
        }

        protected virtual void Detach()
        {
            if (view == null) return;
            if (column != null)
                column.Dispose();
            if (edit != null)
            {
                view.GridControl.RepositoryItems.Remove(edit);
                edit.Dispose();
            }

            view.CustomDrawColumnHeader -= new ColumnHeaderCustomDrawEventHandler(View_CustomDrawColumnHeader);
            view.CustomDrawGroupRow -= new RowObjectCustomDrawEventHandler(View_CustomDrawGroupRow);
            view.CustomUnboundColumnData -= new CustomColumnDataEventHandler(view_CustomUnboundColumnData);
            view.RowStyle -= new RowStyleEventHandler(view_RowStyle);
            view.MouseDown -= new MouseEventHandler(view_MouseDown);

            view = null;
        }

        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo(g);
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
            painter.Draw(args);
            args.Cache.Dispose();
        }

        private void view_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                GridHitInfo info;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                info = view.CalcHitInfo(pt);
                if (info.InRow && info.Column != column && view.IsDataRow(info.RowHandle))
                {
                    ClearSelection();
                    SelectRow(info.RowHandle, true);
                }

                if (info.InColumn && info.Column == column)
                {
                    if (SelectedCount == view.DataRowCount)
                        ClearSelection();
                    else
                        SelectAll();
                }

                if (info.InRow && view.IsGroupRow(info.RowHandle) && info.HitTest != GridHitTest.RowGroupButton)
                {
                    bool selected = IsGroupRowSelected(info.RowHandle);
                    SelectGroup(info.RowHandle, !selected);
                }
            }
        }

        private void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == column)
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == view.DataRowCount);
                e.Handled = true;
            }
        }

        private void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo info;
            info = e.Info as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo;

            info.GroupText = "         " + info.GroupText.TrimStart();
            e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
            e.Painter.DrawObject(e.Info);

            Rectangle r = info.ButtonBounds;
            r.Offset(r.Width * 2, 0);
            DrawCheckBox(e.Graphics, r, IsGroupRowSelected(e.RowHandle));
            e.Handled = true;
        }

        private void view_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (IsRowSelected(e.RowHandle))
            {
                e.Appearance.BackColor = SystemColors.Highlight;
                e.Appearance.ForeColor = SystemColors.HighlightText;
            }
        }

        public GridView View
        {
            get
            {
                return view;
            }
            set
            {
                if (view != value)
                {
                    Detach();
                    Attach(value);
                }
            }
        }

        public GridColumn CheckMarkColumn
        {
            get
            {
                return column;
            }
        }

        public int SelectedCount
        {
            get
            {
                return selection.Count;
            }
        }

        public object GetSelectedRow(int index)
        {
            return selection[index];
        }

        public int GetSelectedIndex(object row)
        {
            return selection.IndexOf(row);
        }

        public void ClearSelection()
        {
            selection.Clear();
            Invalidate();
        }

        private void Invalidate()
        {
            view.CloseEditor();
            view.BeginUpdate();
            view.EndUpdate();
        }

        public void SelectAll()
        {
            selection.Clear();
            ICollection dataSource = view.DataSource as ICollection;
            if (dataSource != null && dataSource.Count == view.DataRowCount)
                selection.AddRange(dataSource);  // fast
            else
                for (int i = 0; i < view.DataRowCount; i++)  // slow
                    selection.Add(view.GetRow(i));
            Invalidate();
        }

        public void SelectGroup(int rowHandle, bool select)
        {
            if (IsGroupRowSelected(rowHandle) && select) return;
            for (int i = 0; i < view.GetChildRowCount(rowHandle); i++)
            {
                int childRowHandle = view.GetChildRowHandle(rowHandle, i);
                if (view.IsGroupRow(childRowHandle))
                    SelectGroup(childRowHandle, select);
                else
                    SelectRow(childRowHandle, select, false);
            }
            Invalidate();
        }

        public void SelectRow(int rowHandle, bool select)
        {
            SelectRow(rowHandle, select, true);
        }

        private void SelectRow(int rowHandle, bool select, bool invalidate)
        {
            if (IsRowSelected(rowHandle) == select) return;
            object row = view.GetRow(rowHandle);
            if (select)
                selection.Add(row);
            else
                selection.Remove(row);
            if (invalidate)
            {
                Invalidate();
            }
        }

        public bool IsGroupRowSelected(int rowHandle)
        {
            for (int i = 0; i < view.GetChildRowCount(rowHandle); i++)
            {
                int row = view.GetChildRowHandle(rowHandle, i);
                if (view.IsGroupRow(row))
                {
                    if (!IsGroupRowSelected(row)) return false;
                }
                else
                    if (!IsRowSelected(row)) return false;
            }
            return true;
        }

        public bool IsRowSelected(int rowHandle)
        {
            if (view.IsGroupRow(rowHandle))
                return IsGroupRowSelected(rowHandle);

            object row = view.GetRow(rowHandle);
            return GetSelectedIndex(row) != -1;
        }

        private void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == CheckMarkColumn)
            {
                if (e.IsGetData)
                    e.Value = IsRowSelected(View.GetRowHandle(e.ListSourceRowIndex));
                else
                    SelectRow(View.GetRowHandle(e.ListSourceRowIndex), (bool)e.Value);
            }
        }

        private void edit_EditValueChanged(object sender, EventArgs e)
        {
            view.PostEditor();
        }
    }
}