Module Module1

    Dim exitCommanded As Boolean

    Sub Main()
        DisplayMenu()

        While exitCommanded = False
            HandleCommand(Console.ReadLine)
        End While

        EndOfProgram()
    End Sub

    Private Sub DisplayMenu()
        Console.WriteLine("")
    End Sub

    Private Sub HandleCommand(ByVal command As String)

        Select Case command.ToLower

            Case "q"
                exitCommanded = True

        End Select

    End Sub

    Private Sub EndOfProgram()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)
    End Sub
End Module
