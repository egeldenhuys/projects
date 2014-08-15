Module Module1

    Public Class Car
        Public Name As String
        Public Year As Integer
        Public Value As Integer
    End Class

    Sub Main()
        Dim newCar As New Car
        Dim carArray(9) As Car

        For i As Integer = 0 To carArray.GetUpperBound(0)
            carArray(i) = New Car
            carArray(i).Name = CStr(i)
            carArray(i).Year = i
            carArray(i).Value = i * 5
        Next

        For i As Integer = 0 To carArray.GetUpperBound(0)
            Console.WriteLine("------")
            DisplayCarStuff(carArray(i))
        Next

        newCar.Name = "John"
        newCar.Year = 2012
        newCar.Value = 5000

        DisplayCarStuff(newCar)

        Console.WriteLine("Press any key to continue...")
        Console.ReadKey(True)


    End Sub

    Private Sub DisplayCarStuff(ByVal theCar As Car)
        Console.WriteLine("Name: " & theCar.Name)
        Console.WriteLine("Year: " & theCar.Year)
        Console.WriteLine("Value: " & theCar.Value)

    End Sub

End Module
