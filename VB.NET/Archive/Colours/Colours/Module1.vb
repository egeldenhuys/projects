Module Module1

    Sub Main()
        ' Set the default colours
        Console.ForegroundColor = ConsoleColor.Red
        Console.BackgroundColor = ConsoleColor.Black

        ' Apply backgound colour to whole screen.
        Console.Clear()

        ' Infinite loop only for testing
        While True

            ' Display the main menu
            Menu()

        End While

    End Sub

    Sub Menu()
        Console.Clear()

        ' Print the menu
        Console.WriteLine("Hur dur... Dis a menu")
        Console.WriteLine("Press ENTER to change colours")

        ' Wait for ENTER key 
        Console.ReadLine()

        ' Call the screen to handle changing colours
        ScreenChangeColours()
    End Sub

    Sub ScreenChangeColours()

        Console.Clear()

        ' print instruction message.
        Console.WriteLine("Choose new foreground colour. Enter the number.")

        ' Print the numbers with their corresponding colour. Can be more creative than this.
        PrintColours()

        ' Apply the choosen colour.
        Console.ForegroundColor = CType(Console.ReadLine, ConsoleColor)


        ' Clear the console before displaying new instructions
        Console.Clear()


        ' print another instruction message
        Console.WriteLine("Choose new Background colour. Enter the number.")

        ' Print the numbers with their corresponding colour. Can be more creative than this.
        PrintColours()
        
        ' Apply the choosen colour.
        Console.BackgroundColor = CType(Console.ReadLine, ConsoleColor)


    End Sub

    Sub PrintColours()

        ' There are 16 colours
        For i As Integer = 0 To 15

            ' Set the colour
            Console.ForegroundColor = CType(i, ConsoleColor)

            ' Write the number using the above colour
            Console.WriteLine(i)
        Next

    End Sub

End Module
