Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'For i As Integer = 0 To 400

        '    Dim tmpItem As New NotifyIcon

        '    tmpItem.Text = "Oh Shit!"
        '    tmpItem.Icon = My.Resources.Troll
        '    tmpItem.Visible = True
        'Next

        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.Opacity = 0


    End Sub

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False


    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Dim tmpItem As New NotifyIcon

        tmpItem.Text = "Oh Shit!"
        tmpItem.Icon = My.Resources.Troll
        tmpItem.ContextMenuStrip = ContextMenuStrip1

        tmpItem.Visible = True
    End Sub


End Class
