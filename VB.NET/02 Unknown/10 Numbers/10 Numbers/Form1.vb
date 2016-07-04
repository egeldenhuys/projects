'-------------------------------------------------------------------
' This program displays 10 random numbers repeatingly then stops them
' in order.
'-------------------------------------------------------------------

Public Class Form1

    Dim numbers(9) As Integer
    Dim numbersLeft As Integer = 10

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        rtxtFinal.Text = "0000000000"

    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click

        tmrRnd.Enabled = False
        tmrGenEnd.Enabled = False

        numbersLeft = 10
        rtxtFinal.SelectionStart = 0
        rtxtFinal.SelectionLength = 10
        rtxtFinal.SelectionColor = Color.Lime


        tmrRnd.Enabled = True
        tmrGenEnd.Enabled = True

    End Sub

    Private Sub tmrRnd_Tick(sender As System.Object, e As System.EventArgs) Handles tmrRnd.Tick

        ' Initialize the random number generator.
        Randomize()

        ' Generate 10 random numbers.
        For i As Integer = 0 To numbersLeft - 1
            numbers(i) = CInt(9 * Rnd())
        Next

        ' Put the numbers in a string
        Dim finalNumber As String = ""

        For Each element In numbers
            finalNumber &= CStr(element)
        Next

        ' Display the Final number
        rtxtFinal.Text = finalNumber

        ColourNumbers()

    End Sub

    Private Sub tmrGenEnd_Tick(sender As System.Object, e As System.EventArgs) Handles tmrGenEnd.Tick

        numbersLeft -= 1

        If numbersLeft = 0 Then
            tmrGenEnd.Enabled = False
            tmrRnd.Enabled = False
        End If

        ColourNumbers()

    End Sub

    Private Sub ColourNumbers()

        rtxtFinal.SelectionStart = numbersLeft
        rtxtFinal.SelectionLength = 10
        rtxtFinal.SelectionColor = Color.Red
        rtxtFinal.SelectionLength = 0

    End Sub


    Private Sub rtxtFinal_Enter(sender As System.Object, e As System.EventArgs) Handles rtxtFinal.Enter
        btnStart.Focus()
    End Sub

    Private Sub Panel1_MouseEnter(sender As System.Object, e As System.EventArgs) Handles Panel1.MouseEnter
        btnStart.Focus()
    End Sub

    Private Sub Panel1_MouseHover(sender As System.Object, e As System.EventArgs) Handles Panel1.MouseHover
        btnStart.Focus()
    End Sub

    Private Sub Panel1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        btnStart.Focus()
    End Sub

    Private Sub Panel1_Enter(sender As System.Object, e As System.EventArgs) Handles Panel1.Enter
        btnStart.Focus()
    End Sub

    Private Sub rtxtFinal_MouseEnter(sender As System.Object, e As System.EventArgs) Handles rtxtFinal.MouseEnter
        btnStart.Focus()
    End Sub

    Private Sub rtxtFinal_MouseHover(sender As System.Object, e As System.EventArgs) Handles rtxtFinal.MouseHover
        btnStart.Focus()
    End Sub

    Private Sub rtxtFinal_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rtxtFinal.MouseMove
        btnStart.Focus()
    End Sub
End Class
