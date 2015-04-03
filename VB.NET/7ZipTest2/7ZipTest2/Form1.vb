Public Class Form1

    Private WithEvents _7zip As Process

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCompress_Click(sender As System.Object, e As System.EventArgs) Handles btnCompress.Click

        'Dim startInfo As New ProcessStartInfo
        'startInfo.FileName = "7za.exe"
        'startInfo.Arguments = "a HARHAR2.zip .\Backups\World_1\*"
        'Process.Start(startInfo)

        _7zip = New Process
        With _7zip.StartInfo
            .FileName = "7za.exe"
            .Arguments = "a ""Backups\HARHAR2.zip"" ""C:\Users\Evert\Documents\Visual Studio 2010\Projects\7ZipTest2\7ZipTest2\bin\Debug\Backups\World 1\*"""
            .UseShellExecute = False
            .CreateNoWindow = True
            .RedirectStandardInput = True
            .RedirectStandardOutput = True
            .RedirectStandardError = True
        End With

        _7zip.Start()
        AppendOutputText("Process Started at: " & _7zip.StartTime.ToString & vbCrLf)
        txtConsole.AppendText(_7zip.StartInfo.Arguments & vbCrLf)
        txtConsole.AppendText(_7zip.StandardError.ReadToEnd())
        txtConsole.AppendText(_7zip.StandardOutput.ReadToEnd())


    End Sub

    Private Sub AppendOutputText(ByVal text As String)

        txtConsole.AppendText(vbCrLf & text)
    End Sub

    Private Sub Server_ErrorOutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles _7zip.ErrorDataReceived
        AppendOutputText(e.Data)

    End Sub

    Private Sub Server_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles _7zip.OutputDataReceived
  
        AppendOutputText(e.Data)

    End Sub

End Class
