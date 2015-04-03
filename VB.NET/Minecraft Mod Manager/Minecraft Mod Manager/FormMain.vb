Imports System.Net
Imports System.ComponentModel
Imports System.IO
Imports ICSharpCode.SharpZipLib
Imports TrollPrograms
Imports Ionic.Zip


#Region "TODO"
' 1. Clean up code and move methods/functions to TrollProgramsDLL
' Auto Updater
' Move some methods and functions to TrollProgramsDLL
' persistent Mod loading
' Mod profiles
' - Server
' Support for mods that are in .jar format
' Install mods in a certain order - contained in the profile

#End Region

Public Class FormMain
    ' TrollProgramsDLL
    Dim WithEvents Downloader As New Network.Downloader

    ' paths
    Dim AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim ProgFolder As String = AppData & "\Troll Programs\Minecraft Mod Manager"
    Dim TmpFolder As String = ProgFolder & "\tmp"
    Dim JarPath As String = AppData & "\.minecraft\bin\minecraft.jar"
    Dim ModsFolder As String = ProgFolder & "\Mods"
    Dim JarFolder As String = ProgFolder & "\Jars"

    ' Other
    Dim MCVersion As String
    Dim MCVersionHash As String
    Dim DownloaderJob As String
    Dim InstalledMods(0) As String

    ' Downloads
    Dim VersionHashesUri As New System.Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20Mod%20Manager/MCVersionHashes.txt")
    Dim NewsUri As New System.Uri("https://dl.dropbox.com/u/57022080/Programs/Minecraft%20Mod%20Manager/News.txt")

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ReDim InstalledMods(0)

        My.Computer.FileSystem.CreateDirectory(TmpFolder)

        DownloadNews()
        LoadMods()

    End Sub


    Private Sub btnFindVersion_Click(sender As System.Object, e As System.EventArgs) Handles btnFindVersion.Click

        Dim fHash As New Cryptography.SHA512

        Dim hash As String = fHash.GetFileHash(JarPath)

        MCVersionHash = hash

        DownloadVersionHashes()

    End Sub

    Private Sub DisplayNews()
        Dim reader As New StreamReader(TmpFolder & "\News.txt")

        lblNews.Text = reader.ReadLine

        reader.Close()
        lblStatus.Text = "Ready"
    End Sub

    Private Sub CompareVersionHashes()
        Dim reader As New StreamReader(TmpFolder & "\VersionHashes.txt")
        Dim textLine As String = ""
        Dim subStrings() As String

        lblMCVersion.Text = "Your version was not found or it has been modified"

        Do While reader.Peek <> -1
            textLine = reader.ReadLine
            subStrings = Split(textLine, "=")

            If subStrings(1) = MCVersionHash Then
                lblMCVersion.Text = subStrings(0)
            End If
        Loop

        reader.Close()

        lblStatus.Text = "Ready"
    End Sub

#Region "Downloads"

    Private Sub DownloadVersionHashes()

        If Downloader.IsBusy = False Then
            lblStatus.Text = "Finding MC Version"

            DownloaderJob = "VersionHash"

            lblMCVersion.Visible = True
            lblMCVersion.Text = "Finding Version..."

            Downloader.DownloadFileAsync(VersionHashesUri, TmpFolder, "VersionHashes.txt")
        Else

            lblStatus.Text = "Busy... Please try again"
        End If


    End Sub

    Private Sub DownloadNews()
        lblStatus.Text = "Downloading news"

        DownloaderJob = "News"
        Downloader.DownloadFileAsync(NewsUri, TmpFolder, "News.txt")

    End Sub

    Private Sub Downloader_FileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles Downloader.DownloadFileCompleted

            Select Case DownloaderJob
                Case "VersionHash"
                    CompareVersionHashes()

                Case "News"
                    DisplayNews()
            End Select


        DownloaderJob = ""
    End Sub

