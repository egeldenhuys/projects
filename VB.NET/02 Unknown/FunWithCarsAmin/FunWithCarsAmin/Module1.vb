Module Module1


    'is it working?
    Dim TextColour As ConsoleColor = ConsoleColor.Red
    Dim BackColour As ConsoleColor = ConsoleColor.Black
    Public Class UserInfo

        Public userName As String
        Public password As String
    End Class
    Public users(9) As UserInfo
    Dim users_count As Integer = 0

    Public Class CAR
        Public brand As String
        Public make As String
        Public model As String
        Public year As Integer
        Public BaseCost As Integer
        Public MarkUp As Integer
    End Class
    Public cars(9) As CAR
    Dim cars_count As Integer = 0

    Sub AddCar()


        If cars_count < 10 Then

            Console.Clear()
            Console.WriteLine("                                       ")
            Console.WriteLine("      _________________________________")
            Console.WriteLine("      Entering new car information...  ")
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("                   ***                    ")
            Console.WriteLine()
            Console.WriteLine("-------------------")
            Console.Write("Enter brand of car: ")
            cars(cars_count).brand = Console.ReadLine()
            Console.Write("Enter car's make: ")
            cars(cars_count).make = Console.ReadLine()
            Console.Write("Enter model: ")
            cars(cars_count).model = Console.ReadLine()
            Console.Write("Year: ")
            cars(cars_count).year = CInt(Console.ReadLine())
            Console.Write("Base cost: ")
            cars(cars_count).BaseCost = CInt(Console.ReadLine())
            Console.Write("Dealer markup (in percentage): ")
            cars(cars_count).MarkUp = CInt(Console.ReadLine())
            Console.WriteLine()
            Console.WriteLine("Car added!")

        Else
            Console.WriteLine("database is currently full.")
        End If

        cars_count += 1

        Menu()



    End Sub
    Sub EditCar()

        Dim car_num(9) As String

        Console.Clear()
        Console.WriteLine("_____________________")
        Console.WriteLine("Select a car to edit: ")
        Console.WriteLine()

        For i = 0 To cars_count - 1
            Console.WriteLine(i & ": " & cars(i).brand & " " & cars(i).make)
        Next


        Dim car_selection As Integer
        Console.Write("selection: ")
        car_selection = CInt(Console.ReadLine)

        Console.Clear()

        Console.WriteLine("Editting car details:")
        Console.WriteLine("__________")
        Console.Write("New brand: ")
        cars(car_selection).brand = Console.ReadLine()
        Console.WriteLine("_________")
        Console.Write("New make: ")
        cars(car_selection).make = Console.ReadLine()
        Console.WriteLine("__________")
        Console.Write("New model: ")
        cars(car_selection).model = Console.ReadLine()
        Console.WriteLine("_________")
        Console.Write("New year: ")
        cars(car_selection).year = CInt(Console.ReadLine())
        Console.WriteLine("______________")
        Console.Write("New base cost: ")
        cars(car_selection).BaseCost = CInt(Console.ReadLine())
        Console.WriteLine("______________________")
        Console.Write("New markup for dealer: ")
        cars(car_selection).MarkUp = CInt(Console.ReadLine())
        Console.WriteLine()
        Console.WriteLine("Details successfully changed!")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("        ***         ")
        Console.WriteLine()
        Console.WriteLine()
        Console.Write("Press any key to return to menu...")
        Console.ReadLine()

        Menu()


    End Sub
    Sub CarDetails()


        Dim car_num(9) As String

        Console.Clear()
        Console.WriteLine("Select a car to view details: ")
        Console.WriteLine()

        For i = 0 To cars_count - 1
            Console.WriteLine(i & ": " & cars(i).brand & " " & cars(i).make)
        Next


        Dim car_selection As Integer
        Console.Write("selection: ")
        car_selection = CInt(Console.ReadLine)

        Console.Clear()

        Console.WriteLine("Viewing stats of car...")
        Console.WriteLine()
        Console.WriteLine("Brand: " & cars(car_selection).brand)
        Console.WriteLine("> Make: " & cars(car_selection).make)
        Console.WriteLine("> Model: " & cars(car_selection).model)
        Console.WriteLine("> Year: " & cars(car_selection).year)
        Console.WriteLine("> Base cost: " & cars(car_selection).BaseCost)
        Console.WriteLine("> Markup percentage: " & cars(car_selection).MarkUp & "%")
        Console.WriteLine()
        Console.WriteLine("> Full cost: " & cars(car_selection).BaseCost * cars(car_selection).MarkUp + cars(car_selection).BaseCost)
        Console.WriteLine("> Cost of increment: " & cars(car_selection).BaseCost * cars(car_selection).MarkUp)
        Console.WriteLine("> Age of car: " & 2013 - cars(car_selection).year)
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("       ***       ")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("Press Enter to return to menu...")
        Console.ReadLine()

        Menu()

    End Sub
    Sub CarStats()

        Console.Clear()

        Dim lowest As Integer
        Dim highest As Integer
        Dim highestIndex As Integer
        Dim lowestIndex As Integer


        lowest = cars(0).BaseCost
        highest = cars(0).BaseCost

        For i As Integer = 0 To cars_count - 1
            If cars(i).BaseCost > highest Then
                highestIndex = i
                highest = cars(i).BaseCost

            End If


            If cars(i).BaseCost < lowest Then
                lowestIndex = i
                lowest = cars(i).BaseCost

            End If

        Next
        Console.WriteLine("highest car base cost: " & cars(highestIndex).brand & "," & " " & "(" & cars(highestIndex).make & ")" & "," & "$" & cars(highestIndex).BaseCost)
        Console.WriteLine("Lowest car base cost: " & cars(lowestIndex).brand & "," & " " & "(" & cars(lowestIndex).make & ")" & "," & "$" & cars(lowestIndex).BaseCost)
        Console.WriteLine()
        Console.WriteLine("Highest car income: " & cars(highestIndex).brand & "," & " " & "(" & cars(highestIndex).make & ")" & "," & "$" & cars(highestIndex).BaseCost * cars(highestIndex).MarkUp)
        Console.WriteLine("Lowest car income: " & cars(lowestIndex).brand & "," & " " & "(" & cars(lowestIndex).make & ")" & "," & "$" & cars(lowestIndex).BaseCost * cars(lowestIndex).MarkUp)


        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("       ***        ")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("Press Enter to return to menu...")
        Console.ReadLine()

        Menu()
    End Sub
    Sub RemoveCar()

        Dim selection As String

        Console.Clear()

        Console.WriteLine("")

        ' ????
        For i As Integer = CInt(selection) To cars_count - 2
            cars(i) = cars(i + 1)
        Next


        cars_count -= 1


    End Sub

    Sub ColourOptions()

        Console.Clear()

        Dim selection As String


        Console.WriteLine(" ____________________________________")
        Console.WriteLine("|             COLOUR OPTIONS         |\")
        Console.WriteLine("|                                    ||")
        Console.WriteLine("|                                    ||")
        Console.WriteLine("| A. Change background colour        ||")
        Console.WriteLine("| B. Change text colour              ||")
        Console.WriteLine("|                                    ||")
        Console.WriteLine("|                                    ||")
        Console.WriteLine("|____________________________________||")
        Console.WriteLine(" \___________________________________\")
        Console.WriteLine()
        Console.Write("Selection: ")

        selection = Console.ReadLine.ToUpper


        If selection = "A" Then
            ChangeBack()

        ElseIf selection = "B" Then
            ChangeText()
        End If


    End Sub
    Sub ChangeBack()

        Console.WriteLine("Select from one of the following colours:")
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.DarkBlue
        Console.WriteLine("1. Dark Blue")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine("2. Dark Green")
        Console.ForegroundColor = ConsoleColor.DarkCyan
        Console.WriteLine("3. Dark Cyan")
        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine("4. Dark Red")
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("5. Dark Magenta")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("6. Dark Yellow")
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine("7. Gray")
        Console.ForegroundColor = ConsoleColor.DarkGray
        Console.WriteLine("8. Dark Yellow")
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine("9. Blue")
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("10. Green")
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("11. Cyan")
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("12. Red")
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WriteLine("13. Magenta")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("14. Yellow")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("15. White")

        Console.BackgroundColor = CType(Console.ReadLine, ConsoleColor)


        Menu()



    End Sub
    Sub ChangeText()

        Dim selection As String

        Console.WriteLine("Select from one of the following colours:")
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("A. Red")
        Console.ForegroundColor = ConsoleColor.DarkRed
        Console.WriteLine("B. Dark Red")
        Console.ForegroundColor = ConsoleColor.Blue
        Console.WriteLine("C. Blue")
        Console.ForegroundColor = ConsoleColor.DarkBlue
        Console.WriteLine("D. Dark Blue")
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("E. Green")
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.WriteLine("F. Dark Green")
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("G. Yellow")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.WriteLine("H. Dark Yellow")
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine("I. Cyan")
        Console.ForegroundColor = ConsoleColor.White
        Console.WriteLine("J. White")

        Console.WriteLine("Selection: ")

        Console.ForegroundColor = CType(Console.ReadLine, ConsoleColor)


    End Sub
    Sub Welcome()

        BackColour = ConsoleColor.Black
        Console.ForegroundColor = ConsoleColor.Red

        Console.WriteLine("  _______________________________________ ")
        Console.WriteLine(" /                                       \")
        Console.WriteLine(" \                                       /")
        Console.WriteLine(" /                                       \")
        Console.WriteLine(" \                                       /")
        Console.WriteLine(" /       WELCOME TO FUN WITH CARS!       \")
        Console.WriteLine(" \       ------------------------        /")
        Console.WriteLine(" /                                       \")
        Console.WriteLine(" \                                       /")
        Console.WriteLine(" /                                       \")
        Console.WriteLine(" \_______________________________________/")
        Console.WriteLine()
        Console.WriteLine("         Press Enter to continue...")



        Console.Read()


        Menu()

    End Sub
    Sub NewUser()

        For i As Integer = 0 To 9
            users(i) = New UserInfo

            If users_count < 10 Then

                Console.Clear()
                Console.Write("Enter new username: ")
                users(users_count).userName = Console.ReadLine

                Console.Write("Enter new password: ")
                users(users_count).password = Console.ReadLine

            Else
                Console.WriteLine("Too many users have already registered!")
            End If

            users_count += 1


            Menu()
        Next
    End Sub
    Sub Login()

        ' Console.WriteLine(" PLEASE ENTER LOGIN INFO:")
        ' Console.WriteLine()
        ' Console.Write("> Username: ")
        'users.userName = Console.ReadLine
        '  Console.Write("> Password: ")

        ' For i As Integer = 0 To users_count


        '  Next


    End Sub
    Sub quit()

        Console.Clear()

        Console.WriteLine("    __________________________________________ ")
        Console.WriteLine("   |                                          |")
        Console.WriteLine("   |    Thank you for using Fun with Cars!    |")
        Console.WriteLine("   |__________________________________________|")
        Console.ReadLine()


    End Sub
    Sub Menu()

        Console.Clear()


        Dim selection As Char

        Console.BackgroundColor = BackColour
        Console.ForegroundColor = TextColour

        Console.WriteLine("                 _____________ ")
        Console.WriteLine("                |             |")
        Console.WriteLine("                |FUN WITH CARS|")
        Console.WriteLine("                |_____________|")
        Console.WriteLine("   ____________________________________________ ")
        Console.WriteLine("  /                                            \")
        Console.WriteLine("  \  ~ Select from the following options: ~    /")
        Console.WriteLine("  /                                            \")
        Console.WriteLine("  \                                            /")
        Console.WriteLine("  /           (A) Add a car                    \")
        Console.WriteLine("  \           (B) Edit a car                   /")
        Console.WriteLine("  /           (C) View car details             \")
        Console.WriteLine("  \           (D) view car statistics          /")
        Console.WriteLine("  /           (E) Remove a car                 \")
        Console.WriteLine("  \           (F) Options                      /")
        Console.WriteLine("  /           (Q) Quit                         \")
        Console.WriteLine("  \____________________________________________/")
        Console.WriteLine()
        Console.WriteLine("Selection: ")

        selection = CChar(Console.ReadLine().ToUpper)

        If selection = "A" Then
            AddCar()
        ElseIf selection = "B" Then
            EditCar()
        ElseIf selection = "C" Then
            CarDetails()
        ElseIf selection = "D" Then
            CarStats()
        ElseIf selection = "E" Then
            RemoveCar()
        ElseIf selection = "F" Then
            ColourOptions()
        ElseIf selection = "Q" Then
            quit()
        End If

    End Sub
    Sub AccountSelect()

        Dim selection As String

        Console.WriteLine("Already registered? Please select A. If you need a new account, please select B!")
        Console.WriteLine("A. Login")
        Console.WriteLine("B. Create new account")

        selection = Console.ReadLine.ToUpper

        If selection = "A" Then
            Login()
        End If
        If selection = "B" Then
            NewUser()
        End If


    End Sub
    Sub SaveUser()

        FileOpen(1, "savedUsers.txt", OpenMode.Output)

        For i = 0 To users_count - 1


            PrintLine(1, users(i).userName)
            PrintLine(1, users(i).password)

        Next

        FileClose(1)

    End Sub
    Sub LoadUser()

        If IO.File.Exists("savedUsers.txt") Then

            FileOpen(1, "savedUsers.txt", OpenMode.Input)

            While Not EOF(1)

                users(users_count).userName = LineInput(1)
                users(users_count).password = LineInput(1)

                users_count += 1

            End While

            FileClose(1)

        End If

    End Sub
    Sub SaveCar()

        'loop through our array and save
        FileOpen(1, "cars.txt", OpenMode.Output)

        For i = 0 To cars_count - 1


            'write all the data to file
            PrintLine(1, cars(i).brand)
            PrintLine(1, cars(i).make)
            PrintLine(1, cars(i).model)
            PrintLine(1, cars(i).year)
            PrintLine(1, cars(i).BaseCost)
            PrintLine(1, cars(i).MarkUp)

        Next

        FileClose(1)

    End Sub
    Sub LoadCar()

        If IO.File.Exists("cars.txt") Then

            'Load all the students from the text file
            FileOpen(1, "cars.txt", OpenMode.Input)

            While Not EOF(1)

                'Load the 6 lines for the student
                cars(cars_count).brand = LineInput(1)
                cars(cars_count).make = LineInput(1)
                cars(cars_count).model = LineInput(1)
                cars(cars_count).year = CInt(LineInput(1))
                cars(cars_count).BaseCost = CInt(LineInput(1))
                cars(cars_count).MarkUp = CInt(LineInput(1))

                'Increment student_count
                cars_count += 1

            End While

            FileClose(1)

        End If
    End Sub
    Sub Main()

        ' Set the default colours
        Console.ForegroundColor = TextColour
        Console.BackgroundColor = BackColour

        ' Apply backgound colour to whole screen.
        Console.Clear()

        ' Infinite loop only for testing
        While True

            ' Display the main menu
            Menu()

        End While

        For i = 0 To 9
            cars(i) = New CAR
        Next

        LoadCar()


        Welcome()
        Console.Clear()
        AccountSelect()
        Menu()
        SaveCar()




    End Sub
End Module


