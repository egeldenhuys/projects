Public Class Form1

    Dim Counter As Integer = 0

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Counter += 1
    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        DataTimer.Enabled = True

    End Sub

    Private Sub DataTimer_Tick(sender As System.Object, e As System.EventArgs) Handles DataTimer.Tick
        txtRawOutput.AppendText(Counter.ToString & vbCrLf)
        txtOutput.AppendText(Counter.ToString & ", ")
        Counter = 0
    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click
        DataTimer.Enabled = False
    End Sub
End Class
