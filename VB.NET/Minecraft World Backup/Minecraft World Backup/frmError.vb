Public Class frmError

    Private Sub frmError_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub ShowError(ByVal errorText As String)
        txtError.Text = errorText
        Me.ShowDialog()

    End Sub
End Class