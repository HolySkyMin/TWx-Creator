namespace TWx_Creator
{
    partial class PreviewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewForm));
            this.NotePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.RedrawBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.bottomBtn = new System.Windows.Forms.Button();
            this.NotePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NotePanel
            // 
            this.NotePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NotePanel.AutoScroll = true;
            this.NotePanel.BackColor = System.Drawing.Color.DimGray;
            this.NotePanel.Controls.Add(this.pictureBox1);
            this.NotePanel.Location = new System.Drawing.Point(10, 10);
            this.NotePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NotePanel.Name = "NotePanel";
            this.NotePanel.Size = new System.Drawing.Size(462, 296);
            this.NotePanel.TabIndex = 0;
            this.NotePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NotePanel_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(319, 203);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReturnBtn.Location = new System.Drawing.Point(324, 310);
            this.ReturnBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(148, 42);
            this.ReturnBtn.TabIndex = 1;
            this.ReturnBtn.Text = "Return";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // RedrawBtn
            // 
            this.RedrawBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RedrawBtn.Location = new System.Drawing.Point(12, 311);
            this.RedrawBtn.Name = "RedrawBtn";
            this.RedrawBtn.Size = new System.Drawing.Size(121, 41);
            this.RedrawBtn.TabIndex = 2;
            this.RedrawBtn.Text = "Redraw from here";
            this.RedrawBtn.UseVisualStyleBackColor = true;
            this.RedrawBtn.Click += new System.EventHandler(this.RedrawBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetBtn.Location = new System.Drawing.Point(140, 312);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(57, 40);
            this.ResetBtn.TabIndex = 3;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // bottomBtn
            // 
            this.bottomBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bottomBtn.Location = new System.Drawing.Point(204, 312);
            this.bottomBtn.Name = "bottomBtn";
            this.bottomBtn.Size = new System.Drawing.Size(94, 40);
            this.bottomBtn.TabIndex = 4;
            this.bottomBtn.Text = "Go to bottom";
            this.bottomBtn.UseVisualStyleBackColor = true;
            this.bottomBtn.Click += new System.EventHandler(this.bottomBtn_Click);
            // 
            // PreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 369);
            this.Controls.Add(this.bottomBtn);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.RedrawBtn);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.NotePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 408);
            this.Name = "PreviewForm";
            this.Text = "Preview";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PreviewForm_Load);
            this.NotePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel NotePanel;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button RedrawBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button bottomBtn;
    }
}