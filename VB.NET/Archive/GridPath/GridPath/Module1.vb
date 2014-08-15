Module Module1

    Dim grid(9, 9) As Integer
    ' Row, Column

    Dim map(9) As String


    Sub Main()

        ' Initialize program

        LoadMap()
        grid = ConvertToGrid(map)
        PrintGrid(grid)

        GetPath(grid)


        ' Get points
        Dim tmp(,) As Integer
        Dim p(1) As Integer
        p = GetPlayerPoint(grid)

        tmp = GetOpenPoints(p, grid)

        For i As Integer = 0 To tmp.GetUpperBound(0)
            If tmp(i, 0) <> -1 Then
                Console.WriteLine(tmp(i, 0) & ", " & tmp(i, 1))
            End If
        Next

        Console.WriteLine()

        PrintGrid(grid)

        For i As Integer = 0 To tmp.GetUpperBound(0)
            If tmp(i, 0) <> -1 Then
                Console.SetCursorPosition(tmp(i, 1), tmp(i, 0))
                Console.Write("X")
            End If

        Next

        'Console.ReadKey()

        'Dim traveledPoints


        Console.ReadKey()

    End Sub

    Private Sub PrintGrid(ByVal numberGrid(,) As Integer)

        For row As Integer = 0 To numberGrid.GetUpperBound(0)

            For col As Integer = 0 To numberGrid.GetUpperBound(0)
                Console.Write(numberGrid(row, col))
            Next
            Console.WriteLine()
        Next

    End Sub

    Private Sub LoadMap()

        map(0) = "1 1 1 1 1 1 1 1 1 1"
        map(1) = "1 2 0 0 0 0 0 3 1 1"
        map(2) = "1 0 1 1 0 1 1 1 1 1"
        map(3) = "1 0 1 1 0 1 1 1 1 1"
        map(4) = "1 0 1 1 0 1 1 1 1 1"
        map(5) = "1 0 1 1 0 1 1 1 1 1"
        map(6) = "1 0 1 1 0 1 1 1 1 1"
        map(7) = "1 0 0 0 0 1 0 0 0 1"
        map(8) = "1 1 1 1 1 1 0 0 0 1"
        map(9) = "1 1 1 1 1 1 1 0 0 0"

        ' Single Path

        ' Loop Start
        ' Get open points around current position, ignore the previous position
        ' Set the curent position to the first open point.
        ' if the current position has a valus of "3", end.
        ' Loop End

        ' Multiple paths
        ' Set the current position as the player pos

        ' Loop Start
        ' Get open points around current position
        ' Save the current position as a choice
        ' Take the first open point of the choice
        ' Continue until dead end, goal or new choice
        ' Loop End


        ' Loop until done
        ' Loop until all choices done
        ' Loop until dead end or path found

    End Sub

    Private Function ConvertToGrid(ByVal map() As String) As Integer(,)
        Dim result(9, 9) As Integer
        Dim subStrings() As String

        For i As Integer = 0 To map.GetUpperBound(0)
            ' Split map string into individial points
            subStrings = Split(map(i), " ")

            ' Load the points into the grid
            For x As Integer = 0 To map.GetUpperBound(0)
                result(i, x) = CInt(subStrings(x))
            Next
        Next

        Return result
    End Function

    ' Player position - Row, Column
    Private Function GetOpenPoints(ByVal playerPoint() As Integer, ByVal numberGrid(,) As Integer) As Integer(,)
        Dim tmpResult(3, 1) As Integer

        ' Fill the tmpResult with "-1"

        For r As Integer = 0 To 3
            For c As Integer = 0 To 1
                tmpResult(r, c) = -1
            Next
        Next

        Dim count As Integer = 0
        Dim rowOffet As Integer = 0
        Dim colOffset As Integer = 0

        Dim safe As Boolean = False

        ' Prioritize the order in which points are returned.
        For i As Integer = 0 To 3

            Select Case i

                Case 0 ' Top
                    rowOffet = -1
                    colOffset = 0


                    If playerPoint(0) > 0 Then
                        safe = True
                    End If

                Case 1 ' Right
                    rowOffet = 0
                    colOffset = 1


                    If playerPoint(1) < numberGrid.GetUpperBound(1) Then
                        safe = True
                    End If

                Case 2 ' Bottom
                    rowOffet = 1
                    colOffset = 0


                    If playerPoint(0) < numberGrid.GetUpperBound(0) Then
                        safe = True
                    End If


                Case 3 ' Left
                    rowOffet = 0
                    colOffset = -1

                    If playerPoint(1) > 0 Then
                        safe = True
                    End If

            End Select


            If safe = True Then

                If numberGrid(playerPoint(0) + rowOffet, playerPoint(1) + colOffset) = 0 Then
                    tmpResult(count, 0) = (playerPoint(0) + rowOffet)
                    tmpResult(count, 1) = (playerPoint(1) + colOffset)
                Else
                    tmpResult(count, 0) = (-1)
                    tmpResult(count, 1) = (-1)
                End If

                count += 1
            End If

            safe = False
        Next


        ' Count how many open points were found, used in creasting the final result.
        Dim openPoints As Integer = 0

        For r As Integer = 0 To 3
            If tmpResult(r, 0) <> -1 Then
                openPoints += 1
            End If
        Next

        ' Create the final result
        Dim result(openPoints - 1, 1) As Integer

        Dim filled As Integer = 0

        ' Filter out invalid points (-1) and add the valid points to the final result

        For r As Integer = 0 To 3
            If tmpResult(r, 0) <> -1 Then
                result(filled, 0) = tmpResult(r, 0)
                result(filled, 1) = tmpResult(r, 1)
                filled += 1
            End If
        Next

        Return result

    End Function

    Private Function GetPath(ByVal numbergrid(,) As Integer) As Integer(,)

        Dim choices(0, 1) As Integer
        Dim choiceCount As Integer = 0
        Dim currentPos(1) As Integer
        Dim walkedPath(0, 1) As Integer

        ' Get player point
        Dim player(1) As Integer
        player = GetPlayerPoint(numbergrid)

        ' Set the current postion to the player position
        currentPos(0) = player(0)
        currentPos(1) = player(1)


        ' Get open points around player
        Dim openPoints(,) As Integer
        openPoints = GetOpenPoints(currentPos, numbergrid)

        ' If there are more than 1 point save the current position as a choice.
        If openPoints.GetUpperBound(0) > 1 Then
            ReDim Preserve choices(choiceCount, 1)
            choices(choiceCount, 0) = currentPos(0)
            choices(choiceCount, 1) = currentPos(1)

            choiceCount += 1
        End If

        ' Take the first open point
        currentPos(0) = choices(choiceCount, 0)
        currentPos(1) = choices(choiceCount, 1)

    End Function

    Private Function GetPlayerPoint(ByVal numberGrid(,) As Integer) As Integer()

        Dim player(1) As Integer

        ' Loop throught the 2D array to find "2"
        For r As Integer = 0 To numberGrid.GetUpperBound(0)
            For c As Integer = 0 To numberGrid.GetUpperBound(1)
                If numberGrid(r, c) = 2 Then
                    player(0) = r
                    player(1) = c
                End If
            Next
        Next

        Return player
    End Function

    ' Get player position
    ' Get open points
    ' If there are more than 1 point save the current point as a choice.
    ' move to the first open point.
    ' Get open points
    ' if there are more than 1 open points save the current point as a choice
    ' if there are 0 points Go to previous choice



    ' Get player position

    ' Get open points
    ' If more than 1 open point save the current player position in the choice array
    ' Move to the first open point.
    ' Save the current position and do not check it again.
End Module
