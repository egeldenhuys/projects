Module Module1

    ' Create the timer
    Dim WithEvents tmrText As New System.Timers.Timer

    ' Variable for which colour should be used
    Dim firstColour As Boolean = False


    Sub Main()
        ' initialize the timer

        ' Set the interval to 1 second
        tmrText.Interval = 1000

        ' Enable the timer
        tmrText.Enabled = True

        Console.ReadLine()
    End Sub

    ' This sub will be executed when the timer elapses
    Sub tmrText_Tick() Handles tmrText.Elapsed
        ' Place the cursor at the start of the screen.
        Console.SetCursorPosition(0, 0)

        ' Determine the colour based on the bool variable
        If firstColour = True Then
            Console.ForegroundColor = ConsoleColor.Green

            ' Set it to false.
            firstColour = False
        Else
            Console.ForegroundColor = ConsoleColor.Red

            ' Set it to true.
            firstColour = True
        End If

        ' Write the text using the determined colour
        Console.WriteLine("This text is flashing!")

        ' Write some text in gray.
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine("This text is gray...")

    End Sub

End Module
