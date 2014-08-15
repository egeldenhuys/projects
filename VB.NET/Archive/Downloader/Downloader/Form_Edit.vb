Imports System.IO
Public Class Form_Edit
    Dim _name As String
    Dim _uri As String
    Dim _desc As String
    Private Sub Form_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        _name = boxName.Text
        _uri = boxUri.Text
        _desc = boxDesc.Text
        Form1.Edit_Entry(_name, _uri, _desc)
        Me.Close()
    End Sub

End Class