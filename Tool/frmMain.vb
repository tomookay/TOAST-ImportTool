Imports System.Diagnostics.Eventing
Imports System.Xml
Imports System.Xml.Serialization

Public Class frmMain
    Dim tc3progLocationFiler As String
    Dim RawProjectPath As String

    Dim RawProjectPathLastSlash As Integer

    Dim station1Location As String

    Dim OpenedFile


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub


    Private Sub btnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click

        ''set filter for project locator
        tc3progLocationFiler = "TOAST TwinCAT3 Project (*.tsproj)|*.tsproj"

        ''locate the twincat3 project with the TOAST data files
        OpenTOASTprojectDialog.Filter = tc3progLocationFiler

        ''open the file selector
        OpenTOASTprojectDialog.ShowDialog()

        lblProjectPath.Text = OpenTOASTprojectDialog.FileName

        ''find raw project location
        RawProjectPathLastSlash = lblProjectPath.Text.LastIndexOf("\")
        lblRawProjectPath.Text = RawProjectPathLastSlash
        lblRawProjectPath.Text = lblProjectPath.Text.Remove(RawProjectPathLastSlash)

        ''find station 1
        station1Location = lblRawProjectPath.Text + "\PLC1\PLC\Machine\Station 1\Motions\"

        ''record all uses of motion files
        For Each foundfile As String In My.Computer.FileSystem.GetFiles(
        station1Location, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
         "*.TCPoU")

            lstbxStation1Files.Items.Add(foundfile)
        Next

        ''select the first index
        lstbxStation1Files.SelectedIndex = 0

        Dim SelectedFile As String = lstbxStation1Files.SelectedItem

        ''open the TCPoU file selected
        OpenedFile = XDocument.Load(SelectedFile)

        ''declare values to trim against
        Dim motionheader As String = "&lt;"
        Dim motionfooter As String = "&gt;"
        Dim motionheaderLocation As UInt32
        Dim motionfooterLocation As UInt32

        ''find location of header and footer
        motionfooterLocation = OpenedFile.ToString.LastIndexOf(motionfooter)
        motionheaderLocation = OpenedFile.ToString.IndexOf(motionheader)

        ''debug
        MsgBox("header location is:" & motionheaderLocation)
        MsgBox("footer location is:" & motionfooterLocation)

        Dim motiondatastring As String

        ''trim file for later use
        motiondatastring = OpenedFile.ToString.Remove(motionfooterLocation + motionfooterLocation.ToString.Length)
        motiondatastring = motiondatastring.ToString.Substring(motionheaderLocation)
        Console.WriteLine(motiondatastring)


    End Sub



End Class
