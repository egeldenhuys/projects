Imports System.Net
Imports System.ComponentModel

#Region "To-Do List"
' To-Do List
' Inside changeLog.txt
#End Region

Public Class frmMain

#Region "Variables"

    Dim TextOutput As String

    ' == Paths ==
    ' Note: Paths do not have a "\" at the end and needs to be added when used.
    Dim currentDir As String = Microsoft.VisualBasic.FileIO.FileSystem.CurrentDirectory
    Dim AppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim TrollFolderPath As String = AppDataPath & "\Troll Programs"
    Dim ProgramFolder As String = TrollFolderPath & "\Minecraft World backup"
    Dim _7zipFolder As String = TrollFolderPath & "\shared\7za920"

    ' == Settings ==
    Dim Worlds() As String
    Dim BackupInterval As Integer
    Dim SettingsSaved As Boolean = False
    Dim CompressWorlds As Boolean = True

    ' == Updates ==
    Dim LatestVersion As String = "0.0.0"
    Dim CurrentVersion As String = "1.4.2"
    Dim DoUpdateCheck As Boolean = True

    Dim WithEvents WCVersion As New WebClient ' Version Downlaoder
    Dim WithEvents WCProg As New WebClient ' Program downlaoder
    Dim WithEvents WC7zip As New WebClient ' 7zip

    ' -- URIs --
    Dim UriVersion As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20World%20Backup/version.txt")
    Dim UriDownload As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20World%20Backup/Minecraft%20World%20Backup.exe")

    ' == 7zip Downloads ==
    Private WithEvents _7zip As Process
    Dim _7zProgress As Integer = 1
    Dim _7z1 As New Uri("https://dl.dropbox.com/u/57022080/Programs/7za920/7za.exe")
    Dim _7z2 As New Uri("https://dl.dropbox.com/u/57022080/Programs/7za920/7-zip.chm")
    Dim _7z3 As New Uri("https://dl.dropbox.com/u/57022080/Programs/7za920/license.txt")
    Dim _7z4 As New Uri("https://dl.dropbox.com/u/57022080/Programs/7za920/readme.txt")

#End Region

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        InitializeProgram()

    End Sub

#Region "Buttons"

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click

        LoadWorlds()

    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        StartBackups()
    End Sub

    Private Sub btnBackupNow_Click(sender As System.Object, e As System.EventArgs) Handles btnBackupNow.Click

        If SettingsSaved = True Then

            If bgwBackup.IsBusy = False Then
                bgwBackup.RunWorkerAsync()
            End If

            SetStatus("Worlds have been backed up", Color.Orange)
        Else
            SetStatus("Save the settings first!", Color.Red)

        End If

    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click
        StopBackups()

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        SaveSettings()

    End Sub

    Private Sub btnConsoleToggle_Click(sender As System.Object, e As System.EventArgs) Handles btnConsoleToggle.Click

        If btnConsoleToggle.Text = "<" Then
            'Hide console
            Me.Width = 489
            btnConsoleToggle.Text = ">"

        Else
            'Show the console
            Me.Width = 923
            btnConsoleToggle.Text = "<"
        End If

    End Sub

    Private Sub tlsViewHelp_Click(sender As System.Object, e As System.EventArgs) Handles tlsViewHelp.Click

    End Sub

    Private Sub tlsChangeLog_Click(sender As System.Object, e As System.EventArgs) Handles tlsChangeLog.Click
        frmChangeLog.Show()

    End Sub

    Private Sub tlsCheckForUpdates_Click(sender As System.Object, e As System.EventArgs) Handles tlsCheckForUpdates.Click
        CheckForUpdate(False)

    End Sub

    Private Sub tlsForceUpdate_Click(sender As System.Object, e As System.EventArgs) Handles tlsForceUpdate.Click
        CheckForUpdate(True)

    End Sub

    Private Sub btnCheckUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckUpdate.Click
        CheckForUpdate(False)

    End Sub


    ' End Region "Buttons"
#End Region

