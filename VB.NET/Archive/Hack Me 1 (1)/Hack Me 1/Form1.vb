Public Class Form1

    Dim number As Integer

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ChangeNum()
    End Sub

    Private Sub btnChange_Click(sender As System.Object, e As System.EventArgs) Handles btnChange.Click
        ChangeNum()
    End Sub

    Private Sub ChangeNum()
        Dim rndNum As New Random

        If number = 100 Then
            Form2.Show()
        Else
            number = rndNum.Next(0, 100)
        End If

        lblValue.Text = CStr(number)
    End Sub

End Class
