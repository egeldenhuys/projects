<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormActivate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormActivate))
        Me.txtChangeLog = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnActivate = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblNewVersion = New System.Windows.Forms.Label()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.prgbDownload = New System.Windows.Forms.ProgressBar()
        Me.lblDownloadStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtChangeLog
        '
        Me.txtChangeLog.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtChangeLog.Location = New System.Drawing.Point(12, 80)
        Me.txtChangeLog.Multiline = True
        Me.txtChangeLog.Name = "txtChangeLog"
        Me.txtChangeLog.ReadOnly = True
        Me.txtChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChangeLog.Size = New System.Drawing.Size(167, 152)
        Me.txtChangeLog.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Change Log:"
        '
        'btnActivate
        '
        Me.btnActivate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActivate.ForeColor = System.Drawing.Color.Red
        Me.btnActivate.Location = New System.Drawing.Point(42, 12)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(102, 38)
        Me.btnActivate.TabIndex = 3
        Me.btnActivate.Text = "Activate"
        Me.btnActivate.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(403, 242)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(41, 13)
        Me.lblVersion.TabIndex = 4
        Me.lblVersion.Text = "version"
        '
        'lblNewVersion
        '
        Me.lblNewVersion.AutoSize = True
        Me.lblNewVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewVersion.ForeColor = System.Drawing.Color.Red
        Me.lblNewVersion.Location = New System.Drawing.Point(2, 241)
        Me.lblNewVersion.Name = "lblNewVersion"
        Me.lblNewVersion.Size = New System.Drawing.Size(191, 20)
        Me.lblNewVersion.TabIndex = 5
        Me.lblNewVersion.Text = "A new version is available!"
        Me.lblNewVersion.Visible = False
        '
        'btnContinue
        '
        Me.btnContinue.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinue.ForeColor = System.Drawing.Color.Green
        Me.btnContinue.Location = New System.Drawing.Point(268, 98)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(110, 69)
        Me.btnContinue.TabIndex = 6
        Me.btnContinue.Text = "Continue"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(199, 238)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(83, 23)
        Me.btnUpdate.TabIndex = 7
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        Me.btnUpdate.Visible = False
        '
        'prgbDownload
        '
        Me.prgbDownload.Location = New System.Drawing.Point(199, 209)
        Me.prgbDownload.Name = "prgbDownload"
        Me.prgbDownload.Size = New System.Drawing.Size(243, 23)
        Me.prgbDownload.TabIndex = 8
        Me.prgbDownload.Visible = False
        '
        'lblDownloadStatus
        '
        Me.lblDownloadStatus.Location = New System.Drawing.Point(196, 192)
        Me.lblDownloadStatus.Name = "lblDownloadStatus"
        Me.lblDownloadStatus.Size = New System.Drawing.Size(246, 14)
        Me.lblDownloadStatus.TabIndex = 9
        Me.lblDownloadStatus.Text = "Connecting"
        Me.lblDownloadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDownloadStatus.Visible = False
        '
        'FormActivate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 264)
        Me.Controls.Add(Me.lblDownloadStatus)
        Me.Controls.Add(Me.prgbDownload)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.lblNewVersion)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.btnActivate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtChangeLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormActivate"
        Me.Text = "Hack Me 5"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtChangeLog As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnActivate As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblNewVersion As System.Windows.Forms.Label
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents prgbDownload As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDownloadStatus As System.Windows.Forms.Label
End Class
