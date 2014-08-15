Public Class Main
    Dim Log As String = "C:\Users\Evert\Documents\App Settings\IPLog\IPlog.txt"
    Dim LogContent As String
    'Dim Writer As System.IO.StreamWriter
    'Dim Reader As System.IO.StreamReader


    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If System.IO.File.Exists(Log) = False Then
            Dim Creator As New System.IO.StreamWriter(Log, False)
            Creator.Close()
        End If
        Label2.Visible = False
    End Sub

    Private Sub btnCompare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompare.Click

        Dim Reader As New System.IO.StreamReader(Log)
        LogContent = Reader.ReadToEnd()
        Reader.Close()
        If LogContent.Contains(TextBox1.Text) Then
            Label2.Visible = True
        Else
            Label2.Visible = False
            Dim Writer As New System.IO.StreamWriter(Log, True)
            Writer.WriteLine(TextBox1.Text)
            Writer.Close()
        End If
        


    End Sub
End Class
