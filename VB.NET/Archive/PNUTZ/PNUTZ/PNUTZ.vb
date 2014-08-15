Imports System.Windows.Forms
Public Class MyFunctions
    ''' <summary>
    ''' Returns how the computer is feeling right now.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MoodMessage() As String

        Return "I AM CRANKY! RAWR266!!!!!"
    End Function

    Public Sub TerminateProg(Prog As Form)
        Prog.Close()

    End Sub

End Class
