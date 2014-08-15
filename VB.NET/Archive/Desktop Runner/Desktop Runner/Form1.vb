Public Class Form1
    Dim mUp, mDown, mLeft, mRight As Boolean
    Dim WalkSpeed As Integer = 3
    Dim PlayerlocX As String
    Dim PlayerlocY As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AdobeDoor.Visible = False
    End Sub

    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick
        MovePlayer()
        'MovePanel()
        CheckDoor()
        lblLocation.Text = Player.Location.ToString
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
        If mRight = True And Player.Right < Me.ClientRectangle.Right Then
            Player.Left += WalkSpeed
        End If
        If mLeft = True And Player.Left > Me.ClientRectangle.Left Then
            Player.Left -= WalkSpeed
        End If
        If mUp = True And Player.Top > Me.ClientRectangle.Top Then
            Player.Top -= WalkSpeed
        End If
        If mDown = True And Player.Bottom < Me.ClientRectangle.Bottom Then
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

    Private Sub CheckDoor()
        'Adobe Enter
        If (Player.Top + Player.Height >= AdobeDoor.Top) And (Player.Top <= AdobeDoor.Top + AdobeDoor.Height) And (Player.Left + Player.Width >= AdobeDoor.Left) And (Player.Left <= AdobeDoor.Left + AdobeDoor.Width) Then
            SaveLocation()
            AdobePanel.BringToFront()
            Player.BringToFront()
            Player.Location = New Point(79, 28)
        End If
        'Adobe Exit
        If (Player.Top + Player.Height >= AdobeExitDoor.Top) And (Player.Top <= AdobeExitDoor.Top + AdobeExitDoor.Height) And (Player.Left + Player.Width >= AdobeExitDoor.Left) And (Player.Left <= AdobeExitDoor.Left + AdobeExitDoor.Width) Then
            Player.Location = New Point(208, 327)
            
            Map1Panel.BringToFront()
            Player.BringToFront()
        End If

    End Sub
    Private Sub SaveLocation()
        PlayerlocX = Player.Location.X
        PlayerlocY = Player.Location.Y
    End Sub
End Class
