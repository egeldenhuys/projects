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
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.txtUA = New System.Windows.Forms.TextBox()
        Me.txtref = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.rtxtContent = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtReqs = New System.Windows.Forms.TextBox()
        Me.txtDelay = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tmrDelay = New System.Windows.Forms.Timer(Me.components)
        Me.txtProx = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtUrl
        '
        Me.txtUrl.Location = New System.Drawing.Point(83, 12)
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.Size = New System.Drawing.Size(543, 20)
        Me.txtUrl.TabIndex = 0
        Me.txtUrl.Text = "http://122.148.156.44:25260"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "URL:"
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(280, 145)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(89, 13)
        Me.lblCount.TabIndex = 2
        Me.lblCount.Text = "Requests Sent: 0"
        '
        'txtUA
        '
        Me.txtUA.Location = New System.Drawing.Point(83, 38)
        Me.txtUA.Name = "txtUA"
        Me.txtUA.Size = New System.Drawing.Size(543, 20)
        Me.txtUA.TabIndex = 3
        Me.txtUA.Text = "This is my user agent. Why do you want to know this? Please stop stealing my pota" & _
    "toes."
        '
        'txtref
        '
        Me.txtref.Location = New System.Drawing.Point(83, 64)
        Me.txtref.Name = "txtref"
        Me.txtref.Size = New System.Drawing.Size(543, 20)
        Me.txtref.TabIndex = 4
        Me.txtref.Text = "I was refered by the CIA. Please send them an email at TonyHawk@BobAnus.com"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "User Agent:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(32, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Referer:"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(87, 140)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 7
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(168, 140)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 8
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'rtxtContent
        '
        Me.rtxtContent.Location = New System.Drawing.Point(12, 185)
        Me.rtxtContent.Name = "rtxtContent"
        Me.rtxtContent.Size = New System.Drawing.Size(614, 424)
        Me.rtxtContent.TabIndex = 9
        Me.rtxtContent.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Requests to send: "
        '
        'txtReqs
        '
        Me.txtReqs.Location = New System.Drawing.Point(116, 105)
        Me.txtReqs.Name = "txtReqs"
        Me.txtReqs.Size = New System.Drawing.Size(100, 20)
        Me.txtReqs.TabIndex = 11
        Me.txtReqs.Text = "5000"
        '
        'txtDelay
        '
        Me.txtDelay.Location = New System.Drawing.Point(360, 105)
        Me.txtDelay.Name = "txtDelay"
        Me.txtDelay.Size = New System.Drawing.Size(100, 20)
        Me.txtDelay.TabIndex = 13
        Me.txtDelay.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(258, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Delay (milliseconds):"
        '
        'tmrDelay
        '
        '
        'txtProx
        '
        Me.txtProx.Location = New System.Drawing.Point(673, 67)
        Me.txtProx.Name = "txtProx"
        Me.txtProx.Size = New System.Drawing.Size(171, 20)
        Me.txtProx.TabIndex = 14
        Me.txtProx.Text = "127.0.0.1:8118"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(670, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Proxy (IP:PORT)"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(6, 140)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 16
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTest.Location = New System.Drawing.Point(522, 150)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(51, 13)
        Me.lblTest.TabIndex = 17
        Me.lblTest.Text = "Testing..."
        Me.lblTest.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 621)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtProx)
        Me.Controls.Add(Me.txtDelay)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtReqs)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rtxtContent)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtref)
        Me.Controls.Add(Me.txtUA)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUrl)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtUrl As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtUA As System.Windows.Forms.TextBox
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents rtxtContent As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReqs As System.Windows.Forms.TextBox
    Friend WithEvents txtDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tmrDelay As System.Windows.Forms.Timer
    Friend WithEvents txtProx As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents lblTest As System.Windows.Forms.Label

End Class
