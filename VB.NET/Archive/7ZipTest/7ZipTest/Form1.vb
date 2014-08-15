Imports System.IO

Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        ' One file parameter to the executable
        Dim sourceName As String = "Survival\"
        ' The second file parameter to the executable
        Dim targetName As String = "Test.7z"

        ' New ProcessStartInfo created
        Dim p As New ProcessStartInfo

        p.RedirectStandardOutput = True
        p.RedirectStandardError = True

        ' Specify the location of the binary
        p.FileName = "C:\Program Files\7-Zip\7z.exe"

        ' Use these arguments for the process
        p.Arguments = "a -t7z -m0=lzma2 -mx=9 " & targetName & " " & sourceName

        ' Use a hidden window
        'p.WindowStyle = ProcessWindowStyle.Hidden

        p.UseShellExecute = False
        p.CreateNoWindow = True
        p.RedirectStandardOutput = True

        ' Start the process

        Dim proc As New Process()
        proc.StartInfo = p

        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As StreamReader = proc.StandardOutput()
        Dim std_err As StreamReader = proc.StandardError()

        ' Display the results.
        TextBox1.Text &= std_out.ReadLine
        TextBox1.Text &= std_err.ReadLine

        ' Clean up.
        std_out.Close()
        std_err.Close()
        proc.Close()

    End Sub
End Class
