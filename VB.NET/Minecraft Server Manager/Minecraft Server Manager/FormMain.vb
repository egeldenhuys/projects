Imports System.IO

Public Class FormMain
    'TODO:


    Private WithEvents Server As Process

    Dim Nether, Query, Flight, rcon, npcs, whiteList, animals, hardcore, online,
            pvp, monsters, structures, level, type, motd, seed, ip, texturePack, port,
            buildHeight, difficulty, mode, players, view As String

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadWorlds()
    End Sub

#Region "Server Settings"

    Private Sub CboWorld_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboWorld.SelectedIndexChanged
        LoadSettings(CboWorld.SelectedItem.ToString)
    End Sub

    Private Sub LoadSettings(ByVal world As String)
        Dim Reader As StreamReader
        Dim line As String
        Dim substrings As String()

        Try
            Reader = New StreamReader(My.Computer.FileSystem.CurrentDirectory & "\" & world & "\MC Server Manager\server.properties")

            Do Until Reader.Peek = -1
                line = Reader.ReadLine()
                substrings = Split(line, "=", 1)

                Select Case substrings(0)
                    Case "allow-nether"
                        Nether = substrings(1)
                    Case "level-name"
                        level = substrings(1)
                    Case "enable-query"
                        Query = substrings(1)
                    Case "allow-flight"
                        Flight = substrings(1)
                    Case "server-port"
                        port = substrings(1)
                    Case "level-type"
                        type = substrings(1)
                    Case "enable-rcon"
                        rcon = substrings(1)
                    Case "level-seed"
                        seed = substrings(1)
                    Case "server-ip"
                        ip = substrings(1)
                    Case "max-build-height"
                        buildHeight = substrings(1)
                    Case "spawn-npcs"
                        npcs = substrings(1)
                    Case "white-list"
                        whiteList = substrings(1)
                    Case "spawn-animals"
                        animals = substrings(1)
                    Case "hardcore"
                        hardcore = substrings(1)
                    Case "texture-pack"
                        texturePack = substrings(1)
                    Case "online-mode"
                        online = substrings(1)
                    Case "pvp"
                        pvp = substrings(1)
                    Case "difficulty"
                        difficulty = substrings(1)
                    Case "gamemode"
                        mode = substrings(1)
                    Case "max-players"
                        players = substrings(1)
                    Case "spawn-monsters"
                        monsters = substrings(1)
                    Case "view-distance"
                        view = substrings(1)
                    Case "generate-structures"
                        structures = substrings(1)
                    Case "motd"
                        motd = substrings(1)

                End Select

            Loop
            Reader.Close()
        Catch ex1 As DirectoryNotFoundException

        Catch ex2 As FileNotFoundException

        End Try

        DisplaySettings()
    End Sub

    Private Sub DisplaySettings()
        TxtMotd.Text = motd
    End Sub

    Private Sub LoadWorlds()

        Dim Files As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

        Files = My.Computer.FileSystem.GetDirectories(My.Computer.FileSystem.CurrentDirectory, FileIO.SearchOption.SearchTopLevelOnly)
        For Each file In Files

            CboWorld.Items.Add(My.Computer.FileSystem.GetName(file))
        Next
    End Sub


#End Region


    Private Sub btnRun_Click(sender As System.Object, e As System.EventArgs)
        Server = New Process
        With Server.StartInfo
            .FileName = "RUN.bat"
            .UseShellExecute = False
            .CreateNoWindow = True
            .RedirectStandardInput = True
            .RedirectStandardOutput = True
            .RedirectStandardError = True
        End With

        Server.Start()

        Server.BeginErrorReadLine()
        Server.BeginOutputReadLine()
        AppendOutputText("Process Started at: " & Server.StartTime.ToString)
    End Sub

    Private Sub btnStop_Click(sender As System.Object, e As System.EventArgs) Handles btnStop.Click
        Server.StandardInput.WriteLine("stop")
        Server.StandardInput.Flush()
        Server.Close()
    End Sub

    Private Sub AppendOutputText(ByVal text As String)
        TxtConsole.AppendText(vbCrLf & text)
    End Sub
    Private Sub Server_ErrorOutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles Server.ErrorDataReceived
        AppendOutputText(e.Data)
    End Sub
    Private Sub Server_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles Server.OutputDataReceived
        If e.Data = My.Computer.FileSystem.CurrentDirectory.ToString & ">PAUSE" Then
            AppendOutputText("Server Stopped...")
        Else
            AppendOutputText(e.Data)
        End If
    End Sub

    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        SendCommand()
    End Sub

    Private Sub TextBox2_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtConsoleCmd.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            SendCommand()
            e.Handled = True
        End If

    End Sub

    Private Sub SendCommand()
        Dim DateMonth As String = ""

        AppendOutputText(">" & TxtConsoleCmd.Text)

        Dim Substrings As String() = Split(TxtConsoleCmd.Text, " ", 2)

        If Date.Now.Month < 10 Then
            DateMonth = "0" & Date.Now.Month
        Else
            DateMonth = "0" & Date.Now.Month
        End If

        If Substrings(0).ToLower = "say" Then
            AppendOutputText(Date.Now.Year & "-" & DateMonth & "-" & Date.Now.Day & " " _
                             & TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second _
                             & " [INFO] <Server> " & Substrings(1))
        End If


        Server.StandardInput.WriteLine(TxtConsoleCmd.Text)
        Server.StandardInput.Flush()

        TxtConsoleCmd.Text = ""

    End Sub


End Class
