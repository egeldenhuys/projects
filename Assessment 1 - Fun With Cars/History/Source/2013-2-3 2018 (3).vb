Imports System.IO

Module Module1

    Public Class Car
        Public Brand As String
        Public Make As String
        Public Model As String
        Public Year As Integer
        Public BaseCost As Single
        Public Markup As Single
        Public Profit As Single

    End Class

    Dim ExitCommanded As Boolean = False
    Dim CarList As New List(Of Car)

    ' Menu colours
    Dim cUser, cOption, cDeco, cBracket, cDesc, cHeading, cInput, cError, cInfo, cInstruction, cCar As ConsoleColor

    Sub Main()
        Console.Title = "Fun With Cars Evert 3"
        SetupColors()
        LoadCarsfromFile()
        DisplayMenu()

        While ExitCommanded = False

            HandleCommand(Console.ReadLine)
        End While

        ' EndOfProgram()
    End Sub

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
    End Sub

    Private Sub HandleCommand(ByVal command As String)
        Console.Clear()

        Select Case command.ToLower

            Case "a"
                ScreenAddCar()

            Case "e"
                ScreenEditCar()

            Case "v"
                ScreenViewCarDetails()

            Case "s"
                ScreenDisplayStatistics()

            Case "r"
                ScreenRemoveCar()

            Case "q"
                ExitCommanded = True

            Case Else
                DisplayMenu()
        End Select

        DisplayMenu()
    End Sub

