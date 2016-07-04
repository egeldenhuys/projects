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
        Console.WriteLine("Menu")
        Dim virtualString As String = "Baker: Please edit this string..."
        Console.Write(virtualString)

        Dim consoleKey As New ConsoleKeyInfo

        While ConsoleKey.Key <> System.ConsoleKey.Enter
            ConsoleKey = Console.ReadKey(True)
            If ConsoleKey.Key = System.ConsoleKey.Backspace Then
                virtualString = virtualString.Remove(virtualString.Length - 1, 1)
                ClearLine()
                Console.Write(virtualString)

            Else
                ClearLine()
                virtualString &= consoleKey.KeyChar
                Console.Write(virtualString)
            End If
        End While


    End Sub

    Private Sub ClearLine()

        Console.SetCursorPosition(0, Console.CursorTop)

        For i As Integer = 0 To Console.BufferWidth - 1
            Console.Write(" ")
        Next

        Console.SetCursorPosition(0, Console.CursorTop - 1)

    End Sub

    Private Sub HandleCommand(ByVal command As String)

        Select Case command.ToLower

            Case "q"
                exitCommanded = True

            Case Else

        End Select

    End Sub

    Private Sub EndOfProgram()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)
    End Sub
End Module
