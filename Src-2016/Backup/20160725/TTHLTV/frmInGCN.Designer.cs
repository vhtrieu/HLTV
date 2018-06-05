namespace TTHLTV
{
    partial class frmInGCN
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lookLopHoc = new DevExpress.XtraEditors.LookUpEdit();
            this.lookChungChi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnInGCN = new DevExpress.XtraEditors.SimpleButton();
            this.rdMatIn = new DevExpress.XtraEditors.RadioGroup();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLopHoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChungChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdMatIn.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(758, 502);
            this.splitContainerControl1.SplitterPosition = 97;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.btnInGCN);
            this.splitContainerControl2.Panel2.Controls.Add(this.rdMatIn);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(758, 97);
            this.splitContainerControl2.SplitterPosition = 451;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lookLopHoc);
            this.groupControl1.Controls.Add(this.lookChungChi);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(451, 97);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thông tin lớp học ";
            // 
            // lookLopHoc
            // 
            this.lookLopHoc.Location = new System.Drawing.Point(123, 53);
            this.lookLopHoc.Name = "lookLopHoc";
            this.lookLopHoc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lookLopHoc.Properties.Appearance.Options.UseFont = true;
            this.lookLopHoc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookLopHoc.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LOP_Name", "Tên lớp học")});
            this.lookLopHoc.Properties.NullText = "Chọn khóa học";
            this.lookLopHoc.Size = new System.Drawing.Size(309, 24);
            this.lookLopHoc.TabIndex = 3;
            // 
            // lookChungChi
            // 
            this.lookChungChi.Location = new System.Drawing.Point(123, 23);
            this.lookChungChi.Name = "lookChungChi";
            this.lookChungChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lookChungChi.Properties.Appearance.Options.UseFont = true;
            this.lookChungChi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookChungChi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CHC_Name", "Tên khóa học ")});
            this.lookChungChi.Properties.NullText = "Chọn lớp ";
            this.lookChungChi.Size = new System.Drawing.Size(309, 24);
            this.lookChungChi.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(7, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(97, 18);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Chọn khóa học";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn lớp ";
            // 
            // btnInGCN
            // 
            this.btnInGCN.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnInGCN.Appearance.Options.UseFont = true;
            this.btnInGCN.Location = new System.Drawing.Point(111, 12);
            this.btnInGCN.Name = "btnInGCN";
            this.btnInGCN.Size = new System.Drawing.Size(75, 65);
            this.btnInGCN.TabIndex = 1;
            this.btnInGCN.Text = "In";
            // 
            // rdMatIn
            // 
            this.rdMatIn.Location = new System.Drawing.Point(5, 12);
            this.rdMatIn.Name = "rdMatIn";
            this.rdMatIn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rdMatIn.Properties.Appearance.Options.UseFont = true;
            this.rdMatIn.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Mặt trước"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Mặt sau")});
            this.rdMatIn.Size = new System.Drawing.Size(100, 65);
            this.rdMatIn.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(758, 399);
            this.reportViewer1.TabIndex = 1;
            // 
            // frmInGCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 502);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmInGCN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IN GIẤY CHỨNG NHẬN ";
            this.Load += new System.EventHandler(this.frmInGCN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookLopHoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChungChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdMatIn.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit lookLopHoc;
        private DevExpress.XtraEditors.LookUpEdit lookChungChi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnInGCN;
        private DevExpress.XtraEditors.RadioGroup rdMatIn;

    }
}