Imports System.IO
Imports System.Net
Imports System.ComponentModel

Public Class FormMain


    ' Note: Paths do not have a "\" at the end and needs to be added when used
    ' Paths
    Dim AppDataPath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim TrollFolderPath As String = AppDataPath & "\Troll Programs"
    Dim MCBinFolderPath As String = AppDataPath & "\.minecraft\bin"
    Dim JarFolderPath As String = TrollFolderPath & "\Minecraft Manager\Jars"
    Dim JarBackupFolderPath As String = TrollFolderPath & "\Minecraft Manager\Backups"
    Dim ProgramFolder As String = TrollFolderPath & "\Minecraft Manager"

    Dim DisplayBackups As Boolean = False

    Dim CurrentVersion As Single = 0.3
    Dim LatestVersion As Single = 0.0

    ' Updating
    Dim WithEvents WC1 As New WebClient
    Dim VersionUri As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20Manager/version.txt")
    Dim DownloadUri As New Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20Manager/Minecraft%20Manager.exe")
    Dim DownloadedPath As String

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Initialize program
        CreateDirectories()
        LoadJars()
        FolderBrowserDialog1.Description = "Select download location."
        GetLatestVersion()
        lblVersion.Text = "Current Version: " & CurrentVersion
        lblLatestVer.Text = "Latest Version: Checking..."


    End Sub

    Private Sub CreateDirectories()
        ' Create directories for saving and reading files

        If My.Computer.FileSystem.DirectoryExists(JarFolderPath) = False Then
            My.Computer.FileSystem.CreateDirectory(JarFolderPath)
        End If

        If My.Computer.FileSystem.DirectoryExists(JarBackupFolderPath) = False Then
            My.Computer.FileSystem.CreateDirectory(JarBackupFolderPath)
        End If

    End Sub

    Private Sub LoadJars()

        lstJars.Items.Clear()
        Dim jarInfo As FileInfo

        If DisplayBackups = False Then
            ' Get the name of each file in the jars folder and add it to the list box
            For Each jar In My.Computer.FileSystem.GetFiles(JarFolderPath)
                jarInfo = My.Computer.FileSystem.GetFileInfo(jar)

                lstJars.Items.Add(RemoveExt(jarInfo.Name))
            Next

        Else
            For Each jar In My.Computer.FileSystem.GetFiles(JarBackupFolderPath)
                jarInfo = My.Computer.FileSystem.GetFileInfo(jar)

                lstJars.Items.Add(RemoveExt(jarInfo.Name))
            Next

        End If

    End Sub

    Private Function RemoveExt(ByVal fileName As String) As String
        Dim finalName As String = ""

        finalName = fileName.Remove(fileName.Length - 4, 4)


        Return finalName
    End Function

    Public Sub AddCurrentJar(ByVal jarName As String, ByVal Backup As Boolean)
        ' This sub is called from the Addjar form.

        If Backup = False Then

            ' Check if the jar already exists
            If jarExists(jarName, False) = False Then
                ' Copy to jars folder
                If NameIsValid(jarName) = True Then
                    My.Computer.FileSystem.CopyFile(MCBinFolderPath & "\minecraft.jar", JarFolderPath & "\" & jarName & ".jar")
                Else
                    SetStatus("Name contains illigal characters!", Color.Red)
                End If


            Else
                SetStatus("Jar already exists with that name", Color.Red)
            End If

        Else ' backup is true

            ' Check if the jar already exists
            If jarExists(jarName, True) = False Then
                ' Copy to backup folder
                If NameIsValid(jarName) = True Then
                    My.Computer.FileSystem.CopyFile(MCBinFolderPath & "\minecraft.jar", JarBackupFolderPath & "\" & jarName & ".jar")
                Else
                    SetStatus("Name contains illigal characters!", Color.Red)
                End If

            Else
                SetStatus("Jar already exists with that name", Color.Red)
            End If

        End If

        LoadJars()

    End Sub

    Private Function NameIsValid(ByVal jarName As String) As Boolean
        Dim result As Boolean = True

        If jarName.Contains("\") Then
            result = False
        End If

        If jarName.Contains("/") Then
            result = False
        End If

        If jarName.Contains("*") Then
            result = False
        End If

        If jarName.Contains("?") Then
            result = False
        End If

        If jarName.Contains("""") Then
            result = False
        End If

        If jarName.Contains("<") Then
            result = False
        End If

        If jarName.Contains(">") Then
            result = False
        End If

        If jarName.Contains("|") Then
            result = False
        End If

        If jarName.Contains(":") Then
            result = False
        End If


        Return result

    End Function

    Private Sub ReplaceJar(ByVal jarName As String)

        If DisplayBackups = False Then
            ' Copt to bin from jars folder
            My.Computer.FileSystem.CopyFile(JarFolderPath & "\" & jarName & ".jar", MCBinFolderPath & "\minecraft.jar", True)

        Else
            ' Copy from backups folder
            My.Computer.FileSystem.CopyFile(JarBackupFolderPath & "\" & jarName & ".jar", MCBinFolderPath & "\minecraft.jar", True)
        End If


    End Sub

    Private Sub GetLatestVersion()
        SetStatus("Checking for update...", Color.Orange)
        WC1.DownloadStringAsync(VersionUri)
    End Sub

    Private Sub WC1_VersionCheckFinished(sender As Object, e As DownloadStringCompletedEventArgs) Handles WC1.DownloadStringCompleted
        LatestVersion = CSng(e.Result)

        lblLatestVer.Text = "Latest Version: " & LatestVersion

        CompareVersions()
    End Sub

    Private Sub WC1_UpdateDownloadFinished(sender As Object, e As AsyncCompletedEventArgs) Handles WC1.DownloadFileCompleted
        System.Diagnostics.Process.Start(DownloadedPath)
        Me.Close()

    End Sub

    Private Sub CompareVersions()
        If CurrentVersion < LatestVersion Then
            btnUpdate.Visible = True
            lblNewVersion.Visible = True
            SetStatus("There is a new version available!", Color.Purple)
            tmrNewVersion.Enabled = True
        Else
            SetStatus("You have the latest version.", Color.Purple)
        End If
    End Sub

    Private Sub DownloadUpdate()
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            SetStatus("Downloading update", Color.Red)
            Me.Enabled = False
            WC1.DownloadFileAsync(DownloadUri, FolderBrowserDialog1.SelectedPath.ToString & "\Minecraft Manager " & LatestVersion & ".exe")
            DownloadedPath = FolderBrowserDialog1.SelectedPath.ToString & "\Minecraft Manager " & LatestVersion & ".exe"
        End If


    End Sub

    Private Sub btnAddCurrentJar_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCurrentJar.Click
        FormAddJar.Show()
        FormAddJar.SetBackupBool(False)

    End Sub

    Private Sub DeleteJar(ByVal jarName As String)
        If DisplayBackups = False Then
            My.Computer.FileSystem.DeleteFile(JarFolderPath & "\" & jarName & ".jar")

        Else
            My.Computer.FileSystem.DeleteFile(JarBackupFolderPath & "\" & jarName & ".jar")

        End If


    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

        If lstJars.SelectedIndex <> -1 Then
            DeleteJar(lstJars.SelectedItem.ToString)
            LoadJars()
        End If

    End Sub

    Public Sub RenameJar(ByVal currentName As String, ByVal newName As String, ByVal isBackup As Boolean)
        ' This sub is called from the rename jar form

        If isBackup = False Then

            ' Check if the jar already exists
            If jarExists(newName, False) = False Then
                My.Computer.FileSystem.RenameFile(JarFolderPath & "\" & currentName & ".jar", newName & ".jar")
            Else
                SetStatus("Jar already exists with that name", Color.Red)

            End If

        Else

            ' Check if the jar already exists in the backup folder
            If jarExists(newName, True) = False Then
                My.Computer.FileSystem.RenameFile(JarBackupFolderPath & "\" & currentName & ".jar", newName & ".jar")
            Else
                SetStatus("Jar already exists with that name", Color.Red)
            End If

        End If

        LoadJars()

    End Sub

    Private Sub btnRename_Click(sender As System.Object, e As System.EventArgs) Handles btnRename.Click

        If lstJars.SelectedIndex <> -1 Then
            FormRenameJar.Show()
            FormRenameJar.SetOldName(lstJars.SelectedItem.ToString)
            FormRenameJar.SetBackupBool(DisplayBackups)
        End If

    End Sub

    Private Sub btnReplace_Click(sender As System.Object, e As System.EventArgs) Handles btnReplace.Click

        If lstJars.SelectedIndex <> -1 Then
            ReplaceJar(lstJars.SelectedItem.ToString)
            SetStatus("Jar has been replaced.", Color.Orange)
        End If

    End Sub

    Private Sub btnToggleJarsDisplayed_Click(sender As System.Object, e As System.EventArgs) Handles btnToggleJarsDisplayed.Click

        If btnToggleJarsDisplayed.Text = "Show Backups" Then
            ' If the current text is "Show Backups"
            lblJarsDisplayed.Visible = True
            DisplayBackups = True
            btnToggleJarsDisplayed.Text = "Hide Backups"
        Else
            ' If the current text is "Hide Backups"
            lblJarsDisplayed.Visible = False
            btnToggleJarsDisplayed.Text = "Show Backups"
            DisplayBackups = False
        End If

        LoadJars()
    End Sub

    Private Sub btnCreateBackup_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateBackup.Click
        FormAddJar.Show()
        FormAddJar.SetBackupBool(True)

    End Sub

    Private Sub SetStatus(ByVal status As String, ByVal statusColour As Color)
        lblStatus.Text = status
        lblStatus.ForeColor = statusColour

        StatusTimer.Enabled = True
    End Sub

    Private Function jarExists(ByVal jarName As String, ByVal isBackup As Boolean) As Boolean

        If isBackup = False Then

            If My.Computer.FileSystem.FileExists(JarFolderPath & "\" & jarName & ".jar") = True Then
                Return True

            Else
                Return False
            End If

        Else ' if backup display is true

            If My.Computer.FileSystem.FileExists(JarBackupFolderPath & "\" & jarName & ".jar") = True Then
                Return True

            Else
                Return False

            End If
        End If

    End Function

    Private Sub StatusTimer_Tick(sender As System.Object, e As System.EventArgs) Handles StatusTimer.Tick
        SetStatus("Ready", Color.Green)

        StatusTimer.Enabled = False

    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        FormAbout.Show()

    End Sub

    Private Sub btnOpenManagerFolder_Click(sender As System.Object, e As System.EventArgs) Handles btnOpenManagerFolder.Click
        Process.Start("explorer.exe", ProgramFolder)

    End Sub

    Private Sub CheckForUpdatesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckForUpdatesToolStripMenuItem.Click
        GetLatestVersion()
    End Sub

    Public Function GetVersion() As Double

        Return CurrentVersion
    End Function

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        DownloadUpdate()
    End Sub

    Private Sub tmrNewVersion_Tick(sender As System.Object, e As System.EventArgs) Handles tmrNewVersion.Tick
        If lblNewVersion.ForeColor = Color.Purple Then
            lblNewVersion.ForeColor = Color.Blue
            btnUpdate.ForeColor = Color.Blue
        Else
            lblNewVersion.ForeColor = Color.Purple
            btnUpdate.ForeColor = Color.Purple

        End If

    End Sub

    Private Sub HelpToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles HelpToolStripMenuItem1.Click
        FormHelp.Show()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ChangeLogToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChangeLogToolStripMenuItem.Click

    End Sub
End Class
