Imports System.IO

Module Module1

    Public Class Car
        Public Brand As String
        Public Make As String
        Public Model As String
        Public Year As Integer
        Public BaseCost As Decimal
        Public Markup As Decimal
        Public Profit As Decimal
        Public Income As Decimal

    End Class

    Dim ExitCommanded As Boolean = False
    Dim CarList As New List(Of Car)
    Dim DatabaseList As New List(Of String)

    Dim currentDatabase As String

    ' Menu colours
    Dim cUser, cOption, cDeco, cBracket, cDesc, cHeading, _
        cInput, cError, cInfo, cInstruction, cCar, cValue, cNum As ConsoleColor

    Sub Main()
        Try
            SetupColors()
            InitializeDatabases()

            Console.Title = "Fun With Cars Evert 3"
            Console.WriteLine("Loading cars from database...")

            LoadCarsfromFile()
            DisplayMenu()

            Dim input As ConsoleKeyInfo

            While ExitCommanded = False

                input = Console.ReadKey(True)
                If input.Key = ConsoleKey.Escape Then
                    Exit While
                End If

                HandleCommand(input)
            End While

        Catch ex As Exception
            Console.Clear()
            WriteHeader("Error")
            Console.WriteLine()

            cWrite("An unhandled exception occured. Please notify the developer:", cInstruction)
            Console.WriteLine()

            cWrite(ex.ToString, cError)
            Console.ReadKey()
        End Try


    End Sub

    ''' <summary>
    ''' Assigns ConsoleColors to the color variables.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetupColors()
        cUser = ConsoleColor.Green ' Text that the user types
        cOption = ConsoleColor.Green ' Commands that can be used E.G. "[A]"
        cDeco = ConsoleColor.DarkGreen ' Decorations. E.G. "+-------+"
        cBracket = ConsoleColor.Gray ' Brackets. E.G. "["
        cDesc = ConsoleColor.Gray ' Descriptions. E.G "Add a new car"
        cHeading = ConsoleColor.Cyan ' Headings, E.G. "Fun with Cars"
        cInput = ConsoleColor.Yellow ' "Brand:"  "Selection:", Lines that take input.
        cError = ConsoleColor.Red ' "That is not a command!"
        cInstruction = ConsoleColor.Magenta ' "Car has been added"
        cInfo = ConsoleColor.Magenta ' "Please enter the information as required."
        cCar = ConsoleColor.White ' BRAND, MODEL MAKE (YEAR)
        cValue = ConsoleColor.DarkCyan '"Brand: ", "Make: "
        cNum = ConsoleColor.Magenta ' Numbers, $50,000.00
    End Sub

    ''' <summary>
    ''' Calls the appropriate screen based on the input key.
    ''' </summary>
    ''' <param name="command">The key the user pressed as ConsoleKeyInfo</param>
    ''' <remarks></remarks>
    Private Sub HandleCommand(ByVal command As ConsoleKeyInfo)
        Dim badCommand As Boolean
        Select Case command.Key.ToString.ToLower

            Case "a"
                Console.Clear()
                ScreenAddCar()

            Case "e"
                Console.Clear()
                ScreenEditCar()

            Case "v"
                Console.Clear()
                ScreenViewCarDetails()

            Case "d"
                Console.Clear()
                ScreenDisplayStatistics()

            Case "r"
                Console.Clear()
                ScreenRemoveCar()

            Case "m"
                Console.Clear()
                ScreenManageDatabase()

            Case "q"
                SaveListToFile()
                ExitCommanded = True

            Case ""

            Case Else
                badCommand = True
        End Select

        If badCommand = True Then
            DisplayError("""" & command.Key.ToString & """ is not a valid option.", 0, 3)
        Else
            Console.Clear()
            DisplayMenu()
        End If

    End Sub

    ' Screens. E.G Main Menu, Edit a car
#Region "Screens"

    Private Sub DisplayMenu()
        Console.Clear()

        WriteHeader("Fun With Cars")
        Console.WriteLine()

        ' Save the cursor position before the options are printed.
        Dim OptionsCursorPos() As Integer = {Console.CursorLeft, Console.CursorTop}

        cWriteArray("+----------- /Options/ ------------+", {cDeco, cHeading, cDeco}, "/")
        cWriteArray("| /[/A/]/ - Add a new car/            |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/E/]/ - Edit a car/               |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/V/]/ - View car details/         |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/D/]/ - Display car statistics/   |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/R/]/ - Remove a car/             |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/M/]/ - Manage Databases/         |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/Q/]/ - Quit/                     |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("+--------------------------------+", {cDeco})
        cWrite("> ", cInput, False, cUser)

        ' Save the cursor positions after the options have been printed.
        ' This is where the cursor will be set after additional User Interface
        ' elements have been printed.
        Dim finalPos() As Integer = {Console.CursorLeft, Console.CursorTop} ' input location

        ' Print the Amount of cars in the database
        DisplayCarsCount(OptionsCursorPos(0) + 40, OptionsCursorPos(1))

        ' print the name of the current database
        PrintCurrentDatabase(OptionsCursorPos(0) + 40, OptionsCursorPos(1) + 4)

        ' Restore the cursor positions.
        Console.SetCursorPosition(finalPos(0), finalPos(1))

        Console.ForegroundColor = cUser

    End Sub

    Private Sub ScreenAddCar()
        Dim tmpCar As New Car
        Dim input As String = "A"
        Dim invalidReason As String = ""

        WriteHeader("Add a new car...")
        Console.WriteLine()

        If CarList.Count >= 250 Then
            cWrite("You can not add more than 250 cars to one database.", cError)
            cWrite("Either delete a car or create a new database.", cError)
            Console.ReadKey(True)
            Exit Sub
        End If

        cWrite("Enter the car information below:", cInfo)
        Console.WriteLine()


        For i As Integer = 1 To 6
            Select Case i
                Case 1
                    cWrite("Brand: ", cInput, False, cUser)
                    input = Console.ReadLine
                Case 2
                    cWrite("Make: ", cInput, False, cUser)
                    input = Console.ReadLine
                Case 3
                    cWrite("Model: ", cInput, False, cUser)
                    input = Console.ReadLine
                Case 4
                    cWrite("Year: ", cInput, False, cUser)
                    input = Console.ReadLine
                Case 5
                    cWrite("Base Cost: ", cInput, False, cUser)
                    input = Console.ReadLine
                Case 6
                    cWrite("Dealer Markup Percentage: ", cInput, False, cUser)
                    input = Console.ReadLine
            End Select

            If input = "" Then
                Exit Sub
            End If

            ' Strings
            If i < 4 Then
                If ValidateInput(input, invalidReason) Then

                    Select Case i
                        Case 1
                            tmpCar.Brand = input
                        Case 2
                            tmpCar.Make = input
                        Case 3
                            tmpCar.Model = input
                    End Select

                Else
                    cWrite(invalidReason, cError)
                    Console.ReadKey(True)
                    Console.Clear()
                    ScreenAddCar()
                    Exit Sub
                End If
            Else
                ' Decimals and integers
                Dim returnDecimal As Decimal = Nothing
                If ValidateInput(input, invalidReason, 1, False, returnDecimal) Then

                    Select Case i
                        Case 4
                            tmpCar.Year = CInt(returnDecimal)
                        Case 5
                            tmpCar.BaseCost = returnDecimal
                        Case 6
                            tmpCar.Markup = returnDecimal
                    End Select
                Else
                    cWrite(invalidReason, cError)
                    Console.ReadKey(True)
                    Console.Clear()
                    ScreenAddCar()
                    Exit Sub
                End If
            End If


        Next
        AddCar(tmpCar)
        cWrite("Car has been added: ", cInfo, False)

        ' print the car info that has been added.
        cWrite(GetCarInfo(CarList.Count - 1), cCar, True)
        Console.ReadKey(True)
    End Sub

    ''' <summary>
    ''' This screen only prints the car list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenEditCar()
        Dim input As String
        Dim invalidReason As String = ""
        Dim carIndex As Integer = 0

        WriteHeader("Edit a car...")
        Console.WriteLine()
        cWrite("Choose a car from the list below to edit", cInstruction)
        Console.WriteLine()

        PrintCarList()

        ' If there are more than 22 cars the instruction at the top is not visible.
        ' So we print it at the bottom as well.
        If CarList.Count > 22 Then
            cWrite("Choose a car from the list above to edit", cInstruction)
        End If

        cWrite("> ", cInput, False, cUser)
        input = Console.ReadLine

        If input = "" Then
            Exit Sub
        End If

        ' Check if the input is valid.
        If ValidateInput(input, invalidReason, carIndex, True) Then
            carIndex = carIndex - 1
        Else
            cWrite(invalidReason, cError, True)
            Console.ReadKey()
            Console.Clear()
            ScreenEditCar()
            Exit Sub
        End If

        ScreenEditCarID(carIndex)

    End Sub

    ''' <summary>
    ''' Screen to edit car information
    ''' </summary>
    ''' <param name="carIndex">The index of the car to edit.</param>
    ''' <remarks></remarks>
    Private Sub ScreenEditCarID(ByVal carIndex As Integer)
        Console.Clear()

        Dim input As String = ""
        Dim invalidReason As String = ""

        WriteHeader("Editing car " & carIndex + 1)
        Console.WriteLine()
        cWrite("Edit the information as required.", cInstruction)
        Console.WriteLine()

        For i As Integer = 1 To 6
            Select Case i
                Case 1
                    ' The VirtualString() function returns the text entered.
                    input = VirtualString("Brand: ", CarList.Item(carIndex).Brand, cInput, cCar, cUser)
                Case 2
                    input = VirtualString("Make: ", CarList.Item(carIndex).Make, cInput, cCar, cUser)
                Case 3
                    input = VirtualString("Model: ", CarList.Item(carIndex).Model, cInput, cCar, cUser)
                Case 4
                    input = VirtualString("Year: ", CStr(CarList.Item(carIndex).Year), cInput, cCar, cUser)
                Case 5
                    input = VirtualString("Base Cost: ", CStr(CarList.Item(carIndex).BaseCost), cInput, cCar, cUser)
                Case 6
                    input = VirtualString("Dealer Markup Percentage: ", CStr(CarList.Item(carIndex).Markup), cInput, cCar, cUser)

            End Select

            ' Check the user's input
            If input = "" And i = 1 Then
                Exit Sub
            End If

            ' Strings
            If i < 4 Then
                If ValidateInput(input, invalidReason) Then

                    Select Case i
                        Case 1
                            CarList.Item(carIndex).Brand = input
                        Case 2
                            CarList.Item(carIndex).Make = input
                        Case 3
                            CarList.Item(carIndex).Model = input
                    End Select
                Else
                    cWrite(invalidReason, cError)
                    Console.ReadKey(True)
                    Console.Clear()
                    ScreenEditCarID(carIndex)
                    Exit Sub
                End If

            Else ' Integers and Decimals
                Dim returnedSingle As Decimal = Nothing

                If ValidateInput(input, invalidReason, 1, False, returnedSingle) Then

                    Select Case i
                        Case 4
                            CarList(carIndex).Year = CInt(returnedSingle)
                        Case 5
                            CarList.Item(carIndex).BaseCost = returnedSingle
                        Case 6
                            CarList.Item(carIndex).Markup = returnedSingle
                    End Select
                Else
                    cWrite(invalidReason, cError)
                    Console.ReadKey(True)
                    Console.Clear()
                    ScreenEditCarID(carIndex)
                    Exit Sub
                End If

            End If
        Next

        SaveListToFile()
        cWrite("Car has been updated.", cInfo)
        Console.ReadKey(True)

    End Sub

    ''' <summary>
    ''' This screen only prints the car list to view the details.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenViewCarDetails()
        Dim input As String

        WriteHeader("View Car Details")
        Console.WriteLine()
        cWrite("Choose a car from the list below to view it's details.", cInstruction, True)
        Console.WriteLine()

        PrintCarList()

        If CarList.Count > 22 Then
            cWrite("Choose a car from the list above to view it's details.", cInstruction)
        End If

        cWrite("> ", cInput, False, cUser)

        input = Console.ReadLine

        If input = "" Then
            Exit Sub
        End If

        Dim invalidReason As String = ""
        Dim returnedInteger As Integer = Nothing

        If ValidateInput(input, invalidReason, returnedInteger, True) Then
            ScreenViewCarDetailsID(returnedInteger - 1)
            Exit Sub
        Else
            cWrite(invalidReason, cError)
            Console.ReadKey(True)
            Console.Clear()
            ScreenViewCarDetails()
            Exit Sub
        End If

    End Sub

    ''' <summary>
    ''' Screen to view car details
    ''' </summary>
    ''' <param name="carIndex">The index of the car to be viewed.</param>
    ''' <remarks></remarks>
    Private Sub ScreenViewCarDetailsID(ByVal carIndex As Integer)
        Console.Clear()
        Dim input As String
        WriteHeader("Displaying details on car #" & carIndex + 1)
        Console.WriteLine()

        cWriteArray(ArgsInStr("Brand: /{0}", {CarList.Item(carIndex).Brand}), {cValue, cCar}, "/", True)
        cWriteArray(ArgsInStr("Make: /{0}", {CarList.Item(carIndex).Make}), {cValue, cCar}, "/", True)
        cWriteArray(ArgsInStr("Model: /{0}", {CarList.Item(carIndex).Model}), {cValue, cCar}, "/", True)
        cWriteArray(ArgsInStr("Year: /{0}", {CStr(CarList.Item(carIndex).Year)}), {cValue, cNum}, "/", True)
        cWriteArray(ArgsInStr("Base Cost: /${0}", {CStr(AC(Math.Round(CarList.Item(carIndex).BaseCost, 2)))}), {cValue, cNum}, "/", True)
        cWriteArray(ArgsInStr("Markup Percentage: /{0}%", {CStr(AC(Math.Round(CarList.Item(carIndex).Markup, 2)))}), {cValue, cNum}, "/", True)

        Console.WriteLine()

        cWriteArray(ArgsInStr("Full Cost: /${0}", {CStr(AC(Math.Round(CarList.Item(carIndex).BaseCost * CarList.Item(carIndex).Markup / 100 + CarList.Item(carIndex).BaseCost, 2)))}), {cValue, cNum}, "/")
        cWriteArray(ArgsInStr("Profit: /${0}", {CStr(AC(Math.Round(CarList.Item(carIndex).BaseCost * CarList.Item(carIndex).Markup / 100, 2)))}), {cValue, cNum}, "/")
        cWriteArray(ArgsInStr("Age of car: /{0}", {CStr(Date.Now.Year - CarList.Item(carIndex).Year)}), {cValue, cNum}, "/")

        Console.WriteLine()

        cWrite("How many cars have been sold?", cInput, True)
        cWrite("> ", cInput, False, cUser)

        ' Wait for user input.
        input = Console.ReadLine

        If input = "" Then
            Exit Sub
        End If

        Dim invalidReason As String = ""
        Dim returnInt As Integer = Nothing
        Dim tmpString As String = ""

        If ValidateInput(input, invalidReason, returnInt, False) Then
            tmpString = CStr(AC(Math.Round((CarList.Item(carIndex).BaseCost * CarList.Item(carIndex).Markup / 100 + CarList.Item(carIndex).BaseCost) * returnInt, 2)))
            cWriteArray(ArgsInStr("Total income for car: /${0}", {tmpString}), {cValue, cNum}, "/", True)
            tmpString = CStr(AC(Math.Round((CarList.Item(carIndex).BaseCost * CarList.Item(carIndex).Markup / 100) * returnInt, 2)))
            cWriteArray(ArgsInStr("Total profit for car: /${0}", {tmpString}), {cValue, cNum}, "/")
        Else
            cWrite(invalidReason, cError)
            Console.ReadKey(True)
            Console.Clear()
            ScreenViewCarDetailsID(carIndex)
            Exit Sub
        End If

        Console.ReadKey(True)
    End Sub

    ''' <summary>
    ''' This screen displays the statistics on all cars in the current database.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenDisplayStatistics()
        WriteHeader("Statistics for car database")
        Console.WriteLine()

        If CarList.Count = 0 Then
            cWrite("Add a car first to view statistics.", cError)
            Console.ReadKey(True)
            Exit Sub
        End If

        Dim tmpString As String = ""
        ' Returns all the cars BaseCost value into one array. This array is used to get the min, max, avg, sum.
        Dim extractedNumbers() As Decimal = ExtractNumbers("BaseCost")
        Dim minMax() As Decimal = GetMinMax(extractedNumbers)
        Dim tmpCarInfo As String = ""
        Dim sd As String

        Dim header As String = ""
        Dim measuredNumber As String = ""

        For i As Integer = 1 To 3

            Select Case i
                Case 1
                    header = "-------------------------------- /Base Cost/ ------------------------------------"
                    measuredNumber = "base cost"
                    extractedNumbers = ExtractNumbers("BaseCost")

                Case 2
                    Console.WriteLine()
                    header = "---------------------------------- /Profit/ -------------------------------------"
                    measuredNumber = "profit"
                    extractedNumbers = ExtractNumbers("Profit")

                Case 3
                    Console.WriteLine()
                    header = "---------------------------------- /Income/ -------------------------------------"
                    measuredNumber = "income"
                    extractedNumbers = ExtractNumbers("Income")
            End Select

            minMax = GetMinMax(extractedNumbers)
            sd = GetSD(extractedNumbers)

            ' Lowest
            cWriteArray(header, {cDeco, cHeading, cDeco}, "/", True)
            tmpCarInfo = GetCarInfo(CInt(minMax(2))) ' Lowest car details
            tmpString = ArgsInStr("Lowest car {2} (/{0}/): /${1}", {tmpCarInfo, CStr(AC(minMax(0))), measuredNumber})
            cWriteArray(tmpString, {cValue, cCar, cValue, cNum}, "/")

            ' Highest
            tmpCarInfo = GetCarInfo(CInt(minMax(3))) ' highest car details
            tmpString = ArgsInStr("Highest car {2} (/{0}/): /${1}", {tmpCarInfo, CStr(AC(minMax(1))), measuredNumber})
            cWriteArray(tmpString, {cValue, cCar, cValue, cNum}, "/")

            ' Average
            tmpString = ArgsInStr("Average car {1}: /${0}", {CStr(AC(minMax(5))), measuredNumber})
            cWriteArray(tmpString, {cValue, cNum}, "/")

            ' Standard Deviation
            tmpString = ArgsInStr("Standard Deviation: /{0}", {sd})
            cWriteArray(tmpString, {cValue, cNum}, "/")

            ' Sum
            tmpString = ArgsInStr("Sum of cars {1}: /${0}", {CStr(AC(minMax(4))), measuredNumber})
            cWriteArray(tmpString, {cValue, cNum}, "/")

        Next

        Console.ReadKey(True)

    End Sub

    ''' <summary>
    ''' This screen prints the car list and deletes the car the use chooses.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenRemoveCar()
        Dim input As String = ""

        WriteHeader("Remove a car...")
        Console.WriteLine()
        cWrite("Choose a car from the list below to remove it from the database.", cInstruction)

        PrintCarList()

        If CarList.Count > 22 Then
            cWrite("Choose a car from the list above to remove it from the database.", cInstruction)
        End If

        cWrite("> ", cInput, False, cUser)
        input = Console.ReadLine()

        If input = "" Then
            Exit Sub
        End If

        Dim returnInt As Integer = Nothing
        Dim invalidReason As String = ""

        If ValidateInput(input, invalidReason, returnInt, True) Then
            DeleteCar(returnInt - 1)
            cWrite("Car #" & returnInt & " has been removed from the database.", cInfo)
        Else
            cWrite(invalidReason, cError)
            Console.ReadKey(True)
            Console.Clear()
            ScreenRemoveCar()
            Exit Sub
        End If

        Console.ReadKey(True)

    End Sub

    ''' <summary>
    ''' Prints and handles the options to manage the databases.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenManageDatabase()
        WriteHeader("Manage Database")
        Console.WriteLine()

        cWriteArray("+--------------- /Options/ ----------------+", {cDeco, cHeading, cDeco}, "/")
        cWriteArray("| /[/L/]/ - Load an existing database/        |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/N/]/ - Create a new database/            |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/D/]/ - Delete a database/                |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/Q/]/ - Go back to the main menu/         |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("+----------------------------------------+", {cDeco})
        cWrite("> ", cInput, False, cUser)

        Dim input As ConsoleKeyInfo
        Dim chosen As Boolean = False

        While chosen = False
            input = Console.ReadKey(True)

            If input.Key = ConsoleKey.Enter Then
                Exit Sub
            End If

            If input.Key = ConsoleKey.Escape Then
                ' ExitCommanded = True
                Exit Sub
            End If

            Select Case input.Key.ToString.ToLower

                Case "l"
                    Console.Clear()
                    ScreenLoadDatabase()
                    chosen = True

                Case "n"
                    Console.Clear()
                    ScreenNewDatabase()
                    chosen = True

                Case "d"
                    Console.Clear()
                    ScreenDeleteDatabase()
                    chosen = True

                    'Case "r"
                    '    Console.WriteLine("Stop pressing me buttons!")

                Case "q"
                    Exit Sub

                Case Else
                    DisplayError("""" & input.Key.ToString & """ is not a valid option", 0, 3)
            End Select

        End While

    End Sub

    ''' <summary>
    ''' prints the list of databases and loads the choosen database.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenLoadDatabase()
        WriteHeader("Load Database")
        Console.WriteLine()

        cWrite("Select a database from below to load.", cInstruction)

        PrintDatabases()

        cWrite("> ", cInput, False, cUser)
        Dim input As String = Console.ReadLine()

        If input = "" Then
            Exit Sub
        End If

        Dim returnInt As Integer
        Dim badInput As Boolean = False

        If Integer.TryParse(input, returnint) Then
            If returnInt = 0 Or returnInt > DatabaseList.Count Then
                badInput = True
            End If
        Else
            badInput = True
        End If

        If badInput = True Then
            cWrite("""" & input & """ is not a valid option.", cError)
            Console.ReadKey(True)
            Console.Clear()
            ScreenLoadDatabase()
        Else
            OpenDatabase(returnInt - 1)
        End If

    End Sub

    ''' <summary>
    ''' Screen to create a new database. Validates the name.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenNewDatabase()
        WriteHeader("Create a new database")

        Console.WriteLine()

        cWrite("Database Name: ", cInput, False, cUser)

        Dim input As String = Console.ReadLine
        Dim invalidChars() As String = {"\", "/", ":", "?", """", "*", "<", ">", "|"}

        If input = "" Then
            Exit Sub
        End If

        ' Check if a database with the same name aleady exists.
        For i As Integer = 0 To DatabaseList.Count - 1
            If input.ToLower = DatabaseList.Item(i).ToLower Then
                cWrite("A Database with that name already exists.", cError)
                Console.ReadKey(True)
                Console.Clear()
                ScreenNewDatabase()
                Exit Sub
            End If
        Next

        If input.Length > 33 Then
            cWrite("The database name can only be 32 characters long", cError)
            Console.ReadKey(True)
            Console.Clear()
            ScreenNewDatabase()
            Exit Sub
        End If

        Dim valid As Boolean = True

        ' Check if the name contains invalid characters. These characters can not be used in file names.
        For Each element In invalidChars
            If input.Contains(element) Then
                valid = False
                Exit For
            End If
        Next

        ' Display error
        If valid = False Then
            cWrite("The name can not contain any of the following characters: / \ * ? "" | < > :", cError)
            Console.ReadKey(True)
            Console.Clear()
            ScreenNewDatabase()
            Exit Sub
        End If

        ' This will only be executed when there are no errors.
        CreateDatabase(input)
        cWrite("The database """ & input & """ has been successfully created", cInfo)
        Console.ReadKey(True)

    End Sub

    ''' <summary>
    ''' Screen to delete a database the user chooses.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ScreenDeleteDatabase()

        WriteHeader("Delete database")
        Console.WriteLine()
        cWrite("choose a database from below to delete.", cInstruction)
        Console.WriteLine()

        PrintDatabases()

        cWrite("> ", cInput, False, cUser)
        Dim input As String = Console.ReadLine()

        If input = "" Then
            Exit Sub
        End If

        Dim returnInt As Integer
        Dim badInput As Boolean = False

        ' Check if the input is valid
        If Integer.TryParse(input, returnInt) Then
            If returnInt = 0 Or returnInt > DatabaseList.Count Then
                badInput = True
            End If
        Else
            badInput = True
        End If

        ' If the input is invalid, display the error message, else delete the database.
        If badInput = True Then
            cWrite("""" & input & """ is not a valid option.", cError)
            Console.ReadKey(True)
            Console.Clear()
            ScreenDeleteDatabase()

        Else
            cWrite("The database """ & DatabaseList.Item(returnInt - 1) & """ has been deleted.", cInfo)
            DeleteDatabase(returnInt - 1)
            Console.ReadKey(True)
        End If

    End Sub

    ''' <summary>
    ''' This function prints and handles the options when an error occurs when loading the cars from file.
    ''' </summary>
    ''' <param name="lineNumber">The line number when the error occured.</param>
    ''' <remarks></remarks>
    Private Sub ScreenProcessingError(ByVal lineNumber As Integer)
        Console.Clear()

        Dim input As ConsoleKeyInfo
        Dim chosen As Boolean = False

        cWrite("There was an error loading the car in the following database:", cError)

        ' Print the line on which the error occured and the database.
        cWrite(ArgsInStr("Line: {0}", {CStr(lineNumber)}), cError)
        cWrite(ArgsInStr("Database: {0}", {currentDatabase}), cError)

        Console.WriteLine()

        cWrite("Select an action from the menu below.", cInstruction)
        Console.WriteLine()

        cWriteArray("+----------- /Options/ ------------+", {cDeco, cHeading, cDeco}, "/")
        cWriteArray("| /[/R/]/ - Remove the invalid car/   |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/D/]/ - Delete the database/      |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/Q/]/ - Quit/                     |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("+--------------------------------+", {cDeco})
        Console.WriteLine()

        cWrite("> ", cInput, False, cUser)

        ' Chosen becomes true when the user has chosen a valid option.
        While chosen = False
            input = Console.ReadKey(True)

            Select Case input.Key.ToString.ToLower
                Case "r"
                    ' Remove the invalid car.

                    ' if the file does not exist, there is nothing to fix.
                    If My.Computer.FileSystem.FileExists("Databases\" & currentDatabase & ".txt") Then
                        Dim reader As New StreamReader("Databases\" & currentDatabase & ".txt")
                        Dim tmpFileContents As String = ""
                        Dim curLineNum As Integer = 1
                        Dim textLine As String

                        ' Read until the end of the file.
                        While reader.Peek <> -1
                            textLine = reader.ReadLine

                            ' Do not add empty or the invalid line to the new file
                            If curLineNum <> lineNumber And textLine <> "" Then
                                tmpFileContents &= textLine & Environment.NewLine
                            End If

                            curLineNum += 1
                        End While

                        reader.Close()

                        ' Write the new file contents to file.
                        Dim writer As New StreamWriter("Databases\" & currentDatabase & ".txt", False)
                        writer.Write(tmpFileContents)
                        writer.Close()

                        cWrite("The invalid car has been removed.", cInfo)

                        Console.ReadKey(True)
                        CarList.Clear()
                        LoadCarsfromFile()
                    End If
                    chosen = True

                Case "d"
                    ' Delete the database.

                    ' Delete the file if it exists.
                    If My.Computer.FileSystem.FileExists("Databases\" & currentDatabase & ".txt") Then
                        My.Computer.FileSystem.DeleteFile("Databases\" & currentDatabase & ".txt")

                        ' Remove the database from the list.
                        DeleteDatabase(GetDatabaseIndex(currentDatabase))

                        ' Set the current database to the Default
                        currentDatabase = "Default"
                        SaveLastDatabase()

                        cWrite("The database has been deleted.", cInfo)
                        Console.ReadKey(True)
                    End If

                    ' Clear the carList to avoid duplicates
                    CarList.Clear()

                    chosen = True
                Case "q"
                    ExitCommanded = True
                    chosen = True

                Case Else
                    DisplayError(ArgsInStr("""{0}"" is not a valid option", {input.KeyChar}), 0, 5)
            End Select

        End While
    End Sub

#End Region

    ' Functions related to cars. These make up the basic functions of the program.
#Region "Car Operations"

    ''' <summary>
    ''' Adds the given car to the carList and also saves it to file.
    ''' </summary>
    ''' <param name="carToAdd"></param>
    ''' <remarks></remarks>
    Private Sub AddCar(ByVal carToAdd As Car)

        CarList.Add(carToAdd)

        ' Immediately save all the cars to file, to avoid data loss.
        SaveListToFile()

    End Sub

    ''' <summary>
    ''' Remove the given car index from the array and saves the new list to file.
    ''' </summary>
    ''' <param name="carIndex"></param>
    ''' <remarks></remarks>
    Private Sub DeleteCar(ByVal carIndex As Integer)

        CarList.RemoveAt(carIndex)

        ' Immediately save all the cars to file, to avoid data loss.
        SaveListToFile()

    End Sub

    ''' <summary>
    ''' Saves the carList to file. Replaces the current database file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveListToFile()

        ' If it exists delete the current database file.
        If My.Computer.FileSystem.FileExists("Databases\" & currentDatabase & ".txt") Then
            My.Computer.FileSystem.DeleteFile("Databases\" & currentDatabase & ".txt")
        End If

        ' Add all the cars to the tmpArray, in the correct format.
        Dim tmpArray(CarList.Count) As String

        For i As Integer = 0 To CarList.Count - 1
            tmpArray(i) = ArgsInStr("{0}@{1}@{2}@{3}@{4}@{5}", {CarList.Item(i).Brand, CarList.Item(i).Make, _
                                                                CarList.Item(i).Model, CStr(CarList.Item(i).Year), _
                                                                CStr(CarList.Item(i).BaseCost), CStr(CarList.Item(i).Markup)}) & Environment.NewLine
        Next

        ' Check if the Databases directory exists, if false create it.
        If My.Computer.FileSystem.DirectoryExists("Databases\") = False Then
            My.Computer.FileSystem.CreateDirectory("Databases\")
        End If

        ' Write all the elements in the array to the file.
        Dim writer As New StreamWriter("Databases\" & currentDatabase & ".txt", False)

        For Each element In tmpArray
            ' We use write because the line terminator is already added into the array.
            writer.Write(element)
        Next

        writer.Close()

    End Sub

    ''' <summary>
    ''' Returns the car by index in the format BRAND, MODEL MAKE (YEAR)
    ''' </summary>
    ''' <param name="carIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCarInfo(ByVal carIndex As Integer) As String

        Return ArgsInStr("{0}, {1} {2} ({3})", {CarList.Item(carIndex).Brand, CarList.Item(carIndex).Make, CarList.Item(carIndex).Model, CStr(CarList.Item(carIndex).Year)})

    End Function

    ''' <summary>
    ''' Populates the CarList with the cars from the file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCarsfromFile()
        ' Clear the list otherwise we are adding the same cars again.
        CarList.Clear()

        ' Check if the current database file exists.
        If My.Computer.FileSystem.FileExists("Databases\" & currentDatabase & ".txt") Then

            Dim reader As New StreamReader("Databases\" & currentDatabase & ".txt")

            Dim subStrings() As String
            Dim tmpCar As New Car
            Dim textLine As String

            ' The line number is used to delete the invalid car, if the user chooses to do so.
            Dim lineNumber As Integer = 1

            While reader.Peek <> -1
                textLine = reader.ReadLine

                subStrings = Split(textLine, "@")

                If subStrings.GetUpperBound(0) <> 5 Then
                    reader.Close()
                    ScreenProcessingError(lineNumber)
                    Exit While
                Else
                    Dim returnInt As Integer
                    Dim returnDec As Decimal

                    tmpCar.Brand = subStrings(0)
                    tmpCar.Make = subStrings(1)
                    tmpCar.Model = subStrings(2)

                    ' Try parsing the year
                    If Integer.TryParse(subStrings(3), returnInt) Then
                        tmpCar.Year = returnInt
                    Else
                        reader.Close()
                        ScreenProcessingError(lineNumber)
                        Exit While
                    End If

                    ' Base Cost
                    If Decimal.TryParse(subStrings(4), returnDec) Then
                        tmpCar.BaseCost = returnDec
                    Else
                        reader.Close()
                        ScreenProcessingError(lineNumber)
                        Exit While
                    End If

                    ' markup
                    If Decimal.TryParse(subStrings(5), returnDec) Then
                        tmpCar.Markup = returnDec
                    Else
                        reader.Close()
                        ScreenProcessingError(lineNumber)
                        Exit While
                    End If

                    ' These valus are used in finding the average, Min, and Max.
                    tmpCar.Profit = tmpCar.BaseCost * tmpCar.Markup / 100
                    tmpCar.Income = (tmpCar.BaseCost * tmpCar.Markup / 100) + tmpCar.BaseCost

                    ' Add the tmp car to the car list
                    CarList.Add(tmpCar)

                    ' reset the tmpcar variable.
                    tmpCar = Nothing
                    tmpCar = New Car

                End If

                lineNumber += 1
            End While

            reader.Close()
        End If
    End Sub

    ''' <summary>
    ''' Prints all the cars in the list to the console in the format: (INDEX) BRAND, MAKE MODEL (YEAR)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrintCarList()

        For i As Integer = 0 To CarList.Count - 1

            cWriteArray((ArgsInStr("    [/{0}/] /{1}, {2} {3} ({4})", {CStr(i + 1), CarList.Item(i).Brand, CarList.Item(i).Make, CarList.Item(i).Model, _
                                                                             CStr(CarList.Item(i).Year)})), {cBracket, cOption, cBracket, cCar}, "/")
        Next
    End Sub

#End Region

    ' Functions that print specific text to the console.
#Region "User Interface Elements"

    ''' <summary>
    ''' Draws a coloured box with the amount of cars inside.
    ''' </summary>
    ''' <param name="left">The left starting position</param>
    ''' <param name="top">The top starting position.</param>
    ''' <remarks></remarks>
    Private Sub DisplayCarsCount(ByVal left As Integer, ByVal top As Integer)

        ' The leftBuffer is the amount of space from the left needed to center the number.
        Dim leftBuffer As Integer
        leftBuffer = CInt(left + 11 - (CarList.Count.ToString).Length / 2)

        Console.SetCursorPosition(left, top)
        ' Write the title
        cWriteArray("+- /Cars In Database /-+", {cDeco, cHeading, cDeco}, "/", False)
        ' move the cursor to the center of the box, by using the leftBuffer variable
        Console.SetCursorPosition(leftBuffer, top + 1)
        ' Write the number of cars in the list.
        cWrite(CStr(CarList.Count), cNum, False)
        ' Move one row down
        Console.SetCursorPosition(left, top + 1)
        cWrite("|", cDeco, False)
        ' Move to the right of the box.
        Console.SetCursorPosition(left + 21, top + 1)
        cWrite("|", cDeco, False)

        ' Write the foot of the box.
        Console.SetCursorPosition(left, top + 2)
        cWrite("+--------------------+", cDeco, False)
    End Sub

    ''' <summary>
    ''' This function writes the heading of the Page/Screen.
    ''' </summary>
    ''' <param name="heading">The heading of the screen</param>
    ''' <remarks></remarks>
    Private Sub WriteHeader(ByVal heading As String)
        cWrite("+-----------------------------------------------------------------------------+", cDeco)
        cWrite("|", cDeco, False)

        WriteCenter(heading, cHeading, -2, False)

        cWriteEnd("|", cDeco)
        cWrite("+-----------------------------------------------------------------------------+", cDeco)
    End Sub

    ''' <summary>
    ''' Prints the given message at the given location. Resets the cursor to it's original position afterwards.
    ''' </summary>
    ''' <param name="errorString">The message to write.</param>
    ''' <param name="left">Left location to start</param>
    ''' <param name="top">Top location to start</param>
    ''' <remarks></remarks>
    Private Sub DisplayError(ByVal errorString As String, ByVal left As Integer, ByVal top As Integer)
        ' Save the original position.
        Dim origCursorPos() As Integer = {Console.CursorLeft, Console.CursorTop}

        ' Set the cursor the the starting point.
        Console.SetCursorPosition(left, top)

        ' Clear the line where the error is to be written.
        For i As Integer = 0 To Console.BufferWidth - 1
            Console.Write(" ")
        Next

        ' Set the cursor the the starting point, again.
        Console.SetCursorPosition(left, top)

        ' print the error string.
        cWrite(errorString, cError, False, , False)

        ' Reset cursor location.
        Console.SetCursorPosition(origCursorPos(0), origCursorPos(1))
    End Sub

    ''' <summary>
    ''' Writes the given character at the end of the current row where the cursor is.
    ''' </summary>
    ''' <param name="text">The character to write.</param>
    ''' <param name="foreColor">The colour of the character.</param>
    ''' <remarks></remarks>
    Private Sub cWriteEnd(ByVal text As String, ByVal foreColor As ConsoleColor)

        ' Moves the cursor to the end of the row.
        Console.SetCursorPosition(Console.BufferWidth - 2, Console.CursorTop)

        Console.ForegroundColor = foreColor

        Console.WriteLine(text)
    End Sub

    ''' <summary>
    ''' Writes the given text to the center of the current row where the cursor is.
    ''' </summary>
    ''' <param name="text">The text to write.</param>
    ''' <param name="foreColor">The color of the text.</param>
    ''' <param name="offset">The amount of units to move the already centered text to the right.</param>
    ''' <param name="newLine">Create a new line</param>
    ''' <remarks></remarks>
    Private Sub WriteCenter(ByVal text As String, Optional ByVal foreColor As ConsoleColor = ConsoleColor.Gray, Optional ByVal offset As Integer = 0, _
                        Optional ByVal newLine As Boolean = True)

        Console.ForegroundColor = foreColor
        ' half the amount of empty space.

        ' # - Empty space that is not part of the given string.

        ' <-------Buffer Width------>
        ' #######TEXT TO WRITE#######
        ' |-----| <- Half of the empty space.

        Dim halve As Integer = CInt((Console.BufferWidth - text.Length) / 2)

        ' Write the left hand empty space.
        For i As Integer = 0 To (halve - 2) + offset
            Console.Write(" ")
        Next

        ' Write the text, Which should now be in the center.
        Console.Write(text)

        If newLine = True Then
            Console.WriteLine()
        End If


    End Sub

    ''' <summary>
    ''' Returns true when the input is valid, otherwise it returns false
    ''' </summary>
    ''' <param name="input">The input to validate</param>
    ''' <param name="returnInteger">The parsed integer will be returned in this variable, if valid. Integer has to = Nothing</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidateInput(ByVal input As String, Optional ByRef invalidReason As String = "", _
                                   Optional ByRef returnInteger As Integer = 1, _
                                   Optional ByVal isOption As Boolean = True, _
                                   Optional ByRef returnDecimal As Decimal = 1D) As Boolean

        Dim isValid As Boolean = True
        Dim parsedInt As Integer
        Dim parsedDec As Decimal

        ' Informs the programmer there is an error.
        If returnInteger = Nothing And returnDecimal = Nothing Then
            cWrite("Internal Error: Can't return an integer and a decimal at the same time", cError)
        End If

        ' The character "@" is used as a delimiter in the database file.
        If input.Contains("@") Then
            isValid = False

            If isOption Then
                invalidReason = """@"" is not a valid option"
            Else
                invalidReason = "You are not allowed to use the character: ""@"""
            End If

        Else

            ' If the return integer is not nothing it means the user has not passed it as an paramater.
            If returnInteger = Nothing Then

                ' try parsing the string into an integer.
                If Integer.TryParse(input, parsedInt) Then
                    ' If it is used as an onption, i.e a list, then it should not be higher than the amount of cars.
                    If isOption Then
                        If parsedInt > CarList.Count Or parsedInt = 0 Then
                            isValid = False
                            invalidReason = """" & input & """ is not a valid option."
                        Else
                            returnInteger = parsedInt
                        End If
                    Else
                        returnInteger = parsedInt
                    End If
                Else
                    isValid = False

                    If isOption Then
                        invalidReason = """" & input & """ is not a valid option."
                    Else
                        invalidReason = """" & input & """ is not a valid number."
                    End If

                End If
            End If

            ' If it is nothing it means the user passed it in the paramater.
            If returnDecimal = Nothing Then

                ' Try parsing the string into a decimal.
                If Decimal.TryParse(input, parsedDec) Then

                    If isOption Then
                        If parsedDec > CarList.Count Or parsedDec = 0 Then
                            isValid = False
                            invalidReason = """" & input & """ is not a valid option."
                        Else
                            returnDecimal = parsedDec
                        End If
                    Else
                        returnDecimal = parsedDec
                    End If

                Else
                    isValid = False
                    If isOption Then
                        invalidReason = """" & input & """ is not a valid option."
                    Else
                        invalidReason = """" & input & """ is not a valid number."
                    End If
                End If
            End If

        End If


        Return isValid
    End Function

    ''' <summary>
    ''' Prints a string to the console. This sting can be erased using backspace. Is not affected when the cursor position is moved.
    ''' </summary>
    ''' <param name="solidWord">The word that can not be erased.</param>
    ''' <param name="content">The string that can be erased.</param>
    ''' <param name="solidColor">The color of the solid word.</param>
    ''' <param name="contentColor">The color of the erasable string.</param>
    ''' <param name="afterColor">The color of the text the user types.</param>
    ''' <param name="resetColor">Reset the color when the function ends.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function VirtualString(ByVal solidWord As String, ByVal content As String, _
                                      Optional ByVal solidColor As ConsoleColor = ConsoleColor.DarkGray, _
                                      Optional ByVal contentColor As ConsoleColor = ConsoleColor.DarkGray, _
                                      Optional ByVal afterColor As ConsoleColor = ConsoleColor.DarkGray, _
                                      Optional ByVal resetColor As Boolean = True) As String

        Dim safe As Boolean
        Dim cki As New ConsoleKeyInfo
        Dim virtualStr As String = solidWord & content

        Console.ForegroundColor = solidColor
        Console.Write(solidWord)
        Console.ForegroundColor = contentColor
        Console.Write(content)
        Console.ForegroundColor = afterColor

        cki = Console.ReadKey(True)
        While cki.Key <> ConsoleKey.Enter

            If cki.Key = ConsoleKey.Backspace Then
                ' Check if the last thing remaining is the instruction. e.g. "Brand: "
                If virtualStr = solidWord Then
                    safe = False
                Else
                    safe = True
                End If

                If safe Then
                    ' Remove the last character from the console and the virtual string
                    virtualStr = virtualStr.Remove(virtualStr.Length - 1, 1)
                    MoveCursorBack()
                    Console.Write(" ")
                    MoveCursorBack()
                End If

            Else
                ' Add a character to the console and string
                virtualStr &= cki.KeyChar
                Console.Write(cki.KeyChar)
            End If

            cki = Console.ReadKey(True)
        End While

        If resetColor = True Then
            Console.ResetColor()
        End If

        Console.WriteLine()

        ' Remove the solid word from the returned string.
        virtualStr = virtualStr.Remove(0, solidWord.Length)

        ' Remove whitespace from the sides of the string.
        virtualStr = Trim(virtualStr)

        Return virtualStr
    End Function

    ''' <summary>
    ''' Writes a string to the console with an array of colours.
    ''' </summary>
    ''' <param name="stringToWrite">The string to write. E.G "RED|BLUE|GREEN" will be printed as (red)RED(blue)BLUE(green)GREEN</param>
    ''' <param name="colorArray">The array of colours to apply to the string when writing.</param>
    ''' <param name="delimiter">The character/string to split the colours with.</param>
    ''' <param name="newLine">Write a line terminator</param>
    ''' <param name="afterColor">The foreground colour to use after the string is printed.</param>
    ''' <param name="resetColor"></param>
    ''' <remarks></remarks>
    Private Sub cWriteArray(ByVal stringToWrite As String, _
                                    Optional ByVal colorArray() As ConsoleColor = Nothing, _
                                    Optional ByVal delimiter As String = "|", _
                                    Optional ByVal newLine As Boolean = True, _
                                    Optional ByVal afterColor As ConsoleColor = ConsoleColor.Gray, _
                                    Optional ByVal resetColor As Boolean = False)

        ' Split the given string into an array using the given deliminator
        Dim stringArray() = Split(stringToWrite, delimiter)

        ' If no colour array is given create a new array matching the length of the
        ' string array. Setting colours in it to gray.
        If colorArray.GetUpperBound(0) = -1 Then
            ReDim colorArray(stringArray.GetUpperBound(0))

            For i As Integer = 0 To stringArray.GetUpperBound(0)
                colorArray(i) = ConsoleColor.Gray
            Next

        End If

        For i As Integer = 0 To stringArray.GetUpperBound(0)
            ' Set the foreground color
            Console.ForegroundColor = colorArray(i)
            ' print the part of the string matching the color
            Console.Write(stringArray(i))
        Next

        If newLine = True Then
            Console.WriteLine()
        End If

        Console.ForegroundColor = afterColor

        If resetColor = True Then
            Console.ResetColor()
        End If

    End Sub

    ''' <summary>
    ''' Writes the given string using the given color.
    ''' </summary>
    ''' <param name="stringToWrite">The string to write</param>
    ''' <param name="foreColor">The forecolor to use</param>
    ''' <param name="newLine">Create a newline</param>
    ''' <param name="afterColor">Color to set the foreground to after the string is printed.</param>
    ''' <param name="resetColor">Reset color when done</param>
    ''' <remarks></remarks>
    Private Sub cWrite(ByVal stringToWrite As String, ByVal foreColor As ConsoleColor, _
                              Optional ByVal newLine As Boolean = True, _
                              Optional ByVal afterColor As ConsoleColor = ConsoleColor.Gray, _
                              Optional ByVal resetColor As Boolean = False)

        Console.ForegroundColor = foreColor

        If newLine = True Then
            Console.WriteLine(stringToWrite)
        Else
            Console.Write(stringToWrite)
        End If

        Console.ForegroundColor = afterColor

        If resetColor = True Then
            Console.ResetColor()
        End If

    End Sub

    ''' <summary>
    ''' Moves the cursor 1 position back. Moves 1 row up if at the start of the column
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MoveCursorBack()

        If Console.CursorLeft = 0 Then
            If Console.CursorTop > 0 Then
                Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1) ' 1 row up, start at the end
            End If
        Else
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop) ' 1 space back
        End If

    End Sub

#End Region

    ' Text formatting functions
#Region "Text Functions"
    ''' <summary>
    ''' Returns the given number as a string with commas.
    ''' </summary>
    ''' <param name="theNumber">The number to format.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AC(ByVal theNumber As Single) As String

        Return theNumber.ToString("N")

    End Function


    ''' <summary>
    ''' Adds arguments into a string. E.G "This {0} a {1}", {"is", "string"} will return as "This is a string"
    ''' </summary>
    ''' <param name="theString">The string in which to insert the arguments</param>
    ''' <param name="theArgs">The arguments to insert.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ArgsInStr(ByVal theString As String, ByVal theArgs() As String) As String
        Dim result As String = theString

        ' Replace all instances of {i} with the appropriate argument.
        For i As Integer = 0 To theArgs.GetUpperBound(0)
            result = Replace(result, "{" & i & "}", theArgs(i))
        Next

        Return result
    End Function

#End Region

    ' Functions that handle numbers
#Region "Number Functions"

    ''' <summary>
    ''' Returns the Min(0), Max(1), MinID(2), MaxID(3), sum(4), avg(5) of a set of numbers
    ''' </summary>
    ''' <param name="arrayOfNums">The array of numbers to evaluate</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Private Function GetMinMax(ByVal arrayOfNums() As Decimal) As Decimal()
        Dim result(5) As Decimal
        Dim highest, highestID, lowest, lowestID, sum, avg As Decimal

        ' Assume the first number is the lowest.
        lowest = arrayOfNums(0)

        For i As Integer = 0 To CarList.Count - 1

            ' if the current known highest number is lowesr than arrayOfNums(i)
            ' set arrayOfNums(i) as the known highest number.
            If highest < arrayOfNums(i) Then
                highest = arrayOfNums(i)
                highestID = i
            End If

            ' if the current known lowest number is higher than arrayOfNums(i)
            ' set arrayOfNums(i) as the known lowest number.
            If lowest > arrayOfNums(i) Then
                lowest = arrayOfNums(i)
                lowestID = i
            End If

            ' Calculate the sum of the numbers
            sum += arrayOfNums(i)
        Next

        ' Calculate the average of the numbers.
        avg = sum / (arrayOfNums.GetUpperBound(0) + 1)

        result = {lowest, highest, lowestID, highestID, sum, avg}
        Return result
    End Function

    ''' <summary>
    ''' Returns the specified value of all cars in an array
    ''' </summary>
    ''' <param name="numberID">The values to return</param>
    ''' <returns>BaseCost</returns>
    ''' <remarks></remarks>
    Private Function ExtractNumbers(ByVal numberID As String) As Decimal()

        Dim result(CarList.Count - 1) As Decimal

        Select Case numberID
            Case "BaseCost"

                ' Add the value of all the cars to the array
                For i As Integer = 0 To CarList.Count - 1
                    result(i) = CarList.Item(i).BaseCost
                Next

            Case "Profit"
                For i As Integer = 0 To CarList.Count - 1
                    result(i) = CarList.Item(i).Profit
                Next

            Case "Income"
                For i As Integer = 0 To CarList.Count - 1
                    result(i) = CarList.Item(i).Income
                Next
        End Select

        Return result
    End Function

    ''' <summary>
    ''' Returns the standard deviation of a set of numbers
    ''' </summary>
    ''' <param name="numbers">The array of numbers to evaluate.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSD(ByVal numbers() As Decimal) As String

        ' http://en.wikipedia.org/wiki/Standard_deviation#Basic_examples

        Dim result As String = "Numbers in database are too large!"
        Dim minMax() As Decimal = GetMinMax(numbers)
        Dim variationSum As Decimal

        Try
            ' To calculate the population standard deviation, first compute the difference of each data point from the mean, and square the result of each:
            For i As Integer = 0 To numbers.GetUpperBound(0)
                variationSum += CDec(Math.Pow(numbers(i) - minMax(5), 2)) '(5) = average
            Next

            result = CStr(Math.Round(Math.Sqrt(variationSum / (numbers.GetUpperBound(0) + 1)), 2))

        Catch ex1 As Exception
            'cWrite("There was an error calculating the standard deviation:", cError)
            'cWrite(ex1.Message, cError)
        End Try

        Return result
    End Function

#End Region

    ' Functions that handle databases
#Region "Database Functions"

    ''' <summary>
    ''' Loads the names of the databases from the file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadDatabaseList()

        If My.Computer.FileSystem.FileExists("Databases.txt") Then
            Dim reader As New StreamReader("Databases.txt")
            Dim textLine As String
            Dim alreadyExists As Boolean = False

            While reader.Peek <> -1
                textLine = reader.ReadLine

                ' Check if the database name already exists.
                ' If the database list count = 0 then there is nothing to compare it with, and will throw an error.
                If DatabaseList.Count <> 0 Then

                    For i As Integer = 0 To DatabaseList.Count - 1
                        If DatabaseList.Item(i).ToLower = textLine.ToLower Then
                            alreadyExists = True
                            Exit For
                        End If
                    Next

                End If

                ' If the user decided to edit the file and manually create an invalid database we delete it.
                If textLine.Length > 32 Then
                    alreadyExists = True
                End If

                ' Add the database name, if it doesn't already exists.
                If alreadyExists = False Then
                    DatabaseList.Add(textLine)
                End If

                alreadyExists = False

            End While

            reader.Close()

            ' Save the new list to fil.e
            SaveDatabaseList()
        End If
    End Sub

    ''' <summary>
    ''' Save the DatabaseList to file. Replaces current file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveDatabaseList()
        Dim writer As New StreamWriter("Databases.txt", False)

        ' Write each database name to the file.
        For i As Integer = 0 To DatabaseList.Count - 1
            writer.WriteLine(DatabaseList.Item(i))
        Next

        writer.Close()
    End Sub

    ''' <summary>
    ''' Creates a database with the given name
    ''' </summary>
    ''' <param name="databaseName"></param>
    ''' <remarks></remarks>
    Private Sub CreateDatabase(ByVal databaseName As String)

        ' Add the database to the list.
        DatabaseList.Add(databaseName)

        ' Save the list with the new database.
        SaveDatabaseList()

        ' Open the new database.
        OpenDatabase(DatabaseList.Count - 1)

    End Sub

    ''' <summary>
    ''' Deletes the database with the given index
    ''' </summary>
    ''' <param name="databaseIndex">The index of the database in DatabaseList</param>
    ''' <remarks></remarks>
    Private Sub DeleteDatabase(ByVal databaseIndex As Integer)
        Dim databaseName As String = DatabaseList.Item(databaseIndex)

        ' Delete the text file where the cars are stored
        If My.Computer.FileSystem.FileExists("Databases\" & databaseName & ".txt") Then
            My.Computer.FileSystem.DeleteFile("Databases\" & databaseName & ".txt")
        End If

        ' Remove the database if it is not the default
        If databaseName <> "Default" Then
            DatabaseList.RemoveAt(databaseIndex)
            SaveDatabaseList()
        End If

        ' If it is the current database being deleted, load the default database.
        If databaseName = currentDatabase Then
            currentDatabase = "Default"
            SaveLastDatabase()
            LoadCarsfromFile()
        End If

    End Sub

    ''' <summary>
    ''' Opens the database with the given index
    ''' </summary>
    ''' <param name="databaseIndex">The index of the database in DatabaseList</param>
    ''' <remarks></remarks>
    Private Sub OpenDatabase(ByVal databaseIndex As Integer)

        ' Sets the current database to the given database.
        currentDatabase = DatabaseList.Item(databaseIndex)

        ' Load the cars from the newly opened database file.
        LoadCarsfromFile()

        ' Save the newly opened database name to the preferences file. To be restored on startup.
        SaveLastDatabase()

    End Sub

    ''' <summary>
    ''' Opens the database with the given name
    ''' </summary>
    ''' <param name="databaseName">The name of the database to open.</param>
    ''' <remarks></remarks>
    Private Sub OpenDatabase(ByVal databaseName As String)

        ' Open the database with the given name if it exists, else open the default database.
        If DatabaseList.Contains(databaseName) Then
            currentDatabase = databaseName
        Else
            ' The Default database can not be deleted, so it is safe to open it.
            currentDatabase = "Default"
        End If

        ' Load the cars from the newly opened database file.
        LoadCarsfromFile()

        ' Save the newly opened database name to the preferences file. To be restored on startup.
        SaveLastDatabase()

    End Sub

    ''' <summary>
    ''' Prints the list of Databases
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrintDatabases()
        Dim tmpString As String

        ' Prints "[1] Database Name"
        For i As Integer = 0 To DatabaseList.Count - 1
            tmpString = ArgsInStr("    [/{0}/]/ {1}", {CStr(i + 1), DatabaseList.Item(i)})
            cWriteArray(tmpString, {cBracket, cOption, cBracket, cCar}, "/", True)
        Next

    End Sub

    ''' <summary>
    ''' Prints the current database to the console, inside a coloured box.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrintCurrentDatabase(ByVal left As Integer, ByVal top As Integer)

        ' Write the Title and top of the box.
        Console.SetCursorPosition(left, top)
        cWriteArray("+-------- /Current Database/ --------+", {cDeco, cHeading, cDeco}, "/", False)

        ' Write the database name.
        ' Since the database name cannot be longer than 32 characters the box size is static
        ' and the name will never overflow.
        Console.SetCursorPosition(left + 2, top + 1)
        cWrite(currentDatabase, cNum, False)

        ' Write the left decoration
        Console.SetCursorPosition(left, top + 1)
        cWrite("|", cDeco, False)

        ' Write the right decoration.
        Console.SetCursorPosition(left + 35, top + 1)
        cWrite("|", cDeco, False)

        ' Write the bottom decorations.
        Console.SetCursorPosition(left, top + 2)
        cWrite("+----------------------------------+", cDeco, False)
    End Sub

    ''' <summary>
    ''' Saves the current database to the preferences file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveLastDatabase()
        Dim writer As New StreamWriter("Preferences.txt", False)

        writer.WriteLine(currentDatabase)

        writer.Close()
    End Sub

    ''' <summary>
    ''' Loads the last used database from the preferences file.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetLastDatabase() As String
        Dim result As String = "Default"

        ' if the file exists read the first line.
        If My.Computer.FileSystem.FileExists("Preferences.txt") Then
            Dim reader As New StreamReader("Preferences.txt")
            result = reader.ReadLine
            reader.Close()
        End If

        ' Default is returned when the file does not exist.
        Return result
    End Function

    ''' <summary>
    ''' Returns the index of the given database's name
    ''' </summary>
    ''' <param name="databaseName">The name of the database to find the index of.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDatabaseIndex(ByVal databaseName As String) As Integer
        Dim result As Integer = 0

        ' Go through each database name in the list and if it matches the given name, return the index.
        For i As Integer = 0 To DatabaseList.Count - 1
            If DatabaseList.Item(i) = databaseName Then
                result = i
                Exit For
            End If
        Next

        Return result
    End Function

    ''' <summary>
    ''' This method Loads the databases from the file. It needs to be called on startup.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitializeDatabases()
        ' Load databases from the databases file
        LoadDatabaseList()

        ' Load the last opened database from the preferences file.
        currentDatabase = GetLastDatabase()

        ' Add the current database to to list if it does not exist.
        If DatabaseList.Contains(currentDatabase) = False Then
            CreateDatabase(currentDatabase)
        End If

        ' If the current database's length is longer than 32 then delete it.
        If currentDatabase.Length > 33 Then
            DeleteDatabase(GetDatabaseIndex(currentDatabase))
        End If

        ' If there are no databases create the Default database.
        If DatabaseList.Count = 0 Then
            CreateDatabase("Default")
        End If
    End Sub
#End Region

End Module
