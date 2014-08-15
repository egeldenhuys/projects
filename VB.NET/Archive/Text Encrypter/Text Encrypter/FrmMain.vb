Imports System.Security.Cryptography
Public Class FrmMain
    Dim String1 As String
    Dim String2 As String
    Dim Result As String
    Dim Method As Integer
    Private Sub FrmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PnlMain.BringToFront()
        Method = 3
        RbtnMethod3.Checked = True
        lblError.Visible = False

        If Method = 3 Then
            lblMethod3.Visible = True
            boxMethod3Key.Visible = True
        Else
            lblMethod3.Visible = False
            boxMethod3Key.Visible = False
        End If
    End Sub
#Region "Main panel"


#Region "Buttons"
    Private Sub btnEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncrypt.Click
        String1 = TextBox1.Text
        String1 = String1.ToLower

        Select Case Method
            Case 1
                Method1_Encrypt()
            Case 2
                Method2_Encrypt()
            Case 3
                Method3_Encrypt()
        End Select
    End Sub

    Private Sub btnDecrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecrypt.Click
        String1 = TextBox2.Text
        String1 = String1.ToLower

        Select Case Method
            Case 1
                Method1_Decrypt()
            Case 2
                Method2_Decrypt()
            Case 3
                Method3_Decrypt()
        End Select
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        lblError.Visible = False
    End Sub

    Private Sub btnOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOptions.Click
        PnlOptions.BringToFront()
    End Sub

    Private Sub btnChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChanges.Click
        TextBox1.Text = LoadChangelog()

        'reads from text file and displays in textbox1.
        'txt file gets installed with application or changes are hardcoded
        'Task: Rename "Changes" to "Changelog"
    End Sub

    Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRename.Click
        Me.Text = ""
    End Sub


#End Region

#Region "Encryption Methods"
    Public Sub Method1_Encrypt()
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
        ResultA = ResultA.Replace("2", "-")
        ResultA = ResultA.Replace("3", "<")
        ResultA = ResultA.Replace("4", "=")
        ResultA = ResultA.Replace("5", ";")
        ResultA = ResultA.Replace("6", ":")
        ResultA = ResultA.Replace("7", "'")
        ResultA = ResultA.Replace("8", "`")
        ResultA = ResultA.Replace("9", "~")

        TextBox2.Text = ResultA
        lblError.Visible = False
    End Sub

    Private Sub Method2_Decrypt()
        On Error GoTo ErrorHandler
        Dim str2 As String
        Dim Result2 As String = ""
        Dim ResultA2 As String = ""
        Dim strTmp As String

        str2 = TextBox2.Text
        str2 = str2.Replace(".", "0")
        str2 = str2.Replace(",", "1")
        str2 = str2.Replace("-", "2")
        str2 = str2.Replace("<", "3")
        str2 = str2.Replace("=", "4")
        str2 = str2.Replace(";", "5")
        str2 = str2.Replace(":", "6")
        str2 = str2.Replace("'", "7")
        str2 = str2.Replace("`", "8")
        str2 = str2.Replace("~", "9")


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
        lblError.Visible = False

        Exit Sub

ErrorHandler:
        lblError.Visible = True

    End Sub

    Private Sub Method3_Encrypt()

        Dim plainText As String = TextBox1.Text
        Dim password As String = boxMethod3Key.Text

        Dim wrapper As New Simple3Des(password)
        Dim cipherText As String = wrapper.EncryptData(plainText)

        TextBox2.Text = cipherText

    End Sub

    Private Sub Method3_Decrypt()

        Dim cipherText As String = TextBox2.Text
        Dim password As String = boxMethod3Key.Text
        Dim wrapper As New Simple3Des(password)

        ' DecryptData throws if the wrong password is used.
        Try
            Dim plainText As String = wrapper.DecryptData(cipherText)
            TextBox1.Text = plainText
        Catch ex As System.Security.Cryptography.CryptographicException
            lblError.Visible = True
            lblError.Text = "The data could not be decrypted with the password."
        End Try
    End Sub
#End Region

#Region "Functions"
    Private Function LoadChangelog()
        Dim Changelog As String

        Changelog = ("ToDo:" & vbNewLine _
                     & "Improve Changelog" & vbNewLine _
                     & "Convert encrytpion methods to functions." & vbNewLine _
                     & "Rename Changes to Changelog" & vbNewLine _
                     & "Improve GUI" & vbNewLine _
                     & "Add some colour" & vbNewLine _
                     & "Add Instructions" & vbNewLine _
                     & "Add help button" & vbNewLine _
                     & "Add about button" & vbNewLine _
                     & "Publish Application" & vbNewLine _
                     & "Add more encryption methods" & vbNewLine _
                     & "Label encryptions methods acording to strength" & vbNewLine _
                     & "Add pictures for easier navigation" & vbNewLine _
                     & "Add icons" & vbNewLine _
                     & "" & vbNewLine _
                     & "" & vbNewLine _
                     & "" & vbNewLine _
                     & "" & vbNewLine _
                     & "==End==" & vbNewLine _
                     )


        Return Changelog
    End Function
#End Region

    Private Sub cboxHideChars_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboxHideChars.CheckedChanged
        If cboxHideChars.Checked = True Then
            TextBox1.PasswordChar = "*"
            TextBox1.UseSystemPasswordChar = False
            
        Else
            TextBox1.UseSystemPasswordChar = True
            
        End If
    End Sub

    Private Sub btnSelAllEncrypt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelAllEncrypt.Click
        TextBox1.Focus()
        TextBox1.SelectAll()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Focus()
        TextBox2.SelectAll()
    End Sub

    Private Sub btnSwap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSwap.Click
        Dim text1 As String = TextBox1.Text
        Dim text2 As String = TextBox2.Text

        TextBox1.Text = text2
        TextBox2.Text = text1

    End Sub
#End Region

#Region "Options Panel"
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If RbtnMethod1.Checked = True Then
            Method = 1
        ElseIf RbtnMethod2.Checked = True Then
            Method = 2
        ElseIf RbtnMethod3.Checked = True Then
            Method = 3
        End If

        If Method = 3 Then
            lblMethod3.Visible = True
            boxMethod3Key.Visible = True
        Else
            lblMethod3.Visible = False
            boxMethod3Key.Visible = False
        End If
        PnlMain.BringToFront()

    End Sub
#End Region
End Class

Public NotInheritable Class Simple3Des
    Private TripleDes As New TripleDESCryptoServiceProvider

    Private Function TruncateHash( _
    ByVal key As String, _
    ByVal length As Integer) _
    As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider

        ' Hash the key.
        Dim keyBytes() As Byte = _
            System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)

        ' Truncate or pad the hash.
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Sub New(ByVal key As String)
        ' Initialize the crypto provider.
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    Public Function EncryptData( _
    ByVal plaintext As String) _
    As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte = _
            System.Text.Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms, _
            TripleDes.CreateEncryptor(), _
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function DecryptData( _
    ByVal encryptedtext As String) _
    As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New System.IO.MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms, _
            TripleDes.CreateDecryptor(), _
            System.Security.Cryptography.CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function


End Class


