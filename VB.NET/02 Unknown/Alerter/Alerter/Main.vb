'----------------------------------------------------------------------------------
' Creates an alert with the specified time
'----------------------------------------------------------------------------------
Public Class Main
    Dim i As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Interval = 100
        Timer1.Enabled = True
        i = 0
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If i = 0 Then
            Me.Hide()
            Timer1.Interval = 5000
        End If

        If i = 1 Then
            Alert.Show()
            Timer1.Enabled = False
        End If
        i = 1
    End Sub

End Class
