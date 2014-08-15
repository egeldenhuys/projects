Imports System.Net
Imports System.ComponentModel
Public Class Form1

    Dim WC(1) As WebClient

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim File1 As New System.Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20Mod%20Manager/MCVersionHashes.txt")
        Dim File2 As New System.Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20Mod%20Manager/News.txt")

        WC(0) = New WebClient
        WC(1) = New WebClient

        WC(0).DownloadFileAsync(File1, "version.txt")
        WC(1).DownloadFileAsync(File2, "news.txt")

    End Sub
End Class
