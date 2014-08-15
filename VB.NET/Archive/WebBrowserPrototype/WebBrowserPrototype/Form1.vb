Imports Skybound.Gecko
Public Class Form1

    Dim FullScreen As Boolean = False

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GeckoWebBrowser1.Navigate("runescape.com")
    End Sub

    Private Sub GoFullScreen()
        Me.MaximizeBox = False
        Me.MaximizeBox = False
        Me.TopMost = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ExitFullScreen()

        Me.MaximizeBox = True
        Me.MaximizeBox = True
        Me.TopMost = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub FullScreenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        If FullScreen = False Then
            FullScreen = True
            GoFullScreen()
        Else
            FullScreen = False
            ExitFullScreen()
        End If
    End Sub
End Class
