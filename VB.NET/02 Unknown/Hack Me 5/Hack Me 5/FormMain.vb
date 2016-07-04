Public Class FormMain
    Dim Number As Integer
    Dim Code As String
    Dim Level As Integer = 1

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Code = FormActivate.GetCode()
        lblLevel.Text = "Level: " & CStr(Level)
    End Sub

    Private Sub btnChange_Click(sender As System.Object, e As System.EventArgs) Handles btnChange.Click
        Dim PageFlip As System.Media.SoundPlayer = New System.Media.SoundPlayer(Hack_Me_5.My.Resources.PageFlip)

        CheckNumber()

        Randomize()
        Number = CInt(Rnd() * 99)
        lblNumber.Text = CStr(Number)

        If chbSound.Checked = True Then
            PageFlip.Play()
        End If


    End Sub

    Private Sub CheckNumber()

        If Number = 100 Then
            lblCode.Visible = True
            lblCode.Text = Code
            btnChange.Enabled = False

        End If
    End Sub

    Private Sub lblHint_Click(sender As System.Object, e As System.EventArgs) Handles lblHint.Click
        MsgBox("Hint: The number will never be 100 without outside influence", MsgBoxStyle.Information, "Hint")
    End Sub
End Class