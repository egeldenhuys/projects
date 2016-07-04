Public Class Main_Menu

    Private Sub btnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculator.Click
        AdditionCalculator.Show()
    End Sub

    Private Sub btnHelloWorld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelloWorld.Click
        HelloWorld.Show()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnCalculator2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculator2.Click
        Calculator.Show()
    End Sub

    Private Sub btnToPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToPassword.Click
        Password.Show()
    End Sub

    Private Sub btnToGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToGame.Click
        Game.Show()
    End Sub

    Private Sub btnToGuesingGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToGuesingGame.Click
        GuesingGame.Show()
    End Sub

    Private Sub btnToGuessTheNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToGuessTheNumber.Click
        GuessTheNumber.Show()
    End Sub

    Private Sub Main_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub btnToTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToTimer.Click
        Timer.Show()

    End Sub

    Private Sub btnToRandomizer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToRandomizer.Click
        Randomizer.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.Show()
    End Sub

    Private Sub btnToTicTacToe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToTicTacToe.Click
        TicTacToe.Show()
    End Sub
End Class