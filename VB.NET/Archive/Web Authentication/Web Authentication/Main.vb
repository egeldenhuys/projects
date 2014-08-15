

Public Class Main
    Dim NumA, NumB, NumC As Integer
    Dim Configpath As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\settings.txt"
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GenerateNumbers()
        My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData)

        Try
            Dim Numbers As String
            Numbers = Settings.Load("Last_Entered_Code", Configpath)
            lblDigit1.Text = Numbers.Substring(0, 1)
            lblDigit2.Text = Numbers.Substring(1, 1)
            lblDigit3.Text = Numbers.Substring(2, 1)
            lblLastCode.Text = "Last Code: " & Settings.Load("Last_Code", Configpath)
            lblLastCombo.Text = Settings.Load("Last_Entered_Code", Configpath)
        Catch ex1 As System.IO.FileNotFoundException
            lblLastCode.Text = ""
            lblLastCombo.Text = ""
        End Try

    End Sub
#Region "plus Buttons"
    Private Sub btnPlus3_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus3.Click
        Dim Digit As Integer
        Digit = CInt(lblDigit3.Text)
        If Digit = 9 Then
            lblDigit3.Text = "0"
        Else
            lblDigit3.Text = CStr((Digit) + 1)
        End If
        CheckCombination()
    End Sub
    Private Sub btnPlus2_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus2.Click
        Dim Digit As Integer
        Digit = CInt(lblDigit2.Text)
        If Digit = 9 Then
            lblDigit2.Text = "0"
        Else
            lblDigit2.Text = CStr((Digit) + 1)
        End If
        CheckCombination()
    End Sub
    Private Sub btnPlus1_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus1.Click
        Dim Digit As Integer
        Digit = CInt(lblDigit1.Text)
        If Digit = 9 Then
            lblDigit1.Text = "0"
        Else
            lblDigit1.Text = CStr((Digit) + 1)
        End If
        CheckCombination()
    End Sub
#End Region

#Region "Minus buttons"
    Private Sub btnMinus1_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus1.Click
        Dim Digit As Integer
        Digit = CInt(lblDigit1.Text)
        If Digit = 0 Then
            lblDigit1.Text = "9"
        Else
            lblDigit1.Text = CStr((Digit) - 1)
        End If
        CheckCombination()
    End Sub

    Private Sub btnMinus2_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus2.Click
        Dim Digit As Integer
        Digit = CInt(lblDigit2.Text)
        If Digit = 0 Then
            lblDigit2.Text = "9"
        Else
            lblDigit2.Text = CStr((Digit) - 1)
        End If
        CheckCombination()
    End Sub

    Private Sub btnMinus3_Click(sender As System.Object, e As System.EventArgs) Handles btnMinus3.Click
        Dim Digit As Integer
        Digit = CInt(lblDigit3.Text)
        If Digit = 0 Then
            lblDigit3.Text = "9"
        Else
            lblDigit3.Text = CStr((Digit) - 1)
        End If
        CheckCombination()
    End Sub
#End Region

    Private Sub CheckCombination()
        If lblDigit1.Text = NumA.ToString Then
            If lblDigit2.Text = NumB.ToString Then
                If lblDigit3.Text = NumC.ToString Then
                    Me.BackColor = Color.Green
                Else
                    Me.BackColor = DefaultBackColor
                End If
            Else
                Me.BackColor = DefaultBackColor
            End If
        Else
            Me.BackColor = DefaultBackColor
        End If
    End Sub

    Private Sub GenerateNumbers()
        Randomize()

        NumA = CInt(9 * Rnd())
        NumB = CInt(9 * Rnd())
        NumC = CInt(9 * Rnd())

        ' Me.Text = NumA & NumB & NumC
    End Sub

    Private Sub Main_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Settings.Save("Last_Code", NumA & NumB & NumC, Configpath)
        Settings.Save("Last_Entered_Code", lblDigit1.Text & lblDigit2.Text & lblDigit3.Text, Configpath)

    End Sub

    
End Class