#Region "Screens"
    Private Sub DisplayMenu()
        Console.Clear()
        WriteHeader("Fun With Cars")

        Console.WriteLine()
        cWriteArray("+----------- /Options/ ------------+", {cDeco, cHeading, cDeco}, "/")
        cWriteArray("| /[/A/]/ - Add a new car/            |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/E/]/ - Edit a car/               |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/V/]/ - View car details/         |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/S/]/ - Display car statistics/   |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/R/]/ - Remove a car/             |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("| /[/Q/]/ - Quit/                     |", {cDeco, cBracket, cOption, cBracket, cDesc, cDeco}, "/")
        cWriteArray("+--------------------------------+", {cDeco})
        cWrite("> ", cInput, False)
        Console.ForegroundColor = cUser

    End Sub

    Private Sub ScreenAddCar()
        Dim tmpCar As New Car
        Dim input As String = "A"
        Dim tmpNum As Single

        WriteHeader("Add a new car...")
        Console.WriteLine()

        cWrite("Please enter the required information below.", cInfo)
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
                If InputIsValid(input) Then

                    Select Case i
                        Case 1
                            tmpCar.Brand = input
                        Case 2
                            tmpCar.Make = input
                        Case 3
                            tmpCar.Model = input
                    End Select
                Else
                    cWrite("You are not allowed to use the character ""@""", cError)
                    Console.ReadKey(True)
                    Console.Clear()
                    ScreenAddCar()
                    Exit Sub
                End If

            Else
                If InputIsValid(input, True, tmpNum) Then

                    Select Case i
                        Case 4
                            tmpCar.Year = CInt(tmpNum)
                        Case 5
                            tmpCar.BaseCost = tmpNum
                        Case 6
                            tmpCar.Markup = tmpNum
                    End Select
                Else
                    cWrite("""" & input & """ is not a valid number.", cError)
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
        Dim invalidInput As Boolean = False

        WriteHeader("Edit a car...")
        Console.WriteLine()
        cWrite("Select a car from below to edit.", cInstruction)
        Console.WriteLine()
        PrintCarList()

        cWrite("> ", cInput, False, cUser)
        input = Console.ReadLine

        If input = "" Then
            Exit Sub
        End If
        Dim result As Integer

        If Integer.TryParse(input, result) Then
            input = CStr(result)
            If result > CarList.Count Or result = 0 Then
                invalidInput = True
            End If
        Else
            invalidInput = True
        End If

        If invalidInput Then
            cWrite("""" & input & """ is not a valid option", cError)
            Console.ReadKey()
            Console.Clear()
            ScreenEditCar()
            Exit Sub
        End If

        Console.Clear()
        WriteHeader("Editing car " & input)
        Console.ReadKey(True)
    End Sub

    Private Sub ScreenDisplayStatistics()


    End Sub

    Private Sub ScreenRemoveCar()


    End Sub

    
    Private Sub ScreenViewCarDetails()


    End Sub

    Private Sub ScreenDisplayCarDetails(ByVal carIndex As Integer)



    End Sub


#End Region

#Region "Car Operations"

    ''' <summary>
    ''' Adds the given car to the list and also saves it to file.
    ''' </summary>
    ''' <param name="carToAdd"></param>
    ''' <remarks></remarks>
    Private Sub AddCar(ByVal carToAdd As Car)
        CarList.Add(carToAdd)
        SaveCarToFile(carToAdd)
    End Sub

    ''' <summary>
    ''' Edit Car information
    ''' </summary>
    ''' <param name="carIndex">The index of the car to edit</param>
    ''' <param name="newCar">The car object to replace the old one</param>
    ''' <remarks></remarks>
    Private Sub EditCar(ByVal carIndex As Integer, newCar As Car)
        CarList.Item(carIndex) = newCar

    End Sub

    ''' <summary>
    ''' Remove the given car index from the array and save the new list to file
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
        Dim writer As New StreamWriter("cars.txt", True)
        writer.WriteLine(ArgsInStr("{0}@{1}@{2}@{3}@{4}@{5}", {theCar.Brand, theCar.Make, theCar.Model, CStr(theCar.Year), CStr(theCar.BaseCost), CStr(theCar.Markup)}))
        writer.Close()

    End Sub

    ''' <summary>
    ''' Saves to carList to file. Overwrites the current file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveListToFile()
        Dim writer As New StreamWriter("cars.txt", False)
        writer.Write("")
        writer.Close()

        For i As Integer = 0 To CarList.Count - 1
            SaveCarToFile(CarList.Item(i))
        Next

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
        If My.Computer.FileSystem.FileExists("cars.txt") Then
            Dim reader As New StreamReader("cars.txt")

            Dim subStrings() As String
            Dim tmpCar As New Car
            Dim textLine As String

            While reader.Peek <> -1
                textLine = reader.ReadLine

                subStrings = Split(textLine, "@")

                tmpCar.Brand = subStrings(0)
                tmpCar.Make = subStrings(1)
                tmpCar.Model = subStrings(2)
                tmpCar.Year = CInt(subStrings(3))
                tmpCar.BaseCost = CInt(subStrings(4))
                tmpCar.Markup = CInt(subStrings(5))

                tmpCar.Profit = tmpCar.BaseCost * tmpCar.Markup / 100

                CarList.Add(tmpCar)
                tmpCar = Nothing
                tmpCar = New Car
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



#Region "Text Operations"

    Private Function CarToArray(ByVal theCar As Car) As String()
        Dim result(0) As String

        For i As Integer = 0 To 5
            Select Case i
                Case 0
                    If theCar.Brand <> Nothing Then
                        ReDim Preserve result(i)
                        result(i) = theCar.Brand
                    End If

                Case 1
                    If theCar.Make <> Nothing Then
                        ReDim Preserve result(i)
                        result(i) = theCar.Make
                    End If
                Case 2
                    If theCar.Model <> Nothing Then
                        ReDim Preserve result(i)
                        result(i) = theCar.Model
                    End If
                Case 3
                    If theCar.Year <> Nothing Then
                        ReDim Preserve result(i)
                        result(i) = CStr(theCar.Year)
                    End If
                Case 4
                    If theCar.BaseCost <> Nothing Then
                        ReDim Preserve result(i)
                        result(i) = CStr(theCar.BaseCost)
                    End If
                Case 5
                    If theCar.Markup <> Nothing Then
                        ReDim Preserve result(i)
                        result(i) = CStr(theCar.Markup)
                    End If
            End Select
        Next

        Return result
    End Function

    Private Function ArrayToCar(ByVal carArray() As String) As Car
        Dim result As New Car

        For i As Integer = 0 To carArray.GetUpperBound(0)
            Select Case i
                Case 0
                    result.Brand = carArray(i)
                Case 1
                    result.Make = carArray(i)
                Case 2
                    result.Model = carArray(i)
                Case 3
                    result.Year = CInt(carArray(i))
                Case 4
                    result.BaseCost = CSng(carArray(i))
                Case 5
                    result.Markup = CSng(carArray(i))
            End Select
        Next

        Return result
    End Function

    Private Function InputIsValid(ByVal text As String, _
                                  Optional ByVal isSingle As Boolean = False, _
                                  Optional ByRef returnValue As Single = 0.0F) As Boolean

        Dim valid As Boolean = True
        Dim value As Single

        If isSingle = True Then
            If Single.TryParse(text, value) Then
                returnValue = value
            Else
                valid = False
            End If
        Else
            If text.Contains("@") Then
                valid = False
            End If
        End If

        Return valid
    End Function

    Private Sub WriteHeader(ByVal heading As String)
        cWrite("+-----------------------------------------------------------------------------+", cDeco)
        cWrite("|", cDeco, False)
        WriteCenter(heading, cHeading, -2, False)
        cWriteEnd("|", cDeco)
        cWrite("+-----------------------------------------------------------------------------+", cDeco)
    End Sub

    Private Sub ClearError()
        Dim origPos(1) As Integer
        Console.ReadKey(False)

        origPos = {Console.CursorLeft, Console.CursorTop}
        Console.SetCursorPosition(0, Console.CursorTop + 1)
        Console.Write("--")

        Console.SetCursorPosition(origPos(0), origPos(1))

    End Sub

    Private Sub DisplayError(ByVal errorText As String, ByVal foreColor As ConsoleColor)
        Dim origPos(1) As Integer
        Dim origColor As ConsoleColor = Console.ForegroundColor

        origPos = {Console.CursorLeft, Console.CursorTop}
        Console.SetCursorPosition(0, Console.CursorTop + 1)
        Console.ForegroundColor = foreColor
        Console.Write(errorText)

        Console.SetCursorPosition(origPos(0), origPos(1))
        Console.ForegroundColor = origColor

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

    Private Sub FillRow(ByVal charToFill As Char, Optional ByVal foreColor As ConsoleColor = ConsoleColor.Gray)

        Console.ForegroundColor = foreColor

        For i As Integer = 0 To Console.BufferWidth - 1
            Console.Write(charToFill)
        Next

        ' Console.WriteLine()
        Console.ResetColor()


    End Sub

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

    Private Function AC(ByVal theNumber As Single) As String
        Dim result As String
        result = theNumber.ToString("N")
        Return result
    End Function

    Private Sub MoveCursorBack()
        If Console.CursorLeft = 0 Then
            If Console.CursorTop > 0 Then
                Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1) ' 1 row up, start at the end
            End If
        Else
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop) ' 1 space back
        End If
    End Sub

    Private Function ArgsInStr(ByVal theString As String, ByVal theArgs() As String) As String
        Dim result As String = theString

        For i As Integer = 0 To theArgs.GetUpperBound(0)
            result = Replace(result, "{" & i & "}", theArgs(i))
        Next

        Return result
    End Function

    ''' <summary>
    ''' Returns the Min(0), Max(1), MinID(2), MaxID(3), sum(4), avg(5) of a set of numbers
    ''' </summary>
    ''' <param name="arrayOfNums"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Private Function GetMinMax(ByVal arrayOfNums() As Single) As Single()
        Dim result(5) As Single
        Dim highest, highestID, lowest, lowestID, sum, avg As Single

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

        If arrayOfNums.GetUpperBound(0) + 1 <> 1 Then
            avg = sum / arrayOfNums.GetUpperBound(0) + 1
        Else
            avg = sum
        End If


        result = {lowest, highest, lowestID, highestID, sum, avg}
        Return result
    End Function

    Private Function NewVirtualString(ByVal solidWord As String, ByVal content As String, _
                                      Optional ByVal solidColor As ConsoleColor = ConsoleColor.DarkGray, _
                                      Optional ByVal contentColor As ConsoleColor = ConsoleColor.DarkGray, _
                                      Optional ByVal afterColor As ConsoleColor = ConsoleColor.DarkGray, _
                                      Optional ByVal resetColor As Boolean = True) As String
        Dim safe As Boolean
        Dim cki As New ConsoleKeyInfo
        Dim virtualString As String = solidWord & content

        Console.ForegroundColor = solidColor
        Console.Write(solidWord)
        Console.ForegroundColor = contentColor
        Console.Write(content)
        Console.ForegroundColor = afterColor

        cki = Console.ReadKey(True)
        While cki.Key <> ConsoleKey.Enter

            If cki.Key = ConsoleKey.Backspace Then
                ' Check if the last thing remaining is the instruction. e.g. "Brand: "
                If virtualString = solidWord Then
                    safe = False
                Else
                    safe = True
                End If

                If safe Then
                    ' Remove the last character from the console and the virtual string
                    virtualString = virtualString.Remove(virtualString.Length - 1, 1)
                    MoveCursorBack()
                    Console.Write(" ")
                    MoveCursorBack()
                End If

            Else
                ' Add a character to the console and string
                virtualString &= cki.KeyChar
                Console.Write(cki.KeyChar)
            End If

            cki = Console.ReadKey(True)
        End While

        If resetColor = True Then
            Console.ResetColor()
        End If
        Console.WriteLine()
        virtualString = virtualString.Remove(0, solidWord.Length)
        virtualString = Trim(virtualString)

        Return virtualString
    End Function

#End Region

#Region "Functions"

    Private Function ExtractNumbers(ByVal numberID As String) As Single()
        Dim result(CarList.Count - 1) As Single

        Select Case numberID
            Case "BaseCost"

                For i As Integer = 0 To CarList.Count - 1
                    result(i) = CarList.Item(i).BaseCost
                Next

            Case "Profit"
                For i As Integer = 0 To CarList.Count - 1
                    result(i) = CarList.Item(i).Profit
                Next

        End Select

        Return result
    End Function
    Private Sub EndOfProgram()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)
    End Sub

#End Region
End Module
