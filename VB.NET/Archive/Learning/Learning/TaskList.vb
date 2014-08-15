Public Class TaskList

    Private Sub TaskList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FILE_NAME As String = "C:\Users\Evert\Desktop\App Settings\Task_List.txt"
        Dim Reader As New System.IO.StreamReader(FILE_NAME)
        TextBox1.Text = Reader.ReadToEnd
        Reader.Close()
        btnSave.Select()
        
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim FILE_NAME As String = "C:\Users\Evert\Desktop\App Settings\Task_List.txt"
        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)
        objWriter.Write(TextBox1.Text)
        objWriter.Close()
        Me.Close()
    End Sub
End Class