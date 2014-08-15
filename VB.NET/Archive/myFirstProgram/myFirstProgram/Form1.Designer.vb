<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form1
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
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.boxLetters = New System.Windows.Forms.TextBox()
        Me.boxRandomized = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(99, 229)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerate.TabIndex = 0
        Me.btnGenerate.Text = "Button1"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'boxLetters
        '
        Me.boxLetters.Location = New System.Drawing.Point(12, 69)
        Me.boxLetters.Name = "boxLetters"
        Me.boxLetters.Size = New System.Drawing.Size(100, 20)
        Me.boxLetters.TabIndex = 1
        '
        'boxRandomized
        '
        Me.boxRandomized.Location = New System.Drawing.Point(172, 69)
        Me.boxRandomized.Name = "boxRandomized"
        Me.boxRandomized.Size = New System.Drawing.Size(100, 20)
        Me.boxRandomized.TabIndex = 2
        '
        'form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.boxRandomized)
        Me.Controls.Add(Me.boxLetters)
        Me.Controls.Add(Me.btnGenerate)
        Me.Name = "form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents boxLetters As System.Windows.Forms.TextBox
    Friend WithEvents boxRandomized As System.Windows.Forms.TextBox
End Class
