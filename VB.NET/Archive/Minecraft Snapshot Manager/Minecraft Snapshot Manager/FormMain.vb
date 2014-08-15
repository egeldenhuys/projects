Imports System.Net
Imports System.IO
Imports System.ComponentModel


Public Class FormMain

    Dim Snapshot_12w29a As New Uri("http://assets.minecraft.net/12w39a/minecraft.jar")
    Dim VersionUri As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20Snapshot%20Manager/Version.txt")
    Dim ProgramUri As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20Snapshot%20Manager/Minecraft%20Snapshot%20Manager.exe")

    Dim AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

    Dim WithEvents WC As New WebClient
    Dim WithEvents WC2 As New WebClient
    Dim WithEvents WC3 As New WebClient


    Dim CurrentVersion As String = "1.0.0"
    Dim LatestVersion As String



    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label3.Text = CurrentVersion
    End Sub


    Private Sub btnInstall_Click(sender As System.Object, e As System.EventArgs) Handles btnInstall.Click
        CreateBackup()
        DownloadSnapshot()

    End Sub

    Private Sub CreateBackup()
        If My.Computer.FileSystem.FileExists(AppData & "\.minecraft\bin\minecraft MSM Backup.jar") = False Then
            My.Computer.FileSystem.CopyFile(AppData & "\.minecraft\bin\minecraft.jar", AppData & "\.minecraft\bin\minecraft MSM Backup.jar", False)
        End If

    End Sub

    Private Sub DownloadSnapshot()
        WC.DownloadFileAsync(Snapshot_12w29a, AppData & "\.minecraft\bin\minecraft.jar")

    End Sub

    Private Sub WC_Finished(sender As Object, e As AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted

        lblStatus.Text = "Finished (100%)"

    End Sub

    Private Sub WC_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        lblStatus.Text = (Math.Round((e.BytesReceived / 1048576), 3) & " MB / " & _
                          (Math.Round((e.TotalBytesToReceive / 1048576), 3) & " MB")) & _
                      " (" & (CInt((e.BytesReceived / e.TotalBytesToReceive) * 100)) & "%)"


        ProgressBar1.Value = CInt((e.BytesReceived / e.TotalBytesToReceive) * 100)
        lblStatus.Visible = True
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Label2.Visible = True
        CreateBackup()
        DownloadSnapshot()

    End Sub

    Private Sub CheckForUpdate()

        WC2.DownloadStringAsync(VersionUri)

    End Sub

    Private Sub WC2_Finished(sender As Object, e As DownloadStringCompletedEventArgs) Handles WC2.DownloadStringCompleted

        LatestVersion = e.Result
        MsgBox(LatestVersion)
        UpdateProgram()

    End Sub


    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        CheckForUpdate()

    End Sub

    Private Sub UpdateProgram()

        If LatestVersion <> CurrentVersion Then
            If MsgBox("A new version is available. Do you want to download it now?", MsgBoxStyle.YesNo, "New Version") = MsgBoxResult.Yes Then
                FolderBrowserDialog1.ShowDialog()

                If FolderBrowserDialog1.SelectedPath <> Nothing Then
                    WC3.DownloadFileAsync(ProgramUri, FolderBrowserDialog1.SelectedPath & "\Minecraft Snapshot Manager.exe")
                End If

            End If


        Else
            MsgBox("You have the latest version", MsgBoxStyle.OkOnly, "No Updates available")


        End If

    End Sub

    Private Sub WC3_Finished(sender As Object, e As AsyncCompletedEventArgs) Handles WC3.DownloadFileCompleted

        MsgBox("The Latest version has been downloaded")
    End Sub

End Class
