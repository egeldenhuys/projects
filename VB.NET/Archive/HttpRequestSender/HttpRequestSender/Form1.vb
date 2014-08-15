Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        txtConsole.Clear()
        txtHeaders.Clear()

        Cw("Starting")

        Dim url As String = txtUrl.Text
        Dim ref As String = txtRef.Text
        Dim amount As Integer = CInt(txtReqs.Text)
        Dim userAgent As String = txtUa.Text

        Cw("Creating request")
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)

        request.UserAgent = userAgent
        request.AllowAutoRedirect = False

        Cw("Getting Response")
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        Cw("------------------------------")
        Cw("Content length is " & response.ContentLength)
        Cw("Content type is " & response.ContentType)
        Cw("Response code: " & response.StatusCode)
        Cw("Response Description: " & response.StatusDescription)
        Cw("------------------------------")

        Hw("===== Request Headers =====")

        Dim reqHeaders() As String = request.Headers.AllKeys

        For i As Integer = 0 To reqHeaders.GetUpperBound(0)
            Hw(reqHeaders(i) & ": " & request.Headers.Get(reqHeaders(i)))
        Next

        Hw("===== Response Headers =====")

        Dim headers() As String = response.Headers.AllKeys

        For i As Integer = 0 To headers.GetUpperBound(0)
            Hw(headers(i) & ": " & response.Headers.Get(headers(i)))
        Next

        '' Get the stream associated with the response. 
        'Cw("Getting stream")
        'Dim receiveStream As Stream = response.GetResponseStream()

        '' Pipes the stream to a higher level stream reader with the required encoding format.  
        'Cw("Creating stream reader")
        'Dim readStream As New StreamReader(receiveStream, Encoding.UTF8)

        'Cw("Reading stream to end")
        'txtOut.Text = readStream.ReadToEnd()
        response.Close()
        'readStream.Close()

        Cw("Finished")
    End Sub

    Private Sub Cw(text As String)
        txtConsole.AppendText(text & Environment.NewLine)

    End Sub

    Private Sub Hw(text As String)
        txtHeaders.AppendText(text & vbNewLine)

    End Sub
End Class
