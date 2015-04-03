Public Class formPart2

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim myArray(10) As Integer
        Dim i As Integer = 1

        For Each myElement In myArray
            myElement = i
            boxDisplay.Text = (boxDisplay.Text & myElement & " is in element " & i & " ") & vbNewLine
            i += 1

        Next


    End Sub
End Class