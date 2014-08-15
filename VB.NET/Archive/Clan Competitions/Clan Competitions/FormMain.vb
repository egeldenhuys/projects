Imports System
Imports System.Net
Imports System.IO
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop


Public Class FormMain
    Dim _sourcePath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Sources\"
    Dim _docpath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Competitions\"
    Dim _configPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\config.txt"
    Dim OptionsPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Settings.txt"
    Dim _clanNames() As String
    Dim _clanUrls() As String
    Dim Version As String = "2.5"
    

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblVersion.Text = Version
        LoadOptions()

        My.Computer.FileSystem.CreateDirectory(_docpath)
        My.Computer.FileSystem.CreateDirectory(_sourcePath)
        If My.Computer.FileSystem.FileExists(_configPath) = False Then
            Dim Writer As New StreamWriter(_configPath, False)
            Writer.Write("")
            Writer.Close()
        End If

        TabControl1.SelectTab(1)
        LoadCompetitions()
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            boxClanName.Focus()
            boxClanName.SelectAll()
        End If
    End Sub

#Region "tabNewComp"

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim _clanName As String = boxClanName.Text
        Dim _uri As String = boxURL.Text
        lblError.Visible = False

        If _clanName <> "" Then

            If _clanNames.Contains(_clanName) = False Then
                Try
                    If _uri = "" Then
                        _uri = GetUrl(_clanName).ToString
                    End If
                    NewCompetition(_clanName, _uri)

                Catch ex1 As WebException
                    lblError.Text = "Page could not be found."
                    lblError.Visible = True
                    SetStatus("Ready")
                End Try

            Else
                lblError.Visible = True
                lblError.Text = "A competition with that name already exists. Delete the original one first."
            End If
        Else
            lblError.Visible = True
            lblError.Text = "Please enter a clan name."
        End If

        boxClanName.Focus()
        boxClanName.SelectAll()
    End Sub

#End Region

#Region "tabUpdateComp"
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim _SelectedItem As Integer = ClansList.SelectedIndex
        Try
            UpdateCompetition(_clanNames(ClansList.SelectedIndex), _clanUrls(ClansList.SelectedIndex))
        Catch ex1 As IndexOutOfRangeException
            ' Do Nothing
        End Try
        ClansList.SelectedIndex = _SelectedItem
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Try
            OpenCompetition(_clanNames(ClansList.SelectedIndex))
        Catch ex1 As IndexOutOfRangeException
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            DeleteCompetition(ClansList.SelectedIndex, ClansList.SelectedItem.ToString)
        Catch ex1 As IndexOutOfRangeException
        Catch ex2 As System.NullReferenceException
        End Try
    End Sub
#End Region

