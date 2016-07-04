Public Class MathsClass

    Shared Function GetNumber() As Integer

        Return 5
    End Function

    Shared Function BiggerNumber() As Integer
        Dim MC As New MathsClass

        Return MC.GetAnotherNumber()
    End Function

    Private Function GetAnotherNumber() As Integer

        Return 100
    End Function

End Class
