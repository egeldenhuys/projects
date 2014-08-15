Imports System.Net
Imports System.IO

Public Class FormMain
    '# Notes #
    ' Read how many members are in "data = " and then divide by age size to get total 
    '       pages - will also remove the need to check for the next page.
    ' 
    '
    '
    '

    Dim Version As String = "0.01"
    Dim AppData As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\"
    Dim Content As String = ""
    'WebClients
    Dim WithEvents WebClient1 As New WebClient
    Dim Downloaded As Boolean = False

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblVersion.Text = "Version " & Version
        ' MsgBox(My.Computer.FileSystem.SpecialDirectories.ProgramFiles.ToString)

        SetStatus("Ready", Color.Green)
    End Sub

    Private Sub btnCreate_Click(sender As System.Object, e As System.EventArgs) Handles btnCreate.Click
        Dim clanName As String = tbClanName.Text

        clanName = Replace(clanName, " ", "+")

        DownloadSource("http://services.runescape.com/m=clan-hiscores/members.ws?&ranking=51&pageSize=45&clanName=" & clanName, "Rise Of The Knights.txt")
        SetStatus("Downloading", Color.Indigo)
    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click

    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub btnCheckUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckUpdate.Click

    End Sub

    Private Sub SetStatus(ByVal Value As String, ByVal Colour As Color)
        lblStatus.ForeColor = Colour
        lblStatus.Text = Value
    End Sub

    Private Sub DownloadSource(ByVal URI As String, ByVal Name As String)
        My.Computer.FileSystem.CreateDirectory(AppData & "\Sources")
        WebClient1.DownloadFileAsync(New Uri(URI), AppData & "Sources\" & Name)


    End Sub

    Private Sub WebClient1_DownloadProgressChanged(ByVal sender As Object, _
                                                   ByVal e As DownloadProgressChangedEventArgs) _
                                               Handles WebClient1.DownloadProgressChanged
        lblDownload.Text = e.ProgressPercentage.ToString & "%"

        If e.ProgressPercentage = 100 Then
            If Downloaded = False Then

                Downloaded = True
            End If
        End If

    End Sub
End Class
