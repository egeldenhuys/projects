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
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tmrRnd = New System.Windows.Forms.Timer(Me.components)
        Me.tmrGenEnd = New System.Windows.Forms.Timer(Me.components)
        Me.rtxtFinal = New System.Windows.Forms.RichTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(118, 126)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'tmrRnd
        '
        Me.tmrRnd.Interval = 200
        '
        'tmrGenEnd
        '
        Me.tmrGenEnd.Interval = 1000
        '
        'rtxtFinal
        '
        Me.rtxtFinal.BackColor = System.Drawing.Color.Black
        Me.rtxtFinal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtxtFinal.Cursor = System.Windows.Forms.Cursors.Default
        Me.rtxtFinal.DetectUrls = False
        Me.rtxtFinal.Font = New System.Drawing.Font("Lucida Console", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtxtFinal.ForeColor = System.Drawing.Color.Lime
        Me.rtxtFinal.Location = New System.Drawing.Point(21, 34)
        Me.rtxtFinal.Multiline = False
        Me.rtxtFinal.Name = "rtxtFinal"
        Me.rtxtFinal.ReadOnly = True
        Me.rtxtFinal.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtxtFinal.ShortcutsEnabled = False
        Me.rtxtFinal.Size = New System.Drawing.Size(151, 27)
        Me.rtxtFinal.TabIndex = 2
        Me.rtxtFinal.Text = "0000000000"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rtxtFinal)
        Me.Panel1.Location = New System.Drawing.Point(59, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(192, 95)
        Me.Panel1.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(310, 161)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Random Numbers"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents tmrRnd As System.Windows.Forms.Timer
    Friend WithEvents tmrGenEnd As System.Windows.Forms.Timer
    Friend WithEvents rtxtFinal As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
