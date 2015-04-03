Imports TrollPrograms.Compression
Imports System.IO

Public Class Form1

    Dim WithEvents Proc As Process

    Dim texts As String

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim Zipper As New SevenZip



        CreateArchiveTest(TextBox2.Text, TextBox3.Text, "Survival", 9, "lzma2", "7z", TextBox1, "C:\Program Files\7-Zip\7z.exe")

    End Sub

    Private Sub CreateArchiveTest(ByVal sourcePath As String, ByVal destinationPath As String, ByVal archiveName As String, ByVal compressionLevel As Integer, _
                                ByVal compressionType As String, ByVal archiveType As String, ByVal OutputTextBox As TextBox, _
                                Optional ByVal binaryPath As String = "7zip.exe")

        Dim procInfo As New ProcessStartInfo(binaryPath)

        ' Set process start info
        procInfo.UseShellExecute = False
        'procInfo.CreateNoWindow = True
        ' procInfo.RedirectStandardError = True
        'procInfo.RedirectStandardOutput = True
        procInfo.Arguments = "a" & " -t" & archiveType & " -m0=" & compressionType & " -mx=" & compressionLevel & " " & destinationPath & archiveName & "." & archiveType & " " & sourcePath


        ' Start the process
        Proc = New Process

        Proc.StartInfo = procInfo

        proc.Start()

        ' Attach to stdout and stderr
        'Dim stdOut As StreamReader = Proc.StandardOutput
        'Dim stdErr As StreamReader = Proc.StandardError

        'AppendOutputText(stdErr.ReadToEnd())
        'AppendOutputText(stdOut.ReadToEnd())

        'Proc.BeginErrorReadLine()
        'Proc.BeginOutputReadLine()
        AppendOutputText("Process Started at: " & Proc.StartTime.ToString)

    End Sub

    Private Sub AppendOutputText(ByVal text As String)

        TextBox1.Text &= vbCrLf & text

    End Sub

    Private Sub Server_ErrorOutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles Proc.ErrorDataReceived
        AppendOutputText(e.Data)

    End Sub

    Private Sub Server_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles Proc.OutputDataReceived
        AppendOutputText(e.Data)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = texts
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
       
    End Sub
End Class
