<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMainMenu
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
        Me.btnToPart1 = New System.Windows.Forms.Button()
        Me.btnToPart2 = New System.Windows.Forms.Button()
        Me.btnTaskList = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnToPart1
        '
        Me.btnToPart1.Location = New System.Drawing.Point(12, 12)
        Me.btnToPart1.Name = "btnToPart1"
        Me.btnToPart1.Size = New System.Drawing.Size(75, 23)
        Me.btnToPart1.TabIndex = 0
        Me.btnToPart1.Text = "Part 1"
        Me.btnToPart1.UseVisualStyleBackColor = True
        '
        'btnToPart2
        '
        Me.btnToPart2.Location = New System.Drawing.Point(12, 41)
        Me.btnToPart2.Name = "btnToPart2"
        Me.btnToPart2.Size = New System.Drawing.Size(75, 23)
        Me.btnToPart2.TabIndex = 1
        Me.btnToPart2.Text = "Part 2"
        Me.btnToPart2.UseVisualStyleBackColor = True
        '
        'btnTaskList
        '
        Me.btnTaskList.Location = New System.Drawing.Point(197, 12)
        Me.btnTaskList.Name = "btnTaskList"
        Me.btnTaskList.Size = New System.Drawing.Size(75, 23)
        Me.btnTaskList.TabIndex = 4
        Me.btnTaskList.Text = "Task List"
        Me.btnTaskList.UseVisualStyleBackColor = True
        '
        'formMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.btnTaskList)
        Me.Controls.Add(Me.btnToPart2)
        Me.Controls.Add(Me.btnToPart1)
        Me.Name = "formMainMenu"
        Me.Text = "Main Menu"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnToPart1 As System.Windows.Forms.Button
    Friend WithEvents btnToPart2 As System.Windows.Forms.Button
    Friend WithEvents btnTaskList As System.Windows.Forms.Button

End Class
