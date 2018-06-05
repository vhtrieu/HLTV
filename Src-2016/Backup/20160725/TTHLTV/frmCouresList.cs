﻿using System;
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
//using Entetities;

namespace TTHLTV
{
    public partial class frmCouresList : DevExpress.XtraEditors.XtraForm
    {
       
        public frmCouresList()
        {
            InitializeComponent();
        }

        #region Variable
        BO_CHUNG_CHI boCc = new BO_CHUNG_CHI();
        
        #endregion

        #region Events

        private void frmCouresList_Load(object sender, EventArgs e)
        {
            this.Refresh();
            LoadCourses();
            SetGridFont(gridCoures.MainView, new Font("Tahoma", 11));

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
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            SimpleButton btnAddNews = (SimpleButton)sender;
            frmAddNewCoures frmAddCoures = new frmAddNewCoures();
            frmAddCoures.btnSender = btnAddNews.Text;

            frmAddCoures.sGridIndexCoures = gvCourses.RowCount + 1;
            DialogResult result = frmAddCoures.ShowDialog();
            LoadCourses();
           
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCourses();
            clearInputData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = gvCourses.GetDataRow(gvCourses.FocusedRowHandle);
            if (selectedRow!=null)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa khóa học này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = int.Parse(selectedRow["CHC_ID"].ToString());
                    selectedRow.Delete();
                    boCc.delete(id);
                    LoadCourses();
                } 
            }
            
        }

        private void gvCourses_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView btnDetails = (DevExpress.XtraGrid.Views.Grid.GridView)sender;

            //frmAddNewCoures frmAddCoures = new frmAddNewCoures();
            ////frmAddCoures.btnSender = btnDetails.Text;
            //DataRow selectedRow = gvCourses.GetDataRow(gvCourses.FocusedRowHandle);
            //string Codes = selectedRow["CHC_Code"].ToString();
            //string Names = selectedRow["CHC_Name"].ToString();
            //int ids = int.Parse(selectedRow["CHC_ID"].ToString());
            //frmAddCoures.sCode = Codes;
            //frmAddCoures.sName = Names;
            //frmAddCoures.sId = ids;
            ////frmAddCoures.ShowDialog();
            //DialogResult result = frmAddCoures.ShowDialog();
            //LoadCourses();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = gvCourses.GetDataRow(gvCourses.FocusedRowHandle);
            //courseDTO = new ENT_Courses();
            //courseDTO.COU_ID = int.Parse(selectedRow["COU_ID"].ToString());
            //courseDTO.COU_Name = txtName.Text;
            //courseDTO.COU_Code = txtCode.Text;
            //courseDTO.COU_CourseTime = int.Parse(txtCourseTime.Text);
            //courseDTO.COU_BeginTime = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", deStartDay.Text));
            //courseDTO.COU_EndTime = DateTime.Parse(String.Format("{0:yyyy/MM/dd}", dateEndDay.Text));
            //courseDTO.COU_Subjects = txtSubject.Text;
            //courseDTO.COU_Fee = long.Parse(txtTrainingFee.Text);
            //courseCtl.updateCourse(courseDTO);
            LoadCourses();

        }
        #endregion

        #region Extenal Functions

        private void SetGridFont(DevExpress.XtraGrid.Views.Base.BaseView baseView, Font sFont)
        {
            foreach (AppearanceObject ap in baseView.Appearance)
            {
                ap.Font = sFont;
            }

        }
       public void LoadCourses()
        {
            gridCoures.DataSource = boCc.getChungChi_All();
        }
        void clearInputData()
        {
            txtCode.Text = string.Empty;
            txtCourseTime.Text = string.Empty;
            txtName.Text = string.Empty;
            txtTrainingFee.Text = string.Empty;
            dateEndDay.Text = string.Empty;
            deStartDay.Text = string.Empty;
            txtSubject.Text = string.Empty;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
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
            sTable.Rows.Add(1, "Tên khóa học");
            sTable.Rows.Add(2, "Mã mã khóa học");
            //sTable.Rows.Add(3, "Khóa học");

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

        private void btnDetail_Click(object sender, EventArgs e)
        {

            SimpleButton btnDetails = (SimpleButton)sender;

            frmAddNewCoures frmAddCoures = new frmAddNewCoures();
            frmAddCoures.btnSender = btnDetails.Text;
            DataRow selectedRow = gvCourses.GetDataRow(gvCourses.FocusedRowHandle);
            string Codes = selectedRow["CHC_Code"].ToString();
            string Names = selectedRow["CHC_Name"].ToString();
            int ids = int.Parse(selectedRow["CHC_ID"].ToString());
            frmAddCoures.sCode = Codes;
            frmAddCoures.sName = Names;
            frmAddCoures.sId = ids;
            DialogResult result = frmAddCoures.ShowDialog();
            LoadCourses();
        }

        private void gvCourses_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView btnDetails = (DevExpress.XtraGrid.Views.Grid.GridView)sender;

            frmAddNewCoures frmAddCoures = new frmAddNewCoures();
            frmAddCoures.btnSender = btnDetails.Appearance.ViewCaption.ToString();
            DataRow selectedRow = gvCourses.GetDataRow(gvCourses.FocusedRowHandle);
            string Codes = selectedRow["CHC_Code"].ToString();
            string Names = selectedRow["CHC_Name"].ToString();
            int ids = int.Parse(selectedRow["CHC_ID"].ToString());
            frmAddCoures.sCode = Codes;
            frmAddCoures.sName = Names;
            frmAddCoures.sId = ids;
            //frmAddCoures.ShowDialog();
            DialogResult result = frmAddCoures.ShowDialog();
            LoadCourses();
        }


       

    }
}