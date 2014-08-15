Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
    End Sub
End Class
