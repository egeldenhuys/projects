Public Class Main
    Private Declare Sub mouse_event Lib "user32" (ByVal dwflags As Long, ByVal dx As Long, ByVal dy As Long, ByVal cbuttons As Long, ByVal dwExtraInfo As Long)
    Private Const mouseclickup = 4
    Private Const mouseclickdown = 2
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer
    Dim clickCount As Integer
    Dim cInterval As Integer
    Dim Clicks As Integer
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        TimerDelay.Interval = boxDelay.Text * 1000
        TimerDelay.Enabled = True
    End Sub

    Private Sub TimerDelay_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDelay.Tick
        TimerClick.Enabled = True
        TimerDelay.Enabled = False
    End Sub

    Private Sub TimerClick_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerClick.Tick
        If clickCount < boxClicks.Text Then
            '2 left down
            '4 left up

            '8 right down
            '10 right up
            mouse_event(8, 0, 0, 0, 0)
            mouse_event(10, 0, 0, 0, 0)
        Else
            TimerClick.Enabled = False
            clickCount = 0
        End If
        clickCount += 1
    End Sub
#Region "Extra"
    Private Sub TimerHotkey_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerHotkey.Tick

        Dim hotkey As Boolean
        hotkey = GetAsyncKeyState(Keys.F6)
        If hotkey = True Then
            TimerClick.Interval = cInterval
            TimerClick.Start()
        End If

        Dim hotkey1 As Boolean
        hotkey1 = GetAsyncKeyState(Keys.F7)
        If hotkey1 = True Then
            TimerClick.Stop()
            clickCount = 0
        End If

    End Sub
#End Region

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        cInterval = boxInterval.Text
        Clicks = boxClicks.Text
        clickCount = 0
        Label6.Text = cInterval * Clicks
    End Sub
End Class
