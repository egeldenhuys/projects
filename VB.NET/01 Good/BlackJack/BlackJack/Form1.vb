Public Class Form1

    Dim cards(54) As Card
    Dim counter As Integer = 0
    Dim playerCards As New List(Of Card)
    Dim dealerCards As New List(Of Card)
    Dim playerSlots(4) As PictureBox

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ' Add pictureboxes to array for easy access
        playerSlots(0) = pbP1
        playerSlots(1) = pbP2
        playerSlots(2) = pbP3
        playerSlots(3) = pbP4
        playerSlots(4) = pbP5

        LoadCards()
        
        HitPlayer()
        HitPlayer()

    End Sub

    Private Sub HitPlayer()
        Append("Hitting Player")
        playerCards.Add(RandomCard())
        RenderPlayerCards()
        CheckPlayerCards()
    End Sub

    Private Sub btnHit_Click(sender As System.Object, e As System.EventArgs) Handles btnHit.Click
        HitPlayer()
    End Sub

    Private Sub btnStand_Click(sender As System.Object, e As System.EventArgs) Handles btnStand.Click

    End Sub

    Private Sub btnInitialize_Click(sender As System.Object, e As System.EventArgs) Handles btnInitialize.Click
        LoadCards()

    End Sub

    Private Sub btnRnd_Click(sender As System.Object, e As System.EventArgs) Handles btnRnd.Click

        pbP1.Image = RandomCard().cardImage
        pbP2.Image = RandomCard().cardImage
        pbP3.Image = RandomCard().cardImage
        pbP4.Image = RandomCard().cardImage
        pbP5.Image = RandomCard().cardImage

        pbD1.Image = RandomCard().cardImage
        pbD2.Image = RandomCard().cardImage
        pbD3.Image = RandomCard().cardImage
        pbD4.Image = RandomCard().cardImage
        pbD5.Image = RandomCard().cardImage

    End Sub

    Private Sub RenderPlayerCards()

        Append("Rendering player cards")

        For i As Integer = 0 To playerCards.Count - 1
            playerSlots(i).Image = playerCards.Item(i).cardImage
        Next

    End Sub

    Private Function RandomCard() As Card

        Append("Getting a random card from the deck")

        Randomize()

        Dim cardNum As Integer = CInt(Rnd() * 51)

        Return cards(cardNum)

    End Function

    Private Sub CheckPlayerCards()

        Dim sum As Integer = 0

        For i As Integer = 0 To playerCards.Count - 1
            sum += playerCards.Item(i).cardValue
        Next

        Append("sum: " & sum)

    End Sub

    Private Sub LoadCards()
        ' This function will load the cards from a single image into an array of bitmaps

        Append("Loading cards...")

        ' Load the main image from the Resources
        Dim allCards As New Bitmap(My.Resources.AllCards)

        ' Card dimensions
        Dim cardWidth As Integer = 79
        Dim cardHeigth As Integer = 123

        ' padding is the space between cards
        Dim paddingX As Integer = 0
        Dim paddingY As Integer = 0

        Dim initialPaddingX As Integer = 0
        Dim initialPaddingY As Integer = 0

        ' Create the temporary card
        Dim tmpCard As New Bitmap(cardWidth, cardHeigth)

        Dim offsetX As Integer = 0
        Dim offsetY As Integer = 0

        Dim cardDone As Integer = 0

        Dim tmpImage As Bitmap
        Dim tmpValue As Integer

        ' Get the image of each card from the image containing all the cards.
        For i As Integer = 0 To cards.GetUpperBound(0)
            ' Assign card image
            tmpImage = GetBlock(allCards, _
                                (offsetX + initialPaddingX), _
                                (offsetY + initialPaddingY), _
                                (offsetX + cardWidth + initialPaddingX), _
                                (offsetY + cardHeigth + initialPaddingY))

            ' Increase offsets
            offsetX += cardWidth + paddingX
            cardDone += 1

            ' Assign card value

            If cardDone >= 10 Then

                tmpValue = 10
            Else
                tmpValue = cardDone
            End If

            ' End of col
            If cardDone = 13 Then
                ' next row
                offsetY += cardHeigth + paddingY
                ' first col
                offsetX = 0

                cardDone = 0
            End If

            

            ' Create card
            cards(i) = New Card(tmpImage, tmpValue)

        Next

        ' Set the last 3 cards's value to -1.
        cards(54).cardValue = -1
        cards(53).cardValue = -1
        cards(52).cardValue = -1

        Append("Cards loaded.")
    End Sub

    Private Function GetBlock(ByRef mainImage As Bitmap, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer) As Bitmap

        ' Create the bitmap. Not 0 based
        Dim result As New Bitmap(x2 - x1, y2 - y1)

        ' The count is the position to place the new pixel
        Dim xCount As Integer = 0
        Dim yCount As Integer = 0



        For x As Integer = x1 To x2 - 1 Step 1
            For y As Integer = y1 To y2 - 1 Step 1
                ' Get the pixel from the main image and add it to the new image. 0 Based.
                Try
                    Dim pixel As Color = mainImage.GetPixel(x, y)

                    Try
                        result.SetPixel(xCount, yCount, pixel)
                    Catch ex As Exception
                        Append("2: " & ex.Message)
                        Exit For
                    End Try

                Catch ex As Exception
                    Append("1: " & ex.Message)
                    Exit For
                End Try


                yCount += 1
            Next

            ' Go to the next column, therefore we reset y
            xCount += 1
            yCount = 0
        Next


        Return result

    End Function

    Private Sub Append(ByRef text As String)
        txtConsole.AppendText(text & Environment.NewLine)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        pbD1.Image = cards(counter).cardImage
        counter += 1
    End Sub


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class

Public Class Card

    Public cardImage As Bitmap
    Public cardValue As Integer

    Public Sub New(ByVal carBitmap As Bitmap, ByVal cardVal As Integer)
        cardImage = carBitmap
        cardValue = cardVal

    End Sub

End Class
