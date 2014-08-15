Imports System.IO


Public Class Form1

    Dim filePath As String = "C:\Users\Evert\Desktop\Minecraft\Servers\Tekkit_Server_3.1.2 (25626)\server.log"

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click

        Dim reader As New StreamReader(filePath)
        Dim textline As String = ""
        Dim substrings() As String
        Dim nameAndIp As String
        Dim playerName As String = ""


        Do While reader.Peek <> -1
            textline = reader.ReadLine

            If textline.Contains("logged in with entity id") Then
                substrings = Split(textline, "]")
                nameAndIp = substrings(1)
                substrings = Split(nameAndIp, "[")

                For Each element In substrings
                    playerName &= element & " "

                Next

            End If

        Loop






    End Sub


End Class
