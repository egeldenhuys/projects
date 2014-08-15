Imports System.Net
Imports System.IO

Public Class Form1

    Dim clients() As WebClient
    Dim spamCount As Integer = 0
    Dim spamCounter As Integer = 0

    Dim free As Integer = 0

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Dim a As New WebClient
        'AddHandler a.DownloadDataCompleted, AddressOf DownloadComplete

    End Sub

    Private Sub DownloadComplete(sender As Object, e As System.Net.DownloadDataCompletedEventArgs)
        spamCount += 1
    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        spamCount = 0
        spamCounter = 0

        tmrDelay.Interval = CInt(txtDelay.Text)

        clients = CreateClients(CInt(txtReqs.Text), txtUA.Text, txtref.Text)

        tmrDelay.Enabled = True

        ' SpamUrl(txtUrl.Text)

    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click

        tmrDelay.Enabled = False
    End Sub

    Private Sub SpamUrl(ByVal url As String)

        'While active = True

        For i As Integer = 0 To clients.GetUpperBound(0)
            If clients(i).IsBusy = False Then
                clients(i).DownloadStringAsync(New Uri(url & "?" & Now.Ticks))
                spamCount += 1
            End If
        Next

        lblCount.Text = CStr(spamCount)
        'Me.Refresh()
        'Application.DoEvents()
        'System.Threading.Thread.Sleep(100)

        'End While

    End Sub

    Private Function CreateClients(amount As Integer, userAgent As String, referer As String) As WebClient()
        Dim result(amount - 1) As WebClient
        Dim prox As New WebProxy
        prox.Address = New Uri("http://" & txtProx.Text)

        For i As Integer = 0 To amount - 1
            result(i) = New WebClient
            result(i).Headers("Accept") = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
            result(i).Headers("Accept-Language") = "en-us,en;q=0.5"
            result(i).Headers("User-Agent") = userAgent
            result(i).Headers("Referer") = referer
            result(i).Proxy = prox
            AddHandler result(i).DownloadStringCompleted, AddressOf Spammed
        Next

        Return result
    End Function

    Private Sub tmrDelay_Tick(sender As System.Object, e As System.EventArgs) Handles tmrDelay.Tick

        If clients(spamCount).IsBusy = False Then
            clients(spamCount).DownloadStringAsync(New Uri(txtUrl.Text & "?" & Now.Ticks))
            spamCount += 1
        End If

        If spamCount = CInt(txtReqs.Text) Then
            tmrDelay.Enabled = False
        End If

    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click

        lblTest.Visible = True

        Dim prox As New WebProxy
        prox.Address = New Uri("http://" & txtProx.Text)
        Dim wc As New WebClient
        wc.Headers("Accept") = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
        wc.Headers("Accept-Language") = "en-us,en;q=0.5"
        wc.Headers("User-Agent") = txtUA.Text
        wc.Headers("Referer") = txtref.Text
        wc.Proxy = prox


        wc.DownloadStringAsync(New Uri(txtUrl.Text))
        AddHandler wc.DownloadStringCompleted, AddressOf DownloadStringCompletedEventArgs

    End Sub

    Private Sub DownloadStringCompletedEventArgs(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            rtxtContent.Text = e.Result

        Catch ex As Exception
            rtxtContent.Text = ex.Message

        End Try

        lblTest.Visible = False
    End Sub

    Private Sub Spammed(sender As Object, e As Net.DownloadStringCompletedEventArgs)
        spamCounter += 1
        lblCount.Text = CStr(spamCounter)
    End Sub

End Class
