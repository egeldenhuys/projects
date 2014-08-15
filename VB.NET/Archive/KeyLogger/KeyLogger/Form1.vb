Public Class Form1
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'Bugs: Collects too many letters from one keypress.
        'maybe need to hook into keyboard.
        Dim key As Boolean = GetAsyncKeyState(Keys.A)
        If key = True Then
            TextBox1.Text = TextBox1.Text & "A"
        End If
        Dim keyb As Boolean = GetAsyncKeyState(Keys.B)
        If keyb = True Then
            TextBox1.Text = TextBox1.Text & "B"
        End If
        Dim keyc As Boolean = GetAsyncKeyState(Keys.C)
        If keyc = True Then
            TextBox1.Text = TextBox1.Text & "C"
        End If
        Dim keyd As Boolean = GetAsyncKeyState(Keys.D)
        If keyd = True Then
            TextBox1.Text = TextBox1.Text & "D"
        End If
        Dim keye As Boolean = GetAsyncKeyState(Keys.E)
        If keye = True Then
            TextBox1.Text = TextBox1.Text & "E"
        End If
        Dim keyf As Boolean = GetAsyncKeyState(Keys.F)
        If keyf = True Then
            TextBox1.Text = TextBox1.Text & "F"
        End If
        Dim keyg As Boolean = GetAsyncKeyState(Keys.G)
        If keyg = True Then
            TextBox1.Text = TextBox1.Text & "G"
        End If
        Dim keySpace As Boolean = GetAsyncKeyState(Keys.Space)
        If keySpace = True Then
            TextBox1.Text = TextBox1.Text & " "
        End If
        Dim keybSpace As Boolean = GetAsyncKeyState(Keys.Back)
        If keybSpace = True Then
            TextBox1.Text = TextBox1.Text.Remove((Len(TextBox1.Text)) - 1, 1)
        End If
    End Sub
End Class
