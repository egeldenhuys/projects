<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RandomizerTest
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
        Me.btnRandomize = New System.Windows.Forms.Button()
        Me.boxLetters = New System.Windows.Forms.TextBox()
        Me.boxRandomized = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnRandomize
        '
        Me.btnRandomize.Location = New System.Drawing.Point(97, 229)
        Me.btnRandomize.Name = "btnRandomize"
        Me.btnRandomize.Size = New System.Drawing.Size(75, 23)
        Me.btnRandomize.TabIndex = 0
        Me.btnRandomize.Text = "Randomize"
        Me.btnRandomize.UseVisualStyleBackColor = True
        '
        'boxLetters
        '
        Me.boxLetters.Location = New System.Drawing.Point(12, 74)
        Me.boxLetters.Name = "boxLetters"
        Me.boxLetters.Size = New System.Drawing.Size(100, 20)
        Me.boxLetters.TabIndex = 1
        '
        'boxRandomized
        '
        Me.boxRandomized.Location = New System.Drawing.Point(162, 74)
        Me.boxRandomized.Name = "boxRandomized"
        Me.boxRandomized.Size = New System.Drawing.Size(100, 20)
        Me.boxRandomized.TabIndex = 2
        '
        'Test
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.boxRandomized)
        Me.Controls.Add(Me.boxLetters)
        Me.Controls.Add(Me.btnRandomize)
        Me.Name = "Test"
        Me.Text = "Test"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRandomize As System.Windows.Forms.Button
    Friend WithEvents boxLetters As System.Windows.Forms.TextBox
    Friend WithEvents boxRandomized As System.Windows.Forms.TextBox
End Class
