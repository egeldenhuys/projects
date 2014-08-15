Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        fbSource.SelectedPath = My.Computer.FileSystem.CurrentDirectory.ToString
        fbDest.SelectedPath = My.Computer.FileSystem.CurrentDirectory.ToString
        txtDest.Text = My.Computer.FileSystem.CurrentDirectory.ToString
        txtSource.Text = My.Computer.FileSystem.CurrentDirectory.ToString
    End Sub

    Private Sub btnSource_Click(sender As System.Object, e As System.EventArgs) Handles btnSource.Click
        Dim result As DialogResult = fbSource.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            txtSource.Text = fbSource.SelectedPath
        End If

    End Sub

    Private Sub btnDest_Click(sender As System.Object, e As System.EventArgs) Handles btnDest.Click
        Dim result As DialogResult = fbDest.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            txtDest.Text = fbDest.SelectedPath
        End If

    End Sub

    Private Sub btnCopy_Click(sender As System.Object, e As System.EventArgs) Handles btnCopy.Click
        Dim folderSource As String = txtSource.Text
        Dim folderDest As String = txtDest.Text

        folderDest &= "\" & My.Computer.FileSystem.GetName(folderSource)

        My.Computer.FileSystem.CopyDirectory(folderSource, folderDest, False)
    End Sub

    Private Function GetTime() As String
        Dim time As String

        Dim timeMinutes As String = Now.Minute.ToString

        If Now.Minute < 10 Then
            timeMinutes = "0" & Now.Minute.ToString
        End If

        time = Now.Year.ToString & "-" & Now.Month.ToString & "-" & Now.Day.ToString & " " & Now.Hour.ToString & timeMinutes

        Return time
    End Function
End Class
