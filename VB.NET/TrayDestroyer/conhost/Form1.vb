Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        Dim procs() As Process


        procs = Process.GetProcessesByName("TrayDestroyer")

        ' No running Tray Destroyer, Lets create one!
        If procs.Length = 0 Then

        End If

    End Sub

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.Visible = False
    End Sub
End Class
