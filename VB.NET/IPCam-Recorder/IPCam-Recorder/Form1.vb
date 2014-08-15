Imports System.Net

Public Class Form1

    Dim WithEvents tmr As New Timer
    Dim i As Integer = 0
    Dim time As String = Now.ToString



    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tmr.Interval = 16
        tmr.Enabled = True
        time = time.Replace(" ", "_")
        time = time.Replace("/", "-")
        time = time.Replace(":", "-")


    End Sub

    Private Sub start()
        Dim wc1 As New WebClient
        Dim creds As New NetworkCredential

        creds.UserName = "admin"
        creds.Password = ""
        wc1.Credentials = creds


        Dim path As String = "C:\Cam\" & time & " (" & i & ").jpg"

            Try
            wc1.DownloadFile("http://192.168.1.80/snapshot.cgi?1384593307811", path)
            Catch ex As WebException
                MsgBox(ex.Message)

            End Try

        PictureBox1.ImageLocation = path
        i += 1


    End Sub

    Private Sub tmrTick() Handles tmr.Tick
        start()
    End Sub

End Class

