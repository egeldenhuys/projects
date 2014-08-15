Public Class Form1
    Dim String1 As String
    Dim String2 As String
    Dim Result As String
    Dim Method As Integer


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlOptions.Visible = False
        Method = 2
    End Sub

    Private Sub btnEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncrypt.Click
        String1 = TextBox1.Text
        String1 = String1.ToLower

        Select Case Method
            Case 1
                Method1_Encrypt()
            Case 2
                Method2_Encrypt()
        End Select
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Private Sub Method1_Encrypt()
        String1 = String1.Replace("a", "Y")
        String1 = String1.Replace("b", "W")
        String1 = String1.Replace("c", "E")
        String1 = String1.Replace("d", "R")
        String1 = String1.Replace("e", "T")
        String1 = String1.Replace("f", "Q")
        String1 = String1.Replace("g", "U")
        String1 = String1.Replace("h", "I")
        String1 = String1.Replace("i", "O")
        String1 = String1.Replace("j", "P")
        String1 = String1.Replace("k", "M")
        String1 = String1.Replace("l", "N")
        String1 = String1.Replace("m", "B")
        String1 = String1.Replace("n", "V")
        String1 = String1.Replace("o", "C")
        String1 = String1.Replace("p", "0")
        String1 = String1.Replace("q", "H")
        String1 = String1.Replace("r", "G")
        String1 = String1.Replace("s", "F")
        String1 = String1.Replace("t", "D")
        String1 = String1.Replace("u", "L")
        String1 = String1.Replace("v", "K")
        String1 = String1.Replace("w", "J")
        String1 = String1.Replace("x", "S")
        String1 = String1.Replace("y", "Z")
        String1 = String1.Replace("z", "A")
        String1 = String1.Replace(" ", "X")
        String1 = String1.ToLower()
        TextBox2.Text = String1
    End Sub

    Private Sub btnDecrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecrypt.Click
        String1 = TextBox2.Text
        String1 = String1.ToLower

        Select Case Method
            Case 1
                Method1_Decrypt()
            Case 2
                Method2_Decrypt()
        End Select

    End Sub
    Private Sub Method1_Decrypt()
        String1 = String1.Replace("y", "A")
        String1 = String1.Replace("w", "B")
        String1 = String1.Replace("e", "C")
        String1 = String1.Replace("r", "D")
        String1 = String1.Replace("t", "E")
        String1 = String1.Replace("q", "F")
        String1 = String1.Replace("u", "G")
        String1 = String1.Replace("i", "H")
        String1 = String1.Replace("o", "I")
        String1 = String1.Replace("p", "J")
        String1 = String1.Replace("m", "K")
        String1 = String1.Replace("n", "L")
        String1 = String1.Replace("b", "M")
        String1 = String1.Replace("v", "N")
        String1 = String1.Replace("c", "O")
        String1 = String1.Replace("0", "P")
        String1 = String1.Replace("h", "Q")
        String1 = String1.Replace("g", "R")
        String1 = String1.Replace("f", "S")
        String1 = String1.Replace("d", "T")
        String1 = String1.Replace("l", "U")
        String1 = String1.Replace("k", "V")
        String1 = String1.Replace("j", "W")
        String1 = String1.Replace("s", "X")
        String1 = String1.Replace("z", "Y")
        String1 = String1.Replace("a", "Z")
        String1 = String1.Replace("x", " ")
        String1 = String1.ToLower()
        TextBox1.Text = String1
    End Sub

    Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRename.Click
        If Me.Text <> "" Then
            Me.Text = ""
        Else
            Me.Text = "Message encrypter"
        End If
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim File_Name As String = "C:\Users\Evert\Test.txt"
        Dim Reader As New System.IO.StreamReader(File_Name)
        TextBox1.Text = Reader.ReadToEnd
        Reader.Close()
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        pnlOptions.Visible = True
        pnlOptions.BringToFront()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If rbtnMethod1.Checked = True Then
            Method = 1
        ElseIf rbtnMethod2.Checked = True Then
            Method = 2
        End If
        pnlOptions.Visible = False
    End Sub

    Private Sub Method2_Encrypt()
        Dim i As Integer = 0
        Dim str As String = TextBox1.Text
        Dim Result As String = ""
        Dim ResultA As String = ""
        'Label2.Text = Len(str)
        'needs to be 3 chars long
        For i = 1 To Len(str)
            'first char to ascii
            Result = Asc(str)
            If Result < 100 Then
                Result = "0" & Result
            End If
            'adds ascii together
            ResultA = ResultA & Result
            'removes char that is already converted
            str = str.Remove(0, 1)
        Next

        ResultA = ResultA.Replace("0", ".")
        ResultA = ResultA.Replace("1", ",")
        ResultA = ResultA.Replace("2", "$")
        ResultA = ResultA.Replace("3", "<")
        ResultA = ResultA.Replace("4", "=")
        ResultA = ResultA.Replace("5", "*")
        ResultA = ResultA.Replace("6", "!")
        ResultA = ResultA.Replace("7", "'")
        ResultA = ResultA.Replace("8", "`")
        ResultA = ResultA.Replace("9", "/")
        TextBox2.Text = ResultA


    End Sub

    Private Sub Method2_Decrypt()
        Dim str2 As String
        Dim Result2 As String = ""
        Dim ResultA2 As String = ""
        Dim strTmp As String

        str2 = TextBox2.Text
        str2 = str2.Replace(".", "0")
        str2 = str2.Replace(",", "1")
        str2 = str2.Replace("$", "2")
        str2 = str2.Replace("<", "3")
        str2 = str2.Replace("=", "4")
        str2 = str2.Replace("*", "5")
        str2 = str2.Replace("!", "6")
        str2 = str2.Replace("'", "7")
        str2 = str2.Replace("`", "8")
        str2 = str2.Replace("/", "9")

        
        For i = 1 To (Len(str2) / 3)
            'removes all but the first 3 ascii numbers
            If Len(str2) = 3 Then
                strTmp = str2
            Else
                strTmp = str2.Substring(0, 3)
            End If
            'strTmp = str2.Remove((0 + 3), (Len(str2) - 3))
            'debugging
            'Label2.Text = strTmp
            'converts ascii to char
            If strTmp.StartsWith(0) Then
                strTmp = strTmp.Remove(0, 1)
            End If
            Result2 = Chr(strTmp)
            'adds all chars together
            ResultA2 = ResultA2 & Result2
            'removes first 3 converted ascii numbers
            str2 = str2.Remove(0, 3)
        Next
        TextBox1.Text = ResultA2
    End Sub
End Class
