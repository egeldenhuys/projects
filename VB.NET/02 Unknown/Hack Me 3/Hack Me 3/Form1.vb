Public Class Form1
    Dim iLetterAmount As Integer = 0
    Dim iLetterCount As Integer = 0
    Dim chrBase As String = "II"
    Dim chrOther As String = "Il"
    Dim Codes As String = "::auth 95jw06" & vbNewLine & "::auth j7823q" & vbNewLine & "::auth 9wm7kj"


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Button As Button
        For Each Button In GroupBox1.Controls

            If Button.Text = "?" Then
                Button.Text = chrOther
                iLetterAmount += 1
            End If

            If Button.Text = "2" Then
                Button.Text = chrBase
            End If
        Next

    End Sub

    Private Sub Button201_Click(sender As System.Object, e As System.EventArgs) Handles Button99.Click, Button98.Click, Button97.Click, Button96.Click, Button95.Click, Button94.Click, Button93.Click, Button92.Click, Button91.Click, Button90.Click, Button9.Click, Button89.Click, Button88.Click, Button87.Click, Button86.Click, Button85.Click, Button84.Click, Button83.Click, Button82.Click, Button81.Click, Button80.Click, Button8.Click, Button79.Click, Button78.Click, Button77.Click, Button76.Click, Button75.Click, Button74.Click, Button73.Click, Button72.Click, Button71.Click, Button70.Click, Button7.Click, Button69.Click, Button68.Click, Button67.Click, Button66.Click, Button65.Click, Button64.Click, Button63.Click, Button62.Click, Button61.Click, Button60.Click, Button6.Click, Button59.Click, Button58.Click, Button57.Click, Button56.Click, Button55.Click, Button54.Click, Button53.Click, Button52.Click, Button51.Click, Button50.Click, Button5.Click, Button49.Click, Button48.Click, Button47.Click, Button46.Click, Button45.Click, Button44.Click, Button43.Click, Button42.Click, Button41.Click, Button40.Click, Button4.Click, Button39.Click, Button38.Click, Button37.Click, Button36.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button30.Click, Button3.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button208.Click, Button207.Click, Button206.Click, Button205.Click, Button204.Click, Button203.Click, Button202.Click, Button201.Click, Button200.Click, Button20.Click, Button2.Click, Button199.Click, Button198.Click, Button197.Click, Button196.Click, Button195.Click, Button194.Click, Button193.Click, Button192.Click, Button191.Click, Button190.Click, Button19.Click, Button189.Click, Button188.Click, Button187.Click, Button186.Click, Button185.Click, Button184.Click, Button183.Click, Button182.Click, Button181.Click, Button180.Click, Button18.Click, Button179.Click, Button178.Click, Button177.Click, Button176.Click, Button175.Click, Button174.Click, Button173.Click, Button172.Click, Button171.Click, Button170.Click, Button17.Click, Button169.Click, Button168.Click, Button167.Click, Button166.Click, Button165.Click, Button164.Click, Button163.Click, Button162.Click, Button161.Click, Button160.Click, Button16.Click, Button159.Click, Button158.Click, Button157.Click, Button156.Click, Button155.Click, Button154.Click, Button153.Click, Button152.Click, Button151.Click, Button150.Click, Button15.Click, Button149.Click, Button148.Click, Button147.Click, Button146.Click, Button145.Click, Button144.Click, Button143.Click, Button142.Click, Button141.Click, Button140.Click, Button14.Click, Button139.Click, Button138.Click, Button137.Click, Button136.Click, Button135.Click, Button134.Click, Button133.Click, Button132.Click, Button131.Click, Button130.Click, Button13.Click, Button129.Click, Button128.Click, Button127.Click, Button126.Click, Button125.Click, Button124.Click, Button123.Click, Button122.Click, Button121.Click, Button120.Click, Button12.Click, Button119.Click, Button118.Click, Button117.Click, Button116.Click, Button115.Click, Button114.Click, Button113.Click, Button112.Click, Button111.Click, Button110.Click, Button11.Click, Button109.Click, Button108.Click, Button107.Click, Button106.Click, Button105.Click, Button104.Click, Button103.Click, Button102.Click, Button101.Click, Button100.Click, Button10.Click, Button1.Click
        Dim Btn As Object = CObj(sender)



        If Btn.text.ToString = chrOther Then
            If Btn.Backcolor <> Color.Green Then
                iLetterCount += 1
                Btn.Backcolor = Color.Green
            End If
        Else
            Reset()
        End If

        If iLetterCount = iLetterAmount Then
            DisplayCodes(Codes)
        End If
    End Sub

    Private Sub DisplayCodes(ByVal AuthCodes As String)
        Me.Hide()
        Hack_Me_3.Codes.lblCodes.Text = AuthCodes
        Hack_Me_3.Codes.ShowDialog()

    End Sub

    Private Sub Reset()
        Dim Button As Button
        For Each Button In GroupBox1.Controls
            iLetterCount = 0
            Button.BackColor = Color.FromName("[Control]")
        Next
    End Sub
End Class
