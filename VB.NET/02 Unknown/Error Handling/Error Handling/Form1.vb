Option Explicit On
Option Strict On

Public Class Form1

    Private Sub HandledError1(ByVal upLimit As Integer)
        Dim test As Short
        Dim ourArray(3) As Integer

        Try
            test = 16000
            test *= test
        Catch ex1 As OverflowException
            MsgBox("We caught an OverflowException in the sub.")
            Try
                For i As Integer = 0 To upLimit
                    ourArray(i) = i
                Next i
            Catch ex2 As IndexOutOfRangeException
                MsgBox("We caught an index out of range exception in the subs error handling")
            End Try
            MsgBox("Sub after catch two")
        End Try
        MsgBox("Sub after catch one")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim forLimit As Integer

        Try
            If isnumeric(textbox1.text.trim) Then 'Checking user input - could be improved.
                forLimit = CInt(TextBox1.Text.Trim)
                HandledError1(forLimit)
            Else
                MsgBox("Please provide a number")
            End If
        Catch ex1 As Exception
            MsgBox("We caught an exception from the sub in the calling code.")
        End Try
    End Sub
End Class

