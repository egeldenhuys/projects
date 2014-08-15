Public Class FormMain
#Region "TODO List"
    '
    '
    '
    '
    '
    '
    '
    '
    '
#End Region
    Dim mUp, mDown, mLeft, mRight As Boolean
    Dim WalkSpeed As Integer = 1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Visible = False
        Button2.Enabled = True
    End Sub

    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick
        MovePlayer()
        'MovePanel()
        CheckDoor()
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Right Then
            mRight = True
            mLeft = False
        End If
        If e.KeyValue = Keys.Left Then
            mLeft = True
            mRight = False
        End If
        If e.KeyValue = Keys.Up Then
            mUp = True
            mDown = False
        End If
        If e.KeyValue = Keys.Down Then
            mDown = True
            mUp = False
        End If
    End Sub
    Private Sub MovePlayer()
        If mRight = True And Player.Right <= Me.ClientRectangle.Right Then
            Player.Left += WalkSpeed
        End If
        If mLeft = True And Player.Left >= Me.ClientRectangle.Left Then
            Player.Left -= WalkSpeed
        End If
        If mUp = True And Player.Top >= Me.ClientRectangle.Top Then
            Player.Top -= WalkSpeed
        End If
        If mDown = True And Player.Bottom <= Me.ClientRectangle.Bottom Then
            Player.Top += WalkSpeed
        End If
    End Sub
    Private Sub MovePanel()
        If mRight = True Then
            Map1Panel.Location = New Point((Map1Panel.Location.X - WalkSpeed), (Map1Panel.Location.Y))
        End If
        If mLeft = True And Player.Left > Me.ClientRectangle.Left Then
            Map1Panel.Location = New Point((Map1Panel.Location.X + WalkSpeed), (Map1Panel.Location.Y))
        End If
        If mUp = True And Player.Top > Me.ClientRectangle.Top Then
            Map1Panel.Location = New Point((Map1Panel.Location.X), (Map1Panel.Location.Y + WalkSpeed))
        End If
        If mDown = True And Player.Bottom < Me.ClientRectangle.Bottom Then
            Map1Panel.Location = New Point((Map1Panel.Location.X), (Map1Panel.Location.Y - WalkSpeed))
        End If

    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = Keys.Right Then
            mRight = False
        End If
        If e.KeyValue = Keys.Left Then
            mLeft = False
        End If
        If e.KeyValue = Keys.Up Then
            mUp = False
        End If
        If e.KeyValue = Keys.Down Then
            mDown = False
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Player.Location = New Point((Me.ClientRectangle.Width \ 2 - 12.5), (Me.ClientRectangle.Height \ 2 - 12.5))
    End Sub

    Private Sub CheckDoor()
        If (Player.Top + Player.Height >= Button2.Top) And (Player.Top <= Button2.Top + Button2.Height) And (Player.Left + Player.Width >= Button2.Left) And (Player.Left <= Button2.Left + Button2.Width) Then
            Label1.Text = "Boom"
        End If

    End Sub
End Class