#End Region

    Private Sub FormMain_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Delete tmp folder
        My.Computer.FileSystem.DeleteDirectory(TmpFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
    End Sub

    Private Sub btnPatch_Click(sender As System.Object, e As System.EventArgs) Handles btnPatch.Click
        PatchJar()
    End Sub

    Private Sub btnSaveJar_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveJar.Click
        Savejar()
    End Sub

    Private Sub Savejar()
        My.Computer.FileSystem.CopyFile(JarPath, ProgFolder & "\Jars\minecraft.jar", True)
    End Sub

    Private Sub PatchJar()

        If My.Computer.FileSystem.FileExists(ProgFolder & "\Jars\minecraft.jar") Then

            ' Replace the current jar with the original jar
            My.Computer.FileSystem.CopyFile(ProgFolder & "\Jars\minecraft.jar", JarPath, True)

            If InstalledMods(0) <> Nothing Then
                RemoveMetaInf()
                AddModsTojar()
            End If

            lblStatus.Text = "Patched"
        End If


    End Sub

    Private Sub RemoveMetaInf()

        Using zip As ZipFile = ZipFile.Read(JarPath)
            ' We cannot remove the entry from the list, within the context of 
            ' an enumeration of said list.
            ' So we add the doomed entry to a list to be removed later.
            ' pass 1: mark the entries for removal
            Dim MarkedEntries As New System.Collections.Generic.List(Of ZipEntry)
            Dim e As ZipEntry
            For Each e In zip
                ' here, we apply the criterion to remove the entry.  It is a time-based criterion, but you could 
                ' use anything you like.  Extension of the file, size of the entry, etc etc. 

                If (e.FileName = "META-INF/MANIFEST.MF") Then
                    MarkedEntries.Add(e)
                End If

                If (e.FileName = "META-INF/MOJANG_C.SF") Then
                    MarkedEntries.Add(e)
                End If

                If (e.FileName = "META-INF/MOJANG_C.DSA") Then
                    MarkedEntries.Add(e)
                End If

            Next
            ' pass 2: actually remove the entry. 
            Dim zombie As ZipEntry
            For Each zombie In MarkedEntries
                zip.RemoveEntry(zombie)
            Next

            zip.Save()
        End Using

    End Sub

    Private Sub AddModsTojar()

        Using zip As ZipFile = ZipFile.Read(JarPath)
            ' the UpdateFile method works even if the entry does not yet exist.
            ' Really it should be called "AddOrUpdateFile"

            For i = 0 To InstalledMods.GetUpperBound(0)
                Console.WriteLine(InstalledMods(i))
                If InstalledMods(i) <> Nothing Then
                    zip.UpdateDirectory(ModsFolder & "\" & InstalledMods(i))
                End If

            Next

            zip.Save()

        End Using

        lblStatus.Text = "Patched"
    End Sub

    Private Sub ExtractZip(ByVal zipPath As String, ByVal destFolder As String)

        Dim ZipToUnpack As String = zipPath
        Dim UnpackDirectory As String = destFolder
        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
            Dim e As ZipEntry
            ' here, we extract every entry, but we could extract conditionally,
            ' based on entry name, size, date, checkbox status, etc.   
            For Each e In zip1
                e.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
            Next
        End Using

    End Sub

    Private Sub LoadMods()
        For Each modFolder In My.Computer.FileSystem.GetDirectories(ModsFolder)

            ' Add folder name to available mods list
            lstAvailableMods.Items.Add(My.Computer.FileSystem.GetName(modFolder.ToString))
        Next
    End Sub

    Private Sub btnAddMod_Click(sender As System.Object, e As System.EventArgs) Handles btnAddMod.Click
        Dim itemName As String = lstAvailableMods.SelectedItem.ToString

        ' Add item to installed mods list
        lstInstalledMods.Items.Add(itemName)

        ' Remove item from available mods list
        lstAvailableMods.Items.Remove(itemName)

        ' Add to array of mods to be installed
        AddToInstalledMods(itemName)
    End Sub

    Private Sub AddToInstalledMods(ByVal modName As String)

        InstalledMods(InstalledMods.GetUpperBound(0)) = modName

        ReDim Preserve InstalledMods(InstalledMods.GetUpperBound(0) + 1)


    End Sub
End Class
