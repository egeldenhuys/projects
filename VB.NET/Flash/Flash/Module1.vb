Module Module1

    Dim aTimer As New Timers.Timer()
    Dim bool As Boolean = False
    Dim counter As Integer = 0

    Sub Main()
        aTimer.Interval = 100

        AddHandler aTimer.Elapsed, AddressOf TimerTick

        aTimer.Start()

        While True
            Console.SetCursorPosition(0, 10)
            PrintBox(ConsoleColor.Green, Console.ReadLine())

        End While

    End Sub

    Private Sub PrintBox(ByVal boxColour As ConsoleColor, ByVal text As String)
        Console.SetCursorPosition(0, 0)

        Console.ForegroundColor = boxColour

        Console.WriteLine("+---------+")
        Console.Write("| ")

        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write(text)

        Dim width As Integer = 9

        For i As Integer = 0 To width - text.Length - 2
            Console.Write(" ")
        Next

        Console.ForegroundColor = boxColour
        Console.WriteLine("|")
        Console.WriteLine("|         |")
        Console.WriteLine("+---------+")

        Console.SetCursorPosition(0, 10)
    End Sub

    Sub TimerTick()
        'Dim rnd As New Random

        'PrintBox(rnd.Next(0, 5))

        If bool = False Then
            PrintBox(ConsoleColor.DarkGreen, CStr(counter))
            bool = True
        Else
            PrintBox(ConsoleColor.Green, CStr(counter))
            bool = False
        End If

        counter += 1
    End Sub


End Module
