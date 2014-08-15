Imports Skybound.Gecko

Public Class Form1
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Xpcom.Initialize("C:\Users\Evert\AppData\Roaming\Troll Programs\shared\xulrunner")
        Xpcom.ProfileDirectory = "C:\Users\Evert\AppData\Roaming\Troll Programs\shared\GeckoProfile"

        Dim sUserAgent As String = "Googlebot/2.1 (+http://www.google.com/bot.html)"
        Skybound.Gecko.GeckoPreferences.User("general.useragent.override") = sUserAgent

    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        GeckoWebBrowser1.Navigate("http://www.google.com")

    End Sub

    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        GeckoWebBrowser1.GoBack()

    End Sub

    Private Sub btnFwd_Click(sender As System.Object, e As System.EventArgs) Handles btnFwd.Click
        GeckoWebBrowser1.GoForward()

    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        GeckoWebBrowser1.Reload()
    End Sub

    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnGo.Click
        GeckoWebBrowser1.Navigate(txtUrl.Text)
    End Sub

    Private Sub Form1_SizeChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.SizeChanged
        GeckoWebBrowser1.Height = Me.Height - 78
    End Sub

    Private Sub txtUrl_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUrl.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            GeckoWebBrowser1.Navigate(txtUrl.Text)
        End If
    End Sub
End Class
