Module modMain

    Private dnsInfoList As List(Of dnsInfo)
    Private interval As Integer = 60000

    Sub Main()

        PrintProgramInfo()
        PrintCommands()
        Dim input As String = ""


        Do Until input.ToLower = "Q"
            HandleCommand(input)

            input = Console.ReadLine

            PrintCommands()

        Loop

    End Sub

    Private Sub HandleCommand(ByVal cmd As String)

        If cmd.Length = 0 Then
            Exit Sub

        End If

        Dim arguments() As String
        arguments = cmd.Split(CChar(" "))

        Dim cmdLetter As Char = Char.ToLower(cmd(0))

        Select Case cmdLetter
            Case CChar("A")

                AddDNS(arguments(1), arguments(2))

            Case CChar("V")
                For i As Integer = 0 To dnsInfoList.Count - 1
                    Console.WriteLine(dnsInfoList.Item(i).Name + " " + dnsInfoList.Item(i).UpdateURL)
                Next

            Case CChar("D")
                DeleteDNS(CInt(arguments(1)))

            Case CChar("I")
                If arguments.Length > 0 Then
                    interval = CInt(arguments(1))
                    Console.WriteLine("interval = " + interval.ToString)

                Else

                    Console.WriteLine("interval = " + interval.ToString)
                End If


        End Select
    End Sub

    Private Sub PrintProgramInfo()
        Console.WriteLine( _
"+-----------------------------------------------------------------------------+" + vbNewLine + _
"|                                 DYNAMIC DNS                                 |" + vbNewLine + _
"+=============================================================================+" + vbNewLine + _
"|                                 DESCRIPTION:                                |" + vbNewLine + _
"| This program will automatically update the DNS record on FreeDNS to point   |" + vbNewLine + _
"| to the external IP address of the computer running this program             |" + vbNewLine + _
"+-----------------------------------------------------------------------------+")

    End Sub

    Private Sub PrintCommands()
        Console.WriteLine( _
"+-----------------------------------------------------------------------------+" + vbNewLine + _
"| COMMANDS:                                                                   |" + vbNewLine + _
"| [A <Name> <Update URL>] - Add DNS                                                               |" + vbNewLine + _
"| [V] - View DNS list                                                         |" + vbNewLine + _
"| [D <ID>] - Delete DNS with ID <ID>                                          |" + vbNewLine + _
"| [I] - Display the current update interval                                   |" + vbNewLine + _
"| [I <seconds>] - Set the update interval                                     |" + vbNewLine + _
"| [Q] - Quit                                                                  |" + vbNewLine + _
"+-----------------------------------------------------------------------------+")

    End Sub

    Private Sub Menu()



        Console.ReadKey()

    End Sub

    Private Sub AddDNS(ByVal name As String, ByVal updateUrl As String)

    End Sub

    Private Sub ViewList()

    End Sub

    Private Sub DeleteDNS(ByVal id As Integer)

    End Sub

    Private Sub UpdateDNS()

    End Sub

    Private Sub SaveList()

    End Sub

    Private Sub LoadList()

    End Sub

End Module
