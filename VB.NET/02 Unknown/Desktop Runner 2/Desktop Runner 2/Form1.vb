Public Class Form1
    Private FullScreen As Boolean = False

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.F Then
            If FullScreen = False Then
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                Me.WindowState = FormWindowState.Maximized
                FullScreen = True
            Else
                Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                Me.WindowState = FormWindowState.Normal
                FullScreen = False
            End If
        End If
    End Sub
End Class
