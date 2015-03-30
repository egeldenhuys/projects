Module Module1

    Public Class Car
        Public Name As String

    End Class

    Dim exitCommanded As Boolean = False

    Sub Main()

        DisplayMenu()

        While exitCommanded = False
            HandleCommand(Console.ReadLine)

        End While

        EndOfProgram()
    End Sub

    Private Sub DisplayMenu()
        Console.WriteLine("This program will test the performance of 2 different types of arrays")
        Console.WriteLine()
        Console.WriteLine("Please choose the array you want to test:")
        Console.WriteLine("(A) Dim arr() as string")
        Console.WriteLine("(B) Dim arr as new ArrayList")
        Console.Write("Selection: ")
    End Sub

    Private Sub HandleCommand(ByVal command As String)

        Select Case command.ToLower

            Case "a"
                TestArray(1)
            Case "b"
                TestArray(2)
        End Select

    End Sub

    Private Sub TestArray(ByVal ArrayID As Integer)
        Dim loopsToDo As Integer
        Dim content As String

        Dim startTime As Long
        Dim endTime As Long
        Dim difference As Long

        Console.WriteLine("How many times do you want to resize the array and add a new element?")
        Console.Write("> ")
        loopsToDo = CInt(Console.ReadLine())

        Console.WriteLine("What do you want to put in the array each time?")
        Console.Write("> ")
        content = Console.ReadLine()


        If ArrayID = 1 Then
            Dim arr() As String
            ' Start Timing
            startTime = DateTime.UtcNow.Ticks

            ReDim arr(0)
            arr(0) = content

            For i As Integer = 1 To loopsToDo
                ReDim arr(i)
                arr(i) = content
            Next

            ' Stop timing
            endTime = DateTime.UtcNow.Ticks
            difference = endTime - startTime
            Console.WriteLine("Operation took {0:N0} nanoseconds", difference * 100)
            Console.WriteLine("Operation took {0:N0} ticks", difference)
            Console.WriteLine("Operation took {0:N0} milliseconds", (difference * 100) / 1000000)
            Console.WriteLine("Operation took {0:N2} seconds", ((difference * 100) / 1000000) / 1000)
            Dim tmpVar As String

            ' Start Timing
            startTime = DateTime.UtcNow.Ticks

            For i As Integer = 0 To arr.GetUpperBound(0)
                tmpVar = arr(i)
            Next

            ' Stop timing
            endTime = DateTime.UtcNow.Ticks
            difference = endTime - startTime
            Console.WriteLine("Extraction took {0:N0} nanoseconds", difference * 100)
            Console.WriteLine("Extraction took {0:N0} ticks", difference)
            Console.WriteLine("Extraction took {0:N0} milliseconds", (difference * 100) / 1000000)
            Console.WriteLine("Extraction took {0:N2} seconds", ((difference * 100) / 1000000) / 1000)
        Else
            Dim arr As New List(Of Car)


            ' Start Timing
            startTime = DateTime.UtcNow.Ticks

            For i As Integer = 0 To loopsToDo

            Next

            ' Stop timing
            endTime = DateTime.UtcNow.Ticks
            difference = endTime - startTime
            Console.WriteLine("Operation took {0:N0} nanoseconds", difference * 100)
            Console.WriteLine("Operation took {0:N0} ticks", difference)
            Console.WriteLine("Operation took {0:N0} milliseconds", (difference * 100) / 1000000)
            Console.WriteLine("Operation took {0:N2} seconds", ((difference * 100) / 1000000) / 1000)



            ' Start Timing
            Dim tmpVar As String

            startTime = DateTime.UtcNow.Ticks

            For i As Integer = 1 To arr.Count - 1
                carInfoExtractor = TryCast(arr.Item(i), Car)
                tmpVar = carInfoExtractor.Name

            Next

            carInfoExtractor = TryCast(arr.Item(0), Car)
            Console.WriteLine(carInfoExtractor.Name)


            ' Stop timing
            endTime = DateTime.UtcNow.Ticks
            difference = endTime - startTime
            Console.WriteLine("Extraction took {0:N0} nanoseconds", difference * 100)
            Console.WriteLine("Extraction took {0:N0} ticks", difference)
            Console.WriteLine("Extraction took {0:N0} milliseconds", (difference * 100) / 1000000)
            Console.WriteLine("Extraction took {0:N2} seconds", ((difference * 100) / 1000000) / 1000)
        End If

    End Sub

    Private Sub EndOfProgram()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)
    End Sub
End Module
