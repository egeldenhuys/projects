Module Module1

    Sub Main()
        While True
            Dim input(5) As Double

            Console.WriteLine("Point 1")
            Console.Write("x1: ")
            input(0) = Console.ReadLine
            Console.Write("y2: ")
            input(1) = Console.ReadLine

            Console.WriteLine("Point 2")
            Console.Write("x1: ")
            input(2) = Console.ReadLine
            Console.Write("y2: ")
            input(3) = Console.ReadLine

            Console.WriteLine("Point 3")
            Console.Write("x1: ")
            input(4) = Console.ReadLine
            Console.Write("y2: ")
            input(5) = Console.ReadLine
            
            Console.WriteLine("Point 3 sits on the line: " & StraightLine({input(0), input(1)}, {input(2), input(3)}, {input(4), input(5)}))
            Console.ReadKey()
            Console.Clear()

        End While
    End Sub

    ''' <summary>
    ''' This function checks if p3 lies on the line created by p1 and p2.
    ''' </summary>
    ''' <param name="p1">First point of the line</param>
    ''' <param name="p2">Second point of the line</param>
    ''' <param name="p3">The point to be checked</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function StraightLine(ByVal p1() As Double, ByVal p2() As Double, ByVal p3() As Double) As Boolean

        ' Find the gradient of the line p1, p2
        Dim m As Double = (p2(1) - p1(1)) / (p2(0) - p1(0))

        ' Find the y-intercept
        Dim b As Double = p1(1) - (m * p1(0))

        ' Check if the given point (p3) sits on the line

        If p3(1) = m * p3(0) + b Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
