Public Class Form1
#Region "Tasks"
    'add reset time
    'Player scores - names
    'fix name tags
#End Region
#Region "Declarations"
    Dim Turn As Integer
    Dim Count As Integer
    Dim P1score As Integer
    Dim P2score As Integer
    Dim Ties As Integer
    Dim StrikeColour As Color
    Dim ResetColour As Color
    Dim Reset As Boolean
    Dim AutoR As Boolean
    Dim P1name As String
    Dim P2name As String
    Dim GameColour As Color
    Dim OptionsColour As Color
#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Page 1 Start
        lblWin.Text = ""
        Turn = 1
        StrikeColour = Color.Green
        ResetColour = Color.White
        Reset = True
        Timer1.Interval = 2000
        AutoR = False
        P1name = "Player 1"
        P2name = "Player 2"
        lblPlayer.Text = P1name
        'Page 1 End
        If AutoR = True Then
            AutoRCheckbox.Checked = True
        End If
    End Sub

#Region "Game"

    Private Sub Slot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Slot1.Click, Slot2.Click, Slot3.Click, Slot4.Click, Slot5.Click, Slot6.Click, Slot7.Click, Slot8.Click, Slot9.Click
        Reset = 0
        If Count < 9 Then
            If Turn = 1 Then
                sender.text = "X"
                Turn = 0
                sender.enabled = False
                lblPlayer.Text = P2name
            Else
                sender.text = "O"
                Turn = 1
                sender.enabled = False
                lblPlayer.Text = P1name
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
            Slot7.BackColor = (StrikeColour)
            Slot8.BackColor = (StrikeColour)
            Slot9.BackColor = (StrikeColour)
            lblWin.Text = P1name & " Wins!"
            EndGame()
        ElseIf Slot4.Text = "X" And Slot5.Text = "X" And Slot6.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot4.BackColor = (StrikeColour)
            Slot5.BackColor = (StrikeColour)
            Slot6.BackColor = (StrikeColour)
            lblWin.Text = P1name & " Wins!"
            EndGame()
        ElseIf Slot1.Text = "X" And Slot2.Text = "X" And Slot3.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot1.BackColor = (StrikeColour)
            Slot2.BackColor = (StrikeColour)
            Slot3.BackColor = (StrikeColour)
            lblWin.Text = P1name & " Wins!"
            EndGame()
        ElseIf Slot7.Text = "X" And Slot4.Text = "X" And Slot1.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot7.BackColor = (StrikeColour)
            Slot4.BackColor = (StrikeColour)
            Slot1.BackColor = (StrikeColour)
            lblWin.Text = P1name & " Wins!"
            EndGame()
        ElseIf Slot8.Text = "X" And Slot5.Text = "X" And Slot2.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot8.BackColor = (StrikeColour)
            Slot5.BackColor = (StrikeColour)
            Slot2.BackColor = (StrikeColour)
            lblWin.Text = P1name & " Wins!"
            EndGame()
        ElseIf Slot9.Text = "X" And Slot6.Text = "X" And Slot3.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot9.BackColor = (StrikeColour)
            Slot6.BackColor = (StrikeColour)
            Slot3.BackColor = (StrikeColour)
            lblWin.Text = P1name & " Wins!"
            EndGame()
        ElseIf Slot7.Text = "X" And Slot5.Text = "X" And Slot3.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot7.BackColor = (StrikeColour)
            Slot5.BackColor = (StrikeColour)
            Slot3.BackColor = (StrikeColour)
            lblWin.Text = P1name & " Wins!"
            EndGame()
        ElseIf Slot9.Text = "X" And Slot5.Text = "X" And Slot1.Text = "X" Then
            P1score = P1score + 1
            lblP1Score.Text = "P1 Score: " & P1score
            Slot9.BackColor = (StrikeColour)
            Slot5.BackColor = (StrikeColour)
            Slot1.BackColor = (StrikeColour)
            lblWin.Text = P1name & " Wins!"
            EndGame()
        End If

        If Slot7.Text = "O" And Slot8.Text = "O" And Slot9.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot7.BackColor = (StrikeColour)
            Slot8.BackColor = (StrikeColour)
            Slot9.BackColor = (StrikeColour)
            lblWin.Text = P2name & " Wins!"
            EndGame()
        ElseIf Slot4.Text = "O" And Slot5.Text = "O" And Slot6.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot4.BackColor = (StrikeColour)
            Slot5.BackColor = (StrikeColour)
            Slot6.BackColor = (StrikeColour)
            lblWin.Text = P2name & " Wins!"
            EndGame()
        ElseIf Slot1.Text = "O" And Slot2.Text = "O" And Slot3.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot1.BackColor = (StrikeColour)
            Slot2.BackColor = (StrikeColour)
            Slot3.BackColor = (StrikeColour)
            lblWin.Text = P2name & " Wins!"
            EndGame()
        ElseIf Slot7.Text = "O" And Slot4.Text = "O" And Slot1.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot7.BackColor = (StrikeColour)
            Slot4.BackColor = (StrikeColour)
            Slot1.BackColor = (StrikeColour)
            lblWin.Text = P2name & " Wins!"
            EndGame()
        ElseIf Slot8.Text = "O" And Slot5.Text = "O" And Slot2.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot8.BackColor = (StrikeColour)
            Slot5.BackColor = (StrikeColour)
            Slot2.BackColor = (StrikeColour)
            lblWin.Text = P2name & " Wins!"
            EndGame()
        ElseIf Slot9.Text = "O" And Slot6.Text = "O" And Slot3.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot9.BackColor = (StrikeColour)
            Slot6.BackColor = (StrikeColour)
            Slot3.BackColor = (StrikeColour)
            lblWin.Text = P2name & " Wins!"
            EndGame()
        ElseIf Slot7.Text = "O" And Slot5.Text = "O" And Slot3.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot7.BackColor = (StrikeColour)
            Slot5.BackColor = (StrikeColour)
            Slot3.BackColor = (StrikeColour)
            lblWin.Text = P2name & " Wins!"
            EndGame()
        ElseIf Slot9.Text = "O" And Slot5.Text = "O" And Slot1.Text = "O" Then
            P2score = P2score + 1
            lblP2Score.Text = "P2 Score: " & P2score
            Slot9.BackColor = (StrikeColour)
            Slot5.BackColor = (StrikeColour)
            Slot1.BackColor = (StrikeColour)
            lblWin.Text = P2name & " Wins!"
            EndGame()
        End If
        If Count = 9 Then
            lblWin.Text = "Tie!"
            EndGame()
        End If
        Return 0
    End Function

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ResetGame()
    End Sub

    Private Function EndGame()
        If AutoR = True Then
            Timer1.Enabled = True
        End If
        lblP1Score.Text = P1name & ": " & P1score
        lblP2Score.Text = P2name & ": " & P2score
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

    Private Function ResetGame()
        Turn = 1
        Count = 0
        lblPlayer.Text = P1name
        lblWin.Text = ""
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
        Slot1.BackColor = ResetColour
        Slot2.BackColor = ResetColour
        Slot3.BackColor = ResetColour
        Slot4.BackColor = ResetColour
        Slot5.BackColor = ResetColour
        Slot6.BackColor = ResetColour
        Slot7.BackColor = ResetColour
        Slot8.BackColor = ResetColour
        Slot9.BackColor = ResetColour
        If Reset = True Then
            Reset = 0
            P1score = 0
            P2score = 0
            Ties = 0
            lblP1Score.Text = "P1 Score: " & P1score
            lblP2Score.Text = "P2 Score: " & P2score
            lblTies.Text = "Ties: " & Ties
        Else : Reset = True
        End If
        Return 0
    End Function

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        Options.BringToFront()
        Me.Text = "Tic Tac Toe - Options"
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Reset = False Then
            ResetGame()
        End If
        Timer1.Enabled = False
    End Sub
#End Region

#Region "Options"
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Text = "Tic Tac Toe"
        Game.BringToFront()

        If AutoRCheckbox.Checked = True Then
            AutoR = True
        Else
            AutoR = False
        End If
        If txtboxP1name.Text <> "Player 1" Then
            P1name = txtboxP1name.Text
        End If
        If txtboxP2name.Text <> "Player 2" Then
            P2name = txtboxP2name.Text
        End If
        If Turn = 1 Then
            lblPlayer.Text = P1name
        ElseIf Turn = 0 Then
            lblPlayer.Text = P2name
        End If
        lblP1Score.Text = P1name & ": " & P1score
        lblP2Score.Text = P2name & ": " & P2score

    End Sub
#End Region
End Class
