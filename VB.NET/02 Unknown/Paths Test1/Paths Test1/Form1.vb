Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.Text = My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData
        Label2.Text = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData
        Label3.Text = My.Computer.FileSystem.SpecialDirectories.ProgramFiles
        Label4.Text = My.Computer.FileSystem.SpecialDirectories.Programs
        Label5.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
    End Sub
End Class
