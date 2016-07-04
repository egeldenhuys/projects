Module MathsModule

    Function GetNumber() As Integer

        Return 5
    End Function

    Function BiggerNumber() As Integer

        Return GetAnotherNumber()
    End Function

    Private Function GetAnotherNumber() As Integer

        Return 100
    End Function

    Public Class TestClass
        Shared Function getString() As String

            Return "This is a string"
        End Function
    End Class
End Module
