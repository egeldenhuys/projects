Public Class Form1
    Dim i As Integer
    Dim Counter() As Integer
    Dim Items() As String
    Dim Item As String
    Dim Done As Boolean = False
    Dim a As Integer
    Dim FirstDone As Boolean = False
    Dim TotalItems As Integer = 0
    Dim Found As Boolean
    Dim substrings(1) As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        i = 1
        lblChance.Text = ""
        ReDim Items(0 To 0)
        ReDim Counter(0 To 0)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddItem()

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ListBox1.Items.Clear()
        i = 1
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        a = 0
        Item = ListBox1.SelectedItem.ToString
        Item = Item.ToLower()
        substrings = Item.Split(".")
        substrings(1) = substrings(1).Trim()
        Found = False
        Do While Found = False
            If substrings(1) = Items(a) Then
                lblChance.Text = Math.Round((Counter(a) / TotalItems * 100), 2) & "%"
                Found = True
            End If
            a += 1
        Loop
    End Sub

    Private Sub boxAddDrop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boxAddDrop.Click
        boxAddDrop.SelectAll()
    End Sub

    Private Sub boxAddDrop_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles boxAddDrop.KeyDown
        If e.KeyValue = Keys.Enter Then
            e.SuppressKeyPress = True
            AddItem()
            boxAddDrop.SelectAll()
        End If
    End Sub

    Private Sub AddItem()
        ListBox1.Items.Add(i & ". " & boxAddDrop.Text)
        Item = boxAddDrop.Text.ToLower
        a = 0
        Done = False
        Do While Done = False
            If Item = Items(a) Then
                Counter(a) += 1
                Done = True
            Else
                If a = Items.GetUpperBound(0) Then
                    If FirstDone = True Then
                        FirstDone = False
                        a += 1
                    End If
                    ReDim Preserve Items(0 To a)
                    ReDim Preserve Counter(0 To a)
                    Items(a) = Item
                    Counter(a) += 1
                    Done = True
                    FirstDone = True
                End If
            End If
            a += 1
        Loop
        TotalItems += 1
        i += 1
        boxAddDrop.AutoCompleteCustomSource.Add(Item)
    End Sub

    Private Sub btnSet1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet5.Click, btnSet4.Click, btnSet3.Click, btnSet2.Click, btnSet1.Click
        If sender.text = boxAddDrop.Text Then
            Item = boxAddDrop.Text.ToLower
            AddItem()
        Else
            sender.text = boxAddDrop.Text
        End If



    End Sub
End Class
