Imports System.Net
Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        txtConsole.Clear()
        txtResponse.Clear()
        Me.Refresh()

        ' Specify the Url to recive the request
        Append(txtConsole, "Creating Request...")
        Dim request As HttpWebRequest = CType(WebRequest.Create(txtUrl.Text), HttpWebRequest)

        ' Set some reasonable limits on resources used by this request
        request.MaximumAutomaticRedirections = 8
        request.MaximumResponseHeadersLength = 8
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:17.0) Gecko/20100101 Firefox/17.0"


        Dim proxyObject As New WebProxy
        proxyObject.Address = New Uri("http://" & txtIP.Text & ":" & txtPort.Text)
        request.Proxy = proxyObject

        Append(txtConsole, "Creating Response...")
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        Append(txtConsole, "Status: " & response.StatusDescription)
        Append(txtConsole, "Content type: " & CStr(response.ContentType))

        Append(txtConsole, "Reading Response...")
        ' Get the stream associated with the response. 
        Dim receiveStream As Stream = response.GetResponseStream()

        ' Pipes the stream to a higher level stream reader with the required encoding format.  
        Dim readStream As New StreamReader(receiveStream, Encoding.UTF8)

        Append(txtResponse, readStream.ReadToEnd)
        response.Close()
        readStream.Close()

        Append(txtConsole, "Done.")
    End Sub

    Private Sub Append(ByVal textBox As TextBox, ByVal text As String)
        textBox.AppendText(text & vbNewLine)
    End Sub

End Class
