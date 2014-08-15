Public Class Form1
    Dim i As Integer
    Dim n1, n2, n3 As Integer
    Dim Result As String
    Dim max As Integer = 10
    Dim Count As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Randomize()
        i = 0
        Count = 0
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        'TimerMain.Enabled = True
        Label1.Text = "Working..."
        Do Until Count = 1000
            n1 = Int(max * Rnd())
            n2 = Int(max * Rnd())
            n3 = Int(max * Rnd())
            i += 1
            If n2 = n1 Then
                If n2 = n3 Then
                    Result = "Number: " & n1 & vbNewLine & "Times Tried: " & i & vbNewLine & vbNewLine
                    'Label1.Text = Result
                    i = 0
                    TextBox1.Text = TextBox1.Text & Result
                    Count += 1
                End If
            End If
        Loop


    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        TimerMain.Enabled = False
        Label1.Text = "Ready"
    End Sub

    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick
        n1 = Int(max * Rnd())
        n2 = Int(max * Rnd())
        n3 = Int(max * Rnd())
        i += 1
        If n2 = n1 Then
            If n2 = n3 Then
                Result = "Number: " & n1 & vbNewLine & "Times Tried: " & i & vbNewLine & vbNewLine
                'Label1.Text = Result
                i = 0
                TextBox1.Text = TextBox1.Text & Result
            End If
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        i = 0
        Label1.Text = "Ready"
        TextBox1.Text = ""
    End Sub
End Class