#Region "tabInfo"
    Private Sub btnDeleteSources_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteSources.Click
        Dim _Response As Integer
        _Response = MsgBox("Are you sure you want to delete all files in: " & _sourcePath & " ? ", MsgBoxStyle.YesNo, "Delete Files?")
        If _Response = vbYes Then
            ' Delete all fines in _sourcePath
            For Each foundFile As String In My.Computer.FileSystem.GetFiles _
                (_sourcePath, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")

                My.Computer.FileSystem.DeleteFile(foundFile)
            Next
        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub NewCompetition(ByVal _clanName As String, ByVal _uri As String)
        Dim _XP As String
        Dim _pageTotal As Integer
        Dim _subStrings() As String
        Dim _name As String
        Dim _done As Boolean = False
        Dim _pageNum As Integer = 1

        Dim _P2PCount As Integer = 0
        Dim _clanMatesCount As Integer = 0


        SetStatus("Downloading", _pageNum)
        DownloadSource(_clanName, _uri, 1)
        SetStatus("Extracting")



        Dim _row As Integer = 2
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

        ' Write Headings
        oSheet.Range("A1").Value = "Name"
        oSheet.Range("B1").Value = "Start XP"
        oSheet.Range("C1").Value = "Current XP"
        oSheet.Range("D1").Value = "Gained XP"
        oSheet.Range("E1").Value = "In Clan"
        oSheet.Range("G5").Value = "Clan Mates"
        oSheet.Range("G6").Value = "P2p Clan Mates"
        oSheet.Range("G7").Value = "Total Xp Gained"
        oSheet.Range("G8").Value = "Total Current XP"
        oSheet.Range("H8").Value = "=SUM(C2:C501)"

        'Write Time
        oSheet.Range("G3").Value = "Start XP recorded at"
        oSheet.Range("H3").Value = Date.Now
        oSheet.Range("G4").Value = "Current XP recorded at"
        oSheet.Range("H4").Value = Date.Now
        'Autofit time cells
        oRng = oSheet.Range("G1", "H1")
        oRng.EntireColumn.AutoFit()

        ' Format Information Cells
        oRng = oSheet.Range("G3", "H8")
        oRng.Interior.Color = RGB(215, 228, 188)
        oRng.Borders.Weight = 2

        oRng = oSheet.Range("H7", "H8")
        oRng.NumberFormat = "#,##0"

        Do While _done = False
            'Read the next line.
            _textLine = objStreamReader.ReadLine

            If _textLine.Contains("<span class=""name"">") Then
                _subStrings = Split(_textLine, ">")
                _subStrings = Split(_subStrings(1), "<")
                _name = _subStrings(0)
                _name = _name.Replace("�", " ")
                If _name <> "Name" Then
                    _clanMatesCount += 1
                    If _name <> "" Then
                        oSheet.Range("A" & _row).Value = _name
                    End If
                End If
            End If

            If _textLine.Contains("<span class=""totalXP"">") Then
                _subStrings = Split(_textLine, ">")
                _subStrings = Split(_subStrings(1), "<")
                _XP = _subStrings(0)
                If _XP <> "Total XP" Then
                    If _XP <> "" Then
                        oSheet.Range("B" & _row).Value = _XP
                        oSheet.Range("C" & _row).Value = _XP
                        oSheet.Range("D" & _row).Value = "=IF(C" & _row & "<> 0, (C" & _row & "-B" & _row & "),0)"
                        _row += 1
                    End If
                End If
            End If


            If _textLine.Contains(">" & _pageNum + 1 & "</a></li>") Then
                _pageTotal = CInt(_pageNum + 1)
            End If

            If _textLine.Contains("<img alt=""Pro""") Then
                _P2PCount += 1
            End If

            If _textLine.Contains("hiscores_global") Then
                _done = True

                lblError.Text = "Clan does not exist."
                lblError.Visible = True
                ' Save document
                objStreamReader.Close()
                'oExcel.Visible = True
                'oExcel.UserControl = True
                oRng = Nothing
                oSheet = Nothing
                oWorkBook.Close(False)
                oWorkBook = Nothing
                oExcel.Quit()
                oExcel = Nothing

                LoadCompetitions()
                Exit Sub
            End If

            If _textLine.Contains("</html>") Then
                If _pageNum < _pageTotal Then
                    _pageNum += 1
                    SetStatus("Downloading", _pageNum)
                    DownloadSource(_clanName, _uri, _pageNum)
                    SetStatus("Extracting")
                    objStreamReader.Close()
                    objStreamReader = New StreamReader(_sourcePath & _clanName & "_" & _pageNum & ".txt")
                Else
                    _done = True
                End If
            End If
        Loop
        ' Write Variables
        oSheet.Range("H5").Value = _clanMatesCount
        oSheet.Range("H6").Value = _P2PCount
        oSheet.Range("H7").Value = "0"
        ' Select A1:E1
        oRng = oSheet.Range("A1", "E1")
        'Set colours A1:E1
        oRng.Interior.Color = RGB(215, 228, 188)
        oRng.Borders.Weight = 2
        'Autofit
        oRng.EntireColumn.AutoFit()
        'Freeze top row
        oSheet.Range("A2", "B2").Select()
        oExcel.ActiveWindow.FreezePanes = True

        oRng = oSheet.Range("A1", "H1")
        oRng.EntireColumn.AutoFit()

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

        SaveCompetition(_clanName, _uri)
        LoadCompetitions()

        If chbNextTab.Checked = True Then
            TabControl1.SelectedIndex = 1
            ClansList.SelectedIndex = (ClansList.Items.Count - 1)
        End If
    End Sub

    Private Sub DownloadSource(ByVal _clanName As String, ByVal _uri As String, ByVal _pageNum As Integer)

        Dim _uriEdit As String = (_uri & "&pageNum=" & _pageNum)
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

    Private Sub UpdateCompetition(ByVal _clanName As String, ByVal _uri As String)
        Dim _pageTotal As Integer
        Dim _subStrings() As String
        Dim _XP As String
        Dim _name As String = ""
        Dim _done As Boolean = False
        Dim _rowSearch As Integer = 2
        Dim _nameFound As Boolean = False
        Dim _pageNum As Integer = 1

        Dim _clanMateCount As Integer = 0
        Dim _P2PCount As Integer = 0

        SetStatus("Downloading", _pageNum)
        DownloadSource(_clanName, _uri, 1)
        SetStatus("Extracting")

        Dim objStreamReader As StreamReader
        Dim _textLine As String
        'Pass the file path and the file name to the StreamReader constructor.
        objStreamReader = New StreamReader(_sourcePath & _clanName & "_" & _pageNum & ".txt")

        Dim oExcel As New Excel.Application
        Dim oWorkBook As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Dim oRng As Excel.Range
        ' Start Excel and get Application object.
        oExcel = CType(CreateObject("Excel.Application"), Excel.Application)

        ' Open Workbook
        oWorkBook = oExcel.Workbooks.Open(_docpath & _clanName & ".xlsx")
        oSheet = CType(oWorkBook.ActiveSheet, Excel.Worksheet)
        ' Load ClanMateCount
        _clanMateCount = CInt(oSheet.Range("H5").Value) + 1
        ' Clear Cells
        oSheet.Range("C2", "C" & _clanMateCount).Value = "0"
        oSheet.Range("E2", "E" & _clanMateCount).Value = "F"

        _clanMateCount = 0
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

                        If oSheet.Range("A" & _rowSearch).Value Is Nothing Then
                            oSheet.Range("A" & _rowSearch).Value = _name
                            oSheet.Range("B" & _rowSearch).Value = "0"
                            oSheet.Range("C" & _rowSearch).Value = _XP
                            oSheet.Range("D" & _rowSearch).Value = "=IF(C" & _rowSearch & "<> 0, (C" & _rowSearch & "-B" & _rowSearch & "),0)"
                            oSheet.Range("E" & _rowSearch).Value = "A"
                            _nameFound = True
                            _clanMateCount += 1
                        Else
                            If oSheet.Range("A" & _rowSearch).Value.ToString = _name Then
                                oSheet.Range("C" & _rowSearch).Value = _XP
                                oSheet.Range("E" & _rowSearch).Value = ""
                                _nameFound = True
                                _clanMateCount += 1
                            End If
                            _rowSearch += 1
                        End If

                    Loop
                End If
            End If

            If _textLine.Contains(">" & _pageNum + 1 & "</a></li>") Then
                _pageTotal = CInt(_pageNum + 1)
            End If

            If _textLine.Contains("<img alt=""Pro""") Then
                _P2PCount += 1
            End If

            If _textLine.Contains("</html>") Then
                If _pageNum < _pageTotal Then
                    _pageNum += 1
                    SetStatus("Downloading", _pageNum)
                    DownloadSource(_clanName, _uri, _pageNum)
                    SetStatus("Extracting")
                    objStreamReader.Close()
                    objStreamReader = New StreamReader(_sourcePath & _clanName & "_" & _pageNum & ".txt")
                Else
                    _done = True
                End If
            End If

        Loop

        oSheet.Range("H4").Value = Date.Now
        oSheet.Range("H5").Value = _clanMateCount
        oSheet.Range("H6").Value = _P2PCount
        oSheet.Range("H7").Value = "=SUM(D2:D" & _clanMateCount + 1 & ")"
        ' AutoFit columns A:D.
        oRng = oSheet.Range("A1", "D1")
        oRng.EntireColumn.AutoFit()
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


        LoadCompetitions()
    End Sub

    Private Sub DeleteCompetition(ByVal _clanIndex As Integer, ByVal _clanName As String)
        lblError2.Visible = False
        Dim _fileContents As String = ""
        Dim _selectedIndex As Integer = ClansList.SelectedIndex

        Try
            My.Computer.FileSystem.DeleteFile(_docpath & _clanName & ".xlsx")
            RemoveComp(_clanIndex)
            LoadCompetitions()
            SelectNextItem(_selectedIndex)
        Catch ex1 As FileNotFoundException

            ' Check for other extention
            Try
                My.Computer.FileSystem.DeleteFile(_docpath & _clanName & ".xls")
            Catch ex2 As FileNotFoundException
                RemoveComp(_clanIndex)
                LoadCompetitions()
                SelectNextItem(_selectedIndex)
            End Try

        Catch ex2 As IOException
            lblError2.Text = "Please close the competition before deleting it."
            lblError2.Visible = True
        Finally

        End Try
    End Sub

    Private Sub OpenCompetition(ByVal _clanName As String)
        Dim oXL As Excel.Application
        oXL = CType(CreateObject("Excel.Application"), Excel.Application)

        Try
            oXL.Workbooks.Open(_docpath & _clanName & ".Xlsx")
        Catch ex1 As Runtime.InteropServices.COMException
            oXL.Workbooks.Open(_docpath & _clanName & ".Xls")
        Finally
            oXL.Visible = True
        End Try


    End Sub

    Private Sub LoadCompetitions()
        Dim _selectedIndex As Integer = ClansList.SelectedIndex
        Dim i As Integer = 0
        Dim _lines As Integer = 0
        Dim _substrings(1) As String

        Dim objStreamReader As StreamReader
        Dim _textLine As String
        objStreamReader = New StreamReader(_configPath)
        _lines = 0
        ClansList.Items.Clear()
        ' Read clans to list box
        Do While objStreamReader.Peek() <> -1
            _textLine = objStreamReader.ReadLine()
            _lines += 1
            _substrings = Split(_textLine, ";")
            ClansList.Items.Add(_substrings(0))
        Loop
        objStreamReader.Close()

        i = 0
        'Read config.txt into arrays
        objStreamReader = New StreamReader(_configPath)
        ReDim _clanNames(0 To (_lines))
        ReDim _clanUrls(0 To (_lines))

        Do While objStreamReader.Peek() <> -1
            _textLine = objStreamReader.ReadLine()
            _substrings = Split(_textLine, ";")
            _clanNames(i) = _substrings(0)
            _clanUrls(i) = _substrings(1)
            i += 1
        Loop
        objStreamReader.Close()

        SetStatus("Ready")
    End Sub

    Private Sub SaveCompetition(ByVal _clanName As String, ByVal _url As String)
        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(_configPath, True)
        objStreamWriter.Write(_clanName & ";" & _url & vbNewLine)
        objStreamWriter.Close()
    End Sub

    Private Function GetUrl(ByVal _clanName As String) As String
        Dim _url As String
        _clanName = Replace(_clanName, " ", "+")
        _url = "http://services.runescape.com/m=clan-hiscores/members.ws?clanName=" & _clanName & "&pageSize=45&ranking=51"
        Return _url
    End Function

    Private Sub SelectNextItem(ByVal _SelectedIndex As Integer)
        ' Select next item
        Select Case _selectedIndex
            Case -1
                ' Do Nothing
            Case 0
                If ClansList.Items.Count > 1 Then
                    ClansList.SelectedIndex = 0
                End If

            Case Else
                ClansList.SelectedIndex = (_selectedIndex - 1)
        End Select
    End Sub

    Private Sub RemoveComp(ByVal _clanIndex As Integer)
        Dim _fileContents As String = ""

        Dim objStreamWriter As StreamWriter
        objStreamWriter = New StreamWriter(_configPath, False)

        _clanNames(_clanIndex) = ""
        _clanUrls(_clanIndex) = ""
        'Write clan array to _filecontents
        For i = 0 To (_clanNames.GetUpperBound(0))
            If _clanNames(i) <> "" Then
                _fileContents = _fileContents & _clanNames(i) & ";" & _clanUrls(i) & vbNewLine
            End If
        Next

        'Trim leading and trailing whitespace
        _fileContents = _fileContents.Trim
        If (ClansList.SelectedIndex - 1) = -1 Then
            Try
                ClansList.SelectedIndex = 1
            Catch ex1 As ArgumentOutOfRangeException
                _fileContents = ""
            End Try
        End If

        objStreamWriter.Write(_fileContents)

        objStreamWriter.Close()
    End Sub

    Private Sub SetError(ByVal _description As String, ByVal _pageNum As Integer)

        Select Case _pageNum
            Case 1
                lblError.Text = _description
                lblError.Visible = True
            Case 2
                lblError2.Text = _description
                lblError2.Visible = True
        End Select
        lblError.Visible = True

    End Sub
    Private Sub SetStatus(ByVal _Status As String, Optional ByVal _pageNumber As Integer = 999)
        Select Case _Status
            Case "Downloading"
                lblStatus1.ForeColor = Color.Red
                lblStatus2.ForeColor = Color.Red
                lblStatus1.Text = "Downloading page " & _pageNumber & "..."
                lblStatus2.Text = "Downloading page " & _pageNumber & "..."

            Case "Extracting"
                lblStatus1.ForeColor = Color.Red
                lblStatus2.ForeColor = Color.Red
                lblStatus1.Text = "Extracting Data..."
                lblStatus2.Text = "Extracting Data..."

            Case "Ready"
                lblStatus1.ForeColor = Color.Green
                lblStatus2.ForeColor = Color.Green
                lblStatus1.Text = "Ready."
                lblStatus2.Text = "Ready."
        End Select

        lblStatus1.Refresh()
        lblStatus2.Refresh()

    End Sub

#End Region

    Private Sub FormMain_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        SaveOptions()
    End Sub
    Private Sub LoadOptions()
        If My.Computer.FileSystem.FileExists(OptionsPath) Then
            Dim Substrings(0 To 1) As String
            Dim Reader As StreamReader
            Dim TextLine As String
            Reader = New StreamReader(OptionsPath)
            Do While Reader.Peek <> -1
                TextLine = Reader.ReadLine()
                Substrings = Split(TextLine, ";")
                Select Case Substrings(0)
                    Case "NextTab"
                        If Substrings(1) = "True" Then
                            chbNextTab.Checked = True
                        Else
                            chbNextTab.Checked = False
                        End If
                End Select
            Loop
            Reader.Close()
        End If

    End Sub
    Private Sub SaveOptions()
        Dim Writer As StreamWriter
        Writer = New StreamWriter(OptionsPath, False)
        If chbNextTab.Checked = True Then
            Writer.WriteLine("NextTab;True")
        Else
            Writer.WriteLine("NextTab;False")
        End If

        Writer.Close()

    End Sub
End Class
