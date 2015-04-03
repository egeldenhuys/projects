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
        Me.pbD1 = New System.Windows.Forms.PictureBox()
        Me.pbD2 = New System.Windows.Forms.PictureBox()
        Me.pbD3 = New System.Windows.Forms.PictureBox()
        Me.pbP1 = New System.Windows.Forms.PictureBox()
        Me.pbP2 = New System.Windows.Forms.PictureBox()
        Me.pbP3 = New System.Windows.Forms.PictureBox()
        Me.btnHit = New System.Windows.Forms.Button()
        Me.btnStand = New System.Windows.Forms.Button()
        Me.txtConsole = New System.Windows.Forms.TextBox()
        Me.pbP4 = New System.Windows.Forms.PictureBox()
        Me.pbP5 = New System.Windows.Forms.PictureBox()
        Me.pbD4 = New System.Windows.Forms.PictureBox()
        Me.pbD5 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnInitialize = New System.Windows.Forms.Button()
        Me.btnRnd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pbD1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbD2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbD3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbP3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbP4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbP5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbD4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbD5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbD1
        '
        Me.pbD1.Location = New System.Drawing.Point(12, 12)
        Me.pbD1.Name = "pbD1"
        Me.pbD1.Size = New System.Drawing.Size(158, 246)
        Me.pbD1.TabIndex = 0
        Me.pbD1.TabStop = False
        '
        'pbD2
        '
        Me.pbD2.Location = New System.Drawing.Point(181, 12)
        Me.pbD2.Name = "pbD2"
        Me.pbD2.Size = New System.Drawing.Size(158, 246)
        Me.pbD2.TabIndex = 1
        Me.pbD2.TabStop = False
        '
        'pbD3
        '
        Me.pbD3.Location = New System.Drawing.Point(356, 12)
        Me.pbD3.Name = "pbD3"
        Me.pbD3.Size = New System.Drawing.Size(158, 246)
        Me.pbD3.TabIndex = 2
        Me.pbD3.TabStop = False
        '
        'pbP1
        '
        Me.pbP1.Location = New System.Drawing.Point(6, 317)
        Me.pbP1.Name = "pbP1"
        Me.pbP1.Size = New System.Drawing.Size(158, 246)
        Me.pbP1.TabIndex = 3
        Me.pbP1.TabStop = False
        '
        'pbP2
        '
        Me.pbP2.Location = New System.Drawing.Point(181, 317)
        Me.pbP2.Name = "pbP2"
        Me.pbP2.Size = New System.Drawing.Size(158, 246)
        Me.pbP2.TabIndex = 4
        Me.pbP2.TabStop = False
        '
        'pbP3
        '
        Me.pbP3.Location = New System.Drawing.Point(356, 317)
        Me.pbP3.Name = "pbP3"
        Me.pbP3.Size = New System.Drawing.Size(158, 246)
        Me.pbP3.TabIndex = 5
        Me.pbP3.TabStop = False
        '
        'btnHit
        '
        Me.btnHit.Location = New System.Drawing.Point(903, 12)
        Me.btnHit.Name = "btnHit"
        Me.btnHit.Size = New System.Drawing.Size(75, 23)
        Me.btnHit.TabIndex = 6
        Me.btnHit.Text = "Hit"
        Me.btnHit.UseVisualStyleBackColor = True
        '
        'btnStand
        '
        Me.btnStand.Location = New System.Drawing.Point(903, 41)
        Me.btnStand.Name = "btnStand"
        Me.btnStand.Size = New System.Drawing.Size(75, 23)
        Me.btnStand.TabIndex = 7
        Me.btnStand.Text = "Stand"
        Me.btnStand.UseVisualStyleBackColor = True
        '
        'txtConsole
        '
        Me.txtConsole.BackColor = System.Drawing.Color.Black
        Me.txtConsole.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConsole.ForeColor = System.Drawing.Color.White
        Me.txtConsole.Location = New System.Drawing.Point(903, 110)
        Me.txtConsole.Multiline = True
        Me.txtConsole.Name = "txtConsole"
        Me.txtConsole.ReadOnly = True
        Me.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConsole.Size = New System.Drawing.Size(333, 453)
        Me.txtConsole.TabIndex = 8
        '
        'pbP4
        '
        Me.pbP4.Location = New System.Drawing.Point(531, 317)
        Me.pbP4.Name = "pbP4"
        Me.pbP4.Size = New System.Drawing.Size(158, 246)
        Me.pbP4.TabIndex = 9
        Me.pbP4.TabStop = False
        '
        'pbP5
        '
        Me.pbP5.Location = New System.Drawing.Point(706, 317)
        Me.pbP5.Name = "pbP5"
        Me.pbP5.Size = New System.Drawing.Size(158, 246)
        Me.pbP5.TabIndex = 10
        Me.pbP5.TabStop = False
        '
        'pbD4
        '
        Me.pbD4.Location = New System.Drawing.Point(531, 12)
        Me.pbD4.Name = "pbD4"
        Me.pbD4.Size = New System.Drawing.Size(158, 246)
        Me.pbD4.TabIndex = 11
        Me.pbD4.TabStop = False
        '
        'pbD5
        '
        Me.pbD5.Location = New System.Drawing.Point(706, 12)
        Me.pbD5.Name = "pbD5"
        Me.pbD5.Size = New System.Drawing.Size(158, 246)
        Me.pbD5.TabIndex = 12
        Me.pbD5.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'btnInitialize
        '
        Me.btnInitialize.Location = New System.Drawing.Point(1161, 12)
        Me.btnInitialize.Name = "btnInitialize"
        Me.btnInitialize.Size = New System.Drawing.Size(75, 23)
        Me.btnInitialize.TabIndex = 13
        Me.btnInitialize.Text = "Initialize"
        Me.btnInitialize.UseVisualStyleBackColor = True
        '
        'btnRnd
        '
        Me.btnRnd.Location = New System.Drawing.Point(1137, 41)
        Me.btnRnd.Name = "btnRnd"
        Me.btnRnd.Size = New System.Drawing.Size(99, 23)
        Me.btnRnd.TabIndex = 14
        Me.btnRnd.Text = "Random Cards"
        Me.btnRnd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(128, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1247, 571)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRnd)
        Me.Controls.Add(Me.btnInitialize)
        Me.Controls.Add(Me.pbD5)
        Me.Controls.Add(Me.pbD4)
        Me.Controls.Add(Me.pbP5)
        Me.Controls.Add(Me.pbP4)
        Me.Controls.Add(Me.txtConsole)
        Me.Controls.Add(Me.btnStand)
        Me.Controls.Add(Me.btnHit)
        Me.Controls.Add(Me.pbP3)
        Me.Controls.Add(Me.pbP2)
        Me.Controls.Add(Me.pbP1)
        Me.Controls.Add(Me.pbD3)
        Me.Controls.Add(Me.pbD2)
        Me.Controls.Add(Me.pbD1)
        Me.Name = "Form1"
        Me.Text = "Blackjack Prototype"
        CType(Me.pbD1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbD2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbD3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbP3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbP4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbP5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbD4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbD5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbD1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbD2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbD3 As System.Windows.Forms.PictureBox
    Friend WithEvents pbP1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbP2 As System.Windows.Forms.PictureBox
    Friend WithEvents pbP3 As System.Windows.Forms.PictureBox
    Friend WithEvents btnHit As System.Windows.Forms.Button
    Friend WithEvents btnStand As System.Windows.Forms.Button
    Friend WithEvents txtConsole As System.Windows.Forms.TextBox
    Friend WithEvents pbP4 As System.Windows.Forms.PictureBox
    Friend WithEvents pbP5 As System.Windows.Forms.PictureBox
    Friend WithEvents pbD4 As System.Windows.Forms.PictureBox
    Friend WithEvents pbD5 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnInitialize As System.Windows.Forms.Button
    Friend WithEvents btnRnd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
