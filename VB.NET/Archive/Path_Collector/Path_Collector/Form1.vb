Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.AppendText("CurrentUserApplicationData: " & My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & vbNewLine)
        TextBox1.AppendText("%Appdata%: " & Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & vbNewLine)
        TextBox1.AppendText("MyDocuments: " & My.Computer.FileSystem.SpecialDirectories.MyDocuments & vbNewLine)
        TextBox1.AppendText("ProgramFiles: " & My.Computer.FileSystem.SpecialDirectories.ProgramFiles & vbNewLine)
        TextBox1.AppendText("All users AppData: " & My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData)

    End Sub
End Class
