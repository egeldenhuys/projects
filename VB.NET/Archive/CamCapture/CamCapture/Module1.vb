Imports System.Timers
Imports System.Net

Module Module1

    Dim aTimer As New Timer
    Dim wc As New WebClient
    Dim i As Integer = 1

    Sub Main()
        Dim a As New NetworkCredential
        a.UserName = "admin"
        a.Password = ""

        wc.Credentials = a

        AddHandler aTimer.Elapsed, AddressOf OnTimedEvent
        ' Set the Interval to 5 seconds.
        aTimer.Interval = 1000
        aTimer.Enabled = True

        While True
            Console.ReadKey()
        End While

    End Sub

    Private Sub OnTimedEvent(source As Object, e As ElapsedEventArgs)
        wc.DownloadFile("http://192.168.1.82:45000/snapshot.cgi?1364722927798", i & ".jpg")
        i += 1
        Console.WriteLine("Downloaded image: " & i)
    End Sub

End Module
