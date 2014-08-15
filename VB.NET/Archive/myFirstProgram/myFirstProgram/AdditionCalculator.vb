Public Class AdditionCalculator

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim num1, num2, product As Single

        If TextBox1.Text = "" Then
            num1 = "0"
        Else
            num1 = TextBox1.Text
        End If
        If TextBox2.Text = "" Then
            num2 = "0"
        Else
            num2 = TextBox2.Text
        End If

        product = num1 + num2

        Label3.Text = product

    End Sub
End Class
