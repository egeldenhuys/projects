Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cursor.Hide()
        PictureBox1.Parent = PictureBox2

    End Sub


    Private Sub Form1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        MouseMoveEvent()

    End Sub

    Private Sub MouseMoveEvent()
        PictureBox1.Location = New Point(CInt(Cursor.Position.X - Me.Location.X - PictureBox1.Width / 2), Cursor.Position.Y - Me.Location.Y - PictureBox1.Height)
    End Sub

    Private Sub PictureBox1_Mousemove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        MouseMoveEvent()
    End Sub

    Private Sub PictureBox2_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        MouseMoveEvent()
    End Sub
End Class