#Region "Functions"

    Private Sub InitializeProgram()
        SetStatus("Initializing...", Color.Red)

        ' Toggle console
        Me.Width = 489
        btnConsoleToggle.Text = ">"

        ' Set the version labels
        lblCurVersion.Text = "Current version: " & CurrentVersion.ToString
        lblLatestVersion.Text = "Latest version:"

        CleanOldFiles()
        LoadWorlds()
        VerifyFiles()

        SetStatus("Ready", Color.Green)

        If DoUpdateCheck = True Then
            CheckForUpdate(False)
        End If

    End Sub

    Private Sub CheckForUpdate(Optional forceUpdate As Boolean = False)
        SetStatus("Checking for updates...", Color.Red)

        If bgwCheckForUpdate.IsBusy = False Then

            If forceUpdate = True Then
                bgwCheckForUpdate.RunWorkerAsync("True")

            Else
                bgwCheckForUpdate.RunWorkerAsync("False")
            End If

        End If

    End Sub

    Private Sub bgwCheckForUpdate_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwCheckForUpdate.DoWork

        Try

            GetLatestVersion()

            If e.Argument.ToString = "True" Then ' If ForceUpdate = True
                bgwCheckForUpdate.ReportProgress(4)

                Dim nameAvailable As Boolean = False
                Dim nameCounter As Integer = 1

                If My.Computer.FileSystem.FileExists(currentDir & "\Minecraft World Backup " & LatestVersion & ".exe") = True Then

                    Do While nameAvailable = False
                        If My.Computer.FileSystem.FileExists(currentDir & "\Minecraft World Backup " & LatestVersion & " (" & nameCounter & ").exe") = False Then
                            WCProg.DownloadFile(UriDownload, currentDir & "\Minecraft World Backup " & LatestVersion & " (" & nameCounter & ").exe")
                            System.Diagnostics.Process.Start(currentDir & "\Minecraft World Backup " & LatestVersion & " (" & nameCounter & ").exe")
                            bgwCheckForUpdate.ReportProgress(100)
                            nameAvailable = True
                        Else
                            nameCounter += 1
                        End If
                    Loop

                Else
                    WCProg.DownloadFile(UriDownload, currentDir & "\Minecraft World Backup " & LatestVersion & ".exe")
                    System.Diagnostics.Process.Start(currentDir & "\Minecraft World Backup " & LatestVersion & ".exe")
                    bgwCheckForUpdate.ReportProgress(100)
                End If


            Else ' If forceUpdate = False
                If CurrentVersion <> LatestVersion Then
                    bgwCheckForUpdate.ReportProgress(2) ' new update is available

                    dialogNewUpdate.ShowDialog()

                    If dialogNewUpdate.DialogResult = Windows.Forms.DialogResult.Yes Then ' The user agrees to update
                        bgwCheckForUpdate.ReportProgress(4)

                        WCProg.DownloadFile(UriDownload, currentDir & "\Minecraft World Backup " & LatestVersion & ".exe")
                        bgwCheckForUpdate.ReportProgress(5)

                        System.Diagnostics.Process.Start(currentDir & "\Minecraft World Backup " & LatestVersion & ".exe")
                        bgwCheckForUpdate.ReportProgress(100)

                    Else
                        bgwCheckForUpdate.ReportProgress(99)
                    End If

                Else
                    bgwCheckForUpdate.ReportProgress(3)
                End If
            End If

        Catch ex1 As WebException
            bgwCheckForUpdate.ReportProgress(98)

        Catch ex As Exception

            frmError.ShowError(ex.ToString)
        End Try

    End Sub

    Private Sub GetLatestVersion()

        LatestVersion = WCVersion.DownloadString(UriVersion)
        bgwCheckForUpdate.ReportProgress(1) ' Update version label

    End Sub

    Private Sub bgwCheckForUpdate_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwCheckForUpdate.RunWorkerCompleted

    End Sub

    Private Sub bgwCheckForUpdate_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwCheckForUpdate.ProgressChanged

        Select Case e.ProgressPercentage
            Case 1
                lblLatestVersion.Text = "Latest Version: " & LatestVersion

            Case 2
                SetStatus("There is a new version available", Color.Purple)

            Case 3
                SetStatus("You have the latest version", Color.Green)

            Case 4
                SetStatus("Downloading latest Version...", Color.Red)
                Me.Enabled = False

            Case 5
                Me.Enabled = True

            Case 98
                SetStatus("Could not connect to server!", Color.Red)

            Case 99
                SetStatus("Ready", Color.Green)

            Case 100
                Me.Close()

        End Select

    End Sub

    Private Sub StartBackups()
        If SettingsSaved = True Then

            lblStatus2.Text = "Status: ON"
            lblStatus2.ForeColor = Color.Green

            tmrBackup.Enabled = True
        Else

            SetStatus("Save the settings first!", Color.Red)
        End If
    End Sub

    Private Sub StopBackups()

        tmrBackup.Enabled = False

        lblStatus2.Text = "Status: OFF"
        lblStatus2.ForeColor = Color.Red

        SetStatus("Backups Stopped", Color.Red)

    End Sub

    Private Sub VerifyFiles()
        ' Create the directory where the 7zip files will be stored
        My.Computer.FileSystem.CreateDirectory(_7zipFolder)

        ' Check if 7zip has been downloaded before, if false download it.
        If My.Computer.FileSystem.FileExists(_7zipFolder & "\7za.exe") = False Then
            DownloadReqFiles()
        End If

    End Sub

    Private Sub DownloadReqFiles()
        Download7zip()

    End Sub

    Private Sub Download7zip()

        Me.Enabled = False
        MsgBox("Downloading 7zip. Click OK to start.", MsgBoxStyle.OkOnly, "Downloading 7zip.")

        Try
            WC7zip.DownloadFileAsync(_7z1, _7zipFolder & "\7za.exe")

        Catch ex1 As WebException
            MsgBox("Could not connect to server", MsgBoxStyle.Exclamation, "Error")

        Catch ex As Exception
            frmError.ShowError(ex.ToString)
        End Try

    End Sub

    Private Sub WC7zip_DownloadFinished(sender As Object, e As AsyncCompletedEventArgs) Handles WC7zip.DownloadFileCompleted

        _7zProgress += 1

        Select Case _7zProgress
            Case 2
                WC7zip.DownloadFileAsync(_7z2, _7zipFolder & "\7-zip.chm")

            Case 3
                WC7zip.DownloadFileAsync(_7z3, _7zipFolder & "\license.txt")

            Case 4
                WC7zip.DownloadFileAsync(_7z4, _7zipFolder & "\Readme.txt")

            Case 5
                MsgBox("Required files have been downloaded", MsgBoxStyle.OkOnly, "Files Downloaded")
                Me.Enabled = True
                _7zProgress = 1

        End Select

    End Sub

    Private Sub CleanOldFiles()
        ' Delete files from old versions

        Dim oldFiles() As String = {"7za.exe", "7-zip.chm", "license.txt", "7z Readme.txt"}

        For Each element In oldFiles
            If My.Computer.FileSystem.FileExists(element) Then
                My.Computer.FileSystem.DeleteFile(element)
            End If
        Next

    End Sub

    Private Sub SaveSettings()
        ' Make sure a world is selected before saving
        If lstWorlds.SelectedItems.Count <> 0 Then
            SetWorlds()
        Else
            SetStatus("No worlds are selected!", Color.Red)
            Exit Sub
        End If


        If txtInterval.Text <> "" Then ' The field should no be blank
            If txtInterval.Text <> "0" Then ' The field should not be 0

                Try
                    BackupInterval = CInt(txtInterval.Text) * 60000 ' Multiply by 60,000 to get minutes
                    tmrBackup.Interval = BackupInterval
                Catch ex1 As OverflowException
                    SetStatus("THE INTERVAL IS OVER NEIN THOUSAND!", Color.Red)
                    Exit Sub
                End Try

            Else ' If the value is 0
                SetStatus("The backup interval can not be 0!", Color.Red)
                Exit Sub
            End If

        Else ' If the field is blank
            SetStatus("Please enter a value into the interval textbox!", Color.Red)
            Exit Sub
        End If


        If chkCompress.Checked = True Then
            CompressWorlds = True
        Else
            CompressWorlds = False
        End If

        SettingsSaved = True
        SetStatus("Settings have been saved", Color.Green)

    End Sub

    Private Sub LoadWorlds()
        lstWorlds.Items.Clear()

        Dim folderCollection As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

        folderCollection = My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.CurrentDirectory, FileIO.SearchOption.SearchTopLevelOnly)

        For Each folder In folderCollection

            Select Case My.Computer.FileSystem.GetName(folder)
                Case "plugins"

                Case "config"

                Case "redpower"

                Case "mods"

                Case "Backups"

                Case "backups"

                Case "buildcraft"

                Case Else
                    lstWorlds.Items.Add(My.Computer.FileSystem.GetName(folder))
            End Select

        Next

    End Sub

    Private Sub SetWorlds()

        'Clear the array
        ReDim Worlds(lstWorlds.CheckedItems.Count - 1)

        ' For each checked item, add it to the worlds array
        For i As Integer = 0 To lstWorlds.CheckedItems.Count - 1
            Worlds(i) = lstWorlds.CheckedItems(i).ToString
        Next

    End Sub

    Private Sub BackupWorlds()

        ' Backup each world in the Worlds() array

        Dim worldSource As String
        Dim worldDest As String
        Dim timeStamp As String = GetTime()

        For Each worldName In Worlds
            worldSource = currentDir & "\" & worldName
            worldDest = currentDir & "\Backups\" & worldName & " " & timeStamp


            Try
                ' Compress worlds
                If CompressWorlds = True Then
                    '#txtConsole.AppendText("------ " & worldName & " (START) ------" & vbCrLf)

                    Dim tmpWorld As String = currentDir & "\Backups\tmpWorld\"
                    My.Computer.FileSystem.CopyDirectory(worldSource, tmpWorld, True)

                    Dim _7zip As New Process

                    With _7zip.StartInfo
                        .FileName = _7zipFolder & "\7za.exe"
                        .Arguments = ("a ") & ("""" & worldDest & ".zip" & """") & (" """ & tmpWorld & "*""")
                        .UseShellExecute = False
                        .CreateNoWindow = True
                        .RedirectStandardInput = False
                        .RedirectStandardOutput = True
                        .RedirectStandardError = True
                    End With

                    _7zip.Start()
                    Dim textLine As String = ""
                    TextOutput &= (_7zip.StartInfo.Arguments & vbCrLf)

                    While _7zip.StandardOutput.Peek <> -1

                        TextOutput &= _7zip.StandardOutput.ReadLine & vbCrLf

                        bgwBackup.ReportProgress(3)
                    End While


                    _7zip.WaitForExit()

                    My.Computer.FileSystem.DeleteDirectory(tmpWorld, FileIO.DeleteDirectoryOption.DeleteAllContents)

                    '#txtConsole.AppendText("------ " & worldName & " (END) ------" & vbCrLf)
                Else
                    ' Do not compress worlds.
                    Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(worldSource, worldDest & "\", True)
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next


    End Sub

    Private Function GetTime() As String
        Dim time, year, month, day, hour, minute, second As String

        year = Now.Year.ToString

        ' Month
        If Now.Month < 10 Then
            month = "0" & Now.Month.ToString
        Else
            month = Now.Month.ToString
        End If

        ' Days
        If Now.Day < 10 Then
            day = "0" & Now.Day.ToString
        Else
            day = Now.Day.ToString
        End If

        ' Hours
        If Now.Hour < 10 Then
            hour = "0" & Now.Hour.ToString
        Else
            hour = Now.Hour.ToString
        End If

        ' Minutes
        If Now.Minute < 10 Then
            minute = "0" & Now.Minute.ToString
        Else
            minute = Now.Minute.ToString
        End If

        ' Seconds
        If Now.Second < 10 Then
            second = "0" & Now.Second.ToString
        Else
            second = Now.Second.ToString
        End If

        time = year & "-" & month & "-" & day & " " & hour & minute & second

        Return time

    End Function

    Private Sub tmrBackup_Tick(sender As System.Object, e As System.EventArgs) Handles tmrBackup.Tick

        If bgwBackup.IsBusy = False Then
            bgwBackup.RunWorkerAsync()
        End If


    End Sub

    Private Sub SetStatus(ByVal strStatus As String, ByVal lblColour As Color)

        lblStatus.Text = strStatus
        lblStatus.ForeColor = lblColour

        tmrStatusReset.Enabled = False
        tmrStatusReset.Enabled = True

    End Sub

    Private Sub tmrStatusReset_Tick(sender As System.Object, e As System.EventArgs) Handles tmrStatusReset.Tick
        SetStatus("", Color.Green)

        tmrStatusReset.Enabled = False
    End Sub

    Private Sub txtInterval_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtInterval.TextChanged
        Dim AllowedChars As String = "0123456789"
        Dim theText As String = txtInterval.Text
        Dim Letter As String
        Dim SelectionIndex As Integer = txtInterval.SelectionStart
        Dim Change As Integer

        For x As Integer = 0 To txtInterval.Text.Length - 1
            Letter = txtInterval.Text.Substring(x, 1)
            If AllowedChars.Contains(Letter) = False Then

                SetStatus("Only numbers are allowed!", Color.Red)
                theText = theText.Replace(Letter, String.Empty)
                Change = 1
            End If
        Next

        txtInterval.Text = theText
        txtInterval.Select(SelectionIndex - Change, 0)


    End Sub

    'End Region "Functions"
#End Region

    Private Sub bgwBackup_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwBackup.DoWork
        bgwBackup.ReportProgress(1)
        BackupWorlds()
        bgwBackup.ReportProgress(2)
    End Sub

    Private Sub bgwBackup_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwBackup.ProgressChanged

        Select Case e.ProgressPercentage

            Case 1
                lblBackup.Visible = True

            Case 2
                lblBackup.Visible = False
                txtConsole.Text = TextOutput

            Case 3
                txtConsole.Text = TextOutput

        End Select


    End Sub
End Class
