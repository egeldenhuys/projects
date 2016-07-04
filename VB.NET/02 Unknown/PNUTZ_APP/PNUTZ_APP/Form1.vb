Imports PNUTZ
Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'CheckFiles()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim PNUTZFunctions As New PNUTZ.MyFunctions

        Label1.Text = PNUTZFunctions.MoodMessage
        PNUTZFunctions.TerminateProg(Me)
    End Sub

    Private Sub CheckFiles()
        If My.Computer.FileSystem.FileExists("PNUTZ.dll") = False Then
            MsgBox("Could not load PNUTZ.dll", MsgBoxStyle.Critical)
            Me.Close()
        End If
    End Sub
End Class
