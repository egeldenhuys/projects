
; #FUNCTION# ====================================================================================================================
; Name ..........: _BombBot_DropInventory
; Description ...: Drops items in the inventory.
; Syntax ........: _BombBot_DropInventory($iBaseX, $iBaseY, $aiItemSearchBaseX, $aiItemSearchBaseY, $aiItemColour,
;                  $aiItemDropIndex, $iMouseSpeed, $iScreenSize)
; Parameters ....: $iBaseX              - An integer value. The upper left corner of the inventory. Inside inventory box
;                  $iBaseY              - An integer value. The upper left corner of the inventory. inside inventory box
;                  $aiItemSearchBaseX   - An array of integers. X Location to search for the colour. Item needs to be in the first slot when capturing location and colour.
;                  $aiItemSearchBaseY   - An array of integers. Y Location to search for the colour. Item needs to be in the first slot when capturing location and colour.
;                  $aiItemColour        - An array of integers. Item needs to be in the first slot when capturing the colour.
;                  $aiItemDropIndex     - An array of integers.
;                  $iMouseSpeed         - An integer value.
;                  $sScreenSize         - An string value. Resizeable or Fixed
; Return values .: None
; Author ........: Evert
; Modified ......:
; Remarks .......:
; Related .......:
; Link ..........:
; Example .......: No
; ===============================================================================================================================
Func _BombBot_DropInventory($iBaseX, $iBaseY, $aiItemSearchBaseX, $aiItemSearchBaseY, $aiItemColour, $aiItemDropIndex, $iMouseSpeed, $sScreenSize)
	Local $iSleep = 130
	;; Variables ;;
	$iBaseX += 28 ; Base X Coordinate
	$iBaseY += 26 ; Base Y Coordinate
	Local $iOffsetX = 0 ; Column
	Local $iOffsetY = 0 ; Row
	Local $aiMousePos


	For $iSlot = 1 To 28

		For $iCounter = 0 To UBound($aiItemColour) - 1
			; Search for item in array
			PixelSearch($aiItemSearchBaseX[$iCounter] + $iOffsetX, $aiItemSearchBaseY[$iCounter] + $iOffsetY, $aiItemSearchBaseX[$iCounter] + $iOffsetX, $aiItemSearchBaseY[$iCounter] + $iOffsetY, $aiItemColour[$iCounter], 10)
			; If a item has been found
			If Not @error Then
				MouseMove($iBaseX + $iOffsetX, $iBaseY + $iOffsetY, $iMouseSpeed)
				$aiMousePos = MouseGetPos()
				Select
					Case $sScreenSize = "Resizeable"

						Select

							;;;; Drop Index = 2 ;;;;
							Case $aiItemDropIndex[$iCounter] = 2

								Select
									; Last Row
									Case $iOffsetY = 216

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] - 16, $aiMousePos[0], $aiMousePos[1] - 16, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 28, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd

										; Not last Row
									Case Else

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] + 1, $aiMousePos[0], $aiMousePos[1] + 1, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 45, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd
								EndSelect

								;;;; Drop Index = 3 ;;;;
							Case $aiItemDropIndex[$iCounter] = 3

								Select
									; Last Row
									Case $iOffsetY = 216

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] - 32, $aiMousePos[0], $aiMousePos[1] - 32, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 27, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd

										; Not last Row
									Case Else

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] + 1, $aiMousePos[0], $aiMousePos[1] + 1, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 60, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd
								EndSelect

								;;;; Drop Index = 4 ;;;;
							Case $aiItemDropIndex[$iCounter] = 4

								Select
									; Second Last Row
									Case $iOffsetY = 180

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] - 12, $aiMousePos[0], $aiMousePos[1] - 12, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 64, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd

										; Last Row
									Case $iOffsetY = 216

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] - 48, $aiMousePos[0], $aiMousePos[1] - 48, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 28, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd

										; Not last Row
									Case Else

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] + 1, $aiMousePos[0], $aiMousePos[1] + 1, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 76, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd
								EndSelect
						EndSelect

					Case $sScreenSize = "Fixed"
						Select

							;;;; Drop Index = 2 ;;;;
							Case $aiItemDropIndex[$iCounter] = 2

								Select
									; Last Row
									Case $iOffsetY = 216

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] - 28, $aiMousePos[0], $aiMousePos[1] - 28, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 15, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd

										; Not last Row
									Case Else

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] + 1, $aiMousePos[0], $aiMousePos[1] + 1, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 45, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd
								EndSelect

								;;;; Drop Index = 3 ;;;;
							Case $aiItemDropIndex[$iCounter] = 3

								Select
									; Last Row
									Case $iOffsetY = 216

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] - 32, $aiMousePos[0], $aiMousePos[1] - 32, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 27, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd

										; Not last Row
									Case Else

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] + 1, $aiMousePos[0], $aiMousePos[1] + 1, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 60, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd
								EndSelect

								;;;; Drop Index = 4 ;;;;
							Case $aiItemDropIndex[$iCounter] = 4

								Select
									; Second Last Row
									Case $iOffsetY = 180

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] - 12, $aiMousePos[0], $aiMousePos[1] - 12, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 64, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd

										; Last Row
									Case $iOffsetY = 216

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] - 48, $aiMousePos[0], $aiMousePos[1] - 48, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 28, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd

										; Not last Row
									Case Else

										MouseClick("right", $aiMousePos[0], $aiMousePos[1], 1, 0)
										; Wait for menu
										While 1
											PixelSearch($aiMousePos[0], $aiMousePos[1] + 1, $aiMousePos[0], $aiMousePos[1] + 1, 0xFFFFFF, 1)
											If @error = 0 Then
												; Drop
												MouseClick("left", $aiMousePos[0], $aiMousePos[1] + 76, 1, $iMouseSpeed)
												Sleep($iSleep)
												ExitLoop 2
											EndIf
											Sleep(70)
										WEnd
								EndSelect
						EndSelect

				EndSelect
			EndIf
		Next

		; Last Row
		If $iOffsetY = 216 Then
			; last collumn
			If $iOffsetX = 126 Then
				ExitLoop 1
			EndIf
			$iOffsetY = 0
			$iOffsetX += 42
		Else
			$iOffsetY += 36
		EndIf
	Next
