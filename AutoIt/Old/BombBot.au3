#cs ----------------------------------------------------------------------------

	AutoIt Version: 3.3.9.0 (beta)
	Author:         myName

	Script Function:
	A collection of functions for RuneScape

#ce ----------------------------------------------------------------------------

#cs
	TODO:

#ce
Global $iGameX
Global $iGameY

_BombBot_FindGame($iGameX, $iGameY, 1)
MsgBox(0, "", $iGameX & ", " & $iGameY)

Func _BombBot_Bank_DepositAll($iGameX, $iGameY, $iMouseSpeed)

	If _BombBot_Bank_IsOpen($iGameX, $iGameY) = True Then
		MouseClick("left", $iGameX + 370, $iGameY + 309, 1, $iMouseSpeed)
	Else
		SetError(1)
	EndIf

EndFunc   ;==>_BombBot_Bank_DepositAll

Func _BombBot_Bank_Withdraw($iGameX, $iGameY, $iMouseSpeed, $iSlot, $iAmount, $iSleep)
	If $iSlot = 1 Then
		MouseClick("right", $iGameX + 53, $iGameY + 105, 1, $iMouseSpeed)
		Local $iaMousePos = MouseGetPos()
		_BombBot_WaitForColour($iaMousePos[0], $iaMousePos[1] + 1, 0xFFFFFF, 0, 2000, $iSleep)
		If Not @error Then
			If $iAmount = "all" Then
				_BombBot_Mouse_ClickRelative("left", 0, 108, $iMouseSpeed)
			EndIf
		Else
			SetError(1)
		EndIf
	EndIf
EndFunc   ;==>_BombBot_Bank_Withdraw

Func _BombBot_Bank_SelectTab($iGameX, $iGameY, $iTab, $iMouseSpeed)
	If _BombBot_Bank_IsOpen($iGameX, $iGameY) = True Then
		Select
			Case $iTab = 1
				MouseClick("left", $iGameX + 95, $iGameY + 64, 1, $iMouseSpeed)
		EndSelect
	Else
		SetError(1)
	EndIf
EndFunc   ;==>_BombBot_Bank_SelectTab

Func _BombBot_Bank_IsOpen($iGameX, $iGameY)
	; Orange Bank of Runescape text
	If PixelGetColor($iGameX + 198, $iGameY + 32) = 0xF2AA3E Then
		Return True
	Else
		Return False
	EndIf
EndFunc   ;==>_BombBot_Bank_IsOpen

Func _BombBot_Bank_Close($iGameX, $iGameY, $iMouseSpeed)
	If _BombBot_Bank_IsOpen($iGameX, $iGameY) = True Then
		MouseClick("left", $iGameX + 488, $iGameY + 34, 1, $iMouseSpeed)
	Else
		SetError(1)
	EndIf
EndFunc   ;==>_BombBot_Bank_Close

Func _BombBot_Mouse_MoveRelative($iX, $iY, $iMouseSpeed)
	Local $aiMousePos = MouseGetPos()
	MouseMove($aiMousePos[0] + $iX, $aiMousePos[1] + $iY, $iMouseSpeed)
EndFunc   ;==>_BombBot_Mouse_MoveRelative

Func _BombBot_Mouse_ClickRelative($sButton, $iX, $iY, $iMouseSpeed)
	Local $aiMousePos = MouseGetPos()
	MouseClick($sButton, $aiMousePos[0] + $iX, $aiMousePos[1] + $iY, 1, $iMouseSpeed)
EndFunc   ;==>_BombBot_Mouse_ClickRelative

Func _BombBot_WaitForColour($iX, $iY, $iColour, $iTolerance, $iTimeOut, $iSleep)
	Local $hStartTime = TimerInit()

	While (TimerDiff($hStartTime) < $iTimeOut)
		PixelSearch($iX, $iY, $iX, $iY, $iColour, $iTolerance)
		If Not @error Then
			ExitLoop 1
		EndIf

		Sleep($iSleep)
	WEnd

	If TimerDiff($hStartTime) > $iTimeOut Then
		SetError(1)
	EndIf

EndFunc   ;==>_BombBot_WaitForColour

Func _BombBot_WaitForMenu($iGameX, $iGameY, $iTimeOut, $iSleep)
	Local $aiMousePos = MouseGetPos()
	_BombBot_WaitForColour($aiMousePos[0], $aiMousePos[1] + 1, 0xFFFFFF, 0, $iTimeOut, $iSleep)
	If Not @error Then
	Else
		SetError(1)
	EndIf
EndFunc   ;==>_BombBot_WaitForMenu

Func _BombBot_FindGame(ByRef $iGameXvar, ByRef $iGameYvar, $iBorder)

	Local $iX = 0
	Local $iY = 0
	Local $iWidth = @DesktopWidth
	Local $iHeight = @DesktopHeight

	Select
		Case $iBorder = 1
			Do
				Consolewrite($ix & ", " & $iy & @CRLF)
				$aiLocation = PixelSearch($iX, $iY, $iWidth, $iY, 0x000001) ; Top left Corner

				If Not @error Then
					If PixelGetColor($aiLocation[0] + 763, $aiLocation[1] + 501) = 0x7C7B7A Then ; Bottom Right corner
						$iGameXvar = $aiLocation[0]
						$iGameYvar = $aiLocation[1]
						ExitLoop 1
					Else
						$iX = $aiLocation[1] + 1
					EndIf
				Else
					$iY += 1
					$iX = 0
					SetError(1)
				EndIf

			Until $iY = $iHeight

		Case $iBorder = 2
			Do
				$aiLocation = PixelSearch($iX, $iY, $iWidth, $iY, 0x221C0D)

				If Not @error Then
					If PixelGetColor($aiLocation[0] + 764, $aiLocation[1] + 502) = 0x282419 Then
						$iGameXvar = $aiLocation[0]
						$iGameYvar = $aiLocation[1]
						ExitLoop 1
					Else
						$iX = $aiLocation[1]
					EndIf
				Else
					$iY += 1
					$iX = 0
					SetError(1)
				EndIf
			Until $iY = $iHeight
	EndSelect



	#cs
		$aiLocation = PixelSearch(0, 0, @DesktopWidth, @DesktopHeight, 0x221C0D)
		If Not @error Then
		If PixelGetColor($aiLocation[0], $aiLocation[1] + 3) = 0x39331B Then
		$iGameXvar = $aiLocation[0]
		$iGameYvar = $aiLocation[1]
		EndIf
		Else
		SetError(1)
		EndIf
	#ce



EndFunc   ;==>_BombBot_FindGame



