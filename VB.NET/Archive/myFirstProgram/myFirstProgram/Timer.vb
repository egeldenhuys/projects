Public Class Timer


    'Seconds1 is the current time
    'Seconds2 is the time the button was clicked/the answer was correct
    'after 5 seconds it should reset
    Dim Seconds1, Seconds2 As Integer

    Private Sub Timer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        lblTime.Text = TimeOfDay.Second


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub
End Class