Imports System.Net.Mail

Public Class Form1

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim Mail As New MailMessage
        Mail.Subject = "Application"
        Mail.To.Add("spam.host.001@hotmail.com")
        Mail.From = New MailAddress("spam.host.001@hotmail.com")
        Mail.Body = My.User.Name.ToString


        Dim SMTP As New SmtpClient("smtp.live.com")
        SMTP.EnableSsl = True
        SMTP.Credentials = New System.Net.NetworkCredential("spam.host.001@hotmail.com", "PASSWORD")
        SMTP.Port = 587
        SMTP.Send(Mail)
        Me.Text = "Sent"
    End Sub
End Class
