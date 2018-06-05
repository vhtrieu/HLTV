namespace TTHLTV
{
    partial class frmCertification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCertification));
            this.gridCertificate = new DevExpress.XtraGrid.GridControl();
            this.gridContentCertificate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStudentBirthDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCerificateName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayDoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayHetHan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookSearchBy = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNew = new DevExpress.XtraEditors.SimpleButton();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.grpDetailTeacher = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.txtCertificateName = new DevExpress.XtraEditors.TextEdit();
            this.txtCertifiCateCode = new DevExpress.XtraEditors.TextEdit();
            this.txtCouresName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lookCondition = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearchText = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContentCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookSearchBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpDetailTeacher)).BeginInit();
            this.grpDetailTeacher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCertificateName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCertifiCateCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCouresName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCondition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridCertificate
            // 
            this.gridCertificate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCertificate.Location = new System.Drawing.Point(2, 2);
            this.gridCertificate.MainView = this.gridContentCertificate;
            this.gridCertificate.Name = "gridCertificate";
            this.gridCertificate.Size = new System.Drawing.Size(830, 356);
            this.gridCertificate.TabIndex = 2;
            this.gridCertificate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridContentCertificate});
            // 
            // gridContentCertificate
            // 
            this.gridContentCertificate.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colFirstName,
            this.colLastName,
            this.colStudentBirthDay,
            this.colSoCC,
            this.colCerificateName,
            this.colClassName,
            this.colNgayCap,
            this.colNgayDoi,
            this.colNgayHetHan});
            this.gridContentCertificate.GridControl = this.gridCertificate;
            this.gridContentCertificate.Name = "gridContentCertificate";
            this.gridContentCertificate.OptionsBehavior.ReadOnly = true;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.Name = "colID";
            // 
            // colFirstName
            // 
            this.colFirstName.Caption = "Họ & Tên đệm";
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 0;
            this.colFirstName.Width = 100;
            // 
            // colLastName
            // 
            this.colLastName.Caption = "Tên";
            this.colLastName.FieldName = "LastName";
            this.colLastName.Name = "colLastName";
            this.colLastName.Visible = true;
            this.colLastName.VisibleIndex = 1;
            this.colLastName.Width = 40;
            // 
            // colStudentBirthDay
            // 
            this.colStudentBirthDay.AppearanceHeader.Options.UseTextOptions = true;
            this.colStudentBirthDay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colStudentBirthDay.Caption = "Ngày sinh";
            this.colStudentBirthDay.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colStudentBirthDay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStudentBirthDay.FieldName = "BirthDay";
            this.colStudentBirthDay.Name = "colStudentBirthDay";
            this.colStudentBirthDay.Visible = true;
            this.colStudentBirthDay.VisibleIndex = 2;
            this.colStudentBirthDay.Width = 63;
            // 
            // colSoCC
            // 
            this.colSoCC.Caption = "Số chứng chỉ";
            this.colSoCC.FieldName = "SoCC";
            this.colSoCC.Name = "colSoCC";
            this.colSoCC.Visible = true;
            this.colSoCC.VisibleIndex = 3;
            this.colSoCC.Width = 90;
            // 
            // colCerificateName
            // 
            this.colCerificateName.Caption = "Tên chứng chỉ";
            this.colCerificateName.FieldName = "TenCC";
            this.colCerificateName.Name = "colCerificateName";
            this.colCerificateName.Visible = true;
            this.colCerificateName.VisibleIndex = 4;
            this.colCerificateName.Width = 130;
            // 
            // colClassName
            // 
            this.colClassName.Caption = "Tên lớp học";
            this.colClassName.FieldName = "ClassName";
            this.colClassName.Name = "colClassName";
            this.colClassName.Visible = true;
            this.colClassName.VisibleIndex = 5;
            this.colClassName.Width = 170;
            // 
            // colNgayCap
            // 
            this.colNgayCap.Caption = "Ngày cấp";
            this.colNgayCap.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayCap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayCap.FieldName = "NgayCap";
            this.colNgayCap.Name = "colNgayCap";
            this.colNgayCap.Visible = true;
            this.colNgayCap.VisibleIndex = 6;
            this.colNgayCap.Width = 63;
            // 
            // colNgayDoi
            // 
            this.colNgayDoi.Caption = "Ngày đổi";
            this.colNgayDoi.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayDoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayDoi.FieldName = "NgayDoi";
            this.colNgayDoi.Name = "colNgayDoi";
            this.colNgayDoi.Visible = true;
            this.colNgayDoi.VisibleIndex = 7;
            this.colNgayDoi.Width = 63;
            // 
            // colNgayHetHan
            // 
            this.colNgayHetHan.Caption = "Ngày hết hạn";
            this.colNgayHetHan.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colNgayHetHan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayHetHan.FieldName = "NgayHetHan";
            this.colNgayHetHan.Name = "colNgayHetHan";
            this.colNgayHetHan.Visible = true;
            this.colNgayHetHan.VisibleIndex = 8;
            this.colNgayHetHan.Width = 90;
            // 
            // lookSearchBy
            // 
            this.lookSearchBy.Location = new System.Drawing.Point(86, 4);
            this.lookSearchBy.Name = "lookSearchBy";
            this.lookSearchBy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lookSearchBy.Properties.Appearance.Options.UseFont = true;
            this.lookSearchBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookSearchBy.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tìm kiếm theo")});
            this.lookSearchBy.Size = new System.Drawing.Size(149, 23);
            this.lookSearchBy.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(444, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(141, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm tươi dữ liệu";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(368, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(9, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 18);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Tìm kiếm";
            // 
            // btnDetail
            // 
            this.btnDetail.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnDetail.Appearance.Options.UseFont = true;
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.Location = new System.Drawing.Point(244, 2);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(119, 30);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "Xem chi tiết";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnAddNew.Appearance.Options.UseFont = true;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(5, 2);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(100, 30);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Cấp mới";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 197;
            this.navBarControl1.Size = new System.Drawing.Size(0, 0);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "navBarItem1";
            this.navBarItem1.Name = "navBarItem1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.grpDetailTeacher);
            this.splitContainerControl1.Panel1.Controls.Add(this.navBarControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(844, 451);
            this.splitContainerControl1.SplitterPosition = 0;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // grpDetailTeacher
            // 
            this.grpDetailTeacher.Controls.Add(this.btnCancel);
            this.grpDetailTeacher.Controls.Add(this.btnSave);
            this.grpDetailTeacher.Controls.Add(this.btnEdit);
            this.grpDetailTeacher.Controls.Add(this.txtCertificateName);
            this.grpDetailTeacher.Controls.Add(this.txtCertifiCateCode);
            this.grpDetailTeacher.Controls.Add(this.txtCouresName);
            this.grpDetailTeacher.Controls.Add(this.labelControl3);
            this.grpDetailTeacher.Controls.Add(this.labelControl6);
            this.grpDetailTeacher.Controls.Add(this.labelControl1);
            this.grpDetailTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetailTeacher.Location = new System.Drawing.Point(0, 0);
            this.grpDetailTeacher.Name = "grpDetailTeacher";
            this.grpDetailTeacher.Size = new System.Drawing.Size(0, 0);
            this.grpDetailTeacher.TabIndex = 1;
            this.grpDetailTeacher.Text = "Chi tiết thông tin chứng chỉ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(162, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Bỏ qua";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(11, 180);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(70, 30);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Sữa";
            // 
            // txtCertificateName
            // 
            this.txtCertificateName.Location = new System.Drawing.Point(86, 102);
            this.txtCertificateName.Name = "txtCertificateName";
            this.txtCertificateName.Size = new System.Drawing.Size(139, 20);
            this.txtCertificateName.TabIndex = 6;
            // 
            // txtCertifiCateCode
            // 
            this.txtCertifiCateCode.Location = new System.Drawing.Point(86, 37);
            this.txtCertifiCateCode.Name = "txtCertifiCateCode";
            this.txtCertifiCateCode.Size = new System.Drawing.Size(139, 20);
            this.txtCertifiCateCode.TabIndex = 4;
            // 
            // txtCouresName
            // 
            this.txtCouresName.Location = new System.Drawing.Point(86, 71);
            this.txtCouresName.Name = "txtCouresName";
            this.txtCouresName.Size = new System.Drawing.Size(139, 20);
            this.txtCouresName.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 83);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tên chứng chỉ";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(6, 18);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(63, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Mã chứng chỉ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Khóa học";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panelControl3);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(838, 451);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách chứng chỉ";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridCertificate);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(2, 89);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(834, 360);
            this.panelControl3.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lookCondition);
            this.panelControl2.Controls.Add(this.lookSearchBy);
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Controls.Add(this.txtSearchText);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 57);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(834, 32);
            this.panelControl2.TabIndex = 3;
            // 
            // lookCondition
            // 
            this.lookCondition.Location = new System.Drawing.Point(240, 4);
            this.lookCondition.Name = "lookCondition";
            this.lookCondition.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lookCondition.Properties.Appearance.Options.UseFont = true;
            this.lookCondition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookCondition.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Giá trị tìm kiếm")});
            this.lookCondition.Size = new System.Drawing.Size(129, 23);
            this.lookCondition.TabIndex = 9;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(547, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(42, 30);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchText
            // 
            this.txtSearchText.Location = new System.Drawing.Point(375, 3);
            this.txtSearchText.Name = "txtSearchText";
            this.txtSearchText.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtSearchText.Properties.Appearance.Options.UseFont = true;
            this.txtSearchText.Size = new System.Drawing.Size(166, 24);
            this.txtSearchText.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnDetail);
            this.panelControl1.Controls.Add(this.btnAddNew);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 22);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(834, 35);
            this.panelControl1.TabIndex = 2;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(110, 1);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(130, 30);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Đổi chứng chỉ";
            // 
            // frmCertification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 451);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmCertification";
            this.Text = "CẤP CHỨNG CHỈ";
            this.Load += new System.EventHandler(this.frmCertification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContentCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookSearchBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpDetailTeacher)).EndInit();
            this.grpDetailTeacher.ResumeLayout(false);
            this.grpDetailTeacher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCertificateName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCertifiCateCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCouresName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookCondition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridCertificate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridContentCertificate;
        private DevExpress.XtraEditors.LookUpEdit lookSearchBy;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnDetail;
        private DevExpress.XtraEditors.SimpleButton btnAddNew;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl grpDetailTeacher;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.TextEdit txtCertificateName;
        private DevExpress.XtraEditors.TextEdit txtCertifiCateCode;
        private DevExpress.XtraEditors.TextEdit txtCouresName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookCondition;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtSearchText;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn colLastName;
        private DevExpress.XtraGrid.Columns.GridColumn colStudentBirthDay;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCC;
        private DevExpress.XtraGrid.Columns.GridColumn colCerificateName;
        private DevExpress.XtraGrid.Columns.GridColumn colClassName;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayCap;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayDoi;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayHetHan;
    }
}