Public Class GuessTheNumber

    Dim Num As Integer
    Dim N As Integer
    Dim Auto As Boolean = True

    Private Sub GuessTheNumber_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        GenNum()
        lblGiveUp.Text = ""
        lblError.Visible = False
        btnAutoReset.ForeColor = Color.Green
    End Sub

    Public Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        GenNum()
        lblGiveUp.Text = ""
        lblError.Visible = False

    End Sub

    Public Sub btnGuess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuess.Click

        On Error GoTo Error_handler
        If boxGuess.Text = "" Then
            boxGuess.Text = "0"
        End If

        If N <= boxGuess.Text Then
            lblIndicator.Text = "Lower"
        Else
            lblIndicator.Text = "Higher"
        End If

        If N = boxGuess.Text Then
            lblIndicator.Text = "Correct"
            lblIndicator.ForeColor = Color.Green
            If Auto = True Then
                Correct.Enabled = True
            End If

        Else
            lblIndicator.ForeColor = Color.Black
        End If

        Exit Sub
Error_handler:
        lblError.Visible = True

    End Sub

    Private Sub btnGiveUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGiveUp.Click

        lblGiveUp.Text = N
    End Sub

    Private Sub GenNum()
        Randomize()
        If Num = "0" Then
            N = (Int((100 * Rnd()) + 1))
            lblIndicator.Text = ""
            boxGuess.Text = ""
        Else
            N = (Int(((Num) * Rnd()) + 1))
            lblIndicator.Text = ""
            boxGuess.Text = ""
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        On Error GoTo Error_handler
        Num = boxNum.Text
        Button1.ForeColor = Color.Green
        GenNum()
        Exit Sub
Error_handler:
        lblError.Visible = True

    End Sub

    Private Sub Correct_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Correct.Tick
        btnReset_Click(sender, e)

        Correct.Enabled = False
    End Sub

    Private Sub btnAutoReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoReset.Click
        If Auto = True Then
            btnAutoReset.ForeColor = Color.Red
            Auto = False
        Else
            btnAutoReset.ForeColor = Color.Green
            Auto = True
            If lblIndicator.Text = "Correct" Then
                btnReset_Click(sender, e)
            End If
        End If

    End Sub
End Class
