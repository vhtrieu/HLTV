using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;
using TTHLTV.BAL;
using TTHLTV.Utilities;
using TTHLTV.DTO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using System.Collections;

namespace TTHLTV
{
     
    public partial class frmEntrySocres : DevExpress.XtraEditors.XtraForm
    {
        BO_DANG_KI_HOC dao_dangki_hoc = new BO_DANG_KI_HOC();
        BO_HOCVIEN boHv = new BO_HOCVIEN();
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        BO_CAP_CHUNGCHI boCapcc;
        CAP_CHUNGCHI dtoCapCc;
        BO_DIEM boDiem;
        DIEM dtoDiem;
        private const int id = -1;
        //int mNumber = -1;
        //int mDiemID = -1;
        string mCaptions = string.Empty;
        private ArrayList mAraayDiem = new ArrayList();
        int sMonID =0;
        int sLopID = 0;
        int sLanThi = 0;
        private DataTable mtbl;
        public frmEntrySocres()
        {
            InitializeComponent();
        }

        #region Events
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lookCcID_EditValueChanged(object sender, EventArgs e)
        {
            if (lookCcID.ItemIndex > id)
            {
                loadLopHoc(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()));
                sLoadSubjectList();
                sLoadMonHoc();
            }
        }
        private void lookUpLop_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpLop.ItemIndex > id)
            {
                // load dateAllocate and dateExpire
                loadDuration();
                // load data to grid
                //loadDataToGrid();
                //btnSave.Enabled = true;
                sLoadMonHoc();
                lookMonHoc.Enabled = true;

            }
        }
        private void frmEntrySocres_Load(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new MyLocalizer();
            sCheckEnable(1);
            dateEntryScores.DateTime = DateTime.Now;   // Convert.ToDateTime(DateTime.().ToString()).ToShortDateString();
            sSearchTool();
            loadKhoaHoc();
            //sLoadLanThi();
            Utilities.setFontSize.SetGridFont(gridEntryCoures.MainView, new Font("Tahoma", 11));
            dateEntryScores.Enabled = true;
            btnSave.Enabled = false;
            lookMonHoc.Enabled = false;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;
            lookLanThi.Enabled = true;
            txtLanThi.Visible = false;
        }
        private void griVEntryCoures_RowClick(object sender, RowClickEventArgs e)
        {
            DataRow selectRow = griVEntryCoures.GetDataRow(griVEntryCoures.FocusedRowHandle);
            lookLanThi.Text = selectRow["DIE_LanThi"].ToString();
            lookLanThi.ClosePopup();
            if (selectRow["DIE_NgayNhapDiem"].ToString() == "")
            {
                return;
            }
            else
            {
                dateEntryScores.EditValue = Convert.ToDateTime(selectRow["DIE_NgayNhapDiem"].ToString()).ToShortDateString();
            }
            
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            SimpleButton btnSender = (SimpleButton)sender;
            mCaptions = btnSender.Text;
            lookCcID.EditValue = DBNull.Value;
            lookUpLop.EditValue = DBNull.Value;
            //lookMonHoc.EditValue = DBNull.Value;
            //lookLanThi.EditValue = DBNull.Value;
            //lookMonHoc.ItemIndex = -1;
            //lookLanThi.ItemIndex = -1;
            listSubjectName.DataSource = null;
            if (griVEntryCoures.DataRowCount > 0)
            {
                ((DataTable)gridEntryCoures.DataSource).Rows.Clear();
            }

            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            lookLanThi.Enabled = true;
            txtDateAllocate.Text = string.Empty;
            txtDateExpire.Text = string.Empty;
            griVEntryCoures.OptionsBehavior.ReadOnly = false;
        }
        private void txtSearchText_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (int.Parse(lookCcID.ItemIndex.ToString()) < 0 && int.Parse(lookUpLop.ItemIndex.ToString()) < 0)
            {
                MessageBox.Show("Chọn khóa học, và lớp học muốn tìm kiếm học viên", "THÔNG BÁO");
                return;
            }
            else
            {
                if (txtSearchText.Text == string.Empty)
                {
                    // ((DataTable)gridCertificate.DataSource).Rows.Clear();
                    loadDataToGrid();

                }
                else
                    if (txtSearchText.Text != string.Empty)
                    {
                        gridEntryCoures.DataSource = dao_dangki_hoc.search_StudentLastName_In_DKH(int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()), txtSearchText.Text);

                    }

            }
        }
        private void lookMonHoc_EditValueChanged(object sender, EventArgs e)
        {
            DataTable vtbl = new DataTable();
            //lookLanThi.EditValue = 1;
            sLoadLanThi();
            //int sLanthi = sLoadLanThi();
            //sLanthi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
            //int sLopID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            //int sMonID = int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString());
            //vtbl = boDiem.select_Diem_by_LanThi(sLopID, sMonID, sLanthi);
            //if (sLanthi > 1)
            //{
            //    DataTable vtbl1 = new DataTable();
            //    vtbl1 = boDiem.select_Diem_by_LanThi(sLopID, sMonID, 1);
            //    if (vtbl1.Rows.Count <= 0 || vtbl1.Columns["DIE_Diem"].ToString() == null)
            //    {
            //        MessageBox.Show("Lớp này chưa nhập điểm thi lần 1", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        loadDataToGrid();
            //        return;
            //    }
            //}
            loadDataToGrid();
            btnSave.Enabled = true;
            label1.Text = "Có "+ griVEntryCoures.RowCount.ToString()+" học viên:";
            
        }
        private void lookLanThi_EditValueChanged(object sender, EventArgs e)
        {
            DataTable tb1 = new DataTable();
            DataTable vtbl = new DataTable();
           // tb1 = getData();
            tb1 = loadDataToGrid();
            //int sLanthi =-1;
            int sMonID = int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString());
            if (tb1.Rows.Count<=0)//tb1.Rows[0]["DIE_LanThi"].ToString() == "")
            {
                //sLanthi = 0;
                loadDataToGrid();
                return;

            }
            else
            {
                loadDataToGrid();
                //sLanthi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
                //int sLopID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
                //vtbl = boDiem.select_Diem_by_LanThi(sLopID, sMonID, sLanthi);
                ////if (sLanthi>1)
                ////{
                ////    DataTable vtbl1 = new DataTable();
                ////    vtbl1 = boDiem.select_Diem_by_LanThi(sLopID, sMonID, 1);
                ////    if ( vtbl1.Rows.Count<=0 || vtbl1.Columns["DIE_Diem"].ToString()==null)
                ////    {
                ////        MessageBox.Show("Lớp này chưa nhập điểm thi lần 1 -xxxx","THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                ////        loadDataToGrid();
                ////        return;
                ////    }
                ////}
                //gridEntryCoures.DataSource = vtbl;
            }
            //txtLanThi.Text = lookLanThi.Text;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            dtoCapCc = new CAP_CHUNGCHI();
            boDiem = new BO_DIEM();
            dtoDiem = new DIEM();
            DataTable tb = new DataTable();
            tb = (DataTable)gridEntryCoures.DataSource;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                dtoDiem.DIE_ID = int.Parse(tb.Rows[i]["DIE_ID"].ToString());
                // De phong khi chua nhap diem ma bam luu.
                if (tb.Rows[i]["DIE_Diem"].ToString() == "")
                {
                    dtoDiem.DIE_Diem = 0;
                }
                else
                {
                    dtoDiem.DIE_Diem = int.Parse(tb.Rows[i]["DIE_Diem"].ToString());
                }
                dtoDiem.DIE_LanThi = int.Parse(lookLanThi.Text.ToString());
                dtoDiem.DIE_NgayNhapDiem = dateEntryScores.DateTime;
                if (dtoDiem.DIE_LanThi == 1)
                {
                    if (dtoDiem.DIE_Diem > 4)
                    {
                        // Neu diem > 4 -> Hoc vien da vuot qua ki thi lan 1
                        boDiem.update_DiemThi_Into_DIEM(dtoDiem);
                    }
                    else
                    {
                        // Neu diem < 5 -> Hoc vien phai thi lai lan 2 -> Update lan thi moi cho hoc vien
                        dtoDiem.DIE_LanThi++;
                        boDiem.update_DiemThi_Into_DIEM(dtoDiem);
                    }
                }
                else
                {
                    //Update diem lan thi thu n
                    if (dtoDiem.DIE_Diem > 4)
                    {
                        // Neu diem > 4 -> Hoc vien da vuot qua ki thi lan 1
                        boDiem.update_DiemThi_Into_DIEM(dtoDiem);
                    }
                    else
                    {
                        // Neu diem < 5 -> Hoc vien phai thi lai lan 2 -> Update lan thi moi cho hoc vien
                        dtoDiem.DIE_LanThi++;
                        boDiem.update_DiemThi_Into_DIEM(dtoDiem);
                    }
                }
                if (vCheckLopDaCapCC())
                {
                    if (dtoDiem.DIE_Diem > 4)
                    {
                        // Neu diem > 4 -> Hoc vien da vuot qua ki thi lan 1
                        boDiem.update_DiemThi_Into_DIEM(dtoDiem);
                    }
                    else
                    {
                        // Neu diem < 5 -> Hoc vien phai thi lai lan 2 -> Update lan thi moi cho hoc vien
                        dtoDiem.DIE_LanThi++;
                        boDiem.update_DiemThi_Into_DIEM(dtoDiem);
                        //Trong truong hop da cap chung chi roi ma sua lai diem nho hon 5 cập nhật số chứng chỉ về null
                        // Sau khi nhap lai diem >5 thi cap lai so chung chi
                        dtoCapCc.CCC_ID = int.Parse(tb.Rows[i]["CCC_ID"].ToString());
                        dtoCapCc.CCC_HOVID = int.Parse(tb.Rows[i]["HOV_ID"].ToString());
                        dtoCapCc.CCC_LOPID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
                        dtoCapCc.CCC_SoCC = string.Empty;
                        dtoCapCc.CCC_NgayCap = null;
                        dtoCapCc.CCC_NgayHetHan = null;
                        boCapcc.update_SoCc(dtoCapCc);
                    }
                }
            }
            MessageBox.Show("Nhập điểm thành công", "THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Information);
            sLoadLanThi();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            SimpleButton btnSender = (SimpleButton)sender;
            mCaptions = btnSender.Text;

            //txtLanThi.Visible = true;
            //lookLanThi.Visible = false;
            btnCancel.Enabled = true;
            griVEntryCoures.OptionsBehavior.ReadOnly = false;
        }
        private void griVEntryCoures_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            DataRow r = griVEntryCoures.GetFocusedDataRow();
            ColumnView view = sender as ColumnView;
            GridColumn column1 = view.Columns["DIE_Diem"];
            if (r["DIE_Diem"].ToString().Equals(String.Empty))
            {
                //e.ErrorText = “Nhập dữ liệu sai.”;
                e.Valid = false;
                view.SetColumnError(view.Columns["DIE_Diem"], "Không được để trống");
            }
            if (int.Parse(r["DIE_Diem"].ToString()) > 10)
            {
                e.ErrorText = "Nhập dữ liệu sai.";
                e.Valid = false;
                view.SetColumnError(view.Columns["DIE_Diem"], "Điểm không thể quá 10");
                return;
            }
            if (int.Parse(r["DIE_Diem"].ToString()) < 0)
            {
                e.ErrorText = "Nhập dữ liệu sai.";
                e.Valid = false;
                view.SetColumnError(view.Columns["DIE_Diem"], "Điểm không thể nhỏ hơn 0");
                return;
            }
        }
        #endregion

        #region Extenal functions
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
        #endregion
        #region Search tool
        private void sSearchTool()
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
            sTable.Rows.Add(2, "Họ và tên đệm");
            sTable.Rows.Add(3, "Mã học viên");
            sTable.Rows.Add(4, "Ngày sinh");

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
        #region Lookup LanThi
        private int sLoadLanThi()
        {
            boDiem = new BO_DIEM();
            lookLanThi.Properties.DataSource = boDiem.lanThi( int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString()), int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString()));
            lookLanThi.Properties.ValueMember = "DIE_LanThi";
            lookLanThi.Properties.DisplayMember = "DIE_LanThi";
            lookLanThi.ItemIndex = 0;
            //int sLanthi = sLoadLanThi();
            //DataTable vtbl = new DataTable();
            //sLanthi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
            //int sLopID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            //int sMonID = int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString());
            //vtbl = boDiem.select_Diem_by_LanThi(sLopID, sMonID, sLanthi);
            //if (sLanthi > 1)
            //{
            //    DataTable vtbl1 = new DataTable();
            //    vtbl1 = boDiem.select_Diem_by_LanThi(sLopID, sMonID, 1);
            //    if (vtbl1.Rows.Count <= 0 || vtbl1.Columns["DIE_Diem"].ToString() == null)
            //    {
            //        MessageBox.Show("Lớp này chưa nhập điểm thi lần 1", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        loadDataToGrid();
            //        //return;
            //    }
            //}
            return lookLanThi.ItemIndex;
        }
        #endregion
        private void sCheckEnable(int sCheck)
        {
            if (sCheck == 1)
            {
                txtDateAllocate.Enabled = false;
                txtDateExpire.Enabled = false;
                //txtFirstName.Enabled = false;
                //txtLastName.Enabled = false;
                //txtPhone.Enabled = false;
                //txtSoBienLai.Enabled = false;
                //dateBirthDay.Enabled = false;
                //lookUpBirthPlace.Enabled = false;
                //lookUpChucDanh.Enabled = false;
                //lookUpDonvi.Enabled = false;
                //txtAddress.Enabled = false;
                //memoRemarks.Enabled = false;

                txtDateAllocate.BackColor = Color.White;
                txtDateExpire.BackColor = Color.White;
                //txtFirstName.BackColor = Color.White;
                //txtLastName.BackColor = Color.White;
                //txtPhone.BackColor = Color.White;
                //txtSoBienLai.BackColor = Color.White;
                //dateBirthDay.BackColor = Color.White;
                //lookUpBirthPlace.BackColor = Color.White;
                //lookUpChucDanh.BackColor = Color.White;
                //lookUpDonvi.BackColor = Color.White;
                //txtAddress.BackColor = Color.White;
                //memoRemarks.BackColor = Color.White;

            }
            else
                if (sCheck == 2)
                {
                    txtDateAllocate.Enabled = true;
                    txtDateExpire.Enabled = true;
                    //txtFirstName.Enabled = true;
                    //txtLastName.Enabled = true;
                    //txtPhone.Enabled = true;
                    //txtSoBienLai.Enabled = true;
                    //dateBirthDay.Enabled = true;
                    //lookUpBirthPlace.Enabled = true;
                    //lookUpChucDanh.Enabled = true;
                    //lookUpDonvi.Enabled = true;
                    //txtAddress.Enabled = true;
                    //memoRemarks.Enabled = true;

                }

        }
        private void loadDuration()
        {
            int LOP_ID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
            BAL.BO_LOP dao_lop = new BO_LOP();
            DataRow row = dao_lop.getLOP_ByID(LOP_ID).Rows[0];// search by ID, so there is only one row
            DateTime DateAllocate = DateTime.Parse(row["LOP_Ngay_KG"].ToString());
            DateTime DateExpire = DateTime.Parse(row["LOP_Ngay_KT"].ToString());
            txtDateAllocate.Text = DateAllocate.ToString("dd/MM/yyyy");
            txtDateExpire.Text = DateExpire.ToString("dd/MM/yyyy");
            //txtDateAllocate.Text = Convert.ToDateTime(row["LOP_Ngay_KG"].ToString()).ToShortDateString();
            //txtDateExpire.Text = Convert.ToDateTime(row["LOP_Ngay_KT"].ToString()).ToShortDateString();
            
        }
        private DataTable sGeneralMark()
        {
            DataTable tb = new DataTable("TableMark");

            tb.Columns.Add("ID", typeof(int));
            tb.Columns.Add("Mark", typeof(int));

            for (int i = 0; i < 11; i++)
            {
                tb.Rows.Add(i,i);
            }
            return tb;

        }
        private void loadDataToGrids()
        {
            gridEntryCoures.DataSource = mtbl;
            ArrayList aDiem = new ArrayList();
            for (int i = 0; i < mtbl.Rows.Count; i++)
            {
                aDiem.Add(mtbl.Rows[i]["DIE_Diem"]);
                mAraayDiem.Add(aDiem);
            }
        }
        private DataTable loadDataToGrid()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            mtbl = new DataTable();
           if (vCheckLopDaCapCC())
            {
                mtbl = boCapcc.vCheckLopDaCapCcByLopMonID(sLopID, sMonID, sLanThi);
                gridEntryCoures.DataSource = mtbl;
                ArrayList aDiem = new ArrayList();
                for (int i = 0; i < mtbl.Rows.Count; i++)
                {
                    aDiem.Add(mtbl.Rows[i]["DIE_Diem"]);
                    mAraayDiem.Add(aDiem);
                }
            }
            else
            {
                mtbl = boDiem.select_Diem_by_Lop_Mon(sLopID, sMonID,sLanThi);
                gridEntryCoures.DataSource = mtbl;
                ArrayList aDiem = new ArrayList();
                for (int i = 0; i < mtbl.Rows.Count; i++)
                {
                    aDiem.Add(mtbl.Rows[i]["DIE_Diem"]);
                    mAraayDiem.Add(aDiem);
                }
            }

            return mtbl;
        }
        private bool vCheckLopDaCapCC()
        {
             sLopID = int.Parse(lookUpLop.GetColumnValue("LOP_ID").ToString());
             sMonID = int.Parse(lookMonHoc.GetColumnValue("MON_ID").ToString());
             sLanThi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
             DataTable vtbl = boCapcc.vCheckLopDaCapCcByLopMonID(sLopID, sMonID, sLanThi);
             if (vtbl.Rows.Count>0)
             {
                 return true;
             }
             else
             {
                 return false;
             }
        }
        private void sLoadSubjectList()
        {
            listSubjectName.DataSource = dao_dangki_hoc.getSubjectName(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()));
            listSubjectName.ValueMember = "MON_ID";
            listSubjectName.DisplayMember = "MON_Name";
        }
        private void sLoadMonHoc()
        {
            lookMonHoc.Properties.DataSource = null;
            lookMonHoc.Properties.DataSource = dao_dangki_hoc.getSubjectName(int.Parse(lookCcID.GetColumnValue("CHC_ID").ToString()));
            lookMonHoc.Properties.ValueMember = "MON_ID";
            lookMonHoc.Properties.DisplayMember = "MON_Name";
        }
        public class MyLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
        {
            public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
            {
                if (id == DevExpress.XtraGrid.Localization.GridStringId.ColumnViewExceptionMessage)
                    return "Vui lòng nhập lại";
                return base.GetLocalizedString(id);
            }
        }
        #endregion
        private void griVEntryCoures_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                griVEntryCoures.MoveNext();
                int col = griVEntryCoures.Columns[5].VisibleIndex;
                griVEntryCoures.FocusedColumn = griVEntryCoures.VisibleColumns[col];
                griVEntryCoures.ShowEditor();
            }
        }
    }
}