Public Class Options

    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Main.AutoR = True Then
            checkbAutoReset.Checked = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If checkbAutoReset.Checked = True Then
            Main.AutoR = True
        Else
            Main.AutoR = False
        End If
        Me.Dispose()
    End Sub
End Class