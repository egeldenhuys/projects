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
        Me.components = New System.ComponentModel.Container()
        Me.Apple1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.TimerDrop = New System.Windows.Forms.Timer(Me.components)
        Me.TimerSpin = New System.Windows.Forms.Timer(Me.components)
        Me.TimerManMove = New System.Windows.Forms.Timer(Me.components)
        Me.picBoxMan = New System.Windows.Forms.PictureBox()
        CType(Me.Apple1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxMan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Apple1
        '
        Me.Apple1.BackColor = System.Drawing.Color.Transparent
        Me.Apple1.Image = Global.Apple_Tree.My.Resources.Resources.cartoon_apple_81
        Me.Apple1.Location = New System.Drawing.Point(12, 63)
        Me.Apple1.Name = "Apple1"
        Me.Apple1.Size = New System.Drawing.Size(40, 40)
        Me.Apple1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Apple1.TabIndex = 1
        Me.Apple1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Apple_Tree.My.Resources.Resources.cartoon_apple_81
        Me.PictureBox1.Location = New System.Drawing.Point(58, 103)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.Apple_Tree.My.Resources.Resources.cartoon_apple_81
        Me.PictureBox2.Location = New System.Drawing.Point(106, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.Apple_Tree.My.Resources.Resources.cartoon_apple_81
        Me.PictureBox3.Location = New System.Drawing.Point(192, 37)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 4
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.Apple_Tree.My.Resources.Resources.cartoon_apple_81
        Me.PictureBox4.Location = New System.Drawing.Point(144, 114)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 5
        Me.PictureBox4.TabStop = False
        '
        'TimerDrop
        '
        Me.TimerDrop.Interval = 1
        '
        'TimerSpin
        '
        '
        'TimerManMove
        '
        Me.TimerManMove.Interval = 1
        '
        'picBoxMan
        '
        Me.picBoxMan.BackColor = System.Drawing.Color.Transparent
        Me.picBoxMan.Image = Global.Apple_Tree.My.Resources.Resources.man_upright
        Me.picBoxMan.Location = New System.Drawing.Point(217, 114)
        Me.picBoxMan.Name = "picBoxMan"
        Me.picBoxMan.Size = New System.Drawing.Size(36, 142)
        Me.picBoxMan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBoxMan.TabIndex = 6
        Me.picBoxMan.TabStop = False
        Me.picBoxMan.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Apple_Tree.My.Resources.Resources.Tree_256x256
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(253, 257)
        Me.Controls.Add(Me.picBoxMan)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Apple1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Apple Tree"
        CType(Me.Apple1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxMan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Apple1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TimerDrop As System.Windows.Forms.Timer
    Friend WithEvents TimerSpin As System.Windows.Forms.Timer
    Friend WithEvents TimerManMove As System.Windows.Forms.Timer
    Friend WithEvents picBoxMan As System.Windows.Forms.PictureBox

End Class
