Imports System
Imports System.Net
Imports System.IO
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop
'Add exeptions

Public Class FormMain
    'Declare Variables
    Dim _name As String
    Dim _XP As String
    Dim _uri As String
    Dim _uriEdit As String
    Dim _row As Integer
    Dim _clanName As String
    Dim _rowSearch As Integer
    Dim _pageNum As Integer
    Dim _pageTotal As Integer
    Dim _subStrings() As String
    Dim _sourcePath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Sources\"
    Dim _docpath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Competitions\"
    Dim _configPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\config.txt"
    Dim _done As Boolean = False
    Dim _newCompetition As Boolean
    Dim _updateCompetition As Boolean
    Dim _nameFound As Boolean = False
    Dim _clanArray() As String
    Dim i As Integer
    Dim _end As Boolean = False
    Dim _lines As Integer
    Dim oXL As Excel.Application
    Dim oWB As Excel.Workbook

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl1.SelectTab(1)
        lblError.Text = ""
        i = 0
        My.Computer.FileSystem.CreateDirectory(_docpath)
        My.Computer.FileSystem.CreateDirectory(_sourcePath)
        If My.Computer.FileSystem.FileExists(_configPath) = False Then
            Dim Writer As New StreamWriter(_configPath, False)
            Writer.Write("")
            Writer.Close()
        End If
        Dim objStreamReader As StreamReader
        Dim _textLine As String
        objStreamReader = New StreamReader(_configPath)
        _lines = 0
        'Filter out adresses
        Do While objStreamReader.Peek() <> -1
            _textLine = objStreamReader.ReadLine()
            _lines += 1
            If _textLine.Contains("http://services.runescape.com/") = False Then
                ClansList.Items.Add(_textLine)
            End If
        Loop
        objStreamReader.Close()

        i = 0
        'Read config.txt into _clanarray
        objStreamReader = New StreamReader(_configPath)
        ReDim _clanArray(0 To (_lines - 1))
        Do While objStreamReader.Peek() <> -1
            _textLine = objStreamReader.ReadLine()
            _clanArray(i) = _textLine
            i += 1
        Loop
        objStreamReader.Close()
        _done = False
        _nameFound = False
        StatusReady()
    End Sub

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click

        'Assign vallues
        _clanName = boxClanName.Text
        _uri = boxURL.Text
        _pageNum = 1
        _newCompetition = True

        If _uri.Contains("pageNum=") Then
            Dim _replaced As Boolean = False
            Dim i As Integer = 1

            Do While _replaced = False
                If _uri.Contains("pageNum=" & i) Then
                    _uri = Replace(_uri, "pageNum=" & i, "")
                    _replaced = True
                Else
                    i += 1
                End If
            Loop
            _uri = _uri.Remove((_uri.IndexOf("&")), 1)
            lblError.Text = _uri
            lblError.Refresh()
        End If
        Dim objStreamWriter As StreamWriter

        'Pass the file path and the file name to the StreamWriter constructor.

        StatusDownload()
        Try
            Download()
            objStreamWriter = New StreamWriter(_configPath, True)

            objStreamWriter.Write(_clanName & vbNewLine & _uri & vbNewLine)
            objStreamWriter.Close()
        Catch ex1 As WebException
            StatusReady()
            lblError.Text = "Address could not be found"
            Exit Sub
        End Try
        StatusExtracting()
        ExtractInfo()

    End Sub

    Private Sub Download()

        _uriEdit = (_uri & "&pageNum=" & _pageNum)
        Dim client As New WebClient()

        ' Add a user agent header in case the 
        ' requested URI contains a query.
        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")

        Dim data As Stream = client.OpenRead(_uriEdit)
        Dim reader As New StreamReader(data)
        Dim _content As String = reader.ReadToEnd()
        Dim objStreamWriter As StreamWriter

        'Pass the file path and the file name to the StreamWriter constructor.
        objStreamWriter = New StreamWriter _
            (_sourcePath & _clanName & "_" & _pageNum & ".txt", False)

        'Write web page to text file
        objStreamWriter.Write(_content)

        'Close the file.
        objStreamWriter.Close()

        data.Close()
        reader.Close()
    End Sub

    Private Sub ExtractInfo()

        If _newCompetition = True Then
            _row = 2
            Dim objStreamReader As StreamReader
            Dim _textLine As String
            'Pass the file path and the file name to the StreamReader constructor.
            objStreamReader = New StreamReader(_sourcePath & _clanName & "_" & _pageNum & ".txt")
            Dim oExcel As Excel.Application
            Dim oWorkBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet
            Dim oRng As Excel.Range
            ' Start Excel and get Application object.
            oExcel = CType(CreateObject("Excel.Application"), Excel.Application)
            ' Get a new workbook.
            oWorkBook = oExcel.Workbooks.Add
            oSheet = CType(oWorkBook.Worksheets(1), Excel.Worksheet)
            oSheet.Range("A1").Value = "Name"
            oSheet.Range("B1").Value = "Start XP"
            oSheet.Range("C1").Value = "Current XP"
            oSheet.Range("D1").Value = "Gained XP"
            Do While _done = False
                'Read the next line.
                _textLine = objStreamReader.ReadLine

                If _textLine.Contains("<span class=""name"">") Then
                    _subStrings = Split(_textLine, ">")
                    _subStrings = Split(_subStrings(1), "<")
                    _name = _subStrings(0)
                    _name = _name.Replace("�", " ")
                    If _name <> "Name" Then
                        '//TextBox1.Text = TextBox1.Text & _name & vbNewLine
                        oSheet.Range("A" & _row).Value = _name
                    End If
                End If

                If _textLine.Contains("<span class=""totalXP"">") Then
                    _subStrings = Split(_textLine, ">")
                    _subStrings = Split(_subStrings(1), "<")
                    _XP = _subStrings(0)
                    If _XP <> "Total XP" Then
                        '//TextBox1.Text = TextBox1.Text & _XP & vbNewLine
                        oSheet.Range("B" & _row).Value = _XP
                        oSheet.Range("C" & _row).Value = _XP
                        oSheet.Range("D" & _row).Value = "=C" & _row & "-B" & _row
                        _row += 1
                    End If
                End If

                If _textLine.Contains("<li class=""current"">") Then
                    _textLine = objStreamReader.ReadLine
                    _textLine = objStreamReader.ReadLine
                    If _textLine <> "</ul>" Then
                        _subStrings = Split(_textLine, ">")
                        _subStrings = Split(_subStrings(2), "<")
                        _pageTotal = CInt(_subStrings(0))
                    End If
                End If

                If _textLine.Contains("</html>") Then
                    If _pageNum < _pageTotal Then
                        _pageNum += 1
                        StatusDownload()
                        Download()
                        StatusExtracting()
                        objStreamReader.Close()
                        objStreamReader = New StreamReader(_sourcePath & _clanName & "_" & _pageNum & ".txt")
                    Else
                        _done = True
                    End If
                End If
            Loop
            ' AutoFit columns A:D.
            oRng = oSheet.Range("A1", "D1")
            'Set colours A1:D1
            oRng.Interior.Color = RGB(215, 228, 188)
            oRng.Borders.Weight = 2
            'Autofit
            oRng.EntireColumn.AutoFit()
            'Freeze top row
            oSheet.Range("A2", "B2").Select()
            oExcel.ActiveWindow.FreezePanes = True
            'Write Time
            oSheet.Range("F3").Value = "Start XP recorded at"
            oSheet.Range("G3").Value = Date.Now
            oSheet.Range("F4").Value = "Current XP recorded at"
            oSheet.Range("G4").Value = Date.Now
            'Autofit time cells
            oRng = oSheet.Range("F1", "G1")
            oRng.EntireColumn.AutoFit()
            'Select A1
            oSheet.Range("A1").Select()
            objStreamReader.Close()
            oWorkBook.SaveAs(_docpath & _clanName)

            'oExcel.Visible = True
            'oExcel.UserControl = True
            oRng = Nothing
            oSheet = Nothing
            oWorkBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
        End If

        If _updateCompetition = True Then
            Dim objStreamReader As StreamReader
            Dim _textLine As String

            'Pass the file path and the file name to the StreamReader constructor.
            objStreamReader = New StreamReader(_sourcePath & _clanName & "_" & _pageNum & ".txt")
            _rowSearch = 2
            Dim oExcel As New Excel.Application
            Dim oWorkBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet
            Dim oRng As Excel.Range
            ' Start Excel and get Application object.
            oExcel = CType(CreateObject("Excel.Application"), Excel.Application)

            ' Open Workbook
            oWorkBook = oExcel.Workbooks.Open(_docpath & _clanName & ".xlsx")
            oSheet = CType(oWorkBook.ActiveSheet, Excel.Worksheet)
            Do While _done = False
                _textLine = objStreamReader.ReadLine

                If _textLine.Contains("<span class=""name"">") Then
                    _subStrings = Split(_textLine, ">")
                    _subStrings = Split(_subStrings(1), "<")
                    _name = _subStrings(0)
                    _name = _name.Replace("�", " ")

                End If

                If _textLine.Contains("<span class=""totalXP"">") Then
                    _subStrings = Split(_textLine, ">")
                    _subStrings = Split(_subStrings(1), "<")
                    _XP = _subStrings(0)
                    _nameFound = False
                    _rowSearch = 2
                    If _XP <> "Total XP" Then
                        Do While _nameFound = False
                            If oSheet.Range("A" & _rowSearch).Value = _name Then
                                oSheet.Range("C" & _rowSearch).Value = _XP
                                oSheet.Range("E" & _rowSearch).Value = "F"
                                _nameFound = True
                            Else
                                If oSheet.Range("A" & _rowSearch).Value = Nothing Then
                                    oSheet.Range("A" & _rowSearch).Value = _name
                                    oSheet.Range("B" & _rowSearch).Value = "0"
                                    oSheet.Range("C" & _rowSearch).Value = _XP
                                    oSheet.Range("D" & _rowSearch).Value = "=C" & _rowSearch & "-B" & _rowSearch
                                    oSheet.Range("E" & _rowSearch).Value = "Added"
                                    _nameFound = True
                                End If
                                _rowSearch += 1

                            End If
                        Loop
                    End If
                End If

                If _textLine.Contains("<li class=""current"">") Then
                    _textLine = objStreamReader.ReadLine
                    _textLine = objStreamReader.ReadLine
                    If _textLine <> "</ul>" Then
                        _subStrings = Split(_textLine, ">")
                        _subStrings = Split(_subStrings(2), "<")
                        _pageTotal = CInt(_subStrings(0))
                    End If
                End If

                If _textLine.Contains("</html>") Then
                    If _pageNum < _pageTotal Then
                        _pageNum += 1
                        StatusDownload()
                        Download()
                        StatusExtracting()
                        objStreamReader.Close()
                        objStreamReader = New StreamReader(_sourcePath & _clanName & "_" & _pageNum & ".txt")
                    Else
                        _done = True
                    End If
                End If

            Loop ' AutoFit columns A:D.
            oSheet.Range("G4").Value = Date.Now
            oRng = oSheet.Range("A1", "D1")
            oRng.EntireColumn.AutoFit()

            _updateCompetition = False

            oRng = oSheet.Range("F1", "G1")
            oRng.EntireColumn.AutoFit()
            oWorkBook.Save()
            objStreamReader.Close()
            'oExcel.Visible = True
            'oExcel.UserControl = True
            oRng = Nothing
            oSheet = Nothing
            oWorkBook = Nothing
            oExcel.Quit()
            oExcel = Nothing
        End If
        ' Make sure that you release object references.


        'Close the file.

        Reset()
    End Sub

    Private Sub Reset()
        ClansList.Items.Clear()
        i = 0
        _newCompetition = False
        _updateCompetition = False
        Dim objStreamReader As StreamReader
        Dim _textLine As String
        objStreamReader = New StreamReader(_configPath)
        _lines = 0
        Do While objStreamReader.Peek() <> -1
            _textLine = objStreamReader.ReadLine()
            _lines += 1
            If _textLine.Contains("http://services.runescape.com/") = False Then
                ClansList.Items.Add(_textLine)
            End If
        Loop
        objStreamReader.Close()

        i = 0
        objStreamReader = New StreamReader(_configPath)
        ReDim _clanArray(0 To (_lines - 1))
        Do While objStreamReader.Peek() <> -1
            _textLine = objStreamReader.ReadLine()
            _clanArray(i) = _textLine
            i += 1
        Loop
        objStreamReader.Close()
        _done = False
        _nameFound = False
        StatusReady()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        _updateCompetition = True
        _clanName = _clanArray(ClansList.SelectedIndex * 2)
        _uri = _clanArray((ClansList.SelectedIndex * 2) + 1)
        _pageNum = 1
        StatusDownload()
        Download()
        StatusExtracting()
        ExtractInfo()
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

        If btnOpen.Text = "Open" Then
            oXL = CType(CreateObject("Excel.Application"), Excel.Application)
            oXL.Workbooks.Open(_docpath & ClansList.Text & ".xlsx")
            oXL.Visible = True
            'btnOpen.Text = "Close"
            'Else
            ' oWB = Nothing
            ' oXL.Quit()
            ' oXL = Nothing
            'btnOpen.Text = "Open"
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim objStreamWriter As StreamWriter
        Dim _fileContents As String = ""
        Dim i As Integer

        Try
            My.Computer.FileSystem.DeleteFile(_docpath & ClansList.Text & ".xlsx", _
                        FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            'Set writer to config.txt
            objStreamWriter = New StreamWriter(_configPath, False)
            'Sets clan name and uri in array to nothing.
            _clanArray(ClansList.SelectedIndex * 2) = " "
            _clanArray(ClansList.SelectedIndex * 2 + 1) = " "
            'Write clan array to _filecontents
            For i = 0 To (_clanArray.GetUpperBound(0))
                _fileContents = _fileContents & _clanArray(i) & vbNewLine
            Next
            'Trim leading and trailing whitespace
            _fileContents = _fileContents.Trim
            If (ClansList.SelectedIndex - 1) = -1 Then
                Try
                    ClansList.SelectedIndex = 1
                Catch ex1 As ArgumentOutOfRangeException
                    _fileContents = ""
                    objStreamWriter.Write(_fileContents)
                    objStreamWriter.Close()
                    Reset()
                    Exit Sub
                End Try
            End If
            '' DEBUG: MsgBox(_fileContents, MsgBoxStyle.OkOnly)
            'Write _filecontents to config
            objStreamWriter.WriteLine(_fileContents)
            objStreamWriter.Close()
        Catch ex1 As OperationCanceledException
            Exit Sub
        Catch ex2 As FileNotFoundException
            objStreamWriter = New StreamWriter(_configPath)
            _clanArray(ClansList.SelectedIndex * 2) = " "
            _clanArray(ClansList.SelectedIndex * 2 + 1) = " "
            For i = 0 To (_clanArray.GetUpperBound(0))
                _fileContents = _fileContents & _clanArray(i) & vbNewLine
            Next
            _fileContents = _fileContents.Trim
            objStreamWriter.WriteLine(_fileContents)
            objStreamWriter.Close()
            Reset()
            Exit Sub
        Catch ex3 As IndexOutOfRangeException
            MsgBox("Idex out of range", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try
        Reset()
    End Sub

    Private Sub StatusDownload()
        lblStatus1.ForeColor = Color.Red
        lblStatus2.ForeColor = Color.Red
        lblStatus1.Text = "Downloading page " & _pageNum & "..."
        lblStatus2.Text = "Downloading page " & _pageNum & "..."
        lblStatus1.Refresh()
        lblStatus2.Refresh()
    End Sub

    Private Sub StatusExtracting()
        lblStatus1.ForeColor = Color.Red
        lblStatus2.ForeColor = Color.Red
        lblStatus1.Text = "Extracting Data..."
        lblStatus2.Text = "Extracting Data..."
        lblStatus1.Refresh()
        lblStatus2.Refresh()
    End Sub

    Private Sub StatusReady()
        lblStatus1.ForeColor = Color.Green
        lblStatus2.ForeColor = Color.Green
        lblStatus1.Text = "Ready."
        lblStatus2.Text = "Ready."
        lblStatus1.Refresh()
        lblStatus2.Refresh()
    End Sub

    Private Sub DeleteFile()

    End Sub
End Class
