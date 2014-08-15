Imports System.IO

Module Module1

    Sub Main()
        Dim input As String = Console.ReadLine
        If input = "a" Then
            ' Specify a file to read from and to create. 
            Dim pathSource As String = "A"
            Dim pathNew As String = "Tmp.txt"
            Try
                Using fsSource As FileStream = New FileStream(pathSource, _
                    FileMode.Open, FileAccess.Read)
                    ' Read the source file into a byte array. 
                    Dim bytes() As Byte = New Byte(CInt((fsSource.Length) - 1)) {}
                    Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
                    Dim numBytesRead As Integer = 0

                    While (numBytesToRead > 0)
                        ' Read may return anything from 0 to numBytesToRead. 
                        Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
                            numBytesToRead)
                        ' Break when the end of the file is reached. 
                        If (n = 0) Then
                            Exit While
                        End If
                        numBytesRead = (numBytesRead + n)
                        numBytesToRead = (numBytesToRead - n)

                    End While
                    numBytesToRead = bytes.Length

                    ' Write the byte array to the other FileStream. 
                    Using fsNew As FileStream = New FileStream(pathNew, _
                        FileMode.Create, FileAccess.Write)
                        fsNew.Write(bytes, 0, numBytesToRead)
                    End Using

                    Console.WriteLine("Writing bytes to file...")
                    Dim writer As New StreamWriter("B")

                    For Each element In bytes
                        writer.WriteLine(element)
                    Next

                    writer.Close()
                    Console.WriteLine("Finished")
                End Using
            Catch ioEx As FileNotFoundException
                Console.WriteLine(ioEx.Message)
            End Try
        Else
            Dim reader As New StreamReader("B")

            Dim bytes(425176) As Byte

            For i As Integer = 0 To 425176
                bytes(i) = CByte(reader.ReadLine())
            Next

            reader.Close()

            ' Write the byte array to the other FileStream. 
            Using fsNew As FileStream = New FileStream("C", _
                FileMode.Create, FileAccess.Write)
                fsNew.Write(bytes, 0, 425176)
            End Using

        End If

        Console.ReadKey()
    End Sub
End Module
