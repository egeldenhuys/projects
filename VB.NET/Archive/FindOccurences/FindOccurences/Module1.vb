Module Module1

    Sub Main()
        Console.WriteLine("Enter string to search in: ")
        Dim inputString As String = Console.ReadLine
        Console.WriteLine("Enter a string to find inside the above string: ")
        Dim inputFind As String = Console.ReadLine

        Console.WriteLine("The given string was found " & FindOccurences(inputString, inputFind) & " times.")

        Console.ReadKey()

    End Sub

    '    BEGIN FindOccurances(data, find)
    '	count = 0
    '	FOR i = 0 to LENGTH(data) - LENGTH(find) + 1)
    '		IF SUBSTRING(data, i LENGTH(find)) = find THEN
    '			count = count + 1
    '		END IF
    '	END FOR
    '	RETURN count
    'END

    Private Function FindOccurences(ByVal data As String, ByVal find As String) As Integer

        Dim count As Integer = 0

        For i As Integer = 0 To data.Length - find.Length ' Do not add "+ 1", causes out of reange exception.
            If data.Substring(i, find.Length) = find Then
                count += 1
            End If
        Next

        Return count
    End Function
End Module
