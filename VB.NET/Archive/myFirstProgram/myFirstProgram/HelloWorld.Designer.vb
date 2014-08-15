<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelloWorld
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
        Me.btnDisplayHello = New System.Windows.Forms.Button()
        Me.lblHelloWorld = New System.Windows.Forms.Label()
        Me.TextBoxTransfer = New System.Windows.Forms.TextBox()
        Me.btnTransferText = New System.Windows.Forms.Button()
        Me.TransferLabel = New System.Windows.Forms.Label()
        Me.Instructions1 = New System.Windows.Forms.Label()
        Me.ExtraTextBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnDisplayHello
        '
        Me.btnDisplayHello.Location = New System.Drawing.Point(12, 26)
        Me.btnDisplayHello.Name = "btnDisplayHello"
        Me.btnDisplayHello.Size = New System.Drawing.Size(75, 23)
        Me.btnDisplayHello.TabIndex = 0
        Me.btnDisplayHello.Text = "Display hello"
        Me.btnDisplayHello.UseVisualStyleBackColor = True
        '
        'lblHelloWorld
        '
        Me.lblHelloWorld.AutoSize = True
        Me.lblHelloWorld.Location = New System.Drawing.Point(100, 31)
        Me.lblHelloWorld.Name = "lblHelloWorld"
        Me.lblHelloWorld.Size = New System.Drawing.Size(0, 13)
        Me.lblHelloWorld.TabIndex = 1
        '
        'TextBoxTransfer
        '
        Me.TextBoxTransfer.Location = New System.Drawing.Point(12, 114)
        Me.TextBoxTransfer.Name = "TextBoxTransfer"
        Me.TextBoxTransfer.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxTransfer.TabIndex = 2
        '
        'btnTransferText
        '
        Me.btnTransferText.Location = New System.Drawing.Point(12, 68)
        Me.btnTransferText.Name = "btnTransferText"
        Me.btnTransferText.Size = New System.Drawing.Size(75, 23)
        Me.btnTransferText.TabIndex = 3
        Me.btnTransferText.Text = "Transfer Text"
        Me.btnTransferText.UseVisualStyleBackColor = True
        '
        'TransferLabel
        '
        Me.TransferLabel.AutoSize = True
        Me.TransferLabel.Location = New System.Drawing.Point(100, 73)
        Me.TransferLabel.Name = "TransferLabel"
        Me.TransferLabel.Size = New System.Drawing.Size(0, 13)
        Me.TransferLabel.TabIndex = 4
        '
        'Instructions1
        '
        Me.Instructions1.AutoSize = True
        Me.Instructions1.Location = New System.Drawing.Point(127, 117)
        Me.Instructions1.Name = "Instructions1"
        Me.Instructions1.Size = New System.Drawing.Size(196, 13)
        Me.Instructions1.TabIndex = 5
        Me.Instructions1.Text = "Place you text here and click ""Transfer"""
        '
        'ExtraTextBox
        '
        Me.ExtraTextBox.Location = New System.Drawing.Point(12, 140)
        Me.ExtraTextBox.Name = "ExtraTextBox"
        Me.ExtraTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ExtraTextBox.TabIndex = 6
        '
        'HelloWorld
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 177)
        Me.Controls.Add(Me.ExtraTextBox)
        Me.Controls.Add(Me.Instructions1)
        Me.Controls.Add(Me.TransferLabel)
        Me.Controls.Add(Me.btnTransferText)
        Me.Controls.Add(Me.TextBoxTransfer)
        Me.Controls.Add(Me.lblHelloWorld)
        Me.Controls.Add(Me.btnDisplayHello)
        Me.Name = "HelloWorld"
        Me.Text = "HelloWorld"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDisplayHello As System.Windows.Forms.Button
    Friend WithEvents lblHelloWorld As System.Windows.Forms.Label
    Friend WithEvents TextBoxTransfer As System.Windows.Forms.TextBox
    Friend WithEvents btnTransferText As System.Windows.Forms.Button
    Friend WithEvents TransferLabel As System.Windows.Forms.Label
    Friend WithEvents Instructions1 As System.Windows.Forms.Label
    Friend WithEvents ExtraTextBox As System.Windows.Forms.TextBox
End Class
