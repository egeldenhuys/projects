Imports System.IO

' TODO
' http://www.freebsd.org/cgi/cvsweb.cgi/src/share/dict/web2?rev=1.12.22.1;content-type=text%2Fplain

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        txtOut.Text = ""
        txtWords.Text = ""

        Dim inputString As String = txtInput.Text
        Dim items(inputString.Length - 1) As String
        Dim length As Integer = CInt(txtLength.Text)
        Dim permutations As New List(Of String)

        For i As Integer = 0 To inputString.Length - 1
            items(i) = inputString(i)
        Next

        Dim permsObj As New PermutationObject(items)
        'lblPerms.Text = "Permutions: " & permsObj.GetPermutationsCount(length)
        permutations = permsObj.GetPermutations(length)

        For Each element In permutations
            txtOut.AppendText(element & Environment.NewLine)
            Application.DoEvents()
        Next

        If chkReturnWords.Checked = True Then
            ' Load Words
            Dim reader As New System.IO.StreamReader("Words.txt")
            Dim words As New List(Of String)
            Dim counter As Integer = 0

            While reader.Peek <> -1
                words.Add(reader.ReadLine)
                counter += 1
            End While

            reader.Close()
            Debug.WriteLine("Words have been loaded")
            txtWords.AppendText("Starting..." & Environment.NewLine)

            For Each element In permutations
                If words.Contains(element) Then
                    txtWords.AppendText(element & Environment.NewLine)
                End If
            Next

            'For i As Integer = 0 To permutations.Count - 1

            '    ' Compare the permution against all the words.
            '    For x As Integer = 0 To words.GetUpperBound(0)
            '        If permutations.Item(i).ToLower = words(x).ToLower Then
            '            txtWords.AppendText(permutations.Item(i) & Environment.NewLine)
            '            Exit For
            '        End If
            '    Next

            '    Application.DoEvents()
            'Next

            txtWords.AppendText("Finished..." & Environment.NewLine)
        End If

    End Sub
End Class

Public Class PermutationObject
    Private Items() As String

    Public Sub New(ByVal theItems() As String)
        Items = theItems
    End Sub

    Public Function GetPermutations(ByVal length As Integer) As List(Of String)
        Dim maxID As Integer = Items.GetUpperBound(0)


        Return SharedPermutations.GetPermutations(Items, length)
    End Function

    Public Function GetPermutationsCount(ByVal length As Integer) As Integer
        Return SharedPermutations.GetPermutionsCount(Items.GetUpperBound(0) + 1, length)
    End Function
End Class

