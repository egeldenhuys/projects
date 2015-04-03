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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabNewComp = New System.Windows.Forms.TabPage()
        Me.lblStatus1 = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.boxURL = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.boxClanName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabUpdateComp = New System.Windows.Forms.TabPage()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.lblStatus2 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ClansList = New System.Windows.Forms.ListBox()
        Me.lblError = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabNewComp.SuspendLayout()
        Me.tabUpdateComp.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabNewComp)
        Me.TabControl1.Controls.Add(Me.tabUpdateComp)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(352, 329)
        Me.TabControl1.TabIndex = 1
        '
        'tabNewComp
        '
        Me.tabNewComp.BackColor = System.Drawing.SystemColors.Control
        Me.tabNewComp.Controls.Add(Me.lblError)
        Me.tabNewComp.Controls.Add(Me.lblStatus1)
        Me.tabNewComp.Controls.Add(Me.btnCreate)
        Me.tabNewComp.Controls.Add(Me.boxURL)
        Me.tabNewComp.Controls.Add(Me.Label2)
        Me.tabNewComp.Controls.Add(Me.boxClanName)
        Me.tabNewComp.Controls.Add(Me.Label1)
        Me.tabNewComp.Location = New System.Drawing.Point(4, 22)
        Me.tabNewComp.Name = "tabNewComp"
        Me.tabNewComp.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNewComp.Size = New System.Drawing.Size(344, 303)
        Me.tabNewComp.TabIndex = 0
        Me.tabNewComp.Text = "Create new competition"
        '
        'lblStatus1
        '
        Me.lblStatus1.AutoSize = True
        Me.lblStatus1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus1.Location = New System.Drawing.Point(6, 285)
        Me.lblStatus1.Name = "lblStatus1"
        Me.lblStatus1.Size = New System.Drawing.Size(38, 13)
        Me.lblStatus1.TabIndex = 5
        Me.lblStatus1.Text = "Ready"
        '
        'btnCreate
        '
        Me.btnCreate.Location = New System.Drawing.Point(135, 79)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 4
        Me.btnCreate.Text = "Create"
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'boxURL
        '
        Me.boxURL.Location = New System.Drawing.Point(76, 39)
        Me.boxURL.Name = "boxURL"
        Me.boxURL.Size = New System.Drawing.Size(223, 20)
        Me.boxURL.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "URL:"
        '
        'boxClanName
        '
        Me.boxClanName.Location = New System.Drawing.Point(76, 5)
        Me.boxClanName.Name = "boxClanName"
        Me.boxClanName.Size = New System.Drawing.Size(223, 20)
        Me.boxClanName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Clan Name:"
        '
        'tabUpdateComp
        '
        Me.tabUpdateComp.BackColor = System.Drawing.SystemColors.Control
        Me.tabUpdateComp.Controls.Add(Me.btnDelete)
        Me.tabUpdateComp.Controls.Add(Me.btnOpen)
        Me.tabUpdateComp.Controls.Add(Me.lblStatus2)
        Me.tabUpdateComp.Controls.Add(Me.btnUpdate)
        Me.tabUpdateComp.Controls.Add(Me.Label3)
        Me.tabUpdateComp.Controls.Add(Me.ClansList)
        Me.tabUpdateComp.Location = New System.Drawing.Point(4, 22)
        Me.tabUpdateComp.Name = "tabUpdateComp"
        Me.tabUpdateComp.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUpdateComp.Size = New System.Drawing.Size(344, 303)
        Me.tabUpdateComp.TabIndex = 1
        Me.tabUpdateComp.Text = "Update existing competition"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(20, 257)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(101, 257)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 4
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'lblStatus2
        '
        Me.lblStatus2.AutoSize = True
        Me.lblStatus2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus2.Location = New System.Drawing.Point(6, 285)
        Me.lblStatus2.Name = "lblStatus2"
        Me.lblStatus2.Size = New System.Drawing.Size(38, 13)
        Me.lblStatus2.TabIndex = 3
        Me.lblStatus2.Text = "Ready"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(241, 257)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Select a clan:"
        '
        'ClansList
        '
        Me.ClansList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClansList.FormattingEnabled = True
        Me.ClansList.ItemHeight = 18
        Me.ClansList.Location = New System.Drawing.Point(20, 49)
        Me.ClansList.Name = "ClansList"
        Me.ClansList.Size = New System.Drawing.Size(296, 202)
        Me.ClansList.TabIndex = 0
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(73, 62)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(68, 15)
        Me.lblError.TabIndex = 6
        Me.lblError.Text = "Error Label"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 329)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormMain"
        Me.Text = "Clan Competitions"
        Me.TabControl1.ResumeLayout(False)
        Me.tabNewComp.ResumeLayout(False)
        Me.tabNewComp.PerformLayout()
        Me.tabUpdateComp.ResumeLayout(False)
        Me.tabUpdateComp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabNewComp As System.Windows.Forms.TabPage
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents boxURL As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents boxClanName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabUpdateComp As System.Windows.Forms.TabPage
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ClansList As System.Windows.Forms.ListBox
    Friend WithEvents lblStatus1 As System.Windows.Forms.Label
    Friend WithEvents lblStatus2 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents lblError As System.Windows.Forms.Label

End Class
