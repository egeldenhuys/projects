<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.lblNumber = New System.Windows.Forms.Label()
        Me.lblHacked = New System.Windows.Forms.Label()
        Me.TimerClose = New System.Windows.Forms.Timer(Me.components)
        Me.lblCode = New System.Windows.Forms.Label()
        Me.lblHidden = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(255, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "If the number is 100, the auth code will apear."
        '
        'btnTest
        '
        Me.btnTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTest.Location = New System.Drawing.Point(0, 121)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(301, 37)
        Me.btnTest.TabIndex = 1
        Me.btnTest.Text = "Test number"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'lblNumber
        '
        Me.lblNumber.AutoSize = True
        Me.lblNumber.Location = New System.Drawing.Point(150, 59)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(19, 13)
        Me.lblNumber.TabIndex = 2
        Me.lblNumber.Text = "99"
        Me.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHacked
        '
        Me.lblHacked.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHacked.ForeColor = System.Drawing.Color.Red
        Me.lblHacked.Location = New System.Drawing.Point(0, 91)
        Me.lblHacked.Name = "lblHacked"
        Me.lblHacked.Size = New System.Drawing.Size(319, 19)
        Me.lblHacked.TabIndex = 3
        Me.lblHacked.Text = "Hacked"
        Me.lblHacked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblHacked.Visible = False
        '
        'TimerClose
        '
        Me.TimerClose.Interval = 2000
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.Green
        Me.lblCode.Location = New System.Drawing.Point(317, 9)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(51, 140)
        Me.lblCode.TabIndex = 5
        Me.lblCode.Text = "::Auth" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "::Auth" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "::Auth" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "::Auth" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "::Auth" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "::Auth" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "::Auth"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCode.Visible = False
        '
        'lblHidden
        '
        Me.lblHidden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHidden.Location = New System.Drawing.Point(318, 31)
        Me.lblHidden.Name = "lblHidden"
        Me.lblHidden.Size = New System.Drawing.Size(157, 118)
        Me.lblHidden.TabIndex = 6
        Me.lblHidden.Text = "Hidden"
        Me.lblHidden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 158)
        Me.Controls.Add(Me.lblHidden)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.lblHacked)
        Me.Controls.Add(Me.lblNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnTest)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Main"
        Me.Text = "Hack Me 2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents lblHacked As System.Windows.Forms.Label
    Friend WithEvents TimerClose As System.Windows.Forms.Timer
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblHidden As System.Windows.Forms.Label

End Class
