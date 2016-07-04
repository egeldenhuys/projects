Imports System.Net
Imports System.ComponentModel

Public Class frmChangeLog
    Dim OutputText As String

    Dim WithEvents WC3 As New WebClient
    Dim ChangeLogUri As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20World%20Backup/changeLog.txt")


    Private Sub frmChangeLog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If bgwWebClient.IsBusy = False Then
            bgwWebClient.RunWorkerAsync()
        End If

    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub DownloadLog()
        Try
            Label1.Visible = False
            OutputText = "Downloading Change Log..."
            bgwWebClient.ReportProgress(1)
            OutputText = WC3.DownloadString(ChangeLogUri).Replace("	", "    ")
            bgwWebClient.ReportProgress(1)

        Catch ex1 As WebException
            Label1.Visible = True
            OutputText = "Could not connect to server!"
            bgwWebClient.ReportProgress(1)

        Catch ex As Exception
            frmError.ShowError(ex.ToString)

        End Try

    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click

        If bgwWebClient.IsBusy = False Then
            bgwWebClient.RunWorkerAsync()
        End If

    End Sub

    Private Sub bgwWebClient_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwWebClient.DoWork
        DownloadLog()
    End Sub

    Private Sub bgwWebClient_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwWebClient.ProgressChanged

        Select Case e.ProgressPercentage
            Case 1 ' Refresh textbox
                txtChangeLog.Text = OutputText
        End Select
    End Sub
End Class