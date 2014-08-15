Public Class Form1
    Dim i As Integer
    Dim Num As Integer
    Dim Above As Integer
    Dim Below As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        
        i = 1
        Do While i <= 10000000
            Randomize()
            Num = Int(100 * Rnd() + 1)
            If Num < 55 Then
                Below += 1
            Else
                Above += 1
            End If
            ' TextBox1.Text = TextBox1.Text & Num & vbNewLine
            i += 1
        Loop
        lblAbove.Text = "55 or over: " & Above
        lblBelow.Text = "below 55: " & Below
        Label1.Text = "Difference: " & Below - Above
    End Sub
End Class
