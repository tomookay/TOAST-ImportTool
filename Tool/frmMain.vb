Imports System.IO
Imports System.Net
Imports System.Text

Public Class frmMain
    Dim tc3progLocationFiler As String
    Dim RawProjectPath As String

    Dim RawProjectPathLastSlash As Integer

    Dim OpenedFile

    Dim arryMotionRowText As String()

    Dim IsLoadingData As Boolean = False


    'from PLC
    Dim gNumberElementsPerRow As Integer

    Dim ProcessArray1() As String ''array read from 
    Dim ProcessArry1Num As Integer


    Dim ProcessArray2() As String
    Dim ProcessArry2Num As Integer


    ''Location of elements in array
    Const txtReturnRel As Integer = 13
    Const txtMotionNameRel As Integer = 16
    Const txtReturnedRel As Integer = 14
    Const txtAdvanceRel As Integer = 10
    Const txtAdvancedRel As Integer = 11

    Const txtReturnAbs As Integer = 3
    Const txtMotionNameAbs As Integer = 6
    Const txtReturnedAbs As Integer = 4
    Const txtAdvanceAbs As Integer = 0
    Const txtAdvancedAbs As Integer = 1

    Dim MotionStringsFileLocation As String

    Dim xmlStrMotionFile() As String 'read in language file

    Dim StartTime As Integer
    Dim EndTime As Integer

    Private Sub BtnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click

        StartTime = My.Computer.Clock.TickCount

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

        'load CONSTS files
        LoadCONSTsFile()

        'load string language files
        LoadMotionStringsFile()

        'load .TcPoU file into list
        LoadMotionListsFromStation()

        'load contents of .TcPoU file into parser
        PopulateListBoxMotions()

        'load data into working list array
        PopulateWorkingList()



        IsLoadingData = False
        EndTime = My.Computer.Clock.TickCount

        MsgBox(EndTime - StartTime & "ms", MsgBoxStyle.Information, "Time Taken...")

    End Sub

    Sub PopulateWorkingList()
        tabControlTasks.TabPages.Item(1).Select()

        lblPLCdataFilePath.Text = MotionStringsFileLocation
        lstBoxImportData.DataSource = ProcessArray1



        ''update null values
        For i = 0 To ProcessArray2.Length - 1
            If ProcessArray2(i) = "" Then
                ''null value, assign dummy string
                ProcessArray2(i) = "NoDetectedValue"
            End If

        Next


        lblMotionFilesPath.Text = "loaded"
        lstBoxPLCData.DataSource = ProcessArray2



    End Sub

    Sub LoadCONSTsFile()
        'load file that contains offset ammount (typ. 20)
        '
        'C:\transline\TwinCAT Project1\PLC1\HMI1\Data\gHMIDataConst.TcGVL
        Dim HMIDataCONSTSlocation As String

        HMIDataCONSTSlocation = lblRawProjectPath.Text & "\PLC1\HMI1\Data\gHMIDataConst.TcGVL"

        lblCONTsPathName.Text = HMIDataCONSTSlocation

        Dim fileSize As Long
        fileSize = My.Computer.FileSystem.GetFileInfo(HMIDataCONSTSlocation).Length

        lblCONSTsFileSize.Text = fileSize & " bytes"

        'load file to memory
        Dim fileContents As String
        fileContents = My.Computer.FileSystem.ReadAllText(lblCONTsPathName.Text)
        Dim splitStringResult() As String
        Dim splittingSeperators() As String = {vbCr}
        splitStringResult = fileContents.Split(splittingSeperators, StringSplitOptions.None)

        ' Dim ReturnedPLCDeclaredValue As String
        'loop around all values and check if value contains specified data
        For i = 0 To splitStringResult.Length - 1

            If splitStringResult(i).Contains("gNumberElementsPerRow") Then
                gNumberElementsPerRow = FindParamInTcDelcare(splitStringResult(i), "gNumberElementsPerRow")
                lblgNumberElementsPerRow.Text = "gNumberElementsPerRow:=" & gNumberElementsPerRow
            End If

        Next


    End Sub



    Sub LoadMotionStringsFile()
        'C:\transline\TwinCAT Project1\PLC1\HMI1\Data\MotionRowText.TcTLO


        MotionStringsFileLocation = lblRawProjectPath.Text & "\PLC1\HMI1\Data\MotionRowText.TcTLO"

        lblMotionTextsPathName.Text = MotionStringsFileLocation

        Dim fileSize As Long
        fileSize = My.Computer.FileSystem.GetFileInfo(MotionStringsFileLocation).Length

        lblMotionTextsFileSize.Text = fileSize & " bytes"


        'load file to memory
        Dim fileContents As String
        fileContents = My.Computer.FileSystem.ReadAllText(lblMotionTextsPathName.Text)

        Dim splittingSeperators() As String = {vbCr}
        xmlStrMotionFile = fileContents.Split(splittingSeperators, StringSplitOptions.None)

        Dim procString As String
        Dim textIDlocation As Integer

        Dim TextIDStrSearch As String = "TextID"
        Dim TextIDToContentDist As Integer = 9

        Dim ContentFooter As String = "</v>"
        Dim ContentFooterDist As Integer



        'init pointer to array
        ProcessArry1Num = 0

        ReDim ProcessArray1(xmlStrMotionFile.Length)
        ReDim ProcessArray2(xmlStrMotionFile.Length)

        For i = 0 To xmlStrMotionFile.Length - 1
            'check if text matches textid header
            If xmlStrMotionFile(i).Contains(TextIDStrSearch) Then
                ' Console.WriteLine("found TextID header")
                procString = xmlStrMotionFile(i)
                textIDlocation = procString.IndexOf(TextIDStrSearch)

                'distance between "TextID" and start of content = 9
                procString = procString.Remove(0, textIDlocation + TextIDToContentDist)

                'find and remove the footer of "<v>"
                ContentFooterDist = procString.IndexOf(ContentFooter) - 1
                procString = procString.Remove(ContentFooterDist, ContentFooter.Length + 1)


                ProcessArray1(ProcessArry1Num) = procString
                ProcessArry1Num = ProcessArry1Num + 1
            Else
                'Console.WriteLine("did not find TextID header")
            End If
        Next

    End Sub

    Sub PopulateListBoxMotions()
        Me.tabContStationLoading.SelectedIndex = 0
        PopulateListBox(cbS1, lstbxStation1Files, lstbxRow1Data)
        Me.tabContStationLoading.SelectedIndex = 1
        PopulateListBox(cbS2, lstbxStation2Files, lstbxRow2Data)
        Me.tabContStationLoading.SelectedIndex = 2
        PopulateListBox(cbS3, lstbxStation3Files, lstbxRow3Data)
        Me.tabContStationLoading.SelectedIndex = 3
        PopulateListBox(cbS4, lstbxStation4Files, lstbxRow4Data)
        Me.tabContStationLoading.SelectedIndex = 4
        PopulateListBox(cbS5, lstbxStation5Files, lstbxRow5Data)
        Me.tabContStationLoading.SelectedIndex = 5
        PopulateListBox(cbS6, lstbxStation6Files, lstbxRow6Data)

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
        LoadStationMotionPaths(cbS1, lblRawProjectPath.Text, "1", lstbxStation1Files)
        LoadStationMotionPaths(cbS2, lblRawProjectPath.Text, "2", lstbxStation2Files)
        LoadStationMotionPaths(cbS3, lblRawProjectPath.Text, "3", lstbxStation3Files)
        LoadStationMotionPaths(cbS4, lblRawProjectPath.Text, "4", lstbxStation4Files)
        LoadStationMotionPaths(cbS5, lblRawProjectPath.Text, "5", lstbxStation5Files)
        LoadStationMotionPaths(cbS6, lblRawProjectPath.Text, "6", lstbxStation6Files)
    End Sub

    Sub LoadStationMotionPaths(ByRef CheckboxValue As CheckBox, ByVal RawProjectPath As String, ByVal StationNumber As String, ByRef ListboxStationFiles As ListBox)

        Dim stationLocation As String

        'cbS1.Checked
        If CheckboxValue.Checked Then

            ''find station
            '
            stationLocation = RawProjectPath & "\PLC1\PLC\Machine\Station " & StationNumber & "\Motions\"

            ''record all uses of motion files
            For Each foundfile As String In My.Computer.FileSystem.GetFiles(
            stationLocation, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories,
             "*.TCPoU")

                ListboxStationFiles.Items.Add(foundfile)
            Next
            'nowt
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


    Sub ParseTextList(ByRef RowData As ListBox, ByVal ElemsPerRow As Integer)

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

        Dim RowNumber As Integer = Conversion.Int(lblRowNumber.Text)
        Dim StnNumber As Integer = Conversion.Int(lblStnNumber.Text)

        'create location starter for array location
        Dim ArryLocation As Integer
        ArryLocation = (gNumberElementsPerRow * RowNumber) - gNumberElementsPerRow

        Dim StationLocator As Integer
        StationLocator = 10000 * StnNumber

        ArryLocation = ArryLocation + StationLocator


        'Const txtReturnRel As Integer = 13
        'Const txtMotionNameRel As Integer = 16
        'Const txtReturnedRel As Integer = 14
        'Const txtAdvanceRel As Integer = 10
        'Const txtAdvancedRel As Integer = 11

        'Const txtReturnAbs As Integer = 3
        'Const txtMotionNameAbs As Integer = 6
        'Const txtReturnedAbs As Integer = 4
        'Const txtAdvanceAbs As Integer = 0
        'Const txtAdvancedAbs As Integer = 1

        'move data to array to later write into new xml fille
        ProcessArray2(ArryLocation + txtAdvanceAbs) = lblAdvanceDepthAbs.Text
        ProcessArray2(ArryLocation + txtAdvancedAbs) = lblAdvanceCoilAbs.Text
        ProcessArray2(ArryLocation + txtReturnAbs) = lblReturnCoilAbs.Text
        ProcessArray2(ArryLocation + txtReturnedAbs) = lblReturnDepthAbs.Text
        ProcessArray2(ArryLocation + txtMotionNameAbs) = lblMotionNameAbs.Text

        ProcessArray2(ArryLocation + txtAdvanceRel) = lblAdvanceDepthSym.Text
        ProcessArray2(ArryLocation + txtAdvancedRel) = lblAdvanceCoilSym.Text
        ProcessArray2(ArryLocation + txtReturnRel) = lblReturnCoilSym.Text
        ProcessArray2(ArryLocation + txtReturnedRel) = lblReturnDepthSym.Text
        ProcessArray2(ArryLocation + txtMotionNameRel) = lblMotionNameSym.Text

        For i = 0 To gNumberElementsPerRow
            If i = txtReturnRel Or
               i = txtMotionNameRel Or
               i = txtReturnedRel Or
               i = txtAdvanceRel Or
               i = txtAdvancedRel Or
               i = txtReturnAbs Or
               i = txtMotionNameAbs Or
               i = txtReturnedAbs Or
               i = txtAdvanceAbs Or
               i = txtAdvancedAbs Then
                'nowt
            Else

                ' ProcessArray2(ArryLocation + i) = "NoValue"
                ProcessArray2(ArryLocation + i) = i + ArryLocation
            End If

        Next




    End Sub






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

            ParseTextList(lstbxRow1Data, gNumberElementsPerRow)

        End If

    End Sub

    Private Sub LstbxStation2Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation2Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow2Data.DataSource = OpenFileToListBox(lstbxStation2Files.SelectedIndex, lstbxStation2Files)

            ParseTextList(lstbxRow2Data, gNumberElementsPerRow)

        End If
    End Sub

    Private Sub LstbxStation3Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation3Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow3Data.DataSource = OpenFileToListBox(lstbxStation3Files.SelectedIndex, lstbxStation3Files)

            ParseTextList(lstbxRow3Data, gNumberElementsPerRow)

        End If
    End Sub

    Private Sub LstbxStation4Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation4Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow4Data.DataSource = OpenFileToListBox(lstbxStation4Files.SelectedIndex, lstbxStation4Files)

            ParseTextList(lstbxRow4Data, gNumberElementsPerRow)

        End If
    End Sub

    Private Sub LstbxStation5Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation5Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow5Data.DataSource = OpenFileToListBox(lstbxStation5Files.SelectedIndex, lstbxStation5Files)

            ParseTextList(lstbxRow5Data, gNumberElementsPerRow)

        End If
    End Sub

    Private Sub LstbxStation6Files_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstbxStation6Files.SelectedIndexChanged
        If Not IsLoadingData Then

            'populate list box for data
            lstbxRow6Data.DataSource = OpenFileToListBox(lstbxStation6Files.SelectedIndex, lstbxStation6Files)

            ParseTextList(lstbxRow6Data, gNumberElementsPerRow)

        End If
    End Sub

    Private Sub BtnCloseBtn_Click(sender As Object, e As EventArgs) Handles btnCloseProject.Click
        lblRawProjectPath.Text = "No Raw Project Path...."

        gNumberElementsPerRow = 0
        lblgNumberElementsPerRow.Text = "gNumberElementsPerRow=:" & gNumberElementsPerRow
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

    Private Sub LoadFormProg(sender As Object, e As EventArgs) Handles MyBase.Load

        ''select load tab
        tabControlTasks.TabPages.Item(0).Select()


    End Sub

    Sub PopulateListBox(ByRef checkboxValue As CheckBox, ByRef listbxFiles As ListBox, ByRef listbxRowData As ListBox)
        'populate list box of row data
        If checkboxValue.Checked Then

            Dim NumListEntries As Integer
            NumListEntries = listbxFiles.Items.Count

            For i = 0 To NumListEntries - 1

                listbxRowData.DataSource = OpenFileToListBox(i, listbxFiles)
                ParseTextList(listbxRowData, gNumberElementsPerRow)

            Next
        End If
    End Sub

    Private Sub lstBoxImportData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBoxImportData.SelectedIndexChanged
        Dim arrySelection As Integer

        arrySelection = Conversion.Int(lstBoxImportData.SelectedItem.ToString)


        lstBoxPLCData.SelectedIndex = arrySelection

        lblImportBoxSelectionNum.Text = arrySelection

        lblPLCDataNumSelected.Text = lstBoxPLCData.SelectedIndex

    End Sub

    Private Sub btnUpdateArray_Click(sender As Object, e As EventArgs) Handles btnUpdateArray.Click


        Dim procString As String
        Dim ProcStringIndex As Integer
        Dim textIDlocation As Integer

        Dim TextIDStrSearch As String = "TextID"

        Dim TextIDToContentDist As Integer = 9

        Dim ContentFooter As String = "</v>"
        Dim ContentFooterDist As Integer


        Dim TextDefaultstr As String = "TextDefault"
        Dim textdefaultlen As Integer
        textdefaultlen = TextDefaultstr.Length

        Dim textdefaultloc As Integer


        Dim ProcString3 As String

        StartTime = My.Computer.Clock.TickCount


        For i = 0 To xmlStrMotionFile.Length - 1

            If xmlStrMotionFile(i).Contains(TextIDStrSearch) Then

                procString = xmlStrMotionFile(i)
                textIDlocation = procString.IndexOf(TextIDStrSearch)

                'distance between "TextID" and start of content = 9
                procString = procString.Remove(0, textIDlocation + TextIDToContentDist)

                'find and remove the footer of "</v>"
                ContentFooterDist = procString.IndexOf(ContentFooter) - 1
                If ContentFooterDist > 1 Then
                    ProcStringIndex = Conversion.Int(procString.Remove(ContentFooterDist, ContentFooter.Length + 1))
                End If


                ''string insersion
                ProcString3 = xmlStrMotionFile(i + 1)

                ''vbLf & "              <v n=""TextDefault"">""To Pick Pounce""</v>"
                ''converts to
                ''vbLf & "              <v n=""TextDefault"">""Test Insert""</v>"

                ''find the location and length of Text default header
                textdefaultloc = ProcString3.IndexOf(TextDefaultstr)


                'find the footer of "<v>"
                ContentFooterDist = procString.IndexOf(ContentFooter) - 1

                'insert at row specified
                procString = procString.Substring(ContentFooterDist)
                'ProcStringIndex = Conversion.Int(procString)


                ProcString3 = ProcString3.Remove(textdefaultloc + textdefaultlen + 3)

                'reassemle XML row using snipped header, insert the next and add the footer of </v>
                ProcString3 = ProcString3 & ProcessArray2(ProcStringIndex) & """" & ContentFooter

                xmlStrMotionFile(i + 1) = ProcString3

                ' Console.WriteLine("TextID:= " & ProcString2 & " TextToUse:= " & ProcString3)





            End If

            'Console.WriteLine(xmlStrMotionFile(i))
        Next



        EndTime = My.Computer.Clock.TickCount

        MsgBox(EndTime - StartTime & "ms", MsgBoxStyle.Information, "Time Taken...")



    End Sub

    Private Sub tabViewData_Click(sender As Object, e As EventArgs) Handles tabViewData.Click

    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BindingNavigator1_RefreshItems(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub
End Class
