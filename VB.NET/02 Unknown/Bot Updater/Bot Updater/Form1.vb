Imports System.Net
Imports System.IO
Imports System.ComponentModel

Public Class Form1
    Dim WithEvents WC As New WebClient
    Dim WithEvents WCConfig As New WebClient

    Dim LatestVersion As String
    Dim CurrentVersion As String = "1.1"

    Dim Done As Boolean = False

    Dim ConfigUrl As String = "http://dl.dropbox.com/u/57022080/Runescape%20Bots/Updater/Config.txt"
    Dim AppUrl As String = "http://dl.dropbox.com/u/57022080/Runescape%20Bots/Updater/Bot%20Updater.exe"
    Dim FishDropperV3Url As String = "http://dl.dropbox.com/u/57022080/Runescape%20Bots/Fish%20Dropper%20v3.au3"


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnDownload_Click(sender As System.Object, e As System.EventArgs) Handles btnDownload.Click

        ProgressBar1.Visible = True
        lblProgress.Visible = True
        Done = False
        Try
            Select Case ListBox1.SelectedItem.ToString
                Case "Fish Dropper v3"
                    WC.DownloadFileAsync(New Uri(FishDropperV3Url), "Fish Dropper v3.au3")
            End Select

        Catch ex1 As NullReferenceException
            'Nothing
        End Try

        Done = False
        Me.Refresh()
    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged

        lblProgress.Text = Math.Round((e.BytesReceived / 1024), 2) & " kb" & "/" & _
                           Math.Round((e.TotalBytesToReceive / 1024), 2) & " kb"

        ProgressBar1.Value = e.ProgressPercentage

        If e.ProgressPercentage = 100 Then
            lblProgress.Text = "Complete"
            If Done = False Then
                ' Process.Start("explorer.exe", My.Computer.FileSystem.CurrentDirectory)
                Done = True
            End If

        End If
    End Sub


    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Done = False
        WC.DownloadFileAsync(New Uri(AppUrl), "Bot Updater v" & LatestVersion & ".exe")
    End Sub

    Private Sub LoadConfig()
        WCConfig.DownloadFileAsync(New Uri(ConfigUrl), "Config.txt")
        Me.Refresh()
    End Sub

    Private Sub WCConfig_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WCConfig.DownloadProgressChanged

        lblProgress.Text = Math.Round((e.BytesReceived / 1024), 2) & " kb" & "/" & _
                           Math.Round((e.TotalBytesToReceive / 1024), 2) & " kb"

        ProgressBar1.Value = e.ProgressPercentage


        If e.ProgressPercentage = 100 Then
            lblProgress.Text = "Complete"
            If Done = False Then
                LoadInfo()
                Done = True
            End If
        End If
    End Sub

    Private Sub LoadInfo()
        Dim Substrings() As String

        Dim Reader As StreamReader
        Reader = New StreamReader("Config.txt")
        Dim _readLine As String

        Do While Reader.Peek <> -1
            _readLine = Reader.ReadLine
            Substrings = Split(_readLine, "=")

            Select Case Substrings(0)
                Case "Latest Version"
                    LatestVersion = Substrings(1)

                    If CurrentVersion <> LatestVersion Then
                        lblNewVersion.Visible = True
                        btnUpdate.Visible = True
                    End If

            End Select
        Loop

        Reader.Close()
        Reader.Dispose()

        Done = False
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Done = False
        LoadConfig()
    End Sub

    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            My.Computer.FileSystem.DeleteFile("Config.txt")
        Catch ex1 As FileNotFoundException

        End Try
    End Sub
End Class
