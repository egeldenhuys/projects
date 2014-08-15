#cs ----------------------------------------------------------------------------
	
	AutoIt Version: 3.3.9.0 (beta)
	Author:         myName
	
	Script Function:
	A collection of functions for RuneScape
	
#ce ----------------------------------------------------------------------------

#cs ------------------------------ TODO: ---------------------------------------
	
	
	++ BombBot.au3 ++
	* Rename functions to be more consistant/appropriate
	* Add UDF Headers
	* Clean up code
	* Make code more efficient
	* Comment where needed
	* Work out good heading symbols (--- Heading ---) / {=== Heading ===)
	* Rename all instances of "BomBBot" to something simpler/better
	* Functions to identify what window is open (eg. bank, trade 1, trade 2, nothing etc..)
	
	++ Other ++
	* Create script to change all used coordinates to (eg. (150) -> ($iGameX + 50) )
	* Find new place to host website
	* Create complete Grid of runescape window (using multiple layers)
	* Intellisense
	* Documentation - Screenshot of what the script is looking for (pixels)
	
	++ Ideas ++
	* Changelog
	* GUI
	* Command que on website
	
	
	++ Tesseract ++
	* Individual statistics
	
	++ Inventory search method ++
	* Hover mouse and wait for uptext - could be used to identify if the slot is empty (slow)
	* use multiple points for each object like a DTM
	
#ce ----------------------------------------------------------------------------


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
				ConsoleWrite($iX & ", " & $iY & @CRLF)
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

Func _BombBot_Drop_FromMenu()

	#cs
		++ _BombBot_Drop_FromMenu TODO ++
		* Do a test for each first letter. (16px appart). Base position + X and Y offset.
		* Modify code to search down then up, this should make it able to drop any item
		* Possible parameter asking which D should be used
		* Create letters Grid and save to future use
	#ce

	Local $aiCurrentMousePos = MouseGetPos()
	Local $iOffsetX
	Local $iOffsetY
	Local $fDone = False
	Local $aiMenuLeft[2] ;Silver
	Local $a = PixelGetColor($aiCurrentMousePos[0], $aiCurrentMousePos[1] - 2)
	Local $iSearchesDone = 0
	Local $fDone2 = False
	Local $aiMatch1[2]
	Local $aiMatch2[2]

	ConsoleWrite("Mouse Pos = " & $aiCurrentMousePos[0] & ", " & $aiCurrentMousePos[1] & @CRLF)
	ConsoleWrite("Colour under mouse (x, y - 2) = " & $a & @CRLF)
	ConsoleWrite("Searching for Dark Colour at the top of the menu..." & @CRLF)

	PixelSearch($aiCurrentMousePos[0], $aiCurrentMousePos[1] + 2, $aiCurrentMousePos[0], $aiCurrentMousePos[1] + 2, 0x050504, 10) ; Search for menu
	If Not @error Then
		ConsoleWrite("Menu Found." & @CRLF)

		While $fDone = False
			ConsoleWrite("Searching for MenuLeft..." & @CRLF)

			$aiMenuLeft = PixelSearch($aiCurrentMousePos[0] - 200, $aiCurrentMousePos[1] + 2, $aiCurrentMousePos[0], $aiCurrentMousePos[1] + 2, 0xFDFDFD, 2) ; Search the the left silver
			If Not @error Then
				ConsoleWrite("MenuLeft was found at " & $aiMenuLeft[0] & ", " & $aiMenuLeft[1] & @CRLF)
				$fDone = True

			Else
				ConsoleWrite("MenuLeft was not found!" & @CRLF)
			EndIf
		WEnd
	Else
		ConsoleWrite("Menu was not found! Searching up..." & @CRLF)
		Local $iUpOffset = 0
		While $fDone2 = False
			If _BombBot_PixelSearch($aiCurrentMousePos[0], $aiCurrentMousePos[1] - $iUpOffset, 0x050504, 0) = 1 Then ; search 1 up
				$fDone2 = True
				While $fDone = False
					ConsoleWrite("Searching for MenuLeft..." & @CRLF)

					$aiMenuLeft = PixelSearch($aiCurrentMousePos[0] - 200, $aiCurrentMousePos[1] + 2, $aiCurrentMousePos[0], $aiCurrentMousePos[1] + 2, 0xFDFDFD, 2) ; Search the the left silver
					If Not @error Then
						ConsoleWrite("MenuLeft was found at " & $aiMenuLeft[0] & ", " & $aiMenuLeft[1] & @CRLF)
						$fDone = True

					Else
						ConsoleWrite("MenuLeft was not found!" & @CRLF)
					EndIf
				WEnd
			Else
				$iUpOffset += 1
			EndIf
		WEnd


	EndIf

	; Find "D"
	$fDone = False

	$iOffsetX = $aiMenuLeft[0]
	$iOffsetY = $aiMenuLeft[1] + 26 ; First letter



	; Letters are 16px appart

	ConsoleWrite("Searching for 'D'..." & @CRLF)
	While $fDone = False

		$aiMatch1[0] = $iOffsetX + 3
		$aiMatch1[1] = $iOffsetY + 4

		$aiMatch2[0] = $iOffsetX + 7
		$aiMatch2[1] = $iOffsetY + 3


		ConsoleWrite("Searching for match 1 at " & $aiMatch1[0] & ", " & $aiMatch1[1] & @CRLF)
		$iSearchesDone += 1
		If _BombBot_PixelSearch($aiMatch1[0], $aiMatch1[1], 0xA9A084, 20) = 1 Then ; Match 1

			ConsoleWrite("Match 1 found at " & $aiMatch1[0] & ", " & $aiMatch1[1] & @CRLF)
			ConsoleWrite("Searching for match 2 at " & $aiMatch2[0] & ", " & $aiMatch2[1] & @CRLF)
			$iSearchesDone += 1
			If _BombBot_PixelSearch($aiMatch2[0], $aiMatch2[1], 0xA9A084, 20) = 1 Then ; Match 2

				ConsoleWrite("Match 2 found at " & $aiMatch2[0] & ", " & $aiMatch2[1] & @CRLF)
				ConsoleWrite("Found the drop button" & @CRLF)

				MouseClick("left", $aiMatch1[0], $aiMatch1[1], 1, 2) ;TEST

				; MsgBox(0, "Found Drop Button", "'Drop' has been found!")
				$fDone = True
			EndIf
		EndIf

		If $iOffsetY > 1080 Then
			Exit 1
		EndIf
		$iOffsetY += 16

		ConsoleWrite("Searches Done = " & $iSearchesDone & @CRLF)
		; ConsoleWrite("Searched for 'D' at " & $iOffsetX & ", " & $iOffsetY & @CRLF)
	WEnd



