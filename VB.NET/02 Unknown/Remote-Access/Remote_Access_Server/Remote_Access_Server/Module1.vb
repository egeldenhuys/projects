Imports System.Net.Sockets
Imports System.Net
Imports System.Text

Module Module1

    Sub Main()
        ' This constructor arbitrarily assigns the local port number. 
        Dim udpClient As New UdpClient(11000)

        ' 192.168.1.162:53989
        Try
            Dim sendBytes() As Byte = Encoding.ASCII.GetBytes("Nobody is here, go home.")

            ' IPEndPoint object will allow us to read datagrams sent from any source. 
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)

            ' UdpClient.Receive blocks until a message is received from a remote host. 
            Dim receiveBytes() As Byte
            Dim returnData As String

            While True

                ' Get output
                receiveBytes = udpClient.Receive(RemoteIpEndPoint)
                returnData = Encoding.ASCII.GetString(receiveBytes)

                ' Adress
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine(RemoteIpEndPoint.Address.ToString() & ":" & RemoteIpEndPoint.Port)
                Console.ForegroundColor = ConsoleColor.Gray

                ' Remove command from output
                For i As Integer = 0 To returnData.Length - 1
                    If returnData(i) = ChrW(10) Then
                        returnData = returnData.Remove(0, i + 1)
                        Exit For
                    End If
                Next

                Dim b As String = "Stuffs"

                ' Write output
                Console.Write(returnData)

                ' Send command
                sendBytes = Encoding.ASCII.GetBytes(Console.ReadLine)
                udpClient.Send(sendBytes, sendBytes.Length, RemoteIpEndPoint.Address.ToString(), RemoteIpEndPoint.Port)
                'udpClient.Send(sendBytes, sendBytes.Length, "192.168.1.162", 53989)
                

            End While


            udpClient.Close()

        Catch e As Exception
            Console.WriteLine(e.ToString())
        End Try

        Console.ReadKey()

    End Sub

    Sub A(ar As IAsyncResult)

    End Sub

End Module
