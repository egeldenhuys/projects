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
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.item3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.item5 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.item4 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Item2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Item1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Rat = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer5 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.item3, Me.item5, Me.item4, Me.Item2, Me.Item1, Me.Rat})
        Me.ShapeContainer1.Size = New System.Drawing.Size(284, 264)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'item3
        '
        Me.item3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.item3.FillColor = System.Drawing.Color.Orange
        Me.item3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.item3.Location = New System.Drawing.Point(133, 119)
        Me.item3.Name = "item3"
        Me.item3.Size = New System.Drawing.Size(35, 33)
        '
        'item5
        '
        Me.item5.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.item5.FillColor = System.Drawing.Color.Orange
        Me.item5.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.item5.Location = New System.Drawing.Point(78, 120)
        Me.item5.Name = "item5"
        Me.item5.Size = New System.Drawing.Size(35, 33)
        '
        'item4
        '
        Me.item4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.item4.FillColor = System.Drawing.Color.Orange
        Me.item4.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.item4.Location = New System.Drawing.Point(105, 118)
        Me.item4.Name = "item4"
        Me.item4.Size = New System.Drawing.Size(35, 33)
        '
        'Item2
        '
        Me.Item2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Item2.FillColor = System.Drawing.Color.Orange
        Me.Item2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.Item2.Location = New System.Drawing.Point(151, 119)
        Me.Item2.Name = "Item2"
        Me.Item2.Size = New System.Drawing.Size(35, 33)
        '
        'Item1
        '
        Me.Item1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Item1.FillColor = System.Drawing.Color.Orange
        Me.Item1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.Item1.Location = New System.Drawing.Point(181, 120)
        Me.Item1.Name = "Item1"
        Me.Item1.Size = New System.Drawing.Size(35, 33)
        '
        'Rat
        '
        Me.Rat.Location = New System.Drawing.Point(70, 93)
        Me.Rat.Name = "Rat"
        Me.Rat.Size = New System.Drawing.Size(20, 20)
        '
        'TimerMain
        '
        Me.TimerMain.Interval = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(208, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'Timer2
        '
        Me.Timer2.Interval = 20
        '
        'Timer3
        '
        Me.Timer3.Interval = 20
        '
        'Timer4
        '
        Me.Timer4.Interval = 20
        '
        'Timer5
        '
        Me.Timer5.Enabled = True
        Me.Timer5.Interval = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Rat As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents TimerMain As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Item1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents item3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents item5 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents item4 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Item2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
    Friend WithEvents Timer5 As System.Windows.Forms.Timer

End Class
