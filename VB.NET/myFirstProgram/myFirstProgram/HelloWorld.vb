Public Class HelloWorld

    Private Sub btnDisplayHello_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayHello.Click
        lblHelloWorld.Text = "Hello World!"
    End Sub

    Private Sub btnTransferText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransferText.Click
        TransferLabel.Text = (TextBoxTransfer.Text) & (" and ") & (ExtraTextBox.Text)
    End Sub
End Class