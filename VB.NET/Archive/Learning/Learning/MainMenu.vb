Public Class formMainMenu

    Private Sub btnToPart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToPart1.Click
        formPart1.Show()
    End Sub

    Private Sub btnToPart2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnToPart2.Click
        formPart2.Show()
    End Sub

    Private Sub btnTaskList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaskList.Click
        TaskList.Show()
    End Sub

    Private Sub lblLinkTutorial_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

    End Sub
    
End Class
