Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class Form1

    Public Event Spammed()
    Private Spams As Integer

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddHandler Spammed, AddressOf MainThreadSpammed

    End Sub

    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click

        SendRequest()

    End Sub

    Private Sub SendRequest()
        Dim url As String = txtUrl.Text
        Dim ref As String = txtRef.Text
        Dim amount As Integer = CInt(txtReqs.Text)
        Dim userAgent As String = txtUa.Text

        Spams = 0

        Dim req As New StateObject()

        For i As Integer = 0 To amount - 1
            req = Nothing
            req = New StateObject
            req.url = url
            req.userAgent = userAgent
            req.ref = ref
            AddHandler req.RequestSent, AddressOf DidASpam

            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf SendRequest), req)
        Next


    End Sub

    Private Sub MainThreadSpammed()
        lblStatus.Text = "Requests sent: " & CStr(Spams)
    End Sub

    Private Sub RaiseEventThreadSafe()
        RaiseEvent Spammed()
    End Sub

    Private Sub DidASpam()
        Spams += 1

        Dim a As New Action(AddressOf RaiseEventThreadSafe)
        Me.Invoke(a)

    End Sub

    Public Sub SendRequest(stateObj As Object)
        Dim stObj As StateObject
        stObj = CType(stateObj, StateObject)

        ' Create the request
        Dim request As HttpWebRequest = CType(WebRequest.Create(stObj.url), HttpWebRequest)

        ' Set request headers
        request.UserAgent = stObj.userAgent
        request.Referer = stObj.ref
        request.AllowAutoRedirect = False

        ' Set proxy details
        Dim proxy As New WebProxy
        ' TOR PROXY
        'proxy.Address = New Uri("http://127.0.0.1:8118")

        request.Proxy = proxy


        ' Send the request and get the response
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        ' Get the stream associated with the response. 
        'Dim receiveStream As Stream = response.GetResponseStream()

        ' Pipes the stream to a higher level stream reader with the required encoding format.  
        'Dim readStream As New StreamReader(receiveStream, Encoding.UTF8)

        ' Read the stream (downloads data)
        'returnValue = readStream.ReadToEnd()
        response.Close()
        'readStream.Close()

        stObj.DoEvent()
    End Sub


End Class
Public Class StateObject
    Public url, ref, userAgent As String
    Public returnValue As String

    Public Event RequestSent()

    Public Sub DoEvent()
        RaiseEvent RequestSent()

    End Sub
End Class

