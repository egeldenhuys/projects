Imports System.Net
Imports System.IO
Imports System.ComponentModel

Public Class FormActivate
    Dim WithEvents WC As New WebClient

    Dim AppActivated As Boolean = False
    Dim Version As String = "1.2"
    Dim LatestVersion As String
    Dim ChangeLog As String
    Dim Code As String
    Dim _Enabled As String
    Dim SaveLocation As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Updates\"

    Dim Website As String = ",.=,,:,,:,,-.;`.='.=',.,,.'.;:,,~.;,," & _
        "-,.~`,-,,.,.;.,-,.;',..,,-.;:,--,.:,.:,.:.;-.;,,.:,-.,,<,," & _
        "<,,~,,..~`,-,,-.,.-,.:.;:,.,,.',.',.-.~`.;-.;-.=:.~~,,,,.~" & _
        ",,',,`.=:.~~,,,,.~.='.'-.~'.~~,.'.~;.'',.,.~;.;<.=:,.=,,:,.~,.`"

    Dim LatestUrl As String = ",.=,,:,,:,,-.;`.='.=',..,.`.=:,..,,=,," & _
        ",,,-.~`,,,,-..=:.~~,,,,.~.=',,'.='.;;.=`.=~.;'.;,.;<.;-.;'.='." & _
        ":;,,-,,-,.`,.;.~~.~',,:,.;,,,,,.,,;.='.'-.~'.~~,.'.<'.;..=`.'',.,.<'.;..=`.;<.=:,.,,-.,.,"

    Dim StartCode As String = ".:..<<.=;.=;.<-.`<,,:.~',,=,,:.<-.`:.~',.`,,',.,,,;.<-.=;.=;.:-"
    Dim EndCode As String = ".:..<<.=;.=;.<-.:~,,.,...<-.`:.~',.`,,',.,,,;.<-.=;.=;.:-"

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BackgroundWorker1.WorkerReportsProgress = True
        lblVersion.Text = "v" & Version

        Me.Width = 192
        Me.Height = 91

        My.Computer.FileSystem.CreateDirectory(SaveLocation)
    End Sub

    Private Sub btnActivate_Click(sender As System.Object, e As System.EventArgs) Handles btnActivate.Click
        txtChangeLog.Text = ChangeLog

        If AppActivated = False Then

            BackgroundWorker1.RunWorkerAsync()
            txtChangeLog.Text = ChangeLog
            AppActivated = True
            btnActivate.Text = "Loading"
        End If


    End Sub

    ' This event handler is where the time-consuming work is done.
    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        DownloadInfo()
    End Sub

    ' This event handler deals with the results of the background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, _
    ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            'canceled
        ElseIf e.Error IsNot Nothing Then
            'Error
        Else
            If _Enabled = "True" Then
                AssignInfo()
                Me.Width = 460
                Me.Height = 290
            ElseIf _Enabled = "Failed" Then
                MsgBox("Unable to connect to server", MsgBoxStyle.Critical, "Error")
                btnActivate.Text = "Activate"
                AppActivated = False
            Else
                MsgBox("You are not authorised to use this application", MsgBoxStyle.Exclamation, "Not Authorised")
                Me.Close()
            End If

        End If
    End Sub

    Private Sub AssignInfo()
        btnActivate.Text = "Refresh"
        btnActivate.ForeColor = Color.Green
        txtChangeLog.Text = ChangeLog

        If LatestVersion <> Version Then
            lblNewVersion.Visible = True
            btnUpdate.Visible = True
            btnContinue.Visible = False
        Else
            lblNewVersion.Visible = False
        End If

    End Sub

    Private Sub DownloadInfo()
        Dim Substrings() As String
        Dim client As New WebClient()
        Dim Done As Boolean = False
        Dim ValuesFound As Boolean = False


        ' Add a user agent header in case the 
        ' requested URI contains a query.
        ' client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
        Try
            Dim Data As Stream = client.OpenRead(Decrypt(Website))
            Dim Reader As New StreamReader(Data)
            Dim Content As String = ""

            Do While Done = False

                Content = Reader.ReadLine

                If Content = Decrypt(EndCode) Then
                    ValuesFound = False
                    Done = True
                End If

                If ValuesFound = True Then
                    Content = Replace(Content, "<p>", "")
                    Content = Replace(Content, "</p>", "")
                    Content = Replace(Content, "&lt;", "<")

                    Content = Decrypt(Content)
                    Substrings = Split(Content, "=")

                    Select Case Substrings(0)
                        Case "Code"
                            Code = Substrings(1)
                        Case "Latest Version"
                            LatestVersion = Substrings(1)
                        Case "Change Log"
                            ChangeLog = Substrings(1)
                        Case "Enabled"
                            _Enabled = Substrings(1)
                    End Select
                End If

                If Content = Decrypt(StartCode) Then
                    ValuesFound = True
                End If

            Loop

        Catch ex1 As System.Net.WebException
            
            _Enabled = "Failed"

        End Try
    End Sub

    Private Function Decrypt(str As String) As String

        Dim Result2 As String = ""
        Dim ResultA2 As String = ""
        Dim strTmp As String

        str = str.Replace(".", "0")
        str = str.Replace(",", "1")
        str = str.Replace("-", "2")
        str = str.Replace("<", "3")
        str = str.Replace("=", "4")
        str = str.Replace(";", "5")
        str = str.Replace(":", "6")
        str = str.Replace("'", "7")
        str = str.Replace("`", "8")
        str = str.Replace("~", "9")


        For i = 1 To (Len(str) / 3)
            'removes all but the first 3 ascii numbers
            If Len(str) = 3 Then
                strTmp = str
            Else
                strTmp = str.Substring(0, 3)
            End If
            'strTmp = str.Remove((0 + 3), (Len(str) - 3))
            'debugging
            'Label2.Text = strTmp
            'converts ascii to char
            If strTmp.StartsWith("0") Then
                strTmp = strTmp.Remove(0, 1)
            End If
            Result2 = Chr(CInt(strTmp))
            'adds all chars together
            ResultA2 = ResultA2 & Result2
            'removes first 3 converted ascii numbers
            str = str.Remove(0, 3)
        Next

        Return ResultA2
    End Function

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        lblDownloadStatus.Visible = True
        prgbDownload.Visible = True

        WC.DownloadFileAsync(New Uri(Decrypt(LatestUrl)), SaveLocation & "Hack Me 5 " & "v" & LatestVersion & ".exe")

    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        lblDownloadStatus.Text = Math.Round((e.BytesReceived / 1024), 2) & " kb" & "/" & Math.Round((e.TotalBytesToReceive / 1024), 2) & " kb"
        prgbDownload.Value = e.ProgressPercentage

        If e.ProgressPercentage = 100 Then
            MsgBox("The latest Hack Me 5 has been downloaded to " & SaveLocation, MsgBoxStyle.OkOnly, "Download Complete")
            Process.Start("explorer.exe", SaveLocation)

            Me.Close()

        End If
    End Sub

    Private Sub btnContinue_Click(sender As System.Object, e As System.EventArgs) Handles btnContinue.Click

        FormMain.Show()

        Me.Close()

    End Sub

    Public Function GetCode() As String
        Dim _Code As String = Code

        Return _Code
    End Function
End Class