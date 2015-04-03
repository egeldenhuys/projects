Imports System.IO

Public Class FormMain

    Dim UpdateUri As New Uri("https://dl.dropbox.com/u/57022080/Programs/Clock/LatestVersion.txt")

    Dim CurrentVersion As String

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Get file version
        Dim fVersion As FileVersionInfo = FileVersionInfo.GetVersionInfo(My.Computer.FileSystem.CurrentDirectory & "\" & My.Application.Info.AssemblyName & ".exe")

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnCompactOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnCompactOpen.Click
        FormTime.Show()
    End Sub

End Class