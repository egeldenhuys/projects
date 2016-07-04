<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GuessingGameSettings
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.boxMoney = New System.Windows.Forms.TextBox()
        Me.lblDesc1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(99, 229)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'boxMoney
        '
        Me.boxMoney.Location = New System.Drawing.Point(172, 12)
        Me.boxMoney.Name = "boxMoney"
        Me.boxMoney.Size = New System.Drawing.Size(100, 20)
        Me.boxMoney.TabIndex = 1
        '
        'lblDesc1
        '
        Me.lblDesc1.AutoSize = True
        Me.lblDesc1.Location = New System.Drawing.Point(127, 15)
        Me.lblDesc1.Name = "lblDesc1"
        Me.lblDesc1.Size = New System.Drawing.Size(42, 13)
        Me.lblDesc1.TabIndex = 2
        Me.lblDesc1.Text = "Money:"
        '
        'GuessingGameSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.lblDesc1)
        Me.Controls.Add(Me.boxMoney)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "GuessingGameSettings"
        Me.Text = "GuessingGameSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents boxMoney As System.Windows.Forms.TextBox
    Friend WithEvents lblDesc1 As System.Windows.Forms.Label
End Class
