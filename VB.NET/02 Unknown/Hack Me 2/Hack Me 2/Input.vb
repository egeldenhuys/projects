Public Class Input

    Private Sub Input_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        CompareNames(TextBox1.Text)
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub CompareNames(ByVal Name As String)
        Dim sComputerName As String = My.Computer.Name.ToString.ToLower
        Name = Name.ToLower

        If Name = sComputerName Then
            MsgBox("Correct", MsgBoxStyle.OkOnly, "Question")


            Main.lblCode.Visible = True
            Main.lblHidden.Visible = True
            Main.btnTest.Visible = False
            Main.Width = 484
        Else
            MsgBox("WRONG", MsgBoxStyle.OkOnly, "Question")
        End If
    End Sub

End Class