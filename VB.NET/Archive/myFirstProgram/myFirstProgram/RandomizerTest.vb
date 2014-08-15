Public Class RandomizerTest

    Dim letters As String = boxLetters.Text

    Private Sub RandomizerTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnRandomize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRandomize.Click
        Encode(str:=letters)
        boxRandomized.Text = letters

    End Sub

    Private Function Encode(ByVal str As String) As Byte()

        Return System.Text.Encoding.Unicode.GetBytes(str)

    End Function
End Class
