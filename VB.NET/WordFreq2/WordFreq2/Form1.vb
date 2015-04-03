Imports System.ComponentModel

Public Class Form1
    Dim InFilePath As String = "C:\Users\Evert\Desktop\S\I.txt"
    Dim OutFilePath As String = "C:\Users\Evert\Desktop\S\O.txt"
    Dim InWords(0) As String
    Dim Words(0, 1) As String
    Dim TotalWords As Integer = 1
    Dim WordsDone As Integer = 0

    ' 0 - 0
    '   - 1
    '
    ' Word ID - Word
    '         - Word Count

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        Dim writer As New System.IO.StreamWriter(OutFilePath, False)
        writer.Write("Working...")
        writer.Close()

        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub GetAllWordsFreq(ByVal inputArray() As String, ByRef outputWordsArray(,) As String)
        Dim wordCount As Integer
        Dim countedWords(0) As String



        ' Go throught the input array and count each word frequency
        For Each word In inputArray

            ' Check if the word has been counted, if false count the word frequency and add it to the counted list.
            '#If FindWordInArray(countedWords, word) = False Then

            ' Count the words in the input array
            wordCount = CountWordInArray(inputArray, word)

            ' Add the word and it's freq to the output array
            AddWordFreqToArray2D(outputWordsArray, word, wordCount)
            Console.WriteLine(word & " : " & wordCount)

            'Delete the word from the main array
            DeleteFromArray1D(inputArray, word)

            ' Add the counted word to the counted words array
            '#AddToArray1D(countedWords, word)
            '#End If


            WordsDone += 1
            BackgroundWorker1.ReportProgress(1)
            WriteWordsFreqToFile(Words, OutFilePath)
        Next

        MsgBox("DONE!")


    End Sub

    Private Function FindWordInArray(ByVal inputArray() As String, ByVal inputWord As String) As Boolean
        Console.WriteLine("Searching for """ & inputWord & """ in the inputArray")
        Dim result As Boolean = False

        ' Go throught each word in the input array and if it matches the input word return true

        For Each word In inputArray
            If word <> Nothing Then
                If word = inputWord Then
                    Console.WriteLine("Found " & word)
                    result = True
                    Exit For
                End If
                Console.WriteLine("""" & word.ToString & """" & " did not match the word that we are looking for.")
            End If

        Next

        Return result
    End Function

    Private Sub DeleteFromArray1D(ByRef inputArray() As String, ByVal word As String)
        Dim tmpArray(0) As String
        Dim i As Integer
        Dim iSize As Integer

        Dim uBoundbefore, uBoundAfter As Integer

        uBoundbefore = inputArray.GetUpperBound(0)

        For i = 0 To inputArray.GetUpperBound(0)
            ' if it is not the word we are trying to delete add it to the tmp array
            If inputArray(i) <> word Then
                AddToArray1D(tmpArray, inputArray(i))
                iSize += 1
            End If
        Next

        ' Contract the inputArray
        ReDim inputArray(iSize)
        inputArray = tmpArray

        uBoundAfter = inputArray.GetUpperBound(0)

        TotalWords = TotalWords - (uBoundbefore - uBoundAfter)

    End Sub

    Private Function CountWordInArray(ByVal inputArray() As String, ByVal inputWord As String) As Integer
        Dim wordCount As Integer = 0

        For Each word In inputArray
            If word = inputWord Then
                wordCount += 1
            End If
        Next

        Return wordCount
    End Function

    Private Sub AddWordFreqToArray2D(ByRef inputArray(,) As String, ByVal word As String, ByVal freq As Integer)
        Dim upperBound As Integer = inputArray.GetUpperBound(0)

        ' Check to see if the last element is empty, if it is add the data, else expand then add
        If inputArray(upperBound, 0) = Nothing Then
            inputArray(upperBound, 0) = word
            inputArray(upperBound, 1) = freq.ToString

        Else
            ExpandArray2D(inputArray)
            inputArray(upperBound + 1, 0) = word
            inputArray(upperBound + 1, 1) = freq.ToString
        End If
    End Sub

    ''' <summary>
    ''' Expands the inputArray's first dimension by 1
    ''' </summary>
    ''' <param name="inputArray">hur dur?</param>
    ''' <remarks>no remakrs. ty!</remarks>
    Private Sub ExpandArray2D(ByRef inputArray(,) As String)
        Dim tmpArray(0, 0) As String

        tmpArray = inputArray

        ReDim inputArray(inputArray.GetUpperBound(0) + 1, 1)

        ' Put the elements back into the original array
        For i As Integer = 0 To tmpArray.GetUpperBound(0)
            inputArray(i, 0) = tmpArray(i, 0)
            inputArray(i, 1) = tmpArray(i, 1)
        Next

    End Sub

    Private Sub AddToArray1D(ByRef inputArray() As String, ByVal word As String)
        Dim upperBound As Integer = inputArray.GetUpperBound(0)

        ' Check to see if the last element is empty, if it is add the data, else expand then add
        If inputArray(upperBound) = Nothing Then
            inputArray(upperBound) = word
        Else
            ReDim Preserve inputArray(upperBound + 1)
            inputArray(upperBound + 1) = word
        End If
    End Sub

    Private Sub LoadWordsFromFile(ByRef inputArray() As String, ByVal filePath As String, ByVal delimiter As String)
        Dim reader As New System.IO.StreamReader(filePath)
        Dim fileContents As String

        fileContents = reader.ReadToEnd
        fileContents = fileContents.ToLower

        inputArray = Split(fileContents, delimiter)

        reader.Close()

        TotalWords = inputArray.GetLength(0)
        Console.WriteLine("There are " & TotalWords & " words in the file.")
    End Sub

    Private Sub WriteWordsFreqToFile(ByVal inputArray(,) As String, ByVal filepath As String)
        Dim writer As New System.IO.StreamWriter(filepath, True)

        '#For i As Integer = 0 To inputArray.GetUpperBound(0)
        writer.WriteLine(inputArray(0, 0) & " : " & inputArray(0, 1))
        '#Next

        writer.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        LoadWordsFromFile(InWords, InFilePath, " ")

        GetAllWordsFreq(InWords, Words)

        WriteWordsFreqToFile(Words, OutFilePath)
    End Sub

    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If WordsDone < TotalWords Then
            ProgressBar1.Maximum = TotalWords
            ProgressBar1.Value = WordsDone
            ProgressBar1.Refresh()
            Label1.Text = WordsDone & "/" & TotalWords & " (" & Math.Round(((WordsDone / TotalWords) * 100), 2) & "%)"
            Label1.Refresh()
        End If

    End Sub
End Class
