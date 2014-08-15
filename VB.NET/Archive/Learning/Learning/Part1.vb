Public Class formPart1

    Private Sub btnDisplayHello_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayHello.Click
        If lblHelloWorld.Text = "Hello World!" Then
            lblHelloWorld.Text = ""
            Me.Text = "Part1"
        Else : lblHelloWorld.Text = "Hello World!"
            Me.Text = "Hello World!"
        End If


    End Sub
End Class