Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim CurDir As String = My.Computer.FileSystem.CurrentDirectory.ToString
        Dim fileName As String
        Dim IDString As String = "T"

        Dim substringsID() As String
        Dim substringsExt() As String

        Dim _Year, _Month, _Day, _Hour, _Minute, _Second As Integer
        Dim PM_Or_AM As String
        Dim CurTime As String

        _Year = Date.Now.Year
        _Month = Date.Now.Month
        _Day = Date.Now.Day
        _Hour = Date.Now.Hour
        _Minute = Date.Now.Minute
        _Second = Date.Now.Second

        ' Convert to 12 hour time and determine if PM or AM
        If _Hour > 12 Then
            _Hour = _Hour - 12
            PM_Or_AM = " PM"
        Else
            PM_Or_AM = " AM"
        End If

        CurTime = (_Year & "-" & _Month & "-" & _Day & " " & _Hour & "-" & _Minute & "-" & _Second)

        ' For each file in the current directory.
        For Each file In My.Computer.FileSystem.GetFiles(CurDir, FileIO.SearchOption.SearchTopLevelOnly)
            fileName = My.Computer.FileSystem.GetName(file) ' Full name (CurrentDate.exe)

            ' If the program has not been run before.
            If fileName = "CurrentDate.exe" Then
                My.Computer.FileSystem.RenameFile(file, "T= " & CurTime & PM_Or_AM & ".exe")

                ' Exit loop to avoid errors
                Exit For

            Else
                ' Split the file name at "." Allow only 2 substrings to be returned. Makes sure that only .exe files are renamed.
                substringsExt = Split(fileName, ".", 2)

                ' If it is an .exe file then check if it has the correct prefix ("T= ")
                If substringsExt(1) = "exe" Then

                    substringsID = Split(fileName, "= ", 2)

                    If substringsID(0) = "T" Then
                        My.Computer.FileSystem.RenameFile(file, "T= " & CurTime & PM_Or_AM & ".exe")

                        ' Exit loop to avoid errors
                        Exit For
                    End If
                End If
            End If

        Next

        Me.Close()
    End Sub
End Class
