Public Class Form1
    Dim s As String
    Dim m As String = "0"
    Dim Running As Boolean
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick

        s = CStr(CInt(s) + 1)

        If s = "60" Then
            s = "0"
            m = CStr(CInt(m) + 1)
        End If

        If s.Length < 2 Then
            s = ("0" & s)
        End If
       
        If m.Length < 2 Then
            m = ("0" & m)
        End If

        lblTime.Text = m & ":" & s

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If Running = False Then
            TimerMain.Enabled = True
            btnStart.Text = "Pause"
            Running = True
            's = 0
            'm = 0
            'Me.Height = 55
        Else
            btnStart.Text = "Start"
            Running = False
            TimerMain.Enabled = False
        End If
        
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        s = "0"
        m = "0"
        lblTime.Text = "0" & m & ":" & "0" & s
    End Sub

End Class
