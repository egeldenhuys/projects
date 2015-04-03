Module Module1

    Sub Main()

        While True

            Console.WriteLine("Please enter a sentence: ")
            Dim input As String = Console.ReadLine

            Dim result(1) As Integer

            result = GetVowelsConsonants(input)

            Console.WriteLine("Vowels: " & result(0))
            Console.WriteLine("Consonants: " & result(1))

            Console.ReadLine()
            Console.Clear()

        End While

    End Sub

    Private Function GetVowelsConsonants(ByVal input As String) As Integer()

        Dim vowels() As String = {"a", "e", "i", "o", "u"}
        Dim consonants() As String = {"b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "x", "z", "w", "y"}

        input = input.ToLower

        Dim vowelsCount As Integer = 0
        Dim consoCount As Integer = 0

        For i As Integer = 0 To input.Length() - 1

            If vowels.Contains(input(i)) Then
                vowelsCount += 1
            ElseIf consonants.Contains(input(i)) Then
                consoCount += 1
            End If

        Next

        Dim result(1) As Integer

        result(0) = vowelsCount
        result(1) = consoCount

        Return result

    End Function
End Module
