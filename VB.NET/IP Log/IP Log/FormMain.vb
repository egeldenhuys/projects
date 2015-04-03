Imports System.IO
Public Class FormMain
    Dim Version As String = "0.01"
    Dim IpCount As Integer = 0
    Dim IpAddressesAll() As String
    Dim IpAddressesUnique() As String
    Dim SaveFileLocation As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\Ips.txt"

    Private Sub FormMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblVersion.Text = Version

        If My.Computer.FileSystem.FileExists(SaveFileLocation) Then
            LoadIPs()
        End If

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Dim Proxy As String = "No"

        If checkbProxy.Checked = True Then
            Proxy = "Yes"
        Else
            Proxy = "No"
        End If

        ' Add IP to list
        listIP.Items.Add(txtbIP.Text)

        ' Add IP to array
        ReDim Preserve IpAddressesAll(0 To IpCount)
        IpAddressesAll(IpCount) = txtbIP.Text & ";" & (System.DateTime.Now.ToString) & ";" & Proxy
        IpCount += 1

        checkbProxy.Checked = False
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        ' Remove IP from list and array
        Dim Substrings() As String
        Dim ElementCount As Integer = 0
        Dim TempArrayStore() As String

        For Each Element In IpAddressesAll
            Substrings = Split(Element, ";")

            If Substrings(0) = listIP.SelectedItem.ToString Then
                IpAddressesAll(ElementCount) = "DELETED"
            End If

            ElementCount += 1
        Next

        TempArrayStore = IpAddressesAll
        ElementCount = 0

        For Each Element In TempArrayStore

            If Element <> "DELETED" Then
                ReDim Preserve IpAddressesAll(0 To ElementCount)
                IpAddressesAll(ElementCount) = Element
                ElementCount += 1
            End If

        Next
        Dim SelectedIndex As Integer = listIP.SelectedIndex

        listIP.Items.Clear()
        DisplayIpsFromArray()


    End Sub

    Private Sub checkbShowAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles checkbShowAll.CheckedChanged
        ' Only display unique/all IPs


    End Sub

    Private Sub LoadIPs()
        ' Read IPs from file into array and add to list box
        Try
            Dim Reader As New StreamReader(SaveFileLocation)
            Dim TextLine As String

            While Reader.Peek <> -1
                TextLine = Reader.ReadLine

                ReDim Preserve IpAddressesAll(0 To IpCount)
                IpAddressesAll(IpCount) = TextLine

                IpCount += 1
            End While

            DisplayIpsFromArray()
            Reader.Close()
        Catch ex1 As FileNotFoundException

        Finally

        End Try
    End Sub

    Private Sub FormMain_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Save Array to file

        Dim Writer As New StreamWriter(SaveFileLocation, False)

        For Each element In IpAddressesAll
            Writer.WriteLine(element)
        Next

        Writer.Close()
    End Sub

    Private Sub listIP_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles listIP.SelectedIndexChanged
        Dim Substrings() As String
        Dim MatchesFound As Integer = 0
        Dim Ip As String
        Dim DateAdded As String
        Dim Proxy As String

        Substrings = Split(IpAddressesAll(listIP.SelectedIndex), ";")

        Ip = Substrings(0)
        DateAdded = Substrings(1)
        Proxy = Substrings(2)

        For Each element In IpAddressesAll
            Substrings = Split(element, ";")

            If Substrings(0) = Ip Then
                MatchesFound += 1
            End If
        Next

        lblIP.Text = Ip
        lblDate.Text = DateAdded
        lblMatches.Text = MatchesFound.ToString
        lblProxy.Text = Proxy

    End Sub

    Private Sub DisplayIpsFromArray()
        Dim Substrings() As String

        For Each Element In IpAddressesAll
            Substrings = Split(Element, ";")
            listIP.Items.Add(Substrings(0))
        Next

    End Sub
End Class
