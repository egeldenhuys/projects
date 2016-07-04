Module Module1

    Dim exitCommanded As Boolean

    Sub Main()
        DisplayMenu()
        Dim floatTest As Single

        floatTest = 2.678357

        Console.WriteLine(floatTest)

        While exitCommanded = False
            HandleCommand(Console.ReadLine)
        End While

        EndOfProgram()
    End Sub

    Private Sub DisplayMenu()
        Console.WriteLine("Menu")
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
