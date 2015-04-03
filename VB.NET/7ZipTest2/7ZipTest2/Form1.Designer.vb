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
        Me.btnSource = New System.Windows.Forms.Button()
        Me.btnDest = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDest = New System.Windows.Forms.TextBox()
        Me.btnCompress = New System.Windows.Forms.Button()
        Me.txtConsole = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(12, 35)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(260, 20)
        Me.txtSource.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Source"
        '
        'btnSource
        '
        Me.btnSource.Location = New System.Drawing.Point(93, 61)
        Me.btnSource.Name = "btnSource"
        Me.btnSource.Size = New System.Drawing.Size(75, 23)
        Me.btnSource.TabIndex = 2
        Me.btnSource.Text = "Browse..."
        Me.btnSource.UseVisualStyleBackColor = True
        '
        'btnDest
        '
        Me.btnDest.Location = New System.Drawing.Point(93, 141)
        Me.btnDest.Name = "btnDest"
        Me.btnDest.Size = New System.Drawing.Size(75, 23)
        Me.btnDest.TabIndex = 5
        Me.btnDest.Text = "Browse..."
        Me.btnDest.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Destination"
        '
        'txtDest
        '
        Me.txtDest.Location = New System.Drawing.Point(12, 115)
        Me.txtDest.Name = "txtDest"
        Me.txtDest.Size = New System.Drawing.Size(260, 20)
        Me.txtDest.TabIndex = 3
        '
        'btnCompress
        '
        Me.btnCompress.Location = New System.Drawing.Point(93, 227)
        Me.btnCompress.Name = "btnCompress"
        Me.btnCompress.Size = New System.Drawing.Size(75, 23)
        Me.btnCompress.TabIndex = 6
        Me.btnCompress.Text = "Compress"
        Me.btnCompress.UseVisualStyleBackColor = True
        '
        'txtConsole
        '
        Me.txtConsole.Location = New System.Drawing.Point(354, 12)
        Me.txtConsole.Multiline = True
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsole.Size = New System.Drawing.Size(443, 238)
        Me.txtConsole.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 262)
        Me.Controls.Add(Me.txtConsole)
        Me.Controls.Add(Me.btnCompress)
        Me.Controls.Add(Me.btnDest)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDest)
        Me.Controls.Add(Me.btnSource)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSource)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSource As System.Windows.Forms.Button
    Friend WithEvents btnDest As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDest As System.Windows.Forms.TextBox
    Friend WithEvents btnCompress As System.Windows.Forms.Button
    Friend WithEvents txtConsole As System.Windows.Forms.TextBox

End Class
