Public Class Form1
    Dim Command As String
    Dim Part As Integer
    Shadows Name As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtInput.Select()
        txtGame.Text = "Welcome to Gomville." & vbNewLine _
        & "Type 'new' to create a new character."
        '0 = wait for "New"
        part = 0
    End Sub

    Private Sub txtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInput.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            Command = txtInput.Text
            e.Handled = True
            txtGame.Text = txtGame.Text & vbNewLine & "> " & Command
            txtInput.Text = ""
            CheckInput()
        End If
    End Sub

    Private Sub CheckInput()
        If Command = "new" Then
            txtGame.Text = txtGame.Text & vbNewLine & "Please choose a name for you character"
            part = 1
        End If
        'ERROR
        If part = 1 Then
            Name = Command
            txtGame.Text = txtGame.Text & vbNewLine & "Welcome " & Name
        End If
    End Sub
End Class
