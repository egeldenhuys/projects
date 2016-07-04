Imports System.Net
Imports System.IO

Public Class Form1
    Dim i As Integer
    Dim real As Single
    Dim a, b, c, d, _e, f, g As Integer
    Dim fake() As Integer
    Dim keyStep As Integer = 0
    Dim cStep As Integer = 0
    Dim _uri As String = "http://tg52c8a2ga.webs.com/Hack_Me.htm"
    Dim _Enabled As String
    Dim _version As String = "1.0.0.0"
    Dim _auth As String
    Dim _letterOrNum As Integer


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Download()
        lblPassword.Visible = False

        Randomize()
        i = CInt(Int(100 * Rnd()))
        real = i
        a = i
        b = i
        c = i
        d = i
        _e = i
        f = i
        g = i
        Label2.Text = CStr(i)

        ReDim fake(0 To 1000000)
        For t = 0 To 1000000
            fake(t) = i
        Next
        'Me.Focus()
        'Me.Refresh()
        Button1.Visible = True


        Me.Refresh()
        boxGuess.Focus()
        '48 57
        For y = 0 To 5
            _letterOrNum = Int(2 * Rnd() + 1)
            If _letterOrNum = 1 Then
                _auth = _auth & ChrW(Int(9 * Rnd() + 49))
            ElseIf _letterOrNum = 2 Then
                _auth = _auth & ChrW(Int(25 * Rnd() + 98))
            End If
        Next

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ChangeNum()
        boxGuess.Focus()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PictureBox1.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox2.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox3.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox4.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox5.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox6.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox7.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox8.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox9.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
        PictureBox10.Location = New Point(Int(340 * Rnd()), (188 * Rnd()))
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Button1.KeyDown

        If keyStep = 0 Then
            If e.KeyValue = Keys.C Then
                keyStep = 1
                Exit Sub
            Else
                keyStep = 0
            End If
        End If

        If keyStep = 1 Then
            If e.KeyValue = Keys.O Then
                keyStep = 2
                Exit Sub
            Else
                If e.KeyValue <> Keys.O Then
                    keyStep = 0
                End If

            End If
        End If

        If keyStep = 2 Then
            If e.KeyValue = Keys.R Then
                keyStep = 3
                Exit Sub
            Else
                If e.KeyValue <> Keys.R Then
                    keyStep = 0
                End If
            End If
        End If

        If keyStep = 3 Then
            If e.KeyValue = Keys.N Then
                keyStep = 4
            Else
                If e.KeyValue <> Keys.N Then
                    keyStep = 0
                End If
            End If
        End If

        If keyStep = 4 Then
            ShowCoins()
            Button1.Visible = False
            lblPassword.Visible = True
            Label1.Visible = False
            Label4.Visible = False
            Label2.Visible = False
            boxGuess.Visible = False
        End If
    End Sub

    Private Sub ShowCoins()
        PictureBox1.Visible = True
        PictureBox2.Visible = True
        PictureBox3.Visible = True
        PictureBox4.Visible = True
        PictureBox5.Visible = True
        PictureBox6.Visible = True
        PictureBox7.Visible = True
        PictureBox8.Visible = True
        PictureBox9.Visible = True
        PictureBox10.Visible = True
        Timer1.Enabled = True
    End Sub

    Private Sub TimerCheat_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCheat.Tick
        Select Case cStep
            Case 0
                lblC1.Visible = True
                cStep += 1
            Case 1
                lblC1.Visible = False
                lblC2.Visible = True
                cStep += 1
            Case 2
                lblC2.Visible = False
                lblC3.Visible = True
                cStep += 1
            Case 3
                lblC3.Visible = False
                lblC4.Visible = True
                cStep += 1
            Case 4
                lblC4.Visible = False
                cStep = 0
                TimerCheat.Enabled = False
        End Select


    End Sub

    Private Sub TimerMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMain.Tick
        TimerCheat.Enabled = True



    End Sub

    Private Sub boxGuess_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles boxGuess.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            ChangeNum()
        End If
    End Sub

    Private Sub ChangeNum()
        Me.Refresh()
        Label2.Text = real
        Label2.Refresh()
        If Label2.Text = "100" Then
            ShowCoins()
            Button1.Visible = False
            lblPassword.Visible = True
            Label1.Visible = False
            Label4.Visible = False
            Label2.Visible = False
            boxGuess.Visible = False
        Else
            i = Int(100 * Rnd())
            For t = 0 To 1000000
                fake(t) = i
            Next
            real = i
            Label2.Text = i
        End If

        Select Case boxGuess.Text.ToLower
            Case CStr(i)
                lblCode.Visible = True
                lblCode.Text = "::auth " & _auth
                ShowCoins()
                Button1.Visible = False
                lblPassword.Visible = True
                Label1.Visible = False
                Label4.Visible = False
                Label2.Visible = False
                boxGuess.Visible = False
            Case "corn"
                lblCode.Visible = True
                lblCode.Text = "::auth " & _auth
                ShowCoins()
                Button1.Visible = False
                lblPassword.Visible = True
                Label1.Visible = False
                Label4.Visible = False
                Label2.Visible = False
                boxGuess.Visible = False
            Case Else
                boxGuess.Text = ""
                boxGuess.SelectAll()
        End Select

    End Sub

    Private Sub Download()
        Dim _done As Boolean
        Dim client As New WebClient()
        Dim Substrings() As String
        ' Add a user agent header in case the 
        ' requested URI contains a query.
        client.Headers.Add("user-agent", "Mozilla/9.0.1 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
        Try
            Dim data As Stream = client.OpenRead(_uri)
        
        Dim reader As New StreamReader(Data)
        Dim _content As String
        
        Do While _done = False
            _content = reader.ReadLine()

            If _content.Contains("version") Then
                Substrings = Split(_content, ">")
                Substrings = Split(Substrings(1), "<")
                Substrings = Split(Substrings(0), ":")
                    If _version <> Substrings(1) Then
                        MsgBox("An update is available (" & Substrings(1) & ")")
                    End If

            End If

            If _content.Contains("enabled") Then
                Substrings = Split(_content, ">")
                Substrings = Split(Substrings(1), "<")
                Substrings = Split(Substrings(0), ":")
                _Enabled = Substrings(1)

            End If

            If _content.Contains("message") Then
                Substrings = Split(_content, ">")
                Substrings = Split(Substrings(1), "<")
                Substrings = Split(Substrings(0), ":")


            End If



            If _content.Contains("</HTML>") Then
                _done = True
            End If


        Loop

        Data.Close()
        reader.Close()

            If _Enabled = "False" Then
                MsgBox("You are not allowed to run this application")
                Me.Close()
            End If

        Catch ex1 As WebException
            MsgBox("You need to be connected to the internet to use this application")
            Me.Close()
        End Try
    End Sub

End Class
