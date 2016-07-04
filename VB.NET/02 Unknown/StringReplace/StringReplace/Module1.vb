Module Module1

    Sub Main()
        Console.WriteLine("Enter a string: ")
        Dim inputString As String = Console.ReadLine

        Console.WriteLine("Enter a string to find in the above string: ")
        Dim inputFind As String = Console.ReadLine

        Console.WriteLine("Enter a string to replace the found word with: ")
        Dim inputReplace As String = Console.ReadLine

        Console.WriteLine("The new string: ")
        Console.WriteLine(StringReplace(inputString, inputFind, inputReplace))

        Console.ReadKey()

    End Sub

    '    BEGIN StringReplace(data, find, replace)
    '	FOR i = 0 to LENGTH(data) - LENGTH(find) + 1)
    '		IF SUBSTRING(data, i, LENGTH(find)) = find THEN
    '			REMOVE(data, i, LENGTH(find))
    '			INSERT(data, i, replace)
    '			i = i + LENGTH(replace)
    '		END IF
    '	END FOR
    '	RETURN data
    'END

    Private Function StringReplace(ByVal data As String, ByVal find As String, ByVal replace As String) As String

        For i As Integer = 0 To data.Length - find.Length
            If data.Substring(i, find.Length) = find Then
                ' .Remove returns a value, therefore we have to assign it to a variable.
                data = data.Remove(i, find.Length)
                data = data.Insert(i, replace)
                i += replace.Length
            End If
        Next

        Return data
    End Function

End Module
