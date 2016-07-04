Module Module1

    Sub Main()
        Console.WriteLine("Please enter the characters")
        Dim sixChars As String = Console.ReadLine
        Console.WriteLine("---------")
        Console.WriteLine(GetCombos(sixChars))
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)

    End Sub

    Private Function GetCombos(ByVal characters As String) As String
        Dim result As String = ""

        Dim combos(characters.Length - 1) As Integer

        Return result
    End Function

End Module
