<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.btnSpin = New System.Windows.Forms.Button()
        Me.Slot1 = New System.Windows.Forms.Button()
        Me.Slot2 = New System.Windows.Forms.Button()
        Me.Slot3 = New System.Windows.Forms.Button()
        Me.btnStop1 = New System.Windows.Forms.Button()
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.btnStop2 = New System.Windows.Forms.Button()
        Me.btnStop3 = New System.Windows.Forms.Button()
        Me.btnStopAll = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOptions = New System.Windows.Forms.Button()
        Me.pnlOptions = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.pnlMain.SuspendLayout()
        Me.pnlOptions.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSpin
        '
        Me.btnSpin.Location = New System.Drawing.Point(108, 164)
        Me.btnSpin.Name = "btnSpin"
        Me.btnSpin.Size = New System.Drawing.Size(75, 23)
        Me.btnSpin.TabIndex = 0
        Me.btnSpin.Text = "Spin"
        Me.btnSpin.UseVisualStyleBackColor = True
        '
        'Slot1
        '
        Me.Slot1.BackColor = System.Drawing.Color.Silver
        Me.Slot1.Enabled = False
        Me.Slot1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Slot1.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Slot1.Location = New System.Drawing.Point(28, 42)
        Me.Slot1.Name = "Slot1"
        Me.Slot1.Size = New System.Drawing.Size(75, 60)
        Me.Slot1.TabIndex = 1
        Me.Slot1.UseVisualStyleBackColor = False
        '
        'Slot2
        '
        Me.Slot2.BackColor = System.Drawing.Color.Silver
        Me.Slot2.Enabled = False
        Me.Slot2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Slot2.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Slot2.Location = New System.Drawing.Point(108, 42)
        Me.Slot2.Name = "Slot2"
        Me.Slot2.Size = New System.Drawing.Size(75, 60)
        Me.Slot2.TabIndex = 2
        Me.Slot2.UseVisualStyleBackColor = False
        '
        'Slot3
        '
        Me.Slot3.BackColor = System.Drawing.Color.Silver
        Me.Slot3.Enabled = False
        Me.Slot3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Slot3.Font = New System.Drawing.Font("Microsoft Sans Serif", 23.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Slot3.Location = New System.Drawing.Point(188, 42)
        Me.Slot3.Name = "Slot3"
        Me.Slot3.Size = New System.Drawing.Size(75, 60)
        Me.Slot3.TabIndex = 3
        Me.Slot3.UseVisualStyleBackColor = False
        '
        'btnStop1
        '
        Me.btnStop1.Location = New System.Drawing.Point(42, 108)
        Me.btnStop1.Name = "btnStop1"
        Me.btnStop1.Size = New System.Drawing.Size(46, 23)
        Me.btnStop1.TabIndex = 4
        Me.btnStop1.Text = "Stop"
        Me.btnStop1.UseVisualStyleBackColor = True
        '
        'TimerMain
        '
        '
        'btnStop2
        '
        Me.btnStop2.Location = New System.Drawing.Point(122, 108)
        Me.btnStop2.Name = "btnStop2"
        Me.btnStop2.Size = New System.Drawing.Size(46, 23)
        Me.btnStop2.TabIndex = 5
        Me.btnStop2.Text = "Stop"
        Me.btnStop2.UseVisualStyleBackColor = True
        '
        'btnStop3
        '
        Me.btnStop3.Location = New System.Drawing.Point(202, 108)
        Me.btnStop3.Name = "btnStop3"
        Me.btnStop3.Size = New System.Drawing.Size(46, 23)
        Me.btnStop3.TabIndex = 6
        Me.btnStop3.Text = "Stop"
        Me.btnStop3.UseVisualStyleBackColor = True
        '
        'btnStopAll
        '
        Me.btnStopAll.Location = New System.Drawing.Point(12, 229)
        Me.btnStopAll.Name = "btnStopAll"
        Me.btnStopAll.Size = New System.Drawing.Size(75, 23)
        Me.btnStopAll.TabIndex = 7
        Me.btnStopAll.Text = "Stop All"
        Me.btnStopAll.UseVisualStyleBackColor = True
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.btnOptions)
        Me.pnlMain.Controls.Add(Me.Slot1)
        Me.pnlMain.Controls.Add(Me.Slot2)
        Me.pnlMain.Controls.Add(Me.Slot3)
        Me.pnlMain.Controls.Add(Me.btnSpin)
        Me.pnlMain.Controls.Add(Me.btnStop1)
        Me.pnlMain.Controls.Add(Me.btnStop2)
        Me.pnlMain.Controls.Add(Me.btnStop3)
        Me.pnlMain.Controls.Add(Me.btnStopAll)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(284, 264)
        Me.pnlMain.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Label1"
        '
        'btnOptions
        '
        Me.btnOptions.Location = New System.Drawing.Point(202, 229)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(75, 23)
        Me.btnOptions.TabIndex = 8
        Me.btnOptions.Text = "Options"
        Me.btnOptions.UseVisualStyleBackColor = True
        '
        'pnlOptions
        '
        Me.pnlOptions.Controls.Add(Me.Label2)
        Me.pnlOptions.Controls.Add(Me.btnSave)
        Me.pnlOptions.Controls.Add(Me.GroupBox1)
        Me.pnlOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlOptions.Location = New System.Drawing.Point(0, 0)
        Me.pnlOptions.Name = "pnlOptions"
        Me.pnlOptions.Size = New System.Drawing.Size(284, 264)
        Me.pnlOptions.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Label2"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(105, 229)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Game Type"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(6, 62)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(71, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Auto Spin"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(105, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Bet on a Number"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 18)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(108, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Stop The Spinner"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlOptions)
        Me.Name = "Main"
        Me.Text = "Slot Machine"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlOptions.ResumeLayout(False)
        Me.pnlOptions.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSpin As System.Windows.Forms.Button
    Friend WithEvents Slot1 As System.Windows.Forms.Button
    Friend WithEvents Slot2 As System.Windows.Forms.Button
    Friend WithEvents Slot3 As System.Windows.Forms.Button
    Friend WithEvents btnStop1 As System.Windows.Forms.Button
    Friend WithEvents TimerMain As System.Windows.Forms.Timer
    Friend WithEvents btnStop2 As System.Windows.Forms.Button
    Friend WithEvents btnStop3 As System.Windows.Forms.Button
    Friend WithEvents btnStopAll As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnOptions As System.Windows.Forms.Button
    Friend WithEvents pnlOptions As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
