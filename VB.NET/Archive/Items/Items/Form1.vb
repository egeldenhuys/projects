Public Class Form1
    Dim Clicked As Boolean
    Dim Item As New ArrayList
    Dim i As Integer = 0
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Clicked = False
    End Sub

    Private Sub RectangleShape1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Item1.Click
        If Clicked = False Then
            Clicked = True
            TimerItem.Enabled = True
        Else
            Clicked = False
            TimerItem.Enabled = False
        End If

    End Sub

    Private Sub TimerItem_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerItem.Tick
        Item1.Location = New Point((Cursor.Position.X - 15), (Cursor.Position.Y - 30))
    End Sub

    Private Sub btnAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddItem.Click
        Dim item(i) As PictureBox
        i += 1
        item(0) = New PictureBox
        item(0).Width = 50
        item(0).Height = 50
        item(0).Location = Item1.Location
        item(0).BackColor = Color.AliceBlue
    End Sub
End Class
