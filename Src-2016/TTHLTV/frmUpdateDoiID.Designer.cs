namespace TTHLTV
{
    partial class frmUpdateDoiID
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lookChungChi = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.gridStudents = new DevExpress.XtraGrid.GridControl();
            this.gridContentStudents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CCC_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChungChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContentStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 57);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(132, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(312, 51);
            this.dataGridView1.TabIndex = 2;
            // 
            // lookChungChi
            // 
            this.lookChungChi.Location = new System.Drawing.Point(132, 90);
            this.lookChungChi.Name = "lookChungChi";
            this.lookChungChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lookChungChi.Properties.Appearance.Options.UseFont = true;
            this.lookChungChi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookChungChi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CHC_Name", "Tên khóa học ")});
            this.lookChungChi.Properties.NullText = "Chọn lớp ";
            this.lookChungChi.Size = new System.Drawing.Size(347, 24);
            this.lookChungChi.TabIndex = 3;
            this.lookChungChi.EditValueChanged += new System.EventHandler(this.lookChungChi_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 4;
            // 
            // gridStudents
            // 
            this.gridStudents.Location = new System.Drawing.Point(132, 120);
            this.gridStudents.MainView = this.gridContentStudents;
            this.gridStudents.Name = "gridStudents";
            this.gridStudents.Size = new System.Drawing.Size(548, 204);
            this.gridStudents.TabIndex = 5;
            this.gridStudents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridContentStudents});
            // 
            // gridContentStudents
            // 
            this.gridContentStudents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.CCC_ID});
            this.gridContentStudents.GridControl = this.gridStudents;
            this.gridContentStudents.Name = "gridContentStudents";
            this.gridContentStudents.OptionsBehavior.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.Caption = "DOI_ID";
            this.ID.FieldName = "DOI_ID";
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            // 
            // CCC_ID
            // 
            this.CCC_ID.Caption = "CCC_ID";
            this.CCC_ID.FieldName = "CCC_ID";
            this.CCC_ID.Name = "CCC_ID";
            this.CCC_ID.Visible = true;
            this.CCC_ID.VisibleIndex = 1;
            // 
            // frmUpdateDoiID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 403);
            this.Controls.Add(this.gridStudents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lookChungChi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "frmUpdateDoiID";
            this.Text = "frmUpdateDoiID";
            this.Load += new System.EventHandler(this.frmUpdateDoiID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookChungChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridContentStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.LookUpEdit lookChungChi;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridStudents;
        private DevExpress.XtraGrid.Views.Grid.GridView gridContentStudents;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn CCC_ID;
    }
}