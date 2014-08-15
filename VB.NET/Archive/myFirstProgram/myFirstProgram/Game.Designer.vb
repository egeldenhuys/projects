<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Game
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
        Me.boxBetMoney = New System.Windows.Forms.TextBox()
        Me.btnBet = New System.Windows.Forms.Button()
        Me.lblMoney = New System.Windows.Forms.Label()
        Me.lblDieRoll = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnAddMoney = New System.Windows.Forms.Button()
        Me.lblDescription2 = New System.Windows.Forms.Label()
        Me.lblDescription3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'boxBetMoney
        '
        Me.boxBetMoney.Location = New System.Drawing.Point(97, 112)
        Me.boxBetMoney.Name = "boxBetMoney"
        Me.boxBetMoney.Size = New System.Drawing.Size(100, 20)
        Me.boxBetMoney.TabIndex = 0
        '
        'btnBet
        '
        Me.btnBet.Location = New System.Drawing.Point(11, 109)
        Me.btnBet.Name = "btnBet"
        Me.btnBet.Size = New System.Drawing.Size(75, 23)
        Me.btnBet.TabIndex = 1
        Me.btnBet.Text = "Bet"
        Me.btnBet.UseVisualStyleBackColor = True
        '
        'lblMoney
        '
        Me.lblMoney.AutoSize = True
        Me.lblMoney.Location = New System.Drawing.Point(94, 135)
        Me.lblMoney.Name = "lblMoney"
        Me.lblMoney.Size = New System.Drawing.Size(13, 13)
        Me.lblMoney.TabIndex = 2
        Me.lblMoney.Text = "0"
        '
        'lblDieRoll
        '
        Me.lblDieRoll.AutoSize = True
        Me.lblDieRoll.Location = New System.Drawing.Point(12, 79)
        Me.lblDieRoll.Name = "lblDieRoll"
        Me.lblDieRoll.Size = New System.Drawing.Size(63, 13)
        Me.lblDieRoll.TabIndex = 3
        Me.lblDieRoll.Text = "Roll amount"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(9, 8)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(247, 26)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "If the number is smaller than 60 you loose your bet." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If the number is 60 or lare" & _
            "r you win double your bet."
        '
        'btnAddMoney
        '
        Me.btnAddMoney.Location = New System.Drawing.Point(197, 37)
        Me.btnAddMoney.Name = "btnAddMoney"
        Me.btnAddMoney.Size = New System.Drawing.Size(75, 23)
        Me.btnAddMoney.TabIndex = 5
        Me.btnAddMoney.Text = "Add $100"
        Me.btnAddMoney.UseVisualStyleBackColor = True
        '
        'lblDescription2
        '
        Me.lblDescription2.AutoSize = True
        Me.lblDescription2.Location = New System.Drawing.Point(85, 114)
        Me.lblDescription2.Name = "lblDescription2"
        Me.lblDescription2.Size = New System.Drawing.Size(13, 13)
        Me.lblDescription2.TabIndex = 6
        Me.lblDescription2.Text = "$"
        '
        'lblDescription3
        '
        Me.lblDescription3.AutoSize = True
        Me.lblDescription3.Location = New System.Drawing.Point(21, 135)
        Me.lblDescription3.Name = "lblDescription3"
        Me.lblDescription3.Size = New System.Drawing.Size(76, 13)
        Me.lblDescription3.TabIndex = 7
        Me.lblDescription3.Text = "Your Money: $"
        '
        'Game
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 173)
        Me.Controls.Add(Me.lblDescription3)
        Me.Controls.Add(Me.lblDescription2)
        Me.Controls.Add(Me.btnAddMoney)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblDieRoll)
        Me.Controls.Add(Me.lblMoney)
        Me.Controls.Add(Me.btnBet)
        Me.Controls.Add(Me.boxBetMoney)
        Me.Name = "Game"
        Me.Text = "Game"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents boxBetMoney As System.Windows.Forms.TextBox
    Friend WithEvents btnBet As System.Windows.Forms.Button
    Friend WithEvents lblMoney As System.Windows.Forms.Label
    Friend WithEvents lblDieRoll As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents btnAddMoney As System.Windows.Forms.Button
    Friend WithEvents lblDescription2 As System.Windows.Forms.Label
    Friend WithEvents lblDescription3 As System.Windows.Forms.Label
End Class
