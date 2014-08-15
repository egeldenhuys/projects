Class Page1
    Dim Turn As Integer = 1
    Dim Count As Integer
    Dim P1score As Integer
    Dim P2score As Integer
    Dim Ties As Integer
    Dim Strike As Color
    Dim ResetC As Color
    Dim Reset As Integer = 0
    Public AutoR As Boolean = False

    Private Sub Slot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Slot1.Click, Slot2.Click, Slot3.Click, Slot4.Click, Slot5.Click, Slot6.Click, Slot7.Click, Slot8.Click, Slot9.Click

        Reset = 0
        If Count < 9 Then
            If Turn = 1 Then
                sender.content = "X"
                Turn = 0
                sender.isenabled = False
                lblPlayer.Content = "Player 2"
            Else
                sender.content = "O"
                Turn = 1
                sender.isenabled = False
                lblPlayer.Content = "Player 1"
            End If
            Count = Count + 1
        End If
        If Count = 9 Then
            Ties = Ties + 1
            lblTies.Content = "Ties: " & Ties
        End If
        Check()
    End Sub

    Private Function Check()

        If Slot7.Content = "X" And Slot8.Content = "X" And Slot9.Content = "X" Then
            P1score = P1score + 1
            lblP1Score.Content = "P1 Score: " & P1score
            'Slot7.Background = Color.FromArgb(255, 255, 255, 100)
            'Slot8.BackColor = (Strike)
            'Slot9.BackColor = (Strike)
            EndGame()
        ElseIf Slot4.Content = "X" And Slot5.Content = "X" And Slot6.Content = "X" Then
            P1score = P1score + 1
            lblP1Score.Content = "P1 Score: " & P1score
            'Slot4.BackColor = (Strike)
            'Slot5.BackColor = (Strike)
            'Slot6.BackColor = (Strike)
            EndGame()
        ElseIf Slot1.Content = "X" And Slot2.Content = "X" And Slot3.Content = "X" Then
            P1score = P1score + 1
            lblP1Score.Content = "P1 Score: " & P1score
            'Slot1.BackColor = (Strike)
            'Slot2.BackColor = (Strike)
            'Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot7.Content = "X" And Slot4.Content = "X" And Slot1.Content = "X" Then
            P1score = P1score + 1
            lblP1Score.Content = "P1 Score: " & P1score
            'Slot7.BackColor = (Strike)
            'Slot4.BackColor = (Strike)
            'Slot1.BackColor = (Strike)
            EndGame()
        ElseIf Slot8.Content = "X" And Slot5.Content = "X" And Slot2.Content = "X" Then
            P1score = P1score + 1
            lblP1Score.Content = "P1 Score: " & P1score
            'Slot8.BackColor = (Strike)
            'Slot5.BackColor = (Strike)
            'Slot2.BackColor = (Strike)
            EndGame()
        ElseIf Slot9.Content = "X" And Slot6.Content = "X" And Slot3.Content = "X" Then
            P1score = P1score + 1
            lblP1Score.Content = "P1 Score: " & P1score
            'Slot9.BackColor = (Strike)
            'Slot6.BackColor = (Strike)
            'Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot7.Content = "X" And Slot5.Content = "X" And Slot3.Content = "X" Then
            P1score = P1score + 1
            lblP1Score.Content = "P1 Score: " & P1score
            'Slot7.BackColor = (Strike)
            'Slot5.BackColor = (Strike)
            'Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot9.Content = "X" And Slot5.Content = "X" And Slot1.Content = "X" Then
            P1score = P1score + 1
            lblP1Score.Content = "P1 Score: " & P1score
            'Slot9.BackColor = (Strike)
            'Slot5.BackColor = (Strike)
            'Slot1.BackColor = (Strike)
            EndGame()
        End If

        If Slot7.Content = "O" And Slot8.Content = "O" And Slot9.Content = "O" Then
            P2score = P2score + 1
            lblP2Score.Content = "P2 Score: " & P2score
            'Slot7.BackColor = (Strike)
            'Slot8.BackColor = (Strike)
            'Slot9.BackColor = (Strike)
            EndGame()
        ElseIf Slot4.Content = "O" And Slot5.Content = "O" And Slot6.Content = "O" Then
            P2score = P2score + 1
            lblP2Score.Content = "P2 Score: " & P2score
            'Slot4.BackColor = (Strike)
            'Slot5.BackColor = (Strike)
            'Slot6.BackColor = (Strike)
            EndGame()
        ElseIf Slot1.Content = "O" And Slot2.Content = "O" And Slot3.Content = "O" Then
            P2score = P2score + 1
            lblP2Score.Content = "P2 Score: " & P2score
            'Slot1.BackColor = (Strike)
            'Slot2.BackColor = (Strike)
            'Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot7.Content = "O" And Slot4.Content = "O" And Slot1.Content = "O" Then
            P2score = P2score + 1
            lblP2Score.Content = "P2 Score: " & P2score
            'Slot7.BackColor = (Strike)
            'Slot4.BackColor = (Strike)
            'Slot1.BackColor = (Strike)
            EndGame()
        ElseIf Slot8.Content = "O" And Slot5.Content = "O" And Slot2.Content = "O" Then
            P2score = P2score + 1
            lblP2Score.Content = "P2 Score: " & P2score
            'Slot8.BackColor = (Strike)
            'Slot5.BackColor = (Strike)
            'Slot2.BackColor = (Strike)
            EndGame()
        ElseIf Slot9.Content = "O" And Slot6.Content = "O" And Slot3.Content = "O" Then
            P2score = P2score + 1
            lblP2Score.Content = "P2 Score: " & P2score
            'Slot9.BackColor = (Strike)
            'Slot6.BackColor = (Strike)
            'Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot7.Content = "O" And Slot5.Content = "O" And Slot3.Content = "O" Then
            P2score = P2score + 1
            lblP2Score.Content = "P2 Score: " & P2score
            'Slot7.BackColor = (Strike)
            'Slot5.BackColor = (Strike)
            'Slot3.BackColor = (Strike)
            EndGame()
        ElseIf Slot9.Content = "O" And Slot5.Content = "O" And Slot1.Content = "O" Then
            P2score = P2score + 1
            lblP2Score.Content = "P2 Score: " & P2score
            'Slot9.BackColor = (Strike)
            'Slot5.BackColor = (Strike)
            'Slot1.BackColor = (Strike)
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
        lblPlayer.Content = "Player 1"
        Slot1.IsEnabled = True
        Slot2.IsEnabled = True
        Slot3.IsEnabled = True
        Slot4.IsEnabled = True
        Slot5.IsEnabled = True
        Slot6.IsEnabled = True
        Slot7.IsEnabled = True
        Slot8.IsEnabled = True
        Slot9.IsEnabled = True
        Slot1.Content = ""
        Slot2.Content = ""
        Slot3.Content = ""
        Slot4.Content = ""
        Slot5.Content = ""
        Slot6.Content = ""
        Slot7.Content = ""
        Slot8.Content = ""
        Slot9.Content = ""
        'Slot1.BackColor = ResetC
        'Slot2.BackColor = ResetC
        'Slot3.BackColor = ResetC
        'Slot4.BackColor = ResetC
        'Slot5.BackColor = ResetC
        'Slot6.BackColor = ResetC
        'Slot7.BackColor = ResetC
        'Slot8.BackColor = ResetC
        'Slot9.BackColor = ResetC
        If Reset = 2 Then
            Reset = 0
            P1score = 0
            P2score = 0
            Ties = 0
            lblP1Score.Content = "P1 Score: " & P1score
            lblP2Score.Content = "P2 Score: " & P2score
            lblTies.Content = "Ties: " & Ties
        End If

    End Sub

    Private Function EndGame()
        'If AutoR = True Then
        'Timer1.IsEnabled = True
        'End If
        lblP1Score.Content = "P1 Score: " & P1score
        lblP2Score.Content = "P2 Score: " & P2score
        Slot1.IsEnabled = False
        Slot2.IsEnabled = False
        Slot3.IsEnabled = False
        Slot4.IsEnabled = False
        Slot5.IsEnabled = False
        Slot6.IsEnabled = False
        Slot7.IsEnabled = False
        Slot8.IsEnabled = False
        Slot9.IsEnabled = False
        Return 0
    End Function

    'Private Sub Settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
    'Dim formOptions As New Options
    'formOptions.ShowDialog()

    'End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    'btnReset_Click(sender, e)
    'Timer1.IsEnabled = False
    'End Sub
End Class
