Imports System.IO

Module Module1

    Public Class Car
        Public Brand As String
        Public Make As String
        Public Model As String
        Public Year As Integer
        Public BaseCost As Integer
        Public Markup As Integer
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
        tmpCar.Markup = CInt(Console.ReadLine())

        SaveCarToFile(tmpCar)
        CarList.Add(tmpCar)

        Console.WriteLine("Car Added!")
        Console.ReadLine()

    End Sub

    Private Sub HandleCommand(ByVal command As String)

        Select Case command.ToLower

            Case "a"
                Console.Clear()
                AddCar()
            Case "b"

            Case "c"
                Console.Clear()
                ViewCarDetails()
            Case "d"

            Case "e"

            Case "q"
                ExitCommanded = True

            Case Else
                Console.Clear()
        End Select

        DisplayMenu()


    End Sub
    Private Sub ViewCarDetails()
        Dim carCount As Integer = CarList.Count
        Dim carMin As Integer = 1

        If carCount = 0 Then
            carMin = 0
        End If

        Console.WriteLine("Using the number of the car, select which car you would like to edit ({0}-{1}).", carMin, carCount)
        Console.WriteLine()

        For i As Integer = 0 To CarList.Count - 1
            Console.WriteLine("    (" & i + 1 & ") " & CarList.Item(i).Brand & ", " & CarList.Item(i).Make & " " & CarList.Item(i).Model _
                              & " (" & CarList.Item(i).Year & ")")
        Next

        Console.Write("Selection :")
        Console.ReadLine()

    End Sub

    Private Sub SaveCarToFile(ByVal theCar As Car)
        Dim writer As New StreamWriter("cars.txt", True)
        writer.WriteLine(theCar.Brand & "@" & theCar.Make & "@" & theCar.Model & "@" & theCar.Year & "@" & theCar.BaseCost & "@" & theCar.Markup)
        writer.Close()

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
