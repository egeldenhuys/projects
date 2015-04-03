Module Module1

    Sub Main()
        Console.WriteLine("Enter Integer: ")
        Console.WriteLine(DecToBin(Console.ReadLine))

        Console.ReadKey()

    End Sub

    Private Function DecToBin(ByVal decNum As Integer) As String
        Dim binValue As Integer = 1
        Dim binString As String = ""

        ' Get the binary value counter
        While binValue <= decNum
            binValue = binValue * 2
        End While

        ' Create binary string
        While decNum <> 0

            If binValue < decNum Then

                decNum = decNum - binValue
                binValue = binValue / 2

            Else

            End If

        End While


    End Function

End Module
