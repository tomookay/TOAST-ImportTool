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
        Me.lblRawProjectPath = New System.Windows.Forms.Label()
        Me.lstbxStation1Files = New System.Windows.Forms.ListBox()
        Me.lstbxRowData = New System.Windows.Forms.ListBox()
        Me.grpboxMotionRow = New System.Windows.Forms.GroupBox()
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
        Me.lblStnNumber = New System.Windows.Forms.Label()
        Me.lblRowNumber = New System.Windows.Forms.Label()
        Me.grpBoxSelectProject.SuspendLayout()
        Me.grpboxMotionRow.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpenProject
        '
        Me.btnOpenProject.Location = New System.Drawing.Point(28, 24)
        Me.btnOpenProject.Name = "btnOpenProject"
        Me.btnOpenProject.Size = New System.Drawing.Size(97, 35)
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
        Me.lblProjectPath.Location = New System.Drawing.Point(156, 24)
        Me.lblProjectPath.Name = "lblProjectPath"
        Me.lblProjectPath.Size = New System.Drawing.Size(491, 34)
        Me.lblProjectPath.TabIndex = 1
        Me.lblProjectPath.Text = "No Project Selected....."
        Me.lblProjectPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpBoxSelectProject
        '
        Me.grpBoxSelectProject.Controls.Add(Me.lblProjectPath)
        Me.grpBoxSelectProject.Controls.Add(Me.btnOpenProject)
        Me.grpBoxSelectProject.Location = New System.Drawing.Point(53, 14)
        Me.grpBoxSelectProject.Name = "grpBoxSelectProject"
        Me.grpBoxSelectProject.Size = New System.Drawing.Size(672, 81)
        Me.grpBoxSelectProject.TabIndex = 2
        Me.grpBoxSelectProject.TabStop = False
        Me.grpBoxSelectProject.Text = "Select Project...."
        '
        'lblRawProjectPath
        '
        Me.lblRawProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRawProjectPath.Location = New System.Drawing.Point(81, 108)
        Me.lblRawProjectPath.Name = "lblRawProjectPath"
        Me.lblRawProjectPath.Size = New System.Drawing.Size(491, 34)
        Me.lblRawProjectPath.TabIndex = 2
        Me.lblRawProjectPath.Text = "No Raw Project Path...."
        Me.lblRawProjectPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstbxStation1Files
        '
        Me.lstbxStation1Files.FormattingEnabled = True
        Me.lstbxStation1Files.Location = New System.Drawing.Point(81, 162)
        Me.lstbxStation1Files.Name = "lstbxStation1Files"
        Me.lstbxStation1Files.ScrollAlwaysVisible = True
        Me.lstbxStation1Files.Size = New System.Drawing.Size(576, 56)
        Me.lstbxStation1Files.TabIndex = 4
        '
        'lstbxRowData
        '
        Me.lstbxRowData.FormattingEnabled = True
        Me.lstbxRowData.Location = New System.Drawing.Point(81, 240)
        Me.lstbxRowData.Name = "lstbxRowData"
        Me.lstbxRowData.ScrollAlwaysVisible = True
        Me.lstbxRowData.Size = New System.Drawing.Size(576, 56)
        Me.lstbxRowData.TabIndex = 5
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
        Me.grpboxMotionRow.Location = New System.Drawing.Point(53, 328)
        Me.grpboxMotionRow.Name = "grpboxMotionRow"
        Me.grpboxMotionRow.Size = New System.Drawing.Size(672, 160)
        Me.grpboxMotionRow.TabIndex = 6
        Me.grpboxMotionRow.TabStop = False
        Me.grpboxMotionRow.Text = "Motion Row Sample"
        '
        'btnAdv
        '
        Me.btnAdv.Location = New System.Drawing.Point(6, 19)
        Me.btnAdv.Name = "btnAdv"
        Me.btnAdv.Size = New System.Drawing.Size(58, 134)
        Me.btnAdv.TabIndex = 11
        Me.btnAdv.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdv.UseVisualStyleBackColor = True
        '
        'btnRet
        '
        Me.btnRet.Location = New System.Drawing.Point(598, 20)
        Me.btnRet.Name = "btnRet"
        Me.btnRet.Size = New System.Drawing.Size(58, 134)
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 522)
        Me.Controls.Add(Me.grpboxMotionRow)
        Me.Controls.Add(Me.lstbxRowData)
        Me.Controls.Add(Me.lstbxStation1Files)
        Me.Controls.Add(Me.lblRawProjectPath)
        Me.Controls.Add(Me.grpBoxSelectProject)
        Me.Name = "frmMain"
        Me.Text = "TOAST Text Export Tool"
        Me.grpBoxSelectProject.ResumeLayout(False)
        Me.grpboxMotionRow.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOpenProject As Button
    Friend WithEvents OpenTOASTprojectDialog As OpenFileDialog
    Friend WithEvents lblProjectPath As Label
    Friend WithEvents grpBoxSelectProject As GroupBox
    Friend WithEvents lblRawProjectPath As Label
    Friend WithEvents lstbxStation1Files As ListBox
    Friend WithEvents lstbxRowData As ListBox
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
End Class
