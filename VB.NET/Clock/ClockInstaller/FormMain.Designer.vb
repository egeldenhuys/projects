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
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.btnDestination = New System.Windows.Forms.Button()
        Me.btnInstall = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.prgDown = New System.Windows.Forms.ProgressBar()
        Me.lblDownStatus = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(6, 19)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(400, 20)
        Me.txtDestination.TabIndex = 0
        '
        'btnDestination
        '
        Me.btnDestination.Location = New System.Drawing.Point(412, 16)
        Me.btnDestination.Name = "btnDestination"
        Me.btnDestination.Size = New System.Drawing.Size(108, 23)
        Me.btnDestination.TabIndex = 1
        Me.btnDestination.Text = "Change Destination"
        Me.btnDestination.UseVisualStyleBackColor = True
        '
        'btnInstall
        '
        Me.btnInstall.Location = New System.Drawing.Point(237, 73)
        Me.btnInstall.Name = "btnInstall"
        Me.btnInstall.Size = New System.Drawing.Size(75, 23)
        Me.btnInstall.TabIndex = 3
        Me.btnInstall.Text = "Install"
        Me.btnInstall.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDestination)
        Me.GroupBox1.Controls.Add(Me.btnDestination)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 55)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Installation Directory"
        '
        'prgDown
        '
        Me.prgDown.Location = New System.Drawing.Point(128, 122)
        Me.prgDown.Name = "prgDown"
        Me.prgDown.Size = New System.Drawing.Size(292, 23)
        Me.prgDown.TabIndex = 2
        Me.prgDown.Visible = False
        '
        'lblDownStatus
        '
        Me.lblDownStatus.Location = New System.Drawing.Point(12, 106)
        Me.lblDownStatus.Name = "lblDownStatus"
        Me.lblDownStatus.Size = New System.Drawing.Size(520, 13)
        Me.lblDownStatus.TabIndex = 5
        Me.lblDownStatus.Text = "lblDownStatus"
        Me.lblDownStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDownStatus.Visible = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 155)
        Me.Controls.Add(Me.lblDownStatus)
        Me.Controls.Add(Me.prgDown)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnInstall)
        Me.Name = "FormMain"
        Me.Text = "Clock Installer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents btnDestination As System.Windows.Forms.Button
    Friend WithEvents btnInstall As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents prgDown As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDownStatus As System.Windows.Forms.Label
End Class
