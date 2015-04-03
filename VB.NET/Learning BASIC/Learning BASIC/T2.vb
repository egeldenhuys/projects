Public Class T2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim R, G, B As Integer
        R = R1.Text
        G = G1.Text
        B = B1.Text
        Me.BackColor = Color.FromArgb(R, G, B)
    End Sub
End Class