Module Module1

    Sub Main()
        Console.SetBufferSize(80, 25)

        Dim strip As New StatusStrip(0, 24, 50, ConsoleColor.Gray, ConsoleColor.Red)

        While True
            strip.SetText(Console.ReadLine)

        End While


        Console.ReadKey()

    End Sub

    Public Class StatusStrip

        Dim text As String
        Dim pos(2) As Integer
        Public foreColor As ConsoleColor
        Public backColor As ConsoleColor

        Public Sub New(ByVal left1 As Integer, _
                       ByVal top As Integer, _
                       ByVal left2 As Integer, _
                       ByVal bg As ConsoleColor, _
                       ByVal fg As ConsoleColor)

            pos(0) = left1
            pos(1) = top
            pos(2) = left2

            foreColor = fg
            backColor = bg

            SetText("")

        End Sub

        Public Sub SetText(ByVal str As String)

            text = str
            Dim prePos() As Integer = GetCursorPos()
            Dim preCol() As ConsoleColor = GetColors()

            Console.SetCursorPosition(pos(0), pos(1))

            Console.BackgroundColor = backColor
            Console.ForegroundColor = foreColor

            Dim out As String = ""

            For i As Integer = 1 To pos(2)
                out &= " "
            Next
            Console.Write(out)

            Console.SetCursorPosition(pos(0), pos(1))
            Console.Write(str)

            Console.BackgroundColor = preCol(0)
            Console.ForegroundColor = preCol(1)

            Console.SetCursorPosition(prePos(0), prePos(1))

        End Sub

        Private Function GetColors() As ConsoleColor()
            Dim result(1) As ConsoleColor

            result(0) = Console.BackgroundColor
            result(1) = Console.ForegroundColor

            Return result
        End Function

        Private Function GetCursorPos() As Integer()
            Dim result(1) As Integer
            result(0) = Console.CursorLeft
            result(1) = Console.CursorTop

            Return result

        End Function

    End Class
End Module
