
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using TTHLTV.Utilities;

namespace TTHLTV
{
    public partial class frmAddNewClass : DevExpress.XtraEditors.XtraForm
    {
        BO_LOP boLop = new BO_LOP();
        BO_CHUNG_CHI boCc = new BO_CHUNG_CHI();
        BO_MON_LOP boMonlop = new BO_MON_LOP();
        private int mSearchBy = -1;
        private int mSearchCon = -1;
        private int mCcId =0;
        private int iLop;
        private string mBtnSender = string.Empty;
        private int sStatust;
        private int mMonHocId;
        public frmAddNewClass()
        {
            InitializeComponent();
        }

        #region Events
       
        private void lookCcID_EditValueChanged(object sender, EventArgs e)
        {
            int id = -1;
            if (lookCcID.ItemIndex >= 0)
            {
                id = int.Parse(getKhoaHoc().Rows[lookCcID.ItemIndex]["CHC_ID"].ToString());

            }
            else
            {
                return;
            }
            mCcId = id;
            clearInputData();
            sLoadDataToGriview();
            txtCode.Text = string.Empty;
            sGeneralCode();
            txtName.Text = lookCcID.GetColumnValue("CHC_Name").ToString();
            txtName.Focus();
            txtName.SelectAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SimpleButton btnSender = (SimpleButton)sender;
            mBtnSender = btnSender.Text;
            //sGeneralCode();
            //sGeneralCodeLop_MonHoc();
            sCheckButtonVisible(2);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string lopCode = string.Empty;
            //int sCheckSave;
            //lopCode = (txtCode.Text).Substring(3, 5);
            //sCheckSave = int.Parse(lopCode.ToString());
            if (checkInput() == true)
            {
                //if (sCheckSave == sStatust + 1)
                if (mBtnSender == "Thêm mới")
                {
                    saveData(1);
                    

                }
                else
                    if (mBtnSender == "Sửa thông tin")//sCheckSave == sStatust)
                    {
                        saveData(2);
                        //clearInputData();
                        //txtCode.Text = string.Empty;
                        //sLoadDataToGriview();
                    }
                clearInputData();
                txtCode.Text = string.Empty;
                sLoadDataToGriview();
                sGeneralCode();
                sGeneralCodeLop_MonHoc();
            }
            else
                return;
           
        }

        private void grvNewClassContent_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            sFillDataToControl();
            sCheckButtonVisible(1);
            btnEdit.Enabled = true;
            btnNew.Enabled = false;
            btnDelete.Enabled = true;
          
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SimpleButton btnSender = (SimpleButton)sender;
            mBtnSender = btnSender.Text;
            clearInputData();
            lookCcID.ItemIndex = int.Parse(("0").ToString());
            this.lookCcID.ResetText();
            this.lookCcID.Properties.NullText = "Chọn khóa học";
            sGeneralCode();
            sCheckButtonVisible(2);
            btnEdit.Enabled = false;
        }

