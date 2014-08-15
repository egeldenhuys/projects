Public Class Form1
    Dim Pass As String
    Dim i As Integer
    Dim ResultAsc1, ResultAsc2, ResultAsc3, ResultAsc4, ResultAsc5, ResultAsc6, ResultAsc7 As Integer
    Dim ResultChr1, ResultChr2, ResultChr3, ResultChr4, ResultChr5, ResultChr6, ResultChr7 As String
    Dim Final As String
    'Dim RAsc() As Integer
    'Dim RChr() As String
    Dim l As Boolean
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        '*can't use Pass except to see if the final result is correct.
        'ASCII as initial result then to normal then compares to pass.
        '1. Start with ASCII 32.
        '2. Convert to Char
        '3. Compare to pass
        '4. If incorrect add 1 ASCII
        '5. Repeat, like a clock
        ' Try and use Arrays
        Pass = TextBox1.Text
        'ASCII 32 to 126
        ResultAsc1 = 32
        ResultAsc2 = 32
        ResultAsc3 = 32
        ResultAsc4 = 32
        ResultAsc5 = 32
        ResultAsc6 = 32
        ResultAsc7 = 32
        i = 0
        Do
            ResultAsc7 += 1
            If ResultAsc7 = 126 Then
                ResultAsc7 = 32
                ResultAsc6 += 1
            End If
            If ResultAsc6 = 126 Then
                ResultAsc6 = 32
                ResultAsc5 += 1
            End If
            If ResultAsc5 = 126 Then
                ResultAsc5 = 32
                ResultAsc4 += 1
            End If
            If ResultAsc4 = 126 Then
                ResultAsc4 = 32
                ResultAsc3 += 1
            End If
            If ResultAsc3 = 126 Then
                ResultAsc3 = 32
                ResultAsc2 += 1
            End If
            If ResultAsc2 = 126 Then
                ResultAsc2 = 32
                ResultAsc1 += 1
            End If
            'ResultAsc3 += 1
            'If ResultAsc3 = 126 Then
            'ResultAsc2 += 1
            'ResultAsc3 = 32
            'End If
            'If ResultAsc2 = 126 Then
            'ResultAsc1 += 1
            'ResultAsc2 = 32
            'End If
            ResultChr1 = Chr(ResultAsc1)
            ResultChr2 = Chr(ResultAsc2)
            ResultChr3 = Chr(ResultAsc3)
            ResultChr4 = Chr(ResultAsc4)
            ResultChr5 = Chr(ResultAsc5)
            ResultChr6 = Chr(ResultAsc6)
            ResultChr7 = Chr(ResultAsc7)
            Final = ResultChr1 & ResultChr2 & ResultChr3 & ResultChr4 & ResultChr5 & ResultChr6 & ResultChr7
        Loop Until Final = Pass

        If Final = Pass Then
            Label1.Text = "Your Password was: " & Pass
        End If

    End Sub

    Private Sub TimerFont_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFont.Tick
        

        If Label2.ForeColor = Color.Red Then
            Label2.ForeColor = Color.Black
        Else
            Label2.ForeColor = Color.Red
        End If
    End Sub
End Class
