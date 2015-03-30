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
        InitializeDatabases()

        Console.Title = "Fun With Cars Evert 3"
        Console.WriteLine("Loading cars from database...")

        SetupColors()
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

        ' EndOfProgram()
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
    ''' Calls the appropriate screen based on the command.
    ''' </summary>
    ''' <param name="command">The command the user entered</param>
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

    ' Windows. E.G Main Menu, Edit a car
#Region "Screens"

    Private Sub DisplayMenu(Optional ByVal errorString As String = Nothing)
        Console.Clear()

        WriteHeader("Fun With Cars")

        If errorString <> Nothing Then
            cWrite(errorString, cError, True) ' Display the error.
        Else
            Console.WriteLine()
        End If

        Dim OptionsCursorPos() As Integer = {Console.CursorLeft, Console.CursorTop} ' Cursor position when the first line of the options box is written
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

        Dim finalPos() As Integer = {Console.CursorLeft, Console.CursorTop} ' input location

        DisplayCarsCount(OptionsCursorPos(0) + 40, OptionsCursorPos(1)) ' Print the box 40 units to the right of the options box
        PrintCurrentDatabase(OptionsCursorPos(0) + 40, OptionsCursorPos(1) + 4)

        Console.SetCursorPosition(finalPos(0), finalPos(1)) ' Put the cursor infront of the "> " where the use should type.
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
        cWrite(GetCarInfo(CarList.Count - 1), cCar, True)
        Console.ReadKey(True)
    End Sub

    Private Sub ScreenEditCar()
        Dim input As String
        Dim invalidReason As String = ""
        Dim carIndex As Integer = 0

        WriteHeader("Edit a car...")
        Console.WriteLine()
        cWrite("Choose a car from the list below to edit", cInstruction)
        Console.WriteLine()

        PrintCarList()

        If CarList.Count > 22 Then
            cWrite("Choose a car from the list above to edit", cInstruction)
        End If

        cWrite("> ", cInput, False, cUser)
        input = Console.ReadLine

        If input = "" Then
            Exit Sub
        End If

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
            ' Gather and display the correct information
            Select Case i
                Case 1
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

            Else ' Integers and singles
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
    ''' <param name="carIndex">The index of the car to bo viewed.</param>
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

    Private Sub ScreenDisplayStatistics()
            WriteHeader("Statistics for car database")
            Console.WriteLine()

            If CarList.Count = 0 Then
                cWrite("Add a car first to view statistics.", cInstruction)
                Console.ReadKey(True)
                Exit Sub
        End If

            Dim tmpString As String = ""
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

    Private Sub ScreenManageDatabase()
        WriteHeader("Manage Database")
        Console.WriteLine()

        cWriteArray("+--------------- /Options/ ----------------+", {cDeco, cHeading, cDeco}, "/")
        cWriteArray("| /[/L/]/ - Load an existing database/        |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/N/]/ - Create a new database/            |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/D/]/ - Delete a database/                |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        'cWriteArray("| /[/R/]/ - Reload the current database/      |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
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

    Private Sub ScreenNewDatabase()
        WriteHeader("Create a new database")

        Console.WriteLine()

        cWrite("Database Name: ", cInput, False, cUser)

        Dim input As String = Console.ReadLine
        Dim invalidChars() As String = {"\", "/", ":", "?", """", "*", "<", ">", "|"}

        If input = "" Then
            Exit Sub
        End If

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

        For Each element In invalidChars
            If input.Contains(element) Then
                valid = False
                Exit For
            End If
        Next

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

        If Integer.TryParse(input, returnInt) Then
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
            ScreenDeleteDatabase()

        Else
            DeleteDatabase(returnInt - 1)
        End If

    End Sub


    ''' <summary>
    ''' This function prints and handles the options when an error occurs when loading the cars from file
    ''' </summary>
    ''' <param name="lineNumber">The line number when the error occured.</param>
    ''' <remarks></remarks>
    Private Sub ScreenProcessingError(ByVal lineNumber As Integer)
        Console.Clear()

        Dim input As String = ""

        cWrite("There has been an error processing the car on line " & lineNumber & " in the database.", cError)
        Console.WriteLine()
        cWrite("Please chose an action from the menu below:", cInstruction)
        Console.WriteLine()

        cWriteArray("+----------- /Options/ ------------+", {cDeco, cHeading, cDeco}, "/")
        cWriteArray("| /[/R/]/ - Remove the invalid car/   |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/D/]/ - Delete the database/      |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/Q/]/ - Quit/                     |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("+--------------------------------+", {cDeco})
        Console.WriteLine()

        cWrite("> ", cInput, False, cUser)

        input = Console.ReadLine()

        If input = "" Then
            ScreenProcessingError(lineNumber)
            Exit Sub
        End If

        Select Case input.ToLower
            Case "r"

                If My.Computer.FileSystem.FileExists("Databases\" & currentDatabase & ".txt") Then
                    Dim reader As New StreamReader("Databases\" & currentDatabase & ".txt")
                    Dim tmpFileContents As String = ""
                    Dim curLineNum As Integer = 1
                    Dim textLine As String

                    While reader.Peek <> -1
                        textLine = reader.ReadLine

                        If curLineNum <> lineNumber And textLine <> "" Then
                            tmpFileContents &= textLine & Environment.NewLine
                        End If

                        curLineNum += 1
                    End While

                    reader.Close()
                    Dim writer As New StreamWriter("Databases\" & currentDatabase & ".txt", False)
                    writer.Write(tmpFileContents)
                    writer.Close()

                    cWrite("The invalid car has been removed.", cInfo)

                    Console.ReadKey(True)
                    CarList.Clear()
                    LoadCarsfromFile()
                End If

            Case "d"
                If My.Computer.FileSystem.FileExists("Databases\" & currentDatabase & ".txt") Then
                    My.Computer.FileSystem.DeleteFile("Databases\" & currentDatabase & ".txt")
                    cWrite("The database has been deleted.", cInfo)
                    Console.ReadKey(True)
                End If
                CarList.Clear()

            Case "q"
                ExitCommanded = True

        End Select
    End Sub

#End Region

    ' Functions related to cars. The base of the program.
#Region "Car Operations"

    ''' <summary>
    ''' Adds the given car to the carList and also saves it to file.
    ''' </summary>
    ''' <param name="carToAdd"></param>
    ''' <remarks></remarks>
    Private Sub AddCar(ByVal carToAdd As Car)
        CarList.Add(carToAdd)
        SaveListToFile()
        'SaveCarToFile(carToAdd)
    End Sub

    ''' <summary>
    ''' Remove the given car index from the array and saves the new list to file.
    ''' </summary>
    ''' <param name="carIndex"></param>
    ''' <remarks></remarks>
    Private Sub DeleteCar(ByVal carIndex As Integer)
        CarList.RemoveAt(carIndex)
        SaveListToFile()
    End Sub

    ''' <summary>
    ''' Saves the given car to file in the correct format
    ''' </summary>
    ''' <param name="theCar"></param>
    ''' <remarks></remarks>
    Private Sub SaveCarToFile(ByVal theCar As Car)

        If My.Computer.FileSystem.DirectoryExists("Databases\") = False Then
            My.Computer.FileSystem.CreateDirectory("Databases\")
        End If

        Dim writer As New StreamWriter("Databases\" & currentDatabase & ".txt", True)
        writer.WriteLine(ArgsInStr("{0}@{1}@{2}@{3}@{4}@{5}", {theCar.Brand, theCar.Make, theCar.Model, CStr(theCar.Year), CStr(theCar.BaseCost), CStr(theCar.Markup)}))
        writer.Close()

    End Sub

    ''' <summary>
    ''' Saves to carList to file. Overwrites the current file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveListToFile()

        If My.Computer.FileSystem.FileExists("Databases\" & currentDatabase & ".txt") Then
            My.Computer.FileSystem.DeleteFile("Databases\" & currentDatabase & ".txt")
        End If

        Dim tmpArray(CarList.Count) As String

        For i As Integer = 0 To CarList.Count - 1
            tmpArray(i) = ArgsInStr("{0}@{1}@{2}@{3}@{4}@{5}", {CarList.Item(i).Brand, CarList.Item(i).Make, _
                                                                CarList.Item(i).Model, CStr(CarList.Item(i).Year), _
                                                                CStr(CarList.Item(i).BaseCost), CStr(CarList.Item(i).Markup)}) & Environment.NewLine
        Next

        If My.Computer.FileSystem.DirectoryExists("Databases\") = False Then
            My.Computer.FileSystem.CreateDirectory("Databases\")
        End If

        Dim writer As New StreamWriter("Databases\" & currentDatabase & ".txt", False)
        For Each element In tmpArray
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
        Dim result As String = ""

        result = ArgsInStr("{0}, {1} {2} ({3})", {CarList.Item(carIndex).Brand, CarList.Item(carIndex).Make, CarList.Item(carIndex).Model, CStr(CarList.Item(carIndex).Year)})
        Return result
    End Function

    ''' <summary>
    ''' Populates the CarList with the cars from the file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCarsfromFile()
        CarList.Clear()
        If My.Computer.FileSystem.FileExists("Databases\" & currentDatabase & ".txt") Then
            Dim reader As New StreamReader("Databases\" & currentDatabase & ".txt")

            Dim subStrings() As String
            Dim tmpCar As New Car
            Dim textLine As String
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


                    If Integer.TryParse(subStrings(3), returnInt) Then
                        tmpCar.Year = returnInt
                    Else
                        reader.Close()
                        ScreenProcessingError(lineNumber)
                        Exit While
                    End If

                    If Decimal.TryParse(subStrings(4), returnDec) Then
                        tmpCar.BaseCost = returnDec
                    Else
                        reader.Close()
                        ScreenProcessingError(lineNumber)
                        Exit While
                    End If

                    If Decimal.TryParse(subStrings(5), returnDec) Then
                        tmpCar.Markup = returnDec
                    Else
                        reader.Close()
                        ScreenProcessingError(lineNumber)
                        Exit While
                    End If

                    tmpCar.Profit = tmpCar.BaseCost * tmpCar.Markup / 100
                    tmpCar.Income = (tmpCar.BaseCost * tmpCar.Markup / 100) + tmpCar.BaseCost

                    CarList.Add(tmpCar)
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

    ' Functions that prints specific text to the console.
#Region "User Interface Elements"

    Private Sub DisplayCarsCount(ByVal left As Integer, ByVal top As Integer)
        Dim leftBuffer As Integer
        leftBuffer = CInt(left + 11 - (CarList.Count.ToString).Length / 2)


        Console.SetCursorPosition(left, top)
        cWriteArray("+- /Cars In Database /-+", {cDeco, cHeading, cDeco}, "/", False)

        Console.SetCursorPosition(leftBuffer, top + 1)
        cWrite(CStr(CarList.Count), cNum, False)
        Console.SetCursorPosition(left, top + 1)
        cWrite("|", cDeco, False)
        Console.SetCursorPosition(left + 21, top + 1)
        cWrite("|", cDeco, False)

        Console.SetCursorPosition(left, top + 2)
        cWrite("+--------------------+", cDeco, False)
    End Sub

    Private Sub WriteHeader(ByVal heading As String)
        cWrite("+-----------------------------------------------------------------------------+", cDeco)
        cWrite("|", cDeco, False)
        WriteCenter(heading, cHeading, -2, False)
        cWriteEnd("|", cDeco)
        cWrite("+-----------------------------------------------------------------------------+", cDeco)
    End Sub

    Private Sub DisplayError(ByVal errorString As String, ByVal left As Integer, ByVal top As Integer)
        Dim origCursorPos() As Integer = {Console.CursorLeft, Console.CursorTop}

        Console.SetCursorPosition(left, top)

        For i As Integer = 0 To Console.BufferWidth - 1
            Console.Write(" ")
        Next

        Console.SetCursorPosition(left, top)

        cWrite(errorString, cError, False, , False)

        Console.SetCursorPosition(origCursorPos(0), origCursorPos(1))
    End Sub

    Private Sub cWriteEnd(ByVal text As String, ByVal foreColor As ConsoleColor)
        Console.SetCursorPosition(Console.BufferWidth - 2, Console.CursorTop)
        Console.ForegroundColor = foreColor
        Console.WriteLine(text)
    End Sub

    Private Sub WriteCenter(ByVal text As String, Optional ByVal foreColor As ConsoleColor = ConsoleColor.Gray, Optional ByVal offset As Integer = 0, _
                        Optional ByVal newLine As Boolean = True)


        Console.ForegroundColor = foreColor
        Dim halve As Integer = CInt((Console.BufferWidth - text.Length) / 2)

        For i As Integer = 0 To (halve - 2) + offset
            Console.Write(" ")
        Next

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

        If returnInteger = Nothing And returnDecimal = Nothing Then
            cWrite("Internal Error: Can't return an integer and a decimal at the same time", cError)
        End If

        If input.Contains("@") Then
            isValid = False

            If isOption Then
                invalidReason = """@"" is not a valid option"
            Else
                invalidReason = "You are not allowed to use the character: ""@"""
            End If

        Else

            If returnInteger = Nothing Then
                If Integer.TryParse(input, parsedInt) Then
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

            If returnDecimal = Nothing Then
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
        virtualStr = virtualStr.Remove(0, solidWord.Length)
        virtualStr = Trim(virtualStr)

        Return virtualStr
    End Function

    Private Sub cWriteArray(ByVal stringToWrite As String, _
                                    Optional ByVal colorArray() As ConsoleColor = Nothing, _
                                    Optional ByVal delimiter As String = "|", _
                                    Optional ByVal newLine As Boolean = True, _
                                    Optional ByVal afterColor As ConsoleColor = ConsoleColor.Gray, _
                                    Optional ByVal resetColor As Boolean = False)

        Dim stringArray() = Split(stringToWrite, delimiter)

        If colorArray.GetUpperBound(0) = -1 Then
            ReDim colorArray(stringArray.GetUpperBound(0))

            For i As Integer = 0 To stringArray.GetUpperBound(0)
                colorArray(i) = ConsoleColor.Gray
            Next

        End If

        For i As Integer = 0 To stringArray.GetUpperBound(0)
            Console.ForegroundColor = colorArray(i)
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

    Private Function AC(ByVal theNumber As Single) As String
        Dim result As String
        result = theNumber.ToString("N")
        Return result
    End Function

    Private Function ArgsInStr(ByVal theString As String, ByVal theArgs() As String) As String
        Dim result As String = theString

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
    ''' <param name="arrayOfNums"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Private Function GetMinMax(ByVal arrayOfNums() As Decimal) As Decimal()
        Dim result(5) As Decimal
        Dim highest, highestID, lowest, lowestID, sum, avg As Decimal

        lowest = arrayOfNums(0)

        For i As Integer = 0 To CarList.Count - 1
            If highest < arrayOfNums(i) Then
                highest = arrayOfNums(i)
                highestID = i
            End If

            If lowest > arrayOfNums(i) Then
                lowest = arrayOfNums(i)
                lowestID = i
            End If

            sum += arrayOfNums(i)
        Next


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
    ''' Gets the standard deviation of a set of numbers
    ''' </summary>
    ''' <param name="numbers"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetSD(ByVal numbers() As Decimal) As String
        Dim result As String = "Numbers in database are too large!"
        Dim minMax() As Decimal = GetMinMax(numbers)
        Dim variationSum As Decimal

        Try
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

                If DatabaseList.Count <> 0 Then

                    For i As Integer = 0 To DatabaseList.Count - 1
                        If DatabaseList.Item(i).ToLower = textLine.ToLower Then
                            alreadyExists = True
                            Exit For
                        End If
                    Next

                End If

                If textLine.Length > 32 Then
                    alreadyExists = True
                End If

                If alreadyExists = False Then
                    DatabaseList.Add(textLine)
                End If

                alreadyExists = False

            End While

            reader.Close()
            SaveDatabaseList()
        End If
    End Sub

    ''' <summary>
    ''' Save the DatabaseList to file
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveDatabaseList()
        Dim writer As New StreamWriter("Databases.txt", False)

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
        DatabaseList.Add(databaseName)
        SaveDatabaseList()
        ' Open the latest database.
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
        currentDatabase = DatabaseList.Item(databaseIndex)
        LoadCarsfromFile()
        SaveLastDatabase()

    End Sub

    ''' <summary>
    ''' Opens the database with the given name
    ''' </summary>
    ''' <param name="databaseName">The name of the database to open.</param>
    ''' <remarks></remarks>
    Private Sub OpenDatabase(ByVal databaseName As String)

        If DatabaseList.Contains(databaseName) Then
            currentDatabase = databaseName
        Else
            currentDatabase = "Default"
        End If

        LoadCarsfromFile()
        SaveLastDatabase()

    End Sub

    ''' <summary>
    ''' Prints the list of databases
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrintDatabases()
        Dim tmpString As String

        For i As Integer = 0 To DatabaseList.Count - 1
            tmpString = ArgsInStr("    [/{0}/]/ {1}", {CStr(i + 1), DatabaseList.Item(i)})
            cWriteArray(tmpString, {cBracket, cOption, cBracket, cCar}, "/", True)
        Next

    End Sub

    ''' <summary>
    ''' Prints the current database to the console, under the header.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrintCurrentDatabase(ByVal left As Integer, ByVal top As Integer)

        Console.SetCursorPosition(left, top)
        cWriteArray("+-------- /Current Database/ --------+", {cDeco, cHeading, cDeco}, "/", False)

        Console.SetCursorPosition(left + 2, top + 1)
        cWrite(currentDatabase, cNum, False)
        Console.SetCursorPosition(left, top + 1)
        cWrite("|", cDeco, False)
        Console.SetCursorPosition(left + 35, top + 1)
        cWrite("|", cDeco, False)

        Console.SetCursorPosition(left, top + 2)
        cWrite("+----------------------------------+", cDeco, False)
    End Sub

    Private Sub SaveLastDatabase()
        Dim writer As New StreamWriter("Preferences.txt", False)

        writer.WriteLine(currentDatabase)

        writer.Close()
    End Sub

    Private Function GetLastDatabase() As String
        Dim result As String = "Default"

        If My.Computer.FileSystem.FileExists("Preferences.txt") Then
            Dim reader As New StreamReader("Preferences.txt")
            result = reader.ReadLine
            reader.Close()
        End If

        Return result
    End Function

    Private Function GetDatabaseIndex(ByVal databaseName As String) As Integer
        Dim result As Integer

        For i As Integer = 0 To DatabaseList.Count - 1
            If DatabaseList.Item(i) = databaseName Then
                result = i
                Exit For
            End If
        Next

        Return result
    End Function

    Private Sub InitializeDatabases()
        ' Load databases
        LoadDatabaseList()
        currentDatabase = GetLastDatabase()

        ' Add the current database to to list if it does not exist.
        If DatabaseList.Contains(currentDatabase) = False Then
            CreateDatabase(currentDatabase)
        End If

        If currentDatabase.Length > 32 Then
            DeleteDatabase(GetDatabaseIndex(currentDatabase))
        End If

        If DatabaseList.Count = 0 Then
            CreateDatabase("Default")
        End If
    End Sub
    '=== Reason ===
    'Adds the ability to catagorize cars.
    'Example: "Holdens", "Dad's Cars", "Favourites", "Bubbles"


    '=== How it will work ===
    'The names of all databases will be stored in a text file named "Databases"
    'and also a Global List.

    'The database named "Default" can not be deleted.

    'When the user tries to load a database that does not have a file it is created.


    '=== Functions Needed (7)===
    '* Display current active database
    '	The current database is displayed below the header.

    '* Append database name to file
    '	Saves the name of the database to the text file

    '* Save database list to file
    '	Saves the entire list fo file. Used for when a database has been
    '	deleted.

    '* Print list of databases
    '	Writes the name of all databases in the text file

    '* Load Database (by id)
    '	The database with the given id in the list is loaded.

    '* Delete Database (by id)
    '	database it is removed from the list. If it is the current
    '	database the Default database is loaded instead.

    '* Create Database (by name)
    '	When the user creates a new database it is appended to the list and file, if it does not already exist.
    '	it is then loaded immediately.

    '=== Current Limitations ===
    ' Statistics can only be displayed for the current database

#End Region

End Module
