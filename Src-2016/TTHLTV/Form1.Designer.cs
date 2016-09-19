namespace TTHLTV
{
    partial class Form1
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
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnLongIn = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtLoginName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(355, 167);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 42);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Thoát";
            // 
            // btnLongIn
            // 
            this.btnLongIn.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnLongIn.Appearance.Options.UseFont = true;
            this.btnLongIn.Location = new System.Drawing.Point(218, 167);
            this.btnLongIn.Name = "btnLongIn";
            this.btnLongIn.Size = new System.Drawing.Size(117, 42);
            this.btnLongIn.TabIndex = 9;
            this.btnLongIn.Text = "Đăng nhập";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(223, 118);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPassWord.Properties.Appearance.Options.UseFont = true;
            this.txtPassWord.Size = new System.Drawing.Size(249, 24);
            this.txtPassWord.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(104, 120);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 18);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(223, 78);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtLoginName.Properties.Appearance.Options.UseFont = true;
            this.txtLoginName.Size = new System.Drawing.Size(249, 24);
            this.txtLoginName.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(104, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 18);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Tên đăng nhập";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 334);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLongIn);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.labelControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoginName.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnLongIn;
        private DevExpress.XtraEditors.TextEdit txtPassWord;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtLoginName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}