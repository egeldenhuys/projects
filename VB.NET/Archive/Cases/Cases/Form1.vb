Public Class Form1
    Dim Answer As String
    Dim State As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblState.Visible = False
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Answer = TextBox.Text
        Answer.ToLower()
        Select Case Answer
            Case "it"
                State = "Correct"
            Case "john"
                State = "yes, my cat's name is John"
            Case Else
                State = "Unknown Command"
        End Select
        lblState.Visible = True
        lblState.Text = State

    End Sub
End Class
