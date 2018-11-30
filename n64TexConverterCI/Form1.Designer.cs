namespace n64TexConverterCI
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
            this.filePathBtn = new System.Windows.Forms.Button();
            this.convertBtn = new System.Windows.Forms.Button();
            this.paletteSizeCmb = new System.Windows.Forms.ComboBox();
            this.texturePic = new System.Windows.Forms.PictureBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.filePathTxt = new System.Windows.Forms.TextBox();
            this.paletteSizeLbl = new System.Windows.Forms.Label();
            this.metadataLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.texturePic)).BeginInit();
            this.SuspendLayout();
            // 
            // filePathBtn
            // 
            this.filePathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathBtn.Location = new System.Drawing.Point(197, 13);
            this.filePathBtn.Name = "filePathBtn";
            this.filePathBtn.Size = new System.Drawing.Size(75, 23);
            this.filePathBtn.TabIndex = 0;
            this.filePathBtn.Text = "File Path";
            this.filePathBtn.UseVisualStyleBackColor = true;
            this.filePathBtn.Click += new System.EventHandler(this.filePathBtn_Click);
            // 
            // convertBtn
            // 
            this.convertBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.convertBtn.Location = new System.Drawing.Point(197, 197);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(75, 23);
            this.convertBtn.TabIndex = 1;
            this.convertBtn.Text = "Convert";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // paletteSizeCmb
            // 
            this.paletteSizeCmb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteSizeCmb.FormattingEnabled = true;
            this.paletteSizeCmb.Items.AddRange(new object[] {
            "16",
            "256"});
            this.paletteSizeCmb.Location = new System.Drawing.Point(197, 57);
            this.paletteSizeCmb.Name = "paletteSizeCmb";
            this.paletteSizeCmb.Size = new System.Drawing.Size(75, 21);
            this.paletteSizeCmb.TabIndex = 2;
            this.paletteSizeCmb.Text = "16";
            // 
            // texturePic
            // 
            this.texturePic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.texturePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.texturePic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.texturePic.Location = new System.Drawing.Point(12, 41);
            this.texturePic.Name = "texturePic";
            this.texturePic.Size = new System.Drawing.Size(179, 208);
            this.texturePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.texturePic.TabIndex = 3;
            this.texturePic.TabStop = false;
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.Location = new System.Drawing.Point(197, 226);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // filePathTxt
            // 
            this.filePathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTxt.Location = new System.Drawing.Point(12, 15);
            this.filePathTxt.Name = "filePathTxt";
            this.filePathTxt.ReadOnly = true;
            this.filePathTxt.Size = new System.Drawing.Size(178, 20);
            this.filePathTxt.TabIndex = 5;
            // 
            // paletteSizeLbl
            // 
            this.paletteSizeLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteSizeLbl.AutoSize = true;
            this.paletteSizeLbl.Location = new System.Drawing.Point(197, 41);
            this.paletteSizeLbl.Name = "paletteSizeLbl";
            this.paletteSizeLbl.Size = new System.Drawing.Size(66, 13);
            this.paletteSizeLbl.TabIndex = 6;
            this.paletteSizeLbl.Text = "Palette Size:";
            // 
            // metadataLbl
            // 
            this.metadataLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metadataLbl.AutoSize = true;
            this.metadataLbl.Location = new System.Drawing.Point(197, 85);
            this.metadataLbl.Name = "metadataLbl";
            this.metadataLbl.Size = new System.Drawing.Size(51, 13);
            this.metadataLbl.TabIndex = 7;
            this.metadataLbl.Text = "metadata";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.metadataLbl);
            this.Controls.Add(this.paletteSizeLbl);
            this.Controls.Add(this.filePathTxt);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.texturePic);
            this.Controls.Add(this.paletteSizeCmb);
            this.Controls.Add(this.convertBtn);
            this.Controls.Add(this.filePathBtn);
            this.MinimumSize = new System.Drawing.Size(210, 210);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI Texture Converter";
            ((System.ComponentModel.ISupportInitialize)(this.texturePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button filePathBtn;
        private System.Windows.Forms.Button convertBtn;
        private System.Windows.Forms.ComboBox paletteSizeCmb;
        private System.Windows.Forms.PictureBox texturePic;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.TextBox filePathTxt;
        private System.Windows.Forms.Label paletteSizeLbl;
		private System.Windows.Forms.Label metadataLbl;
	}
}

