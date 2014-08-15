Imports System.Net
Imports System.ComponentModel


Public Class FormMain

    Dim ClockFileUri() As Uri

    Dim WithEvents WC As WebClient


    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClockFileUri(0) = New Uri("https://dl.dropbox.com/u/57022080/Programs/Clock/ClockManager.exe")
        ClockFileUri(1) = New Uri("https://dl.dropbox.com/u/57022080/Programs/Clock/TrollPrograms.dll")

    End Sub

    Private Sub btnDestination_Click(sender As System.Object, e As System.EventArgs) Handles btnDestination.Click
        FolderBrowserDialog1.ShowDialog()
        txtDestination.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub DownloadFiles()
        lblDownStatus.Visible = True
        prgDown.Visible = True

        lblDownStatus.Text = "ClockManager.exe"

        WC.DownloadFileAsync(ClockFileUri(0), "ClockManager.exe")

    End Sub

    Private Sub DownloadProgressChanged(sender As System.Object, e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged


    End Sub

    Private Sub DownloadFinished(sender As System.Object, e As AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted


    End Sub

End Class