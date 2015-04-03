Public Class Main
    Dim iRealNumber As Double
    Dim aiFakeNumbers(0 To 1000000) As Integer


    Private Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Me.Width = 307
        lblCode.Text = "::auth 7vx807" & vbNewLine & "::auth abc13u" & vbNewLine & "::auth 238rxw"
        'If CheckCE() = True Then
        'lblHacked.Visible = True
        'lblHacked.Text = "Please close Cheat Engine."
        'TimerClose.Enabled = True
        'End If

        NewNumbers()
        Input.ShowDialog(Me)
    End Sub

    Private Sub btnTest_Click(sender As System.Object, e As System.EventArgs) Handles btnTest.Click

        If iRealNumber = 100 Then
            ShowCode()
        Else
            CheckNumbers()
            NewNumbers()
        End If
    End Sub

    Private Sub NewNumbers()

        Randomize()

        iRealNumber = CInt(99 * Rnd())
        For iCounter = 0 To 1000000
            aiFakeNumbers(iCounter) = CInt(iRealNumber)
        Next

        lblNumber.Text = CStr(iRealNumber)

    End Sub

    Private Sub ShowCode()
        btnTest.Visible = False
        lblCode.Visible = True
        lblHidden.Visible = False
        Me.Width = 484
    End Sub

    Private Function CheckNumbers() As Boolean
        Dim bHacked As Boolean

        For iCounter = 0 To 1000000
            If aiFakeNumbers(iCounter) <> CInt(iRealNumber) Then
                lblHacked.Visible = True
                lblHacked.Text = "Hacking detected!"
                TimerClose.Enabled = True
            End If
        Next

        Return bHacked
    End Function

    Private Function CheckCE() As Boolean
        Dim bFound As Boolean
        Dim processes As Process() = Process.GetProcessesByName("cheatengine-x86_64")

        If processes.Length = 0 Then

        Else
            bFound = True
        End If

        Return bFound
    End Function

    Private Sub TimerClose_Tick(sender As System.Object, e As System.EventArgs) Handles TimerClose.Tick
        Me.Close()
    End Sub

    
End Class
