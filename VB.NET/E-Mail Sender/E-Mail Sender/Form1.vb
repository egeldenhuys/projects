Imports System.Net.Mail

Public Class Form1



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim mymailmessage As New MailMessage()

        For i = 1 To Integer.Parse(TextBoxwiththenumbers.Text)

            Try

                mymailmessage.From = New MailAddress("frankly.stuff@hotmail.com")  'has to be a gmail account

                mymailmessage.To.Add(TextBoxTo.Text)

                mymailmessage.Subject = TextBoxSubject.Text

                mymailmessage.Body = TextBoxBody.Text

                Dim Smtp As New SmtpClient("smtp.hotmail.com")

                Smtp.Port = 587

                Smtp.EnableSsl = True

                Smtp.Credentials = New System.Net.NetworkCredential("frankly.stuff@hotmail.com", "bananaemail") '   "Your gmail adress" , "Your password" 

                Smtp.Send(mymailmessage)



            Catch ex As Exception



            End Try

        Next

        MsgBox("Emails spammed !", MsgBoxStyle.Information, "lol")

    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MsgBox("Please wait while sending the mails, the program will not respond  while sending, so don't quit the program, just wait for a message saying the mail has been sent", MsgBoxStyle.Exclamation, "Warning")

    End Sub



    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Application.Exit()

    End Sub

End Class
