Imports System.Net
Imports System.ComponentModel

Public Class Form1

    Dim WithEvents WC1 As New WebClient
    Dim WithEvents WC2 As New WebClient
    Dim WithEvents WC3 As New WebClient
    Dim WithEvents WC4 As New WebClient
    Dim WithEvents WC5 As New WebClient
    Dim WithEvents WC6 As New WebClient
    Dim WithEvents WC7 As New WebClient
    Dim WithEvents WC8 As New WebClient
    Dim WithEvents WC9 As New WebClient
    Dim WithEvents WC10 As New WebClient

    Dim InfoReader1 As System.IO.FileInfo
    Dim InfoReader2 As System.IO.FileInfo
    Dim InfoReader3 As System.IO.FileInfo
    Dim InfoReader4 As System.IO.FileInfo
    Dim InfoReader5 As System.IO.FileInfo
    Dim InfoReader6 As System.IO.FileInfo
    Dim InfoReader7 As System.IO.FileInfo
    Dim InfoReader8 As System.IO.FileInfo
    Dim InfoReader9 As System.IO.FileInfo
    Dim InfoReader10 As System.IO.FileInfo

    Dim ID1 As Integer = 0
    Dim ID2 As Integer = 0
    Dim ID3 As Integer = 0
    Dim ID4 As Integer = 0
    Dim ID5 As Integer = 0
    Dim ID6 As Integer = 0
    Dim ID7 As Integer = 0
    Dim ID8 As Integer = 0
    Dim ID9 As Integer = 0
    Dim ID10 As Integer = 0

    Dim ImagesDownloaded1 As Integer = 0
    Dim ImagesDownloaded2 As Integer = 0
    Dim ImagesDownloaded3 As Integer = 0
    Dim ImagesDownloaded4 As Integer = 0
    Dim ImagesDownloaded5 As Integer = 0
    Dim ImagesDownloaded6 As Integer = 0
    Dim ImagesDownloaded7 As Integer = 0
    Dim ImagesDownloaded8 As Integer = 0
    Dim ImagesDownloaded9 As Integer = 0
    Dim ImagesDownloaded10 As Integer = 0

    Dim TotalIDs As Integer = 0
    Dim CancelPending As Boolean = False
    Dim Start As Integer
    Dim URL As String = "http://services.runescape.com/m=itemdb_rs/3696_obj_big.gif?id="
    Dim ClientsDone As Integer

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        My.Computer.FileSystem.CreateDirectory("RS Objects\")


    End Sub

    Private Sub btnDownload_Click(sender As System.Object, e As System.EventArgs) Handles btnDownload.Click
        CancelPending = False

        WC1.DownloadFileAsync(New Uri(URL & ID1), "RS Objects\Object_" & ID1 & ".png")
        WC2.DownloadFileAsync(New Uri(URL & ID2), "RS Objects\Object_" & ID2 & ".png")
        WC3.DownloadFileAsync(New Uri(URL & ID3), "RS Objects\Object_" & ID3 & ".png")
        WC4.DownloadFileAsync(New Uri(URL & ID4), "RS Objects\Object_" & ID4 & ".png")
        WC5.DownloadFileAsync(New Uri(URL & ID5), "RS Objects\Object_" & ID5 & ".png")
        WC6.DownloadFileAsync(New Uri(URL & ID6), "RS Objects\Object_" & ID6 & ".png")
        WC7.DownloadFileAsync(New Uri(URL & ID7), "RS Objects\Object_" & ID7 & ".png")
        WC8.DownloadFileAsync(New Uri(URL & ID8), "RS Objects\Object_" & ID8 & ".png")
        WC9.DownloadFileAsync(New Uri(URL & ID9), "RS Objects\Object_" & ID9 & ".png")
        WC10.DownloadFileAsync(New Uri(URL & ID10), "RS Objects\Object_" & ID10 & ".png")

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

        lblImages1.Text = CStr(ImagesDownloaded1) & " (" & CStr(ID1) & ")"
        lblTotal.Text = CStr(ImagesDownloaded1 + ImagesDownloaded2 + ImagesDownloaded3 + ImagesDownloaded4 + ImagesDownloaded5 + ImagesDownloaded6 + ImagesDownloaded7 + ImagesDownloaded8) & " (" & TotalIDs & ")"

        If ID1 = Start + 100 Then
            lblImages1.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If

        Else
            If CancelPending = False Then
                WC1.DownloadFileAsync(New Uri(URL & ID1), "RS Objects\Object_" & ID1 & ".png")
            End If
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

        lblImages2.Text = CStr(ImagesDownloaded2) & " (" & CStr(ID2) & ")"

        If ID2 = Start + 200 Then
            lblImages2.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If
        Else
            If CancelPending = False Then
                WC2.DownloadFileAsync(New Uri(URL & ID2), "RS Objects\Object_" & ID2 & ".png")
            End If
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

        lblImages3.Text = CStr(ImagesDownloaded3) & " (" & CStr(ID3) & ")"

        If ID3 = Start + 300 Then
            lblImages3.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If
        Else
            If CancelPending = False Then
                WC3.DownloadFileAsync(New Uri(URL & ID3), "RS Objects\Object_" & ID3 & ".png")
            End If
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

        lblImages4.Text = CStr(ImagesDownloaded4) & " (" & CStr(ID4) & ")"

        If ID4 = Start + 400 Then
            lblImages4.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If
        Else
            If CancelPending = False Then
                WC4.DownloadFileAsync(New Uri(URL & ID4), "RS Objects\Object_" & ID4 & ".png")
            End If
        End If

    End Sub

    Private Sub WC5_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC5.DownloadFileCompleted
        InfoReader5 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID5 & ".png")

        If InfoReader5.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID5 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded5 += 1
        End If

        ID5 += 1
        TotalIDs += 1

        lblImages5.Text = CStr(ImagesDownloaded5) & " (" & CStr(ID5) & ")"


        If ID5 = Start + 500 Then
            lblImages5.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If
        Else
            If CancelPending = False Then
                WC5.DownloadFileAsync(New Uri(URL & ID5), "RS Objects\Object_" & ID5 & ".png")
            End If
        End If

    End Sub

    Private Sub WC6_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC6.DownloadFileCompleted
        InfoReader6 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID6 & ".png")

        If InfoReader6.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID6 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded6 += 1
        End If

        ID6 += 1
        TotalIDs += 1

        lblImages6.Text = CStr(ImagesDownloaded6) & " (" & CStr(ID6) & ")"


        If ID6 = Start + 600 Then
            lblImages6.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If
        Else
            If CancelPending = False Then
                WC6.DownloadFileAsync(New Uri(URL & ID6), "RS Objects\Object_" & ID6 & ".png")
            End If
        End If

    End Sub

    Private Sub WC7_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC7.DownloadFileCompleted
        InfoReader7 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID7 & ".png")

        If InfoReader7.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID7 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded7 += 1
        End If

        ID7 += 1
        TotalIDs += 1

        lblImages7.Text = CStr(ImagesDownloaded7) & " (" & CStr(ID7) & ")"


        If ID7 = Start + 700 Then
            lblImages7.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If
        Else
            If CancelPending = False Then
                WC7.DownloadFileAsync(New Uri(URL & ID7), "RS Objects\Object_" & ID7 & ".png")
            End If
        End If

    End Sub

    Private Sub WC8_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC8.DownloadFileCompleted
        InfoReader8 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID8 & ".png")

        If InfoReader8.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID8 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded8 += 1
        End If

        ID8 += 1
        TotalIDs += 1

        lblImages8.Text = CStr(ImagesDownloaded8) & " (" & CStr(ID8) & ")"

        If ID8 = Start + 800 Then
            lblImages8.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If
        Else
            If CancelPending = False Then
                WC8.DownloadFileAsync(New Uri(URL & ID8), "RS Objects\Object_" & ID8 & ".png")
            End If
        End If

    End Sub

    Private Sub WC9_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC9.DownloadFileCompleted
        InfoReader9 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID9 & ".png")

        If InfoReader9.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID9 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded9 += 1
        End If

        ID9 += 1
        TotalIDs += 1

        lblImages9.Text = CStr(ImagesDownloaded9) & " (" & CStr(ID9) & ")"

        If ID9 = Start + 900 Then
            lblImages9.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If

        Else
            If CancelPending = False Then
                WC9.DownloadFileAsync(New Uri(URL & ID9), "RS Objects\Object_" & ID9 & ".png")
            End If
        End If


    End Sub

    Private Sub WC10_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC10.DownloadFileCompleted
        InfoReader10 = My.Computer.FileSystem.GetFileInfo(My.Computer.FileSystem.CurrentDirectory & "\RS Objects\Object_" & ID10 & ".png")

        If InfoReader10.Length = 0 Then
            My.Computer.FileSystem.DeleteFile("RS Objects\Object_" & ID10 & ".png", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Else
            ImagesDownloaded10 += 1
        End If

        ID10 += 1
        TotalIDs += 1

        lblImages10.Text = CStr(ImagesDownloaded10) & " (" & CStr(ID10) & ")"

        If ID10 = Start + 1000 Then
            lblImages10.ForeColor = Color.Green
            ClientsDone += 1

            If ClientsDone = 10 Then
                Me.Close()
            End If

        Else
            If CancelPending = False Then
                WC10.DownloadFileAsync(New Uri(URL & ID10), "RS Objects\Object_" & ID10 & ".png")
            End If
        End If


    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Start = CInt(TextBox1.Text)

        ID1 = Start
        ID2 = Start + 100
        ID3 = Start + 200
        ID4 = Start + 300
        ID5 = Start + 400
        ID6 = Start + 500
        ID7 = Start + 600
        ID8 = Start + 700
        ID9 = Start + 800
        ID10 = Start + 900

    End Sub
End Class