EndFunc   ;==>_BombBot_DropInventory

; #FUNCTION# ====================================================================================================================
; Name ..........: _WaitForColour
; Description ...:
; Syntax ........: _WaitForColour($iX, $iY, $iColour, $iTolerence, $iTimeOut, $iSleep)
; Parameters ....: $iX                  - An integer value.
;                  $iY                  - An integer value.
;                  $iColour             - An integer value.
;                  $iTolerence          - An integer value.
;                  $iTimeOut            - Amount of milliseconds script should wait for the colour
;                  $iSleep              - An integer value.
; Return values .: Sets @Error to 1 when colour is not found after $iTimeout
; Author ........: Your Name
; Modified ......:
; Remarks .......:
; Related .......:
; Link ..........:
; Example .......: No
; ===============================================================================================================================
Func _BombBot_WaitForColour($iX, $iY, $iColour, $iTolerence, $iTimeOut, $iSleep)
	Local $iStartTime = TimerInit()

	While 1
		PixelSearch($iX, $iY, $iX, $iY, $iColour, $iTolerence)
		If Not @error Then
			ExitLoop 1
		EndIf

		If TimerDiff($iStartTime) > $iTimeOut Then
			SetError(1)
			ExitLoop 1
		EndIf

		Sleep($iSleep)
	WEnd
EndFunc   ;==>_BombBot_WaitForColour

