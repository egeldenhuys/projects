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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabCreate = New System.Windows.Forms.TabPage()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.tbClanName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabUpdate = New System.Windows.Forms.TabPage()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TabOptions = New System.Windows.Forms.TabPage()
        Me.btnCheckUpdate = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblDownload = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TabControl1.SuspendLayout()
        Me.TabCreate.SuspendLayout()
        Me.TabUpdate.SuspendLayout()
        Me.TabOptions.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabCreate)
        Me.TabControl1.Controls.Add(Me.TabUpdate)
        Me.TabControl1.Controls.Add(Me.TabOptions)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(297, 268)
        Me.TabControl1.TabIndex = 0
        '
        'TabCreate
        '
        Me.TabCreate.BackColor = System.Drawing.SystemColors.Control
        Me.TabCreate.Controls.Add(Me.btnCreate)
        Me.TabCreate.Controls.Add(Me.tbClanName)
        Me.TabCreate.Controls.Add(Me.Label1)
        Me.TabCreate.Location = New System.Drawing.Point(4, 22)
        Me.TabCreate.Name = "TabCreate"
        Me.TabCreate.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCreate.Size = New System.Drawing.Size(289, 242)
        Me.TabCreate.TabIndex = 0
        Me.TabCreate.Text = "Create competition"
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(103, 188)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 2
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'tbClanName
        '
        Me.tbClanName.Location = New System.Drawing.Point(76, 7)
        Me.tbClanName.Name = "tbClanName"
        Me.tbClanName.Size = New System.Drawing.Size(196, 20)
        Me.tbClanName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Clan Name:"
        '
        'TabUpdate
        '
        Me.TabUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.TabUpdate.Controls.Add(Me.btnUpdate)
        Me.TabUpdate.Controls.Add(Me.btnOpen)
        Me.TabUpdate.Controls.Add(Me.btnDelete)
        Me.TabUpdate.Controls.Add(Me.ListBox1)
        Me.TabUpdate.Location = New System.Drawing.Point(4, 22)
        Me.TabUpdate.Name = "TabUpdate"
        Me.TabUpdate.Padding = New System.Windows.Forms.Padding(3)
        Me.TabUpdate.Size = New System.Drawing.Size(289, 242)
        Me.TabUpdate.TabIndex = 1
        Me.TabUpdate.Text = "Update existing"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(197, 172)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(116, 172)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(6, 172)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(6, 6)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(266, 160)
        Me.ListBox1.TabIndex = 0
        '
        'TabOptions
        '
        Me.TabOptions.BackColor = System.Drawing.SystemColors.Control
        Me.TabOptions.Controls.Add(Me.btnCheckUpdate)
        Me.TabOptions.Controls.Add(Me.lblVersion)
        Me.TabOptions.Location = New System.Drawing.Point(4, 22)
        Me.TabOptions.Name = "TabOptions"
        Me.TabOptions.Size = New System.Drawing.Size(289, 242)
        Me.TabOptions.TabIndex = 2
        Me.TabOptions.Text = "Options"
        '
        'btnCheckUpdate
        '
        Me.btnCheckUpdate.Location = New System.Drawing.Point(8, 8)
        Me.btnCheckUpdate.Name = "btnCheckUpdate"
        Me.btnCheckUpdate.Size = New System.Drawing.Size(100, 34)
        Me.btnCheckUpdate.TabIndex = 1
        Me.btnCheckUpdate.Text = "Check for Update"
        Me.btnCheckUpdate.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.Location = New System.Drawing.Point(3, 199)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(274, 16)
        Me.lblVersion.TabIndex = 0
        Me.lblVersion.Text = "Version"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.lblDownload})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 246)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(297, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Ready"
        '
        'lblDownload
        '
        Me.lblDownload.Name = "lblDownload"
        Me.lblDownload.Size = New System.Drawing.Size(93, 17)
        Me.lblDownload.Text = "DownloadStatus"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(297, 268)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.Text = "RS Clan Competition Maker"
        Me.TabControl1.ResumeLayout(False)
        Me.TabCreate.ResumeLayout(False)
        Me.TabCreate.PerformLayout()
        Me.TabUpdate.ResumeLayout(False)
        Me.TabOptions.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabCreate As System.Windows.Forms.TabPage
    Friend WithEvents TabUpdate As System.Windows.Forms.TabPage
    Friend WithEvents TabOptions As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents tbClanName As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents btnCheckUpdate As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDownload As System.Windows.Forms.ToolStripStatusLabel

End Class
