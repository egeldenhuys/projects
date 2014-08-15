<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Randomizer
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
        Me.BoxGenerate = New System.Windows.Forms.TextBox()
        Me.BoxLength = New System.Windows.Forms.TextBox()
        Me.BoxTypes = New System.Windows.Forms.TextBox()
        Me.BoxList = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnToTest = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BoxGenerate
        '
        Me.BoxGenerate.Location = New System.Drawing.Point(124, 12)
        Me.BoxGenerate.Name = "BoxGenerate"
        Me.BoxGenerate.Size = New System.Drawing.Size(100, 20)
        Me.BoxGenerate.TabIndex = 0
        '
        'BoxLength
        '
        Me.BoxLength.Location = New System.Drawing.Point(124, 38)
        Me.BoxLength.Name = "BoxLength"
        Me.BoxLength.Size = New System.Drawing.Size(100, 20)
        Me.BoxLength.TabIndex = 1
        '
        'BoxTypes
        '
        Me.BoxTypes.Location = New System.Drawing.Point(124, 64)
        Me.BoxTypes.Name = "BoxTypes"
        Me.BoxTypes.Size = New System.Drawing.Size(100, 20)
        Me.BoxTypes.TabIndex = 2
        '
        'BoxList
        '
        Me.BoxList.Location = New System.Drawing.Point(12, 119)
        Me.BoxList.Multiline = True
        Me.BoxList.Name = "BoxList"
        Me.BoxList.Size = New System.Drawing.Size(259, 132)
        Me.BoxList.TabIndex = 3
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(2, 14)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(116, 65)
        Me.lblDescription.TabIndex = 4
        Me.lblDescription.Text = "How many to Generate" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Length" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Types to choose from"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(124, 90)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerate.TabIndex = 5
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'btnToTest
        '
        Me.btnToTest.Location = New System.Drawing.Point(43, 90)
        Me.btnToTest.Name = "btnToTest"
        Me.btnToTest.Size = New System.Drawing.Size(75, 23)
        Me.btnToTest.TabIndex = 6
        Me.btnToTest.Text = "Test"
        Me.btnToTest.UseVisualStyleBackColor = True
        '
        'Randomizer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 263)
        Me.Controls.Add(Me.btnToTest)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.BoxList)
        Me.Controls.Add(Me.BoxTypes)
        Me.Controls.Add(Me.BoxLength)
        Me.Controls.Add(Me.BoxGenerate)
        Me.Name = "Randomizer"
        Me.Text = "Randomizer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BoxGenerate As System.Windows.Forms.TextBox
    Friend WithEvents BoxLength As System.Windows.Forms.TextBox
    Friend WithEvents BoxTypes As System.Windows.Forms.TextBox
    Friend WithEvents BoxList As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnToTest As System.Windows.Forms.Button
End Class
