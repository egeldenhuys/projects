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
        Me.txtGame = New System.Windows.Forms.TextBox()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtGame
        '
        Me.txtGame.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtGame.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtGame.Location = New System.Drawing.Point(0, 0)
        Me.txtGame.Multiline = True
        Me.txtGame.Name = "txtGame"
        Me.txtGame.ReadOnly = True
        Me.txtGame.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGame.Size = New System.Drawing.Size(416, 322)
        Me.txtGame.TabIndex = 0
        '
        'txtInput
        '
        Me.txtInput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtInput.Location = New System.Drawing.Point(0, 328)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(416, 20)
        Me.txtInput.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 348)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.txtGame)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtGame As System.Windows.Forms.TextBox
    Friend WithEvents txtInput As System.Windows.Forms.TextBox

End Class
