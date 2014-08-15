Imports System.Net
Imports System.ComponentModel

Public Class Form1

    Dim WithEvents WC1 As New WebClient
    Dim WithEvents WC2 As New WebClient
    Dim WithEvents WC3 As New WebClient
    Dim WithEvents WC4 As New WebClient

    Dim InfoReader1 As System.IO.FileInfo
    Dim InfoReader2 As System.IO.FileInfo
    Dim InfoReader3 As System.IO.FileInfo
    Dim InfoReader4 As System.IO.FileInfo

    Dim ID1 As Integer = 0
    Dim ID2 As Integer = 100
    Dim ID3 As Integer = 200
    Dim ID4 As Integer = 300

    Dim ImagesDownloaded1 As Integer
    Dim ImagesDownloaded2 As Integer
    Dim ImagesDownloaded3 As Integer
    Dim ImagesDownloaded4 As Integer

    Dim CancelPending As Boolean = False

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        btnStop.Enabled = False
        Me.Text = "CARROT"
        My.Computer.FileSystem.CreateDirectory("RS Objects")

    End Sub

    Private Sub btnDownload_Click(sender As System.Object, e As System.EventArgs) Handles btnDownload.Click
        CancelPending = False

        WC1.DownloadFileAsync(New Uri("http://dropstatsv1.vacau.com/"), "RS Objects\Object_" & ID1 & ".php")
        'WC2.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID2), "RS Objects\Object_" & ID2 & ".png")
        'WC3.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID3), "RS Objects\Object_" & ID3 & ".png")
        'WC4.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID4), "RS Objects\Object_" & ID4 & ".png")

        btnDownload.Enabled = False
        btnStop.Enabled = True
    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click
        CancelPending = True
        btnStop.Enabled = False
        btnDownload.Enabled = True
    End Sub

    Private Sub WC1_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC1.DownloadFileCompleted
        InfoReader1 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID1 & ".png")

        If InfoReader1.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID1 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded1 += 1
        End If

        ID1 += 1
        lblImages1.Text = CStr(ImagesDownloaded1) & "(" & CStr(ID1) & ")"
        lblTotal.Text = CStr(ImagesDownloaded1 + ImagesDownloaded2 + ImagesDownloaded3 + ImagesDownloaded4) & "(" & CStr(ID1 + ID2 + ID3 + ID4) & ")"

        If CancelPending = False Then
            WC1.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID1), "RS Objects\Object_" & ID1 & ".png")
        End If

    End Sub

    Private Sub WC2_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC1.DownloadFileCompleted
        InfoReader2 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID2 & ".png")

        If InfoReader2.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID2 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded2 += 1
        End If

        ID2 += 1
        lblImages2.Text = CStr(ImagesDownloaded2) & "(" & CStr(ID2) & ")"
        lblTotal.Text = CStr(ImagesDownloaded1 + ImagesDownloaded2 + ImagesDownloaded3 + ImagesDownloaded4) & "(" & CStr(ID1 + ID2 + ID3 + ID4) & ")"

        If CancelPending = False Then
            WC2.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID2), "RS Objects\Object_" & ID2 & ".png")
        End If

    End Sub

    Private Sub WC3_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC3.DownloadFileCompleted
        InfoReader3 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID3 & ".png")

        If InfoReader3.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID3 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        Else
            ImagesDownloaded3 += 1
        End If

        ID3 += 1
        lblImages3.Text = CStr(ImagesDownloaded3) & "(" & CStr(ID3) & ")"
        lblTotal.Text = CStr(ImagesDownloaded1 + ImagesDownloaded2 + ImagesDownloaded3 + ImagesDownloaded4) & "(" & CStr(ID1 + ID2 + ID3 + ID4) & ")"

        If CancelPending = False Then
            WC3.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID3), "RS Objects\Object_" & ID3 & ".png")
        End If

    End Sub

    Private Sub WC4_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC4.DownloadFileCompleted
        InfoReader4 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID4 & ".png")

        If InfoReader4.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID4 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded4 += 1
        End If

        ID4 += 1
        lblImages4.Text = CStr(ImagesDownloaded4) & "(" & CStr(ID4) & ")"
        lblTotal.Text = CStr(ImagesDownloaded1 + ImagesDownloaded2 + ImagesDownloaded3 + ImagesDownloaded4) & "(" & CStr(ID1 + ID2 + ID3 + ID4) & ")"

        If CancelPending = False Then
            WC4.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID4), "RS Objects\Object_" & ID4 & ".png")
        End If

    End Sub
End Class
