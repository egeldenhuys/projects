Module Module1

    Sub Main()
        DisplayMenu()

        EndOfProgram()
    End Sub

    Private Sub DisplayMenu()
        Console.WriteLine("____MENU____")
    End Sub

    Private Sub HandleCommand(ByVal command As String)

        Select Case command

        End Select

    End Sub

    Private Sub EndOfProgram()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)
    End Sub
End Module
