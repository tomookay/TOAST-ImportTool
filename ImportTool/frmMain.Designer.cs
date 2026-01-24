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
            tabContStationLoading = new TabControl();
            tpStation1 = new TabPage();
            tpStation2 = new TabPage();
            tpStation3 = new TabPage();
            tpStation4 = new TabPage();
            tpStation5 = new TabPage();
            tpStation6 = new TabPage();
            lstbxStation2Files = new ListBox();
            lstbxStation3Files = new ListBox();
            lstbxStation4Files = new ListBox();
            lstbxStation5Files = new ListBox();
            lstbxStation6Files = new ListBox();
            lstbxStation1Files = new ListBox();
            tabContStationLoading.SuspendLayout();
            tpStation1.SuspendLayout();
            tpStation2.SuspendLayout();
            tpStation3.SuspendLayout();
            tpStation4.SuspendLayout();
            tpStation5.SuspendLayout();
            tpStation6.SuspendLayout();
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
            lblProjectPath.Size = new Size(578, 29);
            lblProjectPath.TabIndex = 1;
            lblProjectPath.Text = "No Project Loaded";
            lblProjectPath.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // OpenTOASTprojectDialog
            // 
            OpenTOASTprojectDialog.FileName = "Select Location of TOAST project file .tsproj";
            OpenTOASTprojectDialog.Filter = "TOAST TwinCAT3 Project (*.tsproj)|*.tsproj";
            // 
            // tabContStationLoading
            // 
            tabContStationLoading.Controls.Add(tpStation1);
            tabContStationLoading.Controls.Add(tpStation2);
            tabContStationLoading.Controls.Add(tpStation3);
            tabContStationLoading.Controls.Add(tpStation4);
            tabContStationLoading.Controls.Add(tpStation5);
            tabContStationLoading.Controls.Add(tpStation6);
            tabContStationLoading.Location = new Point(61, 101);
            tabContStationLoading.Name = "tabContStationLoading";
            tabContStationLoading.SelectedIndex = 0;
            tabContStationLoading.Size = new Size(648, 259);
            tabContStationLoading.TabIndex = 2;
            // 
            // tpStation1
            // 
            tpStation1.Controls.Add(lstbxStation1Files);
            tpStation1.Location = new Point(4, 24);
            tpStation1.Name = "tpStation1";
            tpStation1.Padding = new Padding(3);
            tpStation1.Size = new Size(640, 231);
            tpStation1.TabIndex = 0;
            tpStation1.Text = "Station 1";
            tpStation1.UseVisualStyleBackColor = true;
            // 
            // tpStation2
            // 
            tpStation2.Controls.Add(lstbxStation2Files);
            tpStation2.Location = new Point(4, 24);
            tpStation2.Name = "tpStation2";
            tpStation2.Padding = new Padding(3);
            tpStation2.Size = new Size(640, 231);
            tpStation2.TabIndex = 1;
            tpStation2.Text = "Station 2";
            tpStation2.UseVisualStyleBackColor = true;
            // 
            // tpStation3
            // 
            tpStation3.Controls.Add(lstbxStation3Files);
            tpStation3.Location = new Point(4, 24);
            tpStation3.Name = "tpStation3";
            tpStation3.Padding = new Padding(3);
            tpStation3.Size = new Size(640, 231);
            tpStation3.TabIndex = 2;
            tpStation3.Text = "Station 3";
            tpStation3.UseVisualStyleBackColor = true;
            // 
            // tpStation4
            // 
            tpStation4.Controls.Add(lstbxStation4Files);
            tpStation4.Location = new Point(4, 24);
            tpStation4.Name = "tpStation4";
            tpStation4.Padding = new Padding(3);
            tpStation4.Size = new Size(640, 231);
            tpStation4.TabIndex = 3;
            tpStation4.Text = "Station 4";
            tpStation4.UseVisualStyleBackColor = true;
            // 
            // tpStation5
            // 
            tpStation5.Controls.Add(lstbxStation5Files);
            tpStation5.Location = new Point(4, 24);
            tpStation5.Name = "tpStation5";
            tpStation5.Padding = new Padding(3);
            tpStation5.Size = new Size(640, 231);
            tpStation5.TabIndex = 4;
            tpStation5.Text = "Station 5";
            tpStation5.UseVisualStyleBackColor = true;
            // 
            // tpStation6
            // 
            tpStation6.Controls.Add(lstbxStation6Files);
            tpStation6.Location = new Point(4, 24);
            tpStation6.Name = "tpStation6";
            tpStation6.Padding = new Padding(3);
            tpStation6.Size = new Size(640, 231);
            tpStation6.TabIndex = 5;
            tpStation6.Text = "Station 6";
            tpStation6.UseVisualStyleBackColor = true;
            // 
            // lstbxStation2Files
            // 
            lstbxStation2Files.FormattingEnabled = true;
            lstbxStation2Files.Location = new Point(44, 68);
            lstbxStation2Files.Name = "lstbxStation2Files";
            lstbxStation2Files.Size = new Size(553, 94);
            lstbxStation2Files.TabIndex = 1;
            // 
            // lstbxStation3Files
            // 
            lstbxStation3Files.FormattingEnabled = true;
            lstbxStation3Files.Location = new Point(44, 68);
            lstbxStation3Files.Name = "lstbxStation3Files";
            lstbxStation3Files.Size = new Size(553, 94);
            lstbxStation3Files.TabIndex = 1;
            // 
            // lstbxStation4Files
            // 
            lstbxStation4Files.FormattingEnabled = true;
            lstbxStation4Files.Location = new Point(44, 68);
            lstbxStation4Files.Name = "lstbxStation4Files";
            lstbxStation4Files.Size = new Size(553, 94);
            lstbxStation4Files.TabIndex = 1;
            // 
            // lstbxStation5Files
            // 
            lstbxStation5Files.FormattingEnabled = true;
            lstbxStation5Files.Location = new Point(44, 68);
            lstbxStation5Files.Name = "lstbxStation5Files";
            lstbxStation5Files.Size = new Size(553, 94);
            lstbxStation5Files.TabIndex = 1;
            // 
            // lstbxStation6Files
            // 
            lstbxStation6Files.FormattingEnabled = true;
            lstbxStation6Files.Location = new Point(44, 68);
            lstbxStation6Files.Name = "lstbxStation6Files";
            lstbxStation6Files.Size = new Size(553, 94);
            lstbxStation6Files.TabIndex = 1;
            // 
            // lstbxStation1Files
            // 
            lstbxStation1Files.FormattingEnabled = true;
            lstbxStation1Files.Location = new Point(44, 68);
            lstbxStation1Files.Name = "lstbxStation1Files";
            lstbxStation1Files.Size = new Size(553, 94);
            lstbxStation1Files.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabContStationLoading);
            Controls.Add(lblProjectPath);
            Controls.Add(btnLoadProject);
            Name = "frmMain";
            Text = "Form1";
            tabContStationLoading.ResumeLayout(false);
            tpStation1.ResumeLayout(false);
            tpStation2.ResumeLayout(false);
            tpStation3.ResumeLayout(false);
            tpStation4.ResumeLayout(false);
            tpStation5.ResumeLayout(false);
            tpStation6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadProject;
        private Label lblProjectPath;
        private OpenFileDialog OpenTOASTprojectDialog;
        private TabControl tabContStationLoading;
        private TabPage tpStation1;
        private TabPage tpStation2;
        private TabPage tpStation3;
        private TabPage tpStation4;
        private TabPage tpStation5;
        private TabPage tpStation6;
        private ListBox lstbxStation1Files;
        private ListBox lstbxStation2Files;
        private ListBox lstbxStation3Files;
        private ListBox lstbxStation4Files;
        private ListBox lstbxStation5Files;
        private ListBox lstbxStation6Files;
    }
}
