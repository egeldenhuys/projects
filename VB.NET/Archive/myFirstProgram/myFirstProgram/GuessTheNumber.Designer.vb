<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GuessTheNumber
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
        Me.boxGuess = New System.Windows.Forms.TextBox()
        Me.btnGuess = New System.Windows.Forms.Button()
        Me.lblIndicator = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnGiveUp = New System.Windows.Forms.Button()
        Me.lblGiveUp = New System.Windows.Forms.Label()
        Me.boxNum = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblDesc1 = New System.Windows.Forms.Label()
        Me.Correct = New System.Windows.Forms.Timer(Me.components)
        Me.lblError = New System.Windows.Forms.Label()
        Me.btnAutoReset = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'boxGuess
        '
        Me.boxGuess.Location = New System.Drawing.Point(83, 42)
        Me.boxGuess.Name = "boxGuess"
        Me.boxGuess.Size = New System.Drawing.Size(100, 20)
        Me.boxGuess.TabIndex = 0
        '
        'btnGuess
        '
        Me.btnGuess.Location = New System.Drawing.Point(2, 40)
        Me.btnGuess.Name = "btnGuess"
        Me.btnGuess.Size = New System.Drawing.Size(75, 23)
        Me.btnGuess.TabIndex = 1
        Me.btnGuess.Text = "Guess:"
        Me.btnGuess.UseVisualStyleBackColor = True
        '
        'lblIndicator
        '
        Me.lblIndicator.AutoSize = True
        Me.lblIndicator.Location = New System.Drawing.Point(189, 45)
        Me.lblIndicator.Name = "lblIndicator"
        Me.lblIndicator.Size = New System.Drawing.Size(48, 13)
        Me.lblIndicator.TabIndex = 2
        Me.lblIndicator.Text = "Indicator"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(2, 2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnGiveUp
        '
        Me.btnGiveUp.Location = New System.Drawing.Point(2, 78)
        Me.btnGiveUp.Name = "btnGiveUp"
        Me.btnGiveUp.Size = New System.Drawing.Size(75, 23)
        Me.btnGiveUp.TabIndex = 4
        Me.btnGiveUp.Text = "Show Number" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnGiveUp.UseVisualStyleBackColor = True
        '
        'lblGiveUp
        '
        Me.lblGiveUp.AutoSize = True
        Me.lblGiveUp.Location = New System.Drawing.Point(83, 83)
        Me.lblGiveUp.Name = "lblGiveUp"
        Me.lblGiveUp.Size = New System.Drawing.Size(48, 13)
        Me.lblGiveUp.TabIndex = 5
        Me.lblGiveUp.Text = "Indicator"
        '
        'boxNum
        '
        Me.boxNum.Location = New System.Drawing.Point(179, 5)
        Me.boxNum.Name = "boxNum"
        Me.boxNum.Size = New System.Drawing.Size(74, 20)
        Me.boxNum.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(259, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "S"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblDesc1
        '
        Me.lblDesc1.AutoSize = True
        Me.lblDesc1.Location = New System.Drawing.Point(103, 8)
        Me.lblDesc1.Name = "lblDesc1"
        Me.lblDesc1.Size = New System.Drawing.Size(70, 13)
        Me.lblDesc1.TabIndex = 8
        Me.lblDesc1.Text = "Max Number:"
        '
        'Correct
        '
        Me.Correct.Interval = 2000
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.BackColor = System.Drawing.Color.Orange
        Me.lblError.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblError.Location = New System.Drawing.Point(189, 91)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(94, 13)
        Me.lblError.TabIndex = 9
        Me.lblError.Text = "Only use numbers!"
        '
        'btnAutoReset
        '
        Me.btnAutoReset.Location = New System.Drawing.Point(259, 27)
        Me.btnAutoReset.Name = "btnAutoReset"
        Me.btnAutoReset.Size = New System.Drawing.Size(22, 23)
        Me.btnAutoReset.TabIndex = 10
        Me.btnAutoReset.Text = "A"
        Me.btnAutoReset.UseVisualStyleBackColor = True
        '
        'GuessTheNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 113)
        Me.Controls.Add(Me.btnAutoReset)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.lblDesc1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.boxNum)
        Me.Controls.Add(Me.lblGiveUp)
        Me.Controls.Add(Me.btnGiveUp)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.lblIndicator)
        Me.Controls.Add(Me.btnGuess)
        Me.Controls.Add(Me.boxGuess)
        Me.Name = "GuessTheNumber"
        Me.Text = "GuessTheNumber"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents boxGuess As System.Windows.Forms.TextBox
    Friend WithEvents lblIndicator As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnGuess As System.Windows.Forms.Button
    Friend WithEvents btnGiveUp As System.Windows.Forms.Button
    Friend WithEvents lblGiveUp As System.Windows.Forms.Label
    Friend WithEvents boxNum As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblDesc1 As System.Windows.Forms.Label
    Friend WithEvents Correct As System.Windows.Forms.Timer
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents btnAutoReset As System.Windows.Forms.Button
End Class
