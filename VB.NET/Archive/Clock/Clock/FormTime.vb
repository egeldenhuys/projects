Public Class FormTime
    Dim iSecondsDisplay As Boolean = True
    Dim iHour, iMinute, iSecond As Integer
    Dim DN As String = ""

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblTime.Text = GetTime()

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = GetTime()

    End Sub

    Private Function GetTime() As String
        iHour = TimeOfDay.Hour
        iMinute = TimeOfDay.Minute
        iSecond = TimeOfDay.Second

        ' Convert hours to 12 hour Time

        If iHour >= 13 Then
            iHour -= 12
            DN = "PM"
        Else
            DN = "AM"
        End If

        ' Convert to 12 hour time
        If iHour = 0 Then
            iHour = 12
        End If

        ' Add extra 0 infront of 1 digit numbers and display them
        If iMinute < 10 Then
            ' If less than 10 minutes
            Return (iHour & ":" & "0" & iMinute & " " & DN)
        Else

            'If more than 10 hours and more than 10 minutes
            Return (iHour & ":" & iMinute & " " & DN)
        End If


    End Function
End Class
