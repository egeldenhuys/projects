Module Module1


    ' Create the timer
    Dim WithEvents tmrText As New System.Timers.Timer

    ' Variable for which colour should be used
    Dim firstColour As Boolean = False

    Public Class CAR
        Public brand As String
        Public make As String
        Public model As String
        Public year As Integer
        Public basecost As Integer
        Public markup As Integer
    End Class

    Dim cars(9) As CAR

    Dim car_count As Integer = 0

    Sub AddCar()

        If car_count < 10 Then

            Console.Clear()

            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("___________________________         ")
            Console.WriteLine("___    |_____  /_____  /__(_)_____________ _   ______ _   ____________ ________")
            Console.WriteLine("__  /| |  __  /_  __  /__  /__  __ \_  __ `/   _  __ `/   _  ___/  __ `/_  ___/")
            Console.WriteLine("_  ___ / /_/ / / /_/ / _  / _  / / /  /_/ /    / /_/ /    / /__ / /_/ /_  /    ")
            Console.WriteLine("/_/  |_\__,_/  \__,_/  /_/  /_/ /_/_\__, /     \__,_/     \___/ \__,_/ /_/     ")
            Console.WriteLine("                                   /____/                                      ")
            Console.WriteLine("")


            Console.WriteLine("     Currently adding new car details...")
            Console.WriteLine()
            Console.Write("      Brand: ")
            cars(car_count).brand = Console.ReadLine
            Console.WriteLine()
            Console.Write("      Make: ")
            cars(car_count).make = Console.ReadLine
            Console.WriteLine()
            Console.Write("      Model: ")
            cars(car_count).model = Console.ReadLine
            Console.WriteLine()
            Console.Write("      Year: ")
            cars(car_count).year = CInt(Console.ReadLine)
            Console.WriteLine()
            Console.Write("      Base Cost: ")
            cars(car_count).basecost = CInt(Console.ReadLine)
            Console.WriteLine()
            Console.Write("      Dealer Markup Percentage <i.e. 50 for 50%): ")
            cars(car_count).markup = CInt(Console.ReadLine)
            Console.WriteLine()
            Console.WriteLine("Congratulations! Your car has successfully been added.")
            Console.WriteLine()
            Console.WriteLine("Press any key to return to the Menu.")

        Else
            Console.WriteLine("Apologies, the car database is currently full.")
            Console.WriteLine("If you still wish to add another car then delete an existing car and retry.")
            Console.WriteLine("Press any key to return to the Menu.")

        End If

        car_count += 1

        Console.ReadKey()
        Menu()

    End Sub

    Sub EditCar()

        Dim car_number As Integer

        Console.Clear()

        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine(" __  __       _       _    ")
        Console.WriteLine("|  \/  | __ _(_)_ __ | |_ ___ _ __   __ _ _ __   ___ ___ ")
        Console.WriteLine("| |\/| |/ _` | | '_ \| __/ _ \ '_ \ / _` | '_ \ / __/ _ \")
        Console.WriteLine("| |  | | (_| | | | | | ||  __/ | | | (_| | | | | (_|  __/")
        Console.WriteLine("|_|  |_|\__,_|_|_| |_|\__\___|_| |_|\__,_|_| |_|\___\___|")
        Console.WriteLine("")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()


        'give the user a selection menu
        Console.WriteLine("Select a car from the following list that you wish to edit by entering the number highlighted to the left of the car's name:")

        'loop through the cars
        For i = 0 To car_count - 1
            Console.WriteLine(i & ": " & cars(i).brand & " " & cars(i).make)
        Next

        'get number of the car they want to edit
        Console.Write("Selection: ")
        car_number = CInt(Console.ReadLine)

        Console.Clear()

        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine(" __  __       _       _    ")
        Console.WriteLine("|  \/  | __ _(_)_ __ | |_ ___ _ __   __ _ _ __   ___ ___ ")
        Console.WriteLine("| |\/| |/ _` | | '_ \| __/ _ \ '_ \ / _` | '_ \ / __/ _ \")
        Console.WriteLine("| |  | | (_| | | | | | ||  __/ | | | (_| | | | | (_|  __/")
        Console.WriteLine("|_|  |_|\__,_|_|_| |_|\__\___|_| |_|\__,_|_| |_|\___\___|")
        Console.WriteLine("")
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("         Currently editing car details...")
        Console.WriteLine()


        Console.Write("                  Brand: ")
        cars(car_count).brand = Console.ReadLine
        Console.WriteLine()
        Console.Write("                  Make: ")
        cars(car_count).make = Console.ReadLine
        Console.WriteLine()
        Console.Write("                  Model: ")
        cars(car_count).model = Console.ReadLine
        Console.WriteLine()
        Console.Write("                  Year: ")
        cars(car_count).year = CInt(Console.ReadLine)
        Console.WriteLine()
        Console.Write("                  Base Cost: ")
        cars(car_count).basecost = CInt(Console.ReadLine)
        Console.WriteLine()
        Console.Write("                  Dealer Markup Percentage: ")
        cars(car_count).markup = CInt(Console.ReadLine)
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("     Congratulations! Your car has successfully been edited.")
        Console.WriteLine()
        Console.WriteLine("             Press any key to return to the Menu.")

        Console.ReadKey()
        Menu()


    End Sub

    Sub ViewCar()
        Dim car_number As Integer
        Dim car_sold As Integer

        Console.Clear()

        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine(" _______                               ")
        Console.WriteLine("(_______)                              ")
        Console.WriteLine(" _   ___ _____  ____ _____  ____ _____ ")
        Console.WriteLine("| | (_  (____ |/ ___|____ |/ _  | ___ |")
        Console.WriteLine("| |___) / ___ | |   / ___ ( (_| | ____|")
        Console.WriteLine(" \_____/\_____|_|   \_____|\___ |_____)")
        Console.WriteLine("                          (_____|      ")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")

        'give the user a selection menu
        Console.WriteLine("   Select a car from the following list that you wish to view by entering")
        Console.WriteLine("   the number highlighted to the left of the car's name:")
        Console.WriteLine()

        'loop through the car
        For i = 0 To car_count - 1
            Console.WriteLine("   " & i & ": " & cars(i).brand & " " & cars(i).make)
        Next

        Console.WriteLine()
        'get number of the student they want to edit
        Console.Write("   Selection: ")
        car_number = CInt(Console.ReadLine)

        Console.Clear()

        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine(" _______                               ")
        Console.WriteLine("(_______)                              ")
        Console.WriteLine(" _   ___ _____  ____ _____  ____ _____ ")
        Console.WriteLine("| | (_  (____ |/ ___|____ |/ _  | ___ |")
        Console.WriteLine("| |___) / ___ | |   / ___ ( (_| | ____|")
        Console.WriteLine(" \_____/\_____|_|   \_____|\___ |_____)")
        Console.WriteLine("                          (_____|      ")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")

        'write the details back on the screen
        Console.WriteLine("   Viewing the details of car " & cars(car_number).brand & " " & cars(car_number).make)
        Console.WriteLine()
        Console.WriteLine("   Model: " & cars(car_number).model)
        Console.WriteLine("   Year: " & cars(car_number).year)
        Console.WriteLine("   Base Cost: $" & cars(car_number).basecost)
        Console.WriteLine("   Markup Percentage: " & cars(car_number).markup & "%")

        'Full cost
        Console.WriteLine()
        Console.WriteLine("   Full cost: $" & cars(car_number).basecost + (cars(car_number).basecost * cars(car_number).markup))

        'cost increment
        Console.WriteLine("   Cost increment: $" & cars(car_number).basecost * cars(car_number).markup)

        'age of car
        Console.WriteLine("   Age of car: " & 2013 - cars(car_number).year & " years old")
        Console.WriteLine()

        'Income and Profit
        Console.Write("   How many of these cars have been sold so far? ")
        car_sold = CInt(Console.ReadLine)
        Console.WriteLine()
        Console.Write("   The full income for the car is: $" & car_sold * (cars(car_number).basecost + (cars(car_number).basecost * cars(car_number).markup)))
        Console.WriteLine()
        Console.WriteLine("   The full profit for the car is: $" & cars(car_number).basecost + (cars(car_number).basecost * cars(car_number).markup))
        Console.WriteLine()
        Console.WriteLine("   Press any key to return to the menu")
        Console.ReadKey()
        Menu()

    End Sub

    Sub CarStats()
        Console.Clear()

        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("      _, ___  _, ___ _  _, ___ _  _,  _,")
        Console.WriteLine("      (_   |  /_\  |  | (_   |  | / ` (_ ")
        Console.WriteLine("      , )  |  | |  |  | , )  |  | \ , , )")
        Console.WriteLine("       ~   ~  ~ ~  ~  ~  ~   ~  ~  ~   ~ ")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")


        Dim lowest As Integer
        Dim highest As Integer
        Dim highestIndex As Integer
        Dim lowestIndex As Integer

        lowest = cars(0).basecost
        highest = cars(0).basecost

        For i As Integer = 0 To car_count - 1
            If cars(i).basecost > highest Then
                highestIndex = i
                highest = cars(i).basecost

            End If


            If cars(i).basecost < lowest Then
                lowestIndex = i
                lowest = cars(i).basecost

            End If

        Next
        'lowest car base cost
        Console.WriteLine("   Lowest car base cost <$" & cars(lowestIndex).brand & ", " & cars(lowestIndex).model & " " & cars(lowestIndex).make & "<" & cars(lowestIndex).year & ">>: " & cars(lowestIndex).basecost)
        Console.WriteLine()

        'highest car base cost
        Console.WriteLine("   Highest car base cost <$" & cars(highestIndex).brand & ", " & cars(highestIndex).model & " " & cars(highestIndex).make & "<" & cars(highestIndex).year & ">>: " & cars(highestIndex).basecost)
        Console.WriteLine()

        'average car base cost
        Console.WriteLine("   Average car base cost: $")

        Console.WriteLine("")
        Console.WriteLine("   __)__)__)__)__)__)__)__)__)__)__)__)__)__)__)__)__)__)__)__)__)")
        Console.WriteLine("  (  (  (  (  (  (  (  (  (  (  (  (  (  (  (  (  (  (  (  (  (")
        Console.WriteLine("")

        'lowest card income
        Console.WriteLine("   Lowest car income <$" & cars(lowestIndex).brand & ", " & cars(lowestIndex).model & " " & cars(lowestIndex).make & "<" & cars(lowestIndex).year & ">>: " & cars(lowestIndex).basecost)
        Console.WriteLine()

        'highest car income
        Console.WriteLine("   Highest car income <$" & cars(highestIndex).brand & ", " & cars(highestIndex).model & " " & cars(highestIndex).make & "<" & cars(highestIndex).year & ">>: " & cars(highestIndex).basecost)
        Console.WriteLine()

        'average car income
        Console.WriteLine("   Average car income: $")
        Console.WriteLine()

        Console.WriteLine()
        Console.WriteLine("      Press any key to return to the menu")

        Console.ReadKey()
        Menu()

    End Sub

    Sub RemoveCar()

        Dim selection As Integer

        Console.Clear()

        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("     ____.             __     _____.___.                .___")
        Console.WriteLine("    |    |__ __  ____ |  | __ \__  |   |____ _______  __| _/")
        Console.WriteLine("    |    |  |  \/    \|  |/ /  /   |   \__  \\_  __ \/ __ | ")
        Console.WriteLine("/\__|    |  |  /   |  \    <   \____   |/ __ \|  | \/ /_/ | ")
        Console.WriteLine("\________|____/|___|  /__|_ \  / ______(____  /__|  \____ | ")
        Console.WriteLine("                    \/     \/  \/           \/           \/ ")
        Console.WriteLine("")
        Console.WriteLine()
        Console.WriteLine()



        Console.WriteLine("   Select which car you wish to remove")

        For i = 0 To car_count - 1
            Console.WriteLine("   " & i & ": " & cars(i).brand & " " & cars(i).make)
        Next

        selection = CInt(Console.ReadLine)


        For i = selection To car_count - 2
            cars(i) = cars(i + 1)
        Next

        Console.WriteLine("   Congratulations! The car has been removed.. forever! ")
        Console.WriteLine()
        Console.WriteLine("   Press any key to return to the menu")


        car_count -= 1

        Console.ReadKey()

        Menu()


    End Sub

    Sub Settings()

        Console.Clear()

        Dim selection As String

        Console.WriteLine("  .--.      .-'.      .--.      .--.      .--.      .--.      .`-.      .--.")
        Console.WriteLine(":::::.\::::::::.\::::::::.\::::::::.\::::::::.\::::::::.\::::::::.\::::::::.\")
        Console.WriteLine("'      `--'      `.-'      `--'      `--'      `--'      `-.'      `--'      `")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("")
        Console.WriteLine("Press any key to return to the menu")
        Console.WriteLine("")
        Console.WriteLine("  .--.      .-'.      .--.      .--.      .--.      .--.      .`-.      .--.")
        Console.WriteLine(":::::.\::::::::.\::::::::.\::::::::.\::::::::.\::::::::.\::::::::.\::::::::.\")
        Console.WriteLine("'      `--'      `.-'      `--'      `--'      `--'      `-.'      `--'      `")

        Console.ReadKey()
        Menu()


    End Sub
    Sub HelloWorld() Handles tmrText.Elapsed

        ' Place the cursor at the start of the screen.
        Console.SetCursorPosition(0, 0)

        ' Determine the colour based on the bool variable
        If firstColour = True Then
            Console.ForegroundColor = ConsoleColor.Cyan

            ' Set it to false.
            firstColour = False
        Else
            Console.ForegroundColor = ConsoleColor.Green

            ' Set it to true.
            firstColour = True
        End If


        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine()
        Console.WriteLine("           __      __       .__                               ")
        Console.WriteLine("          /  \    /  \ ____ |  |   ____  ____   _____   ____  ")
        Console.WriteLine("          \   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \ ")
        Console.WriteLine("           \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/ ")
        Console.WriteLine("            \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >")
        Console.WriteLine("                 \/       \/          \/            \/     \/ ")
        Console.WriteLine("                          to FUN WITH CARS")
        Console.WriteLine("                                             -by Peter Silalahi")
        Console.WriteLine()
        Console.WriteLine("                     Press any key to continue...")




    End Sub
    Sub Menu()

        Dim selection As Char

        Do

            Console.Clear()

            'display the menu
            Console.WriteLine("@ _  @  _  @  _  @  _  @  )     (  @  _  @  _  @  _  @  _  @")
            Console.WriteLine("`/ `<_,< `<_,< `<_,< `<_,<(((()))>._>' >._>' >._>' >._>' \'")
            Console.WriteLine("( @     @     @     @     )     (     @     @     @     @ )   ")
            Console.WriteLine(" \'                                                     `/")
            Console.WriteLine("@ )                                                     ( @")
            Console.WriteLine("`/      Welcome to Peter's version of Fun with Cars.     \'")
            Console.WriteLine("( @                                                     @ )")
            Console.WriteLine(" \'            Select from the options below            `/")
            Console.WriteLine("@ )                 <A> Add a car                       ( @")
            Console.WriteLine("`/                  <B> Edit an existing car             \'")
            Console.WriteLine("( @                 <C> View existing car details       @ )")
            Console.WriteLine(" \'                 <D> Display all car statistics      `/")
            Console.WriteLine("@ )                 <E> Remove an existing car          ( @")
            Console.WriteLine("`/                  <F> Settings                         \'")
            Console.WriteLine("( @                 <Q> Exit program                    @ )")
            Console.WriteLine(" \'                                                     `/")
            Console.WriteLine("@ )                                                     ( @")
            Console.WriteLine("`/                                                       \'")
            Console.WriteLine("( @  _  @  _  @  _  @  _  )     (  _  @  _  @  _  @  _  @ )")
            Console.WriteLine(" \_,< `<_,< `<_,< `<_,< `<((())))>' >._>' >._>' >._>' >._/")
            Console.WriteLine("     @     @     @     @  )     (  @     @     @     @")

            Console.WriteLine()
            Console.WriteLine("The program has been running for: ")
            Console.WriteLine()
            Console.WriteLine("Selection :")

            'get the character from the user
            selection = CChar(Console.ReadLine().ToUpper)

            'check what they typed in
            If selection = "A" Then
                AddCar()
            ElseIf selection = "B" Then
                EditCar()
            ElseIf selection = "C" Then
                ViewCar()
            ElseIf selection = "D" Then
                CarStats()
            ElseIf selection = "E" Then
                RemoveCar()
            ElseIf selection = "F" Then
                Settings()
            End If

        Loop Until selection = "Q"

    End Sub

    Sub SaveCar()

        'loop through our array  and save
        FileOpen(1, "cars.txt", OpenMode.Output)

        For i = 0 To car_count - 1

            'write all the data to file
            PrintLine(1, cars(i).brand)
            PrintLine(1, cars(i).make)
            PrintLine(1, cars(i).model)
            PrintLine(1, cars(i).year)
            PrintLine(1, cars(i).basecost)
            PrintLine(1, cars(i).markup)

            On Error Resume Next



        Next

        FileClose(1)

    End Sub

    Sub LoadCar()

        If IO.File.Exists("cars.txt") Then

            'load all the cars from the text file
            FileOpen(1, "cars.txt", OpenMode.Input)

            While Not EOF(1)

                'load the 6 lines for the student
                cars(car_count).brand = LineInput(1)
                cars(car_count).make = LineInput(1)
                cars(car_count).model = LineInput(1)
                cars(car_count).year = CInt(LineInput(1))
                cars(car_count).basecost = CInt(LineInput(1))
                cars(car_count).markup = CInt(LineInput(1))

                'increment car_count
                car_count += 1

            End While

            FileClose(1)

        End If
    End Sub
    Sub Main()

        For i = 0 To 9
            cars(i) = New CAR
        Next

        ' initialize the timer

        ' Set the interval to 1 second
        tmrText.Interval = 1000

        ' Enable the timer
        tmrText.Enabled = True

        LoadCar()

        HelloWorld()
        Console.ReadKey()
        tmrText.Enabled = False
        Menu()
        SaveCar()

    End Sub

End Module
