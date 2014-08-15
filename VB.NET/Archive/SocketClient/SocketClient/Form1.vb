Imports System.Net.Sockets
Imports System.Text
Public Class Form1
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        Dim serverStream As NetworkStream = clientSocket.GetStream()
        Dim outStream As Byte() = _
        System.Text.Encoding.ASCII.GetBytes("Message from Client$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()

        Dim inStream(10024) As Byte
        serverStream.Read(inStream, 0, CInt(clientSocket.ReceiveBufferSize))
        Dim returndata As String = _
        System.Text.Encoding.ASCII.GetString(inStream)
        msg("Data from Server : " + returndata)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load
        msg("Client Started")
        clientSocket.Connect("127.0.0.1", 8888)
        Label1.Text = "Client Socket Program - Server Connected ..."
    End Sub

    Sub msg(ByVal mesg As String)
        TextBox1.Text = TextBox1.Text + Environment.NewLine + " >> " + mesg
    End Sub
End Class
