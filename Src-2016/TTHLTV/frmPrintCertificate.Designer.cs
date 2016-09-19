namespace TTHLTV
{
    partial class frmPrintCertificate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintCertificate));
            this.gridCertificate = new DevExpress.XtraGrid.GridControl();
            this.gridContentCertificate = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookLanThi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpSoHieuDoi = new DevExpress.XtraEditors.LookUpEdit();
            this.lookLopHoc = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lookChungChi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.radCapQ = new DevExpress.XtraEditors.RadioGroup();
            this.txtDateExpire = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnInGCN = new DevExpress.XtraEditors.SimpleButton();
            this.txtDateAllocate = new DevExpress.XtraEditors.TextEdit();
            this.rdMatIn = new DevExpress.XtraEditors.RadioGroup();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContentCertificate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLanThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSoHieuDoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLopHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChungChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCapQ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateExpire.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAllocate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdMatIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridCertificate
            // 
            this.gridCertificate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCertificate.Location = new System.Drawing.Point(0, 0);
            this.gridCertificate.MainView = this.gridContentCertificate;
            this.gridCertificate.Name = "gridCertificate";
            this.gridCertificate.Size = new System.Drawing.Size(1036, 312);
            this.gridCertificate.TabIndex = 3;
            this.gridCertificate.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridContentCertificate});
            // 
            // gridContentCertificate
            // 
            this.gridContentCertificate.GridControl = this.gridCertificate;
            this.gridContentCertificate.Name = "gridContentCertificate";
            // 
            // btnIn
            // 
            this.btnIn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.Location = new System.Drawing.Point(350, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(131, 35);
            this.btnIn.TabIndex = 11;
            this.btnIn.Text = "In chứng chỉ";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.groupControl2);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(1036, 115);
            this.splitContainerControl2.SplitterPosition = 437;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookLanThi);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.lookUpSoHieuDoi);
            this.groupControl1.Controls.Add(this.lookLopHoc);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.lookChungChi);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(437, 115);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thông tin lớp học ";
            // 
            // lookLanThi
            // 
            this.lookLanThi.Location = new System.Drawing.Point(109, 84);
            this.lookLanThi.Name = "lookLanThi";
            this.lookLanThi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lookLanThi.Properties.Appearance.Options.UseFont = true;
            this.lookLanThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLanThi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DIE_LanThi", "Lần thi")});
            this.lookLanThi.Properties.NullText = "";
            this.lookLanThi.Size = new System.Drawing.Size(97, 24);
            this.lookLanThi.TabIndex = 99;
            this.lookLanThi.EditValueChanged += new System.EventHandler(this.lookLanThi_EditValueChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(36, 87);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(43, 18);
            this.labelControl9.TabIndex = 98;
            this.labelControl9.Text = "Lần thi";
            // 
            // lookUpSoHieuDoi
            // 
            this.lookUpSoHieuDoi.Location = new System.Drawing.Point(109, 54);
            this.lookUpSoHieuDoi.Name = "lookUpSoHieuDoi";
            this.lookUpSoHieuDoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lookUpSoHieuDoi.Properties.Appearance.Options.UseFont = true;
            this.lookUpSoHieuDoi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpSoHieuDoi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CCC_SoHieuDoi", "Số hiệu")});
            this.lookUpSoHieuDoi.Properties.NullText = "Chọn số hiệu đổi";
            this.lookUpSoHieuDoi.Size = new System.Drawing.Size(323, 24);
            this.lookUpSoHieuDoi.TabIndex = 97;
            this.lookUpSoHieuDoi.EditValueChanged += new System.EventHandler(this.lookUpSoHieuDoi_EditValueChanged);
            // 
            // lookLopHoc
            // 
            this.lookLopHoc.Location = new System.Drawing.Point(109, 54);
            this.lookLopHoc.Name = "lookLopHoc";
            this.lookLopHoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lookLopHoc.Properties.Appearance.Options.UseFont = true;
            this.lookLopHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLopHoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LOP_Name", "Tên lớp")});
            this.lookLopHoc.Properties.NullText = "Chọn lớp học";
            this.lookLopHoc.Size = new System.Drawing.Size(323, 24);
            this.lookLopHoc.TabIndex = 91;
            this.lookLopHoc.EditValueChanged += new System.EventHandler(this.lookLopHoc_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(7, 27);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(92, 18);
            this.labelControl8.TabIndex = 93;
            this.labelControl8.Text = "Loại chứng chỉ";
            // 
            // lookChungChi
            // 
            this.lookChungChi.Location = new System.Drawing.Point(109, 24);
            this.lookChungChi.Name = "lookChungChi";
            this.lookChungChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lookChungChi.Properties.Appearance.Options.UseFont = true;
            this.lookChungChi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookChungChi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CHC_Name", "Tên chứng chỉ")});
            this.lookChungChi.Properties.NullText = "Chọn chứng chỉ";
            this.lookChungChi.Size = new System.Drawing.Size(323, 24);
            this.lookChungChi.TabIndex = 90;
            this.lookChungChi.EditValueChanged += new System.EventHandler(this.lookChungChi_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(7, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 18);
            this.labelControl2.TabIndex = 92;
            this.labelControl2.Text = "Tên  lớp";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.radCapQ);
            this.groupControl2.Controls.Add(this.txtDateExpire);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.btnInGCN);
            this.groupControl2.Controls.Add(this.txtDateAllocate);
            this.groupControl2.Controls.Add(this.rdMatIn);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(593, 115);
            this.groupControl2.TabIndex = 2;
            // 
            // radCapQ
            // 
            this.radCapQ.Location = new System.Drawing.Point(5, 25);
            this.radCapQ.Name = "radCapQ";
            this.radCapQ.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.radCapQ.Properties.Appearance.Options.UseFont = true;
            this.radCapQ.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Cấp mới"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Cấp lại"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Cấp đổi")});
            this.radCapQ.Size = new System.Drawing.Size(100, 69);
            this.radCapQ.TabIndex = 6;
            this.radCapQ.SelectedIndexChanged += new System.EventHandler(this.radCapQ_SelectedIndexChanged);
            // 
            // txtDateExpire
            // 
            this.txtDateExpire.EditValue = "";
            this.txtDateExpire.Enabled = false;
            this.txtDateExpire.Location = new System.Drawing.Point(396, 86);
            this.txtDateExpire.Name = "txtDateExpire";
            this.txtDateExpire.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtDateExpire.Properties.Appearance.Options.UseFont = true;
            this.txtDateExpire.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtDateExpire.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtDateExpire.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateExpire.Size = new System.Drawing.Size(148, 24);
            this.txtDateExpire.TabIndex = 95;
            this.txtDateExpire.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(119, 88);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(62, 18);
            this.labelControl5.TabIndex = 96;
            this.labelControl5.Text = "Thời hạn ";
            this.labelControl5.Visible = false;
            // 
            // btnInGCN
            // 
            this.btnInGCN.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnInGCN.Appearance.Options.UseFont = true;
            this.btnInGCN.Location = new System.Drawing.Point(270, 27);
            this.btnInGCN.Name = "btnInGCN";
            this.btnInGCN.Size = new System.Drawing.Size(25, 23);
            this.btnInGCN.TabIndex = 5;
            this.btnInGCN.Text = "In";
            this.btnInGCN.Visible = false;
            this.btnInGCN.Click += new System.EventHandler(this.btnInGCN_Click);
            // 
            // txtDateAllocate
            // 
            this.txtDateAllocate.EditValue = "";
            this.txtDateAllocate.Enabled = false;
            this.txtDateAllocate.Location = new System.Drawing.Point(221, 86);
            this.txtDateAllocate.Name = "txtDateAllocate";
            this.txtDateAllocate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtDateAllocate.Properties.Appearance.Options.UseFont = true;
            this.txtDateAllocate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtDateAllocate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtDateAllocate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.txtDateAllocate.Size = new System.Drawing.Size(153, 24);
            this.txtDateAllocate.TabIndex = 94;
            this.txtDateAllocate.Visible = false;
            // 
            // rdMatIn
            // 
            this.rdMatIn.Location = new System.Drawing.Point(117, 25);
            this.rdMatIn.Name = "rdMatIn";
            this.rdMatIn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rdMatIn.Properties.Appearance.Options.UseFont = true;
            this.rdMatIn.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Mặt trong"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Mặt ngoài")});
            this.rdMatIn.Size = new System.Drawing.Size(100, 50);
            this.rdMatIn.TabIndex = 4;
            this.rdMatIn.SelectedIndexChanged += new System.EventHandler(this.rdMatIn_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.Enabled = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageIndex = 0;
            this.btnNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(3, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(115, 35);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "Thêm mới";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 39);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridCertificate);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1036, 433);
            this.splitContainerControl1.SplitterPosition = 115;
            this.splitContainerControl1.TabIndex = 44;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(266, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 35);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.btnIn);
            this.panelControl2.Controls.Add(this.btnNew);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnEdit);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1036, 39);
            this.panelControl2.TabIndex = 43;
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(486, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 35);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(122, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(140, 35);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Sửa thông tin";
            // 
            // frmPrintCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 472);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.panelControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrintCertificate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IN GIẤY CHƯNG NHẬN ";
            this.Load += new System.EventHandler(this.frmPrintCertificate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContentCertificate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLanThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpSoHieuDoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookLopHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChungChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCapQ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateExpire.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAllocate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdMatIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridCertificate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridContentCertificate;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnInGCN;
        private DevExpress.XtraEditors.RadioGroup rdMatIn;
        private DevExpress.XtraEditors.TextEdit txtDateExpire;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtDateAllocate;
        private DevExpress.XtraEditors.LookUpEdit lookLopHoc;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit lookChungChi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup radCapQ;
        private DevExpress.XtraEditors.LookUpEdit lookUpSoHieuDoi;
        private DevExpress.XtraEditors.LookUpEdit lookLanThi;
        private DevExpress.XtraEditors.LabelControl labelControl9;
    }
}