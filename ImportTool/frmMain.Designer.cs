namespace ImportTool
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoadProject = new Button();
            lblProjectPath = new Label();
            OpenTOASTprojectDialog = new OpenFileDialog();
            tvStation1 = new TreeView();
            lstbxStation1Files = new ListBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tvStation2 = new TreeView();
            lstbxStation2Files = new ListBox();
            tabPage3 = new TabPage();
            tvStation3 = new TreeView();
            lstbxStation3Files = new ListBox();
            tabPage4 = new TabPage();
            tvStation4 = new TreeView();
            lstbxStation4Files = new ListBox();
            tabPage5 = new TabPage();
            tvStation5 = new TreeView();
            lstbxStation5Files = new ListBox();
            tabPage6 = new TabPage();
            tvStation6 = new TreeView();
            lstbxStation6Files = new ListBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadProject
            // 
            btnLoadProject.Location = new Point(12, 12);
            btnLoadProject.Name = "btnLoadProject";
            btnLoadProject.Size = new Size(90, 29);
            btnLoadProject.TabIndex = 0;
            btnLoadProject.Text = "Load Project";
            btnLoadProject.UseVisualStyleBackColor = true;
            btnLoadProject.Click += btnLoadProject_Click;
            // 
            // lblProjectPath
            // 
            lblProjectPath.Location = new Point(108, 12);
            lblProjectPath.Name = "lblProjectPath";
            lblProjectPath.Size = new Size(760, 29);
            lblProjectPath.TabIndex = 1;
            lblProjectPath.Text = "No Project Loaded";
            lblProjectPath.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // OpenTOASTprojectDialog
            // 
            OpenTOASTprojectDialog.FileName = "Select Location of TOAST project file .tsproj";
            OpenTOASTprojectDialog.Filter = "TOAST TwinCAT3 Project (*.tsproj)|*.tsproj";
            // 
            // tvStation1
            // 
            tvStation1.Location = new Point(6, 121);
            tvStation1.Name = "tvStation1";
            tvStation1.Size = new Size(843, 172);
            tvStation1.TabIndex = 2;
            // 
            // lstbxStation1Files
            // 
            lstbxStation1Files.FormattingEnabled = true;
            lstbxStation1Files.Location = new Point(6, 6);
            lstbxStation1Files.Name = "lstbxStation1Files";
            lstbxStation1Files.Size = new Size(843, 109);
            lstbxStation1Files.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Location = new Point(19, 47);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(863, 349);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tvStation1);
            tabPage1.Controls.Add(lstbxStation1Files);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(855, 321);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tvStation2);
            tabPage2.Controls.Add(lstbxStation2Files);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(855, 321);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tvStation2
            // 
            tvStation2.Location = new Point(6, 132);
            tvStation2.Name = "tvStation2";
            tvStation2.Size = new Size(843, 172);
            tvStation2.TabIndex = 4;
            // 
            // lstbxStation2Files
            // 
            lstbxStation2Files.FormattingEnabled = true;
            lstbxStation2Files.Location = new Point(6, 17);
            lstbxStation2Files.Name = "lstbxStation2Files";
            lstbxStation2Files.Size = new Size(843, 109);
            lstbxStation2Files.TabIndex = 3;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tvStation3);
            tabPage3.Controls.Add(lstbxStation3Files);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(855, 321);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tvStation3
            // 
            tvStation3.Location = new Point(6, 132);
            tvStation3.Name = "tvStation3";
            tvStation3.Size = new Size(843, 172);
            tvStation3.TabIndex = 4;
            // 
            // lstbxStation3Files
            // 
            lstbxStation3Files.FormattingEnabled = true;
            lstbxStation3Files.Location = new Point(6, 17);
            lstbxStation3Files.Name = "lstbxStation3Files";
            lstbxStation3Files.Size = new Size(843, 109);
            lstbxStation3Files.TabIndex = 3;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(tvStation4);
            tabPage4.Controls.Add(lstbxStation4Files);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(855, 321);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tvStation4
            // 
            tvStation4.Location = new Point(6, 132);
            tvStation4.Name = "tvStation4";
            tvStation4.Size = new Size(843, 172);
            tvStation4.TabIndex = 6;
            // 
            // lstbxStation4Files
            // 
            lstbxStation4Files.FormattingEnabled = true;
            lstbxStation4Files.Location = new Point(6, 17);
            lstbxStation4Files.Name = "lstbxStation4Files";
            lstbxStation4Files.Size = new Size(843, 109);
            lstbxStation4Files.TabIndex = 5;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(tvStation5);
            tabPage5.Controls.Add(lstbxStation5Files);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(855, 321);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tvStation5
            // 
            tvStation5.Location = new Point(6, 132);
            tvStation5.Name = "tvStation5";
            tvStation5.Size = new Size(843, 172);
            tvStation5.TabIndex = 6;
            // 
            // lstbxStation5Files
            // 
            lstbxStation5Files.FormattingEnabled = true;
            lstbxStation5Files.Location = new Point(6, 17);
            lstbxStation5Files.Name = "lstbxStation5Files";
            lstbxStation5Files.Size = new Size(843, 109);
            lstbxStation5Files.TabIndex = 5;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(tvStation6);
            tabPage6.Controls.Add(lstbxStation6Files);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(855, 321);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "tabPage6";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // tvStation6
            // 
            tvStation6.Location = new Point(6, 132);
            tvStation6.Name = "tvStation6";
            tvStation6.Size = new Size(843, 172);
            tvStation6.TabIndex = 6;
            // 
            // lstbxStation6Files
            // 
            lstbxStation6Files.FormattingEnabled = true;
            lstbxStation6Files.Location = new Point(6, 17);
            lstbxStation6Files.Name = "lstbxStation6Files";
            lstbxStation6Files.Size = new Size(843, 109);
            lstbxStation6Files.TabIndex = 5;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 450);
            Controls.Add(tabControl1);
            Controls.Add(lblProjectPath);
            Controls.Add(btnLoadProject);
            Name = "frmMain";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadProject;
        private Label lblProjectPath;
        private OpenFileDialog OpenTOASTprojectDialog;
        private ListBox lstbxStation1Files;
        private TreeView tvStation1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TreeView tvStation2;
        private ListBox lstbxStation2Files;
        private TabPage tabPage3;
        private TreeView tvStation3;
        private ListBox lstbxStation3Files;
        private TabPage tabPage4;
        private TreeView tvStation4;
        private ListBox lstbxStation4Files;
        private TabPage tabPage5;
        private TreeView tvStation5;
        private ListBox lstbxStation5Files;
        private TabPage tabPage6;
        private TreeView tvStation6;
        private ListBox lstbxStation6Files;
    }
}
