Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblNumber.Text = ""
    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Dim Lower As Integer = CInt(lblLower.Text)
        Dim upper As Integer = CInt(lblUpper.Text)

        Randomize()
        lblNumber.Text = CStr(CInt(upper * Rnd() - Lower + 1))
    End Sub
End Class
