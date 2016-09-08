namespace ImageEditor
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
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Label7 = new System.Windows.Forms.Label();
            this.lbloriginalSize = new System.Windows.Forms.Label();
            this.lblModifiedSize = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.DomainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.btnCrop = new System.Windows.Forms.Button();
            this.btnMakeSelection = new System.Windows.Forms.Button();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.Label5 = new System.Windows.Forms.Label();
            this.DomainUpDownBrightness = new System.Windows.Forms.DomainUpDown();
            this.TrackBarBrightness = new System.Windows.Forms.TrackBar();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.btnRotateHorizantal = new System.Windows.Forms.Button();
            this.btnRotatevertical = new System.Windows.Forms.Button();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.TabPage5 = new System.Windows.Forms.TabPage();
            this.btnCreateText = new System.Windows.Forms.Button();
            this.btnColor5 = new System.Windows.Forms.Button();
            this.btnColor6 = new System.Windows.Forms.Button();
            this.btnColor7 = new System.Windows.Forms.Button();
            this.btnColor18 = new System.Windows.Forms.Button();
            this.btnColor4 = new System.Windows.Forms.Button();
            this.btnColor3 = new System.Windows.Forms.Button();
            this.btnColor1 = new System.Windows.Forms.Button();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.Label15 = new System.Windows.Forms.Label();
            this.btnunderline = new System.Windows.Forms.Button();
            this.btnitalic = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.cmbFonts = new System.Windows.Forms.ComboBox();
            this.btnColorDlg = new System.Windows.Forms.Button();
            this.LblColor = new System.Windows.Forms.Label();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBrightness)).BeginInit();
            this.TabPage4.SuspendLayout();
            this.TabPage5.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 24);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.AutoScroll = true;
            this.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.SplitContainer1.Panel1.Controls.Add(this.PictureBox1);
            this.SplitContainer1.Panel1.Resize += new System.EventHandler(this.SplitContainer1_Panel1_Resize);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.TabControl1);
            this.SplitContainer1.Size = new System.Drawing.Size(858, 591);
            this.SplitContainer1.SplitterDistance = 575;
            this.SplitContainer1.TabIndex = 6;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(3, 22);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(585, 452);
            this.PictureBox1.TabIndex = 0;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.PictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.PictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage4);
            this.TabControl1.Controls.Add(this.TabPage5);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(279, 591);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.Label7);
            this.TabPage1.Controls.Add(this.lbloriginalSize);
            this.TabPage1.Controls.Add(this.lblModifiedSize);
            this.TabPage1.Controls.Add(this.Label4);
            this.TabPage1.Controls.Add(this.btnOk);
            this.TabPage1.Controls.Add(this.Label3);
            this.TabPage1.Controls.Add(this.DomainUpDown1);
            this.TabPage1.Controls.Add(this.Label2);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(271, 565);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Resize";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(27, 217);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(66, 13);
            this.Label7.TabIndex = 8;
            this.Label7.Text = "Original size:";
            // 
            // lbloriginalSize
            // 
            this.lbloriginalSize.AutoSize = true;
            this.lbloriginalSize.Location = new System.Drawing.Point(110, 217);
            this.lbloriginalSize.Name = "lbloriginalSize";
            this.lbloriginalSize.Size = new System.Drawing.Size(0, 13);
            this.lbloriginalSize.TabIndex = 7;
            // 
            // lblModifiedSize
            // 
            this.lblModifiedSize.AutoSize = true;
            this.lblModifiedSize.Location = new System.Drawing.Point(110, 240);
            this.lblModifiedSize.Name = "lblModifiedSize";
            this.lblModifiedSize.Size = new System.Drawing.Size(0, 13);
            this.lblModifiedSize.TabIndex = 6;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(27, 240);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Modified size:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(113, 60);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(51, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(92, 68);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(15, 13);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "%";
            // 
            // DomainUpDown1
            // 
            this.DomainUpDown1.Location = new System.Drawing.Point(11, 63);
            this.DomainUpDown1.Name = "DomainUpDown1";
            this.DomainUpDown1.Size = new System.Drawing.Size(75, 20);
            this.DomainUpDown1.TabIndex = 2;
            this.DomainUpDown1.SelectedItemChanged += new System.EventHandler(this.DomainUpDown1_SelectedItemChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(8, 188);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(105, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Size setting summery";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(8, 28);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(191, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Tag = "";
            this.Label1.Text = "Percantage of original width and height";
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.btnCrop);
            this.TabPage3.Controls.Add(this.btnMakeSelection);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Size = new System.Drawing.Size(271, 565);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Crop";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCrop
            // 
            this.btnCrop.Location = new System.Drawing.Point(93, 102);
            this.btnCrop.Name = "btnCrop";
            this.btnCrop.Size = new System.Drawing.Size(75, 26);
            this.btnCrop.TabIndex = 1;
            this.btnCrop.Text = "Crop";
            this.btnCrop.UseVisualStyleBackColor = true;
            this.btnCrop.Click += new System.EventHandler(this.btnCrop_Click);
            // 
            // btnMakeSelection
            // 
            this.btnMakeSelection.Location = new System.Drawing.Point(70, 73);
            this.btnMakeSelection.Name = "btnMakeSelection";
            this.btnMakeSelection.Size = new System.Drawing.Size(115, 23);
            this.btnMakeSelection.TabIndex = 0;
            this.btnMakeSelection.Text = "Make Selection";
            this.btnMakeSelection.UseVisualStyleBackColor = true;
            this.btnMakeSelection.Click += new System.EventHandler(this.btnMakeSelection_Click);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.Label5);
            this.TabPage2.Controls.Add(this.DomainUpDownBrightness);
            this.TabPage2.Controls.Add(this.TrackBarBrightness);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(271, 565);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Brightness";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(28, 48);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(65, 15);
            this.Label5.TabIndex = 2;
            this.Label5.Text = "Brightness";
            // 
            // DomainUpDownBrightness
            // 
            this.DomainUpDownBrightness.Location = new System.Drawing.Point(162, 101);
            this.DomainUpDownBrightness.Name = "DomainUpDownBrightness";
            this.DomainUpDownBrightness.ReadOnly = true;
            this.DomainUpDownBrightness.Size = new System.Drawing.Size(61, 20);
            this.DomainUpDownBrightness.TabIndex = 1;
            // 
            // TrackBarBrightness
            // 
            this.TrackBarBrightness.BackColor = System.Drawing.Color.White;
            this.TrackBarBrightness.Location = new System.Drawing.Point(17, 100);
            this.TrackBarBrightness.Maximum = 100;
            this.TrackBarBrightness.Minimum = -100;
            this.TrackBarBrightness.Name = "TrackBarBrightness";
            this.TrackBarBrightness.Size = new System.Drawing.Size(139, 45);
            this.TrackBarBrightness.TabIndex = 0;
            this.TrackBarBrightness.Scroll += new System.EventHandler(this.TrackBarBrightness_Scroll);
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.btnRotateRight);
            this.TabPage4.Controls.Add(this.btnRotateHorizantal);
            this.TabPage4.Controls.Add(this.btnRotatevertical);
            this.TabPage4.Controls.Add(this.btnRotateLeft);
            this.TabPage4.Location = new System.Drawing.Point(4, 22);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Size = new System.Drawing.Size(271, 565);
            this.TabPage4.TabIndex = 3;
            this.TabPage4.Text = "Rotate";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Location = new System.Drawing.Point(75, 120);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(122, 23);
            this.btnRotateRight.TabIndex = 3;
            this.btnRotateRight.Text = "Rotate right";
            this.btnRotateRight.UseVisualStyleBackColor = true;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // btnRotateHorizantal
            // 
            this.btnRotateHorizantal.Location = new System.Drawing.Point(75, 182);
            this.btnRotateHorizantal.Name = "btnRotateHorizantal";
            this.btnRotateHorizantal.Size = new System.Drawing.Size(122, 23);
            this.btnRotateHorizantal.TabIndex = 2;
            this.btnRotateHorizantal.Text = "Rotate horizantal";
            this.btnRotateHorizantal.UseVisualStyleBackColor = true;
            this.btnRotateHorizantal.Click += new System.EventHandler(this.btnRotateHorizantal_Click);
            // 
            // btnRotatevertical
            // 
            this.btnRotatevertical.Location = new System.Drawing.Point(75, 211);
            this.btnRotatevertical.Name = "btnRotatevertical";
            this.btnRotatevertical.Size = new System.Drawing.Size(122, 23);
            this.btnRotatevertical.TabIndex = 1;
            this.btnRotatevertical.Text = "Rotate vertical";
            this.btnRotatevertical.UseVisualStyleBackColor = true;
            this.btnRotatevertical.Click += new System.EventHandler(this.btnRotatevertical_Click);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Location = new System.Drawing.Point(75, 91);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(122, 23);
            this.btnRotateLeft.TabIndex = 0;
            this.btnRotateLeft.Text = "Rotate left";
            this.btnRotateLeft.UseVisualStyleBackColor = true;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // TabPage5
            // 
            this.TabPage5.Controls.Add(this.btnCreateText);
            this.TabPage5.Controls.Add(this.btnColor5);
            this.TabPage5.Controls.Add(this.btnColor6);
            this.TabPage5.Controls.Add(this.btnColor7);
            this.TabPage5.Controls.Add(this.btnColor18);
            this.TabPage5.Controls.Add(this.btnColor4);
            this.TabPage5.Controls.Add(this.btnColor3);
            this.TabPage5.Controls.Add(this.btnColor1);
            this.TabPage5.Controls.Add(this.btnColor2);
            this.TabPage5.Controls.Add(this.Label15);
            this.TabPage5.Controls.Add(this.btnunderline);
            this.TabPage5.Controls.Add(this.btnitalic);
            this.TabPage5.Controls.Add(this.btnBold);
            this.TabPage5.Controls.Add(this.cmbFontSize);
            this.TabPage5.Controls.Add(this.cmbFonts);
            this.TabPage5.Controls.Add(this.btnColorDlg);
            this.TabPage5.Controls.Add(this.LblColor);
            this.TabPage5.Location = new System.Drawing.Point(4, 22);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Size = new System.Drawing.Size(271, 565);
            this.TabPage5.TabIndex = 4;
            this.TabPage5.Text = "Text";
            this.TabPage5.UseVisualStyleBackColor = true;
            // 
            // btnCreateText
            // 
            this.btnCreateText.Location = new System.Drawing.Point(50, 33);
            this.btnCreateText.Name = "btnCreateText";
            this.btnCreateText.Size = new System.Drawing.Size(75, 23);
            this.btnCreateText.TabIndex = 25;
            this.btnCreateText.Text = "CreateText";
            this.btnCreateText.UseVisualStyleBackColor = true;
            // 
            // btnColor5
            // 
            this.btnColor5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnColor5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor5.Location = new System.Drawing.Point(109, 225);
            this.btnColor5.Name = "btnColor5";
            this.btnColor5.Size = new System.Drawing.Size(23, 21);
            this.btnColor5.TabIndex = 24;
            this.btnColor5.UseVisualStyleBackColor = false;
            // 
            // btnColor6
            // 
            this.btnColor6.BackColor = System.Drawing.Color.Yellow;
            this.btnColor6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor6.Location = new System.Drawing.Point(133, 225);
            this.btnColor6.Name = "btnColor6";
            this.btnColor6.Size = new System.Drawing.Size(23, 21);
            this.btnColor6.TabIndex = 23;
            this.btnColor6.UseVisualStyleBackColor = false;
            // 
            // btnColor7
            // 
            this.btnColor7.BackColor = System.Drawing.Color.Green;
            this.btnColor7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor7.Location = new System.Drawing.Point(157, 225);
            this.btnColor7.Name = "btnColor7";
            this.btnColor7.Size = new System.Drawing.Size(23, 21);
            this.btnColor7.TabIndex = 22;
            this.btnColor7.UseVisualStyleBackColor = false;
            // 
            // btnColor18
            // 
            this.btnColor18.BackColor = System.Drawing.Color.Purple;
            this.btnColor18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor18.Location = new System.Drawing.Point(181, 225);
            this.btnColor18.Name = "btnColor18";
            this.btnColor18.Size = new System.Drawing.Size(23, 21);
            this.btnColor18.TabIndex = 21;
            this.btnColor18.UseVisualStyleBackColor = false;
            // 
            // btnColor4
            // 
            this.btnColor4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnColor4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor4.Location = new System.Drawing.Point(181, 202);
            this.btnColor4.Name = "btnColor4";
            this.btnColor4.Size = new System.Drawing.Size(23, 21);
            this.btnColor4.TabIndex = 20;
            this.btnColor4.UseVisualStyleBackColor = false;
            // 
            // btnColor3
            // 
            this.btnColor3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnColor3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor3.Location = new System.Drawing.Point(157, 202);
            this.btnColor3.Name = "btnColor3";
            this.btnColor3.Size = new System.Drawing.Size(23, 21);
            this.btnColor3.TabIndex = 19;
            this.btnColor3.UseVisualStyleBackColor = false;
            // 
            // btnColor1
            // 
            this.btnColor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnColor1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor1.Location = new System.Drawing.Point(109, 202);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(23, 21);
            this.btnColor1.TabIndex = 18;
            this.btnColor1.UseVisualStyleBackColor = false;
            // 
            // btnColor2
            // 
            this.btnColor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnColor2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor2.Location = new System.Drawing.Point(133, 202);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(23, 21);
            this.btnColor2.TabIndex = 17;
            this.btnColor2.UseVisualStyleBackColor = false;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(52, 233);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(31, 13);
            this.Label15.TabIndex = 16;
            this.Label15.Text = "Color";
            // 
            // btnunderline
            // 
            this.btnunderline.Location = new System.Drawing.Point(193, 110);
            this.btnunderline.Name = "btnunderline";
            this.btnunderline.Size = new System.Drawing.Size(28, 23);
            this.btnunderline.TabIndex = 15;
            this.btnunderline.Text = "U";
            this.btnunderline.UseVisualStyleBackColor = true;
            // 
            // btnitalic
            // 
            this.btnitalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnitalic.Location = new System.Drawing.Point(166, 110);
            this.btnitalic.Name = "btnitalic";
            this.btnitalic.Size = new System.Drawing.Size(28, 23);
            this.btnitalic.TabIndex = 14;
            this.btnitalic.Text = "I";
            this.btnitalic.UseVisualStyleBackColor = true;
            // 
            // btnBold
            // 
            this.btnBold.Location = new System.Drawing.Point(139, 110);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(28, 23);
            this.btnBold.TabIndex = 13;
            this.btnBold.Text = "B";
            this.btnBold.UseVisualStyleBackColor = true;
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Location = new System.Drawing.Point(51, 110);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(67, 21);
            this.cmbFontSize.TabIndex = 12;
            // 
            // cmbFonts
            // 
            this.cmbFonts.FormattingEnabled = true;
            this.cmbFonts.Location = new System.Drawing.Point(50, 83);
            this.cmbFonts.Name = "cmbFonts";
            this.cmbFonts.Size = new System.Drawing.Size(168, 21);
            this.cmbFonts.TabIndex = 9;
            // 
            // btnColorDlg
            // 
            this.btnColorDlg.Location = new System.Drawing.Point(214, 200);
            this.btnColorDlg.Name = "btnColorDlg";
            this.btnColorDlg.Size = new System.Drawing.Size(22, 48);
            this.btnColorDlg.TabIndex = 8;
            this.btnColorDlg.Text = "...";
            this.btnColorDlg.UseVisualStyleBackColor = true;
            // 
            // LblColor
            // 
            this.LblColor.BackColor = System.Drawing.Color.DimGray;
            this.LblColor.Location = new System.Drawing.Point(52, 202);
            this.LblColor.Name = "LblColor";
            this.LblColor.Size = new System.Drawing.Size(27, 23);
            this.LblColor.TabIndex = 0;
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(858, 24);
            this.MenuStrip1.TabIndex = 5;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.ToolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "Edit";
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.UndoToolStripMenuItem.Text = "Undo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 615);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBrightness)).EndInit();
            this.TabPage4.ResumeLayout(false);
            this.TabPage5.ResumeLayout(false);
            this.TabPage5.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lbloriginalSize;
        internal System.Windows.Forms.Label lblModifiedSize;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DomainUpDown DomainUpDown1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.Button btnCrop;
        internal System.Windows.Forms.Button btnMakeSelection;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.DomainUpDown DomainUpDownBrightness;
        internal System.Windows.Forms.TrackBar TrackBarBrightness;
        internal System.Windows.Forms.TabPage TabPage4;
        internal System.Windows.Forms.Button btnRotateRight;
        internal System.Windows.Forms.Button btnRotateHorizantal;
        internal System.Windows.Forms.Button btnRotatevertical;
        internal System.Windows.Forms.Button btnRotateLeft;
        internal System.Windows.Forms.TabPage TabPage5;
        internal System.Windows.Forms.Button btnCreateText;
        internal System.Windows.Forms.Button btnColor5;
        internal System.Windows.Forms.Button btnColor6;
        internal System.Windows.Forms.Button btnColor7;
        internal System.Windows.Forms.Button btnColor18;
        internal System.Windows.Forms.Button btnColor4;
        internal System.Windows.Forms.Button btnColor3;
        internal System.Windows.Forms.Button btnColor1;
        internal System.Windows.Forms.Button btnColor2;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Button btnunderline;
        internal System.Windows.Forms.Button btnitalic;
        internal System.Windows.Forms.Button btnBold;
        internal System.Windows.Forms.ComboBox cmbFontSize;
        internal System.Windows.Forms.ComboBox cmbFonts;
        internal System.Windows.Forms.Button btnColorDlg;
        internal System.Windows.Forms.Label LblColor;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
    }
}

