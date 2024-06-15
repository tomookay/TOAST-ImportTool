<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnOpenProject = New System.Windows.Forms.Button()
        Me.OpenTOASTprojectDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lblProjectPath = New System.Windows.Forms.Label()
        Me.grpBoxSelectProject = New System.Windows.Forms.GroupBox()
        Me.btnCloseProject = New System.Windows.Forms.Button()
        Me.lblRawProjectPath = New System.Windows.Forms.Label()
        Me.grpboxMotionRow = New System.Windows.Forms.GroupBox()
        Me.lblRowNumber = New System.Windows.Forms.Label()
        Me.lblStnNumber = New System.Windows.Forms.Label()
        Me.btnAdv = New System.Windows.Forms.Button()
        Me.btnRet = New System.Windows.Forms.Button()
        Me.lblMotionNameSym = New System.Windows.Forms.Label()
        Me.lblMotionNameAbs = New System.Windows.Forms.Label()
        Me.lblReturnDepthSym = New System.Windows.Forms.Label()
        Me.lblReturnCoilSym = New System.Windows.Forms.Label()
        Me.lblReturnDepthAbs = New System.Windows.Forms.Label()
        Me.lblReturnCoilAbs = New System.Windows.Forms.Label()
        Me.lblAdvanceDepthSym = New System.Windows.Forms.Label()
        Me.lblAdvanceCoilSym = New System.Windows.Forms.Label()
        Me.lblAdvanceDepthAbs = New System.Windows.Forms.Label()
        Me.lblAdvanceCoilAbs = New System.Windows.Forms.Label()
        Me.cbS1 = New System.Windows.Forms.CheckBox()
        Me.cbS2 = New System.Windows.Forms.CheckBox()
        Me.cbS3 = New System.Windows.Forms.CheckBox()
        Me.cbS4 = New System.Windows.Forms.CheckBox()
        Me.cbS5 = New System.Windows.Forms.CheckBox()
        Me.cbS6 = New System.Windows.Forms.CheckBox()
        Me.cbAllStns = New System.Windows.Forms.CheckBox()
        Me.tabContStationLoading = New System.Windows.Forms.TabControl()
        Me.Station1 = New System.Windows.Forms.TabPage()
        Me.lstbxStation1Files = New System.Windows.Forms.ListBox()
        Me.lstbxRow1Data = New System.Windows.Forms.ListBox()
        Me.Station2 = New System.Windows.Forms.TabPage()
        Me.lstbxStation2Files = New System.Windows.Forms.ListBox()
        Me.lstbxRow2Data = New System.Windows.Forms.ListBox()
        Me.Station3 = New System.Windows.Forms.TabPage()
        Me.lstbxStation3Files = New System.Windows.Forms.ListBox()
        Me.lstbxRow3Data = New System.Windows.Forms.ListBox()
        Me.Station4 = New System.Windows.Forms.TabPage()
        Me.lstbxStation4Files = New System.Windows.Forms.ListBox()
        Me.lstbxRow4Data = New System.Windows.Forms.ListBox()
        Me.Station5 = New System.Windows.Forms.TabPage()
        Me.lstbxStation5Files = New System.Windows.Forms.ListBox()
        Me.lstbxRow5Data = New System.Windows.Forms.ListBox()
        Me.Station6 = New System.Windows.Forms.TabPage()
        Me.lstbxStation6Files = New System.Windows.Forms.ListBox()
        Me.lstbxRow6Data = New System.Windows.Forms.ListBox()
        Me.grpboxParse = New System.Windows.Forms.GroupBox()
        Me.lblMotionTextsPathName = New System.Windows.Forms.Label()
        Me.lblMotionTextsFileSize = New System.Windows.Forms.Label()
        Me.lblCONSTsFileSize = New System.Windows.Forms.Label()
        Me.lblCONTsPathName = New System.Windows.Forms.Label()
        Me.lblgNumberElementsPerRow = New System.Windows.Forms.Label()
        Me.tabControlTasks = New System.Windows.Forms.TabControl()
        Me.tabImport = New System.Windows.Forms.TabPage()
        Me.tabViewData = New System.Windows.Forms.TabPage()
        Me.btnUpdateArray = New System.Windows.Forms.Button()
        Me.lblPLCDataNumSelected = New System.Windows.Forms.Label()
        Me.lblImportBoxSelectionNum = New System.Windows.Forms.Label()
        Me.lblMotionFilesPath = New System.Windows.Forms.Label()
        Me.lblPLCdataFilePath = New System.Windows.Forms.Label()
        Me.lstBoxPLCData = New System.Windows.Forms.ListBox()
        Me.lstBoxImportData = New System.Windows.Forms.ListBox()
        Me.tabExportData = New System.Windows.Forms.TabPage()
        Me.grpBoxSelectProject.SuspendLayout()
        Me.grpboxMotionRow.SuspendLayout()
        Me.tabContStationLoading.SuspendLayout()
        Me.Station1.SuspendLayout()
        Me.Station2.SuspendLayout()
        Me.Station3.SuspendLayout()
        Me.Station4.SuspendLayout()
        Me.Station5.SuspendLayout()
        Me.Station6.SuspendLayout()
        Me.grpboxParse.SuspendLayout()
        Me.tabControlTasks.SuspendLayout()
        Me.tabImport.SuspendLayout()
        Me.tabViewData.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpenProject
        '
        Me.btnOpenProject.Location = New System.Drawing.Point(9, 19)
        Me.btnOpenProject.Name = "btnOpenProject"
        Me.btnOpenProject.Size = New System.Drawing.Size(97, 29)
        Me.btnOpenProject.TabIndex = 0
        Me.btnOpenProject.Text = "Open Project"
        Me.btnOpenProject.UseVisualStyleBackColor = True
        '
        'OpenTOASTprojectDialog
        '
        Me.OpenTOASTprojectDialog.DefaultExt = "*.tsproj"
        Me.OpenTOASTprojectDialog.FileName = "Select Location of TOAST project file .tsproj"
        Me.OpenTOASTprojectDialog.RestoreDirectory = True
        '
        'lblProjectPath
        '
        Me.lblProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProjectPath.Location = New System.Drawing.Point(113, 19)
        Me.lblProjectPath.Name = "lblProjectPath"
        Me.lblProjectPath.Size = New System.Drawing.Size(589, 29)
        Me.lblProjectPath.TabIndex = 1
        Me.lblProjectPath.Text = "No Project Selected....."
        Me.lblProjectPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpBoxSelectProject
        '
        Me.grpBoxSelectProject.Controls.Add(Me.btnCloseProject)
        Me.grpBoxSelectProject.Controls.Add(Me.lblProjectPath)
        Me.grpBoxSelectProject.Controls.Add(Me.btnOpenProject)
        Me.grpBoxSelectProject.Controls.Add(Me.lblRawProjectPath)
        Me.grpBoxSelectProject.Location = New System.Drawing.Point(12, 12)
        Me.grpBoxSelectProject.Name = "grpBoxSelectProject"
        Me.grpBoxSelectProject.Size = New System.Drawing.Size(724, 96)
        Me.grpBoxSelectProject.TabIndex = 2
        Me.grpBoxSelectProject.TabStop = False
        Me.grpBoxSelectProject.Text = "Select Project...."
        '
        'btnCloseProject
        '
        Me.btnCloseProject.Location = New System.Drawing.Point(9, 52)
        Me.btnCloseProject.Name = "btnCloseProject"
        Me.btnCloseProject.Size = New System.Drawing.Size(97, 29)
        Me.btnCloseProject.TabIndex = 2
        Me.btnCloseProject.Text = "Close Project"
        Me.btnCloseProject.UseVisualStyleBackColor = True
        '
        'lblRawProjectPath
        '
        Me.lblRawProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRawProjectPath.Location = New System.Drawing.Point(112, 53)
        Me.lblRawProjectPath.Name = "lblRawProjectPath"
        Me.lblRawProjectPath.Size = New System.Drawing.Size(590, 28)
        Me.lblRawProjectPath.TabIndex = 2
        Me.lblRawProjectPath.Text = "No Raw Project Path...."
        Me.lblRawProjectPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpboxMotionRow
        '
        Me.grpboxMotionRow.Controls.Add(Me.lblRowNumber)
        Me.grpboxMotionRow.Controls.Add(Me.lblStnNumber)
        Me.grpboxMotionRow.Controls.Add(Me.btnAdv)
        Me.grpboxMotionRow.Controls.Add(Me.btnRet)
        Me.grpboxMotionRow.Controls.Add(Me.lblMotionNameSym)
        Me.grpboxMotionRow.Controls.Add(Me.lblMotionNameAbs)
        Me.grpboxMotionRow.Controls.Add(Me.lblReturnDepthSym)
        Me.grpboxMotionRow.Controls.Add(Me.lblReturnCoilSym)
        Me.grpboxMotionRow.Controls.Add(Me.lblReturnDepthAbs)
        Me.grpboxMotionRow.Controls.Add(Me.lblReturnCoilAbs)
        Me.grpboxMotionRow.Controls.Add(Me.lblAdvanceDepthSym)
        Me.grpboxMotionRow.Controls.Add(Me.lblAdvanceCoilSym)
        Me.grpboxMotionRow.Controls.Add(Me.lblAdvanceDepthAbs)
        Me.grpboxMotionRow.Controls.Add(Me.lblAdvanceCoilAbs)
        Me.grpboxMotionRow.Location = New System.Drawing.Point(9, 228)
        Me.grpboxMotionRow.Name = "grpboxMotionRow"
        Me.grpboxMotionRow.Size = New System.Drawing.Size(663, 171)
        Me.grpboxMotionRow.TabIndex = 6
        Me.grpboxMotionRow.TabStop = False
        Me.grpboxMotionRow.Text = "Motion Row Sample"
        '
        'lblRowNumber
        '
        Me.lblRowNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRowNumber.Location = New System.Drawing.Point(285, 126)
        Me.lblRowNumber.Name = "lblRowNumber"
        Me.lblRowNumber.Size = New System.Drawing.Size(91, 27)
        Me.lblRowNumber.TabIndex = 13
        Me.lblRowNumber.Text = "RowNum"
        Me.lblRowNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStnNumber
        '
        Me.lblStnNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStnNumber.Location = New System.Drawing.Point(285, 94)
        Me.lblStnNumber.Name = "lblStnNumber"
        Me.lblStnNumber.Size = New System.Drawing.Size(91, 27)
        Me.lblStnNumber.TabIndex = 12
        Me.lblStnNumber.Text = "stnNum"
        Me.lblStnNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAdv
        '
        Me.btnAdv.Location = New System.Drawing.Point(9, 19)
        Me.btnAdv.Name = "btnAdv"
        Me.btnAdv.Size = New System.Drawing.Size(58, 138)
        Me.btnAdv.TabIndex = 11
        Me.btnAdv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdv.UseVisualStyleBackColor = True
        '
        'btnRet
        '
        Me.btnRet.Location = New System.Drawing.Point(588, 20)
        Me.btnRet.Name = "btnRet"
        Me.btnRet.Size = New System.Drawing.Size(58, 137)
        Me.btnRet.TabIndex = 10
        Me.btnRet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRet.UseVisualStyleBackColor = True
        '
        'lblMotionNameSym
        '
        Me.lblMotionNameSym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMotionNameSym.Location = New System.Drawing.Point(246, 56)
        Me.lblMotionNameSym.Name = "lblMotionNameSym"
        Me.lblMotionNameSym.Size = New System.Drawing.Size(165, 27)
        Me.lblMotionNameSym.TabIndex = 9
        Me.lblMotionNameSym.Text = "Motion Name Sym"
        Me.lblMotionNameSym.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMotionNameAbs
        '
        Me.lblMotionNameAbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMotionNameAbs.Location = New System.Drawing.Point(246, 20)
        Me.lblMotionNameAbs.Name = "lblMotionNameAbs"
        Me.lblMotionNameAbs.Size = New System.Drawing.Size(165, 27)
        Me.lblMotionNameAbs.TabIndex = 8
        Me.lblMotionNameAbs.Text = "Motion Name abs"
        Me.lblMotionNameAbs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblReturnDepthSym
        '
        Me.lblReturnDepthSym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReturnDepthSym.Location = New System.Drawing.Point(417, 130)
        Me.lblReturnDepthSym.Name = "lblReturnDepthSym"
        Me.lblReturnDepthSym.Size = New System.Drawing.Size(165, 27)
        Me.lblReturnDepthSym.TabIndex = 7
        Me.lblReturnDepthSym.Text = "Return Depth Sym"
        Me.lblReturnDepthSym.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReturnCoilSym
        '
        Me.lblReturnCoilSym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReturnCoilSym.Location = New System.Drawing.Point(417, 94)
        Me.lblReturnCoilSym.Name = "lblReturnCoilSym"
        Me.lblReturnCoilSym.Size = New System.Drawing.Size(165, 27)
        Me.lblReturnCoilSym.TabIndex = 6
        Me.lblReturnCoilSym.Text = "Return Coil Sym"
        Me.lblReturnCoilSym.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblReturnCoilSym.UseMnemonic = False
        '
        'lblReturnDepthAbs
        '
        Me.lblReturnDepthAbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReturnDepthAbs.Location = New System.Drawing.Point(417, 56)
        Me.lblReturnDepthAbs.Name = "lblReturnDepthAbs"
        Me.lblReturnDepthAbs.Size = New System.Drawing.Size(165, 27)
        Me.lblReturnDepthAbs.TabIndex = 5
        Me.lblReturnDepthAbs.Text = "Return Depth abs"
        Me.lblReturnDepthAbs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblReturnCoilAbs
        '
        Me.lblReturnCoilAbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblReturnCoilAbs.Location = New System.Drawing.Point(417, 20)
        Me.lblReturnCoilAbs.Name = "lblReturnCoilAbs"
        Me.lblReturnCoilAbs.Size = New System.Drawing.Size(165, 27)
        Me.lblReturnCoilAbs.TabIndex = 4
        Me.lblReturnCoilAbs.Text = "Return Coil abs"
        Me.lblReturnCoilAbs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAdvanceDepthSym
        '
        Me.lblAdvanceDepthSym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAdvanceDepthSym.Location = New System.Drawing.Point(70, 130)
        Me.lblAdvanceDepthSym.Name = "lblAdvanceDepthSym"
        Me.lblAdvanceDepthSym.Size = New System.Drawing.Size(165, 27)
        Me.lblAdvanceDepthSym.TabIndex = 3
        Me.lblAdvanceDepthSym.Text = "Advance Depth Sym"
        Me.lblAdvanceDepthSym.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdvanceCoilSym
        '
        Me.lblAdvanceCoilSym.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAdvanceCoilSym.Location = New System.Drawing.Point(70, 94)
        Me.lblAdvanceCoilSym.Name = "lblAdvanceCoilSym"
        Me.lblAdvanceCoilSym.Size = New System.Drawing.Size(165, 27)
        Me.lblAdvanceCoilSym.TabIndex = 2
        Me.lblAdvanceCoilSym.Text = "Advance Coil Sym"
        Me.lblAdvanceCoilSym.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAdvanceCoilSym.UseMnemonic = False
        '
        'lblAdvanceDepthAbs
        '
        Me.lblAdvanceDepthAbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAdvanceDepthAbs.Location = New System.Drawing.Point(70, 56)
        Me.lblAdvanceDepthAbs.Name = "lblAdvanceDepthAbs"
        Me.lblAdvanceDepthAbs.Size = New System.Drawing.Size(165, 27)
        Me.lblAdvanceDepthAbs.TabIndex = 1
        Me.lblAdvanceDepthAbs.Text = "Advance Depth abs"
        Me.lblAdvanceDepthAbs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdvanceCoilAbs
        '
        Me.lblAdvanceCoilAbs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAdvanceCoilAbs.Location = New System.Drawing.Point(70, 20)
        Me.lblAdvanceCoilAbs.Name = "lblAdvanceCoilAbs"
        Me.lblAdvanceCoilAbs.Size = New System.Drawing.Size(165, 27)
        Me.lblAdvanceCoilAbs.TabIndex = 0
        Me.lblAdvanceCoilAbs.Text = "Advance Coil abs"
        Me.lblAdvanceCoilAbs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbS1
        '
        Me.cbS1.AutoSize = True
        Me.cbS1.Checked = True
        Me.cbS1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbS1.Location = New System.Drawing.Point(37, 19)
        Me.cbS1.Name = "cbS1"
        Me.cbS1.Size = New System.Drawing.Size(68, 17)
        Me.cbS1.TabIndex = 7
        Me.cbS1.Text = "Station 1"
        Me.cbS1.UseVisualStyleBackColor = True
        '
        'cbS2
        '
        Me.cbS2.AutoSize = True
        Me.cbS2.Checked = True
        Me.cbS2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbS2.Location = New System.Drawing.Point(111, 19)
        Me.cbS2.Name = "cbS2"
        Me.cbS2.Size = New System.Drawing.Size(68, 17)
        Me.cbS2.TabIndex = 8
        Me.cbS2.Text = "Station 2"
        Me.cbS2.UseVisualStyleBackColor = True
        '
        'cbS3
        '
        Me.cbS3.AutoSize = True
        Me.cbS3.Checked = True
        Me.cbS3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbS3.Location = New System.Drawing.Point(185, 19)
        Me.cbS3.Name = "cbS3"
        Me.cbS3.Size = New System.Drawing.Size(68, 17)
        Me.cbS3.TabIndex = 9
        Me.cbS3.Text = "Station 3"
        Me.cbS3.UseVisualStyleBackColor = True
        '
        'cbS4
        '
        Me.cbS4.AutoSize = True
        Me.cbS4.Checked = True
        Me.cbS4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbS4.Location = New System.Drawing.Point(259, 19)
        Me.cbS4.Name = "cbS4"
        Me.cbS4.Size = New System.Drawing.Size(68, 17)
        Me.cbS4.TabIndex = 10
        Me.cbS4.Text = "Station 4"
        Me.cbS4.UseVisualStyleBackColor = True
        '
        'cbS5
        '
        Me.cbS5.AutoSize = True
        Me.cbS5.Checked = True
        Me.cbS5.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbS5.Location = New System.Drawing.Point(333, 19)
        Me.cbS5.Name = "cbS5"
        Me.cbS5.Size = New System.Drawing.Size(68, 17)
        Me.cbS5.TabIndex = 11
        Me.cbS5.Text = "Station 5"
        Me.cbS5.UseVisualStyleBackColor = True
        '
        'cbS6
        '
        Me.cbS6.AutoSize = True
        Me.cbS6.Checked = True
        Me.cbS6.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbS6.Location = New System.Drawing.Point(407, 19)
        Me.cbS6.Name = "cbS6"
        Me.cbS6.Size = New System.Drawing.Size(68, 17)
        Me.cbS6.TabIndex = 12
        Me.cbS6.Text = "Station 6"
        Me.cbS6.UseVisualStyleBackColor = True
        '
        'cbAllStns
        '
        Me.cbAllStns.AutoSize = True
        Me.cbAllStns.Location = New System.Drawing.Point(545, 19)
        Me.cbAllStns.Name = "cbAllStns"
        Me.cbAllStns.Size = New System.Drawing.Size(78, 17)
        Me.cbAllStns.TabIndex = 13
        Me.cbAllStns.Text = "All Stations"
        Me.cbAllStns.UseVisualStyleBackColor = True
        '
        'tabContStationLoading
        '
        Me.tabContStationLoading.Controls.Add(Me.Station1)
        Me.tabContStationLoading.Controls.Add(Me.Station2)
        Me.tabContStationLoading.Controls.Add(Me.Station3)
        Me.tabContStationLoading.Controls.Add(Me.Station4)
        Me.tabContStationLoading.Controls.Add(Me.Station5)
        Me.tabContStationLoading.Controls.Add(Me.Station6)
        Me.tabContStationLoading.Location = New System.Drawing.Point(9, 42)
        Me.tabContStationLoading.Name = "tabContStationLoading"
        Me.tabContStationLoading.SelectedIndex = 0
        Me.tabContStationLoading.Size = New System.Drawing.Size(663, 180)
        Me.tabContStationLoading.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabContStationLoading.TabIndex = 14
        '
        'Station1
        '
        Me.Station1.Controls.Add(Me.lstbxStation1Files)
        Me.Station1.Controls.Add(Me.lstbxRow1Data)
        Me.Station1.Location = New System.Drawing.Point(4, 22)
        Me.Station1.Name = "Station1"
        Me.Station1.Padding = New System.Windows.Forms.Padding(3)
        Me.Station1.Size = New System.Drawing.Size(655, 154)
        Me.Station1.TabIndex = 0
        Me.Station1.Text = "Station 1"
        Me.Station1.UseVisualStyleBackColor = True
        '
        'lstbxStation1Files
        '
        Me.lstbxStation1Files.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxStation1Files.FormattingEnabled = True
        Me.lstbxStation1Files.Location = New System.Drawing.Point(5, 5)
        Me.lstbxStation1Files.Name = "lstbxStation1Files"
        Me.lstbxStation1Files.ScrollAlwaysVisible = True
        Me.lstbxStation1Files.Size = New System.Drawing.Size(644, 82)
        Me.lstbxStation1Files.TabIndex = 8
        '
        'lstbxRow1Data
        '
        Me.lstbxRow1Data.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxRow1Data.FormattingEnabled = True
        Me.lstbxRow1Data.Location = New System.Drawing.Point(5, 94)
        Me.lstbxRow1Data.Name = "lstbxRow1Data"
        Me.lstbxRow1Data.ScrollAlwaysVisible = True
        Me.lstbxRow1Data.Size = New System.Drawing.Size(644, 56)
        Me.lstbxRow1Data.TabIndex = 9
        '
        'Station2
        '
        Me.Station2.Controls.Add(Me.lstbxStation2Files)
        Me.Station2.Controls.Add(Me.lstbxRow2Data)
        Me.Station2.Location = New System.Drawing.Point(4, 22)
        Me.Station2.Name = "Station2"
        Me.Station2.Padding = New System.Windows.Forms.Padding(3)
        Me.Station2.Size = New System.Drawing.Size(655, 154)
        Me.Station2.TabIndex = 1
        Me.Station2.Text = "Station 2"
        Me.Station2.UseVisualStyleBackColor = True
        '
        'lstbxStation2Files
        '
        Me.lstbxStation2Files.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxStation2Files.FormattingEnabled = True
        Me.lstbxStation2Files.Location = New System.Drawing.Point(5, 5)
        Me.lstbxStation2Files.Name = "lstbxStation2Files"
        Me.lstbxStation2Files.ScrollAlwaysVisible = True
        Me.lstbxStation2Files.Size = New System.Drawing.Size(644, 82)
        Me.lstbxStation2Files.TabIndex = 6
        '
        'lstbxRow2Data
        '
        Me.lstbxRow2Data.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxRow2Data.FormattingEnabled = True
        Me.lstbxRow2Data.Location = New System.Drawing.Point(5, 94)
        Me.lstbxRow2Data.Name = "lstbxRow2Data"
        Me.lstbxRow2Data.ScrollAlwaysVisible = True
        Me.lstbxRow2Data.Size = New System.Drawing.Size(644, 56)
        Me.lstbxRow2Data.TabIndex = 7
        '
        'Station3
        '
        Me.Station3.Controls.Add(Me.lstbxStation3Files)
        Me.Station3.Controls.Add(Me.lstbxRow3Data)
        Me.Station3.Location = New System.Drawing.Point(4, 22)
        Me.Station3.Name = "Station3"
        Me.Station3.Padding = New System.Windows.Forms.Padding(3)
        Me.Station3.Size = New System.Drawing.Size(655, 154)
        Me.Station3.TabIndex = 2
        Me.Station3.Text = "Station 3"
        Me.Station3.UseVisualStyleBackColor = True
        '
        'lstbxStation3Files
        '
        Me.lstbxStation3Files.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxStation3Files.FormattingEnabled = True
        Me.lstbxStation3Files.Location = New System.Drawing.Point(5, 5)
        Me.lstbxStation3Files.Name = "lstbxStation3Files"
        Me.lstbxStation3Files.ScrollAlwaysVisible = True
        Me.lstbxStation3Files.Size = New System.Drawing.Size(644, 82)
        Me.lstbxStation3Files.TabIndex = 6
        '
        'lstbxRow3Data
        '
        Me.lstbxRow3Data.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxRow3Data.FormattingEnabled = True
        Me.lstbxRow3Data.Location = New System.Drawing.Point(5, 94)
        Me.lstbxRow3Data.Name = "lstbxRow3Data"
        Me.lstbxRow3Data.ScrollAlwaysVisible = True
        Me.lstbxRow3Data.Size = New System.Drawing.Size(644, 56)
        Me.lstbxRow3Data.TabIndex = 7
        '
        'Station4
        '
        Me.Station4.Controls.Add(Me.lstbxStation4Files)
        Me.Station4.Controls.Add(Me.lstbxRow4Data)
        Me.Station4.Location = New System.Drawing.Point(4, 22)
        Me.Station4.Name = "Station4"
        Me.Station4.Padding = New System.Windows.Forms.Padding(3)
        Me.Station4.Size = New System.Drawing.Size(655, 154)
        Me.Station4.TabIndex = 3
        Me.Station4.Text = "Station 4"
        Me.Station4.UseVisualStyleBackColor = True
        '
        'lstbxStation4Files
        '
        Me.lstbxStation4Files.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxStation4Files.FormattingEnabled = True
        Me.lstbxStation4Files.Location = New System.Drawing.Point(5, 5)
        Me.lstbxStation4Files.Name = "lstbxStation4Files"
        Me.lstbxStation4Files.ScrollAlwaysVisible = True
        Me.lstbxStation4Files.Size = New System.Drawing.Size(644, 82)
        Me.lstbxStation4Files.TabIndex = 6
        '
        'lstbxRow4Data
        '
        Me.lstbxRow4Data.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxRow4Data.FormattingEnabled = True
        Me.lstbxRow4Data.Location = New System.Drawing.Point(5, 94)
        Me.lstbxRow4Data.Name = "lstbxRow4Data"
        Me.lstbxRow4Data.ScrollAlwaysVisible = True
        Me.lstbxRow4Data.Size = New System.Drawing.Size(644, 56)
        Me.lstbxRow4Data.TabIndex = 7
        '
        'Station5
        '
        Me.Station5.Controls.Add(Me.lstbxStation5Files)
        Me.Station5.Controls.Add(Me.lstbxRow5Data)
        Me.Station5.Location = New System.Drawing.Point(4, 22)
        Me.Station5.Name = "Station5"
        Me.Station5.Padding = New System.Windows.Forms.Padding(3)
        Me.Station5.Size = New System.Drawing.Size(655, 154)
        Me.Station5.TabIndex = 4
        Me.Station5.Text = "Station 5"
        Me.Station5.UseVisualStyleBackColor = True
        '
        'lstbxStation5Files
        '
        Me.lstbxStation5Files.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxStation5Files.FormattingEnabled = True
        Me.lstbxStation5Files.Location = New System.Drawing.Point(5, 5)
        Me.lstbxStation5Files.Name = "lstbxStation5Files"
        Me.lstbxStation5Files.ScrollAlwaysVisible = True
        Me.lstbxStation5Files.Size = New System.Drawing.Size(644, 82)
        Me.lstbxStation5Files.TabIndex = 6
        '
        'lstbxRow5Data
        '
        Me.lstbxRow5Data.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxRow5Data.FormattingEnabled = True
        Me.lstbxRow5Data.Location = New System.Drawing.Point(5, 94)
        Me.lstbxRow5Data.Name = "lstbxRow5Data"
        Me.lstbxRow5Data.ScrollAlwaysVisible = True
        Me.lstbxRow5Data.Size = New System.Drawing.Size(644, 56)
        Me.lstbxRow5Data.TabIndex = 7
        '
        'Station6
        '
        Me.Station6.Controls.Add(Me.lstbxStation6Files)
        Me.Station6.Controls.Add(Me.lstbxRow6Data)
        Me.Station6.Location = New System.Drawing.Point(4, 22)
        Me.Station6.Name = "Station6"
        Me.Station6.Padding = New System.Windows.Forms.Padding(3)
        Me.Station6.Size = New System.Drawing.Size(655, 154)
        Me.Station6.TabIndex = 5
        Me.Station6.Text = "Station 6"
        Me.Station6.UseVisualStyleBackColor = True
        '
        'lstbxStation6Files
        '
        Me.lstbxStation6Files.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxStation6Files.FormattingEnabled = True
        Me.lstbxStation6Files.Location = New System.Drawing.Point(5, 5)
        Me.lstbxStation6Files.Name = "lstbxStation6Files"
        Me.lstbxStation6Files.ScrollAlwaysVisible = True
        Me.lstbxStation6Files.Size = New System.Drawing.Size(644, 82)
        Me.lstbxStation6Files.TabIndex = 6
        '
        'lstbxRow6Data
        '
        Me.lstbxRow6Data.BackColor = System.Drawing.SystemColors.Control
        Me.lstbxRow6Data.FormattingEnabled = True
        Me.lstbxRow6Data.Location = New System.Drawing.Point(5, 94)
        Me.lstbxRow6Data.Name = "lstbxRow6Data"
        Me.lstbxRow6Data.ScrollAlwaysVisible = True
        Me.lstbxRow6Data.Size = New System.Drawing.Size(644, 56)
        Me.lstbxRow6Data.TabIndex = 7
        '
        'grpboxParse
        '
        Me.grpboxParse.Controls.Add(Me.tabContStationLoading)
        Me.grpboxParse.Controls.Add(Me.grpboxMotionRow)
        Me.grpboxParse.Controls.Add(Me.cbAllStns)
        Me.grpboxParse.Controls.Add(Me.cbS1)
        Me.grpboxParse.Controls.Add(Me.cbS6)
        Me.grpboxParse.Controls.Add(Me.cbS2)
        Me.grpboxParse.Controls.Add(Me.cbS5)
        Me.grpboxParse.Controls.Add(Me.cbS3)
        Me.grpboxParse.Controls.Add(Me.cbS4)
        Me.grpboxParse.Location = New System.Drawing.Point(26, 7)
        Me.grpboxParse.Name = "grpboxParse"
        Me.grpboxParse.Size = New System.Drawing.Size(682, 405)
        Me.grpboxParse.TabIndex = 15
        Me.grpboxParse.TabStop = False
        Me.grpboxParse.Text = "Parse Result"
        '
        'lblMotionTextsPathName
        '
        Me.lblMotionTextsPathName.AutoSize = True
        Me.lblMotionTextsPathName.Location = New System.Drawing.Point(28, 576)
        Me.lblMotionTextsPathName.Name = "lblMotionTextsPathName"
        Me.lblMotionTextsPathName.Size = New System.Drawing.Size(140, 13)
        Me.lblMotionTextsPathName.TabIndex = 16
        Me.lblMotionTextsPathName.Text = "Motion Texts File Not Found"
        '
        'lblMotionTextsFileSize
        '
        Me.lblMotionTextsFileSize.AutoSize = True
        Me.lblMotionTextsFileSize.Location = New System.Drawing.Point(574, 576)
        Me.lblMotionTextsFileSize.Name = "lblMotionTextsFileSize"
        Me.lblMotionTextsFileSize.Size = New System.Drawing.Size(43, 13)
        Me.lblMotionTextsFileSize.TabIndex = 17
        Me.lblMotionTextsFileSize.Text = "FileSize"
        '
        'lblCONSTsFileSize
        '
        Me.lblCONSTsFileSize.AutoSize = True
        Me.lblCONSTsFileSize.Location = New System.Drawing.Point(574, 589)
        Me.lblCONSTsFileSize.Name = "lblCONSTsFileSize"
        Me.lblCONSTsFileSize.Size = New System.Drawing.Size(43, 13)
        Me.lblCONSTsFileSize.TabIndex = 19
        Me.lblCONSTsFileSize.Text = "FileSize"
        '
        'lblCONTsPathName
        '
        Me.lblCONTsPathName.AutoSize = True
        Me.lblCONTsPathName.Location = New System.Drawing.Point(28, 589)
        Me.lblCONTsPathName.Name = "lblCONTsPathName"
        Me.lblCONTsPathName.Size = New System.Drawing.Size(121, 13)
        Me.lblCONTsPathName.TabIndex = 18
        Me.lblCONTsPathName.Text = "CONSTs File Not Found"
        '
        'lblgNumberElementsPerRow
        '
        Me.lblgNumberElementsPerRow.AutoSize = True
        Me.lblgNumberElementsPerRow.Location = New System.Drawing.Point(532, 602)
        Me.lblgNumberElementsPerRow.Name = "lblgNumberElementsPerRow"
        Me.lblgNumberElementsPerRow.Size = New System.Drawing.Size(143, 13)
        Me.lblgNumberElementsPerRow.TabIndex = 20
        Me.lblgNumberElementsPerRow.Text = "gNumberElementsPerRow=?"
        '
        'tabControlTasks
        '
        Me.tabControlTasks.Controls.Add(Me.tabImport)
        Me.tabControlTasks.Controls.Add(Me.tabViewData)
        Me.tabControlTasks.Controls.Add(Me.tabExportData)
        Me.tabControlTasks.Location = New System.Drawing.Point(12, 114)
        Me.tabControlTasks.Name = "tabControlTasks"
        Me.tabControlTasks.SelectedIndex = 0
        Me.tabControlTasks.Size = New System.Drawing.Size(728, 447)
        Me.tabControlTasks.TabIndex = 22
        '
        'tabImport
        '
        Me.tabImport.Controls.Add(Me.grpboxParse)
        Me.tabImport.Location = New System.Drawing.Point(4, 22)
        Me.tabImport.Name = "tabImport"
        Me.tabImport.Padding = New System.Windows.Forms.Padding(3)
        Me.tabImport.Size = New System.Drawing.Size(720, 421)
        Me.tabImport.TabIndex = 0
        Me.tabImport.Text = "Import Data"
        Me.tabImport.UseVisualStyleBackColor = True
        '
        'tabViewData
        '
        Me.tabViewData.Controls.Add(Me.btnUpdateArray)
        Me.tabViewData.Controls.Add(Me.lblPLCDataNumSelected)
        Me.tabViewData.Controls.Add(Me.lblImportBoxSelectionNum)
        Me.tabViewData.Controls.Add(Me.lblMotionFilesPath)
        Me.tabViewData.Controls.Add(Me.lblPLCdataFilePath)
        Me.tabViewData.Controls.Add(Me.lstBoxPLCData)
        Me.tabViewData.Controls.Add(Me.lstBoxImportData)
        Me.tabViewData.Location = New System.Drawing.Point(4, 22)
        Me.tabViewData.Name = "tabViewData"
        Me.tabViewData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabViewData.Size = New System.Drawing.Size(720, 421)
        Me.tabViewData.TabIndex = 1
        Me.tabViewData.Text = "View Data"
        Me.tabViewData.UseVisualStyleBackColor = True
        '
        'btnUpdateArray
        '
        Me.btnUpdateArray.Location = New System.Drawing.Point(561, 28)
        Me.btnUpdateArray.Name = "btnUpdateArray"
        Me.btnUpdateArray.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateArray.TabIndex = 6
        Me.btnUpdateArray.Text = "Update"
        Me.btnUpdateArray.UseVisualStyleBackColor = True
        '
        'lblPLCDataNumSelected
        '
        Me.lblPLCDataNumSelected.AutoSize = True
        Me.lblPLCDataNumSelected.Location = New System.Drawing.Point(260, 399)
        Me.lblPLCDataNumSelected.Name = "lblPLCDataNumSelected"
        Me.lblPLCDataNumSelected.Size = New System.Drawing.Size(13, 13)
        Me.lblPLCDataNumSelected.TabIndex = 5
        Me.lblPLCDataNumSelected.Text = "0"
        '
        'lblImportBoxSelectionNum
        '
        Me.lblImportBoxSelectionNum.AutoSize = True
        Me.lblImportBoxSelectionNum.Location = New System.Drawing.Point(21, 399)
        Me.lblImportBoxSelectionNum.Name = "lblImportBoxSelectionNum"
        Me.lblImportBoxSelectionNum.Size = New System.Drawing.Size(13, 13)
        Me.lblImportBoxSelectionNum.TabIndex = 4
        Me.lblImportBoxSelectionNum.Text = "0"
        '
        'lblMotionFilesPath
        '
        Me.lblMotionFilesPath.AutoSize = True
        Me.lblMotionFilesPath.Location = New System.Drawing.Point(260, 12)
        Me.lblMotionFilesPath.Name = "lblMotionFilesPath"
        Me.lblMotionFilesPath.Size = New System.Drawing.Size(55, 13)
        Me.lblMotionFilesPath.TabIndex = 3
        Me.lblMotionFilesPath.Text = "No Path..."
        '
        'lblPLCdataFilePath
        '
        Me.lblPLCdataFilePath.AutoSize = True
        Me.lblPLCdataFilePath.Location = New System.Drawing.Point(21, 12)
        Me.lblPLCdataFilePath.Name = "lblPLCdataFilePath"
        Me.lblPLCdataFilePath.Size = New System.Drawing.Size(55, 13)
        Me.lblPLCdataFilePath.TabIndex = 2
        Me.lblPLCdataFilePath.Text = "No Path..."
        '
        'lstBoxPLCData
        '
        Me.lstBoxPLCData.FormattingEnabled = True
        Me.lstBoxPLCData.IntegralHeight = False
        Me.lstBoxPLCData.Location = New System.Drawing.Point(263, 28)
        Me.lstBoxPLCData.Name = "lstBoxPLCData"
        Me.lstBoxPLCData.ScrollAlwaysVisible = True
        Me.lstBoxPLCData.Size = New System.Drawing.Size(247, 368)
        Me.lstBoxPLCData.TabIndex = 1
        '
        'lstBoxImportData
        '
        Me.lstBoxImportData.FormattingEnabled = True
        Me.lstBoxImportData.IntegralHeight = False
        Me.lstBoxImportData.Location = New System.Drawing.Point(24, 28)
        Me.lstBoxImportData.Name = "lstBoxImportData"
        Me.lstBoxImportData.ScrollAlwaysVisible = True
        Me.lstBoxImportData.Size = New System.Drawing.Size(224, 368)
        Me.lstBoxImportData.TabIndex = 0
        '
        'tabExportData
        '
        Me.tabExportData.Location = New System.Drawing.Point(4, 22)
        Me.tabExportData.Name = "tabExportData"
        Me.tabExportData.Size = New System.Drawing.Size(720, 421)
        Me.tabExportData.TabIndex = 2
        Me.tabExportData.Text = "Export Data"
        Me.tabExportData.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 628)
        Me.Controls.Add(Me.tabControlTasks)
        Me.Controls.Add(Me.lblgNumberElementsPerRow)
        Me.Controls.Add(Me.lblCONSTsFileSize)
        Me.Controls.Add(Me.lblCONTsPathName)
        Me.Controls.Add(Me.lblMotionTextsFileSize)
        Me.Controls.Add(Me.lblMotionTextsPathName)
        Me.Controls.Add(Me.grpBoxSelectProject)
        Me.Name = "frmMain"
        Me.Text = "TOAST Text Export Tool"
        Me.grpBoxSelectProject.ResumeLayout(False)
        Me.grpboxMotionRow.ResumeLayout(False)
        Me.tabContStationLoading.ResumeLayout(False)
        Me.Station1.ResumeLayout(False)
        Me.Station2.ResumeLayout(False)
        Me.Station3.ResumeLayout(False)
        Me.Station4.ResumeLayout(False)
        Me.Station5.ResumeLayout(False)
        Me.Station6.ResumeLayout(False)
        Me.grpboxParse.ResumeLayout(False)
        Me.grpboxParse.PerformLayout()
        Me.tabControlTasks.ResumeLayout(False)
        Me.tabImport.ResumeLayout(False)
        Me.tabViewData.ResumeLayout(False)
        Me.tabViewData.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOpenProject As Button
    Friend WithEvents OpenTOASTprojectDialog As OpenFileDialog
    Friend WithEvents lblProjectPath As Label
    Friend WithEvents grpBoxSelectProject As GroupBox
    Friend WithEvents lblRawProjectPath As Label
    Friend WithEvents grpboxMotionRow As GroupBox
    Public WithEvents lblAdvanceCoilAbs As Label
    Public WithEvents lblAdvanceDepthAbs As Label
    Public WithEvents lblAdvanceDepthSym As Label
    Public WithEvents lblAdvanceCoilSym As Label
    Public WithEvents lblMotionNameAbs As Label
    Public WithEvents lblReturnDepthSym As Label
    Public WithEvents lblReturnCoilSym As Label
    Public WithEvents lblReturnDepthAbs As Label
    Public WithEvents lblReturnCoilAbs As Label
    Public WithEvents btnAdv As Button
    Public WithEvents btnRet As Button
    Public WithEvents lblMotionNameSym As Label
    Public WithEvents lblStnNumber As Label
    Public WithEvents lblRowNumber As Label
    Friend WithEvents cbS1 As CheckBox
    Friend WithEvents cbS2 As CheckBox
    Friend WithEvents cbS3 As CheckBox
    Friend WithEvents cbS4 As CheckBox
    Friend WithEvents cbS5 As CheckBox
    Friend WithEvents cbS6 As CheckBox
    Friend WithEvents cbAllStns As CheckBox
    Friend WithEvents tabContStationLoading As TabControl
    Friend WithEvents Station1 As TabPage
    Friend WithEvents Station2 As TabPage
    Friend WithEvents lstbxStation2Files As ListBox
    Friend WithEvents lstbxRow2Data As ListBox
    Friend WithEvents Station3 As TabPage
    Friend WithEvents lstbxStation3Files As ListBox
    Friend WithEvents lstbxRow3Data As ListBox
    Friend WithEvents Station4 As TabPage
    Friend WithEvents lstbxStation4Files As ListBox
    Friend WithEvents lstbxRow4Data As ListBox
    Friend WithEvents Station5 As TabPage
    Friend WithEvents lstbxStation5Files As ListBox
    Friend WithEvents lstbxRow5Data As ListBox
    Friend WithEvents Station6 As TabPage
    Friend WithEvents lstbxStation6Files As ListBox
    Friend WithEvents lstbxRow6Data As ListBox
    Public WithEvents lstbxStation1Files As ListBox
    Public WithEvents lstbxRow1Data As ListBox
    Friend WithEvents btnCloseProject As Button
    Friend WithEvents grpboxParse As GroupBox
    Friend WithEvents lblMotionTextsPathName As Label
    Friend WithEvents lblMotionTextsFileSize As Label
    Friend WithEvents lblCONSTsFileSize As Label
    Friend WithEvents lblCONTsPathName As Label
    Friend WithEvents lblgNumberElementsPerRow As Label
    Friend WithEvents tabImport As TabPage
    Friend WithEvents tabViewData As TabPage
    Friend WithEvents lstBoxImportData As ListBox
    Friend WithEvents tabExportData As TabPage
    Friend WithEvents lstBoxPLCData As ListBox
    Friend WithEvents tabControlTasks As TabControl
    Friend WithEvents lblMotionFilesPath As Label
    Friend WithEvents lblPLCdataFilePath As Label
    Friend WithEvents lblImportBoxSelectionNum As Label
    Friend WithEvents lblPLCDataNumSelected As Label
    Friend WithEvents btnUpdateArray As Button
End Class
