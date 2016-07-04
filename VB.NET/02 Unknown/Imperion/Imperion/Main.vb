Public Class Main
    Dim Metal, Crystal, Tritium As Integer
    Dim btnMetal_Selected, btnCrystal_Selected, btnTritium_Selected As Boolean
    Dim Level(15) As Integer
    Dim i As Integer

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblStatus.Text = ""
    End Sub

    Private Sub btnM_Mine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM_Mine.Click
        btnMetal_Selected = True
        lblStatus.Text = "Click an Empty slot to build a Metal Mine"
    End Sub

    Private Sub Slot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Slot1.Click,
        Slot2.Click, Slot3.Click, Slot4.Click, Slot5.Click, Slot6.Click, Slot7.Click, Slot8.Click, Slot9.Click,
        Slot10.Click, Slot11.Click, Slot12.Click, Slot13.Click, Slot14.Click, Slot15.Click
        i += 1
        If btnMetal_Selected = True Then
            If sender.Text = "Empty" Then
                Dim Level(i) As Integer
                Level(i) = 1
                sender.Text = "Metal Mine" & vbNewLine & "Level " & Level(i)
                btnMetal_Selected = False
                lblStatus.Text = ""
            End If
        ElseIf btnCrystal_Selected = True Then
            If sender.Text = "Empty" Then
                Level(i) = 1
                sender.Text = "Crystal Mine" & vbNewLine & "Level " & Level(i)
                btnCrystal_Selected = False
                lblStatus.Text = ""
            End If
        ElseIf btnTritium_Selected = True Then
            If sender.Text = "Empty" Then
                Level(i) = 1
                sender.Text = "Tritium Mine" & vbNewLine & "Level " & Level(i)
                btnTritium_Selected = False
                lblStatus.Text = ""
            End If
        End If
    End Sub

    Private Sub btnC_Mine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnC_Mine.Click
        btnCrystal_Selected = True
        lblStatus.Text = "Click an Empty slot to build a Crystal Mine"
    End Sub

    Private Sub btnT_Mine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnT_Mine.Click
        btnTritium_Selected = True
        lblStatus.Text = "Click an Empty slot to biuld a Tritium Mine"
    End Sub

    Private Sub btnUpgrade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpgrade.Click
        i = 1
        Level(i) = 5
    End Sub

End Class
