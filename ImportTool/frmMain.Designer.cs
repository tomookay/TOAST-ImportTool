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
            tabStations = new TabControl();
            tabPage1 = new TabPage();
            dgvStation1 = new DataGridView();
            clmNumber = new DataGridViewTextBoxColumn();
            clmText = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            dgvStation2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            tvStation2 = new TreeView();
            lstbxStation2Files = new ListBox();
            tabPage3 = new TabPage();
            dgvStation3 = new DataGridView();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            tvStation3 = new TreeView();
            lstbxStation3Files = new ListBox();
            tabPage4 = new TabPage();
            dgvStation4 = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            tvStation4 = new TreeView();
            lstbxStation4Files = new ListBox();
            tabPage5 = new TabPage();
            dgvStation5 = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            tvStation5 = new TreeView();
            lstbxStation5Files = new ListBox();
            tabPage6 = new TabPage();
            dgvStation6 = new DataGridView();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            tvStation6 = new TreeView();
            lstbxStation6Files = new ListBox();
            btnExport = new Button();
            tabStations.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStation1).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStation2).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStation3).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStation4).BeginInit();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStation5).BeginInit();
            tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStation6).BeginInit();
            SuspendLayout();
            // 
            // btnLoadProject
            // 
            btnLoadProject.Location = new Point(12, 12);
            btnLoadProject.Name = "btnLoadProject";
            btnLoadProject.Size = new Size(90, 30);
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
            tvStation1.Location = new Point(6, 132);
            tvStation1.Name = "tvStation1";
            tvStation1.Size = new Size(843, 172);
            tvStation1.TabIndex = 2;
            // 
            // lstbxStation1Files
            // 
            lstbxStation1Files.FormattingEnabled = true;
            lstbxStation1Files.Location = new Point(6, 17);
            lstbxStation1Files.Name = "lstbxStation1Files";
            lstbxStation1Files.Size = new Size(843, 109);
            lstbxStation1Files.TabIndex = 1;
            // 
            // tabStations
            // 
            tabStations.Controls.Add(tabPage1);
            tabStations.Controls.Add(tabPage2);
            tabStations.Controls.Add(tabPage3);
            tabStations.Controls.Add(tabPage4);
            tabStations.Controls.Add(tabPage5);
            tabStations.Controls.Add(tabPage6);
            tabStations.Location = new Point(19, 47);
            tabStations.Name = "tabStations";
            tabStations.SelectedIndex = 0;
            tabStations.Size = new Size(863, 505);
            tabStations.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvStation1);
            tabPage1.Controls.Add(tvStation1);
            tabPage1.Controls.Add(lstbxStation1Files);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(855, 477);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Station 1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvStation1
            // 
            dgvStation1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStation1.Columns.AddRange(new DataGridViewColumn[] { clmNumber, clmText });
            dgvStation1.Location = new Point(6, 310);
            dgvStation1.Name = "dgvStation1";
            dgvStation1.Size = new Size(843, 158);
            dgvStation1.TabIndex = 3;
            // 
            // clmNumber
            // 
            clmNumber.HeaderText = "Number";
            clmNumber.Name = "clmNumber";
            // 
            // clmText
            // 
            clmText.HeaderText = "Text";
            clmText.Name = "clmText";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvStation2);
            tabPage2.Controls.Add(tvStation2);
            tabPage2.Controls.Add(lstbxStation2Files);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(855, 477);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Station 2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvStation2
            // 
            dgvStation2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStation2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgvStation2.Location = new Point(6, 310);
            dgvStation2.Name = "dgvStation2";
            dgvStation2.Size = new Size(843, 158);
            dgvStation2.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Number";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Text";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
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
            tabPage3.Controls.Add(dgvStation3);
            tabPage3.Controls.Add(tvStation3);
            tabPage3.Controls.Add(lstbxStation3Files);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(855, 477);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Station 3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvStation3
            // 
            dgvStation3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStation3.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvStation3.Location = new Point(6, 310);
            dgvStation3.Name = "dgvStation3";
            dgvStation3.Size = new Size(843, 158);
            dgvStation3.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Number";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Text";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
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
            tabPage4.Controls.Add(dgvStation4);
            tabPage4.Controls.Add(tvStation4);
            tabPage4.Controls.Add(lstbxStation4Files);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(855, 477);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Station 4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvStation4
            // 
            dgvStation4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStation4.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dgvStation4.Location = new Point(6, 310);
            dgvStation4.Name = "dgvStation4";
            dgvStation4.Size = new Size(843, 158);
            dgvStation4.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Number";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Text";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
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
            tabPage5.Controls.Add(dgvStation5);
            tabPage5.Controls.Add(tvStation5);
            tabPage5.Controls.Add(lstbxStation5Files);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(855, 477);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Station 5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvStation5
            // 
            dgvStation5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStation5.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8 });
            dgvStation5.Location = new Point(6, 310);
            dgvStation5.Name = "dgvStation5";
            dgvStation5.Size = new Size(843, 158);
            dgvStation5.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Number";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Text";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
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
            tabPage6.Controls.Add(dgvStation6);
            tabPage6.Controls.Add(tvStation6);
            tabPage6.Controls.Add(lstbxStation6Files);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(855, 477);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Station 6";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // dgvStation6
            // 
            dgvStation6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStation6.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10 });
            dgvStation6.Location = new Point(6, 310);
            dgvStation6.Name = "dgvStation6";
            dgvStation6.Size = new Size(843, 158);
            dgvStation6.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Number";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.HeaderText = "Text";
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
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
            // btnExport
            // 
            btnExport.Location = new Point(12, 558);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(202, 30);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export to MotionRowText.TcTLO";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 607);
            Controls.Add(btnExport);
            Controls.Add(tabStations);
            Controls.Add(lblProjectPath);
            Controls.Add(btnLoadProject);
            Name = "frmMain";
            Text = "Sx_01_Motion_xx.TcPOU-2-MotionRowText.TcTLO Importer";
            tabStations.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStation1).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStation2).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStation3).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStation4).EndInit();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStation5).EndInit();
            tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStation6).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadProject;
        private Label lblProjectPath;
        private OpenFileDialog OpenTOASTprojectDialog;
        private ListBox lstbxStation1Files;
        private TreeView tvStation1;
        private TabControl tabStations;
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
        private DataGridView dgvStation1;
        private DataGridViewTextBoxColumn clmNumber;
        private DataGridViewTextBoxColumn clmText;
        private DataGridView dgvStation2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridView dgvStation3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridView dgvStation4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridView dgvStation5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridView dgvStation6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private Button btnExport;
    }
}
