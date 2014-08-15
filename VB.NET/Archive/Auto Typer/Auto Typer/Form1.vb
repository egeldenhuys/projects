Public Class Form1
    Dim Message As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Message = TextBox1.Text
    End Sub

    Private Sub SendMessage()

    End Sub

    Private Sub btnSave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnSave.KeyPress
        Message = TextBox1.Text
            SendKeys.Send(Message)
    End Sub
End Class
