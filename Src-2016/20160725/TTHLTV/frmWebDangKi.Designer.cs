namespace TTHLTV
{
    partial class frmWebDangKi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebDangKi));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnMoveStudents = new DevExpress.XtraEditors.SimpleButton();
            this.cklWebDkh = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnUpdateStatus = new DevExpress.XtraEditors.SimpleButton();
            this.grdWebListHocVien = new DevExpress.XtraGrid.GridControl();
            this.grvWebListHocVien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DKW_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DKW_FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DKW_LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DKW_Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DKW_NgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DKW_Email = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cklWebDkh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWebListHocVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWebListHocVien)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1118, 481);
            this.splitContainer1.SplitterDistance = 496;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnMoveStudents);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cklWebDkh);
            this.splitContainer2.Size = new System.Drawing.Size(496, 481);
            this.splitContainer2.SplitterDistance = 66;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnMoveStudents
            // 
            this.btnMoveStudents.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnMoveStudents.Appearance.Options.UseFont = true;
            this.btnMoveStudents.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveStudents.Image")));
            this.btnMoveStudents.Location = new System.Drawing.Point(50, 21);
            this.btnMoveStudents.Name = "btnMoveStudents";
            this.btnMoveStudents.Size = new System.Drawing.Size(208, 35);
            this.btnMoveStudents.TabIndex = 8;
            this.btnMoveStudents.Text = "Đăng kí học viên vào lớp";
            this.btnMoveStudents.Click += new System.EventHandler(this.btnMoveStudents_Click);
            // 
            // cklWebDkh
            // 
            this.cklWebDkh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cklWebDkh.Appearance.Options.UseFont = true;
            this.cklWebDkh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cklWebDkh.Location = new System.Drawing.Point(0, 0);
            this.cklWebDkh.Name = "cklWebDkh";
            this.cklWebDkh.Size = new System.Drawing.Size(496, 411);
            this.cklWebDkh.TabIndex = 3;
            this.cklWebDkh.Click += new System.EventHandler(this.cklWebDkh_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnUpdateStatus);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.grdWebListHocVien);
            this.splitContainer3.Size = new System.Drawing.Size(618, 481);
            this.splitContainer3.SplitterDistance = 65;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnUpdateStatus.Appearance.Options.UseFont = true;
            this.btnUpdateStatus.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateStatus.Image")));
            this.btnUpdateStatus.Location = new System.Drawing.Point(34, 21);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(246, 35);
            this.btnUpdateStatus.TabIndex = 15;
            this.btnUpdateStatus.Text = "Cập nhật trạng thái đã gọi điện";
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // grdWebListHocVien
            // 
            this.grdWebListHocVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWebListHocVien.Location = new System.Drawing.Point(0, 0);
            this.grdWebListHocVien.MainView = this.grvWebListHocVien;
            this.grdWebListHocVien.Name = "grdWebListHocVien";
            this.grdWebListHocVien.Size = new System.Drawing.Size(618, 412);
            this.grdWebListHocVien.TabIndex = 0;
            this.grdWebListHocVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWebListHocVien});
            // 
            // grvWebListHocVien
            // 
            this.grvWebListHocVien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.DKW_ID,
            this.DKW_FirstName,
            this.DKW_LastName,
            this.DKW_Phone,
            this.DKW_NgaySinh,
            this.DKW_Email});
            this.grvWebListHocVien.GridControl = this.grdWebListHocVien;
            this.grvWebListHocVien.Name = "grvWebListHocVien";
            // 
            // DKW_ID
            // 
            this.DKW_ID.Caption = "ID";
            this.DKW_ID.FieldName = "DKW_ID";
            this.DKW_ID.Name = "DKW_ID";
            // 
            // DKW_FirstName
            // 
            this.DKW_FirstName.Caption = "Họ";
            this.DKW_FirstName.FieldName = "DKW_FirstName";
            this.DKW_FirstName.Name = "DKW_FirstName";
            this.DKW_FirstName.Visible = true;
            this.DKW_FirstName.VisibleIndex = 0;
            // 
            // DKW_LastName
            // 
            this.DKW_LastName.Caption = "Tên";
            this.DKW_LastName.FieldName = "DKW_LastName";
            this.DKW_LastName.Name = "DKW_LastName";
            this.DKW_LastName.Visible = true;
            this.DKW_LastName.VisibleIndex = 1;
            // 
            // DKW_Phone
            // 
            this.DKW_Phone.Caption = "Điện thoại";
            this.DKW_Phone.FieldName = "DKW_Phone";
            this.DKW_Phone.Name = "DKW_Phone";
            this.DKW_Phone.Visible = true;
            this.DKW_Phone.VisibleIndex = 2;
            // 
            // DKW_NgaySinh
            // 
            this.DKW_NgaySinh.Caption = "Ngày sinh";
            this.DKW_NgaySinh.FieldName = "DKW_NgaySinh";
            this.DKW_NgaySinh.Name = "DKW_NgaySinh";
            this.DKW_NgaySinh.Visible = true;
            this.DKW_NgaySinh.VisibleIndex = 3;
            // 
            // DKW_Email
            // 
            this.DKW_Email.Caption = "Email";
            this.DKW_Email.FieldName = "DKW_Email";
            this.DKW_Email.Name = "DKW_Email";
            this.DKW_Email.Visible = true;
            this.DKW_Email.VisibleIndex = 4;
            // 
            // frmWebDangKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 481);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmWebDangKi";
            this.Text = "frmWebDangKi";
            this.Load += new System.EventHandler(this.frmWebDangKi_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cklWebDkh)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWebListHocVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWebListHocVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private DevExpress.XtraGrid.GridControl grdWebListHocVien;
        private DevExpress.XtraGrid.Views.Grid.GridView grvWebListHocVien;
        private DevExpress.XtraEditors.CheckedListBoxControl cklWebDkh;
        private DevExpress.XtraGrid.Columns.GridColumn DKW_ID;
        private DevExpress.XtraGrid.Columns.GridColumn DKW_FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn DKW_LastName;
        private DevExpress.XtraGrid.Columns.GridColumn DKW_Phone;
        private DevExpress.XtraGrid.Columns.GridColumn DKW_NgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn DKW_Email;
        private DevExpress.XtraEditors.SimpleButton btnUpdateStatus;
        private DevExpress.XtraEditors.SimpleButton btnMoveStudents;

    }
}