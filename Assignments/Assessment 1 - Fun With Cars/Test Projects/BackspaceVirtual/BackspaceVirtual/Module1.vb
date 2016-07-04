Module Module1

    Dim exitCommanded As Boolean

    Sub Main()
        Console.WriteLine(NewVirtualString("BOB: Do not kill the cat", "BOB: "))

        While exitCommanded = False
            HandleCommand(Console.ReadLine)
        End While

        EndOfProgram()
    End Sub

    Private Sub DisplayMenu()
        Dim SolidWords(1) As String
        SolidWords(0) = "Baker: "
        SolidWords(1) = "John: "

        Dim safe As Boolean = True
        Console.WriteLine("DO NOT DELECT ME")

        Dim virtualString As String = "John: Please edit this string..."
        Console.ForegroundColor = ConsoleColor.Green

        Console.Write(virtualString)
        Console.ForegroundColor = ConsoleColor.Red

        Dim consoleKey As New ConsoleKeyInfo

        While consoleKey.Key <> System.ConsoleKey.Enter
            consoleKey = Console.ReadKey(True)
            If consoleKey.Key = System.ConsoleKey.Backspace Then

                For Each element In SolidWords
                    If virtualString = element Then
                        safe = False
                        Exit For
                    Else
                        safe = True
                    End If
                Next

                If safe = True Then
                    virtualString = virtualString.Remove(virtualString.Length - 1, 1)
                    MoveCursorBack()
                    Console.Write(" ")
                    MoveCursorBack()
                End If

            Else
                virtualString &= consoleKey.KeyChar
                Console.Write(consoleKey.KeyChar)
            End If
        End While

        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine(virtualString)
        Console.ResetColor()

    End Sub

    Private Sub MoveCursorBack()
        If Console.CursorLeft = 0 Then
            If Console.CursorTop > 0 Then
                Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1) ' 1 row up, start at the end
            End If
        Else
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop) ' 1 space back
        End If
    End Sub

    Private Function NewVirtualString(ByVal theString As String, ByVal solidWord As String) As String
        Dim safe As Boolean
        Dim cki As New ConsoleKeyInfo
        Console.Write(theString)

        While cki.Key <> ConsoleKey.Enter
            cki = Console.ReadKey(True)

            If cki.Key = ConsoleKey.Backspace Then
                ' Check if the last thing remaining is the instruction. e.g. "Brand: "
                'For Each element In solidWords
                If theString = solidWord Then
                    safe = False
                    'Exit For
                Else
                    safe = True
                End If
                'Next

                If safe Then
                    ' Remove the last character from the console and the virtual string
                    theString = theString.Remove(theString.Length - 1, 1)
                    MoveCursorBack()
                    Console.Write(" ")
                    MoveCursorBack()
                End If

            Else
                ' Add a character to the console and string
                theString &= cki.KeyChar
                Console.Write(cki.KeyChar)
            End If

        End While
        Console.WriteLine()
        theString = theString.Remove(0, solidWord.Length)


        Return theString
    End Function

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
