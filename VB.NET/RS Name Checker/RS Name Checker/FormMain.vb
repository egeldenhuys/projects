Imports System.Net
Imports System.IO

Public Class FormMain

    Dim WithEvents WC1 As New WebClient
    Dim WithEvents WC2 As New WebClient
    Dim WithEvents WC3 As New WebClient
    Dim WithEvents WC4 As New WebClient
    Dim WithEvents WC5 As New WebClient

    Dim FileVersion As String = "Version 1.0"
    Dim BaseUrl As String = "https://secure.runescape.com/m=account-" & _
        "creation/check_details.ajax?noNameSuggestions=true&displayname="

    Dim BaseUrl2 As String = "http://rscript.org/lookup.php?type=namecheck&name="
    Dim AvailableWord As String = "NAMECHECK: AVALIBLE"
    Dim SaveLocation As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData _
                                 & "\AvailableNames.txt"

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Reset()
        
        lblVersion.Text = FileVersion
    End Sub

    Private Sub btnCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnCheck.Click
        Reset()

        If TextBox1.Text <> "" Then
            If WC1.IsBusy = False Then
                WC1.DownloadStringAsync(New Uri(BaseUrl2 & TextBox1.Text))
            End If
        End If

        If TextBox2.Text <> "" Then
            If WC2.IsBusy = False Then
                WC2.DownloadStringAsync(New Uri(BaseUrl2 & TextBox2.Text))
            End If
        End If

        If TextBox3.Text <> "" Then
            If WC3.IsBusy = False Then
                WC3.DownloadStringAsync(New Uri(BaseUrl2 & TextBox3.Text))
            End If
        End If

        If TextBox4.Text <> "" Then
            If WC4.IsBusy = False Then
                WC4.DownloadStringAsync(New Uri(BaseUrl2 & TextBox4.Text))
            End If
        End If

        If TextBox5.Text <> "" Then
            If WC5.IsBusy = False Then
                WC5.DownloadStringAsync(New Uri(BaseUrl2 & TextBox5.Text))
            End If
        End If


    End Sub

#Region "WebClient Events"
    Private Sub WC1_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles WC1.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        ProgressBar1.Refresh()
    End Sub

    Private Sub WC1_DownloadCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles WC1.DownloadStringCompleted
        Label1.Visible = True

        ParseResult(e.Result, Label1)
    End Sub

    Private Sub WC2_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles WC2.DownloadProgressChanged
        ProgressBar2.Value = e.ProgressPercentage
        ProgressBar2.Refresh()
    End Sub

    Private Sub WC2_DownloadCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles WC2.DownloadStringCompleted
        Label2.Visible = True

        ParseResult(e.Result, Label2)
    End Sub

    Private Sub WC3_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles WC3.DownloadProgressChanged
        ProgressBar3.Value = e.ProgressPercentage
        ProgressBar3.Refresh()
    End Sub

    Private Sub WC3_DownloadCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles WC3.DownloadStringCompleted
        Label3.Visible = True

        ParseResult(e.Result, Label3)
    End Sub

    Private Sub WC4_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles WC4.DownloadProgressChanged
        ProgressBar4.Value = e.ProgressPercentage
        ProgressBar4.Refresh()
    End Sub

    Private Sub WC4_DownloadCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles WC4.DownloadStringCompleted
        Label4.Visible = True

        ParseResult(e.Result, Label4)
    End Sub

    Private Sub WC5_ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles WC5.DownloadProgressChanged
        ProgressBar5.Value = e.ProgressPercentage
        ProgressBar5.Refresh()
    End Sub

    Private Sub WC5_DownloadCompleted(sender As Object, e As DownloadStringCompletedEventArgs) Handles WC5.DownloadStringCompleted
        Label5.Visible = True

        ParseResult(e.Result, Label5)
    End Sub

#End Region

    Private Sub Reset()
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False

        ProgressBar1.Value = 0
        ProgressBar2.Value = 0
        ProgressBar3.Value = 0
        ProgressBar4.Value = 0
        ProgressBar5.Value = 0
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Reset()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub ParseResult(ByVal ResultStr As String, ByVal ResultLabel As Label)
        If ResultStr.Contains(AvailableWord) Then
            ResultLabel.ForeColor = Color.Green
            ResultLabel.Text = "Available"
        Else
            ResultLabel.Text = "Taken"
            ResultLabel.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        lblError.Visible = False

        Dim Writer As New StreamWriter(SaveLocation, True)

        If Label1.Text = "Available" Then
            Writer.WriteLine(TextBox1.Text)
        End If

        If Label2.Text = "Available" Then
            Writer.WriteLine(TextBox2.Text)
        End If

        If Label3.Text = "Available" Then
            Writer.WriteLine(TextBox3.Text)
        End If

        If Label4.Text = "Available" Then
            Writer.WriteLine(TextBox4.Text)
        End If

        If Label5.Text = "Available" Then
            Writer.WriteLine(TextBox5.Text)
        End If

        Writer.Close()

    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        lblError.Visible = False

        If File.Exists(SaveLocation) Then
            Process.Start(SaveLocation)
        Else
            lblError.Text = "No names have been saved yet"
            lblError.Visible = True
        End If

    End Sub
End Class
