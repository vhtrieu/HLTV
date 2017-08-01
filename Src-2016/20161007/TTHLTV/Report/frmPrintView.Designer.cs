namespace TTHLTV.Report
{
    partial class frmPrintView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintView));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.InGcnViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.RpInGCN2 = new TTHLTV.Report.RpInGCN_MatTrong();
            this.rpInGCN1 = new TTHLTV.Report.RpInGCN_MatTrong();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.InGcnViewer);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(919, 468);
            this.splitContainerControl1.SplitterPosition = 38;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // InGcnViewer
            // 
            this.InGcnViewer.ActiveViewIndex = -1;
            this.InGcnViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InGcnViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.InGcnViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InGcnViewer.Location = new System.Drawing.Point(0, 0);
            this.InGcnViewer.Name = "InGcnViewer";
            this.InGcnViewer.Size = new System.Drawing.Size(919, 424);
            this.InGcnViewer.TabIndex = 0;
            // 
            // frmPrintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 468);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrintView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IN GIẤY CHỨNG NHẬN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInGiayChungNhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer InGcnViewer;
        private RpInGCN_MatTrong RpInGCN2;
        private RpInGCN_MatTrong rpInGCN1;

    }
}