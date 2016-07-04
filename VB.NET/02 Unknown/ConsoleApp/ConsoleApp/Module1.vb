Module Module1
    Dim Name As String = "Kangaroo"
    Dim Password As String = "cake"
    Sub Main()
        Console.Write("Welcome to The Land of Barabarians!" & vbNewLine)

        Console.Write("What is your name?" & vbNewLine)
        If Console.ReadLine = "Kangaroo" Then
            Console.Write("Welcome Kangaroo" & vbNewLine)
            Console.Write("What is you secret word?" & vbNewLine)
        End If
        If Console.ReadLine = Password Then
            Console.Write("Correct!" & vbNewLine)
        End If
        If Console.ReadLine = "New" Then
            Console.Write("Please Choose a name for your character" & vbNewLine)
        End If
    End Sub
End Module
