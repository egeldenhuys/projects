Public Class FormAbout


    Private Sub FormAbout_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadInfo()

    End Sub

    Private Sub LoadInfo()
        lblVersion.Text = "Version: " & FormMain.GetVersion

    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class