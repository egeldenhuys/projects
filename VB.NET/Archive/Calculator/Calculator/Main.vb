Public Class Main
    Dim Num1 As Long
    Dim Num2 As Long
    Dim Total As Long
    Dim Plus As Boolean
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Number_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        txtDisplay.Text = txtDisplay.Text & sender.text
    End Sub

    Private Sub btnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlus.Click
        Num1 = txtDisplay.Text
        txtDisplay.Text = ""
        Plus = True
    End Sub

    Private Sub btnMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinus.Click
        Num1 = txtDisplay.Text
        txtDisplay.Text = ""
        Plus = False
    End Sub

    Private Sub btnEquals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquals.Click
        Num2 = txtDisplay.Text
        If Plus = True Then
            Total = Num1 + Num2
        Else
            Total = Num1 - Num2
        End If
        txtDisplay.Text = Total

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Num1 = 0
        Num2 = 0
        Total = 0
        txtDisplay.Text = ""
    End Sub
End Class