Public Class SharedPermutations
    ''' <summary>
    ''' Returns the number of permutions based on the given values
    ''' </summary>
    ''' <param name="typesToChoose">How many items there are to choose from.</param>
    ''' <param name="amountChosen">How many of these items are choosen.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPermutionsCount(ByVal typesToChoose As Integer, ByVal amountChosen As Integer) As Integer
        Dim result As Integer
        Dim a As ULong
        Dim b As ULong

        a = GetFactorial(typesToChoose)
        b = GetFactorial(typesToChoose - amountChosen)

        If b = 0 Then
            result = CInt(a)
        Else
            result = CInt(a / b)
        End If

        Return result
    End Function

    ''' <summary>
    ''' Returns all possible Permutations using the objects in the array.
    ''' </summary>
    ''' <param name="items">The array of items</param>
    ''' <param name="length">How long each combination should be</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPermutations(ByVal items() As String, ByVal length As Integer) As List(Of String)
        Form1.Label5.Text = "Started"
        Dim result As New List(Of String)
        Dim combination(length - 1) As Integer
        Dim allCombinationsFound As Boolean = False
        Dim combinationsDone As Integer = 0
        'Dim permutions As Integer
        Dim writer As New StreamWriter("out.txt")

        Dim firstCombo(length - 1) As Integer
        'qwertyuiopasdfghjklzxcvbnm1234567890 
        'permutions = GetPermutionsCount(items.GetUpperBound(0) + 1, length)

        ' set all elements in the combination to the first item
        For i As Integer = 0 To combination.GetUpperBound(0)
            combination(i) = 0
        Next

        ' set all elements in the combination to the first item
        For i As Integer = 0 To combination.GetUpperBound(0)
            firstCombo(i) = items.GetUpperBound(0)
        Next

        While allCombinationsFound = False
            ' Increase the combination
            combination = IncreaseCombination(combination, items.GetUpperBound(0))

            ' Check if there are collisions in the combination. i.e. {0, 0, 1} would return true
            '                                                        {0, 1, 2} would return false
            If ContainsCollision(combination) = False Then
                ' Add the combination to the list to be returned.
                'result.Add(CombinationToString(combination, items))
                'Form1.txtOut.AppendText( & vbNewLine)
                writer.WriteLine(CombinationToString(combination, items))
                'combinationsDone += 1
            End If

            ' Stop if all combinations have been found
            If SharedPermutations.CombinationToString(combination, items) = SharedPermutations.CombinationToString(firstCombo, items) Then
                allCombinationsFound = True
            End If

            Application.DoEvents()
        End While

        Form1.Label5.Text = "Done"

        writer.Close()

        Return result
    End Function

    ''' <summary>
    ''' Gets the factorial of the given number.
    ''' </summary>
    ''' <param name="number"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFactorial(ByVal number As Integer) As ULong
        ' In mathematics, the factorial of a non-negative integer n, 
        'denoted by n!, is the product of all positive integers less than or equal to n. For example,
        ' 5 ! = 5 * 4 * 3 * 2 * 1 = 120.

        ' If the number is 0 or below throw an exception
        If number < 0 Then
            Throw New Exception("Cannot return the factorial of " & number)
            Exit Function
        End If

        Dim result As ULong = CULng(number)

        For i As Integer = 1 To number - 1
            result *= (CULng(number) - CULng(i))
        Next

        Return result
    End Function

    ''' <summary>
    ''' Convert a combination ({0, 1, 5}) to a string representing the index.
    ''' </summary>
    ''' <param name="combination">The array of index to convert to a string</param>
    ''' <param name="items">The array of items in the combination.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CombinationToString(ByVal combination() As Integer, ByVal items() As String) As String
        Dim result As String = ""

        ' combination(0) represents the first item in the items() array
        For i = 0 To combination.GetUpperBound(0)
            result &= items(combination(i))
        Next

        Return result
    End Function

    ''' <summary>
    ''' Checks if there are more than one of an element in the array. Returns true if there are.
    ''' </summary>
    ''' <param name="combination"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ContainsCollision(ByVal combination() As Integer) As Boolean
        Dim result As Boolean = False
        Dim checkedList As New List(Of Integer)

        ' Add the first id to checked array
        checkedList.Add(combination(0))

        ' Add other characters to checked array if they have not been added yet
        ' If they do exist in the array exit loop and return true
        ' If all characters have been added and loop has not yet been exited return false

        ' Start as 1 because we already added the first character
        For i As Integer = 1 To combination.GetUpperBound(0)
            ' Check if the CheckedList contains the next ID in the combinations array
            If checkedList.Contains(combination(i)) Then
                result = True
                Exit For
            Else
                ' Add the checked ID to the checked list
                checkedList.Add(combination(i))
            End If
        Next


        Dim combinationString As String = ""

        For Each element As Integer In combination
            combinationString &= element & ", "
        Next

        'Debug.WriteLine("The combination " & combinationString & " contained collisions: " & result)


        Return result
    End Function

    ''' <summary>
    ''' Increases the given combination. {0, 0, 0}, 3 Will return {0, 0, 1}. {0, 0, 3} will return {0, 1, 0}
    ''' </summary>
    ''' <param name="combination">The array of IDs to increase</param>
    ''' <param name="maxID">The highest ID</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IncreaseCombination(ByVal combination() As Integer, ByVal maxID As Integer) As Integer()
        ' This function works exactly like a odometer.

        ' Given the maxID is 5
        ' Combination = {0, 0, 0}
        ' 0, 0, 0
        ' 0, 0, 1...
        ' 0, 0, 5
        ' 5 is the highest allowed value. Set it to 0 and increase the item before it
        ' 0, 1, 0...
        ' 0, 5, 5
        ' 5 is the highest allowed value. Set it to 0 and increase the number before it.
        ' 0, 5, 0
        ' The number before it is the highest allowed value. Set it to 0 and increase the number before it.
        ' 1, 0, 0
        ' 1, 0, 1...
        ' 5, 5, 5
        ' -> 5, 5, 0
        ' -> 5, 0, 0
        ' -> 0, 0, 0
        ' There does not exist and item before the first 0.



        ' lastItem is the last item of the array
        Dim lastItem As Integer = combination.GetUpperBound(0)

        For i As Integer = 0 To combination.GetUpperBound(0)
            ' If x <> maxID then increase x. {0, 0, x} or {0, x, 0} etc.
            If combination(lastItem - i) <> maxID Then
                combination(lastItem - i) += 1
                ' We can exit the loop now because we have increased the combination
                Exit For
            Else ' if x = maxID then
                ' Set the item after x to 0. {0, x, 3} becomes {0, x, 0}
                combination(lastItem - i) = 0
                ' If there exists an item before x then continue
                If (lastItem - 1 - i) <> -1 Then
                    ' If the item before x is not the max, increase it.
                    If combination(lastItem - 1 - i) <> maxID Then
                        combination(lastItem - 1 - i) += 1
                        Exit For
                    End If
                End If
            End If
        Next

        Return combination
    End Function

End Class
