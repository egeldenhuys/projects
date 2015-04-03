<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.listIP = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbIP = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.label3 = New System.Windows.Forms.Label()
        Me.checkbShowAll = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblIP = New System.Windows.Forms.Label()
        Me.lblMatches = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.checkbProxy = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblProxy = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'listIP
        '
        Me.listIP.FormattingEnabled = True
        Me.listIP.Location = New System.Drawing.Point(12, 25)
        Me.listIP.Name = "listIP"
        Me.listIP.Size = New System.Drawing.Size(140, 199)
        Me.listIP.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "All IPs"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 287)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Add IP"
        '
        'txtbIP
        '
        Me.txtbIP.Location = New System.Drawing.Point(8, 303)
        Me.txtbIP.Name = "txtbIP"
        Me.txtbIP.Size = New System.Drawing.Size(140, 20)
        Me.txtbIP.TabIndex = 3
        Me.txtbIP.Text = "138.130.115.92"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(157, 300)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(231, 25)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(20, 13)
        Me.label3.TabIndex = 5
        Me.label3.Text = "IP:"
        '
        'checkbShowAll
        '
        Me.checkbShowAll.AutoSize = True
        Me.checkbShowAll.Checked = True
        Me.checkbShowAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkbShowAll.Location = New System.Drawing.Point(15, 230)
        Me.checkbShowAll.Name = "checkbShowAll"
        Me.checkbShowAll.Size = New System.Drawing.Size(67, 17)
        Me.checkbShowAll.TabIndex = 6
        Me.checkbShowAll.Text = "Show All"
        Me.checkbShowAll.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(167, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Matches Found:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(184, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Date Added:"
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.Location = New System.Drawing.Point(257, 25)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(17, 13)
        Me.lblIP.TabIndex = 9
        Me.lblIP.Text = "IP"
        '
        'lblMatches
        '
        Me.lblMatches.AutoSize = True
        Me.lblMatches.Location = New System.Drawing.Point(257, 46)
        Me.lblMatches.Name = "lblMatches"
        Me.lblMatches.Size = New System.Drawing.Size(48, 13)
        Me.lblMatches.TabIndex = 10
        Me.lblMatches.Text = "Matches"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(257, 67)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(30, 13)
        Me.lblDate.TabIndex = 11
        Me.lblDate.Text = "Date"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(15, 253)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'checkbProxy
        '
        Me.checkbProxy.AutoSize = True
        Me.checkbProxy.Location = New System.Drawing.Point(238, 303)
        Me.checkbProxy.Name = "checkbProxy"
        Me.checkbProxy.Size = New System.Drawing.Size(52, 17)
        Me.checkbProxy.TabIndex = 13
        Me.checkbProxy.Text = "Proxy"
        Me.checkbProxy.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(215, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Proxy:"
        '
        'lblProxy
        '
        Me.lblProxy.AutoSize = True
        Me.lblProxy.Location = New System.Drawing.Point(257, 88)
        Me.lblProxy.Name = "lblProxy"
        Me.lblProxy.Size = New System.Drawing.Size(33, 13)
        Me.lblProxy.TabIndex = 15
        Me.lblProxy.Text = "Proxy"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(347, 313)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Version: "
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(391, 313)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(28, 13)
        Me.lblVersion.TabIndex = 17
        Me.lblVersion.Text = "0.01"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 335)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblProxy)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.checkbProxy)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblMatches)
        Me.Controls.Add(Me.lblIP)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.checkbShowAll)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtbIP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.listIP)
        Me.Name = "FormMain"
        Me.Text = "IP Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listIP As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtbIP As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents checkbShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents lblMatches As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents checkbProxy As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblProxy As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label

End Class
