Imports System.IO

Public Class Form1
    Dim _Apps() As String
    Dim _Appstmp() As String
    Dim _tmp(1) As String
    Dim i As Integer
    Dim a As Integer
    Dim _num As Integer
    Dim _done As Boolean = False
    Dim _userName As String = My.User.Name.ToString
    Dim _Content As String = ""
    Dim _downloadPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Downloads"
    Dim _configUri As String = "http://dl.dropbox.com/u/57022080/Applications/Downloader/Applications.txt"
    Dim _configPath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Settings\Applications.txt"
    Dim _localConfigPath As String = "C:\Users\Evert\Dropbox\Public\Applications\Downloader\Applications.txt"
    Dim _appName As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _tmp = Split(_userName, "\")
        _userName = _tmp(1)
        If _userName = "Evert" Then
            btnAdd.Visible = True
            btnRemove.Visible = True
            btnEdit.Visible = True
        Else
            Me.Height = 333
        End If

        _Refresh()

        
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        i = 0
        Try
            _done = False
            Do While _done = False
                If _Apps(i) = ListBox1.SelectedItem.ToString Then
                    TextBox1.Text = _Apps(i + 2)
                    _done = True
                Else
                    i += 1
                End If
            Loop
        Catch ex1 As NullReferenceException

        End Try

    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        i = 0
        _done = False
        lblStatus.Visible = True
        lblStatus.Refresh()
        Do While _done = False
            If _Apps(i) = ListBox1.SelectedItem.ToString Then
                _appName = ListBox1.SelectedItem.ToString
                My.Computer.Network.DownloadFile(_Apps(i + 1), _downloadPath & "\" & _appName & ".exe", "", "", False, 60000, True)
                _done = True
            Else
                i += 1
            End If
        Loop
        lblStatus.Visible = False
        lblStatus.Refresh()
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Process.Start("explorer.exe", _downloadPath)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Form_Add.Show()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        i = 0
        _done = False
        Do While _done = False
            If _Apps(i) = ListBox1.SelectedItem.ToString Then
                _done = True
                _Apps(i) = " "
                _Apps(i + 1) = " "
                _Apps(i + 2) = " "
            Else
                i += 1
            End If
        Loop
        reWriteFile()
        TextBox1.Text = ""
    End Sub

    Public Sub _Refresh()
        Try
            My.Computer.Network.DownloadFile(_configUri, _configPath, "", "", False, 20000, True)
        Catch ex1 As System.Net.WebException
            MsgBox("Could not download file", vbOKOnly, "Error")
        End Try

        Dim Reader As StreamReader
        Reader = New StreamReader(_configPath)
        Dim _readLine As String
        _num = 2
        i = 0
        ListBox1.Items.Clear()
        ReDim _Appstmp(0 To 2)
        Do While Reader.Peek <> -1
            ReDim Preserve _Apps(0 To _num)
            _readLine = Reader.ReadLine()
            _Appstmp = Split(_readLine, ";")
            If _readLine <> "" Then
                _Apps(i) = _Appstmp(0)
                ListBox1.Items.Add(_Apps(i))
                i += 1
                _Apps(i) = _Appstmp(1)

                i += 1
                _Apps(i) = _Appstmp(2)

                i += 1
                _num += 3
            End If
        Loop
        Reader.Close()
        TextBox1.Text = ""
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        lblStatus.Visible = True
        lblStatus.Refresh()
        _Refresh()
        lblStatus.Visible = False
        lblStatus.Refresh()
    End Sub

    Public Sub _LocalRefresh()
        Dim Reader As StreamReader
        Reader = New StreamReader(_localConfigPath)
        Dim _readLine As String
        _num = 2
        i = 0
        ListBox1.Items.Clear()
        ReDim _Appstmp(0 To 2)
        Do While Reader.Peek <> -1
            ReDim Preserve _Apps(0 To _num)
            _readLine = Reader.ReadLine()
            If _readLine <> "" Then
                _Appstmp = Split(_readLine, ";")

                _Apps(i) = _Appstmp(0)
                ListBox1.Items.Add(_Apps(i))
                i += 1
                _Apps(i) = _Appstmp(1)

                i += 1
                _Apps(i) = _Appstmp(2)

                i += 1
                _num += 3
            End If
        Loop
        Reader.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Form_Edit.Show()
        i = 0
        _done = False
        Do While _done = False
            If _Apps(i) = ListBox1.SelectedItem.ToString Then
                a = i
                _done = True
                Form_Edit.boxName.Text = _Apps(i)
                Form_Edit.boxUri.Text = _Apps(i + 1)
                Form_Edit.boxDesc.Text = _Apps(i + 2)
            Else
                i += 1
            End If
        Loop
    End Sub

    Public Sub Edit_Entry(ByVal _name As String, ByVal _uri As String, ByVal _desc As String)
        _Apps(a) = _name
        _Apps(a + 1) = _uri
        _Apps(a + 2) = _desc
        reWriteFile()
        TextBox1.Text = ""
    End Sub

    Private Sub reWriteFile()
        _Content = ""
        i = 0
        _done = False
        Do While _done = False

            If _Apps(i) <> " " Then
                _Content = _Content & _Apps(i) & ";"
                i += 1
            End If
            If _Apps(i) <> " " Then
                _Content = _Content & _Apps(i) & ";"
                i += 1
            End If
            If _Apps(i) <> " " Then
                'If i = _Apps.GetUpperBound(0) Then
                '_Content = _Content & _Apps(i)
                'Else
                _Content = _Content & _Apps(i) & vbNewLine
                'End If
            End If

            If i < _Apps.GetUpperBound(0) Then
                i += 1
            Else
                _done = True
            End If

        Loop
        _Content = Trim(_Content)
        Dim Writer As StreamWriter
        Writer = New StreamWriter(_localConfigPath, False)
        'changed
        Writer.Write(_Content)
        Writer.Close()
        _LocalRefresh()
    End Sub


End Class
