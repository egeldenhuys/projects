Public Class GuesingGame

    Private Sub GuesingGame_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        GuessingGameSettings.Show()
    End Sub

    Private Sub btnBet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBet.Click
        Randomize()
        lblNumber.Text = (Int((100 * Rnd()) + 1))
    End Sub
End Class