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
        Me.Player = New System.Windows.Forms.PictureBox()
        Me.Map1Panel = New System.Windows.Forms.Panel()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.AdobeDoor = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.AdobePanel = New System.Windows.Forms.Panel()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.AdobeExitDoor = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.lblLocation = New System.Windows.Forms.Label()
        CType(Me.Player, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Map1Panel.SuspendLayout()
        Me.AdobePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Player
        '
        Me.Player.Image = Global.Desktop_Runner.My.Resources.Resources.Player
        Me.Player.Location = New System.Drawing.Point(208, 327)
        Me.Player.Name = "Player"
        Me.Player.Size = New System.Drawing.Size(25, 25)
        Me.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Player.TabIndex = 0
        Me.Player.TabStop = False
        '
        'Map1Panel
        '
        Me.Map1Panel.BackgroundImage = Global.Desktop_Runner.My.Resources.Resources.Map
        Me.Map1Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Map1Panel.Controls.Add(Me.ShapeContainer1)
        Me.Map1Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Map1Panel.Location = New System.Drawing.Point(0, 0)
        Me.Map1Panel.Name = "Map1Panel"
        Me.Map1Panel.Size = New System.Drawing.Size(762, 481)
        Me.Map1Panel.TabIndex = 1
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.AdobeDoor})
        Me.ShapeContainer1.Size = New System.Drawing.Size(762, 481)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'AdobeDoor
        '
        Me.AdobeDoor.BackColor = System.Drawing.Color.Red
        Me.AdobeDoor.FillColor = System.Drawing.Color.Red
        Me.AdobeDoor.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.AdobeDoor.Location = New System.Drawing.Point(240, 317)
        Me.AdobeDoor.Name = "AdobeDoor"
        Me.AdobeDoor.Size = New System.Drawing.Size(44, 44)
        '
        'TimerMain
        '
        Me.TimerMain.Enabled = True
        Me.TimerMain.Interval = 1
        '
        'AdobePanel
        '
        Me.AdobePanel.Controls.Add(Me.ShapeContainer2)
        Me.AdobePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdobePanel.Location = New System.Drawing.Point(0, 0)
        Me.AdobePanel.Name = "AdobePanel"
        Me.AdobePanel.Size = New System.Drawing.Size(762, 481)
        Me.AdobePanel.TabIndex = 1
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.AdobeExitDoor})
        Me.ShapeContainer2.Size = New System.Drawing.Size(762, 481)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'AdobeExitDoor
        '
        Me.AdobeExitDoor.FillColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AdobeExitDoor.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.SolidDiamond
        Me.AdobeExitDoor.Location = New System.Drawing.Point(26, 19)
        Me.AdobeExitDoor.Name = "AdobeExitDoor"
        Me.AdobeExitDoor.Size = New System.Drawing.Size(44, 44)
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(688, 9)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(39, 13)
        Me.lblLocation.TabIndex = 1
        Me.lblLocation.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 481)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.Player)
        Me.Controls.Add(Me.Map1Panel)
        Me.Controls.Add(Me.AdobePanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.Player, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Map1Panel.ResumeLayout(False)
        Me.AdobePanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Player As System.Windows.Forms.PictureBox
    Friend WithEvents Map1Panel As System.Windows.Forms.Panel
    Friend WithEvents TimerMain As System.Windows.Forms.Timer
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents AdobeDoor As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents AdobePanel As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents AdobeExitDoor As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lblLocation As System.Windows.Forms.Label

End Class
