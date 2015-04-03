Public Class Form1

   
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim fullText As String = RichTextBox1.Text

        Dim rawLines() As String = SplitLines(fullText)

        For Each line In rawLines
            RichTextBox2.AppendText(line & " END" & Environment.NewLine)
        Next

        RichTextBox2.AppendText("Done")
    End Sub

    Private Function HtmlTableToArray(ByRef rawLines() As String) As String()


    End Function

    Private Function SplitLines(ByRef fullText As String) As String()
        Dim tmpResult As New List(Of String)
        Dim foundEnd As Boolean = False
        Dim curCharPos As Integer = 0
        Dim lastCharPos As Integer = 0
        Dim endFound As Boolean = False
        Dim i As Integer = 0
        Dim textLength As Integer = fullText.Length

        While endFound = False

            If Asc(fullText(curCharPos)) = 10 Then
                ' Add the text before the new line to the array
                tmpResult.Add(fullText.Substring(lastCharPos, curCharPos))
                ' Remove the text we just added.
                fullText = fullText.Remove(0, curCharPos)
                ' Reset counters, as the string length has changed.
                curCharPos = 0
                lastCharPos = 0
            End If

            curCharPos += 1
            i += 1

            If i = textLength - 1 Then
                endFound = True
            End If

        End While

        Dim result(tmpResult.Count - 1) As String

        ' Convert the list to an array.
        For counter As Integer = 0 To tmpResult.Count - 1
            result(counter) = tmpResult.Item(counter)
        Next

        Return result
    End Function
End Class
