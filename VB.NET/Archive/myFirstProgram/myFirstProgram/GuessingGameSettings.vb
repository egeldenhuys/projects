Public Class GuessingGameSettings

    Private Sub GuessingGameSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        GuesingGame.lblMoney.Text = boxMoney.Text
        If boxMoney.Text = "" Then
            GuesingGame.lblMoney.Text = "0"
        End If
        Me.Close()
    End Sub
End Class