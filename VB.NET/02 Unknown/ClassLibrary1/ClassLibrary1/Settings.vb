Imports System.IO

Public Class Settings
    Public Sub Save(ByVal Name As String, ByVal Value As String, ByVal FilePath As String)
        Dim Reader As StreamReader
        Dim Writer As StreamWriter
        Dim TextLine As String
        Dim Substrings(0 To 1) As String
        Dim Content As String = ""
        Dim Found As Boolean

        If My.Computer.FileSystem.FileExists(FilePath) = True Then

            Reader = New StreamReader(FilePath)

            While Reader.Peek <> -1
                TextLine = Reader.ReadLine
                Substrings = Split(TextLine, "=", 2)

                If Name = Substrings(0) Then
                    Found = True
                    Content &= vbNewLine & Name & "=" & Value & vbNewLine
                Else
                    Content &= TextLine
                End If

                If Reader.Peek = -1 Then
                    If Found = False Then
                        Content &= vbNewLine & Name & "=" & Value & vbNewLine
                    End If
                End If


            End While
            Reader.Close()
        Else
            Content = Name & "=" & Value & vbNewLine
        End If

        Writer = New StreamWriter(FilePath, False)
        Writer.Write(Content)
        Writer.Close()

    End Sub

    Public Function Load(ByVal Name As String, ByVal FilePath As String) As String
        Dim Value As String = ""

        Dim Reader As StreamReader
        Dim TextLine As String
        Dim Substrings(0 To 1) As String

        Reader = New StreamReader(FilePath)
        While Reader.Peek <> -1
            TextLine = Reader.ReadLine
            Substrings = Split(TextLine, "=", 2)

            If Name = Substrings(0) Then
                Value = Substrings(1)
            End If

        End While
        Reader.Close()

        Return Value
    End Function

    Public Sub Delete(ByVal Name As String, ByVal FilePath As String)

        Dim Reader As StreamReader
        Dim Writer As StreamWriter
        Dim TextLine As String
        Dim Substrings(0 To 1) As String
        Dim Content As String = ""
        Dim Found As Boolean

        If My.Computer.FileSystem.FileExists(FilePath) = True Then

            Reader = New StreamReader(FilePath)

            While Reader.Peek <> -1
                TextLine = Reader.ReadLine
                Substrings = Split(TextLine, "=", 2)

                If Name = Substrings(0) Then
                    Found = True
                Else
                    Content &= TextLine
                End If

            End While
            Reader.Close()
        End If

        Writer = New StreamWriter(FilePath, False)
        Writer.Write(Content)
        Writer.Close()

    End Sub
End Class


