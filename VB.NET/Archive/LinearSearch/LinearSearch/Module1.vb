Module Module1

    ' BEGIN LinearSearch(array, numToFind)
    '	FOR i = 0 to SIZEOF(array)
    '		IF array(i) = numToFind THEN
    '			RETURN i
    '		END IF
    '	END FOR
    '	RETURN -1
    ' END

    Sub Main()
        Dim numbers() As Integer = {6, 3, 9, 9, 2, 2, 1, 0, 9, 7, 4, 7, 8, 3}

        Console.WriteLine("Enter the number you wish to find: ")
        Dim input As Integer = CInt(Console.ReadLine)

        Dim result As Integer = LinearSearch(numbers, input)

        If result = -1 Then
            Console.WriteLine("Number not found in array")
        Else
            Console.WriteLine("The index of the number in the array is " & result)
        End If

        Console.ReadKey()


    End Sub

    Private Function LinearSearch(ByVal arr() As Integer, ByVal numToFind As Integer) As Integer

        For i As Integer = 0 To arr.GetUpperBound(0)
            If arr(i) = numToFind Then
                Return i
            End If
        Next

        Return -1
    End Function

End Module
