Module Module1

    Sub Main()
        While True
            Console.WriteLine("How many fibonacci numbers do you want to generate?")

            Dim input As Integer = CInt(Console.ReadLine)
            Console.WriteLine("Generating numbers....")

            Dim result(0) As ULong

            If result(0) = 0 Then
                Console.WriteLine("That many will result in an overflow")
            Else
                result = Fibonacci(input)
            End If

            For Each element In result
                Console.WriteLine(element)
            Next

            Console.ReadKey()
            Console.Clear()
        End While

    End Sub

    Private Function Fibonacci(ByVal amount As Integer) As ULong()
        Dim result(0) As ULong

        If amount = 94 Then ' After 93 numbers overflow occurs.
            result(0) = 0

        Else
            ReDim result(amount - 1)

            For i As Integer = 0 To amount - 1

                If (i < 2) Then
                    result(i) = 1
                Else
                    result(i) = result(i - 1) + result(i - 2)
                End If

            Next
        End If

        Return result

    End Function
End Module
