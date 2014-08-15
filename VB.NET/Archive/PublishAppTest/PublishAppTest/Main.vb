Public Class Main
    Dim Num(2) As Integer
    Dim NumSpin(2) As Boolean
    Dim i As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumSpin = {False, False, False}
    End Sub

#Region "pnlMain"
    Private Sub btnSpin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpin.Click
        TimerMain.Enabled = True
        TimerMain.Interval = 1
        NumSpin = {True, True, True}
        Num = {0, 0, 0}
        i = 0
    End Sub
    Private Sub btnStop1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop1.Click
        NumSpin(0) = False
        Check7()
    End Sub

    Private Sub btnStop2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop2.Click
        NumSpin(1) = False
        Check7()
    End Sub

    Private Sub btnStop3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop3.Click
        NumSpin(2) = False
        Check7()
    End Sub


    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick
        TimerMain.Interval = 150
        i += 1
        If NumSpin(0) = True Then
            Num(0) = Num(0) + 1
        End If
        If NumSpin(1) = True Then
            Num(1) = Num(1) + 1
        End If
        If NumSpin(2) = True Then
            Num(2) = Num(2) + 1
        End If

        If i = 9 Then
            If NumSpin(0) = True Then
                Num(0) = 0
            End If
            If NumSpin(1) = True Then
                Num(1) = 0
            End If
            If NumSpin(2) = True Then
                Num(2) = 0
            End If
            i = 0
        End If
        Slot1.Text = Num(0)
        Slot2.Text = Num(1)
        Slot3.Text = Num(2)
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        pnlOptions.BringToFront()
    End Sub

    Private Sub btnStopAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopAll.Click
        NumSpin = {False, False, False}
        Check7()
    End Sub

    Private Sub Check7()
        If NumSpin(0) = False And NumSpin(1) = False And NumSpin(2) = False Then
            If Slot1.Text = 7 Then
                Label1.Text = "Winner"
            ElseIf Slot2.Text = 7 Then
                Label1.Text = "Winner"
            ElseIf Slot3.Text = 7 Then
                Label1.Text = "Winner"
            End If
        End If
       

    End Sub
#End Region

    Private Sub RadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged

        If RadioButton1.Checked = True Then
            Label2.Text = RadioButton1.Text & vbNewLine & _
                "The numbers will spin and you have to press Stop to" & vbNewLine & _
                "stop them from spinning. This has to be done for " & vbNewLine & _
                "all 3 spinning reels."
        ElseIf RadioButton2.Checked = True Then
            Label2.Text = RadioButton2.Text & vbNewLine & _
                "You have to bet on a number from 0 - 9." & vbNewLine & _
                "If you are correct you win double the amount" & vbNewLine & _
                "you bet. The numbers spin automatically"
        ElseIf RadioButton3.Checked = True Then
            Label2.Text = RadioButton3.Text & vbNewLine & _
                "The numbers just spin..."
        End If
    End Sub
End Class
