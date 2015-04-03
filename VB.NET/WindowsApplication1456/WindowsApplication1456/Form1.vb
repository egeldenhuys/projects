Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim PNUTZDLL As New PNUTZ.MyFunctions

        Label1.Text = PNUTZDLL.MoodMessage()
        Dim File1 As My.Resources
        My.Computer.FileSystem.CopyFile(
    End Sub
End Class
