Module Module1

    Sub Main()
        While True


            Console.Write("How many rolls do you want to do: ")
            Dim input As String = Console.ReadLine

            Dim a As Integer = 0
            Dim b As Integer = 0
            Dim sum As Integer = 0

            Dim rnd As New Random
            Dim numbers(10) As Integer

            For i As ULong = 0 To CULng(input)
                a = rnd.Next(1, 7)
                b = rnd.Next(1, 7)
                sum = a + b

                numbers(sum - 2) += 1

            Next

            For i As Integer = 0 To 10
                Console.WriteLine(i + 2 & ": " & numbers(i))
            Next

        End While

    End Sub

End Module
