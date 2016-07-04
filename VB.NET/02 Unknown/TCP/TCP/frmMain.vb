Public Class frmMain

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClient_Click(sender As System.Object, e As System.EventArgs) Handles btnClient.Click
        frmClient.Show()

    End Sub

    Private Sub btnServer_Click(sender As System.Object, e As System.EventArgs) Handles btnServer.Click
        frmServer.Show()

    End Sub
End Class
