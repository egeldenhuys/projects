Public Class Form1

    Dim fakes(9999999) As Integer
    Dim trigger As Integer
    Dim real As Double
    Dim trigger2 As Double

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ChangeValue()
    End Sub

    Private Sub btnChange_Click(sender As System.Object, e As System.EventArgs) Handles btnChange.Click
        ChangeValue()
    End Sub

    Private Sub ChangeValue()
        Dim rndNum As New Random

        If trigger = 100 Then
            MsgBox("Hacking Detected")
            Me.Close()

        End If

        If trigger2 = 100 Then
            MsgBox("Hacking Detected")
            Me.Close()
        End If

        If real = 100 Then
            Form2.Show()
        Else
            real = (rndNum.Next(0, 100))
            trigger = CInt(real)
            trigger2 = real

            For i As Integer = 0 To 9999999
                fakes(i) = CInt(real)
            Next

        End If

        lblValue.Text = CStr(real)
    End Sub

End Class
