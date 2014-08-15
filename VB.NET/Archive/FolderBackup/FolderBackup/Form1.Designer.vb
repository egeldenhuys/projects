<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDest = New System.Windows.Forms.TextBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnSource = New System.Windows.Forms.Button()
        Me.btnDest = New System.Windows.Forms.Button()
        Me.fbSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.fbDest = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(12, 21)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(429, 20)
        Me.txtSource.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Source"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Destination"
        '
        'txtDest
        '
        Me.txtDest.Location = New System.Drawing.Point(12, 72)
        Me.txtDest.Name = "txtDest"
        Me.txtDest.Size = New System.Drawing.Size(429, 20)
        Me.txtDest.TabIndex = 2
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(235, 107)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 4
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnSource
        '
        Me.btnSource.Location = New System.Drawing.Point(447, 19)
        Me.btnSource.Name = "btnSource"
        Me.btnSource.Size = New System.Drawing.Size(75, 23)
        Me.btnSource.TabIndex = 5
        Me.btnSource.Text = "Browse..."
        Me.btnSource.UseVisualStyleBackColor = True
        '
        'btnDest
        '
        Me.btnDest.Location = New System.Drawing.Point(447, 72)
        Me.btnDest.Name = "btnDest"
        Me.btnDest.Size = New System.Drawing.Size(75, 23)
        Me.btnDest.TabIndex = 6
        Me.btnDest.Text = "Browse..."
        Me.btnDest.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 146)
        Me.Controls.Add(Me.btnDest)
        Me.Controls.Add(Me.btnSource)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDest)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSource)
        Me.Name = "Form1"
        Me.Text = "Folder Backup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDest As System.Windows.Forms.TextBox
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnSource As System.Windows.Forms.Button
    Friend WithEvents btnDest As System.Windows.Forms.Button
    Friend WithEvents fbSource As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents fbDest As System.Windows.Forms.FolderBrowserDialog

End Class
