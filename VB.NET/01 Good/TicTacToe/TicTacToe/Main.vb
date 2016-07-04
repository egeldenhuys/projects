Public Class Main
    'TODO
    '
    '
    '
    'Add options for 'auto reset' and 'strike colour' and also BG colour
    '
    '
    Dim Turn As Integer
    Dim Count As Integer
    Dim P1score As Integer
    Dim P2score As Integer
    Dim Ties As Integer
    Dim Strike As Color
    Dim ResetC As Color
    Dim Reset As Integer
    Public AutoR As Boolean



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblPlayer.Text = "Player 1"
        Turn = 1
        Strike = Color.Green
        ResetC = Color.White
        Reset = 0
        Timer1.Interval = 2000
        AutoR = False
    End Sub

    Private Sub Slot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Slot1.Click, Slot2.Click, Slot3.Click, Slot4.Click, Slot5.Click, Slot6.Click, Slot7.Click, Slot8.Click, Slot9.Click
        Reset = 0
        If Count < 9 Then
            If Turn = 1 Then
                sender.text = "X"
                Turn = 0
                sender.enabled = False
                lblPlayer.Text = "Player 2"
            Else
                sender.text = "O"
                Turn = 1
                sender.enabled = False
                lblPlayer.Text = "Player 1"
            End If
            Count = Count + 1
        End If
        If Count = 9 Then
            Ties = Ties + 1
            lblTies.Text = "Ties: " & Ties
        End If
        Check()
    End Sub

    Private Function Check()

        If Slot7.Text = "X" And Slot8.Text = "X" And Slot9.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot7.BackColor = (Strike)
            Slot8.BackColor = (Strike)
            Slot9.BackColor = (Strike)
            EndGame()
        ElseIf Slot4.Text = "X" And Slot5.Text = "X" And Slot6.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot4.BackColor = (Strike)
            Slot5.BackColor = (Strike)
            Slot6.BackColor = (Strike)
            EndGame()
        ElseIf Slot1.Text = "X" And Slot2.Text = "X" And Slot3.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot1.BackColor = (Strike)
            Slot2.BackColor = (Strike)
            Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot7.Text = "X" And Slot4.Text = "X" And Slot1.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot7.BackColor = (Strike)
            Slot4.BackColor = (Strike)
            Slot1.BackColor = (Strike)
            EndGame()
        ElseIf Slot8.Text = "X" And Slot5.Text = "X" And Slot2.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot8.BackColor = (Strike)
            Slot5.BackColor = (Strike)
            Slot2.BackColor = (Strike)
            EndGame()
        ElseIf Slot9.Text = "X" And Slot6.Text = "X" And Slot3.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot9.BackColor = (Strike)
            Slot6.BackColor = (Strike)
            Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot7.Text = "X" And Slot5.Text = "X" And Slot3.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot7.BackColor = (Strike)
            Slot5.BackColor = (Strike)
            Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot9.Text = "X" And Slot5.Text = "X" And Slot1.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot9.BackColor = (Strike)
            Slot5.BackColor = (Strike)
            Slot1.BackColor = (Strike)
            EndGame()
        End If

        If Slot7.Text = "O" And Slot8.Text = "O" And Slot9.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot7.BackColor = (Strike)
            Slot8.BackColor = (Strike)
            Slot9.BackColor = (Strike)
            EndGame()
        ElseIf Slot4.Text = "O" And Slot5.Text = "O" And Slot6.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot4.BackColor = (Strike)
            Slot5.BackColor = (Strike)
            Slot6.BackColor = (Strike)
            EndGame()
        ElseIf Slot1.Text = "O" And Slot2.Text = "O" And Slot3.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot1.BackColor = (Strike)
            Slot2.BackColor = (Strike)
            Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot7.Text = "O" And Slot4.Text = "O" And Slot1.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot7.BackColor = (Strike)
            Slot4.BackColor = (Strike)
            Slot1.BackColor = (Strike)
            EndGame()
        ElseIf Slot8.Text = "O" And Slot5.Text = "O" And Slot2.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot8.BackColor = (Strike)
            Slot5.BackColor = (Strike)
            Slot2.BackColor = (Strike)
            EndGame()
        ElseIf Slot9.Text = "O" And Slot6.Text = "O" And Slot3.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot9.BackColor = (Strike)
            Slot6.BackColor = (Strike)
            Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot7.Text = "O" And Slot5.Text = "O" And Slot3.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot7.BackColor = (Strike)
            Slot5.BackColor = (Strike)
            Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot9.Text = "O" And Slot5.Text = "O" And Slot1.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot9.BackColor = (Strike)
            Slot5.BackColor = (Strike)
            Slot1.BackColor = (Strike)
            EndGame()
        End If
        If Count = 9 Then
            EndGame()
        End If
        Return 0
    End Function

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset = Reset + 1
        Turn = 1
        Count = 0
        lblPlayer.Text = "Player 1"
        Slot1.Enabled = True
        Slot2.Enabled = True
        Slot3.Enabled = True
        Slot4.Enabled = True
        Slot5.Enabled = True
        Slot6.Enabled = True
        Slot7.Enabled = True
        Slot8.Enabled = True
        Slot9.Enabled = True
        Slot1.Text = ""
        Slot2.Text = ""
        Slot3.Text = ""
        Slot4.Text = ""
        Slot5.Text = ""
        Slot6.Text = ""
        Slot7.Text = ""
        Slot8.Text = ""
        Slot9.Text = ""
        Slot1.BackColor = ResetC
        Slot2.BackColor = ResetC
        Slot3.BackColor = ResetC
        Slot4.BackColor = ResetC
        Slot5.BackColor = ResetC
        Slot6.BackColor = ResetC
        Slot7.BackColor = ResetC
        Slot8.BackColor = ResetC
        Slot9.BackColor = ResetC
        If Reset = 2 Then
            Reset = 0
            P1score = 0
            P2score = 0
            Ties = 0
            lblP1Score.Text = "P1 Score: " & P1score
            lblP2Score.Text = "P2 Score: " & P2score
            lblTies.Text = "Ties: " & Ties
        End If

    End Sub

    Private Function EndGame()
        If AutoR = True Then
            Timer1.Enabled = True
        End If
        lblP1Score.Text = "P1 Score: " & P1score
        lblP2Score.Text = "P2 Score: " & P2score
        Slot1.Enabled = False
        Slot2.Enabled = False
        Slot3.Enabled = False
        Slot4.Enabled = False
        Slot5.Enabled = False
        Slot6.Enabled = False
        Slot7.Enabled = False
        Slot8.Enabled = False
        Slot9.Enabled = False
        Return 0
    End Function

    Private Sub Settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        Dim formOptions As New Options
        formOptions.ShowDialog()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        btnReset_Click(sender, e)
        Timer1.Enabled = False
    End Sub
End Class



