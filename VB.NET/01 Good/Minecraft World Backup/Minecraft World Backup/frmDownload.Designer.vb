<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownload
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
        Me.pgbMain = New System.Windows.Forms.ProgressBar()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.pgbFile = New System.Windows.Forms.ProgressBar()
        Me.lblDownload = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pgbMain
        '
        Me.pgbMain.Location = New System.Drawing.Point(15, 54)
        Me.pgbMain.Name = "pgbMain"
        Me.pgbMain.Size = New System.Drawing.Size(260, 23)
        Me.pgbMain.TabIndex = 0
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(107, 83)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'pgbFile
        '
        Me.pgbFile.Location = New System.Drawing.Point(15, 25)
        Me.pgbFile.Name = "pgbFile"
        Me.pgbFile.Size = New System.Drawing.Size(260, 23)
        Me.pgbFile.TabIndex = 2
        '
        'lblDownload
        '
        Me.lblDownload.Location = New System.Drawing.Point(12, 9)
        Me.lblDownload.Name = "lblDownload"
        Me.lblDownload.Size = New System.Drawing.Size(260, 13)
        Me.lblDownload.TabIndex = 3
        Me.lblDownload.Text = "File"
        Me.lblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmDownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 121)
        Me.Controls.Add(Me.lblDownload)
        Me.Controls.Add(Me.pgbFile)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.pgbMain)
        Me.Name = "frmDownload"
        Me.Text = "Download"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgbMain As System.Windows.Forms.ProgressBar
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents pgbFile As System.Windows.Forms.ProgressBar
    Friend WithEvents lblDownload As System.Windows.Forms.Label
End Class
