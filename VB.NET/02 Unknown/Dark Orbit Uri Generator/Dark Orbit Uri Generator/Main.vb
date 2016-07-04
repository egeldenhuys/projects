Public Class Main
    Dim i As Integer
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        i = 0
        lblStatus.Text = ""
        ProgressBar.Minimum = 0
        ProgressBar.Maximum = 700
        Progress.Interval = 1
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Progress.Enabled = True
        TimerConnect.Interval = 1500
        TimerConnect.Enabled = True
        lblStatus.Text = "Connecting to DarkOrbit Database..."
    End Sub

    Private Sub TimerConnect_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerConnect.Tick
        i = i + 1
        If i = 1 Then
            lblStatus.Text = "Searching for Username..."
            TimerConnect.Interval = 5000
        ElseIf i = 2 Then
            lblStatus.Text = "Downloading User Profile..."
            TimerConnect.Interval = 1000
        ElseIf i = 3 Then
            lblStatus.Text = "Decrypting User Profile..."
            TimerConnect.Interval = 4000
        ElseIf i = 4 Then
            lblStatus.Text = "Ready"
            lblDesc3.Enabled = True
            boxUridium.Enabled = True
            btnSet.Enabled = True
            TimerConnect.Enabled = False
            ProgressBar.Value = 0
        ElseIf i = 5 Then
            lblStatus.Text = "Changing Uridium amount..."
            TimerConnect.Interval = 500
        ElseIf i = 6 Then
            lblStatus.Text = "Encrypting User Profile..."
            TimerConnect.Interval = 4000
        ElseIf i = 7 Then
            lblStatus.Text = "Submitting User Profile..."
            TimerConnect.Interval = 1000
        ElseIf i = 8 Then
            lblStatus.Text = "Done..."
            TimerConnect.Interval = 1000
        ElseIf i = 9 Then
            lblStatus.Text = "Destroying all evidence..."
            TimerConnect.Interval = 1000
        ElseIf i = 10 Then
            lblStatus.Text = "Done"
            TimerConnect.Enabled = False
            ProgressBar.Value = 0
        End If
    End Sub

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        lblStatus.Text = "Changing Uridium amount..."
        TimerConnect.Interval = 500
        TimerConnect.Enabled = True
        ProgressBar.Maximum = 480
        Progress.Enabled = True
    End Sub

    Private Sub Progress_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Progress.Tick
        ProgressBar.Value = (ProgressBar.Value) + 1
        If ProgressBar.Value = (ProgressBar.Maximum) Then
            Progress.Enabled = False
        End If
    End Sub
End Class
