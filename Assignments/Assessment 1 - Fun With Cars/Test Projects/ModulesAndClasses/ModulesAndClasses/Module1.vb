Module Module1

    Dim exitCommanded As Boolean


    Sub Main()
        Console.WriteLine(MathsModule.TestClass.getString())

        
        'Dim C1 As New Class1

        'Console.WriteLine(C1.)


        While exitCommanded = False
            HandleCommand(Console.ReadLine)
        End While
        EndOfProgram()
    End Sub

    Private Sub DisplayMenu()


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
