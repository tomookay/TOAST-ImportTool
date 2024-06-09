Public Class frmMain
    Dim tc3progLocationFiler As String
    Dim RawProjectPath As String

    Dim RawProjectPathLastSlash As Integer



    Dim OpenedFile

    Dim arryMotionRowText As String()


    Const motionheader_lt As String = "&lt;"
    Const motionfooter_gt As String = "&gt;"

    Dim IsLoadingData As Boolean = False


    Private Sub BtnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click
        ''set logic for later use
        IsLoadingData = True

        ''clear down the list boxes
        ClearDownOnStart()


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


        'load .TcPoU file into list
        LoadMotionListsFromStation()

        'load contents of .TcPoU file into parser
        PopulateListBoxMotions()


        IsLoadingData = False


    End Sub

    Sub PopulateListBoxMotions()
        PopulateListBox1()
        PopulateListBox2()
        PopulateListBox3()
        PopulateListBox4()
        PopulateListBox5()
        PopulateListBox6()

    End Sub

    Sub ClearDownOnStart()
        ''clear down the lists
        lstbxStation1Files.Items.Clear()
        lstbxStation2Files.Items.Clear()
        lstbxStation3Files.Items.Clear()
        lstbxStation4Files.Items.Clear()
        lstbxStation5Files.Items.Clear()
        lstbxStation6Files.Items.Clear()

        lstbxRow1Data.DataSource = Nothing
        lstbxRow2Data.DataSource = Nothing
        lstbxRow3Data.DataSource = Nothing
        lstbxRow4Data.DataSource = Nothing
        lstbxRow5Data.DataSource = Nothing
        lstbxRow6Data.DataSource = Nothing

        lstbxRow1Data.Items.Clear()
        lstbxRow2Data.Items.Clear()
        lstbxRow3Data.Items.Clear()
        lstbxRow4Data.Items.Clear()
        lstbxRow5Data.Items.Clear()
        lstbxRow6Data.Items.Clear()

        ClearParsingList()



    End Sub

    Sub LoadMotionListsFromStation()
        'populate locations of .TCPoU's containing motions to parse later
        LoadStation1()
        LoadStation2()
        LoadStation3()
        LoadStation4()
        LoadStation5()
        LoadStation6()


    End Sub

    Sub LoadStation1()

        Dim stationLocation As String

        If cbS1.Checked Then

            tabContStationLoading.TabPages.Item(0).Select()

            ''find station 1
            stationLocation = lblRawProjectPath.Text + "\PLC1\PLC\Machine\Station 1\Motions\"

            ''record all uses of motion files
            For Each foundfile As String In My.Computer.FileSystem.GetFiles(
            stationLocation, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
             "*.TCPoU")

                lstbxStation1Files.Items.Add(foundfile)
            Next
            '  MsgBox("station 1 List populated")
        End If
    End Sub

    Sub LoadStation2()

        Dim stationLocation As String

        If cbS2.Checked Then

            tabContStationLoading.TabPages.Item(1).Select()

            ''find station 2
            stationLocation = lblRawProjectPath.Text + "\PLC1\PLC\Machine\Station 2\Motions\"

            ''record all uses of motion files
            For Each foundfile As String In My.Computer.FileSystem.GetFiles(
            stationLocation, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
             "*.TCPoU")

                lstbxStation2Files.Items.Add(foundfile)
            Next

            'MsgBox("station 2 List populated")

        End If



    End Sub

    Sub LoadStation3()

        Dim stationLocation As String

        If cbS3.Checked Then

            tabContStationLoading.TabPages.Item(2).Select()

            ''find station 3
            stationLocation = lblRawProjectPath.Text + "\PLC1\PLC\Machine\Station 3\Motions\"

            ''record all uses of motion files
            For Each foundfile As String In My.Computer.FileSystem.GetFiles(
            stationLocation, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
             "*.TCPoU")

                lstbxStation3Files.Items.Add(foundfile)
            Next

            ' MsgBox("station 3 List populated")

        End If



    End Sub

    Sub LoadStation4()

        Dim stationLocation As String

        If cbS4.Checked Then

            tabContStationLoading.TabPages.Item(3).Select()

            ''find station 4
            stationLocation = lblRawProjectPath.Text + "\PLC1\PLC\Machine\Station 4\Motions\"

            ''record all uses of motion files
            For Each foundfile As String In My.Computer.FileSystem.GetFiles(
            stationLocation, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
             "*.TCPoU")

                lstbxStation4Files.Items.Add(foundfile)
            Next

            ' MsgBox("station 4 List populated")

        End If



    End Sub

    Sub LoadStation5()

        Dim stationLocation As String

        tabContStationLoading.TabPages.Item(4).Select()

        If cbS5.Checked Then

            ''find station 5
            stationLocation = lblRawProjectPath.Text + "\PLC1\PLC\Machine\Station 5\Motions\"

            ''record all uses of motion files
            For Each foundfile As String In My.Computer.FileSystem.GetFiles(
            stationLocation, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
             "*.TCPoU")

                lstbxStation5Files.Items.Add(foundfile)
            Next

            '  MsgBox("station 5 List populated")

        End If



    End Sub

    Sub LoadStation6()

        Dim stationLocation As String

        tabContStationLoading.TabPages.Item(5).Select()

        If cbS6.Checked Then

            ''find station 6
            stationLocation = lblRawProjectPath.Text + "\PLC1\PLC\Machine\Station 6\Motions\"

            ''record all uses of motion files
            For Each foundfile As String In My.Computer.FileSystem.GetFiles(
            stationLocation, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
             "*.TCPoU")

                lstbxStation6Files.Items.Add(foundfile)
            Next

            ' MsgBox("station 6 List populated")

        End If


    End Sub

    Sub PopulateListBox1()
        If cbS1.Checked Then
            Me.tabContStationLoading.SelectedIndex = 0

            Dim NumListEntries As Integer
            NumListEntries = lstbxStation1Files.Items.Count

            For i = 0 To NumListEntries - 1

                lstbxRow1Data.DataSource = OpenFileToListBox(i, lstbxStation1Files)
                ParseTextList(lstbxRow1Data)

            Next
        End If
    End Sub

    Sub PopulateListBox2()
        If cbS2.Checked Then
            Me.tabContStationLoading.SelectedIndex = 1

            Dim NumListEntries As Integer
            NumListEntries = lstbxStation2Files.Items.Count

            For i = 0 To NumListEntries - 1

                lstbxRow2Data.DataSource = OpenFileToListBox(i, lstbxStation2Files)
                ParseTextList(lstbxRow2Data)

            Next
        End If
    End Sub

    Sub PopulateListBox3()
        If cbS3.Checked Then
            Me.tabContStationLoading.SelectedIndex = 2

            Dim NumListEntries As Integer
            NumListEntries = lstbxStation3Files.Items.Count

            For i = 0 To NumListEntries - 1

                lstbxRow3Data.DataSource = OpenFileToListBox(i, lstbxStation3Files)
                ParseTextList(lstbxRow3Data)

            Next
        End If
    End Sub

    Sub PopulateListBox4()
        If cbS4.Checked Then
            Me.tabContStationLoading.SelectedIndex = 3

            Dim NumListEntries As Integer
            NumListEntries = lstbxStation4Files.Items.Count

            For i = 0 To NumListEntries - 1

                lstbxRow4Data.DataSource = OpenFileToListBox(i, lstbxStation4Files)
                ParseTextList(lstbxRow4Data)

            Next
        End If
    End Sub

    Sub PopulateListBox5()
        If cbS5.Checked Then
            Me.tabContStationLoading.SelectedIndex = 4

            Dim NumListEntries As Integer
            NumListEntries = lstbxStation5Files.Items.Count

            For i = 0 To NumListEntries - 1

                lstbxRow5Data.DataSource = OpenFileToListBox(i, lstbxStation5Files)
                ParseTextList(lstbxRow5Data)

            Next
        End If
    End Sub

    Sub PopulateListBox6()
        If cbS6.Checked Then
            Me.tabContStationLoading.SelectedIndex = 5

            Dim NumListEntries As Integer
            NumListEntries = lstbxStation6Files.Items.Count

            For i = 0 To NumListEntries - 1

                lstbxRow6Data.DataSource = OpenFileToListBox(i, lstbxStation6Files)
                ParseTextList(lstbxRow6Data)

            Next
        End If
    End Sub

    Function OpenFileToListBox(ByVal RowNum As Integer, ByRef stationListing As ListBox) As String()

        ''select the first index
        '  lstbxStation1Files.SelectedIndex = RowNum
        stationListing.SelectedIndex = RowNum

        Dim SelectedFile As String = stationListing.SelectedItem

        ''open the TCPoU file selected
        OpenedFile = XDocument.Load(SelectedFile)

        ''declare values to trim against
        Dim motionheaderLocation As UInt32
        Dim motionfooterLocation As UInt32

        ''find location of header and footer
        motionfooterLocation = OpenedFile.ToString.LastIndexOf(motionfooter_gt)
        motionheaderLocation = OpenedFile.ToString.IndexOf(motionheader_lt)

        Dim motiondatastring As String

        ''trim file for later use
        motiondatastring = OpenedFile.ToString.Remove(motionfooterLocation + motionfooterLocation.ToString.Length)
        motiondatastring = motiondatastring.ToString.Substring(motionheaderLocation)
        ' Console.WriteLine(motiondatastring)

        arryMotionRowText = motiondatastring.Split(vbCr)

        Return arryMotionRowText

    End Function


    Sub ParseTextList(ByRef RowData As ListBox)

        '&lt;MotionRow&gt; 0
        '&lt;StationNumber&gt;1&lt;/StationNumber&gt; 1
        lblStnNumber.Text = ParseRow(RowData.Items(1).ToString, "StationNumber")

        '&lt;RowNumber&gt;1&lt;/RowNumber&gt; 2
        lblRowNumber.Text = ParseRow(RowData.Items(2).ToString, "RowNumber")

        '&lt;Advance&gt; 3
        '&lt;AdvanceCoilTextSym&gt;Advance&lt;/AdvanceCoilTextSym&gt; 4
        lblAdvanceCoilSym.Text = ParseRow(RowData.Items(4).ToString, "AdvanceCoilTextSym")

        '&lt;AdvanceDepthTextSym&gt;Advanced&lt;/AdvanceDepthTextSym&gt; 5
        lblAdvanceDepthSym.Text = ParseRow(RowData.Items(5).ToString, "AdvanceDepthTextSym")

        '&lt;AdvanceCoilTextAbs&gt;Q1.0&lt;/AdvanceCoilTextAbs&gt; 6
        lblAdvanceCoilAbs.Text = ParseRow(RowData.Items(6).ToString, "AdvanceCoilTextAbs")

        '&lt;AdvanceDepthTextAbs&gt;I1.0&lt;/AdvanceDepthTextAbs&gt; 7
        lblAdvanceDepthAbs.Text = ParseRow(RowData.Items(7).ToString, "AdvanceDepthTextAbs")

        '&lt;ManSeq&gt;1&lt;/ManSeq&gt; 8
        btnAdv.Text = ParseRow(RowData.Items(8).ToString, "ManSeq")
        '&lt;/Advance&gt; 9
        '&lt;Return&gt; 10
        '&lt;ReturnCoilTextSym&gt;Return&lt;/ReturnCoilTextSym&gt; 11
        lblReturnCoilSym.Text = ParseRow(RowData.Items(11).ToString, "ReturnCoilTextSym")

        '&lt;ReturnDepthTextSym&gt;Returned&lt;/ReturnDepthTextSym&gt; 12
        lblReturnDepthSym.Text = ParseRow(RowData.Items(12).ToString, "ReturnDepthTextSym")

        '&lt;ReturnCoilTextAbs&gt;Q1.1&lt;/ReturnCoilTextAbs&gt; 13
        lblReturnCoilAbs.Text = ParseRow(RowData.Items(13).ToString, "ReturnCoilTextAbs")

        '&lt;ReturnDepthTextAbs&gt;I1.1&lt;/ReturnDepthTextAbs&gt; 14
        lblReturnDepthAbs.Text = ParseRow(RowData.Items(14).ToString, "ReturnDepthTextAbs")

        '&lt;ManSeq&gt;2&lt;/ManSeq&gt; 15
        btnRet.Text = ParseRow(RowData.Items(15).ToString, "ManSeq")

        '&lt;/Return&gt; 16
        '&lt;Motion&gt; 17
        '&lt;NameSym&gt;Clamp Cylinder&lt;/NameSym&gt; 18
        lblMotionNameSym.Text = ParseRow(RowData.Items(18).ToString, "NameSym")

        '&lt;NameAbs&gt;A1&lt;/NameAbs&gt; 19
        lblMotionNameAbs.Text = ParseRow(RowData.Items(19).ToString, "NameAbs")

        '&lt;/Motion&gt; 20
        '&lt;/MotionRow&gt 21
    End Sub


    Function ParseRow(ByVal InputRow As String, ByVal SearchString As String) As String

        Dim startLocation As Integer

        startLocation = InputRow.IndexOf(motionfooter_gt)

        Dim anotherint As Integer

        ''check if string contains 0, 1 or >1 headers, the xml tags <tag> <tag>
        ''for a xml row to be checked, there must be 2 or more tags.
        anotherint = UBound(Split(InputRow, SearchString))

        If anotherint = 0 Then
            '     MsgBox("no result")'error state
            Return "Error: StrLen0"
        End If

        If anotherint = 1 Then
            'MsgBox("Only found one") 'error state
            Return "Error: StrLen1"
        End If

        If anotherint > 1 Then
            'MsgBox("more than 1.." & anotherint) 'not error state
        End If

        ''assemble strings to parse against
        Dim headerStart As String
        headerStart = motionheader_lt & SearchString & motionfooter_gt

        Dim footerStart As String
        footerStart = motionheader_lt & "/" & SearchString & motionfooter_gt

        Dim headerStartLocation As Integer
        headerStartLocation = InputRow.IndexOf(headerStart)

        Dim footerStartLocation As Integer
        footerStartLocation = InputRow.IndexOf(footerStart)

        Dim headerLength As Integer
        headerLength = headerStart.Length

        Dim footerLength As Integer
        footerLength = footerStart.Length

        ''snip footer first
        Dim processString As String
        processString = InputRow.Remove(footerStartLocation, footerLength)

        ''snip header second
        Dim processString2 As String
        processString2 = processString.Remove(headerStartLocation, headerLength)

        ''snip CR at the start
        Dim processString3 As String
        processString3 = processString2.Remove(0, 1)

        Console.Write(vbCrLf)
        Return processString3

    End Function



    Private Sub CbAllStns_CheckStateChanged(sender As Object, e As EventArgs) Handles cbAllStns.CheckStateChanged
        If cbAllStns.Checked Then
            cbS1.Checked = True
            cbS2.Checked = True
            cbS3.Checked = True
            cbS4.Checked = True
            cbS5.Checked = True
            cbS6.Checked = True
        Else
            cbS1.Checked = False
            cbS2.Checked = False
            cbS3.Checked = False
            cbS4.Checked = False
            cbS5.Checked = False
            cbS6.Checked = False
        End If

    End Sub

    Private Sub LstbxStation1Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation1Files.SelectedIndexChanged

        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow1Data.DataSource = OpenFileToListBox(lstbxStation1Files.SelectedIndex, lstbxStation1Files)

            ParseTextList(lstbxRow1Data)

        End If

    End Sub

    Private Sub LstbxStation2Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation2Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow2Data.DataSource = OpenFileToListBox(lstbxStation2Files.SelectedIndex, lstbxStation2Files)

            ParseTextList(lstbxRow2Data)

        End If
    End Sub

    Private Sub LstbxStation3Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation3Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow3Data.DataSource = OpenFileToListBox(lstbxStation3Files.SelectedIndex, lstbxStation3Files)

            ParseTextList(lstbxRow3Data)

        End If
    End Sub

    Private Sub LstbxStation4Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation4Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow4Data.DataSource = OpenFileToListBox(lstbxStation4Files.SelectedIndex, lstbxStation4Files)

            ParseTextList(lstbxRow4Data)

        End If
    End Sub

    Private Sub LstbxStation5Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation5Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow5Data.DataSource = OpenFileToListBox(lstbxStation5Files.SelectedIndex, lstbxStation5Files)

            ParseTextList(lstbxRow4Data)

        End If
    End Sub

    Private Sub LstbxStation6Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation6Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow6Data.DataSource = OpenFileToListBox(lstbxStation6Files.SelectedIndex, lstbxStation6Files)

            ParseTextList(lstbxRow6Data)

        End If
    End Sub

    Private Sub btnCloseBtn_Click(sender As Object, e As EventArgs) Handles btnCloseProject.Click
        lblRawProjectPath.Text = "No Raw Project Path...."
        ClearDownOnStart()

    End Sub


    Sub ClearParsingList()

        '&lt;MotionRow&gt; 0
        '&lt;StationNumber&gt;1&lt;/StationNumber&gt; 1
        lblStnNumber.Text = ""

        '&lt;RowNumber&gt;1&lt;/RowNumber&gt; 2
        lblRowNumber.Text = ""

        '&lt;Advance&gt; 3
        '&lt;AdvanceCoilTextSym&gt;Advance&lt;/AdvanceCoilTextSym&gt; 4
        lblAdvanceCoilSym.Text = ""

        '&lt;AdvanceDepthTextSym&gt;Advanced&lt;/AdvanceDepthTextSym&gt; 5
        lblAdvanceDepthSym.Text = ""

        '&lt;AdvanceCoilTextAbs&gt;Q1.0&lt;/AdvanceCoilTextAbs&gt; 6
        lblAdvanceCoilAbs.Text = ""

        '&lt;AdvanceDepthTextAbs&gt;I1.0&lt;/AdvanceDepthTextAbs&gt; 7
        lblAdvanceDepthAbs.Text = ""

        '&lt;ManSeq&gt;1&lt;/ManSeq&gt; 8
        btnAdv.Text = ""
        '&lt;/Advance&gt; 9
        '&lt;Return&gt; 10
        '&lt;ReturnCoilTextSym&gt;Return&lt;/ReturnCoilTextSym&gt; 11
        lblReturnCoilSym.Text = ""

        '&lt;ReturnDepthTextSym&gt;Returned&lt;/ReturnDepthTextSym&gt; 12
        lblReturnDepthSym.Text = ""

        '&lt;ReturnCoilTextAbs&gt;Q1.1&lt;/ReturnCoilTextAbs&gt; 13
        lblReturnCoilAbs.Text = ""

        '&lt;ReturnDepthTextAbs&gt;I1.1&lt;/ReturnDepthTextAbs&gt; 14
        lblReturnDepthAbs.Text = ""

        '&lt;ManSeq&gt;2&lt;/ManSeq&gt; 15
        btnRet.Text = ""

        '&lt;/Return&gt; 16
        '&lt;Motion&gt; 17
        '&lt;NameSym&gt;Clamp Cylinder&lt;/NameSym&gt; 18
        lblMotionNameSym.Text = ""

        '&lt;NameAbs&gt;A1&lt;/NameAbs&gt; 19
        lblMotionNameAbs.Text = ""



        '&lt;/Motion&gt; 20
        '&lt;/MotionRow&gt 21


    End Sub


End Class
