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
        Me.boxSend = New System.Windows.Forms.TextBox()
        Me.boxCapacity = New System.Windows.Forms.TextBox()
        Me.boxPaladium = New System.Windows.Forms.TextBox()
        Me.boxPromerium = New System.Windows.Forms.TextBox()
        Me.boxSeprom = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.cboxSent = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'boxSend
        '
        Me.boxSend.Location = New System.Drawing.Point(112, 190)
        Me.boxSend.Name = "boxSend"
        Me.boxSend.Size = New System.Drawing.Size(100, 20)
        Me.boxSend.TabIndex = 0
        '
        'boxCapacity
        '
        Me.boxCapacity.Location = New System.Drawing.Point(91, 12)
        Me.boxCapacity.Name = "boxCapacity"
        Me.boxCapacity.Size = New System.Drawing.Size(100, 20)
        Me.boxCapacity.TabIndex = 1
        Me.boxCapacity.Text = "3000"
        '
        'boxPaladium
        '
        Me.boxPaladium.Location = New System.Drawing.Point(91, 38)
        Me.boxPaladium.Name = "boxPaladium"
        Me.boxPaladium.Size = New System.Drawing.Size(100, 20)
        Me.boxPaladium.TabIndex = 2
        '
        'boxPromerium
        '
        Me.boxPromerium.Location = New System.Drawing.Point(91, 83)
        Me.boxPromerium.Name = "boxPromerium"
        Me.boxPromerium.Size = New System.Drawing.Size(100, 20)
        Me.boxPromerium.TabIndex = 3
        Me.boxPromerium.Text = "50"
        '
        'boxSeprom
        '
        Me.boxSeprom.Location = New System.Drawing.Point(91, 109)
        Me.boxSeprom.Name = "boxSeprom"
        Me.boxSeprom.Size = New System.Drawing.Size(100, 20)
        Me.boxSeprom.TabIndex = 4
        Me.boxSeprom.Text = "50"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(99, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Send Them First"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Cargo Capacity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Palladium"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Promerium"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Seprom"
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(91, 146)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(75, 23)
        Me.btnCalculate.TabIndex = 10
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'cboxSent
        '
        Me.cboxSent.AutoSize = True
        Me.cboxSent.Location = New System.Drawing.Point(197, 97)
        Me.cboxSent.Name = "cboxSent"
        Me.cboxSent.Size = New System.Drawing.Size(48, 17)
        Me.cboxSent.TabIndex = 11
        Me.cboxSent.Text = "Sent"
        Me.cboxSent.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 193)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Free Cargo Space"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 226)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboxSent)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.boxSeprom)
        Me.Controls.Add(Me.boxPromerium)
        Me.Controls.Add(Me.boxPaladium)
        Me.Controls.Add(Me.boxCapacity)
        Me.Controls.Add(Me.boxSend)
        Me.Name = "Form1"
        Me.Text = "Dark Orbit Cargo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents boxSend As System.Windows.Forms.TextBox
    Friend WithEvents boxCapacity As System.Windows.Forms.TextBox
    Friend WithEvents boxPaladium As System.Windows.Forms.TextBox
    Friend WithEvents boxPromerium As System.Windows.Forms.TextBox
    Friend WithEvents boxSeprom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents cboxSent As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
