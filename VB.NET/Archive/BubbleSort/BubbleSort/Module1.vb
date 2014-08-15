Module Module1

    Sub Main()
        Console.Write("How many numbers do you want to sort: ")
        Dim nums As Integer = CInt(Console.ReadLine)

        Dim input(nums - 1) As Integer

        For i As Integer = 0 To nums - 1
            input(i) = Console.ReadLine
        Next

        Dim result() As Integer = BubbleSort(input)

        For i As Integer = 0 To result.GetUpperBound(0)
            Console.Write(result(i) & " ")
        Next

        Console.ReadKey()


    End Sub

    '    BEGIN BubbleSort(array)
    '	FOR i = 0 to SIZEOF(array)
    '		FOR j = 0 to SIZEOF(array) - i
    '			IF array(j) > array(j+1) THEN
    '				temp = array(j)
    '				array(j) = array(j+1)
    '				array(j+1) = temp
    '			END IF
    '		END FOR
    '	END FOR
    '	RETURN array
    'END

    Private Function BubbleSort(ByVal arr() As Integer) As Integer()
        Dim temp As Integer

        For i As Integer = 0 To arr.GetUpperBound(0)
            For j As Integer = 0 To arr.GetUpperBound(0) - i - 1 ' -1 otherwise out of bounds exception occurs.
                If arr(j) > arr(j + 1) Then
                    temp = arr(j)
                    arr(j) = arr(j + 1)
                    arr(j + 1) = temp
                End If
            Next
        Next

        Return arr
    End Function

End Module



