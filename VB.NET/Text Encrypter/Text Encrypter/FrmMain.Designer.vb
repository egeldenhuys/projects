<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Me.PnlMain = New System.Windows.Forms.Panel()
        Me.btnSwap = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnSelAllEncrypt = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.cboxHideChars = New System.Windows.Forms.CheckBox()
        Me.btnOptions = New System.Windows.Forms.Button()
        Me.btnChanges = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDecrypt = New System.Windows.Forms.Button()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PnlOptions = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbtnMethod1 = New System.Windows.Forms.RadioButton()
        Me.RbtnMethod2 = New System.Windows.Forms.RadioButton()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.RbtnMethod3 = New System.Windows.Forms.RadioButton()
        Me.boxMethod3Key = New System.Windows.Forms.TextBox()
        Me.lblMethod3 = New System.Windows.Forms.Label()
        Me.PnlMain.SuspendLayout()
        Me.PnlOptions.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlMain
        '
        Me.PnlMain.Controls.Add(Me.lblMethod3)
        Me.PnlMain.Controls.Add(Me.boxMethod3Key)
        Me.PnlMain.Controls.Add(Me.btnSwap)
        Me.PnlMain.Controls.Add(Me.Button1)
        Me.PnlMain.Controls.Add(Me.btnSelAllEncrypt)
        Me.PnlMain.Controls.Add(Me.lblVersion)
        Me.PnlMain.Controls.Add(Me.lblError)
        Me.PnlMain.Controls.Add(Me.cboxHideChars)
        Me.PnlMain.Controls.Add(Me.btnOptions)
        Me.PnlMain.Controls.Add(Me.btnChanges)
        Me.PnlMain.Controls.Add(Me.btnRename)
        Me.PnlMain.Controls.Add(Me.btnClear)
        Me.PnlMain.Controls.Add(Me.btnDecrypt)
        Me.PnlMain.Controls.Add(Me.btnEncrypt)
        Me.PnlMain.Controls.Add(Me.TextBox2)
        Me.PnlMain.Controls.Add(Me.TextBox1)
        Me.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlMain.Location = New System.Drawing.Point(0, 0)
        Me.PnlMain.Name = "PnlMain"
        Me.PnlMain.Size = New System.Drawing.Size(726, 370)
        Me.PnlMain.TabIndex = 0
        '
        'btnSwap
        '
        Me.btnSwap.Location = New System.Drawing.Point(317, 246)
        Me.btnSwap.Name = "btnSwap"
        Me.btnSwap.Size = New System.Drawing.Size(75, 23)
        Me.btnSwap.TabIndex = 11
        Me.btnSwap.Text = "Swap Text"
        Me.btnSwap.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(501, 243)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Select All"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnSelAllEncrypt
        '
        Me.btnSelAllEncrypt.Location = New System.Drawing.Point(138, 243)
        Me.btnSelAllEncrypt.Name = "btnSelAllEncrypt"
        Me.btnSelAllEncrypt.Size = New System.Drawing.Size(75, 23)
        Me.btnSelAllEncrypt.TabIndex = 9
        Me.btnSelAllEncrypt.Text = "Select All"
        Me.btnSelAllEncrypt.UseVisualStyleBackColor = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(653, 346)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(69, 13)
        Me.lblVersion.TabIndex = 8
        Me.lblVersion.Text = "Version 0.0.3"
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(433, 280)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(214, 13)
        Me.lblError.TabIndex = 1
        Me.lblError.Text = "There was an error trying to Decrypt the text"
        '
        'cboxHideChars
        '
        Me.cboxHideChars.AutoSize = True
        Me.cboxHideChars.Location = New System.Drawing.Point(12, 319)
        Me.cboxHideChars.Name = "cboxHideChars"
        Me.cboxHideChars.Size = New System.Drawing.Size(102, 17)
        Me.cboxHideChars.TabIndex = 1
        Me.cboxHideChars.Text = "Hide Characters"
        Me.cboxHideChars.UseVisualStyleBackColor = True
        '
        'btnOptions
        '
        Me.btnOptions.Location = New System.Drawing.Point(7, 341)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(75, 23)
        Me.btnOptions.TabIndex = 7
        Me.btnOptions.Text = "Options"
        Me.btnOptions.UseVisualStyleBackColor = True
        '
        'btnChanges
        '
        Me.btnChanges.Location = New System.Drawing.Point(194, 341)
        Me.btnChanges.Name = "btnChanges"
        Me.btnChanges.Size = New System.Drawing.Size(75, 23)
        Me.btnChanges.TabIndex = 6
        Me.btnChanges.Text = "Changelog"
        Me.btnChanges.UseVisualStyleBackColor = True
        '
        'btnRename
        '
        Me.btnRename.Location = New System.Drawing.Point(88, 341)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(100, 23)
        Me.btnRename.TabIndex = 5
        Me.btnRename.Text = "Rename Window"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(169, 280)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear All"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDecrypt
        '
        Me.btnDecrypt.Location = New System.Drawing.Point(88, 280)
        Me.btnDecrypt.Name = "btnDecrypt"
        Me.btnDecrypt.Size = New System.Drawing.Size(75, 23)
        Me.btnDecrypt.TabIndex = 3
        Me.btnDecrypt.Text = "Decrypt"
        Me.btnDecrypt.UseVisualStyleBackColor = True
        '
        'btnEncrypt
        '
        Me.btnEncrypt.Location = New System.Drawing.Point(7, 280)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(75, 23)
        Me.btnEncrypt.TabIndex = 2
        Me.btnEncrypt.Text = "Encrypt"
        Me.btnEncrypt.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.AcceptsReturn = True
        Me.TextBox2.AcceptsTab = True
        Me.TextBox2.Location = New System.Drawing.Point(375, 12)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox2.Size = New System.Drawing.Size(326, 228)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(326, 228)
        Me.TextBox1.TabIndex = 0
        '
        'PnlOptions
        '
        Me.PnlOptions.Controls.Add(Me.GroupBox1)
        Me.PnlOptions.Controls.Add(Me.BtnSave)
        Me.PnlOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlOptions.Location = New System.Drawing.Point(0, 0)
        Me.PnlOptions.Name = "PnlOptions"
        Me.PnlOptions.Size = New System.Drawing.Size(726, 370)
        Me.PnlOptions.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbtnMethod3)
        Me.GroupBox1.Controls.Add(Me.RbtnMethod1)
        Me.GroupBox1.Controls.Add(Me.RbtnMethod2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 113)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Method"
        '
        'RbtnMethod1
        '
        Me.RbtnMethod1.AutoSize = True
        Me.RbtnMethod1.Location = New System.Drawing.Point(6, 19)
        Me.RbtnMethod1.Name = "RbtnMethod1"
        Me.RbtnMethod1.Size = New System.Drawing.Size(70, 17)
        Me.RbtnMethod1.TabIndex = 1
        Me.RbtnMethod1.TabStop = True
        Me.RbtnMethod1.Text = "Method 1"
        Me.RbtnMethod1.UseVisualStyleBackColor = True
        '
        'RbtnMethod2
        '
        Me.RbtnMethod2.AutoSize = True
        Me.RbtnMethod2.Location = New System.Drawing.Point(5, 42)
        Me.RbtnMethod2.Name = "RbtnMethod2"
        Me.RbtnMethod2.Size = New System.Drawing.Size(70, 17)
        Me.RbtnMethod2.TabIndex = 2
        Me.RbtnMethod2.TabStop = True
        Me.RbtnMethod2.Text = "Method 2"
        Me.RbtnMethod2.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(65, 131)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'RbtnMethod3
        '
        Me.RbtnMethod3.AutoSize = True
        Me.RbtnMethod3.Location = New System.Drawing.Point(5, 65)
        Me.RbtnMethod3.Name = "RbtnMethod3"
        Me.RbtnMethod3.Size = New System.Drawing.Size(70, 17)
        Me.RbtnMethod3.TabIndex = 3
        Me.RbtnMethod3.TabStop = True
        Me.RbtnMethod3.Text = "Method 3"
        Me.RbtnMethod3.UseVisualStyleBackColor = True
        '
        'boxMethod3Key
        '
        Me.boxMethod3Key.Location = New System.Drawing.Point(409, 338)
        Me.boxMethod3Key.Name = "boxMethod3Key"
        Me.boxMethod3Key.Size = New System.Drawing.Size(100, 20)
        Me.boxMethod3Key.TabIndex = 12
        Me.boxMethod3Key.Visible = False
        '
        'lblMethod3
        '
        Me.lblMethod3.AutoSize = True
        Me.lblMethod3.Location = New System.Drawing.Point(375, 341)
        Me.lblMethod3.Name = "lblMethod3"
        Me.lblMethod3.Size = New System.Drawing.Size(28, 13)
        Me.lblMethod3.TabIndex = 13
        Me.lblMethod3.Text = "Key:"
        Me.lblMethod3.Visible = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 370)
        Me.Controls.Add(Me.PnlMain)
        Me.Controls.Add(Me.PnlOptions)
        Me.Name = "FrmMain"
        Me.Text = "Text Encrypter"
        Me.PnlMain.ResumeLayout(False)
        Me.PnlMain.PerformLayout()
        Me.PnlOptions.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlMain As System.Windows.Forms.Panel
    Friend WithEvents PnlOptions As System.Windows.Forms.Panel
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents btnRename As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnDecrypt As System.Windows.Forms.Button
    Friend WithEvents btnEncrypt As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnChanges As System.Windows.Forms.Button
    Friend WithEvents btnOptions As System.Windows.Forms.Button
    Friend WithEvents RbtnMethod2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbtnMethod1 As System.Windows.Forms.RadioButton
    Friend WithEvents cboxHideChars As System.Windows.Forms.CheckBox
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents btnSelAllEncrypt As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnSwap As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbtnMethod3 As System.Windows.Forms.RadioButton
    Friend WithEvents lblMethod3 As System.Windows.Forms.Label
    Friend WithEvents boxMethod3Key As System.Windows.Forms.TextBox

End Class
