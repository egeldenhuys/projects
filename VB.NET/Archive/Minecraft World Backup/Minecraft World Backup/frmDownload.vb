Imports System.Net
Imports System.ComponentModel

Public Class frmDownload

    Dim WithEvents Wc7zip As WebClient
    Dim _7zProgress As Integer = 1

    ' == Paths ==
    ' Note: Paths do not have a "\" at the end and needs to be added when used.
    Dim currentDir As String = Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory
    Dim AppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim TrollFolderPath As String = AppDataPath & "\Troll Programs"
    Dim ProgramFolder As String = TrollFolderPath & "\Minecraft World backup"
    Dim _7zipFolder As String = TrollFolderPath & "\shared\7za920"

    ' -- URIs --

    Dim UriVersion As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20World%20Backup/version.txt")
    Dim UriDownload As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20World%20Backup/Minecraft%20World%20Backup.exe")
    Dim _7z1 As New Uri("https://dl.dropbox.com/u/57022080/Programs/7za920/7za.exe")
    Dim _7z2 As New Uri("https://dl.dropbox.com/u/57022080/Programs/7za920/7-zip.chm")
    Dim _7z3 As New Uri("https://dl.dropbox.com/u/57022080/Programs/7za920/license.txt")
    Dim _7z4 As New Uri("https://dl.dropbox.com/u/57022080/Programs/7za920/readme.txt")

    Private Sub frmDownload_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DownloadFile(ByVal fileGroup As String)

        Select Case fileGroup

            Case "Program"

            Case "7zip"

        End Select

    End Sub

    Private Sub Download7zip()
        _7zProgress = 1
        Wc7zip.DownloadFileAsync(_7z1, _7zipFolder & "7za.exe")

    End Sub

    Private Sub WC7zip_DownloadFinished(sender As Object, e As AsyncCompletedEventArgs) Handles Wc7zip.DownloadFileCompleted

        _7zProgress += 1

        Select Case _7zProgress
            Case 2
                Wc7zip.DownloadFileAsync(_7z2, _7zipFolder & "\7-zip.chm")

            Case 3
                Wc7zip.DownloadFileAsync(_7z3, _7zipFolder & "\license.txt")

            Case 4
                Wc7zip.DownloadFileAsync(_7z4, _7zipFolder & "\Readme.txt")

            Case 5

        End Select

    End Sub

    Private Sub WC7zip_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles Wc7zip.DownloadProgressChanged

    End Sub

End Class