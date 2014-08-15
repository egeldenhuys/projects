Imports System.Net
Imports System.IO

'------------------------------------
' This program checks if a user as paid for minecraft
' If they have it will display their skin.
'------------------------------------
Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCheck_Click(sender As System.Object, e As System.EventArgs) Handles btnCheck.Click

        Dim prem As Boolean = HasPaid(txtName.Text)

        lblStatus.Visible = False
        picSkin.Image = Nothing

        Me.Refresh()

        If prem = False Then
            lblStatus.Text = "User " & txtName.Text & " is not premium"
            lblStatus.ForeColor = Color.Red
            lblStatus.Visible = True
            Me.Refresh()
        Else
            lblStatus.Text = "User " & txtName.Text & " is premium"
            lblStatus.ForeColor = Color.Green
            lblStatus.Visible = True
            Me.Refresh()
            picSkin.Image = GetSkin(txtName.Text)
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtName.TextChanged
        lblLength.Text = "Username Length: " & txtName.TextLength
    End Sub

    Private Function HasPaid(ByVal username As String) As Boolean
        Dim wc As New WebClient

        Dim content As String = wc.DownloadString("https://minecraft.net/haspaid.jsp?user=" & username)

        If content = "false" Then
            Return False
        Else
            Return True
        End If

        wc.Dispose()
    End Function

    Private Function GetSkin(ByVal username As String) As Bitmap

        Dim skin As Bitmap = Nothing

        Try
            Dim request As WebRequest = WebRequest.Create("http://skins.minecraft.net/MinecraftSkins/" & username & ".png")


            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Dim dataStream As Stream = response.GetResponseStream()

            skin = New Bitmap(dataStream)



        Catch ex1 As WebException

        End Try

        Return skin

    End Function

    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class
