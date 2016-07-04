Public Class FormRenameJar

    Dim OldJarName As String
    Dim Backup As Boolean


    Private Sub FormRenameJar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        If txtRenameJar.Text <> Nothing Then
            FormMain.RenameJar(OldJarName, txtRenameJar.Text, Backup)
            Me.Close()
        End If

    End Sub

    Public Sub SetOldName(ByVal name As String)
        OldJarName = name

    End Sub

    Public Sub SetBackupBool(ByVal isbackup As Boolean)
        Backup = isbackup
    End Sub

End Class