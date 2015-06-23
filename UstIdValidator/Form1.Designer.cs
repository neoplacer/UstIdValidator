namespace UstIdValidator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmdValidate = new System.Windows.Forms.Button();
            this.lblOwnUstId = new System.Windows.Forms.Label();
            this.lblRequestUStID = new System.Windows.Forms.Label();
            this.txtUstIDDE = new System.Windows.Forms.TextBox();
            this.txtUstIDREG = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.stbar = new System.Windows.Forms.StatusStrip();
            this.stbarlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsButtonIEExplTrack = new System.Windows.Forms.ToolStripSplitButton();
            this.countIEPull = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.stbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdValidate
            // 
            this.cmdValidate.Location = new System.Drawing.Point(197, 70);
            this.cmdValidate.Name = "cmdValidate";
            this.cmdValidate.Size = new System.Drawing.Size(75, 23);
            this.cmdValidate.TabIndex = 2;
            this.cmdValidate.Text = "Überprüfen";
            this.cmdValidate.UseVisualStyleBackColor = true;
            this.cmdValidate.Click += new System.EventHandler(this.cmdValidate_Click);
            // 
            // lblOwnUstId
            // 
            this.lblOwnUstId.AutoSize = true;
            this.lblOwnUstId.Location = new System.Drawing.Point(13, 13);
            this.lblOwnUstId.Name = "lblOwnUstId";
            this.lblOwnUstId.Size = new System.Drawing.Size(84, 13);
            this.lblOwnUstId.TabIndex = 1;
            this.lblOwnUstId.Text = "Eigene USt-IdNr";
            // 
            // lblRequestUStID
            // 
            this.lblRequestUStID.AutoSize = true;
            this.lblRequestUStID.Location = new System.Drawing.Point(13, 47);
            this.lblRequestUStID.Name = "lblRequestUStID";
            this.lblRequestUStID.Size = new System.Drawing.Size(117, 13);
            this.lblRequestUStID.TabIndex = 2;
            this.lblRequestUStID.Text = "Abzufragende USt-IdNr";
            // 
            // txtUstIDDE
            // 
            this.txtUstIDDE.Location = new System.Drawing.Point(172, 10);
            this.txtUstIDDE.Name = "txtUstIDDE";
            this.txtUstIDDE.Size = new System.Drawing.Size(100, 20);
            this.txtUstIDDE.TabIndex = 0;
            this.txtUstIDDE.Text = "DE";
            // 
            // txtUstIDREG
            // 
            this.txtUstIDREG.Location = new System.Drawing.Point(172, 44);
            this.txtUstIDREG.Name = "txtUstIDREG";
            this.txtUstIDREG.Size = new System.Drawing.Size(100, 20);
            this.txtUstIDREG.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 114);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(260, 108);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // prgBar
            // 
            this.prgBar.Location = new System.Drawing.Point(25, 70);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(166, 23);
            this.prgBar.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(84, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 7;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(9, 98);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(39, 13);
            this.lblData.TabIndex = 8;
            this.lblData.Text = "Daten:";
            // 
            // stbar
            // 
            this.stbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbarlblStatus,
            this.tsButtonIEExplTrack});
            this.stbar.Location = new System.Drawing.Point(0, 227);
            this.stbar.Name = "stbar";
            this.stbar.Size = new System.Drawing.Size(278, 22);
            this.stbar.SizingGrip = false;
            this.stbar.TabIndex = 10;
            this.stbar.Text = "statusStrip1";
            // 
            // stbarlblStatus
            // 
            this.stbarlblStatus.Name = "stbarlblStatus";
            this.stbarlblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tsButtonIEExplTrack
            // 
            this.tsButtonIEExplTrack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonIEExplTrack.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonIEExplTrack.Image")));
            this.tsButtonIEExplTrack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonIEExplTrack.Name = "tsButtonIEExplTrack";
            this.tsButtonIEExplTrack.Size = new System.Drawing.Size(32, 20);
            this.tsButtonIEExplTrack.Text = "toolStripSplitButton1";
            this.tsButtonIEExplTrack.ButtonClick += new System.EventHandler(this.tsButtonIEExplTrack_ButtonClick);
            // 
            // countIEPull
            // 
            this.countIEPull.Tick += new System.EventHandler(this.countIEPull_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(1, 76);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(19, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "▼";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.UseMnemonic = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(291, 10);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(174, 77);
            this.dataGridView1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 249);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.stbar);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtUstIDREG);
            this.Controls.Add(this.txtUstIDDE);
            this.Controls.Add(this.lblRequestUStID);
            this.Controls.Add(this.lblOwnUstId);
            this.Controls.Add(this.cmdValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "USt-IdNr Prüfer";
            this.stbar.ResumeLayout(false);
            this.stbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdValidate;
        private System.Windows.Forms.Label lblOwnUstId;
        private System.Windows.Forms.Label lblRequestUStID;
        private System.Windows.Forms.TextBox txtUstIDDE;
        private System.Windows.Forms.TextBox txtUstIDREG;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.StatusStrip stbar;
        private System.Windows.Forms.ToolStripStatusLabel stbarlblStatus;
        private System.Windows.Forms.ToolStripSplitButton tsButtonIEExplTrack;
        private System.Windows.Forms.Timer countIEPull;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

