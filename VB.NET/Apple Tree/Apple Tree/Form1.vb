'----------------------------------------------------------------------------------
' A game where you click apples and they drop to the floor...
'----------------------------------------------------------------------------------

Public Class Form1
    Dim _Apple As PictureBox
    Dim _falling As Boolean
    Dim _falled As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _falled = 0
    End Sub

    Private Sub Apple1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click, PictureBox3.Click, PictureBox2.Click, PictureBox1.Click, Apple1.Click
        If _falling = False Then
            _Apple = sender
            TimerDrop.Enabled = True
            TimerSpin.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDrop.Tick
        _falling = True
        If _Apple.Location.Y < (293 - 80) Then
            _Apple.Location = New Point(_Apple.Location.X, _Apple.Location.Y + 5)
        Else
            _falling = False
            TimerDrop.Enabled = False
            _falled += 1
            If _falled = 5 Then
                TimerManMove.Enabled = True
                picBoxMan.Visible = True
            End If
        End If

    End Sub

    Private Sub TimerSpin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSpin.Tick
        If _falling = True Then
            _Apple.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        Else
            TimerSpin.Enabled = False
        End If

    End Sub

    Private Sub TimerManMove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerManMove.Tick
        picBoxMan.Location = New Point(picBoxMan.Location.X - 2, picBoxMan.Location.Y)

        If picBoxMan.Bounds.IntersectsWith(PictureBox3.Bounds) Then

            PictureBox3.Visible = False
        End If
        If picBoxMan.Bounds.IntersectsWith(PictureBox4.Bounds) Then
            PictureBox4.Visible = False

        End If
        If picBoxMan.Bounds.IntersectsWith(PictureBox2.Bounds) Then
            PictureBox2.Visible = False

        End If
        If picBoxMan.Bounds.IntersectsWith(PictureBox1.Bounds) Then
            PictureBox1.Visible = False

        End If
        If picBoxMan.Bounds.IntersectsWith(Apple1.Bounds) Then
            Apple1.Visible = False

        End If

        If picBoxMan.Location.X < -68 Then
            picBoxMan.Visible = False
            TimerManMove.Enabled = False
            Me.Close()
        End If
    End Sub

End Class
