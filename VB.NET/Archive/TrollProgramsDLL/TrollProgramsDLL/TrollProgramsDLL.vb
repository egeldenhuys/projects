Imports System.Security.Cryptography
Imports System.Net
Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms

Namespace Cryptography

    Public Class SHA512

        Public Function GetFileHash(ByVal filepath As String) As String

            ' Create file handle
            Dim File As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)

            ' create a new md5 object
            Dim SHA512 As New SHA512CryptoServiceProvider()

            ' compute the hash
            Dim byteHash() As Byte = SHA512.ComputeHash(File)

            File.Close()

            ' Convert byte hash to string
            Return ByteArrayToString(byteHash)

        End Function

        Private Function ByteArrayToString(ByVal input() As Byte) As String
            ' Make a string builder that is twice as long as the amount of bytes
            Dim stringBuilder As New System.Text.StringBuilder(input.Length * 2)

            For i As Integer = 0 To input.Length - 1
                stringBuilder.Append(input(i).ToString("X2"))
            Next

            Return stringBuilder.ToString.ToLower

        End Function

    End Class
End Namespace

Namespace Network
    Public Class Downloader

        Dim WithEvents WC As New WebClient

        Public Event DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)


        Public Sub DownloadFileAsync(ByVal uri As Uri, ByVal destinationFolder As String, ByVal fileName As String)


            ' Check if the destination folder is in the right format
            If destinationFolder.Last <> "\" Then

                destinationFolder = destinationFolder & "\"
            End If

            WC.DownloadFileAsync(uri, destinationFolder & fileName)

        End Sub

        Private Sub WC_DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted

            RaiseEvent DownloadFileCompleted(sender, e)

        End Sub

        Public Function IsBusy() As Boolean

            Return WC.IsBusy
        End Function

    End Class

End Namespace

Public Class Update

    Dim WithEvents WC As New WebClient

    Public Event UpdateCheckDone(webContents As String)

    Public Sub CheckForUpdate(ByVal currentVersion As String, ByVal uri As Uri)

        WC.DownloadStringAsync(uri)

    End Sub

    Private Sub WC_DownloadFinished(sender As Object, e As DownloadStringCompletedEventArgs) Handles WC.DownloadStringCompleted

        RaiseEvent UpdateCheckDone(e.Result)
    End Sub
End Class

Namespace Compression
    Public Class SevenZip

        Public Sub CreateArchive(ByVal sourcePath As String, ByVal destinationPath As String, ByVal archiveName As String, ByVal compressionLevel As Integer, _
                                 ByVal compressionType As String, ByVal archiveType As String, ByVal OutputTextBox As TextBox, _
                                 Optional ByVal binaryPath As String = "7zip.exe")

            Dim procInfo As New ProcessStartInfo(binaryPath)

            ' Set process start info
            procInfo.UseShellExecute = False
            procInfo.CreateNoWindow = False
            procInfo.RedirectStandardError = True
            procInfo.RedirectStandardOutput = True
            procInfo.Arguments = "a" & " -t" & archiveType & " -mx=" & compressionLevel & " " & destinationPath & archiveName & "." & archiveType & " " & sourcePath

            ' Start the process

            Dim proc As New Process()
            proc.StartInfo = procInfo

            proc.Start()

            ' Attach to stdout and stderr
            Dim stdOut As StreamReader = proc.StandardOutput
            Dim stdErr As StreamReader = proc.StandardError

            ' Display the results

            OutputTextBox.Text &= stdOut.ReadToEnd
            OutputTextBox.Text &= stdErr.ReadToEnd

            ' Clean up
            stdOut.Close()
            stdErr.Close()

        End Sub
    End Class

End Namespace