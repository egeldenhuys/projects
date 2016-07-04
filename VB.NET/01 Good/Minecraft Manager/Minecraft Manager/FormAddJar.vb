Public Class FormAddJar

    Dim Backup As Boolean

    Private Sub FormAddJar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        If txtJarNewName.Text <> Nothing Then
            FormMain.AddCurrentJar(txtJarNewName.Text, Backup)
            Me.Close()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Public Sub SetBackupBool(ByVal isBackup As Boolean)
        Backup = isBackup

    End Sub
End Class