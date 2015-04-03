Public Class Calculator

    Dim Number1 As Decimal


    Private Sub btnToPractiseCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToPractiseCalculator.Click
        PractiseCalculator.Show()
    End Sub

    Private Sub btnNum1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum1.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum1.Text)

    End Sub

    Private Sub btnNum2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum2.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum2.Text)
    End Sub

    Public Sub btnPlus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlus.Click
        Number1 = BoxDisplay.Text
        BoxDisplay.Text = ""


    End Sub

    Public Sub btnEquals_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEquals.Click
        If BoxDisplay.Text = "" Then
            BoxDisplay.Text = "0"
        End If
        Dim Number2 As Decimal = BoxDisplay.Text
        
        BoxDisplay.Text = Number1 + Number2



    End Sub

    Private Sub Calculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Number1 = "0"
        BoxDisplay.Text = ""
    End Sub

    Private Sub btnNum3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum3.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum3.Text)
    End Sub

    Private Sub btnNum4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum4.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum4.Text)
    End Sub

    Private Sub btnNum5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum5.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum5.Text)
    End Sub

    Private Sub btnNum6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum6.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum6.Text)
    End Sub

    Private Sub btnNum7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum7.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum7.Text)
    End Sub

    Private Sub btnNum8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum8.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum8.Text)
    End Sub

    Private Sub btnNum9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum9.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum9.Text)
    End Sub

    Private Sub btnNum0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNum0.Click
        BoxDisplay.Text = (BoxDisplay.Text) & (btnNum0.Text)
    End Sub
End Class