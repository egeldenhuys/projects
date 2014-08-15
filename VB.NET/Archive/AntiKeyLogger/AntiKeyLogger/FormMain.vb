Public Class FormMain

    Dim Problem As System.Diagnostics.Process

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnScan.Click
        If btnScan.Text = "Scan" Then
            Dim pList() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("Calculator")

            lblWindow.Text = "No errors found"
            lblWindow.Visible = True
            lblWindow.ForeColor = Color.Green

            For Each proc As System.Diagnostics.Process In pList
                Problem = proc

                lblWindow.Text = "Error Found"
                lblWindow.Visible = True
                lblWindow.ForeColor = Color.Red

                btnScan.Text = "Fix"
            Next

        ElseIf btnScan.Text = "Fix" Then
            Problem.Kill()
            lblWindow.Text = "Fixed"
            lblWindow.ForeColor = Color.Green
        End If
    End Sub

End Class
