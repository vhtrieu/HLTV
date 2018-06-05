using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using TTHLTV.DTO;
using TTHLTV.BAL;
using System.Globalization;

namespace TTHLTV
{
    public partial class frmAddNewCertificate : DevExpress.XtraEditors.XtraForm
    {
        BO_CAP_CHUNGCHI boCapcc;
        CAP_CHUNGCHI dtoCapCc;
        BO_DANG_KI_HOC boDkh = new BO_DANG_KI_HOC();
        BO_MONHOC boMonHoc = new BO_MONHOC();
        BO_DOI_CHUNGCHI boDoiCc = new BO_DOI_CHUNGCHI();
        private string mSoCc = string.Empty;
        private int mCheckLopDaCap = -1;
        private DataTable tbst;
        private DataTable tableDiem;
        private GridCheckMarksSelection sselection;
        BO_DIEM boDiem = new BO_DIEM();
        //int sAge = 0;
        DataTable tb2 = new DataTable();
        public frmAddNewCertificate()
        {
            InitializeComponent();
        }
        #region Events
        private void frmAddNewCertificate_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridCertificate.MainView, new Font("Tahoma", 11));

            loadKhoaHoc();
            checkDate();
            acticeSearch();
            checkInvisible();
            lookLopHoc.Enabled = false;
            checkEdit1.Enabled = false;

        }
        private void lookChungChi_EditValueChanged(object sender, EventArgs e)
        {
            lookLopHoc.Enabled = true;
            loadLopHoc();
            vGetLastSoCC();

        }
        private void lookLopHoc_EditValueChanged(object sender, EventArgs e)
        {
            if (sLoadLanThi())
            {
                //sLoadLanThi();
                sDisplayGrid();
                vGetLastSoCC();
                checkEdit1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Lớp này chưa nhập điểm", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridContentCertificate.Columns.Clear();
                gridCertificate.DataSource = null;
                return;
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchByLastNameContrain();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string messages = "";
            string caption = "";
            int skDiem = -1;
            if (mCheckLopDaCap > 0)
            {
                messages = " Chắc chắn muốn lưu chứng chỉ cho học viên đã chọn ";
                caption = " THÔNG BÁO ";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(messages, caption, button);
                if (result == DialogResult.Yes)
                {
                    if (updateSoCC_New())
                    {
                        MessageBox.Show("Lưu thành công.", "THÔNG BÁO");
                        sDisplayGrid();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Lưu không thành công.", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            //Save new
            else if (checkGridEmpty() == false)
            {
                int statust = 0;
                int sCheckDiem = 0;
                for (int i = 0; i < gridContentCertificate.RowCount; i++)
                {
                    string sCheckStatust = gridContentCertificate.GetRowCellValue(i, "Số CC").ToString();
                    DataTable cCMhTable = new DataTable();
                    cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
                    for (int ik = 0; ik < cCMhTable.Rows.Count; ik++)
                    {
                        string vDiem = gridContentCertificate.GetRowCellValue(i, cCMhTable.Rows[ik]["MonHoc"].ToString()).ToString();

                        if (vDiem != string.Empty)
                        {
                            skDiem = int.Parse(gridContentCertificate.GetRowCellValue(i, cCMhTable.Rows[ik]["MonHoc"].ToString()).ToString());
                        }
                        if (skDiem < 5)
                        {
                            sCheckDiem++;
                        }
                    }
                }
                if (statust < gridContentCertificate.DataRowCount)
                {
                    messages = " Chắc chắn muốn lưu chứng chỉ cho học viên ";
                    caption = " THÔNG BÁO ";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(messages, caption, button);
                    if (result == DialogResult.Yes)
                    {
                        if (saveData())
                        {
                            messages = " Lưu chứng chỉ thành công ";
                            caption = " THÔNG BÁO";
                            button = MessageBoxButtons.OK;
                            MessageBox.Show(messages, caption, button);
                            sDisplayGrid();
                            this.Refresh();
                        }
                        else
                        {
                            messages = " Lưu chứng chỉ không thành công ";
                            caption = " THÔNG BÁO";
                            button = MessageBoxButtons.OK;
                            MessageBox.Show(messages, caption, button);
                        }
                    }
                }
                else
                {
                    messages = " Lớp này đã cấp chứng chỉ";
                    caption = " THÔNG BÁO";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    button = MessageBoxButtons.OK;
                    MessageBox.Show(messages, caption, button);
                }
            }
            else
            {
                messages = "Chọn lớp có học viên trước khi cấp chứng chỉ";
                caption = " THÔNG BÁO";
                MessageBoxButtons button = MessageBoxButtons.YesNo;
                button = MessageBoxButtons.OK;
                MessageBox.Show(messages, caption, button);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataTable lastSoCc = new DataTable();
            lastSoCc = boCapcc.getLast_SoCc(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            if (lastSoCc.Rows.Count <= 0)
            {
                txtSoCcSave.Text = "00000";
                txtSoCcCuoi.Text = "00000";
                return;
            }
            else
            {
                txtSoCcSave.Text = lastSoCc.Rows[0]["SoCc"].ToString();
                txtSoCcCuoi.Text = lastSoCc.Rows[0]["SoCc"].ToString();
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void radioTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            acticeSearch();
            checkInvisible();

        }
        private void gridContentCertificate_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedColumn.FieldName == "Họ" || view.FocusedColumn.FieldName == "Tên" || view.FocusedColumn.FieldName == "Ngày sinh")
            {
                e.Cancel = true;
            }
            DataTable cCMhTable = new DataTable();
            cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < cCMhTable.Rows.Count; i++)
            {
                if (view.FocusedColumn.FieldName == cCMhTable.Rows[i]["MonHoc"].ToString())
                {
                    e.Cancel = true;
                }
            }
        }
        private void txtSearchText_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            /* Comment at 2013.05.26- Trieu*/
            //if (int.Parse(lookChungChi.ItemIndex.ToString()) < 0 && int.Parse(lookLopHoc.ItemIndex.ToString()) < 0)
            //{
            //    MessageBox.Show("Chọn khóa học, và lớp học muốn tìm kiếm học viên", "THÔNG BÁO");
            //    return;
            //}
            //else
            //{
            //    DataTable temTb = new DataTable();
            //    temTb = boDkh.getDangKiHoc_Name_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            //    if (temTb.Rows.Count > 0)
            //    {
            //        if (txtSearchText.Text == string.Empty)
            //        {
            //            // ((DataTable)gridCertificate.DataSource).Rows.Clear();
            //            showLopDaCapCC();
            //        }
            //        else
            //            if (txtSearchText.Text != string.Empty)
            //            {
            //                gridCertificate.DataSource = searchCCCResultTable();
            //                gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            //                //gridCertificate.DataSource = boCcc.searchHocVien_In_DKH_ByName( txtSearchText.Text);
            //            }
            //    }
            //    else
            //    {
            //        if (txtSearchText.Text == string.Empty)
            //        {
            //            // ((DataTable)gridCertificate.DataSource).Rows.Clear();
            //            showData();
            //        }
            //        else
            //            if (txtSearchText.Text != string.Empty)
            //            {
            //                gridCertificate.DataSource = SearchTableResult();
            //                gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            //                //gridCertificate.DataSource = boCcc.searchHocVien_In_DKH_ByName( txtSearchText.Text);

            //            }

            //    }



            //}
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        private void txtSearchText_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lookChungChi.ItemIndex < -1)
            {
                MessageBox.Show("Chưa chọn loại chứng chỉ", "THÔNG BÁO");
                return;
            }
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            if (sselection.SelectedCount > 0)
            {
                CapLai();
            }
            else
            {
                saveDataToGrid();
            }

        }
        private void radCapTuDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radCapTuDong.SelectedIndex == 0)
            {
                txtSoCcText.Enabled = false;
                txtEditeSoCc.Enabled = false;
            }
            else
                if (radCapTuDong.SelectedIndex == 1)
            {
                txtSoCcText.Enabled = true;
                txtEditeSoCc.Enabled = true;
            }
        }
        private void txtEditeSoCc_Leave(object sender, EventArgs e)
        {
            if (txtEditeSoCc.Text.Length < 5)
            {
                MessageBox.Show("Phải nhập số chứng chỉ có 5 chữ số", "NHẬP SỐ CHỨNG CHỈ KHÔNG ĐÚNG");
                txtEditeSoCc.Focus();

            }
        }
        private void txtEditeSoCc_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            txtEditSave.Text = txtEditeSoCc.Text;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (sselection.SelectedCount == 0)
            {
                MessageBox.Show("Chưa chọn học viên muốn xóa số chứng chỉ", "THÔNG BÁO");
                return;
            }

            string messages = "";
            string caption = "";
            messages = " Chắc chắn muốn xóa số chứng chỉ cho học viên này ";
            caption = " THÔNG BÁO ";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(messages, caption, button);
            if (result == DialogResult.Yes)
            {

                //if (UpdateSoCCNull())
                //{
                //    this.Refresh();

                //}
                //else
                //{
                //    return;
                //}
                updateSoCC_Null();
                sDisplayGrid();
                //btnCancel.Enabled = true;
            }
        }
        private void lookLanThi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                sDisplayGrid();
                vGetLastSoCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCnNgayCap_Click(object sender, EventArgs e)
        {
            if (dateNgayCap.EditValue == null)
            {
                MessageBox.Show("Chưa nhập ngày cấp", "THÔNG BÁO");
                dateNgayCap.Focus();
                return;
            }
            else
            {
                updateSoCC_NgayCap();
                showData();
                sDisplayGrid();

            }
        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            int iCheckd = 0;
            btnCnNgayCap.Enabled = true;
            if (gridContentCertificate.RowCount > 0 && iCheckd > 0)
            {
                sselection.CheckMarkColumn.Dispose();
            }
            else if (checkEdit1.Checked == false)
            {
                sselection.CheckMarkColumn.Dispose();
            }

        }
        private void radNgayCap_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            checkDate();
        }
        private void dateNgayCap_EditValueChanged_1(object sender, EventArgs e)
        {
            checkDate();
        }
        #endregion
        #region Extenal functions
        private void setDataToGridView()
        {
            string CCC_Code = string.Empty;
            string CCC_SoCC = string.Empty;
            DataTable lastSoCcC = new DataTable();
            for (int i = 0; i < gridContentCertificate.RowCount; i++)
            {
                lastSoCcC = boCapcc.getLast_SoCc(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
                if (lastSoCcC.Rows.Count <= 0)
                {
                    CCC_Code = "CCC" + Utilities.quydinh.LaySTT(1);
                    CCC_SoCC = Utilities.quydinh.LaySTT(1) + " GTVT";
                }
                else
                {
                    string stemp = lastSoCcC.Rows[0]["SoCc"].ToString();
                    string[] ss = stemp.Split(' ');
                    mSoCc = ss[0].ToString();
                    CCC_Code = "CCC" + Utilities.quydinh.LaySTT(int.Parse(mSoCc.ToString()) + 1);
                    CCC_SoCC = Utilities.quydinh.LaySTT(int.Parse(mSoCc.ToString()) + 1) + " GTVT";
                }
            }
        }
        private void sDisplayGrid()
        {
            DataTable temTb = new DataTable();
            DataTable tb1 = new DataTable();
            int vLopID = -1;
            int vLanThi = -1;
            vLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            vLanThi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());
            tb1 = getLopDaCapCC();
            // Lớp này đã có cấp chứng chỉ cho học viên
            mCheckLopDaCap = tb1.Rows.Count;
            if (mCheckLopDaCap > 0)
            {
                btnSave.Enabled = true;
                //tb1 = getLopDaCapCC();
                tb2 = GetTable();
                foreach (DataRow item in tb2.Rows)
                {
                    DataRow newRow = tb1.NewRow();
                    newRow.ItemArray = item.ItemArray;
                    tb1.Rows.Add(newRow);
                }
                tbst = new DataTable();
                tbst = tb1.Clone();
                for (int i = 0; i < tb1.Rows.Count; i++)
                {
                    DateTime datetime;
                    string StringDate = string.Empty;
                    int tb1ColCount = tb1.Columns.Count;
                    if (tb1.Rows[i][tb1ColCount - 2].ToString() != "")
                    {
                        datetime = Convert.ToDateTime(tb1.Rows[i][tb1ColCount - 2].ToString());
                        datetime = Convert.ToDateTime(datetime.ToShortDateString());
                        StringDate = datetime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        StringDate = StringDate.ToString().Substring(0, 2) + "/" + StringDate.ToString().Substring(3, 2) + "/" + StringDate.ToString().Substring(6, 4);
                    }
                    DataRow tbstRow = tbst.NewRow();

                    tbstRow[0] = tb1.Rows[i][0].ToString();
                    tbstRow[1] = tb1.Rows[i][1].ToString();
                    tbstRow[2] = tb1.Rows[i][2].ToString();
                    tbstRow[3] = tb1.Rows[i][3].ToString();
                    int subColTotal = tb1ColCount - 7;
                    for (int isd = 4; isd < tb1ColCount - 3; isd++)
                    {
                        tbstRow[isd] = tb1.Rows[i][isd].ToString();
                    }
                    tbstRow[tb1ColCount - 3] = tb1.Rows[i][tb1ColCount - 3].ToString();
                    tbstRow[tb1ColCount - 2] = StringDate.ToString(); // tb1.Rows[i][tb1ColCount - 3].ToString();
                    if (tb1.Rows[i][tb1ColCount - 1].ToString() != "")
                    {
                        tbstRow[tb1ColCount - 1] = tb1.Rows[i][tb1ColCount - 1].ToString();
                    }
                    else
                        tbstRow[tb1ColCount - 1] = -1;

                    tbst.Rows.Add(tbstRow);
                }
                gridContentCertificate.Columns.Clear();
                gridCertificate.DataSource = tbst;

                gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
                gridContentCertificate.Columns["CCC_LOPID"].VisibleIndex = -1;
                gridContentCertificate.Columns["CCC_ID"].VisibleIndex = -1;
                sselection = new GridCheckMarksSelection(gridContentCertificate);
                sselection.CheckMarkColumn.VisibleIndex = 0;
                sselection.CheckMarkColumn.Width = 8;
            }
            else
            {
                //Load lớp chưa cấp chứng chỉ cho học viên nào.
                showData();
            }
            DataTable lastSoCc = new DataTable();
            lastSoCc = boCapcc.getLast_SoCc(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            if (lastSoCc.Rows.Count <= 0)
            {
                txtSoCcSave.Text = " 00000 ";
                txtSoCcCuoi.Text = " 00000 ";
                return;
            }
            else
            {
                string stempss = lastSoCc.Rows[0]["SoCc"].ToString();
                string[] sss = stempss.Split(' ');
                txtSoCcSave.Text = sss[0].ToString();
                string stemps = lastSoCc.Rows[0]["SoCc"].ToString();
                string[] ss = stemps.Split(' ');
                txtSoCcCuoi.Text = ss[0].ToString();//.Substring(0,5);
                mSoCc = txtSoCcCuoi.Text;
            }
        }
        private Boolean sLoadLanThi()
        {
            DataTable tbl = new DataTable();
            tbl = boDiem.LanThi_generalMark(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            if (tbl.Rows.Count > 0)
            {
                lookLanThi.Properties.DataSource = tbl;
                lookLanThi.Properties.ValueMember = "DIE_LanThi";
                lookLanThi.Properties.DisplayMember = "DIE_LanThi";
                lookLanThi.ItemIndex = 0;
            }
            else
            {
                return false;
            }
            return true;
        }
        #region Load lookup chung chi
        private DataTable getKhoaHoc()
        {
            BAL.BO_CHUNG_CHI bal = new BO_CHUNG_CHI();
            return bal.getChungChi_All();
        }
        private void loadKhoaHoc()
        {
            lookChungChi.Properties.DataSource = getKhoaHoc();
            lookChungChi.Properties.ValueMember = "CHC_ID";
            lookChungChi.Properties.DisplayMember = "CHC_Name";
            //lookChungChi.ItemIndex = 0;
        }

        #endregion
        #region Load lookup lop hoc
        private DataTable getLopHoc()
        {
            BAL.BO_LOP bal = new BO_LOP();
            //return bal.getLop_Alls();
            int vCcID = int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString());
            return bal.getLOP_ByCcID(vCcID);
        }
        private void loadLopHoc()
        {
            lookLopHoc.Properties.DataSource = getLopHoc();
            lookLopHoc.Properties.ValueMember = "LOP_ID";
            lookLopHoc.Properties.DisplayMember = "LOP_Name";
            //lookLopHoc.ItemIndex = 0;
        }
        #endregion
        private void checkInvisible()
        {
            if (radioTimKiem.SelectedIndex == 0)
            {
                groupTK_CaNhan.Enabled = false;

            }
            else
            {
                groupTK_CaNhan.Enabled = true;

            }
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        private void checkDate()
        {
            if (radNgayCap.SelectedIndex == 0)
            {
                dateNgayCap.Enabled = false;
                dateNgayHetHan.Enabled = false;
                dateNgayCap.DateTime = DateTime.Now;
                dateNgayHetHan.DateTime = new DateTime(dateNgayCap.DateTime.Year + 5, dateNgayCap.DateTime.Month, dateNgayCap.DateTime.Day, dateNgayCap.DateTime.Hour, dateNgayCap.DateTime.Minute, dateNgayCap.DateTime.Second, dateNgayCap.DateTime.Millisecond);

            }
            else
                if (radNgayCap.SelectedIndex == 1)
            {
                dateNgayCap.Enabled = true;
                dateNgayHetHan.Enabled = false;
                dateNgayHetHan.DateTime = new DateTime(dateNgayCap.DateTime.Year + 5, dateNgayCap.DateTime.Month, dateNgayCap.DateTime.Day, dateNgayCap.DateTime.Hour, dateNgayCap.DateTime.Minute, dateNgayCap.DateTime.Second, dateNgayCap.DateTime.Millisecond);
            }

        }
        private void showData()
        {
            gridContentCertificate.Columns.Clear();
            gridCertificate.DataSource = GetTable();

            gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            gridContentCertificate.Columns["CCC_LOPID"].VisibleIndex = -1;
            gridContentCertificate.Columns["CCC_ID"].VisibleIndex = -1;
            gridContentCertificate.Columns.Add();
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatString = "dd/MM/yyyy";
            sselection = new GridCheckMarksSelection(gridContentCertificate);
            sselection.CheckMarkColumn.VisibleIndex = 0;
            sselection.CheckMarkColumn.Width = 8;

        }
        private DataTable GetTable()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            string DD = string.Empty;
            DataTable cCMhTable = new DataTable();
            tableDiem = new DataTable("TempDiem");
            DataColumn column = new DataColumn();
            tableDiem.Columns.Add("HvID", typeof(int));
            tableDiem.Columns.Add("Họ", typeof(string));
            tableDiem.Columns.Add("Tên", typeof(string));
            tableDiem.Columns.Add("Ngày sinh", typeof(string));
            cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < cCMhTable.Rows.Count; i++)
            {
                tableDiem.Columns.Add(cCMhTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            tableDiem.Columns.Add("CCC_ID", typeof(int));
            tableDiem.Columns.Add("Số CC", typeof(string));
            tableDiem.Columns.Add("Ngày cấp", typeof(string));
            tableDiem.Columns.Add("CCC_LOPID", typeof(int));

            DataTable tbs = new DataTable();
            tbs = boCapcc.GetData_For_CAP_CHUNGCHI_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));

            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = tableDiem.NewRow();
                newRow.ItemArray = dr.ItemArray;
                tableDiem.Rows.Add(newRow);
            }
            return tableDiem;
        }
        private bool saveData()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            dtoCapCc = new CAP_CHUNGCHI();
            DateTime vtempDate;

            int i = 0;
            DataTable cCMhTable = new DataTable();
            DataTable tb1 = new DataTable();
            tb1 = boCapcc.getHocVienCapCC_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));

            dtoCapCc.CCC_LOPID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            dtoCapCc.CCC_NgayCap = dateNgayCap.DateTime;
            //TrieuVH add start 2018-04-19
            dtoCapCc.CCC_NgayHetHan = (DateTime)dateNgayHetHan.EditValue;
            //TrieuVH add start 2018-04-19
            dtoCapCc.CCC_CHCID = int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString());
            dtoCapCc.CCC_Status = 1;
            dtoCapCc.CCC_SoHieuDoi = string.Empty;
            dtoCapCc.CCC_DOIID = -1;

            if (tb1.Rows.Count > 0)
            {
                if (gridContentCertificate.RowCount > tb1.Rows.Count) // Truong hop nay hiem khi xay ra
                {
                    while (i < gridContentCertificate.RowCount)
                    {
                        dtoCapCc.CCC_Code = dtoCapCc.CCC_SoCC = gridContentCertificate.GetRowCellValue(i, "Số CC").ToString();
                        dtoCapCc.CCC_HOVID = int.Parse(gridContentCertificate.GetRowCellValue(i, "HvID").ToString());
                        dtoCapCc.CCC_ID = int.Parse(gridContentCertificate.GetRowCellValue(i, "CCC_ID").ToString());
                        //vtempDate = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString()));
                        //TrieuVH deleted start 2018-04-19
                        //object tmDayOffBirth = gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString();
                        //if (tmDayOffBirth.ToString().Length < 5)
                        //{
                        //    tmDayOffBirth = "01/01/" + tmDayOffBirth;
                        //}
                        //else if (tmDayOffBirth.ToString().Length < 7)
                        //{
                        //    tmDayOffBirth = "01/" + tmDayOffBirth;
                        //}
                        ////vtempDate = DateTime.ParseExact(gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        //vtempDate = DateTime.ParseExact(tmDayOffBirth.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        //dtoCapCc.CCC_NgayHetHan = vCheckExpirationDate(vtempDate);
                        //TrieuVH deleted end 2018-04-19
                        if (dtoCapCc.CCC_SoCC != string.Empty)
                        {
                            for (int ik = 0; ik < tb2.Rows.Count; ik++)
                            {
                                if (int.Parse(tb2.Rows[ik]["HvID"].ToString()) == dtoCapCc.CCC_HOVID)
                                {
                                    boCapcc.insert(dtoCapCc);
                                }
                            }
                            boCapcc.update_CapChungChi(dtoCapCc);
                        }
                        i++;
                    }
                }
                else
                {
                    while (i < gridContentCertificate.RowCount)// Update cung so rows
                    {
                        dtoCapCc.CCC_Code = dtoCapCc.CCC_SoCC = gridContentCertificate.GetRowCellValue(i, "Số CC").ToString();
                        //update new start
                        dtoCapCc.CCC_HOVID = int.Parse(gridContentCertificate.GetRowCellValue(i, "HvID").ToString());
                        //vtempDate = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString()));
                        //TrieuVH deleted start 2018-04-19
                        //object tmDayOffBirth = gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString();
                        //if (tmDayOffBirth.ToString().Length < 5)
                        //{
                        //    tmDayOffBirth = "01/01/" + tmDayOffBirth;
                        //}
                        //else if (tmDayOffBirth.ToString().Length < 7)
                        //{
                        //    tmDayOffBirth = "01/" + tmDayOffBirth;
                        //}
                        ////vtempDate = DateTime.ParseExact(gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        //vtempDate = DateTime.ParseExact(tmDayOffBirth.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);

                        //dtoCapCc.CCC_NgayHetHan = vCheckExpirationDate(vtempDate);
                        //TrieuVH deleted start 2018-04-19
                        if (dtoCapCc.CCC_SoCC != string.Empty)
                        {
                            for (int imk = 0; imk < tb1.Rows.Count; imk++)
                            {
                                if (int.Parse(tb1.Rows[imk]["CCC_HOVID"].ToString()) == dtoCapCc.CCC_HOVID)
                                {
                                    boCapcc.update_CapChungChi(dtoCapCc);
                                }
                            }
                            boCapcc.insert(dtoCapCc);
                        }
                        i++;
                    }
                }
            }
            else
            {
                while (i < gridContentCertificate.RowCount)
                {
                    dtoCapCc.CCC_SoCC = gridContentCertificate.GetRowCellValue(i, "Số CC").ToString();
                    dtoCapCc.CCC_Code = gridContentCertificate.GetRowCellValue(i, "Số CC").ToString();
                    //vtempDate = DateTime.ParseExact(gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    //TrieuVH deleted start 2018-04-19
                    //object tmDayOffBirth = gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString();
                    //if (tmDayOffBirth.ToString().Length < 5)
                    //{
                    //    tmDayOffBirth = "01/01/" + tmDayOffBirth;
                    //}
                    //else if (tmDayOffBirth.ToString().Length < 7)
                    //{
                    //    tmDayOffBirth = "01/" + tmDayOffBirth;
                    //}
                    //vtempDate = DateTime.ParseExact(tmDayOffBirth.ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    ////vtempDate = DateTime.Parse(tmDayOffBirth.ToString());// Utilities.Tool.ConvertToDate(tmDayOffBirth.ToString(), "dd/MM/yyyy");
                    //dtoCapCc.CCC_NgayHetHan = vCheckExpirationDate(vtempDate);
                    //TrieuVH deleted start 2018-04-19
                    if (dtoCapCc.CCC_SoCC != string.Empty)
                    {
                        dtoCapCc.CCC_HOVID = int.Parse(gridContentCertificate.GetRowCellValue(i, "HvID").ToString());
                        boCapcc.insert(dtoCapCc);
                    }
                    i++;
                }
            }
            vGetLastSoCC();
            return true;
        }
        private void vGetLastSoCC()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            DataTable lastSoCc = new DataTable();
            lastSoCc = boCapcc.getLast_SoCc(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            if (lastSoCc.Rows.Count <= 0)
            {
                txtSoCcCuoi.Text = "00000";
                txtSoCcSave.Text = "00000";
            }
            else if (lastSoCc.Rows[0]["SoCc"].ToString() == string.Empty)
            {
                txtSoCcCuoi.Text = "00000";
                txtSoCcSave.Text = "00000";
            }
            else
            {
                txtSoCcSave.Text = lastSoCc.Rows[0]["SoCc"].ToString();// +" GTVT";
                txtSoCcCuoi.Text = lastSoCc.Rows[0]["SoCc"].ToString();
                mSoCc = lastSoCc.Rows[0]["SoCc"].ToString();
            }
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
        private void searchByLastNameContrain()
        {
            gridCertificate.DataSource = boDkh.getCAP_CHUNGCHI_HV_ByLastNameContrain(txtSearchText.Text);

        }
        //private DateTime vCheckExpirationDate(DateTime vtempDate)
        //{
        //    int vAge = 0;
        //    object ExpirationYear;
        //    DateTime ExpirationDate;
        //    DateTime NewExpirationDate = DateTime.Now;
        //    vAge = dateNgayHetHan.DateTime.Year - vtempDate.Year;

        //    if (vAge >= 60)
        //    {
        //        ExpirationYear = vAge - 60;
        //        ExpirationDate = new DateTime(dateNgayHetHan.DateTime.Year - int.Parse(ExpirationYear.ToString()), vtempDate.Date.Month, vtempDate.Date.Day, vtempDate.Date.Hour, vtempDate.Date.Minute, vtempDate.Date.Second, vtempDate.Date.Millisecond);
        //        //ExpirationDate = new DateTime(dateNgayHetHan.DateTime.Year, vtempDate.Date.Month, vtempDate.Date.Day);
        //        NewExpirationDate = ExpirationDate;
        //    }
        //    else
        //    {
        //        NewExpirationDate = dateNgayHetHan.DateTime;
        //    }
        //    return NewExpirationDate;
        //}
        private Boolean checkGridEmpty()
        {
            int sCheck = gridContentCertificate.RowCount;
            if (sCheck == 0)
            {
                return true;
            }
            else
                return false;

        }
        private DataTable SearchTableResult()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            string DD = string.Empty;
            DataTable sResultTable = new DataTable();
            DataTable tableDiem = new DataTable("SearchResult");
            DataColumn column = new DataColumn();
            tableDiem.Columns.Add("HvID", typeof(int));
            tableDiem.Columns.Add("Họ", typeof(string));
            tableDiem.Columns.Add("Tên", typeof(string));
            tableDiem.Columns.Add("Ngày sinh", typeof(string));
            sResultTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < sResultTable.Rows.Count; i++)
            {
                tableDiem.Columns.Add(sResultTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            tableDiem.Columns.Add("Số CC", typeof(string));
            tableDiem.Columns.Add("Ngày cấp", typeof(string));

            DataTable tbs = new DataTable();
            //tbs = boCcc.GetData_For_CAP_CHUNGCHI_ByLopID(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()));
            tbs = boCapcc.searchHocVien_In_DKH_ByName(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text);
            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = tableDiem.NewRow();
                newRow.ItemArray = dr.ItemArray;
                tableDiem.Rows.Add(newRow);
            }
            return tableDiem;
        }
        private DataTable getLopDaCapCC()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            int vLopID = -1;
            int vLanThi = -1;
            vLopID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
            vLanThi = int.Parse(lookLanThi.GetColumnValue("DIE_LanThi").ToString());

            DataTable cCMhTable = new DataTable();
            DataTable dsHvDaCapCC = new DataTable("dsHvDaCapCC");
            DataColumn column = new DataColumn();
            dsHvDaCapCC.Columns.Add("HvID", typeof(int));
            dsHvDaCapCC.Columns.Add("Họ", typeof(string));
            dsHvDaCapCC.Columns.Add("Tên", typeof(string));
            dsHvDaCapCC.Columns.Add("Ngày sinh", typeof(string));
            cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < cCMhTable.Rows.Count; i++)
            {
                dsHvDaCapCC.Columns.Add(cCMhTable.Rows[i]["MonHoc"].ToString(), typeof(string));
            }
            dsHvDaCapCC.Columns.Add("CCC_ID", typeof(int));
            dsHvDaCapCC.Columns.Add("Số CC", typeof(string));
            dsHvDaCapCC.Columns.Add("Ngày cấp", typeof(string));
            dsHvDaCapCC.Columns.Add("CCC_LOPID", typeof(int));
            //dsHvDaCapCC.Columns.Add("SoCC", typeof(string));
            DataTable tbs = new DataTable();
            if (vLanThi > 1)
            {
                //Load tat ca cac hoc vien co lan thi >1
                // Load tat ca cac mon hoc thi >=5 diem
                int vHocVienId = -1;
                DataTable vTable = new DataTable();
                tbs = boDkh.getDangKiHoc_Name_ByLopID(vLopID, vLanThi);

                for (int i = 0; i < tbs.Rows.Count; i++)
                {
                    vHocVienId = int.Parse(tbs.Rows[i]["DAC_HOVID"].ToString());
                    vTable = boCapcc.vLoadCapChungChi_Next(vLopID, vHocVienId);
                    foreach (DataRow dr in vTable.Rows)
                    {
                        DataRow newRow = dsHvDaCapCC.NewRow();
                        newRow.ItemArray = dr.ItemArray;
                        dsHvDaCapCC.Rows.Add(newRow);
                    }
                }
            }
            else
            {
                tbs = boDkh.getDangKiHoc_Name_ByLopID(vLopID, vLanThi);
                foreach (DataRow dr in tbs.Rows)
                {
                    DataRow newRow = dsHvDaCapCC.NewRow();
                    newRow.ItemArray = dr.ItemArray;
                    for (int i = 4; i < cCMhTable.Rows.Count; i++)
                    {
                        if (newRow.ItemArray[i] == DBNull.Value)
                        {
                            newRow.Delete();
                            break;
                        }
                    }
                    dsHvDaCapCC.Rows.Add(newRow);
                }
            }

            return dsHvDaCapCC;
        }
        private void showLopDaCapCC()
        {
            DataTable tbCcc = new DataTable();
            DataTable tbst = new DataTable();
            tbCcc = getLopDaCapCC();
            tbst = tbCcc.Clone();
            for (int i = 0; i < tbCcc.Rows.Count; i++)
            {
                DateTime datetime;
                string StringDate = string.Empty;
                int tb1ColCount = tbCcc.Columns.Count;
                if (tbCcc.Rows[i][tb1ColCount - 2].ToString() != "")
                {
                    datetime = Convert.ToDateTime(tbCcc.Rows[i][tb1ColCount - 2].ToString());
                    datetime = Convert.ToDateTime(datetime.ToShortDateString());
                    StringDate = datetime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    StringDate = StringDate.ToString().Substring(0, 2) + "/" + StringDate.ToString().Substring(3, 2) + "/" + StringDate.ToString().Substring(6, 4);

                }
                DataRow tbstRow = tbst.NewRow();

                tbstRow[0] = tbCcc.Rows[i][0].ToString();
                tbstRow[1] = tbCcc.Rows[i][1].ToString();
                tbstRow[2] = tbCcc.Rows[i][2].ToString();
                tbstRow[3] = tbCcc.Rows[i][3].ToString();
                int subColTotal = tb1ColCount - 7;
                for (int isd = 4; isd < tb1ColCount - 3; isd++)
                {
                    tbstRow[isd] = tbCcc.Rows[i][isd].ToString();
                }
                tbstRow[tb1ColCount - 3] = tbCcc.Rows[i][tb1ColCount - 3].ToString();
                tbstRow[tb1ColCount - 2] = StringDate.ToString(); // tb1.Rows[i][tb1ColCount - 3].ToString();
                if (tbCcc.Rows[i][tb1ColCount - 1].ToString() != "")
                {
                    tbstRow[tb1ColCount - 1] = tbCcc.Rows[i][tb1ColCount - 1].ToString();
                }
                else
                    tbstRow[tb1ColCount - 1] = -1;

                tbst.Rows.Add(tbstRow);
            }

            gridContentCertificate.Columns.Clear();
            gridCertificate.DataSource = tbst;

            gridContentCertificate.Columns["HvID"].VisibleIndex = -1;
            gridContentCertificate.Columns["CCC_LOPID"].VisibleIndex = -1;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridContentCertificate.Columns["Ngày sinh"].DisplayFormat.FormatString = "dd/MM/yyyy";
        }
        private DataTable searchCCCResultTable()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            string DD = string.Empty;
            DataTable sResultTable = new DataTable();
            DataTable sResult = new DataTable("SearchCCCResult");
            DataColumn column = new DataColumn();
            sResult.Columns.Add("HvID", typeof(int));
            sResult.Columns.Add("Họ", typeof(string));
            sResult.Columns.Add("Tên", typeof(string));
            sResult.Columns.Add("Ngày sinh", typeof(string));
            sResultTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            for (int i = 0; i < sResultTable.Rows.Count; i++)
            {
                sResult.Columns.Add(sResultTable.Rows[i]["MonHoc"].ToString(), typeof(string));// (i.ToString() + 4)+ 
            }
            sResult.Columns.Add("Số CC", typeof(string));
            sResult.Columns.Add("Ngày cấp", typeof(string));

            DataTable tbs = new DataTable();
            tbs = boCapcc.searchHocVien_In_CCC_ByName(int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString()), txtSearchText.Text);
            foreach (DataRow dr in tbs.Rows)
            {
                DataRow newRow = sResult.NewRow();
                newRow.ItemArray = dr.ItemArray;
                sResult.Rows.Add(newRow);
            }
            return sResult;

        }
        private void saveDataToGrid()
        {
            BO_CAP_CHUNGCHI bo_cCC = new BO_CAP_CHUNGCHI();
            string CCC_Code = string.Empty;
            string CCC_SoCC = string.Empty;
            DateTime CCC_NgayCaps = DateTime.Now;
            DateTime CCC_NgayHetHan = DateTime.Now;
            DateTime vBirthDayYear = DateTime.Now;
            System.Data.SqlTypes.SqlDateTime getDateNull;
            getDateNull = SqlDateTime.Null;
            int i = 0;
            DataTable cCMhTable = new DataTable();
            DataTable tb1 = new DataTable();
            string sSoCc = string.Empty;
            string vStrSoCC = string.Empty;
            while (i < gridContentCertificate.RowCount)
            {
                boCapcc = new BO_CAP_CHUNGCHI();
                DataRow dr = gridContentCertificate.GetDataRow(i);
                string sdate = dr[4].ToString();
                //vBirthDayYear = ConvertToDate(sdate, "dd/MM/yyyy");
                //vAge = dateNgayCap.DateTime.Year + 5 - vBirthDayYear.Year;
                string sSoChungChi = dr["Số Cc"].ToString();
                cCMhTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
                for (int id = 0; id < cCMhTable.Rows.Count; id++)
                {
                    int vDiem = 0;
                    string vStr = dr[4 + id].ToString();
                    if (vStr == string.Empty)
                    {
                        vDiem = 0;
                    }
                    else
                    {
                        vDiem = int.Parse(vStr);
                    }
                    if (vDiem < 5)
                    {
                        goto outer;
                    }
                    else if (sSoChungChi != string.Empty)
                    {
                        goto outer;
                    }
                }
                if (txtEditeSoCc.Text == "")
                {
                    vStrSoCC = txtSoCcCuoi.Text;
                }
                else
                {
                    vStrSoCC = txtEditeSoCc.Text;
                }
                sSoCc = Utilities.quydinh.LaySTT(int.Parse(vStrSoCC.ToString()) + 1) + " GTVT";
                txtSoCcCuoi.Text = sSoCc.ToString().Substring(0, 5);
                dr["Số Cc"] = sSoCc;
                dr["Ngày cấp"] = CCC_NgayCaps;

            outer:
                i++;
            }

            DataTable lastSoCc = new DataTable();
            lastSoCc = boCapcc.getLast_SoCc(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
            if (lastSoCc.Rows.Count <= 0)
            {
                txtSoCcCuoi.Text = "00000";
                return;
            }
            else
            {
                mSoCc = lastSoCc.Rows[0]["SoCc"].ToString();
            }
        }
        private Boolean UpdateSoCCNull()
        {
            DateTime CCC_NgayCaps = DateTime.Now;
            DateTime CCC_NgayHetHan = DateTime.Now;
            if (sselection.SelectedCount > 0)
            {
                for (int i = 0; i < gridContentCertificate.RowCount; i++)
                {

                    if (sselection.IsRowSelected(i))
                    {
                        // Update coder
                        DataRow dr = gridContentCertificate.GetDataRow(i);
                        int HvId = int.Parse(dr["HvId"].ToString());
                        int LopId = int.Parse(dr["CCC_LOPID"].ToString());
                        dr["Số Cc"] = "";
                        dr["Ngày cấp"] = "";
                    }

                }
            }
            return true;

        }
        private void CapLai()
        {
            int num;
            DataTable vTable;
            bool isNumeric = int.TryParse(txtEditeSoCc.Text, out num);
            if (!isNumeric)
            {
                MessageBox.Show("Phải nhập số", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditeSoCc.Focus();
                return;
            }
            if (sselection.SelectedCount > 0)
            {
                DateTime CCC_NgayCaps = dateNgayCap.DateTime;
                for (int i = 0; i < gridContentCertificate.RowCount; i++)
                {
                    if (sselection.IsRowSelected(i))
                    {
                        // Update coder
                        DataRow dr = gridContentCertificate.GetDataRow(i);
                        if (radCapTuDong.SelectedIndex < 1 || txtEditeSoCc.Text == "")
                        {
                            MessageBox.Show("Chưa nhập số chứng chỉ cuối", "THÔNG BÁO");
                            txtEditeSoCc.Focus();
                            return;
                        }
                        vTable = boMonHoc.SelectMONHOC_Name_By_CHCID(int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString()));
                        for (int id = 0; id < vTable.Rows.Count; id++)
                        {
                            int vDiem = 0;
                            string vStr = dr[4 + id].ToString();
                            if (vStr == "")
                            {
                                vDiem = 0;
                            }
                            else
                            {
                                vDiem = int.Parse(vStr);
                            }
                            if (vDiem < 5)
                            {
                                goto outer;
                            }
                        }
                        string stemps = txtEditeSoCc.Text;
                        string[] ss = stemps.Split(' ');
                        string sSoCc = ss[0].ToString();
                        sSoCc = Utilities.quydinh.LaySTT(int.Parse(sSoCc.ToString()) + 1) + " GTVT";
                        txtEditeSoCc.Text = sSoCc.ToString().Substring(0, 5);
                        dr["Số Cc"] = sSoCc;
                        dr["Ngày cấp"] = CCC_NgayCaps;
                    }
                outer:;
                }
            }

        }
        private void updateSoCC_Null()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            dtoCapCc = new CAP_CHUNGCHI();
            if (checkGridEmpty() == false)
            {
                for (int i = 0; i < gridContentCertificate.RowCount; i++)
                {
                    if (sselection.IsRowSelected(i))
                    {
                        DataRow dr = gridContentCertificate.GetDataRow(i);
                        dtoCapCc.CCC_ID = int.Parse(dr["CCC_ID"].ToString());
                        dtoCapCc.CCC_SoCC = string.Empty;
                        dtoCapCc.CCC_NgayCap = null;
                        dtoCapCc.CCC_NgayHetHan = null;
                        boCapcc.update_SoCc(dtoCapCc);
                    }
                }
            }
        }
        private Boolean updateSoCC_New()
        {
            boCapcc = new BO_CAP_CHUNGCHI();
            dtoCapCc = new CAP_CHUNGCHI();
            DateTime vtempDate;
            if (sselection.SelectedCount <= 0)
            {
                MessageBox.Show("Phải chọn các danh sách lưu chứng chỉ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                dtoCapCc.CCC_NgayCap = dateNgayCap.DateTime;
                //TrieuVH add start 2018-04-19
                dateNgayHetHan.DateTime = new DateTime(dateNgayCap.DateTime.Year + 5, dateNgayCap.DateTime.Month, dateNgayCap.DateTime.Day, dateNgayCap.DateTime.Hour, dateNgayCap.DateTime.Minute, dateNgayCap.DateTime.Second, dateNgayCap.DateTime.Millisecond);
                dtoCapCc.CCC_NgayHetHan = (DateTime)dateNgayHetHan.EditValue;
                //TrieuVH add start 2018-04-19
                for (int i = 0; i < gridContentCertificate.RowCount; i++)
                {
                    if (sselection.IsRowSelected(i))
                    {
                        DataRow dr = gridContentCertificate.GetDataRow(i);
                        dtoCapCc.CCC_ID = int.Parse(dr["CCC_ID"].ToString());
                        dtoCapCc.CCC_HOVID = int.Parse(dr["HvID"].ToString());
                        dtoCapCc.CCC_Code = dtoCapCc.CCC_SoCC = dr["Số Cc"].ToString();
                        //TrieuVH deleted start 2018-04-19
                        //object tmDayOffBirth = gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString();
                        //if (tmDayOffBirth.ToString().Length < 5)
                        //{
                        //    tmDayOffBirth = "01/01/" + tmDayOffBirth;
                        //}
                        //else if (tmDayOffBirth.ToString().Length < 7)
                        //{
                        //    tmDayOffBirth = "01/" + tmDayOffBirth;
                        //}
                        //vtempDate = DateTime.ParseExact(tmDayOffBirth.ToString(), "dd/MM/yyyy", CultureInfo.CurrentUICulture.DateTimeFormat);
                        //TrieuVH deleted end 2018-04-19
                        //vtempDate = DateTime.ParseExact(gridContentCertificate.GetRowCellValue(i, "Ngày sinh").ToString(), "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                        //Update on required "Xem lại cc" 2017-10-12
                        //dtoCapCc.CCC_NgayHetHan = vCheckExpirationDate(vtempDate);
                        //dtoCapCc.CCC_NgayHetHan = (DateTime)dateNgayHetHan.EditValue; /TrieuVH deleted 2018-04-19
                        //End
                        if (tb2.Rows.Count > 0)
                        {
                            dtoCapCc.CCC_NgayCapLai = null;
                            dtoCapCc.CCC_Status = 1;
                            dtoCapCc.CCC_SoHieuDoi = string.Empty;
                            dtoCapCc.CCC_DOIID = -1;
                            dtoCapCc.CCC_LOPID = int.Parse(lookLopHoc.GetColumnValue("LOP_ID").ToString());
                            dtoCapCc.CCC_CHCID = int.Parse(lookChungChi.GetColumnValue("CHC_ID").ToString());
                            for (int ik = 0; ik < tb2.Rows.Count; ik++)
                            {
                                if (int.Parse(tb2.Rows[ik]["HvID"].ToString()) == dtoCapCc.CCC_HOVID)
                                {
                                    boCapcc.insert(dtoCapCc);
                                }
                            }
                        }
                        else if (dtoCapCc.CCC_SoCC == string.Empty)
                        {
                            dtoCapCc.CCC_NgayCap = null;
                            dtoCapCc.CCC_NgayHetHan = null;
                            boCapcc.update_SoCc(dtoCapCc);
                        }
                        else
                        {
                            boCapcc.update_SoCc(dtoCapCc);
                        }
                    }
                }
                return true;
            }
        }
        private static DateTime ConvertToDate(string Date, string Format)
        {
            DateTime date = DateTime.MinValue;
            try
            {
                string[] s = Date.Split(new char[] { '/', '-' });
                int d = date.Day;
                int m = date.Month;
                int y = date.Year;
                //for (int i = 0; i < s.Length; i++)
                //{
                if (Format == "dd/MM/yyyy" || Format == "dd-MM-yyyy")
                {
                    if (s.Length == 2)
                    {
                        int.TryParse(s[0], out m);
                        int.TryParse(s[1], out y);
                    }
                    else if (s.Length == 3)
                    {
                        int.TryParse(s[0], out d);
                        int.TryParse(s[1], out m);
                        int.TryParse(s[2], out y);
                    }
                    else if (s.Length == 1)
                    {
                        int.TryParse(s[0], out y);
                    }
                }
                else if (Format == "MM/dd/yyyy" || Format == "MM-dd-yyyy")
                {
                    if (s.Length == 2)
                    {
                        int.TryParse(s[0], out m);
                        int.TryParse(s[1], out y);
                    }
                    else if (s.Length == 3)
                    {
                        int.TryParse(s[0], out d);
                        int.TryParse(s[1], out m);
                        int.TryParse(s[2], out y);
                    }
                    else if (s.Length == 1)
                    {
                        int.TryParse(s[0], out y);
                    }
                }


                //}

                date = new DateTime(y, m, d);
            }
            catch { }
            return date;
        }
        private void updateSoCC_NgayCap()
        {
            if (sselection.SelectedCount == 0)
            {
                MessageBox.Show("Chưa chọn học viên", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DateTime CCC_NgayCaps = dateNgayCap.DateTime;
                dateNgayHetHan.DateTime = new DateTime(dateNgayCap.DateTime.Year + 5, dateNgayCap.DateTime.Month, dateNgayCap.DateTime.Day, dateNgayCap.DateTime.Hour, dateNgayCap.DateTime.Minute, dateNgayCap.DateTime.Second, dateNgayCap.DateTime.Millisecond);
                DateTime CCC_NgayHetHan = dateNgayHetHan.DateTime;
                for (int i = 0; i < gridContentCertificate.RowCount; i++)
                {
                    if (sselection.IsRowSelected(i))
                    {
                        DataRow dr = gridContentCertificate.GetDataRow(i);
                        int CccID = int.Parse(dr["CCC_ID"].ToString());
                        //TrieuVH delete start 2018-04-19
                        //string NgaySinh = dr["Ngày sinh"].ToString();

                        //DateTime sBirthDay = ConvertToDate(NgaySinh, "dd/MM/yyyy");

                        //int years = -1;
                        ////years = dateNgayHetHan.DateTime.Year - sBirthDay.Year;
                        //object newYear;
                        //int yearEnd = -1;
                        //newYear = years = dateNgayCap.DateTime.Year - sBirthDay.Year;

                        //if (int.Parse(newYear.ToString()) >= 60)
                        //{
                        //    MessageBox.Show("Học viên " + dr["Họ"].ToString() + " " + dr["Tên"].ToString() + "này đã quá 60 tuổi", "THÔNG BÁO");
                        //    //return;
                        //    yearEnd = dateNgayHetHan.DateTime.Year - (int.Parse(newYear.ToString()) - 60);
                        //    //yearEnd = dateNgayCap.DateTime.Year + years;
                        //    sBirthDay = new DateTime(yearEnd, sBirthDay.Date.Month, sBirthDay.Date.Day, sBirthDay.Date.Hour, sBirthDay.Date.Minute, sBirthDay.Date.Second, sBirthDay.Date.Millisecond);
                        //    CCC_NgayHetHan = sBirthDay;
                        //}
                        //years = 60 - years;

                        //if (years > 5)
                        //{
                        //    CCC_NgayHetHan = new DateTime(dateNgayCap.DateTime.Year + 5, dateNgayCap.DateTime.Month, dateNgayCap.DateTime.Day, dateNgayCap.DateTime.Hour, dateNgayCap.DateTime.Minute, dateNgayCap.DateTime.Second, dateNgayCap.DateTime.Millisecond);
                        //}
                        //else
                        //{
                        //    yearEnd = dateNgayHetHan.DateTime.Year - (int.Parse(newYear.ToString()) - 60);
                        //    sBirthDay = new DateTime(yearEnd, sBirthDay.Date.Month, sBirthDay.Date.Day, sBirthDay.Date.Hour, sBirthDay.Date.Minute, sBirthDay.Date.Second, sBirthDay.Date.Millisecond);
                        //    CCC_NgayHetHan = sBirthDay;
                        //}
                        //TrieuVH delete end 2018-04-19
                        boDoiCc.update_NgayCap_Doi(CccID, CCC_NgayCaps, CCC_NgayHetHan);
                    }

                }

            }
        }
        #endregion

    }
}


