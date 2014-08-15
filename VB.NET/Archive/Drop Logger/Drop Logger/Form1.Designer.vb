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
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.boxAddDrop = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSet1 = New System.Windows.Forms.Button()
        Me.btnSet2 = New System.Windows.Forms.Button()
        Me.btnSet3 = New System.Windows.Forms.Button()
        Me.btnSet4 = New System.Windows.Forms.Button()
        Me.btnSet5 = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblChance = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(133, 24)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(172, 264)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Add Drop:"
        '
        'boxAddDrop
        '
        Me.boxAddDrop.AutoCompleteCustomSource.AddRange(New String() {""})
        Me.boxAddDrop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.boxAddDrop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.boxAddDrop.Location = New System.Drawing.Point(12, 25)
        Me.boxAddDrop.Name = "boxAddDrop"
        Me.boxAddDrop.Size = New System.Drawing.Size(100, 20)
        Me.boxAddDrop.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(24, 51)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add Drop"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Quick Add:"
        '
        'btnSet1
        '
        Me.btnSet1.Location = New System.Drawing.Point(24, 112)
        Me.btnSet1.Name = "btnSet1"
        Me.btnSet1.Size = New System.Drawing.Size(75, 23)
        Me.btnSet1.TabIndex = 5
        Me.btnSet1.Text = "Set Drop"
        Me.btnSet1.UseVisualStyleBackColor = True
        '
        'btnSet2
        '
        Me.btnSet2.Location = New System.Drawing.Point(24, 141)
        Me.btnSet2.Name = "btnSet2"
        Me.btnSet2.Size = New System.Drawing.Size(75, 23)
        Me.btnSet2.TabIndex = 6
        Me.btnSet2.Text = "Set Drop"
        Me.btnSet2.UseVisualStyleBackColor = True
        '
        'btnSet3
        '
        Me.btnSet3.Location = New System.Drawing.Point(24, 170)
        Me.btnSet3.Name = "btnSet3"
        Me.btnSet3.Size = New System.Drawing.Size(75, 23)
        Me.btnSet3.TabIndex = 7
        Me.btnSet3.Text = "Set Drop"
        Me.btnSet3.UseVisualStyleBackColor = True
        '
        'btnSet4
        '
        Me.btnSet4.Location = New System.Drawing.Point(24, 199)
        Me.btnSet4.Name = "btnSet4"
        Me.btnSet4.Size = New System.Drawing.Size(75, 23)
        Me.btnSet4.TabIndex = 8
        Me.btnSet4.Text = "Set Drop"
        Me.btnSet4.UseVisualStyleBackColor = True
        '
        'btnSet5
        '
        Me.btnSet5.Location = New System.Drawing.Point(24, 228)
        Me.btnSet5.Name = "btnSet5"
        Me.btnSet5.Size = New System.Drawing.Size(75, 23)
        Me.btnSet5.TabIndex = 9
        Me.btnSet5.Text = "Set Drop"
        Me.btnSet5.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(24, 275)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear List"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 259)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Options:"
        '
        'lblChance
        '
        Me.lblChance.AutoSize = True
        Me.lblChance.Location = New System.Drawing.Point(130, 293)
        Me.lblChance.Name = "lblChance"
        Me.lblChance.Size = New System.Drawing.Size(39, 13)
        Me.lblChance.TabIndex = 12
        Me.lblChance.Text = "Label4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 313)
        Me.Controls.Add(Me.lblChance)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSet5)
        Me.Controls.Add(Me.btnSet4)
        Me.Controls.Add(Me.btnSet3)
        Me.Controls.Add(Me.btnSet2)
        Me.Controls.Add(Me.btnSet1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.boxAddDrop)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Form1"
        Me.Text = "Drop Logger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents boxAddDrop As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSet1 As System.Windows.Forms.Button
    Friend WithEvents btnSet2 As System.Windows.Forms.Button
    Friend WithEvents btnSet3 As System.Windows.Forms.Button
    Friend WithEvents btnSet4 As System.Windows.Forms.Button
    Friend WithEvents btnSet5 As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblChance As System.Windows.Forms.Label

End Class