Func _BombBot_RegionWaitForColour($iX, $iY, $iX2, $iY2, $iColour, $iTolerence, $iTimeOut, $iSleep)
	Local $iStartTime = TimerInit()

	While 1
		PixelSearch($iX, $iY, $iX2, $iY2, $iColour, $iTolerence)
		If Not @error Then
			ExitLoop 1
		EndIf

		If TimerDiff($iStartTime) > $iTimeOut Then
			SetError(1)
			ExitLoop 1
		EndIf

		Sleep($iSleep)
	WEnd
EndFunc   ;==>_BombBot_RegionWaitForColour

; #FUNCTION# ====================================================================================================================
; Name ..........: _BombBot_WaitForColourChange
; Description ...:
; Syntax ........: _BombBot_WaitForColourChange($iX, $iY, $iTimeOut, $iSleep)
; Parameters ....: $iX                  - An integer value. X Location to search
;                  $iY                  - An integer value. Y Location to search
;                  $iTimeOut            - An integer value. Timeout
;                  $iSleep              - An integer value. Interval to check for change
; Return values .: 1 if timeout
; Author ........: Evert
; Modified ......:
; Remarks .......:
; Related .......:
; Link ..........:
; Example .......: No
; ===============================================================================================================================
Func _BombBot_WaitForColourChange($iX, $iY, $iTimeOut, $iSleep)
	Local $iStartTime = TimerInit()
	Local $iPixelColour1
	Local $iPixelColour2

	$iPixelColour1 = PixelGetColor($iX, $iY)

	While 1

		$iPixelColour2 = PixelGetColor($iX, $iY)

		If $iPixelColour1 <> $iPixelColour2 Then
			ExitLoop 1
		EndIf

		If TimerDiff($iStartTime) > $iTimeOut Then
			SetError(1)
			ExitLoop 1
		EndIf

		Sleep($iSleep)
	WEnd
EndFunc   ;==>_BombBot_WaitForColourChange

Func _BombBot_CheckForTrade()

EndFunc   ;==>_BombBot_CheckForTrade

Func _BombBot_Login($sUsername, $sPassword, $sScreenSize)
	Select
		Case $sScreenSize = "Fixed"
			; Yellow login Button
			_BombBot_WaitForColour(745, 409, 0xB57B09, 10, 5000, 100)
			If Not @error Then
				MouseClick("left", 776, 322, 1, 10)
				Send($sUsername, 1)
				Send("{ENTER}")
				Sleep(100)
				Send($sPassword, 1)
				Sleep(100)
				; Login
				MouseClick("left", 726, 411, 1, 10)
			EndIf
	EndSelect
EndFunc   ;==>_BombBot_Login

Func _BombBot_LoginLobby($sScreenSize)
	Select
		Case $sScreenSize = "Fixed"
			MouseClick("left", 881, 575, 1, 10)
	EndSelect
EndFunc   ;==>_BombBot_LoginLobby

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

Func _BombBot_AcceptTrade($iStage, $iMode, $sTimeOut, $sScreenSize)
	Select
		Case $sScreenSize = "Fixed"
			Select
				Case $iMode = 1 ; Accept when other player accepts.
					Select

						Case $iStage = 1
							_BombBot_WaitForColour(484, 408, 0xFFFFFF, 10, $sTimeOut, 100)
							If Not @error Then
								MouseClick("left", 560, 258, 1, 10)
							EndIf

						Case $iStage = 2
							_BombBot_WaitForColour(370, 191, 0xFFFF00, 10, $sTimeOut, 100)
							If Not @error Then
								MouseClick("left", 522, 424, 1, 10)
							EndIf
					EndSelect
			EndSelect
	EndSelect
EndFunc   ;==>_BombBot_AcceptTrade

Func _BombBot_LogOut($sScreenSize)
	Select
		Case $sScreenSize = "Fixed"
			MouseClick("left", 1053, 126, 1, 10)
			_BombBot_WaitForColour(997, 523, 0x811F1D, 10, 5000, 100)
			If Not @error Then
				MouseClick("left", 997, 523, 1, 10)
			EndIf

	EndSelect

EndFunc   ;==>_BombBot_LogOut








