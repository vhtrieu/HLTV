namespace TTHLTV
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.tbRegister = new DevExpress.XtraTab.XtraTabControl();
            this.tbLongIn = new DevExpress.XtraTab.XtraTabPage();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLongIn = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtLoginName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabRegister = new DevExpress.XtraTab.XtraTabPage();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.exitNew = new DevExpress.XtraEditors.SimpleButton();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassNew = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserNew = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tbRegister)).BeginInit();
            this.tbRegister.SuspendLayout();
            this.tbLongIn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).BeginInit();
            this.tabRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNew.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRegister
            // 
            this.tbRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbRegister.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tbRegister.Location = new System.Drawing.Point(0, 0);
            this.tbRegister.Name = "tbRegister";
            this.tbRegister.SelectedTabPage = this.tbLongIn;
            this.tbRegister.Size = new System.Drawing.Size(574, 297);
            this.tbRegister.TabIndex = 0;
            this.tbRegister.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbLongIn,
            this.tabRegister});
            // 
            // tbLongIn
            // 
            this.tbLongIn.Controls.Add(this.btnExit);
            this.tbLongIn.Controls.Add(this.btnLongIn);
            this.tbLongIn.Controls.Add(this.txtPassWord);
            this.tbLongIn.Controls.Add(this.labelControl2);
            this.tbLongIn.Controls.Add(this.txtLoginName);
            this.tbLongIn.Controls.Add(this.labelControl1);
            this.tbLongIn.Name = "tbLongIn";
            this.tbLongIn.Size = new System.Drawing.Size(567, 268);
            this.tbLongIn.Text = "ĐĂNG NHẬP";
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(287, 134);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 42);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLongIn
            // 
            this.btnLongIn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnLongIn.Appearance.Options.UseFont = true;
            this.btnLongIn.Location = new System.Drawing.Point(150, 134);
            this.btnLongIn.Name = "btnLongIn";
            this.btnLongIn.Size = new System.Drawing.Size(117, 42);
            this.btnLongIn.TabIndex = 3;
            this.btnLongIn.Text = "Đăng nhập";
            this.btnLongIn.Click += new System.EventHandler(this.btnLongIn_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(155, 85);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPassWord.Properties.Appearance.Options.UseFont = true;
            this.txtPassWord.Size = new System.Drawing.Size(249, 24);
            this.txtPassWord.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(36, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 18);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(155, 45);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtLoginName.Properties.Appearance.Options.UseFont = true;
            this.txtLoginName.Size = new System.Drawing.Size(249, 24);
            this.txtLoginName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(36, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên đăng nhập";
            // 
            // tabRegister
            // 
            this.tabRegister.Controls.Add(this.txtCode);
            this.tabRegister.Controls.Add(this.labelControl6);
            this.tabRegister.Controls.Add(this.txtFullName);
            this.tabRegister.Controls.Add(this.labelControl5);
            this.tabRegister.Controls.Add(this.exitNew);
            this.tabRegister.Controls.Add(this.btnRegister);
            this.tabRegister.Controls.Add(this.txtPassNew);
            this.tabRegister.Controls.Add(this.labelControl3);
            this.tabRegister.Controls.Add(this.txtUserNew);
            this.tabRegister.Controls.Add(this.labelControl4);
            this.tabRegister.Name = "tabRegister";
            this.tabRegister.Size = new System.Drawing.Size(567, 268);
            this.tabRegister.Text = "ĐĂNG KÍ MỚI";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(200, 40);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(249, 24);
            this.txtCode.TabIndex = 15;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(81, 42);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(97, 18);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "Mã người dùng";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(200, 70);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtFullName.Properties.Appearance.Options.UseFont = true;
            this.txtFullName.Size = new System.Drawing.Size(249, 24);
            this.txtFullName.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(81, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 18);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Họ và Tên";
            // 
            // exitNew
            // 
            this.exitNew.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.exitNew.Appearance.Options.UseFont = true;
            this.exitNew.Location = new System.Drawing.Point(332, 177);
            this.exitNew.Name = "exitNew";
            this.exitNew.Size = new System.Drawing.Size(117, 42);
            this.exitNew.TabIndex = 5;
            this.exitNew.Text = "Thoát";
            this.exitNew.Click += new System.EventHandler(this.exitNew_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnRegister.Appearance.Options.UseFont = true;
            this.btnRegister.Location = new System.Drawing.Point(195, 177);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(117, 42);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Đăng kí";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtPassNew
            // 
            this.txtPassNew.Location = new System.Drawing.Point(200, 134);
            this.txtPassNew.Name = "txtPassNew";
            this.txtPassNew.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPassNew.Properties.Appearance.Options.UseFont = true;
            this.txtPassNew.Size = new System.Drawing.Size(249, 24);
            this.txtPassNew.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(81, 136);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 18);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Mật khẩu";
            // 
            // txtUserNew
            // 
            this.txtUserNew.Location = new System.Drawing.Point(200, 102);
            this.txtUserNew.Name = "txtUserNew";
            this.txtUserNew.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtUserNew.Properties.Appearance.Options.UseFont = true;
            this.txtUserNew.Size = new System.Drawing.Size(249, 24);
            this.txtUserNew.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(81, 104);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(101, 18);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Tên đăng nhập";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 297);
            this.Controls.Add(this.tbRegister);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbRegister)).EndInit();
            this.tbRegister.ResumeLayout(false);
            this.tbLongIn.ResumeLayout(false);
            this.tbLongIn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).EndInit();
            this.tabRegister.ResumeLayout(false);
            this.tabRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNew.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl tbRegister;
        private DevExpress.XtraTab.XtraTabPage tbLongIn;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnLongIn;
        private DevExpress.XtraEditors.TextEdit txtPassWord;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtLoginName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTab.XtraTabPage tabRegister;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton exitNew;
        private DevExpress.XtraEditors.SimpleButton btnRegister;
        private DevExpress.XtraEditors.TextEdit txtPassNew;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtUserNew;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl6;

    }
}