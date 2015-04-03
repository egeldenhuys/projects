Module Module1

    Sub Main()
        Dim nums(2) As Double
        Dim result(2) As Double

        While True
            For i As Integer = 1 To 3
                Console.Write("Number " & i & ": ")
                nums(i - 1) = CInt(Console.ReadLine)
            Next

            
            result = NumberSeries(nums, 3)

            If result(0) = 0 Then
                Console.WriteLine("Numbers are not in series")
            Else
                Console.WriteLine("Number 4: " & result(0))
                Console.WriteLine("Number 5: " & result(1))
                Console.WriteLine("Number 6: " & result(2))
            End If

            

            Console.ReadKey()
            Console.Clear()
        End While

    End Sub

    Private Function NumberSeries(ByVal nums() As Double, ByVal returnAmount As Integer) As Double()
        Dim b(1) As Double
        Dim result(returnAmount - 1) As Double

        b(0) = nums(1) - nums(0)
        b(1) = nums(2) - nums(1)

        Dim m As Double

        m = b(1) / b(0)


        If b(0) = 0 Or b(1) = 0 Then ' Not in series
            result(0) = 0
            Return result
            Exit Function
        End If

        If b(0) = 1 Then
            If b(1) > 1 Then
                If b(1) = m Then ' Not in series
                    result(0) = 0
                    Return result
                    Exit Function
                End If
            End If
        End If

        If -b(0) = b(1) Then ' Not in series
            result(0) = 0
            Return result
            Exit Function
        End If

        If b(0) > b(1) Then ' Not in series
            result(0) = 0
            Return result
            Exit Function
        End If

        ' Debug
        'Console.WriteLine("m = " & m)
        'Console.WriteLine("b(0) = " & b(0))
        'Console.WriteLine("b(1) = " & b(1))

        If ((nums(0) ^ 2) = nums(1)) And ((nums(1) ^ 2) = nums(2)) Then
            ' Squares
            'Console.WriteLine("Squares")
            For i As Integer = 0 To returnAmount - 1
                result(i) = nums(0) ^ (2 * (2 ^ (i + 2)))
            Next
        ElseIf (Not (m = 1)) Then
            ' Multiplication and division
            'Console.WriteLine("Multiplication and division")

            If m * nums(0) <> nums(1) Then ' Not in series
                result(0) = 0
                Return result
                Exit Function
            End If

            For i As Integer = 0 To returnAmount - 1
                result(i) = nums(0) * (m ^ (i + 3))
            Next
        ElseIf m = 1 Then
            ' Addition and Subtraction
            'Console.WriteLine("+ and -")
            For i As Integer = 0 To returnAmount - 1
                result(i) = nums(0) + (b(0) * (i + 3))
            Next
        End If

        Return result

    End Function

End Module
