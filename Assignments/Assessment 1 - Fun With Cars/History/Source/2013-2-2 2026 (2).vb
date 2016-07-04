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
    Dim cInstruction, cInput, cCar, cOption, cError, cUser, cHeading, cEdit, cMenu, cInfo, cNumber As ConsoleColor

    Sub Main()

        SetupColors()

        LoadCarsfromFile()

        DisplayMenu()

        While ExitCommanded = False
            HandleCommand(Console.ReadLine)
        End While

        ' EndOfProgram()
    End Sub

    Private Sub SetupColors()
        cInstruction = ConsoleColor.Yellow ' Lines that ask the user to do something. e.g "Select your option from the menu below"
        cInput = ConsoleColor.Green ' Lines that indicate the user to enter information. e.g "Brand:", "Selection"
        cCar = ConsoleColor.Gray ' Car lines. E.G "Holden, Make Model (Year)"
        cOption = ConsoleColor.Cyan ' Options. E.G. "(x) Delete car" where x is the cololoured option
        cError = ConsoleColor.Gray ' Errors. E.G. "That is not a number", "You can not use that character", "No cars found"
        cUser = ConsoleColor.Cyan ' Text that the user types. E.G. "1", "Holden", "2013"
        cHeading = ConsoleColor.Cyan ' Headings. E.G "Welcome to fun with cars!", "Car data base statistics.
        cEdit = ConsoleColor.Gray ' Color of text that can be edited
        cMenu = ConsoleColor.Magenta ' Menu elements. E.G. "(A) Edit a car"
        cInfo = ConsoleColor.White ' E.G "car has been added"
        cNumber = ConsoleColor.Green ' "$2000"'
    End Sub

    Private Sub HandleCommand(ByVal command As String)
        Console.Clear()

        Select Case command.ToLower

            Case "a"
                ScreenAddCar()

            Case "b"
                ScreenEditCar()

            Case "c"
                ScreenViewCarDetails()

            Case "d"
                ScreenDisplayStatistics()

            Case "e"
                ScreenRemoveCar()

            Case "q"
                ExitCommanded = True

            Case Else
                Console.Clear()
        End Select

        DisplayMenu()


    End Sub

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

        result = ArgsInStr("{0}, {1} {2} ({3})", {CarList.Item(carIndex).Brand, CarList.Item(carIndex).Model, CarList.Item(carIndex).Make, CStr(CarList.Item(carIndex).Year)})
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
            Console.WriteLine(ArgsInStr("    ({0}) {1}, {2} {3} ({4})", {CStr(i + 1), CarList.Item(i).Brand, CarList.Item(i).Make, CarList.Item(i).Model, _
                                                                             CStr(CarList.Item(i).Year)}))
        Next
    End Sub

#End Region

