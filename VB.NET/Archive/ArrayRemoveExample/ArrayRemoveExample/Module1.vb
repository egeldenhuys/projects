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

    Dim cars(9) As Car

    Sub Main()

        ' Fill the cars array with random data.
        For i As Integer = 0 To 9
            cars(i) = New Car
            cars(i).Brand = "Brand " & i
            cars(i).Make = "Make " & i
            cars(i).Model = "Model " & i
            cars(i).Year = i
            cars(i).BaseCost = i
            cars(i).Markup = i
        Next

        ' Print the cars to screen
        For i As Integer = 0 To cars.GetUpperBound(0)

            Console.WriteLine("{0}, {1}, {2}, {3}, {4})", CStr(i + 1), cars(i).Brand, cars(i).Make, cars(i).Model, CStr(cars(i).Year))
        Next

        ' Remove the car with the index of 5 in the cars array, from the cars array.
        RemoveCarFromArray(5)

        ' Print the cars to the screen, this time there should be one less car.
        For i As Integer = 0 To cars.GetUpperBound(0) - 1

            Console.WriteLine("{0}, {1}, {2}, {3}, {4})", CStr(i + 1), cars(i).Brand, cars(i).Make, cars(i).Model, CStr(cars(i).Year))
        Next

        Console.ReadLine()


    End Sub

    Private Sub RemoveCarFromArray(carIndex As Integer)

        ' Clear the car from the original array
        cars(carIndex) = Nothing

        ' Create the tmp array
        Dim tmpArray(9) As Car

        ' Create a variable to count how many cars we found. (Not Nothing)
        Dim foundCounter As Integer = 0

        ' Fill the tmp array with car objects. Otherwise adding a car would fail.
        For i As Integer = 0 To 9
            tmpArray(i) = New Car
        Next

        ' Go through the carArray and add all non Empty cars to the tmp array.
        For i As Integer = 0 To 9
            If Not cars(i) Is Nothing Then
                ' Add the car to the tmp array
                tmpArray(foundCounter) = cars(i)

                ' Increment the foundCounter
                foundCounter += 1
            End If
        Next

        ' Assign the tmpArray to the cars array.
        cars = tmpArray

        ' You might need to decrease a carCounter variable.
    End Sub

End Module
