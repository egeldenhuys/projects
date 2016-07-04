Imports System.Windows.Forms.Cursor

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Randomize()

        Cursor.Position = New System.Drawing.Point(Cursor.Position.X + CInt(20 * Rnd()) - CInt(20 * Rnd()), Cursor.Position.Y + CInt(20 * Rnd()) - CInt(20 * Rnd()))
    End Sub
End Class
