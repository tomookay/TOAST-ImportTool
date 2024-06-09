Public Class frmMain
    Dim tc3progLocationFiler As String
    Dim RawProjectPath As String

    Dim RawProjectPathLastSlash As Integer

    Dim station1Location As String

    Dim OpenedFile

    Dim arryMotionRowText As String()


    Const motionheader As String = "&lt;"
    Const motionfooter As String = "&gt;"



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
        Dim motionheaderLocation As UInt32
        Dim motionfooterLocation As UInt32

        ''find location of header and footer
        motionfooterLocation = OpenedFile.ToString.LastIndexOf(motionfooter)
        motionheaderLocation = OpenedFile.ToString.IndexOf(motionheader)

        ''debug
        '' MsgBox("header location is:" & motionheaderLocation)
        '' MsgBox("footer location is:" & motionfooterLocation)

        Dim motiondatastring As String

        ''trim file for later use
        motiondatastring = OpenedFile.ToString.Remove(motionfooterLocation + motionfooterLocation.ToString.Length)
        motiondatastring = motiondatastring.ToString.Substring(motionheaderLocation)
        ' Console.WriteLine(motiondatastring)

        arryMotionRowText = motiondatastring.Split(vbCr)


        lstbxRowData.DataSource = arryMotionRowText

        '&lt;MotionRow&gt; 0
        '&lt;StationNumber&gt;1&lt;/StationNumber&gt; 1
        lblStnNumber.Text = ParseRow(lstbxRowData.Items(1).ToString, "StationNumber")

        '&lt;RowNumber&gt;1&lt;/RowNumber&gt; 2
        lblRowNumber.Text = ParseRow(lstbxRowData.Items(2).ToString, "RowNumber")

        '&lt;Advance&gt; 3
        '&lt;AdvanceCoilTextSym&gt;Advance&lt;/AdvanceCoilTextSym&gt; 4
        lblAdvanceCoilSym.Text = ParseRow(lstbxRowData.Items(4).ToString, "AdvanceCoilTextSym")

        '&lt;AdvanceDepthTextSym&gt;Advanced&lt;/AdvanceDepthTextSym&gt; 5
        lblAdvanceDepthSym.Text = ParseRow(lstbxRowData.Items(5).ToString, "AdvanceDepthTextSym")

        '&lt;AdvanceCoilTextAbs&gt;Q1.0&lt;/AdvanceCoilTextAbs&gt; 6
        lblAdvanceCoilAbs.Text = ParseRow(lstbxRowData.Items(6).ToString, "AdvanceCoilTextAbs")

        '&lt;AdvanceDepthTextAbs&gt;I1.0&lt;/AdvanceDepthTextAbs&gt; 7
        lblAdvanceDepthAbs.Text = ParseRow(lstbxRowData.Items(7).ToString, "AdvanceDepthTextAbs")

        '&lt;ManSeq&gt;1&lt;/ManSeq&gt; 8
        btnAdv.Text = ParseRow(lstbxRowData.Items(8).ToString, "ManSeq")
        '&lt;/Advance&gt; 9
        '&lt;Return&gt; 10
        '&lt;ReturnCoilTextSym&gt;Return&lt;/ReturnCoilTextSym&gt; 11
        lblReturnCoilSym.Text = ParseRow(lstbxRowData.Items(11).ToString, "ReturnCoilTextSym")

        '&lt;ReturnDepthTextSym&gt;Returned&lt;/ReturnDepthTextSym&gt; 12
        lblReturnDepthSym.Text = ParseRow(lstbxRowData.Items(12).ToString, "ReturnDepthTextSym")

        '&lt;ReturnCoilTextAbs&gt;Q1.1&lt;/ReturnCoilTextAbs&gt; 13
        lblReturnCoilAbs.Text = ParseRow(lstbxRowData.Items(13).ToString, "ReturnCoilTextAbs")

        '&lt;ReturnDepthTextAbs&gt;I1.1&lt;/ReturnDepthTextAbs&gt; 14
        lblReturnDepthAbs.Text = ParseRow(lstbxRowData.Items(14).ToString, "ReturnDepthTextAbs")

        '&lt;ManSeq&gt;2&lt;/ManSeq&gt; 15
        btnRet.Text = ParseRow(lstbxRowData.Items(15).ToString, "ManSeq")

        '&lt;/Return&gt; 16
        '&lt;Motion&gt; 17
        '&lt;NameSym&gt;Clamp Cylinder&lt;/NameSym&gt; 18
        lblMotionNameSym.Text = ParseRow(lstbxRowData.Items(18).ToString, "NameSym")

        '&lt;NameAbs&gt;A1&lt;/NameAbs&gt; 19
        lblMotionNameAbs.Text = ParseRow(lstbxRowData.Items(19).ToString, "NameAbs")



        '&lt;/Motion&gt; 20
        '&lt;/MotionRow&gt 21



    End Sub

    Function ParseRow(ByVal InputRow As String, ByVal SearchString As String) As String

        Dim startLocation As Integer

        startLocation = InputRow.IndexOf(motionfooter)

        Dim numLts As Integer
        Dim numGts As Integer
        Dim TextLocation As Integer
        Dim TextLocation2 As Integer

        Dim processString As String
        Dim processString2 As String
        Dim anotherint As Integer




        '' MsgBox("InputRow: " & InputRow)

        ''motionheader
        ''motionfooter

        ''  If InputRow.Contains(motionheader) Then
        ''  MsgBox("it does contain numLts")
        ''  End If



        anotherint = UBound(Split(InputRow, SearchString))

        If anotherint = 0 Then
            '     MsgBox("no result")'error state
        End If

        If anotherint = 1 Then
            'MsgBox("Only found one") 'error state
        End If

        If anotherint > 1 Then
            'MsgBox("more than 1.." & anotherint) 'not error state
        End If

        ''MsgBox(anotherint)

        ' processString = InputRow.Trim(vbCr)
        ' processString = processString.Trim(vbLf)




        TextLocation = InputRow.IndexOf(SearchString)
        processString = InputRow.Substring(TextLocation + SearchString.Length)

        TextLocation2 = processString.IndexOf(SearchString)
        processString2 = processString.Remove(TextLocation2 - 1)

        Dim finalheader As String = "&gt;"
        Dim finalheaderlocation As Integer

        finalheaderlocation = processString2.IndexOf(finalheader)
        processString2 = processString2.Substring(finalheaderlocation)



        Console.Write(processString2)

        Console.Write(vbCrLf)
        Return processString2




    End Function

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblStnNumber.Click

    End Sub
End Class
