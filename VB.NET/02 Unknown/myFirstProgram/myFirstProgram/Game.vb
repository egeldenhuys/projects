Public Class Game

    Private Sub btnBet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBet.Click
        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and 6.
        Dim DieRoll As Integer = (Int((100 * Rnd()) + 1))
        Dim BetMoney As Integer = boxBetMoney.Text
        Dim Money As Integer = lblMoney.Text
        lblDieRoll.Text = DieRoll

        If DieRoll >= 60 Then
            lblMoney.Text += boxBetMoney.Text * 2
        Else
            lblMoney.Text -= BetMoney
        End If

    End Sub

    Public Sub btnAddMoney_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMoney.Click
        lblMoney.Text = lblMoney.Text + 100


    End Sub
End Class