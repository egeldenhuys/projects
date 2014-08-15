Imports System.IO

Public Class Form1
    Dim RawWords(0) As String
    Dim CountedWords(0) As String
    Dim Word(0) As String
    Dim WordCount(0) As Integer


    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        Dim Reader As New StreamReader(txtInput.Text)

        Dim textFile As String

        'Read Whole file and split by ' '
        textFile = Reader.ReadToEnd
        RawWords = Split(textFile, " ")
        Reader.Close()

        Dim wordCounter As Integer = 0
        Dim arrayCounter As Integer = 0




        For Each element1 In RawWords
            ' Check if thr word has already been counted
            If alreadyCounted(element1) = False Then
                ' Count all the RawWords
                For Each element2 In RawWords
                    ' Check if the word matches the word we are searching for
                    If element2 = element1 Then
                        wordCounter += 1
                    End If



                Next ' RawWords

                ' Add the new word and it's freq to the word and wordcounter array
                Word(arrayCounter) = element1
                WordCount(arrayCounter) = wordCounter

                arrayCounter += 1
                wordCounter = 0

                'Expand the arrays
                ReDim Preserve Word(arrayCounter)
                ReDim Preserve WordCount(arrayCounter)
            End If
        Next

        Dim arrayCounter2 As Integer = 0

        Dim Writer As New StreamWriter(txtOutput.Text)
        For Each element In Word
            Writer.WriteLine(Word(arrayCounter2) & " : " & WordCount(arrayCounter2))
            arrayCounter2 += 1
        Next

        Writer.Close()

    End Sub

    Private Function alreadyCounted(ByVal strWord As String) As Boolean
        Dim result As Boolean

        For Each element In CountedWords
            If strWord = element Then
                result = True
            Else
                result = False
                ' Add the word to the array
                CountedWords(CountedWords.GetUpperBound(0)) = strWord

                ReDim Preserve CountedWords(CountedWords.GetUpperBound(0) + 1)
            End If
        Next

        
        Return result

    End Function
End Class
