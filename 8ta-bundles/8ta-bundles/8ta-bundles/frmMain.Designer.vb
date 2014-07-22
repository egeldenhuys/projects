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
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.lblOnPeak = New System.Windows.Forms.Label()
        Me.lblOffPeak = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrRefresh
        '
        '
        'lblOnPeak
        '
        Me.lblOnPeak.AutoSize = True
        Me.lblOnPeak.Location = New System.Drawing.Point(0, 9)
        Me.lblOnPeak.Name = "lblOnPeak"
        Me.lblOnPeak.Size = New System.Drawing.Size(87, 13)
        Me.lblOnPeak.TabIndex = 0
        Me.lblOnPeak.Text = "Peak Time Data:"
        '
        'lblOffPeak
        '
        Me.lblOffPeak.AutoSize = True
        Me.lblOffPeak.Location = New System.Drawing.Point(0, 33)
        Me.lblOffPeak.Name = "lblOffPeak"
        Me.lblOffPeak.Size = New System.Drawing.Size(104, 13)
        Me.lblOffPeak.TabIndex = 1
        Me.lblOffPeak.Text = "Off Peak Time Data:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 240)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(284, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 17)
        Me.lblStatus.Text = "Status:"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(0, 65)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lblOffPeak)
        Me.Controls.Add(Me.lblOnPeak)
        Me.Name = "frmMain"
        Me.Text = "8ta Bundles"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents lblOnPeak As System.Windows.Forms.Label
    Friend WithEvents lblOffPeak As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnRefresh As System.Windows.Forms.Button

End Class
