Imports System.Net

Public Class Form1
    Dim cam1 As IPCamera
    Dim lastName As String = ""


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim time As String = Now.ToString
        time = time.Replace(" ", "_")
        time = time.Replace("/", "-")
        time = time.Replace(":", "-")
        txtName.Text = time

    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click

        FolderBrowserDialog1.ShowDialog()

        Dim path As String = FolderBrowserDialog1.SelectedPath
        txtPath.Text = path

    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click

        If IsNothing(cam1) = False Then
            cam1.StopCapture()
        End If

        If lastName = txtName.Text Then
            cam1 = New IPCamera(txtName.Text, txtIP.Text, txtPath.Text, CInt(txtInterval.Text), cam1.GetCaptureCount, PictureBox1)
        Else
            cam1 = New IPCamera(txtName.Text, txtIP.Text, txtPath.Text, CInt(txtInterval.Text), 0, PictureBox1)
        End If


        cam1.StartCapture()
        lblStatus.Text = "Recording"
        lastName = txtName.Text

    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click
        cam1.StopCapture()

        lblStatus.Text = "Stopped"

    End Sub


End Class

Public Class IPCamera
    Private captureCount As Integer
    Private WithEvents captureTimer As New Timer

    Private _picBox As PictureBox

    Private _name As String
    Private _savePath As String
    Private _Ip As String
    Private _interval As Integer

    Public Sub CaptureImage(path As String)
        Dim wc As New WebClient

        Dim creds As New NetworkCredential
        creds.UserName = "admin"
        creds.Password = ""

        wc.Credentials = creds

            wc.DownloadFile("http://" & _Ip & "/snapshot.cgi?" & Now.Ticks, path)

            Try
                _picBox.ImageLocation = path
            Catch ex As Exception

            End Try

    End Sub

    Public Function GetLastPath() As String
        Return (_savePath & "\" & _name & " (" & captureCount & ").jpg")

    End Function

    Public Function GetCaptureCount() As Integer

        Return captureCount

    End Function

    Public Sub New(name As String, Ip As String, savePath As String, interval As Integer, startNum As Integer, Optional ByRef picBox As PictureBox = Nothing)
        _name = name
        _Ip = Ip
        _interval = interval
        _savePath = savePath
        _picBox = picBox
        captureCount = startNum

        My.Computer.FileSystem.CreateDirectory(_savePath)

        captureTimer.Interval = _interval

    End Sub

    Public Sub StartCapture()
        captureTimer.Enabled = True

    End Sub

    Public Sub StopCapture()
        captureTimer.Enabled = False

    End Sub

    Private Sub TimerElapsed() Handles captureTimer.Tick

        CaptureImage(_savePath & "\" & _name & " (" & captureCount & ").jpg")
        captureCount += 1

    End Sub

End Class
