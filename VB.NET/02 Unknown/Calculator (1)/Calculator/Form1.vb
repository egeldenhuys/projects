Imports System.IO

Public Class Form1

    Dim num1, num2 As Single
    Dim operation As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadList()

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        SaveList()

    End Sub

    Private Sub Number_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        txtOutput.Text = txtOutput.Text & sender.text
        lblErr.Visible = False

    End Sub

    Private Sub Operator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSub.Click, btnMul.Click, btnAdd.Click, btnDiv.Click

        If txtOutput.Text = "" Then
            lblErr.Text = "Please enter a number!"
            lblErr.Visible = True
        Else
            num1 = txtOutput.Text
            operation = sender.text
            txtOutput.Text = ""
        End If
        

    End Sub

    Private Sub btnEqual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEqual.Click

        If txtOutput.Text = "" Then
            lblErr.Text = "Please enter a number"
            lblErr.Visible = True

        Else

            num2 = txtOutput.Text

            Select Case operation
                Case "+"
                    txtOutput.Text = num1 + num2
                    lstHistory.Items.Add(num1 & operation & num2 & "=" & (num1 + num2))

                Case "-"
                    txtOutput.Text = num1 - num2
                    lstHistory.Items.Add(num1 & operation & num2 & "=" & (num1 - num2))

                Case "*"
                    txtOutput.Text = num1 * num2
                    lstHistory.Items.Add(num1 & operation & num2 & "=" & (num1 * num2))

                Case "/"

                    If num2 = 0 Then
                        lblErr.Text = "Cannot divide by 0!"
                        lblErr.Visible = True
                    Else
                        txtOutput.Text = num1 / num2
                        lstHistory.Items.Add(num1 & operation & num2 & "=" & (num1 / num2))
                    End If


            End Select

        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtOutput.Text = ""
    End Sub

    Private Sub btnRoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRoot.Click

        If txtOutput.Text = "" Then
            lblErr.Text = "Please enter a number!"
            lblErr.Visible = True
        Else

            num1 = txtOutput.Text
            num2 = Math.Sqrt(num1)
            txtOutput.Text = num2
            lstHistory.Items.Add("Sqrt(" & num1 & ")" & "=" & num2)

        End If

        

    End Sub

    Private Sub SaveList()

        Dim writer As New StreamWriter("History.txt")

        For i As Integer = 0 To lstHistory.Items.Count - 1

            writer.WriteLine(lstHistory.Items(i))
        Next

        writer.Close()


    End Sub

    Private Sub LoadList()

        If File.Exists("History.txt") = True Then

            Dim reader As New StreamReader("History.txt")

            While reader.Peek <> -1
                lstHistory.Items.Add(reader.ReadLine)
            End While

            reader.Close()

        End If

    End Sub

    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBin.Click

        txtOutput.Text = ConvertToBin(txtOutput.Text)


    End Sub

    Private Function ConvertToDec(ByVal bits As String) As Integer

        Dim counter As Integer = 0
        Dim input As String = txtOutput.Text
        Dim value As Integer = 1

        For i As Integer = 0 To input.Length - 2
            value = value * 2
        Next

        For i As Integer = 0 To input.Length - 1

            If input(i) = "1" Then
                counter += value
                value = value / 2

            Else
                value = value / 2
            End If

        Next


        Return counter

    End Function

    Private Function ConvertToBin(ByVal number As Integer) As String

        Bit()

        Return False

    End Function

    'Dim bits As New BitArray(Input.Length - 1)

    '    For i As Integer = 0 To input.Length - 1

    '        If input(i) = "1" Then
    '            bits.Set(i, True)

    '        Else
    '            bits.Set(i, False)
    '        End If
    '    Next

    'Dim bytes As Byte
    '    bits.

    Private Sub btnDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDec.Click

        txtOutput.Text = ConvertToDec(txtOutput.Text)

    End Sub
End Class
