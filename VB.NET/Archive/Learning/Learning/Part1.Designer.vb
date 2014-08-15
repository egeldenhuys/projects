<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPart1
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
        Me.lblHelloWorld = New System.Windows.Forms.Label()
        Me.btnDisplayHello = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblHelloWorld
        '
        Me.lblHelloWorld.AutoSize = True
        Me.lblHelloWorld.Font = New System.Drawing.Font("News706 BT", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelloWorld.Location = New System.Drawing.Point(47, 26)
        Me.lblHelloWorld.Name = "lblHelloWorld"
        Me.lblHelloWorld.Size = New System.Drawing.Size(0, 19)
        Me.lblHelloWorld.TabIndex = 0
        '
        'btnDisplayHello
        '
        Me.btnDisplayHello.Location = New System.Drawing.Point(61, 90)
        Me.btnDisplayHello.Name = "btnDisplayHello"
        Me.btnDisplayHello.Size = New System.Drawing.Size(75, 23)
        Me.btnDisplayHello.TabIndex = 1
        Me.btnDisplayHello.Text = "Display Hello"
        Me.btnDisplayHello.UseVisualStyleBackColor = True
        '
        'formPart1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(197, 125)
        Me.Controls.Add(Me.btnDisplayHello)
        Me.Controls.Add(Me.lblHelloWorld)
        Me.Name = "formPart1"
        Me.Text = "Part1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHelloWorld As System.Windows.Forms.Label
    Friend WithEvents btnDisplayHello As System.Windows.Forms.Button
End Class
