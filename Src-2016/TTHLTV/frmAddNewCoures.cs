using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TTHLTV.BAL;
using TTHLTV.DAL;

namespace TTHLTV
{
    public partial class frmAddNewCoures : DevExpress.XtraEditors.XtraForm
    {
        BO_CHUNG_CHI boCc = new BO_CHUNG_CHI();
        BO_MONHOC boMh = new BO_MONHOC();
        BO_CC_MONHOC boCc_Mh = new BO_CC_MONHOC();
        frmCouresList sCouresList = new frmCouresList();
        private int sStatust;
        public int sGridIndexCoures ;
        private int mIdCcMh;
        private int mCcID;
        private int mFontSize;

        public string sCode = string.Empty;
        public string sName = string.Empty;
        public int sId = 0;
        public string btnSender = string.Empty;
        private int msbId = -1;
        private int mcId = -1;
        public frmAddNewCoures()
        {
            InitializeComponent();
        }
        private void checkExits()
        {
            int sTotal = boCc_Mh.getCC_MONHOC_ByCcID(mIdCcMh).Rows.Count;
            for (int ii = 0; ii < sTotal; ii++)
            {
                for (int i = 0; i < boMh.getMonHoc_All().Rows.Count; i++)
                {
                    if (boCc_Mh.getCC_MONHOC_ByCcID(mIdCcMh).Rows[ii]["CCM_MONID"].ToString() == boMh.getMonHoc_All().Rows[i]["MON_ID"].ToString())
                    {
                        //listSubject.SetItemChecked(int.Parse(boCc_Mh.getCC_MONHOC_ByCcID(mIdCcMh).Rows[ii]["CCM_MONID"].ToString()), true);
                        listSubject.SetItemChecked(i, true);
                    }
                    else
                    {
                        listSubject.Refresh();
                    }
                }
            }
        }
        private void frmAddNewCoures_Load(object sender, EventArgs e)
        {
           Utilities.setFontSize.SetGridFont(gridCoures.MainView, new Font("Tahoma", 11));
            sLoadSubject();
            checkVisible(1);
            vLoadLoaiChungChi();
            vLookupFontSize_1();
            vLookupFontSize_2();
            vLookupFontSize_3();
            vLookupFontSize_4();
            gridCoures.DataSource = boCc.getChungChi_All();
            if (btnSender == "Xem chi tiết" || btnSender == "Appearance")
            {
                //loadDataEdit();
                vLoadLoaiChungChiInfoByID(sId);
            }
            else
                if (btnSender == "Thêm mới")
                {
                    //sLoadDataToControl();
                    sGeneralCode();
                    txtName.Enabled = true;
                }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadDataEdit()
        {
            vLoadLoaiChungChiInfoByID(sId);
            txtCode.Text = sCode.ToString();
            txtName.Text = sName.ToString();
            checkVisible(1);
        }

        private void vLoadLoaiChungChiInfoByID(int ChungChiId)
        {
            checkVisible(3);
            DataTable tb = new DataTable();
            tb = boCc.getChungChi_ByID(ChungChiId);
            if (tb.Rows.Count>0)
            {
                mIdCcMh = int.Parse(tb.Rows[0]["CHC_ID"].ToString());
                sId = mIdCcMh;
                txtCode.Text = tb.Rows[0]["CHC_Code"].ToString();
                txtName.Text = tb.Rows[0]["CHC_Name"].ToString();
                txtNoidung1.Text = tb.Rows[0]["CHC_Content1"].ToString();
                txtNoidung2.Text = tb.Rows[0]["CHC_Content2"].ToString();
                txtNoidung3.Text = tb.Rows[0]["CHC_Content3"].ToString();
                txtNoidung4.Text = tb.Rows[0]["CHC_Content4"].ToString();
                txtSoQT.Text = tb.Rows[0]["CHC_QuyTac"].ToString();
                txtModleCourse.Text = tb.Rows[0]["CHC_ModleCode"].ToString();
                txtQuyDinh.Text = tb.Rows[0]["CHC_QuyDinh"].ToString();
                txtQuyDinhEng.Text = tb.Rows[0]["CHC_QuyDinhEngl"].ToString();

                for (int i = 0; i < boCc_Mh.getCC_MONHOC_All().Rows.Count; i++)
                {
                    if (mIdCcMh == int.Parse(boCc_Mh.getCC_MONHOC_All().Rows[i]["CCM_CHCID"].ToString()))
                    {
                        mIdCcMh = int.Parse(boCc_Mh.getCC_MONHOC_All().Rows[i]["CCM_CHCID"].ToString());
                    }
                }
                listSubject.UnCheckAll();
                checkExits();
            }
        }

        private void sLoadSubject()
        {
            listSubject.DataSource = boMh.getMonHoc_All();
            listSubject.ValueMember = "MON_ID";
            listSubject.DisplayMember = "MON_Name";
        }
        private void checkVisible(int scheck)
        {
            if (scheck==1)
            {

                txtCode.Enabled = false;
                txtName.Enabled = false;
                txtNoidung1.Enabled = false;
                txtNoidung2.Enabled = false;
                txtNoidung3.Enabled = false;
                txtNoidung4.Enabled = false;
                txtSoQT.Enabled = false;
                txtModleCourse.Enabled = false;
                txtQuyDinh.Enabled = false;
                txtQuyDinhEng.Enabled = false;
                lookupFonsize_1.Enabled = false;
                lookupFonsize_2.Enabled = false;
                lookupFonsize_3.Enabled = false;
                lookupFonsize_4.Enabled = false;
                txtName.BackColor = Color.White;
                txtNoidung1.BackColor = Color.White;
                txtNoidung2.BackColor = Color.White;
                txtNoidung3.BackColor = Color.White;
                txtNoidung4.BackColor = Color.White;
                txtSoQT.BackColor = Color.White;
                txtModleCourse.BackColor = Color.White;
                txtQuyDinh.BackColor = Color.White;
                txtQuyDinhEng.BackColor = Color.White;
                btnEdit.Enabled = false;
                btnSave.Enabled = false;
            }
            else
                if (scheck==2)
                {
                    txtCode.Enabled = false;
                    txtName.Enabled = true;
                    txtNoidung1.Enabled = true;
                    txtNoidung2.Enabled = true;
                    txtNoidung3.Enabled = true;
                    txtNoidung4.Enabled = true;
                    txtSoQT.Enabled = true;
                    txtModleCourse.Enabled = true;
                    txtQuyDinh.Enabled = true;
                    txtQuyDinhEng.Enabled = true;
                    btnSave.Enabled = true;
                    btnEdit.Enabled = false;
                    lookupFonsize_1.Enabled = true;
                    lookupFonsize_2.Enabled = true;
                    lookupFonsize_3.Enabled = true;
                    lookupFonsize_4.Enabled = true;
                    
                }
            else
                    if (scheck==3)
                    {
                        txtCode.Enabled = false;
                        txtName.Enabled = false;
                        txtNoidung1.Enabled = false;
                        txtNoidung2.Enabled = false;
                        txtNoidung3.Enabled = false;
                        txtNoidung4.Enabled = false;
                        txtSoQT.Enabled = false;
                        txtQuyDinh.Enabled = false;
                        txtQuyDinhEng.Enabled = false;
                        txtModleCourse.Enabled = false;
                        txtName.BackColor = Color.White;
                        txtNoidung1.BackColor = Color.White;
                        txtNoidung2.BackColor = Color.White;
                        txtNoidung3.BackColor = Color.White;
                        txtNoidung4.BackColor = Color.White;
                        txtSoQT.BackColor = Color.White;
                        txtModleCourse.BackColor = Color.White;
                        txtQuyDinh.BackColor = Color.White;
                        txtQuyDinhEng.BackColor = Color.White;
                        btnSave.Enabled = false;
                        btnEdit.Enabled = true;
                        btnNew.Enabled = true;
                        lookupFonsize_1.Enabled = false;
                        lookupFonsize_2.Enabled = false;
                        lookupFonsize_3.Enabled = false;
                        lookupFonsize_4.Enabled = false;
                    }
 
        }
        private void griVCoures_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            checkVisible(3);
         
            DataRow selectedRow = griVCoures.GetDataRow(griVCoures.FocusedRowHandle);
             mIdCcMh = int.Parse(selectedRow["CHC_ID"].ToString());
             sId = mIdCcMh;
            txtCode.Text = selectedRow["CHC_Code"].ToString();
            txtName.Text = selectedRow["CHC_Name"].ToString();
            txtNoidung1.Text = selectedRow["CHC_Content1"].ToString();
            txtNoidung2.Text = selectedRow["CHC_Content2"].ToString();
            txtNoidung3.Text = selectedRow["CHC_Content3"].ToString();
            txtNoidung4.Text = selectedRow["CHC_Content4"].ToString();
            txtSoQT.Text = selectedRow["CHC_QuyTac"].ToString();
            txtModleCourse.Text = selectedRow["CHC_ModleCode"].ToString();
            txtQuyDinh.Text = selectedRow["CHC_QuyDinh"].ToString();
            txtQuyDinhEng.Text = selectedRow["CHC_QuyDinhEngl"].ToString();

            for (int i = 0; i < boCc_Mh.getCC_MONHOC_All().Rows.Count; i++)
            {
                if (mIdCcMh == int.Parse( boCc_Mh.getCC_MONHOC_All().Rows[i]["CCM_CHCID"].ToString()))
                {
                    mIdCcMh = int.Parse( boCc_Mh.getCC_MONHOC_All().Rows[i]["CCM_CHCID"].ToString());
                }
            }
            listSubject.UnCheckAll();
            checkExits();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            checkVisible(2);
            sGeneralCode();
            txtName.Text = string.Empty;
            txtName.Focus();
            listSubject.UnCheckAll();
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string ccCode = string.Empty;
            int sCheckSave;
            ccCode = (txtCode.Text).Substring(3, 5);
            sCheckSave = int.Parse(ccCode.ToString());
            // check insert
            if (sCheckSave == sStatust + 1)
            {
                int sIndex =0;
                for (int i = 0; i < listSubject.ItemCount; i++)
                {
                    if (listSubject.GetItemChecked(i) == true)
                    {
                        sIndex++;
                    }
                }
                //call insert function 
                if (sIndex <= 0 || txtName.Text == string.Empty)
                {
                   
                        MessageBox.Show("Chưa nhập đầy đủ thông tin cho loại chứng chỉ", "THÔNG BÁO");
                        txtName.Focus();
		 
                }
                else
                {
                    if (sSaveData(1))
                    {
                        MessageBox.Show("Thêm loại chứng chỉ mới thành công", "THÔNG BÁO");
                    }
                    else
                    {
                        MessageBox.Show("Thêm loại chứng chỉ mới không thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    sGeneralCode();
                    txtName.Text = "";
                    sLoadSubject();
                    sShowData();
                }
               
            }
            else
                // check update
                if (sCheckSave == sStatust)
                {
                    // call update function
                    if (sSaveData(2))
                    {
                         MessageBox.Show("Cập nhật thông tin thành công", "THÔNG BÁO");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin không thành công", "THÔNG BÁO",MessageBoxButtons.OK, MessageBoxIcon.Warning);   
                    }
                   
                }
        }
        private void sGeneralCode()
        {
            DataTable tb = new DataTable();
            tb = boCc.getDsCHUNG_CHI_LastCode();
            string lCode = String.Empty;
            if (tb.Rows.Count == 0)
            {
                lCode = "000000";

            }
            else
            {
                lCode = tb.Rows[0]["CHC_Code"].ToString(); 
 
            }
            lCode = lCode.Substring(3, 5);
            txtCode.Text = ("CHC" + Utilities.quydinh.LaySTT(int.Parse(lCode.ToString()) + 1)).ToString();
            sStatust = int.Parse(lCode.ToString());
        }
        private Boolean sSaveData(int sCheck)
        {
            string sCode = string.Empty;
            string sName = string.Empty;
            string vNoidung1 = string.Empty;
            string vNoidung2 = string.Empty;
            string vNoidung3 = string.Empty;
            string vNoidung4 = string.Empty;
            string vQuyTac = string.Empty;
            string vModleCode = string.Empty;
            string vQuyDinh = string.Empty;
            string vQuyDinhEng = string.Empty;
            int vStatust = -1;

            sCode = txtCode.Text;
            sName = txtName.Text;
            vNoidung1 = txtNoidung1.Text;
            vNoidung2 = txtNoidung2.Text;
            vNoidung3 = txtNoidung3.Text;
            vNoidung4 = txtNoidung4.Text;
            vQuyTac = txtSoQT.Text;
            vModleCode = txtModleCourse.Text;
            vQuyDinh = txtQuyDinh.Text;
            vQuyDinhEng = txtQuyDinhEng.Text;

            if (lookLoaiCC.ItemIndex > -1)
            {
                vStatust = int.Parse(lookLoaiCC.GetColumnValue("LOA_ID").ToString());
            } 
            else
            {
                MessageBox.Show("Chưa chọn loại chứng chỉ","THÔNG BÁO",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (sCheck ==1)
            {
                boCc.insert(sCode, sName, vNoidung1, vNoidung2, vNoidung3, vNoidung4, vQuyTac, vModleCode, vStatust, vQuyDinh, vQuyDinhEng,6,6,6,6);
                for (int ii = 0; ii < listSubject.ItemCount; ii++)
                {
                    if (listSubject.GetItemChecked(ii))
                    {
                       
                        mcId = int.Parse(boCc.getNewCode().Rows[0]["CHC_ID"].ToString()); // Lay ID moi nhat cua table CHUNG_CHI
                        msbId = int.Parse(listSubject.GetItemValue(ii).ToString());
                        // Luu vao table CHUNG_CHI
                       
                        // Luu vao table CC_MONHOC
                        boCc_Mh.insert(msbId, mcId);
                    }
                }
                
             }
            else
            if (sCheck==2)
            {
                // Update tên chứng chỉ
                boCc.update(sCode, sName, vNoidung1, vNoidung2, vNoidung3, vNoidung4, vQuyTac, vModleCode, vStatust, mIdCcMh, vQuyDinh, vQuyDinhEng);
                // Delete cac ID mon hoc cu, insert id mon hoc moi.
                // Delete by chung chi Id
                boCc_Mh.delete_CC_MonHoc_byChcId(mIdCcMh);             
                // Update ( Insert moi ) vao table CC_MONHOC 
                for (int ik = 0; ik < listSubject.ItemCount; ik++)
                {
                    if (listSubject.GetItemChecked(ik))
                    {
                        mcId = int.Parse(boCc.getNewCode().Rows[0]["CHC_ID"].ToString()); // Lay ID moi nhat cua table CHUNG_CHI
                        msbId = int.Parse(listSubject.GetItemValue(ik).ToString());
                        boCc_Mh.insert(msbId, mIdCcMh);
                    }
                }
                
            }
            return true; 
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            checkVisible(2);
            sStatust = int.Parse( txtCode.Text.Substring(3,5).ToString());

        }
        private void sShowData()
        {
            gridCoures.DataSource = boCc.getChungChi_All();
        }
        private DataTable vLookupLoaiChungChi()
        {
            //-- Instantiate the data set and table
            DataTable vTable = new DataTable();
            //DataTable sTable = sDataset.Tables.Add("sSearchTable");

            //-- Add columns to the data table
            vTable.Columns.Add("LOA_ID", typeof(int));
            vTable.Columns.Add("LOA_Name", typeof(string));

            //-- Add rows to the data table
            vTable.Rows.Add(1, "Chứng chỉ huấn luyện cơ bản");
            vTable.Rows.Add(2, "Chứng chỉ huấn luyện nghiệp vụ");
            vTable.Rows.Add(3, "Chứng chỉ huấn luyện đặc biêt");
            vTable.Rows.Add(4, "Chứng chỉ khác");
            vTable.Rows.Add(5, "Chứng chỉ cập nhật");
            return vTable;

        }
        private void vLoadLoaiChungChi()
        {
            lookLoaiCC.Properties.DataSource = vLookupLoaiChungChi();
            lookLoaiCC.Properties.DisplayMember = "LOA_Name";
            lookLoaiCC.Properties.ValueMember = "LOA_ID";
        }
        private void lookLoaiCC_EditValueChanged(object sender, EventArgs e)
        {
            //// Kiểm tra để hiển thị filed đúng
            //if (lookLoaiCC.ItemIndex==3)
            //{
            //    txtSoQT.Enabled = false;
            //    txtQuyDinh.Enabled = true;
            //    txtQuyDinhEng.Enabled = true;
            //}
            //if (lookLoaiCC.ItemIndex==2)
            //{
                
            //}
        }
        private void btnF_1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            //Get Id Font by FON_Content
            string vString = "Content_1";
            int vFontID = int.Parse( boCc_Mh.getFont_ID(vString).Rows[0]["FON_ID"].ToString());
            // Update font size 
            boCc_Mh.Update_font(vFontID, 1, fontDialog1.Font.Name.ToString(), int.Parse(fontDialog1.Font.Size.ToString()), vString);


        }
        private DataTable vLookupFontSize()
        {
            //-- Instantiate the data set and table
            DataTable vTable = new DataTable();
            //-- Add columns to the data table
            vTable.Columns.Add("FON_ID", typeof(int));
            vTable.Columns.Add("FON_FontSize", typeof(string));

            //-- Add rows to the data table
            vTable.Rows.Add(1, "1");
            vTable.Rows.Add(2, "2");
            vTable.Rows.Add(3, "3");
            vTable.Rows.Add(4, "4");
            vTable.Rows.Add(5, "5");
            vTable.Rows.Add(6, "6");
            vTable.Rows.Add(7, "7");
            vTable.Rows.Add(8, "8");
            vTable.Rows.Add(9, "9");
            vTable.Rows.Add(10, "10");
           
            return vTable;

        }
        private void vLookupFontSize_1()
        {
            lookupFonsize_1.Properties.DataSource = vLookupFontSize();
            lookupFonsize_1.Properties.ValueMember = "FON_ID";
            lookupFonsize_1.Properties.DisplayMember = "FON_FontSize";
        }
        private void vLookupFontSize_2()
        {
            lookupFonsize_2.Properties.DataSource = vLookupFontSize();
            lookupFonsize_2.Properties.ValueMember = "FON_ID";
            lookupFonsize_2.Properties.DisplayMember = "FON_FontSize";
        }
        private void vLookupFontSize_3()
        {
            lookupFonsize_3.Properties.DataSource = vLookupFontSize();
            lookupFonsize_3.Properties.ValueMember = "FON_ID";
            lookupFonsize_3.Properties.DisplayMember = "FON_FontSize";
        }
        private void vLookupFontSize_4()
        {
            lookupFonsize_4.Properties.DataSource = vLookupFontSize();
            lookupFonsize_4.Properties.ValueMember = "FON_ID";
            lookupFonsize_4.Properties.DisplayMember = "FON_FontSize";
        }
        private void vUpdate_FontSize_1( int vCcID, int vFontSize)
        {
            
            boCc.vUpdate_Fontsize_1(vCcID, vFontSize);
 
        }
        private void vUpdate_FontSize_2(int vCcID, int vFontSize)
        {
            
            boCc.vUpdate_Fontsize_2(vCcID, vFontSize);

        }
        private void vUpdate_FontSize_3(int vCcID, int vFontSize)
        {
            boCc.vUpdate_Fontsize_3(vCcID, vFontSize);

        }
        private void vUpdate_FontSize_4(int vCcID, int vFontSize)
        {
            vCcID = mIdCcMh;
            vFontSize = int.Parse(lookupFonsize_4.GetColumnValue("FON_FontSize").ToString());
            boCc.vUpdate_Fontsize_4(vCcID, vFontSize);

        }
        private void lookupFonsize_1_EditValueChanged(object sender, EventArgs e)
        {
             mCcID = mIdCcMh;
             if (lookupFonsize_1.GetColumnValue("FON_FontSize").ToString() != "")
             {
                 mFontSize = int.Parse(lookupFonsize_1.GetColumnValue("FON_FontSize").ToString());
             }
             else
             {
                 MessageBox.Show("Chưa chọn kích thước cho nội dung","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                 return;
             }
             
            vUpdate_FontSize_1(mCcID, mFontSize);
        }
        private void lookupFonsize_2_EditValueChanged(object sender, EventArgs e)
        {
            mCcID = mIdCcMh;
            if (lookupFonsize_2.GetColumnValue("FON_FontSize").ToString() != "")
            {
                mFontSize = int.Parse(lookupFonsize_2.GetColumnValue("FON_FontSize").ToString());
            }
            else
            {
                MessageBox.Show("Chưa chọn kích thước cho nội dung", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            vUpdate_FontSize_2(mCcID, mFontSize);
        }
        private void lookupFonsize_3_EditValueChanged(object sender, EventArgs e)
        {
            mCcID = mIdCcMh;
            if (lookupFonsize_3.GetColumnValue("FON_FontSize").ToString() != "")
            {
                mFontSize = int.Parse(lookupFonsize_3.GetColumnValue("FON_FontSize").ToString());
            }
            else
            {
                MessageBox.Show("Chưa chọn kích thước cho nội dung", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            vUpdate_FontSize_3(mCcID, mFontSize);
        }
        private void lookupFonsize_4_EditValueChanged(object sender, EventArgs e)
        {
            mCcID = mIdCcMh;
            if (lookupFonsize_4.GetColumnValue("FON_FontSize").ToString() != "")
            {
                mFontSize = int.Parse(lookupFonsize_4.GetColumnValue("FON_FontSize").ToString());
            }
            else
            {
                MessageBox.Show("Chưa chọn kích thước cho nội dung", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            vUpdate_FontSize_4(mCcID, mFontSize);
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}