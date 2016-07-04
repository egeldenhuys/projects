Public Class Form1
    Dim rY, rX, mX1, mY1 As Integer
    Dim i As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        i = 1
    End Sub

    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick
        Item1.Location = New Point((Cursor.Position.X), (Cursor.Position.Y))

        'CheckRatLocation()
        'Label1.Text = Cursor.Position.ToString
        'Label2.Text = Rat.Location.ToString
        'MoveItems()
    End Sub
    Private Sub CheckRatLocation()
        rX = Int(Rat.Location.X)
        rY = Int(Rat.Location.Y)
        mX1 = Int(Cursor.Position.X)
        mY1 = Int(Cursor.Position.Y)
        'moves X
        If rX < mX1 Then
            rX += 3
        ElseIf rX > mX1 Then
            rX -= 3
        ElseIf (rX = mX1 - 4) Then
            rX = mX1
        ElseIf rX = mX1 + 4 Then
            rX = mX1
        End If

        If rY < mY1 Then
            rY += 3
        ElseIf rY > mY1 Then
            rY -= 3
        ElseIf rY = mY1 Then
            rY += 0
        End If
        MoveRat()
    End Sub
    Private Sub MoveRat()
        Rat.Location = New Point(rX, rY)
    End Sub

    Private Sub MoveItems()


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Item2.Location = New Point((Item1.Location.X + 0), (Item1.Location.Y + 40))
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        item3.Location = New Point((Item2.Location.X + 0), (Item2.Location.Y + 40))
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        item4.Location = New Point((item3.Location.X + 0), (item3.Location.Y + 40))
    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        item5.Location = New Point((item4.Location.X + 0), (item4.Location.Y + 40))
    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick


        Select Case i
            Case 1
                TimerMain.Enabled = True
            Case 2
                Timer1.Enabled = True
            Case 3
                Timer2.Enabled = True
            Case 4
                Timer3.Enabled = True
            Case 5
                Timer4.Enabled = True
                Timer5.Enabled = False
        End Select
        i += 1

    End Sub
End Class

