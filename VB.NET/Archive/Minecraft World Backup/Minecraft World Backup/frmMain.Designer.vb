<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnBackupNow = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.tmrBackup = New System.Windows.Forms.Timer(Me.components)
        Me.btnStop = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstWorlds = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCompress = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tmrStatusReset = New System.Windows.Forms.Timer(Me.components)
        Me.lblStatus2 = New System.Windows.Forms.Label()
        Me.btnCheckUpdate = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnForceUpdate = New System.Windows.Forms.Button()
        Me.lblLatestVersion = New System.Windows.Forms.Label()
        Me.lblCurVersion = New System.Windows.Forms.Label()
        Me.txtConsole = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tlsHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlsViewHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlsChangeLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlsCheckForUpdates = New System.Windows.Forms.ToolStripMenuItem()
        Me.tlsForceUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnConsoleToggle = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bgwCheckForUpdate = New System.ComponentModel.BackgroundWorker()
        Me.lblBackup = New System.Windows.Forms.Label()
        Me.bgwBackup = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(300, 41)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 4
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnBackupNow
        '
        Me.btnBackupNow.Location = New System.Drawing.Point(318, 69)
        Me.btnBackupNow.Name = "btnBackupNow"
        Me.btnBackupNow.Size = New System.Drawing.Size(114, 23)
        Me.btnBackupNow.TabIndex = 5
        Me.btnBackupNow.Text = "Create Backup Now"
        Me.btnBackupNow.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(167, 19)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'tmrBackup
        '
        Me.tmrBackup.Interval = 600000
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(381, 41)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 7
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstWorlds)
        Me.GroupBox1.Controls.Add(Me.btnRefresh)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 165)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Worlds"
        '
        'lstWorlds
        '
        Me.lstWorlds.FormattingEnabled = True
        Me.lstWorlds.Location = New System.Drawing.Point(6, 19)
        Me.lstWorlds.Name = "lstWorlds"
        Me.lstWorlds.Size = New System.Drawing.Size(155, 139)
        Me.lstWorlds.Sorted = True
        Me.lstWorlds.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Interval (Minutes):"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(103, 17)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(100, 20)
        Me.txtInterval.TabIndex = 9
        Me.txtInterval.Text = "5"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCompress)
        Me.GroupBox2.Controls.Add(Me.txtInterval)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 212)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 73)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options"
        '
        'chkCompress
        '
        Me.chkCompress.AutoSize = True
        Me.chkCompress.Checked = True
        Me.chkCompress.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompress.Location = New System.Drawing.Point(9, 43)
        Me.chkCompress.Name = "chkCompress"
        Me.chkCompress.Size = New System.Drawing.Size(108, 17)
        Me.chkCompress.TabIndex = 10
        Me.chkCompress.Text = "Compress Worlds"
        Me.chkCompress.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 358)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(917, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 11
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(121, 17)
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(105, 297)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 23)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save Settings"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tmrStatusReset
        '
        Me.tmrStatusReset.Enabled = True
        Me.tmrStatusReset.Interval = 5000
        '
        'lblStatus2
        '
        Me.lblStatus2.AutoSize = True
        Me.lblStatus2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus2.ForeColor = System.Drawing.Color.Red
        Me.lblStatus2.Location = New System.Drawing.Point(339, 95)
        Me.lblStatus2.Name = "lblStatus2"
        Me.lblStatus2.Size = New System.Drawing.Size(63, 13)
        Me.lblStatus2.TabIndex = 13
        Me.lblStatus2.Text = "Status: OFF"
        '
        'btnCheckUpdate
        '
        Me.btnCheckUpdate.Location = New System.Drawing.Point(16, 71)
        Me.btnCheckUpdate.Name = "btnCheckUpdate"
        Me.btnCheckUpdate.Size = New System.Drawing.Size(109, 23)
        Me.btnCheckUpdate.TabIndex = 14
        Me.btnCheckUpdate.Text = "Check For Updates"
        Me.btnCheckUpdate.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnForceUpdate)
        Me.GroupBox3.Controls.Add(Me.lblLatestVersion)
        Me.GroupBox3.Controls.Add(Me.btnCheckUpdate)
        Me.GroupBox3.Controls.Add(Me.lblCurVersion)
        Me.GroupBox3.Location = New System.Drawing.Point(277, 191)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 124)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Version Information"
        '
        'btnForceUpdate
        '
        Me.btnForceUpdate.Location = New System.Drawing.Point(16, 95)
        Me.btnForceUpdate.Name = "btnForceUpdate"
        Me.btnForceUpdate.Size = New System.Drawing.Size(82, 23)
        Me.btnForceUpdate.TabIndex = 15
        Me.btnForceUpdate.Text = "Force Update"
        Me.btnForceUpdate.UseVisualStyleBackColor = True
        '
        'lblLatestVersion
        '
        Me.lblLatestVersion.AutoSize = True
        Me.lblLatestVersion.Location = New System.Drawing.Point(13, 50)
        Me.lblLatestVersion.Name = "lblLatestVersion"
        Me.lblLatestVersion.Size = New System.Drawing.Size(81, 13)
        Me.lblLatestVersion.TabIndex = 1
        Me.lblLatestVersion.Text = "lblLatestVersion"
        '
        'lblCurVersion
        '
        Me.lblCurVersion.AutoSize = True
        Me.lblCurVersion.Location = New System.Drawing.Point(13, 24)
        Me.lblCurVersion.Name = "lblCurVersion"
        Me.lblCurVersion.Size = New System.Drawing.Size(68, 13)
        Me.lblCurVersion.TabIndex = 0
        Me.lblCurVersion.Text = "lblCurVersion"
        '
        'txtConsole
        '
        Me.txtConsole.BackColor = System.Drawing.Color.Black
        Me.txtConsole.ForeColor = System.Drawing.Color.Lime
        Me.txtConsole.Location = New System.Drawing.Point(500, 43)
        Me.txtConsole.Multiline = True
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsole.Size = New System.Drawing.Size(407, 272)
        Me.txtConsole.TabIndex = 16
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlsHelp})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(917, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tlsHelp
        '
        Me.tlsHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlsViewHelp, Me.tlsChangeLog, Me.tlsCheckForUpdates, Me.tlsForceUpdate})
        Me.tlsHelp.Name = "tlsHelp"
        Me.tlsHelp.Size = New System.Drawing.Size(44, 20)
        Me.tlsHelp.Text = "Help"
        '
        'tlsViewHelp
        '
        Me.tlsViewHelp.Name = "tlsViewHelp"
        Me.tlsViewHelp.Size = New System.Drawing.Size(173, 22)
        Me.tlsViewHelp.Text = "View Help"
        Me.tlsViewHelp.Visible = False
        '
        'tlsChangeLog
        '
        Me.tlsChangeLog.Name = "tlsChangeLog"
        Me.tlsChangeLog.Size = New System.Drawing.Size(173, 22)
        Me.tlsChangeLog.Text = "Change Log"
        '
        'tlsCheckForUpdates
        '
        Me.tlsCheckForUpdates.Name = "tlsCheckForUpdates"
        Me.tlsCheckForUpdates.Size = New System.Drawing.Size(173, 22)
        Me.tlsCheckForUpdates.Text = "Check For Updates"
        '
        'tlsForceUpdate
        '
        Me.tlsForceUpdate.Name = "tlsForceUpdate"
        Me.tlsForceUpdate.Size = New System.Drawing.Size(173, 22)
        Me.tlsForceUpdate.Text = "Force Update"
        '
        'btnConsoleToggle
        '
        Me.btnConsoleToggle.Location = New System.Drawing.Point(459, 134)
        Me.btnConsoleToggle.Name = "btnConsoleToggle"
        Me.btnConsoleToggle.Size = New System.Drawing.Size(18, 40)
        Me.btnConsoleToggle.TabIndex = 18
        Me.btnConsoleToggle.Text = "<"
        Me.ToolTip1.SetToolTip(Me.btnConsoleToggle, "Hide/Show Console")
        Me.btnConsoleToggle.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 323)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(285, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Settings need to be saved after changes have been made."
        '
        'bgwCheckForUpdate
        '
        Me.bgwCheckForUpdate.WorkerReportsProgress = True
        '
        'lblBackup
        '
        Me.lblBackup.AutoSize = True
        Me.lblBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackup.ForeColor = System.Drawing.Color.Green
        Me.lblBackup.Location = New System.Drawing.Point(297, 108)
        Me.lblBackup.Name = "lblBackup"
        Me.lblBackup.Size = New System.Drawing.Size(148, 18)
        Me.lblBackup.TabIndex = 20
        Me.lblBackup.Text = "Backup in progress..."
        Me.lblBackup.Visible = False
        '
        'bgwBackup
        '
        Me.bgwBackup.WorkerReportsProgress = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 380)
        Me.Controls.Add(Me.lblBackup)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnConsoleToggle)
        Me.Controls.Add(Me.txtConsole)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblStatus2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnBackupNow)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "MC World Backup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnBackupNow As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents tmrBackup As System.Windows.Forms.Timer
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstWorlds As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents tmrStatusReset As System.Windows.Forms.Timer
    Friend WithEvents lblStatus2 As System.Windows.Forms.Label
    Friend WithEvents btnCheckUpdate As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblLatestVersion As System.Windows.Forms.Label
    Friend WithEvents lblCurVersion As System.Windows.Forms.Label
    Friend WithEvents chkCompress As System.Windows.Forms.CheckBox
    Friend WithEvents txtConsole As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnConsoleToggle As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnForceUpdate As System.Windows.Forms.Button
    Friend WithEvents bgwCheckForUpdate As System.ComponentModel.BackgroundWorker
    Friend WithEvents tlsHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlsViewHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlsChangeLog As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlsCheckForUpdates As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tlsForceUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblBackup As System.Windows.Forms.Label
    Friend WithEvents bgwBackup As System.ComponentModel.BackgroundWorker

End Class
