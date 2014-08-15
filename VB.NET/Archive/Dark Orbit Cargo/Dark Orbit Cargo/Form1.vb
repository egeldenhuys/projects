Public Class Form1
    Dim Capacity, Promerium, Seprom, Palladium, Send As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnCalculate.Enabled = False
        boxPaladium.Focus()
    End Sub

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Capacity = boxCapacity.Text
        Promerium = boxPromerium.Text
        Seprom = boxSeprom.Text
        Palladium = boxPaladium.Text

        Send = Capacity - (Promerium + Seprom + Palladium)
        boxSend.Text = Send
        boxSend.Focus()
    End Sub

    Private Sub cboxSent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxSent.CheckedChanged
        If cboxSent.Checked = True Then
            btnCalculate.Enabled = True
        Else
            btnCalculate.Enabled = False
        End If
    End Sub
End Class
