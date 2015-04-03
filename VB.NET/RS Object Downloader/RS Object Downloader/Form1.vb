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
    Dim ID2 As Integer = 500
    Dim ID3 As Integer = 1000
    Dim ID4 As Integer = 1500

    Dim ImagesDownloaded1 As Integer = 0
    Dim ImagesDownloaded2 As Integer = 0
    Dim ImagesDownloaded3 As Integer = 0
    Dim ImagesDownloaded4 As Integer = 0

    Dim TotalIDs As Integer = 0

    Dim CancelPending As Boolean = False

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        My.Computer.FileSystem.CreateDirectory("RS Objects\")

    End Sub

    Private Sub btnDownload_Click(sender As System.Object, e As System.EventArgs) Handles btnDownload.Click

        CancelPending = False

        WC1.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID1), "RS Objects\Object_" & ID1 & ".png")
        WC2.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID2), "RS Objects\Object_" & ID2 & ".png")
        WC3.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID3), "RS Objects\Object_" & ID3 & ".png")
        WC4.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID4), "RS Objects\Object_" & ID4 & ".png")

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
        TotalIDs += 1

        Select Case ID1
            Case 500
                ID1 = 2000

            Case 2500
                ID1 = 4000

            Case 4500
                ID1 = 6000

            Case 6500
                ID1 = 8000

            Case 8500
                ID1 = 10000

            Case 10500
                ID1 = 12000

            Case 12500
                ID1 = 14000

            Case 14500
                ID1 = 16000

            Case 16500
                ID1 = 18000

            Case 18500
                ID1 = 20000

        End Select

        lblImages1.Text = CStr(ImagesDownloaded1) & " (" & CStr(ID1) & ")"
        lblTotal.Text = CStr(ImagesDownloaded1 + ImagesDownloaded2 + ImagesDownloaded3 + ImagesDownloaded4) & " (" & TotalIDs & ")"

        If CancelPending = False Then
            WC1.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID1), "RS Objects\Object_" & ID1 & ".png")
        End If

    End Sub

    Private Sub WC2_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC2.DownloadFileCompleted
        InfoReader2 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID2 & ".png")

        If InfoReader2.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID2 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded2 += 1
        End If

        ID2 += 1
        TotalIDs += 1

        Select Case ID2
            Case 1000
                ID2 = 2500

            Case 3000
                ID2 = 4500

            Case 5000
                ID2 = 6500

            Case 7000
                ID2 = 8500

            Case 9000
                ID2 = 10500

            Case 11000
                ID2 = 12500

            Case 13000
                ID2 = 14500

            Case 15000
                ID2 = 16500

            Case 17000
                ID2 = 18500

            Case 19000
                ID2 = 20500

        End Select

        lblImages2.Text = CStr(ImagesDownloaded2) & " (" & CStr(ID2) & ")"

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
        TotalIDs += 1

        Select Case ID3
            Case 1500
                ID3 = 3000

            Case 3500
                ID3 = 5000

            Case 5500
                ID3 = 7000

            Case 7500
                ID3 = 9000

            Case 9500
                ID3 = 11000

            Case 11500
                ID3 = 13000

            Case 13500
                ID3 = 15000

            Case 15500
                ID3 = 17000

            Case 17500
                ID3 = 19000

            Case 19500
                ID3 = 21000

        End Select

        lblImages3.Text = CStr(ImagesDownloaded3) & " (" & CStr(ID3) & ")"

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
        TotalIDs += 1

        Select Case ID4
            Case 2000
                ID4 = 3500

            Case 4000
                ID4 = 5500

            Case 6000
                ID4 = 7500

            Case 8000
                ID4 = 9500

            Case 10000
                ID4 = 11500

            Case 12000
                ID4 = 13500

            Case 14000
                ID4 = 15500

            Case 16000
                ID4 = 17500

            Case 18000
                ID4 = 19500

            Case 20000
                ID4 = 21500

        End Select

        lblImages4.Text = CStr(ImagesDownloaded4) & " (" & CStr(ID4) & ")"

        If CancelPending = False Then
            WC4.DownloadFileAsync(New Uri("http://services.runescape.com/m=itemdb_rs/3696_obj_sprite.gif?id=" & ID4), "RS Objects\Object_" & ID4 & ".png")
        End If

    End Sub
End Class
