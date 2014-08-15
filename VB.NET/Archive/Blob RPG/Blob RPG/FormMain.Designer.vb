<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.Map1Panel = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Player = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Map1Panel.SuspendLayout()
        CType(Me.Player, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerMain
        '
        Me.TimerMain.Enabled = True
        Me.TimerMain.Interval = 1
        '
        'Map1Panel
        '
        Me.Map1Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Map1Panel.Controls.Add(Me.PictureBox1)
        Me.Map1Panel.Controls.Add(Me.Button2)
        Me.Map1Panel.Controls.Add(Me.Label2)
        Me.Map1Panel.Controls.Add(Me.Label1)
        Me.Map1Panel.Location = New System.Drawing.Point(0, 1)
        Me.Map1Panel.Name = "Map1Panel"
        Me.Map1Panel.Size = New System.Drawing.Size(2425, 2052)
        Me.Map1Panel.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(362, 234)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(24, 29)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 364)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(181, 151)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Label1"
        '
        'Player
        '
        Me.Player.Image = Global.Blob_RPG.My.Resources.Resources.Player
        Me.Player.Location = New System.Drawing.Point(242, 293)
        Me.Player.Name = "Player"
        Me.Player.Size = New System.Drawing.Size(25, 25)
        Me.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Player.TabIndex = 1
        Me.Player.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Blob_RPG.My.Resources.Resources.Map_complete
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(752, 605)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1253, 604)
        Me.Controls.Add(Me.Player)
        Me.Controls.Add(Me.Map1Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormMain"
        Me.Text = "Blob RPG"
        Me.Map1Panel.ResumeLayout(False)
        Me.Map1Panel.PerformLayout()
        CType(Me.Player, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerMain As System.Windows.Forms.Timer
    Friend WithEvents Player As System.Windows.Forms.PictureBox
    Friend WithEvents Map1Panel As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
