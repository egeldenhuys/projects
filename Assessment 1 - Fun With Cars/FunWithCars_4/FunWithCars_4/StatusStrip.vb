Namespace ConsoleUI

    Public Class StatusStrip

        Private sText As String
        Dim pos(2) As Integer
        Public foreColor As ConsoleColor
        Public backColor As ConsoleColor

        Public Property Right As Integer

            Set(ByVal value As Integer)
                pos(2) = value
                Refresh()
            End Set

            Get
                Return pos(2)
            End Get

        End Property

        Public Property Top As Integer

            Set(ByVal value As Integer)
                pos(1) = value
                Refresh()
            End Set

            Get
                Return pos(1)
            End Get

        End Property

        Public Property Left As Integer

            Set(ByVal value As Integer)
                pos(0) = value
                Refresh()
            End Set

            Get
                Return pos(0)
            End Get

        End Property

        Public Property ForegroundColor() As ConsoleColor

            Set(ByVal value As ConsoleColor)
                foreColor = value
                Refresh()
            End Set

            Get
                Return foreColor
            End Get

        End Property

        Public Property BackgroundColor() As ConsoleColor

            Set(ByVal value As ConsoleColor)
                backColor = value
                Refresh()
            End Set

            Get
                Return backColor
            End Get

        End Property

        Public Property Text() As String

            Set(ByVal Value As String)
                sText = Value
                Refresh()
            End Set

            Get
                Return sText
            End Get

        End Property

        Public Sub New(ByVal left As Integer, _
                       ByVal top As Integer, _
                       ByVal right As Integer, _
                       ByVal backgroundColor As ConsoleColor, _
                       ByVal foregroundColor As ConsoleColor)

            pos(0) = left
            pos(1) = top
            pos(2) = right

            foreColor = foregroundColor
            backColor = backgroundColor

            Refresh()

        End Sub

        Public Sub Clear()
            sText = ""

            Dim tmpColors(1) As ConsoleColor
            tmpColors(0) = backColor
            tmpColors(1) = foreColor

            backColor = ConsoleColor.Black

            Refresh()

            backColor = tmpColors(0)
        End Sub

        Private Sub Refresh()

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
            Console.Write(sText)

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

End Namespace
