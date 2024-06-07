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
        Me.grpBoxSelectProject.SuspendLayout()
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
        Me.lstbxStation1Files.Size = New System.Drawing.Size(576, 95)
        Me.lstbxStation1Files.TabIndex = 4
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lstbxStation1Files)
        Me.Controls.Add(Me.lblRawProjectPath)
        Me.Controls.Add(Me.grpBoxSelectProject)
        Me.Name = "frmMain"
        Me.Text = "TOAST Text Export Tool"
        Me.grpBoxSelectProject.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOpenProject As Button
    Friend WithEvents OpenTOASTprojectDialog As OpenFileDialog
    Friend WithEvents lblProjectPath As Label
    Friend WithEvents grpBoxSelectProject As GroupBox
    Friend WithEvents lblRawProjectPath As Label
    Friend WithEvents lstbxStation1Files As ListBox
End Class