        private void frmAddNewClass_Load(object sender, EventArgs e)
        {
            Utilities.setFontSize.SetGridFont(gridNewClass.MainView, new Font("Tahoma", 11));
            //sGeneralCode();
            sGeneralCodeLop_MonHoc();
            sCheckButtonVisible(1);
            loadKhoaHoc();
            sLookupSearchBy();
            sLookupCondition();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = grvNewClassContent.GetDataRow(grvNewClassContent.FocusedRowHandle);
            if (selectedRow != null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa lớp này không?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int lopId = int.Parse(selectedRow["LOP_ID"].ToString());
                    selectedRow.Delete();
                    boLop.delete(lopId);
                    clearInputData();
                    txtCode.Text = string.Empty;
                    sLoadDataToGriview();
                }
            }
        }

        private void lookSearchBy_EditValueChanged(object sender, EventArgs e)
        {
            mSearchBy = int.Parse( lookSearchBy.GetColumnValue("ID").ToString());

        }

        private void lookCondition_EditValueChanged(object sender, EventArgs e)
        {
            mSearchCon = int.Parse(lookCondition.GetColumnValue("ID").ToString());
           
        }

       private void btnClose_Click(object sender, EventArgs e)
       {
           this.Close();
       }

       private void btnCancel_Click(object sender, EventArgs e)
       {
           clearInputData();
           lookCcID.Properties.DataSource = null;
           lookCcID.Properties.NullText="Chọn chứng chỉ";
           txtCode.Text = string.Empty;
           btnNew.Enabled = true;
       }

       private void btnSearch_Click(object sender, EventArgs e)
       {
           if (txtSearchInput.Text != string.Empty)
           {
               mSearchBy = int.Parse(lookSearchBy.GetColumnValue("ID").ToString());
               mSearchCon = int.Parse(lookCondition.GetColumnValue("ID").ToString());
               gridNewClass.DataSource = sSearch(mSearchBy);
           }
           else
               if (txtSearchInput.Text == string.Empty)
               {
                   ((DataTable)gridNewClass.DataSource).Rows.Clear();

               }
       }

       private void txtSearchInput_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
       {
           if (txtSearchInput.Text != string.Empty)
           {
               mSearchBy = int.Parse(lookSearchBy.GetColumnValue("ID").ToString());
               mSearchCon = int.Parse(lookCondition.GetColumnValue("ID").ToString());
               gridNewClass.DataSource = sSearch(mSearchBy);
           }
           else
               if (txtSearchInput.Text == string.Empty)
               {
                   ((DataTable)gridNewClass.DataSource).Rows.Clear();

               }
       }
        #endregion

       #region Extenal functions
       private void sCheckButtonVisible( int sCheck)
        {
            if (sCheck ==1)
            {
                btnNew.Enabled = true;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
                btnClose.Enabled = true;
                btnDelete.Enabled = false;
                btnCancel.Enabled = false;
                txtName.Enabled = false;
                txtKhoa.Enabled = false;
                txtShortName.Enabled = false;
                dateNgayKG.Enabled = false;
                dateNgayKT.Enabled = false;
                dateNgayQD.Enabled = false;
                txtName.BackColor = Color.White;
                txtShortName.BackColor = Color.White;
                dateNgayKG.BackColor = Color.White;
                dateNgayKT.BackColor = Color.White;
                dateNgayQD.BackColor = Color.White;
                txtKhoa.BackColor = Color.White;
            }
            else
                if (sCheck ==2)
                {
                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnSave.Enabled = true;
                    btnClose.Enabled = true;
                    btnDelete.Enabled = true;
                    btnCancel.Enabled = true;
                    txtName.Enabled = true;
                    txtKhoa.Enabled=true;
                    txtShortName.Enabled = true;
                    dateNgayKG.Enabled = true;
                    dateNgayKT.Enabled = true;
                    dateNgayQD.Enabled = true;
                }
 
        }

        #region Genaral code
        private void sGeneralCode()
        {
            DataTable tb = new DataTable();
            tb = boLop.getLOP_LastCode();
            string lCode = String.Empty;
            if (tb.Rows.Count ==0)
            {
                lCode = "000000";
            }
            else
                if (tb.Rows.Count>0)
                {
                    lCode = tb.Rows[0]["LastCode"].ToString();
                }
           
            txtCode.Text = ("LOP" + quydinh.LaySTT(int.Parse(lCode.ToString()) + 1)).ToString();
            sStatust = int.Parse(lCode.ToString());
        }
        #endregion
        #region general code chung chi mon hoc
        private void sGeneralCodeLop_MonHoc()
        {
            DataTable tb = new DataTable();
            tb = boLop.getLOP_MONHOC_LastCode();
            string lCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                lCode = "000000";
            }
            else
                if (tb.Rows.Count > 0)
                {
                    lCode = tb.Rows[0]["LastCode"].ToString();
                }

            txtMonLopCode.Text = ("MOL" + quydinh.LaySTT(int.Parse(lCode.ToString()) + 1)).ToString();
            sStatust = int.Parse(lCode.ToString());
        }
        #endregion
        #region Search tool
        private void sLookupSearchBy()
        {
            //-- Instantiate the data set and table
            DataTable sTable = new DataTable("sSearchTable");

            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "Tên lớp");
            sTable.Rows.Add(2, "Mã lớp");

            lookSearchBy.Properties.DataSource= sTable;
            lookSearchBy.Properties.ValueMember = "ID";
            lookSearchBy.Properties.DisplayMember = "Name";
            lookSearchBy.ItemIndex = 0;
        }
        private void sLookupCondition()
        {
            //-- Instantiate the data set and table

            DataTable sTable = new DataTable("sConditionTable");

            //-- Add columns to the data table
            sTable.Columns.Add("ID", typeof(int));
            sTable.Columns.Add("Name", typeof(string));

            //-- Add rows to the data table
            sTable.Rows.Add(1, "Có chứa");
            sTable.Rows.Add(2, "Bắt đầu");

            lookCondition.Properties.DataSource= sTable;
            lookCondition.Properties.ValueMember = "ID";
            lookCondition.Properties.DisplayMember = "Name";
            lookCondition.ItemIndex = 0;
        }
        private DataTable sSearch(int sSearch)
        {
            DataTable tb = new DataTable("Result");
           //sSearch= mSearchBy;
           if (sSearch == 1)
            {
               tb= sSearchByName(mSearchCon);
            }
            else
                if (sSearch == 2)
                {
                   tb= sSearchByCode(mSearchCon);
                }
           return tb;
        }
        private DataTable sSearchByName(int sSear)
        {
            //sSear = mSearchCon;
            DataTable tb = new DataTable("SearchResult");
            
            if (sSear == 1)
            {
                 tb = boLop.SearchClass_ByName("%" + txtSearchInput.Text + "%");

            }
            else
                if (sSear == 2)
                {
                     tb = boLop.SearchClass_ByName(txtSearchInput.Text + "%");
                }
            return tb;
 
        }
        private DataTable sSearchByCode(int sSear)
        {
            DataTable tb = new DataTable("SearchResult");

            if (sSear == 1)
            {
                tb = boLop.SearchClass_ByName("%" + txtSearchInput.Text + "%");

            }
            else
                if (sSear == 2)
                {
                    tb = boLop.SearchClass_ByName(txtSearchInput.Text + "%");
                }
            return tb;
 
        }
        #endregion
        private void sFillDataToControl( )
        {
            DataRow selectedRow = grvNewClassContent.GetDataRow(grvNewClassContent.FocusedRowHandle);
            iLop = int.Parse(selectedRow["LOP_ID"].ToString());
            txtCode.Text = selectedRow["LOP_Code"].ToString();
            txtName.Text = selectedRow["LOP_Name"].ToString();
            txtKhoa.Text = selectedRow["LOP_Khoa"].ToString();
            txtShortName.Text = selectedRow["LOP_ShortName"].ToString();
            dateNgayKG.DateTime = Convert.ToDateTime(selectedRow["LOP_Ngay_KG"].ToString());
            dateNgayKT.DateTime = Convert.ToDateTime(selectedRow["LOP_Ngay_KT"].ToString());
            dateNgayQD.DateTime = Convert.ToDateTime(selectedRow["LOP_Ngay_QD"].ToString());
            //dateNgayKT.Text = Convert.ToDateTime(selectedRow["LOP_Ngay_KT"].ToString()).ToShortDateString();
            //dateNgayQD.Text = Convert.ToDateTime(selectedRow["LOP_Ngay_QD"].ToString()).ToShortDateString();
        }

        private void sLoadDataToGriview()
        {
            gridNewClass.DataSource = boLop.getLOP_ByCcID_NewClass(mCcId);
        }
        
        private void clearInputData()
        {
            txtName.Text = string.Empty;
            txtKhoa.Text = string.Empty;
            txtShortName.Text = string.Empty;
            dateNgayKG.Text = string.Empty;
            dateNgayKT.Text = string.Empty;
            dateNgayQD.Text = string.Empty;
                     
        }

       private DataTable getKhoaHoc()
        {
            return boCc.getChungChi_All();
 
        }

        private void loadKhoaHoc()
        {
            lookCcID.Properties.DataSource = getKhoaHoc();
            lookCcID.Properties.ValueMember = "CHC_ID";
            lookCcID.Properties.DisplayMember = "CHC_Name";
           
        }
       
        private void saveData( int sCheck)
        {
            string sCode = string.Empty;
            string sName = string.Empty;
            string sKhoa;
            string sShortName = string.Empty;
            DateTime sNgayKG = new DateTime();
            DateTime sNgayKT = new DateTime(); 
            DateTime sNgayQD = new DateTime();
            int sCcId;
          
                sCode = txtCode.Text;
                sName = txtName.Text;
                sKhoa = txtKhoa.Text;
                sShortName = txtShortName.Text;
                //object startDate = dateNgayKG.Text;
                //object endDadate = dateNgayKT.Text;
                //object sDate = dateNgayQD.Text;

                //startDate = dateNgayKG.Text.Substring(3, 2) + "/" + dateNgayKG.Text.Substring(0, 2) + "/" + dateNgayKG.Text.Substring(6, 4);
                //endDadate = dateNgayKT.Text.Substring(3, 2) + "/" + dateNgayKT.Text.Substring(0, 2) + "/" + dateNgayKT.Text.Substring(6, 4);
                //sDate = dateNgayQD.Text.Substring(3, 2) + "/" + dateNgayQD.Text.Substring(0, 2) + "/" + dateNgayQD.Text.Substring(6, 4);

                //sNgayKG = DateTime.ParseExact(dateNgayKG.Text, "mm/dd/yyyy", null);
                //sNgayKT = DateTime.ParseExact(dateNgayKT.Text, "mm/dd/yyyy", null);
                //sNgayQD = DateTime.ParseExact(dateNgayQD.Text, "mm/dd/yyyy", null);
                sNgayKG = dateNgayKG.DateTime;
                sNgayKT = dateNgayKT.DateTime;
                sNgayQD = dateNgayQD.DateTime;

              
                sCcId = mCcId;

                if (sCheck == 1)
                {
                    boLop.insert(sCode, sName, sKhoa, sShortName, sNgayKG, sNgayKT, sNgayQD, sCcId);

                    int sLastLopId = int.Parse(boLop.getLOP_LastId().Rows[0]["LastID"].ToString());
                    Dictionary<int, int> sDicIdMonHoc = new Dictionary<int, int>();
                    for (int i = 0; i < boLop.getCC_MONHOC_BY_CCID(mCcId).Rows.Count-1; i++)
                    {
                        sDicIdMonHoc.Add(int.Parse(boLop.getCC_MONHOC_BY_CCID(mCcId).Rows[i]["CCM_MONID"].ToString()), i);
                    }
                    foreach (var item in sDicIdMonHoc)
                    {
                        mMonHocId = item.Key;
                        // get so tiet khi da co mon id
                        int sMonSotiet = int.Parse(boLop.SelectMONHOC_SoTiet_MonId(mMonHocId).Rows[0]["MON_SoTiet"].ToString());
                        boMonlop.insert(txtMonLopCode.Text, sLastLopId, mMonHocId, -1, sMonSotiet);
                    }

                }
                else
                    if (sCheck == 2)
                    {
                        boLop.update(iLop, sCode, sName, sKhoa, sShortName, sNgayKG, sNgayKT, sNgayQD, sCcId);
                        // CHECK UPDATE MON_LOP TABLE HERE
                    }
        }

        private Boolean checkInput()
        {
            if (txtKhoa.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập khóa học", "THÔNG BÁO");
                txtKhoa.Focus();
            }
            else
            {
                if (txtShortName.Text == string.Empty)
                {
                    MessageBox.Show("Chưa nhập tên viết tắt của lớp học", "THÔNG BÁO");
                    txtShortName.Focus();

                }
                else
                {
                    if (dateNgayKG.Text == string.Empty)
                    {
                        MessageBox.Show("Chưa nhập ngày bắt đầu", "THÔNG BÁO");
                        dateNgayKG.Focus();
                        return false;
                    }
                    else
                    {
                        if (dateNgayKT.Text == string.Empty)
                        {
                            MessageBox.Show("Chưa nhập ngày kết thúc ", " THÔNG BÁO");
                            dateNgayKT.Focus();
                            return false;

                        }
                        else
                        {
                            if (dateNgayQD.Text == string.Empty)
                            {
                                MessageBox.Show("Chưa nhập ngày quyết định", "THÔNG BÁO");
                                dateNgayQD.Focus();

                            }
 
                        }
                        
                    }
 
                }
 
            }
           
            
            return true;
        }

       #endregion

        private void txtKhoa_Leave(object sender, EventArgs e)
        {
           
                //if (txtKhoa.Text.Length != 4)
                //{
                //    MessageBox.Show("Nhập đủ bốn chữ số cho khóa học (####)", "THÔNG BÁO");
                //    txtKhoa.Focus();
                //    txtKhoa.SelectAll();
                    
                //}
            
        }



    }
}