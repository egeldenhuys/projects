Imports System.IO
Public Class Form_Add
    Dim _name As String
    Dim _uri As String
    Dim _desc As String
    Dim _localConfigPath As String = "C:\Users\Evert\Dropbox\Public\Applications\Downloader\Applications.txt"
    Private Sub Form_Add_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        _name = boxName.Text
        _uri = boxUri.Text
        _desc = boxDesc.Text

        Dim Writer As StreamWriter
        Dim _writeLine As String
        Writer = New StreamWriter(_localConfigPath, True)
        _writeLine = _name & ";" & _uri & ";" & _desc
        _writeLine = Trim(_writeLine)
        'new line removed
        Writer.WriteLine(_writeLine)
        Writer.Close()
        Form1._LocalRefresh()

        boxName.Text = ""
        boxUri.Text = ""
        boxDesc.Text = ""
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        boxName.Text = ""
        boxUri.Text = ""
        boxDesc.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class