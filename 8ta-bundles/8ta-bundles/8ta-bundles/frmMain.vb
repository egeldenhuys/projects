Imports System.Net
Imports System.IO

Public Class frmMain

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub tmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick

    End Sub

    Private Sub GetData()

        ' Set up variables
        ' Error: Website requires browser to make additional Post requests.

        Dim URL As String = "http://onnet.8ta.com/"
        Dim client As New WebClient
        Dim data As Stream = client.OpenRead(URL)
        Dim reader As New StreamReader(data)
        Dim str As String = ""

        Dim peak As String = ""
        Dim offPeak As String = ""

        str = reader.ReadLine()

        While str.Length > 0

            ' Peak data
            If str.Contains("<td>Once-off Telkom Mobile Data</td>") Then
                data.Seek(30, CType(data.Position, SeekOrigin))
                peak = reader.ReadLine
                lblOnPeak.Text = peak

            End If

        End While


    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        GetData()

    End Sub
End Class
