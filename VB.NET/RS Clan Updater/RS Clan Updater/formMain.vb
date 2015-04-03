Imports System.IO
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop

Public Class formMain

    Private Sub formMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        ConfigureProgress()
        txtConsole.AppendText("Progress bar configured." & vbCrLf)
        UpdateClans()

    End Sub

    Private Sub btnHelp_Click(sender As System.Object, e As System.EventArgs) Handles btnHelp.Click
        txtConsole.AppendText("Instructions:" & vbCrLf & vbCrLf)
        txtConsole.AppendText("Place a text file named ""Names.txt"" in the same folder as this application." & vbCrLf & vbCrLf)
        txtConsole.AppendText("The text file should contain all the names of the clan, each name on a new line." & vbCrLf & vbCrLf)
        txtConsole.AppendText("Place the spreadsheet named ""Runescape Accounts.xlsx"" in the same folder." & vbCrLf & vbCrLf)
        txtConsole.AppendText("The names should be in the C column, and the clans in the D column." & vbCrLf & vbCrLf)
        txtConsole.AppendText("Press start and the clan will be applied the the correct names." & vbCrLf & vbCrLf)
    End Sub

    Private Sub UpdateClans()
        txtConsole.AppendText("Starting Update." & vbCrLf)
        Dim oReader As New StreamReader("Paid Mercenaries.txt")
        Dim textLine As String
        Dim Done As Boolean = False

        Dim oExcel As Excel.Application
        Dim oWorkBook As Excel.Workbook
        Dim oSheet As Excel.Worksheet
        Dim oRange As Excel.Range
        Dim SearchRow As Integer = 2

        oExcel = CType(CreateObject("Excel.Application"), Excel.Application)
        oWorkBook = oExcel.Workbooks.Open(My.Computer.FileSystem.CurrentDirectory & "\RS Accounts.xlsx")
        oSheet = CType(oWorkBook.ActiveSheet, Excel.Worksheet)

        Do While oReader.Peek <> -1
            textLine = oReader.ReadLine
            textLine = textLine.ToLower

            Do Until Done = True
                If oSheet.Range("C" & SearchRow).Value Is Nothing Then
                    Done = True
                    txtConsole.AppendText(textLine & " was not found" & vbCrLf)
                Else
                    If oSheet.Range("C" & SearchRow).Value.ToString.ToLower = textLine Then
                        oSheet.Range("D" & SearchRow).Value = "Paid Mercenaries"
                        txtConsole.AppendText("[FOUND] " & textLine & vbCrLf)
                        Done = True
                    Else
                        SearchRow += 1
                    End If
                End If

            Loop

            txtConsole.Refresh()
            Done = False
            SearchRow = 2
            ProgressBar1.Value += 1
            ProgressBar1.Refresh()
            lblPercentage.Text = CStr(Int(((ProgressBar1.Value / ProgressBar1.Maximum) * 100)) & "%")

        Loop

        oReader.Close()
        oWorkBook.Save()
        oRange = Nothing
        oSheet = Nothing
        oWorkBook = Nothing
        oExcel.Quit()
        oExcel = Nothing

        txtConsole.AppendText("Update complete." & vbCrLf)
    End Sub

    Private Sub ConfigureProgress()
        Dim oReader As New StreamReader("Paid Mercenaries.txt")
        Dim textLine As String
        Dim Count As Integer

        While oReader.Peek <> -1
            textLine = oReader.ReadLine
            Count += 1
        End While

        ProgressBar1.Maximum = Count
        txtConsole.AppendText("There are " & Count & " names to compare." & vbCrLf)

        oReader.Close()
    End Sub
End Class
