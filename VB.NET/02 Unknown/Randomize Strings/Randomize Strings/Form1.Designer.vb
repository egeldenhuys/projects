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
        Me.tbLength = New System.Windows.Forms.TextBox()
        Me.tbAmount = New System.Windows.Forms.TextBox()
        Me.tbCharacters = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.listResults = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'tbLength
        '
        Me.tbLength.Location = New System.Drawing.Point(113, 11)
        Me.tbLength.Name = "tbLength"
        Me.tbLength.Size = New System.Drawing.Size(77, 20)
        Me.tbLength.TabIndex = 0
        '
        'tbAmount
        '
        Me.tbAmount.Location = New System.Drawing.Point(113, 37)
        Me.tbAmount.Name = "tbAmount"
        Me.tbAmount.Size = New System.Drawing.Size(77, 20)
        Me.tbAmount.TabIndex = 1
        '
        'tbCharacters
        '
        Me.tbCharacters.Location = New System.Drawing.Point(113, 63)
        Me.tbCharacters.Name = "tbCharacters"
        Me.tbCharacters.Size = New System.Drawing.Size(136, 20)
        Me.tbCharacters.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(67, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Length"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Amount to generate"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(49, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Characters"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(279, 25)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(72, 42)
        Me.btnGenerate.TabIndex = 6
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'listResults
        '
        Me.listResults.FormattingEnabled = True
        Me.listResults.Location = New System.Drawing.Point(12, 89)
        Me.listResults.Name = "listResults"
        Me.listResults.Size = New System.Drawing.Size(401, 160)
        Me.listResults.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(425, 259)
        Me.Controls.Add(Me.listResults)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbCharacters)
        Me.Controls.Add(Me.tbAmount)
        Me.Controls.Add(Me.tbLength)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbLength As System.Windows.Forms.TextBox
    Friend WithEvents tbAmount As System.Windows.Forms.TextBox
    Friend WithEvents tbCharacters As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents listResults As System.Windows.Forms.ListBox

End Class
