Imports System.IO

Module Module1

    Public Class Car
        Public Brand As String
        Public Make As String
        Public Model As String
        Public Year As Integer
        Public BaseCost As Integer
        Public Markup As Single
    End Class

    Dim ExitCommanded As Boolean = False
    Dim CarList As New List(Of Car)

    Sub Main()
        LoadCarsfromFile()

        DisplayMenu()

        While ExitCommanded = False
            HandleCommand(Console.ReadLine)
        End While

        ' EndOfProgram()
    End Sub

    Private Sub DisplayMenu()
        Console.Clear()
        Console.WriteLine("Welcome to Fun With Cars. (Evert Geldenhuys)")
        Console.WriteLine()
        Console.WriteLine("Select your option from the below menu:")
        Console.WriteLine("    (A) Add a car")
        Console.WriteLine("    (B) Edit a car")
        Console.WriteLine("    (C) View Car Details")
        Console.WriteLine("    (D) Display car statistics")
        Console.WriteLine("    (E) Remove a car")
        Console.WriteLine("    (Q) Quit")
        Console.Write("Selection: ")

    End Sub

    Private Sub AddCar()
        Dim tmpCar As New Car

        Console.WriteLine("Entering new car details...")
        Console.Write("Brand: ")
        tmpCar.Brand = Console.ReadLine()
        Console.Write("Make: ")
        tmpCar.Make = Console.ReadLine()
        Console.Write("Model: ")
        tmpCar.Model = Console.ReadLine()
        Console.Write("Year: ")
        tmpCar.Year = CInt(Console.ReadLine())
        Console.Write("Base Cost: ")
        tmpCar.BaseCost = CInt(Console.ReadLine())
        Console.Write("Dealer Markup percentage (i.e. 50 for 50%): ")
        tmpCar.Markup = CSng(Console.ReadLine())

        SaveCarToFile(tmpCar)
        CarList.Add(tmpCar)

        Console.WriteLine("Car Added!")
        Console.ReadLine()

    End Sub

    Private Sub HandleCommand(ByVal command As String)
        Console.Clear()

        Select Case command.ToLower

            Case "a"
                AddCar()

            Case "b"
                EditCar()

            Case "c"
                ViewCarDetails()

            Case "d"
                DisplayStatistics()

            Case "e"
                RemoveCarScreen()

            Case "q"
                ExitCommanded = True

            Case Else
                Console.Clear()
        End Select
        DisplayMenu()
    End Sub

    Private Sub DisplayStatistics()
        Dim lowestVal, lowestValID, highestVal, highestValID, avgVal, sumVal As Single
        Dim lowestIncome, lowIncomeID, highestIncome, highIncomeId, avgIncome, sumIncome As Single

        lowestVal = CarList.Item(0).BaseCost
        highestVal = 0
        sumVal = 0

        For i As Integer = 0 To CarList.Count - 1
            If highestVal < CarList.Item(i).BaseCost Then
                highestVal = CarList.Item(i).BaseCost
                highestValID = i
            End If

            If lowestVal > CarList.Item(i).BaseCost Then
                lowestVal = CarList.Item(i).BaseCost
                lowestValID = i
            End If

            sumVal += CarList.Item(i).BaseCost
        Next
        avgVal = CInt(sumVal / CarList.Count)

        lowestIncome = CarList.Item(0).BaseCost * CarList.Item(0).Markup / 100

        For i As Integer = 0 To CarList.Count - 1
            If highestIncome < CarList.Item(i).BaseCost * CarList.Item(i).Markup / 100 Then
                highestIncome = CarList.Item(i).BaseCost * CarList.Item(i).Markup / 100
                highIncomeId = i
            End If

            If lowestIncome > CarList.Item(i).BaseCost * CarList.Item(i).Markup / 100 Then
                lowestIncome = CarList.Item(i).BaseCost * CarList.Item(i).Markup / 100
                lowIncomeID = i
            End If

            sumIncome += CarList.Item(i).BaseCost * CarList.Item(i).Markup / 100
        Next

        avgIncome = CInt(sumIncome / CarList.Count)

        Console.WriteLine("Full statistics for Fun With Cars Database.")
        Console.WriteLine()
        Console.WriteLine(ArgsInStr("Lowest car base cost ({0}): ${1}", {CarInfo(CInt(lowestValID)), CStr(lowestVal)}))
        Console.WriteLine(ArgsInStr("highest car base cost ({0}): ${1}", {CarInfo(CInt(highestValID)), CStr(highestVal)}))
        Console.WriteLine(ArgsInStr("Average car base cost: ${0}", {CStr(avgVal)}))
        Console.WriteLine()
        Console.WriteLine(ArgsInStr("Lowest car income ({0}): ${1}", {CarInfo(CInt(lowIncomeID)), CStr(lowestIncome)}))
        Console.WriteLine(ArgsInStr("highest car income ({0}): ${1}", {CarInfo(CInt(highIncomeId)), CStr(highestIncome)}))
        Console.WriteLine(ArgsInStr("Average car income: ${0}", {CStr(avgIncome)}))

        Console.ReadLine()

    End Sub

    Private Function CarInfo(ByVal carIndex As Integer) As String
        Dim result As String = ""

        result = ArgsInStr("{0}, {1} {2} ({3})", {CarList.Item(carIndex).Brand, CarList.Item(carIndex).Model, CarList.Item(carIndex).Make, CStr(CarList.Item(carIndex).Year)})
        Return result
    End Function

    Private Sub RemoveCarScreen()
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

    Private Sub DeleteCar(ByVal realIndex As Integer)
        CarList.RemoveAt(realIndex)
        SaveListToFile()
    End Sub

    Private Sub EditCar()
        Dim carCount As Integer = CarList.Count
        Dim carMin As Integer = 1

        If carCount = 0 Then
            carMin = 0
        End If

        Console.WriteLine(ArgsInStr("Using the number of the car, select which car you would like to edit ({0}-{1}).", {CStr(carMin), CStr(carCount)}))
        Console.WriteLine()

        PrintCarList()

        Console.Write("Selection : ")

        Dim carIndex As Integer = CInt(Console.ReadLine())
        Dim realIndex As Integer = carIndex - 1

        Console.Clear()
        Console.WriteLine("Editing car #" & carIndex & "...")

        Console.Write("Brand: ")
        CarList.Item(realIndex).Brand = Console.ReadLine()
        Console.Write("Make: ")
        CarList.Item(realIndex).Make = Console.ReadLine()
        Console.Write("Model: ")
        CarList.Item(realIndex).Model = Console.ReadLine()
        Console.Write("Year: ")
        CarList.Item(realIndex).Year = CInt(Console.ReadLine())
        Console.Write("Base Cost: ")
        CarList.Item(realIndex).BaseCost = CInt(Console.ReadLine())
        Console.Write("Dealer Markup percentage (i.e. 50 for 50%): ")
        CarList.Item(realIndex).Markup = CSng(Console.ReadLine())

        Console.WriteLine()
        SaveListToFile()
        Console.WriteLine("Editing Complete!")

        Console.ReadLine()

    End Sub

    Private Sub PrintCarList()
        For i As Integer = 0 To CarList.Count - 1
            Console.WriteLine(ArgsInStr("    ({0}) {1}, {2} {3} ({4})", {CStr(i + 1), CarList.Item(i).Brand, CarList.Item(i).Make, CarList.Item(i).Model, _
                                                                             CStr(CarList.Item(i).Year)}))
        Next
    End Sub

    Private Sub ViewCarDetails()
        Dim carCount As Integer = CarList.Count
        Dim carMin As Integer = 1

        If carCount = 0 Then
            carMin = 0
        End If

        Console.WriteLine(ArgsInStr("Using the number of the car, select which car you would like to edit ({0}-{1}).", {CStr(carMin), CStr(carCount)}))
        Console.WriteLine()

        PrintCarList()

        Console.Write("Selection : ")
        Dim input As String = Console.ReadLine()
        If input <> "" Then
            Console.Clear()
            DisplayCarDetails(CInt(input))
        End If

    End Sub

    Private Sub DisplayCarDetails(ByVal carIndex As Integer)
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

    Private Function ArgsInStr(ByVal theString As String, ByVal theArgs() As String) As String
        Dim result As String = theString

        For i As Integer = 0 To theArgs.GetUpperBound(0)
            result = Replace(result, "{" & i & "}", theArgs(i))
        Next

        Return result
    End Function

    Private Sub SaveCarToFile(ByVal theCar As Car)
        Dim writer As New StreamWriter("cars.txt", True)
        writer.WriteLine(ArgsInStr("{0}@{1}@{2}@{3}@{4}@{5}", {theCar.Brand, theCar.Make, theCar.Model, CStr(theCar.Year), CStr(theCar.BaseCost), CStr(theCar.Markup)}))
        writer.Close()

    End Sub

    Private Sub SaveListToFile()
        Dim writer As New StreamWriter("cars.txt", False)
        writer.Write("")
        writer.Close()

        For i As Integer = 0 To CarList.Count - 1
            SaveCarToFile(CarList.Item(i))
        Next

    End Sub

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

                CarList.Add(tmpCar)
                tmpCar = Nothing
                tmpCar = New Car
            End While

            reader.Close()
        End If
    End Sub

    Private Sub EndOfProgram()
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)
    End Sub
End Module
