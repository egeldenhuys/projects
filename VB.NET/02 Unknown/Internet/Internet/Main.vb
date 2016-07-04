Public Class Main
    'TODO:
    ' Make Received and sent data with options
    ' Make a real counter
    ' Make it so that if you press a button the menustrip opens
    ' Copy all other interfaces
    ' logo connecting animation
    ' Logo hover
    ' Publish application
    Dim S As Integer
    Dim M As Integer
    Dim H As Integer
    Dim Pressed As Boolean = True
    Dim Connected As Boolean = False
    Dim Options_Hover, Options_None, Details_None, Details_Hover, Details_Pressed, Logo_On, Logo_Off As Image

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Transparancy
        lblTime.Parent = BlueStrip
        lblTime.BackColor = Color.Transparent
        btnConnect.Parent = BlueStrip
        btnConnect.BackColor = Color.Transparent
        'Clearing labels
        lblStatus.Text = ""
        lblDataReceived.Text = ""
        lblDataSent.Text = ""
        lblIPAddress.Text = ""
        'Images
        Options_Hover = Internet.My.Resources.Resources.Options_Hover
        Options_None = Internet.My.Resources.Resources.Options_None
        Details_None = Internet.My.Resources.Resources.Details_None
        Details_Hover = Internet.My.Resources.Resources.Details_Hover
        Details_Pressed = Internet.My.Resources.Resources.Details_Pressed
        Logo_On = Internet.My.Resources.Resources.Logo_On
        Logo_Off = Internet.My.Resources.Resources.Logo_Off
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        If Connected = False Then
            pic_Logo_Frame.Image = Logo_On
            Connected = True
            btnConnect.Text = "Disconnect"
            GenerateIP()
        Else
            Connected = False
            pic_Logo_Frame.Image = Logo_Off
            btnConnect.Text = "Connect"
            lblTime.Text = "Not Connected"
            lblIPAddress.Text = ""
            S = 0
            M = 0
            H = 0
        End If

        If Timer1.Enabled = False Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub btnDisconect_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConnect.MouseHover
        lblStatus.Text = "Connect to Bigpond Wireless Broadband."
    End Sub

    Private Sub btnDisconect_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConnect.MouseLeave
        lblStatus.Text = ""
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        S = S + 1
        If S = 60 Then
            M = M + 1
            S = 0
        End If

        If M = 60 Then
            H = H + 1
            M = 0
        End If

        If M > 0 Then
            lblTime.Text = (M & " mins ") & (S & " secs")
            Timer1.Interval = 1000
        Else
            lblTime.Text = (S & " secs")
        End If

        If H > 0 Then
            lblTime.Text = (H & " hrs ") & (M & " mins")
            Timer1.Interval = 60000

        End If
    End Sub

    Private Sub GenerateIP()
        Dim Num As Integer

        Randomize()
        Num = (Int(5 * Rnd()) + 1)
        If Num = 1 Then
            lblIPAddress.Text = "121.218.208.47"
        ElseIf Num = 2 Then
            lblIPAddress.Text = "124.180.73.31"
        ElseIf Num = 3 Then
            lblIPAddress.Text = "185.123.95.13"
        ElseIf Num = 4 Then
            lblIPAddress.Text = "124.180.155.37"
        ElseIf Num = 5 Then
            lblIPAddress.Text = " 58.169.168.121"
        ElseIf Num = 6 Then
            lblIPAddress.Text = "66.249.67.255"
        ElseIf Num = 7 Then
            lblIPAddress.Text = "58.168.97.51"
        ElseIf Num = 8 Then
            lblIPAddress.Text = "124.185.78.76"
        ElseIf Num = 9 Then
            lblIPAddress.Text = "124.184.183.183"
        ElseIf Num = 10 Then
            lblIPAddress.Text = "203.51.76.48"

        End If
    End Sub

    Private Sub picOptions_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_Options_Frame.MouseEnter
        pic_Options_Frame.Image = Options_Hover
    End Sub

    Private Sub pic_Options_Frame_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_Options_Frame.MouseLeave
        pic_Options_Frame.Image = Options_None
        lblStatus.Text = ""
    End Sub

    Private Sub pic_Details_Frame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_Details_Frame.Click
        If Pressed = True Then
            Me.Height = 170
            Pressed = False
            pic_Details_Frame.Image = Details_Hover
        Else
            Me.Height = 237
            Pressed = True
            pic_Details_Frame.Image = Details_Pressed
        End If
    End Sub

    Private Sub pic_Details_Frame_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_Details_Frame.MouseEnter
        If Pressed = False Then
            pic_Details_Frame.Image = Details_Hover
        End If
    End Sub

    Private Sub pic_Details_Frame_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_Details_Frame.MouseHover
        lblStatus.Text = "Show or hide connection details."
    End Sub

    Private Sub pic_Details_Frame_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_Details_Frame.MouseLeave
        If Pressed = False Then
            pic_Details_Frame.Image = Details_None
        End If
        lblStatus.Text = ""
    End Sub

    Private Sub lblTime_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTime.MouseHover
        lblStatus.Text = "Shows the status of your connection to BigPond Wireless Broadband."
    End Sub

    Private Sub lblTime_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTime.MouseLeave
        lblStatus.Text = ""
    End Sub

    Private Sub pic_Options_Frame_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pic_Options_Frame.MouseHover
        lblStatus.Text = "Change Connection Manager settings."
    End Sub

    Private Sub pic_Options_Frame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic_Options_Frame.Click

    End Sub
End Class
