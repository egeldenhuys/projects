<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GuesingGame
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
        Me.boxMoneyBet = New System.Windows.Forms.TextBox()
        Me.btnBet = New System.Windows.Forms.Button()
        Me.lblNumber = New System.Windows.Forms.Label()
        Me.lblMoney = New System.Windows.Forms.Label()
        Me.boxNumberGuess = New System.Windows.Forms.TextBox()
        Me.lblDesc1 = New System.Windows.Forms.Label()
        Me.lblDesc2 = New System.Windows.Forms.Label()
        Me.lblNumberGuessed = New System.Windows.Forms.Label()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'boxMoneyBet
        '
        Me.boxMoneyBet.Location = New System.Drawing.Point(118, 182)
        Me.boxMoneyBet.Name = "boxMoneyBet"
        Me.boxMoneyBet.Size = New System.Drawing.Size(100, 20)
        Me.boxMoneyBet.TabIndex = 0
        '
        'btnBet
        '
        Me.btnBet.Location = New System.Drawing.Point(37, 179)
        Me.btnBet.Name = "btnBet"
        Me.btnBet.Size = New System.Drawing.Size(75, 23)
        Me.btnBet.TabIndex = 1
        Me.btnBet.Text = "Bet"
        Me.btnBet.UseVisualStyleBackColor = True
        '
        'lblNumber
        '
        Me.lblNumber.AutoSize = True
        Me.lblNumber.Location = New System.Drawing.Point(115, 71)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(44, 13)
        Me.lblNumber.TabIndex = 2
        Me.lblNumber.Text = "Number"
        '
        'lblMoney
        '
        Me.lblMoney.AutoSize = True
        Me.lblMoney.Location = New System.Drawing.Point(195, 9)
        Me.lblMoney.Name = "lblMoney"
        Me.lblMoney.Size = New System.Drawing.Size(85, 13)
        Me.lblMoney.TabIndex = 3
        Me.lblMoney.Text = "Money Available"
        '
        'boxNumberGuess
        '
        Me.boxNumberGuess.Location = New System.Drawing.Point(118, 208)
        Me.boxNumberGuess.Name = "boxNumberGuess"
        Me.boxNumberGuess.Size = New System.Drawing.Size(100, 20)
        Me.boxNumberGuess.TabIndex = 4
        '
        'lblDesc1
        '
        Me.lblDesc1.AutoSize = True
        Me.lblDesc1.Location = New System.Drawing.Point(73, 211)
        Me.lblDesc1.Name = "lblDesc1"
        Me.lblDesc1.Size = New System.Drawing.Size(44, 13)
        Me.lblDesc1.TabIndex = 5
        Me.lblDesc1.Text = "Number"
        '
        'lblDesc2
        '
        Me.lblDesc2.AutoSize = True
        Me.lblDesc2.Location = New System.Drawing.Point(24, 71)
        Me.lblDesc2.Name = "lblDesc2"
        Me.lblDesc2.Size = New System.Drawing.Size(89, 26)
        Me.lblDesc2.TabIndex = 6
        Me.lblDesc2.Text = "The number was:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     You guessed:"
        '
        'lblNumberGuessed
        '
        Me.lblNumberGuessed.AutoSize = True
        Me.lblNumberGuessed.Location = New System.Drawing.Point(115, 84)
        Me.lblNumberGuessed.Name = "lblNumberGuessed"
        Me.lblNumberGuessed.Size = New System.Drawing.Size(49, 13)
        Me.lblNumberGuessed.TabIndex = 7
        Me.lblNumberGuessed.Text = "Guessed"
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(2, 4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(75, 23)
        Me.btnSettings.TabIndex = 8
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'GuesingGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.lblNumberGuessed)
        Me.Controls.Add(Me.lblDesc2)
        Me.Controls.Add(Me.lblDesc1)
        Me.Controls.Add(Me.boxNumberGuess)
        Me.Controls.Add(Me.lblMoney)
        Me.Controls.Add(Me.lblNumber)
        Me.Controls.Add(Me.btnBet)
        Me.Controls.Add(Me.boxMoneyBet)
        Me.Name = "GuesingGame"
        Me.Text = "GuesingGame"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents boxMoneyBet As System.Windows.Forms.TextBox
    Friend WithEvents btnBet As System.Windows.Forms.Button
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents lblMoney As System.Windows.Forms.Label
    Friend WithEvents boxNumberGuess As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc1 As System.Windows.Forms.Label
    Friend WithEvents lblDesc2 As System.Windows.Forms.Label
    Friend WithEvents lblNumberGuessed As System.Windows.Forms.Label
    Friend WithEvents btnSettings As System.Windows.Forms.Button
End Class
