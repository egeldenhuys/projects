Public Class Form1
    Dim Uno, Dos, Tres As Integer
    Dim pusta, Wawart As Double
    Dim Spin As Boolean
    Sub Randomize()
        lbl1.Text = CStr(Int(Rnd() * 10))
        lbl2.Text = CStr(Int(Rnd() * 10))
        lbl3.Text = CStr(Int(Rnd() * 10))
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSPIN.Click    
        If lblBet.Text <= 0 Then
            MsgBox("Buy a Chip", vbApplicationModal + vbDefaultButton1 + vbInformation + vbOKOnly, "Adrian Panoy SLOT MACHINE")
            Exit Sub
        Else
            Timer1.Enabled = True
            lblResult.Text = ""
            lblMoney.Text = Val(lblMoney.Text) - Val(lblBet.Text)
            Label7.Text = Val(lblMoney.Text)
        End If
        

        
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call Randomize()
        Uno = Val(lbl1.Text)
        Dos = Val(lbl2.Text)
        Tres = Val(lbl3.Text)
        Label1.Text = Val(Label1.Text) - 1
        If Val(Label1.Text) = 1 Then
            Timer1.Enabled = False
            Label1.Text = 10
            Call Haha()
        End If
        If lblResult.Text = "" Then

            Call Haha()
            Exit Sub
        End If
        
        TimerSpin.Enabled = True
    End Sub

   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub YouLost()
        lblResult.Text = "Sorry!!! You Lost!! Spin Again"
    End Sub
    Private Sub TwoKinds()   
        Wawart = (Val(lblBet.Text) * 5)
        lblMoney.Text = Wawart + Val(Label7.Text)
        lblResult.Text = "2 kinds"
    End Sub
    Private Sub Haha()
        If Uno = 7 And Dos = 7 And Tres = 7 Then
            Wawart = (Val(lblBet.Text) * 20)
            lblMoney.Text = Wawart + Val(Label7.Text)
            lblResult.Text = "Jackpot"
            Exit Sub
        End If

        If Val(Uno) = "3" And Val(Dos) = "7" And Val(Tres) = "2" Then
            Call YouLost()
            Exit Sub
        ElseIf Val(Uno) = "9" And Val(Dos) = "7" And Val(Tres) = "3" Then
            Call YouLost()
            Exit Sub
        ElseIf Val(Uno) = "7" And Val(Dos) = "7" Then
            Call TwoKinds()
            Exit Sub
        End If

        If Uno <> 7 And Dos <> 7 And Tres <> 7 Then
            If Uno = Dos And Dos = Tres And Uno = Tres Then
                Wawart = (Val(lblBet.Text) * 10)
                lblMoney.Text = Wawart + Val(Label7.Text)
                lblResult.Text = "3 Kinds"
                Exit Sub
            ElseIf Val(Uno) = Val(Dos) Or Val(Dos) = Val(Tres) Or Val(Uno) = Val(Tres) Then
                If Val(Dos) = Val(Uno) Or Val(Tres) = Val(Dos) Or Val(Tres) = Val(Uno) Then
                    Call TwoKinds()
                    Exit Sub
                End If
            Else
                Call YouLost()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'System.Diagnostics.Process.Start("http://codes-47.blogspot.com")
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pusta = Val(lblBet.Text) + 10
        If pusta > 100 Then
            MsgBox("Maximum BET is 100", vbApplicationModal + vbDefaultButton1 + vbInformation + vbOKOnly, "Adrian Panoy SLOT MACHINE")
            Exit Sub
        Else
            lblBet.Text = Val(lblBet.Text) + 10
            lblMoney.Text = Val(lblMoney.Text) - 10
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        pusta = Val(lblBet.Text) - 10
        If pusta < 10 Then
            MsgBox("Minimum BET is 10", vbApplicationModal + vbDefaultButton1 + vbInformation + vbOKOnly, "Adrian Panoy SLOT MACHINE")
            Exit Sub       
        Else
            lblBet.Text = Val(lblBet.Text) - 10
            lblMoney.Text = Val(lblMoney.Text) + 10
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Val(lblMoney.Text) > 100 Then
            MsgBox("You have a enough Chip", vbApplicationModal + vbDefaultButton1 + vbInformation + vbOKOnly, "Adrian Panoy SLOT MACHINE")
            Exit Sub
        ElseIf Val(lblMoney.Text) <= 0 Or Val(lblMoney.Text) <= 100 Then
            'lblBet.Text = Val(lblBet.Text) + 100
            lblMoney.Text = Val(lblMoney.Text) + 1000
        End If
    End Sub

    Private Sub TimerSpin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSpin.Tick
        
        TimerSpin.Enabled = False
        Button1_Click(sender, e)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoSpin.Click
        
    End Sub
End Class
