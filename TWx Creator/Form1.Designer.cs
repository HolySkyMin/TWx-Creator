namespace TWx_Creator
{
    partial class MainField
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainField));
            this.InputField = new System.Windows.Forms.RichTextBox();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.CreateNewBtn = new System.Windows.Forms.Button();
            this.ProgramInfoBtn = new System.Windows.Forms.Button();
            this.SaveFileBtn = new System.Windows.Forms.Button();
            this.OpenFileBtn = new System.Windows.Forms.Button();
            this.ExportPanel = new System.Windows.Forms.GroupBox();
            this.PreviewBtn = new System.Windows.Forms.Button();
            this.CompileBtn = new System.Windows.Forms.Button();
            this.ExportLangPanel = new System.Windows.Forms.GroupBox();
            this.TW6 = new System.Windows.Forms.RadioButton();
            this.TW5 = new System.Windows.Forms.RadioButton();
            this.TW4 = new System.Windows.Forms.RadioButton();
            this.TW2 = new System.Windows.Forms.RadioButton();
            this.InputLangPanel = new System.Windows.Forms.GroupBox();
            this.TWxScript = new System.Windows.Forms.RadioButton();
            this.LogList = new System.Windows.Forms.ListBox();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.ExportDialog = new System.Windows.Forms.SaveFileDialog();
            this.ButtonsPanel.SuspendLayout();
            this.ExportPanel.SuspendLayout();
            this.ExportLangPanel.SuspendLayout();
            this.InputLangPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputField
            // 
            this.InputField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputField.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputField.Location = new System.Drawing.Point(10, 59);
            this.InputField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputField.Name = "InputField";
            this.InputField.Size = new System.Drawing.Size(407, 300);
            this.InputField.TabIndex = 0;
            this.InputField.Text = "";
            this.InputField.WordWrap = false;
            this.InputField.TextChanged += new System.EventHandler(this.InputField_TextChanged);
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsPanel.Controls.Add(this.CreateNewBtn);
            this.ButtonsPanel.Controls.Add(this.ProgramInfoBtn);
            this.ButtonsPanel.Controls.Add(this.SaveFileBtn);
            this.ButtonsPanel.Controls.Add(this.OpenFileBtn);
            this.ButtonsPanel.Location = new System.Drawing.Point(10, 10);
            this.ButtonsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(682, 45);
            this.ButtonsPanel.TabIndex = 1;
            // 
            // CreateNewBtn
            // 
            this.CreateNewBtn.Location = new System.Drawing.Point(3, 2);
            this.CreateNewBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateNewBtn.Name = "CreateNewBtn";
            this.CreateNewBtn.Size = new System.Drawing.Size(131, 40);
            this.CreateNewBtn.TabIndex = 4;
            this.CreateNewBtn.Text = "Create new project";
            this.CreateNewBtn.UseVisualStyleBackColor = true;
            this.CreateNewBtn.Click += new System.EventHandler(this.CreateNewBtn_Click);
            // 
            // ProgramInfoBtn
            // 
            this.ProgramInfoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgramInfoBtn.Location = new System.Drawing.Point(549, 2);
            this.ProgramInfoBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgramInfoBtn.Name = "ProgramInfoBtn";
            this.ProgramInfoBtn.Size = new System.Drawing.Size(131, 40);
            this.ProgramInfoBtn.TabIndex = 2;
            this.ProgramInfoBtn.Text = "Program info";
            this.ProgramInfoBtn.UseVisualStyleBackColor = true;
            this.ProgramInfoBtn.Click += new System.EventHandler(this.ProgramInfoBtn_Click);
            // 
            // SaveFileBtn
            // 
            this.SaveFileBtn.Location = new System.Drawing.Point(276, 2);
            this.SaveFileBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveFileBtn.Name = "SaveFileBtn";
            this.SaveFileBtn.Size = new System.Drawing.Size(131, 40);
            this.SaveFileBtn.TabIndex = 1;
            this.SaveFileBtn.Text = "Save project";
            this.SaveFileBtn.UseVisualStyleBackColor = true;
            this.SaveFileBtn.Click += new System.EventHandler(this.SaveFileBtn_Click);
            // 
            // OpenFileBtn
            // 
            this.OpenFileBtn.Location = new System.Drawing.Point(139, 2);
            this.OpenFileBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenFileBtn.Name = "OpenFileBtn";
            this.OpenFileBtn.Size = new System.Drawing.Size(131, 40);
            this.OpenFileBtn.TabIndex = 0;
            this.OpenFileBtn.Text = "Open project";
            this.OpenFileBtn.UseVisualStyleBackColor = true;
            this.OpenFileBtn.Click += new System.EventHandler(this.OpenFileBtn_Click);
            // 
            // ExportPanel
            // 
            this.ExportPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportPanel.Controls.Add(this.PreviewBtn);
            this.ExportPanel.Controls.Add(this.CompileBtn);
            this.ExportPanel.Controls.Add(this.ExportLangPanel);
            this.ExportPanel.Controls.Add(this.InputLangPanel);
            this.ExportPanel.Location = new System.Drawing.Point(423, 59);
            this.ExportPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportPanel.Name = "ExportPanel";
            this.ExportPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportPanel.Size = new System.Drawing.Size(270, 299);
            this.ExportPanel.TabIndex = 2;
            this.ExportPanel.TabStop = false;
            this.ExportPanel.Text = "Generate setting";
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PreviewBtn.Location = new System.Drawing.Point(5, 210);
            this.PreviewBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(260, 40);
            this.PreviewBtn.TabIndex = 3;
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.UseVisualStyleBackColor = true;
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // CompileBtn
            // 
            this.CompileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompileBtn.Location = new System.Drawing.Point(5, 254);
            this.CompileBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompileBtn.Name = "CompileBtn";
            this.CompileBtn.Size = new System.Drawing.Size(260, 40);
            this.CompileBtn.TabIndex = 2;
            this.CompileBtn.Text = "Generate";
            this.CompileBtn.UseVisualStyleBackColor = true;
            this.CompileBtn.Click += new System.EventHandler(this.CompileBtn_Click);
            // 
            // ExportLangPanel
            // 
            this.ExportLangPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportLangPanel.Controls.Add(this.TW6);
            this.ExportLangPanel.Controls.Add(this.TW5);
            this.ExportLangPanel.Controls.Add(this.TW4);
            this.ExportLangPanel.Controls.Add(this.TW2);
            this.ExportLangPanel.Location = new System.Drawing.Point(5, 103);
            this.ExportLangPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportLangPanel.Name = "ExportLangPanel";
            this.ExportLangPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExportLangPanel.Size = new System.Drawing.Size(260, 102);
            this.ExportLangPanel.TabIndex = 1;
            this.ExportLangPanel.TabStop = false;
            this.ExportLangPanel.Text = "Export format";
            // 
            // TW6
            // 
            this.TW6.AutoSize = true;
            this.TW6.Checked = true;
            this.TW6.Location = new System.Drawing.Point(5, 79);
            this.TW6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TW6.Name = "TW6";
            this.TW6.Size = new System.Drawing.Size(221, 16);
            this.TW6.TabIndex = 3;
            this.TW6.TabStop = true;
            this.TW6.Text = "TW6 (6Lane TWx Beatmap Format)";
            this.TW6.UseVisualStyleBackColor = true;
            // 
            // TW5
            // 
            this.TW5.AutoSize = true;
            this.TW5.Location = new System.Drawing.Point(5, 59);
            this.TW5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TW5.Name = "TW5";
            this.TW5.Size = new System.Drawing.Size(221, 16);
            this.TW5.TabIndex = 2;
            this.TW5.Text = "TW5 (5Lane TWx Beatmap Format)";
            this.TW5.UseVisualStyleBackColor = true;
            // 
            // TW4
            // 
            this.TW4.AutoSize = true;
            this.TW4.Location = new System.Drawing.Point(5, 39);
            this.TW4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TW4.Name = "TW4";
            this.TW4.Size = new System.Drawing.Size(221, 16);
            this.TW4.TabIndex = 1;
            this.TW4.Text = "TW4 (4Lane TWx Beatmap Format)";
            this.TW4.UseVisualStyleBackColor = true;
            // 
            // TW2
            // 
            this.TW2.AutoSize = true;
            this.TW2.Location = new System.Drawing.Point(5, 19);
            this.TW2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TW2.Name = "TW2";
            this.TW2.Size = new System.Drawing.Size(221, 16);
            this.TW2.TabIndex = 0;
            this.TW2.Text = "TW2 (2Lane TWx Beatmap Format)";
            this.TW2.UseVisualStyleBackColor = true;
            // 
            // InputLangPanel
            // 
            this.InputLangPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputLangPanel.Controls.Add(this.TWxScript);
            this.InputLangPanel.Location = new System.Drawing.Point(5, 19);
            this.InputLangPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputLangPanel.Name = "InputLangPanel";
            this.InputLangPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputLangPanel.Size = new System.Drawing.Size(260, 79);
            this.InputLangPanel.TabIndex = 0;
            this.InputLangPanel.TabStop = false;
            this.InputLangPanel.Text = "Script parsing method";
            // 
            // TWxScript
            // 
            this.TWxScript.AutoSize = true;
            this.TWxScript.Checked = true;
            this.TWxScript.Location = new System.Drawing.Point(5, 19);
            this.TWxScript.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TWxScript.Name = "TWxScript";
            this.TWxScript.Size = new System.Drawing.Size(80, 16);
            this.TWxScript.TabIndex = 0;
            this.TWxScript.TabStop = true;
            this.TWxScript.Text = "TWxScript";
            this.TWxScript.UseVisualStyleBackColor = true;
            // 
            // LogList
            // 
            this.LogList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogList.FormattingEnabled = true;
            this.LogList.HorizontalScrollbar = true;
            this.LogList.ItemHeight = 12;
            this.LogList.Location = new System.Drawing.Point(10, 363);
            this.LogList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogList.Name = "LogList";
            this.LogList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.LogList.Size = new System.Drawing.Size(683, 136);
            this.LogList.TabIndex = 3;
            this.LogList.TabStop = false;
            // 
            // OpenDialog
            // 
            this.OpenDialog.DefaultExt = "twxc";
            this.OpenDialog.FileName = "Project File";
            this.OpenDialog.Filter = "TWx Creator Savefile (*.twxc)|*.twxc";
            this.OpenDialog.Title = "프로젝트 파일 선택";
            // 
            // SaveDialog
            // 
            this.SaveDialog.DefaultExt = "twxc";
            this.SaveDialog.FileName = "New Project";
            this.SaveDialog.Filter = "TWx Creator Savefile (*.twxc)|*.twxc";
            this.SaveDialog.Title = "프로젝트 저장";
            // 
            // ExportDialog
            // 
            this.ExportDialog.FileName = "New Beatmap";
            // 
            // MainField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 515);
            this.Controls.Add(this.LogList);
            this.Controls.Add(this.ExportPanel);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.InputField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(721, 554);
            this.Name = "MainField";
            this.Text = "TWx Creator 0.1.3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainField_FormClosing);
            this.Load += new System.EventHandler(this.MainField_Load);
            this.ButtonsPanel.ResumeLayout(false);
            this.ExportPanel.ResumeLayout(false);
            this.ExportLangPanel.ResumeLayout(false);
            this.ExportLangPanel.PerformLayout();
            this.InputLangPanel.ResumeLayout(false);
            this.InputLangPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox InputField;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button OpenFileBtn;
        private System.Windows.Forms.Button ProgramInfoBtn;
        private System.Windows.Forms.Button SaveFileBtn;
        private System.Windows.Forms.GroupBox ExportPanel;
        private System.Windows.Forms.Button CompileBtn;
        private System.Windows.Forms.GroupBox ExportLangPanel;
        private System.Windows.Forms.RadioButton TW6;
        private System.Windows.Forms.RadioButton TW5;
        private System.Windows.Forms.RadioButton TW4;
        private System.Windows.Forms.RadioButton TW2;
        private System.Windows.Forms.GroupBox InputLangPanel;
        private System.Windows.Forms.RadioButton TWxScript;
        private System.Windows.Forms.ListBox LogList;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.Button CreateNewBtn;
        private System.Windows.Forms.SaveFileDialog ExportDialog;
        private System.Windows.Forms.Button PreviewBtn;
    }
}

