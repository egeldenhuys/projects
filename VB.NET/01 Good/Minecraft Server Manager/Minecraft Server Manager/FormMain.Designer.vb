<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.TxtConsole = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabServerSettings = New System.Windows.Forms.TabPage()
        Me.BtnRun = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnNew = New System.Windows.Forms.Button()
        Me.TxtNotes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboMode = New System.Windows.Forms.ComboBox()
        Me.TxtSeed = New System.Windows.Forms.TextBox()
        Me.TxtViewDistance = New System.Windows.Forms.TextBox()
        Me.CboDifficulty = New System.Windows.Forms.ComboBox()
        Me.TxtMaxPlayers = New System.Windows.Forms.TextBox()
        Me.ChkHardCore = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChkAllowNether = New System.Windows.Forms.CheckBox()
        Me.ChkWhiteList = New System.Windows.Forms.CheckBox()
        Me.ChkGenStructures = New System.Windows.Forms.CheckBox()
        Me.ChkOnlineMode = New System.Windows.Forms.CheckBox()
        Me.ChkSpawnMonsters = New System.Windows.Forms.CheckBox()
        Me.ChkSpawnAnimals = New System.Windows.Forms.CheckBox()
        Me.ChkPVP = New System.Windows.Forms.CheckBox()
        Me.ChkSpawnNPCs = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CboLevelType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMotd = New System.Windows.Forms.TextBox()
        Me.CboWorld = New System.Windows.Forms.ComboBox()
        Me.TabConsole = New System.Windows.Forms.TabPage()
        Me.TxtConsoleCmd = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.TabPlayers = New System.Windows.Forms.TabPage()
        Me.TabCommands = New System.Windows.Forms.TabPage()
        Me.TabOptions = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabServerSettings.SuspendLayout()
        Me.TabConsole.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(8, 235)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'TxtConsole
        '
        Me.TxtConsole.BackColor = System.Drawing.SystemColors.Control
        Me.TxtConsole.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtConsole.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtConsole.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtConsole.Location = New System.Drawing.Point(3, 3)
        Me.TxtConsole.Multiline = True
        Me.TxtConsole.Name = "TxtConsole"
        Me.TxtConsole.ReadOnly = True
        Me.TxtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtConsole.Size = New System.Drawing.Size(650, 217)
        Me.TxtConsole.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabServerSettings)
        Me.TabControl1.Controls.Add(Me.TabConsole)
        Me.TabControl1.Controls.Add(Me.TabPlayers)
        Me.TabControl1.Controls.Add(Me.TabCommands)
        Me.TabControl1.Controls.Add(Me.TabOptions)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(664, 302)
        Me.TabControl1.TabIndex = 5
        '
        'TabServerSettings
        '
        Me.TabServerSettings.BackColor = System.Drawing.Color.Honeydew
        Me.TabServerSettings.Controls.Add(Me.BtnRun)
        Me.TabServerSettings.Controls.Add(Me.BtnSave)
        Me.TabServerSettings.Controls.Add(Me.BtnNew)
        Me.TabServerSettings.Controls.Add(Me.TxtNotes)
        Me.TabServerSettings.Controls.Add(Me.Label5)
        Me.TabServerSettings.Controls.Add(Me.CboMode)
        Me.TabServerSettings.Controls.Add(Me.TxtSeed)
        Me.TabServerSettings.Controls.Add(Me.TxtViewDistance)
        Me.TabServerSettings.Controls.Add(Me.CboDifficulty)
        Me.TabServerSettings.Controls.Add(Me.TxtMaxPlayers)
        Me.TabServerSettings.Controls.Add(Me.ChkHardCore)
        Me.TabServerSettings.Controls.Add(Me.Label4)
        Me.TabServerSettings.Controls.Add(Me.ChkAllowNether)
        Me.TabServerSettings.Controls.Add(Me.ChkWhiteList)
        Me.TabServerSettings.Controls.Add(Me.ChkGenStructures)
        Me.TabServerSettings.Controls.Add(Me.ChkOnlineMode)
        Me.TabServerSettings.Controls.Add(Me.ChkSpawnMonsters)
        Me.TabServerSettings.Controls.Add(Me.ChkSpawnAnimals)
        Me.TabServerSettings.Controls.Add(Me.ChkPVP)
        Me.TabServerSettings.Controls.Add(Me.ChkSpawnNPCs)
        Me.TabServerSettings.Controls.Add(Me.Label13)
        Me.TabServerSettings.Controls.Add(Me.Label12)
        Me.TabServerSettings.Controls.Add(Me.Label11)
        Me.TabServerSettings.Controls.Add(Me.Label9)
        Me.TabServerSettings.Controls.Add(Me.CboLevelType)
        Me.TabServerSettings.Controls.Add(Me.Label3)
        Me.TabServerSettings.Controls.Add(Me.Label2)
        Me.TabServerSettings.Controls.Add(Me.Label1)
        Me.TabServerSettings.Controls.Add(Me.TxtMotd)
        Me.TabServerSettings.Controls.Add(Me.CboWorld)
        Me.TabServerSettings.Location = New System.Drawing.Point(4, 22)
        Me.TabServerSettings.Name = "TabServerSettings"
        Me.TabServerSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.TabServerSettings.Size = New System.Drawing.Size(656, 276)
        Me.TabServerSettings.TabIndex = 0
        Me.TabServerSettings.Text = "Server Settings"
        '
        'BtnRun
        '
        Me.BtnRun.Location = New System.Drawing.Point(492, 245)
        Me.BtnRun.Name = "BtnRun"
        Me.BtnRun.Size = New System.Drawing.Size(75, 23)
        Me.BtnRun.TabIndex = 35
        Me.BtnRun.Text = "Run"
        Me.BtnRun.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(573, 245)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 34
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(204, 6)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(75, 23)
        Me.BtnNew.TabIndex = 33
        Me.BtnNew.Text = "New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'TxtNotes
        '
        Me.TxtNotes.Location = New System.Drawing.Point(238, 161)
        Me.TxtNotes.Multiline = True
        Me.TxtNotes.Name = "TxtNotes"
        Me.TxtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNotes.Size = New System.Drawing.Size(216, 109)
        Me.TxtNotes.TabIndex = 32
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(197, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Notes"
        '
        'CboMode
        '
        Me.CboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMode.FormattingEnabled = True
        Me.CboMode.Location = New System.Drawing.Point(376, 61)
        Me.CboMode.Name = "CboMode"
        Me.CboMode.Size = New System.Drawing.Size(121, 21)
        Me.CboMode.TabIndex = 30
        '
        'TxtSeed
        '
        Me.TxtSeed.Location = New System.Drawing.Point(376, 26)
        Me.TxtSeed.Name = "TxtSeed"
        Me.TxtSeed.Size = New System.Drawing.Size(100, 20)
        Me.TxtSeed.TabIndex = 29
        '
        'TxtViewDistance
        '
        Me.TxtViewDistance.Location = New System.Drawing.Point(376, 3)
        Me.TxtViewDistance.Name = "TxtViewDistance"
        Me.TxtViewDistance.Size = New System.Drawing.Size(100, 20)
        Me.TxtViewDistance.TabIndex = 28
        '
        'CboDifficulty
        '
        Me.CboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDifficulty.FormattingEnabled = True
        Me.CboDifficulty.Location = New System.Drawing.Point(376, 90)
        Me.CboDifficulty.Name = "CboDifficulty"
        Me.CboDifficulty.Size = New System.Drawing.Size(121, 21)
        Me.CboDifficulty.TabIndex = 27
        '
        'TxtMaxPlayers
        '
        Me.TxtMaxPlayers.Location = New System.Drawing.Point(74, 91)
        Me.TxtMaxPlayers.Name = "TxtMaxPlayers"
        Me.TxtMaxPlayers.Size = New System.Drawing.Size(124, 20)
        Me.TxtMaxPlayers.TabIndex = 26
        '
        'ChkHardCore
        '
        Me.ChkHardCore.AutoSize = True
        Me.ChkHardCore.Location = New System.Drawing.Point(112, 141)
        Me.ChkHardCore.Name = "ChkHardCore"
        Me.ChkHardCore.Size = New System.Drawing.Size(71, 17)
        Me.ChkHardCore.TabIndex = 25
        Me.ChkHardCore.Text = "HardCore"
        Me.ChkHardCore.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Max Players"
        '
        'ChkAllowNether
        '
        Me.ChkAllowNether.AutoSize = True
        Me.ChkAllowNether.Location = New System.Drawing.Point(112, 117)
        Me.ChkAllowNether.Name = "ChkAllowNether"
        Me.ChkAllowNether.Size = New System.Drawing.Size(86, 17)
        Me.ChkAllowNether.TabIndex = 23
        Me.ChkAllowNether.Text = "Allow Nether"
        Me.ChkAllowNether.UseVisualStyleBackColor = True
        '
        'ChkWhiteList
        '
        Me.ChkWhiteList.AutoSize = True
        Me.ChkWhiteList.Location = New System.Drawing.Point(11, 256)
        Me.ChkWhiteList.Name = "ChkWhiteList"
        Me.ChkWhiteList.Size = New System.Drawing.Size(73, 17)
        Me.ChkWhiteList.TabIndex = 22
        Me.ChkWhiteList.Text = "White List"
        Me.ChkWhiteList.UseVisualStyleBackColor = True
        '
        'ChkGenStructures
        '
        Me.ChkGenStructures.AutoSize = True
        Me.ChkGenStructures.Location = New System.Drawing.Point(11, 233)
        Me.ChkGenStructures.Name = "ChkGenStructures"
        Me.ChkGenStructures.Size = New System.Drawing.Size(121, 17)
        Me.ChkGenStructures.TabIndex = 21
        Me.ChkGenStructures.Text = "Generate Structures"
        Me.ChkGenStructures.UseVisualStyleBackColor = True
        '
        'ChkOnlineMode
        '
        Me.ChkOnlineMode.AutoSize = True
        Me.ChkOnlineMode.Location = New System.Drawing.Point(11, 210)
        Me.ChkOnlineMode.Name = "ChkOnlineMode"
        Me.ChkOnlineMode.Size = New System.Drawing.Size(86, 17)
        Me.ChkOnlineMode.TabIndex = 20
        Me.ChkOnlineMode.Text = "Online Mode"
        Me.ChkOnlineMode.UseVisualStyleBackColor = True
        '
        'ChkSpawnMonsters
        '
        Me.ChkSpawnMonsters.AutoSize = True
        Me.ChkSpawnMonsters.Location = New System.Drawing.Point(11, 186)
        Me.ChkSpawnMonsters.Name = "ChkSpawnMonsters"
        Me.ChkSpawnMonsters.Size = New System.Drawing.Size(105, 17)
        Me.ChkSpawnMonsters.TabIndex = 19
        Me.ChkSpawnMonsters.Text = "Spawn Monsters"
        Me.ChkSpawnMonsters.UseVisualStyleBackColor = True
        '
        'ChkSpawnAnimals
        '
        Me.ChkSpawnAnimals.AutoSize = True
        Me.ChkSpawnAnimals.Location = New System.Drawing.Point(11, 163)
        Me.ChkSpawnAnimals.Name = "ChkSpawnAnimals"
        Me.ChkSpawnAnimals.Size = New System.Drawing.Size(98, 17)
        Me.ChkSpawnAnimals.TabIndex = 18
        Me.ChkSpawnAnimals.Text = "Spawn Animals"
        Me.ChkSpawnAnimals.UseVisualStyleBackColor = True
        '
        'ChkPVP
        '
        Me.ChkPVP.AutoSize = True
        Me.ChkPVP.Location = New System.Drawing.Point(11, 141)
        Me.ChkPVP.Name = "ChkPVP"
        Me.ChkPVP.Size = New System.Drawing.Size(47, 17)
        Me.ChkPVP.TabIndex = 17
        Me.ChkPVP.Text = "PVP"
        Me.ChkPVP.UseVisualStyleBackColor = True
        '
        'ChkSpawnNPCs
        '
        Me.ChkSpawnNPCs.AutoSize = True
        Me.ChkSpawnNPCs.Location = New System.Drawing.Point(11, 117)
        Me.ChkSpawnNPCs.Name = "ChkSpawnNPCs"
        Me.ChkSpawnNPCs.Size = New System.Drawing.Size(89, 17)
        Me.ChkSpawnNPCs.TabIndex = 16
        Me.ChkSpawnNPCs.Text = "Spawn NPCs"
        Me.ChkSpawnNPCs.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(305, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Game Mode"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(295, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Level Seed"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(295, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "View Distance"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(331, 97)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Difficulty"
        '
        'CboLevelType
        '
        Me.CboLevelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboLevelType.FormattingEnabled = True
        Me.CboLevelType.Location = New System.Drawing.Point(74, 61)
        Me.CboLevelType.Name = "CboLevelType"
        Me.CboLevelType.Size = New System.Drawing.Size(124, 21)
        Me.CboLevelType.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Level Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "MOTD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "World"
        '
        'TxtMotd
        '
        Me.TxtMotd.Location = New System.Drawing.Point(70, 33)
        Me.TxtMotd.Name = "TxtMotd"
        Me.TxtMotd.Size = New System.Drawing.Size(128, 20)
        Me.TxtMotd.TabIndex = 1
        '
        'CboWorld
        '
        Me.CboWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboWorld.FormattingEnabled = True
        Me.CboWorld.Location = New System.Drawing.Point(70, 6)
        Me.CboWorld.Name = "CboWorld"
        Me.CboWorld.Size = New System.Drawing.Size(128, 21)
        Me.CboWorld.Sorted = True
        Me.CboWorld.TabIndex = 0
        '
        'TabConsole
        '
        Me.TabConsole.BackColor = System.Drawing.Color.OldLace
        Me.TabConsole.Controls.Add(Me.TxtConsole)
        Me.TabConsole.Controls.Add(Me.TxtConsoleCmd)
        Me.TabConsole.Controls.Add(Me.btnSend)
        Me.TabConsole.Controls.Add(Me.btnStop)
        Me.TabConsole.Location = New System.Drawing.Point(4, 22)
        Me.TabConsole.Name = "TabConsole"
        Me.TabConsole.Padding = New System.Windows.Forms.Padding(3)
        Me.TabConsole.Size = New System.Drawing.Size(656, 276)
        Me.TabConsole.TabIndex = 1
        Me.TabConsole.Text = "Console"
        '
        'TxtConsoleCmd
        '
        Me.TxtConsoleCmd.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtConsoleCmd.Location = New System.Drawing.Point(190, 237)
        Me.TxtConsoleCmd.Name = "TxtConsoleCmd"
        Me.TxtConsoleCmd.Size = New System.Drawing.Size(372, 20)
        Me.TxtConsoleCmd.TabIndex = 3
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(568, 234)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 4
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'TabPlayers
        '
        Me.TabPlayers.Location = New System.Drawing.Point(4, 22)
        Me.TabPlayers.Name = "TabPlayers"
        Me.TabPlayers.Size = New System.Drawing.Size(656, 276)
        Me.TabPlayers.TabIndex = 2
        Me.TabPlayers.Text = "Players"
        Me.TabPlayers.UseVisualStyleBackColor = True
        '
        'TabCommands
        '
        Me.TabCommands.Location = New System.Drawing.Point(4, 22)
        Me.TabCommands.Name = "TabCommands"
        Me.TabCommands.Size = New System.Drawing.Size(656, 276)
        Me.TabCommands.TabIndex = 4
        Me.TabCommands.Text = "Commands"
        Me.TabCommands.UseVisualStyleBackColor = True
        '
        'TabOptions
        '
        Me.TabOptions.Location = New System.Drawing.Point(4, 22)
        Me.TabOptions.Name = "TabOptions"
        Me.TabOptions.Size = New System.Drawing.Size(656, 276)
        Me.TabOptions.TabIndex = 3
        Me.TabOptions.Text = "Options"
        Me.TabOptions.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 302)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormMain"
        Me.Text = "Minecraft Server Manager"
        Me.TabControl1.ResumeLayout(False)
        Me.TabServerSettings.ResumeLayout(False)
        Me.TabServerSettings.PerformLayout()
        Me.TabConsole.ResumeLayout(False)
        Me.TabConsole.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents TxtConsole As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabServerSettings As System.Windows.Forms.TabPage
    Friend WithEvents TabConsole As System.Windows.Forms.TabPage
    Friend WithEvents TxtConsoleCmd As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents CboDifficulty As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMaxPlayers As System.Windows.Forms.TextBox
    Friend WithEvents ChkHardCore As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkAllowNether As System.Windows.Forms.CheckBox
    Friend WithEvents ChkWhiteList As System.Windows.Forms.CheckBox
    Friend WithEvents ChkGenStructures As System.Windows.Forms.CheckBox
    Friend WithEvents ChkOnlineMode As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSpawnMonsters As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSpawnAnimals As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPVP As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSpawnNPCs As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CboLevelType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMotd As System.Windows.Forms.TextBox
    Friend WithEvents CboWorld As System.Windows.Forms.ComboBox
    Friend WithEvents BtnRun As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents TxtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboMode As System.Windows.Forms.ComboBox
    Friend WithEvents TxtSeed As System.Windows.Forms.TextBox
    Friend WithEvents TxtViewDistance As System.Windows.Forms.TextBox
    Friend WithEvents TabPlayers As System.Windows.Forms.TabPage
    Friend WithEvents TabOptions As System.Windows.Forms.TabPage
    Friend WithEvents TabCommands As System.Windows.Forms.TabPage

End Class