#Region "Screens"
    Private Sub DisplayMenu()
        Console.Clear()
        Console.WriteLine("+-----------------------------------------------------------------------------+")
        WriteCenter("Fun With Cars")
        Console.WriteLine("+-----------------------------------------------------------------------------+")
        Console.WriteLine()
        Console.WriteLine("+-----+----------")
        Console.WriteLine("| [A] - Add a new car")
        Console.WriteLine("| [E] - Edit a car")
        Console.WriteLine("| [V] - View car details")
        Console.WriteLine("| [D] - Display car statistics")
        Console.WriteLine("| [R] - Remove a car")
        Console.WriteLine("| [Q] - Quit")
    End Sub

    Private Sub ScreenDisplayStatistics()


        cWrite("Full statistics for Fun With Cars Database.", cHeading)
        Console.WriteLine()

        If CarList.Count <> 0 Then
            Dim tmpArr() As Single
            Dim MinMax() As Single

            tmpArr = ExtractNumbers("BaseCost")
            MinMax = GetMinMax(tmpArr)

            cWriteArray(ArgsInStr("Lowest car base cost (|{0}|): |${1}", {GetCarInfo(CInt(MinMax(2))), CStr(AC(MinMax(0)))}), {cInfo, cUser, cInfo, cNumber})
            cWriteArray(ArgsInStr("highest car base cost (|{0}|): |${1}", {GetCarInfo(CInt(MinMax(3))), CStr(AC(MinMax(1)))}), {cInfo, cUser, cInfo, cNumber})
            cWriteArray(ArgsInStr("Average car base cost: |${0}", {CStr(MinMax(5))}), {cInfo, cNumber})
            Console.WriteLine()

            tmpArr = ExtractNumbers("Profit")
            MinMax = GetMinMax(tmpArr)

            Console.WriteLine(ArgsInStr("Lowest car profit ({0}): ${1}", {GetCarInfo(CInt(MinMax(2))), CStr(MinMax(0))}))
            Console.WriteLine(ArgsInStr("highest car profit ({0}): ${1}", {GetCarInfo(CInt(MinMax(3))), CStr(MinMax(1))}))
            Console.WriteLine(ArgsInStr("Average car profit: ${0}", {CStr(MinMax(5))}))

        Else
            cWrite("There are no cars in the database. Add a car first.", cError)
        End If

        Console.ReadLine()

    End Sub

    Private Sub ScreenRemoveCar()
        Dim carCount As Integer = CarList.Count
        Dim carMin As Integer = 1

        If carCount = 0 Then
            carMin = 0
        End If

        Console.WriteLine(ArgsInStr("Using the number of the car, select which car you would like to Remove ({0}-{1}).", {CStr(carMin), CStr(carCount)}))
        Console.WriteLine()

        PrintCarList()

        Console.Write("Selection : ")
        Dim selection As String = Console.ReadLine()

        If selection <> "" Then
            DeleteCar(CInt(selection) - 1)
            Console.WriteLine("Car #{0} has been deleted", {selection})
            Console.ReadLine()
        End If


    End Sub

    Private Sub ScreenEditCar()

        Console.WriteLine(ArgsInStr("Using the number of the car, select which car you would like to edit (1-{0}).", {CStr(CarList.Count)}))
        Console.WriteLine()

        PrintCarList()

        Console.Write("Selection : ")

        Dim input As String = Console.ReadLine
        If input <> "" Then


            Dim carIndex As Integer = CInt(Console.ReadLine())
            Dim realIndex As Integer = carIndex - 1

            Console.Clear()
            Console.WriteLine("Editing car #" & carIndex & "...")

            CarList.Item(realIndex).Brand = NewVirtualString("Brand: ", CarList.Item(realIndex).Brand, cInput, cEdit, cUser)
            CarList.Item(realIndex).Make = NewVirtualString("Make: ", CarList.Item(realIndex).Make, cInput, cEdit, cUser)
            CarList.Item(realIndex).Model = NewVirtualString("Model: ", CarList.Item(realIndex).Model, cInput, cEdit, cUser)
            CarList.Item(realIndex).Year = CInt(NewVirtualString("Year: ", CStr((CarList.Item(realIndex).Year)), cInput, cEdit, cUser))
            CarList.Item(realIndex).BaseCost = CInt(NewVirtualString("Base Cost: ", CStr(CarList.Item(realIndex).BaseCost), cInput, cEdit, cUser))
            CarList.Item(realIndex).Markup = CSng(NewVirtualString("Dealer Markup percentage (i.e. 50 for 50%): ", CStr(CarList.Item(realIndex).Markup), cInput, cEdit, cUser))

            Console.WriteLine()

            SaveListToFile()

            Console.WriteLine("Editing Complete!")
            Console.ReadLine()
        End If
    End Sub

    Private Sub ScreenViewCarDetails()
        Dim carCount As Integer = CarList.Count
        Dim carMin As Integer = 1

        If carCount = 0 Then
            carMin = 0
        End If

        Console.WriteLine(ArgsInStr("Using the number of the car, select which car you would like to view (1-{0}).", {CStr(CarList.Count)}))
        Console.WriteLine()

        PrintCarList()

        Console.Write("Selection : ")
        Dim input As String = Console.ReadLine()
        If input <> "" Then
            Console.Clear()
            ScreenDisplayCarDetails(CInt(input))
        End If

    End Sub

    Private Sub ScreenDisplayCarDetails(ByVal carIndex As Integer)
        Dim realIndex As Integer = carIndex - 1

        Console.WriteLine("Displaying details of car #" & carIndex)
        Console.WriteLine("Brand: " & CarList.Item(realIndex).Brand)
        Console.WriteLine("Make: " & CarList.Item(realIndex).Make)
        Console.WriteLine("Model: " & CarList.Item(realIndex).Model)
        Console.WriteLine("Year: " & CarList.Item(realIndex).Year)
        Console.WriteLine("Base Cost: " & CarList.Item(realIndex).BaseCost)
        Console.WriteLine("Markup Percentage: " & CarList.Item(realIndex).Markup)

        Console.WriteLine()
        Dim fullCost As Single = CarList.Item(realIndex).BaseCost * (CarList.Item(realIndex).Markup / 100) + CarList.Item(realIndex).BaseCost
        Dim costIncrement As Single = CarList.Item(realIndex).BaseCost * CarList.Item(realIndex).Markup / 100

        Console.WriteLine("Full Cost: $" & fullCost)
        Console.WriteLine("Cost of increment: $" & costIncrement)
        Console.WriteLine("Age of car: " & Date.UtcNow.Year - CarList.Item(realIndex).Year)

        Console.WriteLine()

        Console.Write("How many cars have been sold? ")
        Dim carsSold As Integer = CInt(Console.ReadLine())

        Console.WriteLine("Full income for car: $" & CSng(fullCost * carsSold))
        Console.WriteLine("Full profit for car: $" & CSng(costIncrement * carsSold))
        Console.ReadLine()


    End Sub

    Private Sub ScreenAddCar()
        Dim tmpCar As New Car
        Dim input As String

        cWrite("Entering new car details...", cHeading)
        cWrite("Brand: ", cInput, False, cUser)

        input = Console.ReadLine
        If input <> "" Then
            tmpCar.Brand = input
            cWrite("Make: ", cInput, False, cUser)
            tmpCar.Make = Console.ReadLine()
            cWrite("Model: ", cInput, False, cUser)
            tmpCar.Model = Console.ReadLine()
            cWrite("Year: ", cInput, False, cUser)
            tmpCar.Year = CInt(Console.ReadLine())
            cWrite("Base Cost: ", cInput, False, cUser)
            tmpCar.BaseCost = CInt(Console.ReadLine())
            cWrite("Dealer Markup percentage (i.e. 50 for 50%): ", cInput, False, cUser)
            tmpCar.Markup = CSng(Console.ReadLine())

            tmpCar.Profit = tmpCar.BaseCost * tmpCar.Markup / 100

            SaveCarToFile(tmpCar)
            CarList.Add(tmpCar)

            cWrite("Car Added!", cInfo)
            Console.ReadLine()
        End If

    End Sub

#End Region

#Region "Functions"

    Private Sub WriteCenter(ByVal text As String, Optional ByVal foreColor As ConsoleColor = ConsoleColor.Gray)

        Console.ForegroundColor = forecolor
        Dim halve As Integer = CInt((Console.BufferWidth - text.Length) / 2)

        For i As Integer = 0 To halve - 2
            Console.Write(" ")
        Next

        Console.Write(text)
        Console.WriteLine()

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
                                    ByVal colorArray() As ConsoleColor, _
                                    Optional ByVal newLine As Boolean = True, _
                                    Optional ByVal afterColor As ConsoleColor = ConsoleColor.Gray, _
                                    Optional ByVal resetColor As Boolean = False)

        Dim stringArray() = Split(stringToWrite, "|")

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

    Private Sub EndOfProgram()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)
    End Sub

#End Region
End Module
