Public Class Main
    Dim X As Integer
    Dim Y As Integer
    Dim Cheat As Boolean
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        Label1.Select()
        Cheat = False
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        btnNo.Visible = False
    End Sub

    Private Sub btnNo_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.MouseEnter
        Movebutton()
    End Sub

    Private Sub btnNo_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.MouseHover
        'Movebutton()
    End Sub
    Private Sub Movebutton()

        If Cheat = False Then
            X = Int(220 * Rnd() + 10)
            Y = Int(140 * Rnd() + 10)
            btnNo.Location = New Point(X, Y)
        End If

    End Sub

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        Cheat = True
    End Sub

End Class