EndFunc   ;==>_BombBot_Drop_FromMenu

Func _BombBot_PixelSearch($iX, $iY, $iColour, $iTolerance)
	PixelSearch($iX, $iY, $iX, $iY, $iColour, $iTolerance)
	If Not @error Then
		ConsoleWrite("Found #############" & @CRLF)
		Return 1
	Else
		ConsoleWrite("Not Found" & @CRLF)
		Return 0
	EndIf

EndFunc   ;==>_BombBot_PixelSearch

; #FUNCTION# ====================================================================================================================
; Name ..........: _BombBot_SelectOption
; Description ...:
; Syntax ........: _BombBot_SelectOption($iOption, $iMouseSpeed, $iTimeOut, $iSleep)
; Parameters ....: $iOption             - An integer value.
;                  $iMouseSpeed         - An integer value.
;                  $iTimeOut            - An integer value.
;                  $iSleep              - An integer value.
; Return values .: Sets @error to 1 if the colour could not be found within $iTimeOut
; Author ........: Your Name
; Modified ......:
; Remarks .......:
; Related .......:
; Link ..........:
; Example .......: No
; ===============================================================================================================================
Func _BombBot_SelectOption($iOption, $iMouseSpeed, $iTimeOut, $iSleep)
	Local $aiMousePos = MouseGetPos()

	_BombBot_WaitForColour($aiMousePos[0], $aiMousePos[1] + 1, 0xFFFFFF, 1, $iTimeOut, $iSleep)
	If Not @error Then
		Select
			Case $iOption = 2
				MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 45, 1, $iMouseSpeed)
			Case $iOption = 3
				MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 60, 1, $iMouseSpeed)
			Case $iOption = 4
				MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 75, 1, $iMouseSpeed)
			Case $iOption = 6
				MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 110, 1, $iMouseSpeed)
		EndSelect
	Else
		SetError(1)
	EndIf
EndFunc   ;==>_BombBot_SelectOption









