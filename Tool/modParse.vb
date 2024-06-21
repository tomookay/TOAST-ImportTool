Imports System.Net.Security

Module modParse

    Public Const motionheader_lt As String = "&lt;"
    Public Const motionfooter_gt As String = "&gt;"

    Public Function FindParamInTcDelcare(ByVal InputStr As String, ByVal SearchStr As String) As String
        Dim ProcString As String
        Dim ProcString2 As String
        Dim ProcString3 As String
        Dim delimchar As String = ":="
        Dim delimLen As Integer = delimchar.Length
        Dim delimLocation As Integer

        Dim TC3delimchar As String = ";"
        Dim TC3delimcharLocation As Integer

        Dim TC3SpaceChar As String = " "
        Dim TC3SpaceCharLocation As Integer
        Dim ProcString4 As String = "Unknown"

        ProcString3 = "unknown"

        'vbLf & vbTab & "gNumberElementsPerRow:UINT := 20;  //number of _things_ in each row, buttons, indicators, etc"
        ''convert string value to output value
        If InputStr.Contains(SearchStr) Then
            'MsgBox("Value detected: " & SearchStr)
            delimLocation = InputStr.IndexOf(delimchar)


            ProcString = InputStr.ToString.Substring(delimLocation)
            ProcString2 = ProcString.Remove(0, delimLen)

            TC3delimcharLocation = ProcString2.IndexOf(TC3delimchar)
            If TC3delimcharLocation >= 1 Then
                ProcString3 = ProcString2.Remove(TC3delimcharLocation)
            End If

            TC3SpaceCharLocation = ProcString3.IndexOf(TC3SpaceChar)
            If TC3SpaceCharLocation >= 0 Then
                ProcString4 = ProcString3.Remove(TC3SpaceCharLocation, 1)
            End If

            Return ProcString4


        Else
            'MsgBox("Value not detected")
            Return "NoValue"
            Exit Function

        End If


    End Function

    Function ParseRow(ByVal InputRow As String, ByVal SearchString As String) As String

        Dim startLocation As Integer

        startLocation = InputRow.IndexOf(motionfooter_gt)

        Dim anotherint As Integer

        ''check if string contains 0, 1 or >1 headers, the xml tags <tag><tag>
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

        Dim resultfirst As Char = processString3.First()

        'try harder at removing header spaces
        If processString3.Length > 1 Then
            Do Until resultfirst <> " "
                If resultfirst = " " Then
                    processString3 = processString3.Remove(0, 1)
                End If

                'update checker
                resultfirst = processString3.First()
            Loop
        End If



        If processString3.Contains("   ") Then
            ''snip 3 phantom spaces at the start
            processString3 = processString3.Remove(0, 4)
        End If



        ''   Console.Write(vbCrLf)
        Return processString3

    End Function

    Sub LoadStationMotionPaths(ByRef CheckboxValue As CheckBox, ByVal RawProjectPath As String, ByVal StationNumber As String, ByRef ListboxStationFiles As ListBox)

        Dim stationLocation As String

        'cbS1.Checked
        If CheckboxValue.Checked Then

            ''find station
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

End Module
