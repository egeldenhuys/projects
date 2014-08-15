Public Class Form1
    Dim Password As String
    Dim i As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        Password = TextBox1.Text
        TextBox2.Text = StringToAscii(Password)

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        
    End Sub
    Function StringToAscii(ByVal str)
        Dim result, x
        StringToAscii = ""
        If Len(str) = 0 Then Exit Function
        If Len(str) = 1 Then
            result = Asc(Mid(str, 1, 1))
            StringToAscii = ("000"(3 - Len(CStr(result))) & CStr(result))
            Exit Function
        End If
        result = ""
        For x = 1 To Len(str)
            result = result & StringToAscii(Mid(str, x, 1))
        Next
        StringToAscii = result
    End Function

    Function AsciiToString(ByVal str)
        Dim result, x
        AsciiToString = ""
        If Len(str) < 3 Then Exit Function
        If Len(str) = 3 Then
            AsciiToString = Chr(CInt(str))
            Exit Function
        End If
        result = ""
        For x = 1 To Len(str) Step 3
            result = result & AsciiToString(Mid(str, x, 3))
        Next
        AsciiToString = result
    End Function

End Class
