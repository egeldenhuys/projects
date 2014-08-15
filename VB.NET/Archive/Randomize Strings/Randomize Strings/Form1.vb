Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        listResults.Items.Clear()
        GenRandomStrings()
    End Sub

    Private Sub GenRandomStrings()
        Dim Amount As Integer = CInt(tbAmount.Text)
        Dim Length As Integer = CInt(tbLength.Text)
        Dim Characters As String = tbCharacters.Text
        Dim ChrLength As Integer = Characters.Length
        Dim ChrArray(0 To Characters.Length) As String
        Dim Line As String = ""
        Dim RndNum As Integer
        Characters.ToCharArray()


        Randomize()

        For AmountCounter As Integer = 1 To Amount
            For LengthCounter As Integer = 1 To Length
                RndNum = CInt(ChrLength * Rnd())
                If RndNum = ChrLength Then
                    RndNum -= 1
                End If
                Line &= Characters(RndNum)
            Next
            listResults.Items.Add(Line)
            Line = ""
        Next
    End Sub
End Class
