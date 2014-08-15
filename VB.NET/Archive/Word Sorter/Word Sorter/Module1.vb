Module Module1

    Dim TotalWords As Integer = 0

    Sub Main()
        My.Computer.FileSystem.CreateDirectory("Words\")
        DisplayMenu()
        TotalWords = GetFileLength()

        Console.WriteLine("Words: " & TotalWords)

        If Console.ReadLine = "start" Then
            StartSorting()

        End If

    End Sub

    Private Sub DisplayMenu()
        Console.WriteLine("This program will read all words in a text file called Words.txt and write the words in a textfile with the name as the word's length.")
        Console.WriteLine("EG. Dog -> 3.txt (Contents: Dog, cat, rat...)")
        Console.WriteLine("------------------------")
        Console.WriteLine("Type start to start sorting words")

    End Sub

    Private Sub StartSorting()
        Dim reader As New System.IO.StreamReader("words.txt")
        Dim wordsDone As Integer

        Dim textLine As String

        While reader.Peek <> -1
            textLine = reader.ReadLine
            AppendToFile(textLine)
            wordsDone += 1
            Console.WriteLine("(" & wordsDone & "/" & TotalWords & ") " & textLine & " = " & textLine.Length)

        End While

        reader.Close()


    End Sub

    Private Function GetFileLength() As Integer
        Dim result As Integer = 0
        Dim reader As New System.IO.StreamReader("words.txt")
        Dim text As String
        text = reader.ReadToEnd()

        Dim subStrings() As String
        subStrings = text.Split(CChar(Environment.NewLine))

        For Each element In subStrings
            result += 1
        Next


        reader.Close()
        Return result
    End Function

    Private Sub AppendToFile(ByVal stringToAppend As String)
        Dim fileName As String = "Words\" & stringToAppend.Length & ".txt"

        Dim writer As New System.IO.StreamWriter(fileName, True)
        writer.WriteLine(stringToAppend)
        writer.Close()

    End Sub

End Module
