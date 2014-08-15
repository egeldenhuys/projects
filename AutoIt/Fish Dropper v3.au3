; TODO:
;	Port to Simba:
;		- All functions should be re-useable (parameters)
;	------
;	Rewrite all functions to use parameters and be re-useable
;	Fix bug where inventory dropping is looped if there is text in the chatbar.
;	Make first dropping method more accurate
;	Rewrite second drop method
;	Bot profiles
;	Upload session statistics

#include <ScreenCapture.au3>
#include <FTPEx.au3>
#include <Date.au3>

OnAutoItExitRegister("_Finish")

;;;; Hotkeys ;;;;
HotKeySet("{ESC}", "Terminate")
HotKeySet("{PAUSE}", "TogglePause")
HotKeySet("{F1}", "DisplaySessionStats")
HotKeySet("{F6}", "DisplayTotalStats")

#cs ---- Account and screen settings ----
	
	--- Desktop Settings ---
	
	- Members Account -
	Global $iGameX = 300
	Global $iGameY = 20
	Global $iDropSpeed1 = 0
	Global $sUploadName = "" ; Text file to store statistics in
	Global $sUsername = "" ; Email Address (Login)
	
	- Free Account -
	Global $iGameX = 300
	Global $iGameY = 116
	Global $iDropSpeed1 = 0
	Global $sUploadName = "" ; Text file to store statistics in
	Global $sUsername = "" ; Email Address (Login)
	
	----------------------------------------
	
	--- laptop Settings ---
	
	- Members Account -
	Global $iGameX = 257
	Global $iGameY = 26
	Global $iDropSpeed1 = 7
	Global $sUploadName = "Drop_B0T_01" ; Text file to store statistics in
	Global $sUsername = "Drop-Bot01@bonshaw.e4ward.com" ; Email Address (Login)
	
	- Free Account -
	Global $iGameX = 257
	Global $iGameY = 122
	Global $iDropSpeed1 = 7
	Global $sUploadName = "Drop_B0T_01" ; Text file to store statistics in
	Global $sUsername = "Drop-Bot01@bonshaw.e4ward.com" ; Email Address (Login)
#ce

;;;; Variables ;;;;

Global $iGameX = 257
Global $iGameY = 122
Global $iDropSpeed1 = 7
Global $sUploadName = "Drop_B0T_01"
Global $sUsername = "Drop-Bot01@bonshaw.e4ward.com"

Global $sPassword = ""
Global $bAdvertise = True

Global Const $iMouseSpeed = 1
Global $iBaseX = $iGameX + 575
Global $iBaseY = $iGameY + 231
Global Const $iShadeTolerence = 14
Global Const $iTimeOut = 2000
Global Const $iLoopSleep = 50
Global Const $sFilePath = @AppDataDir & "\Troll Applications\Bots\Fish Dropper\" & $sUploadName & ".txt"
Global Const $sImageFolder = @AppDataDir & "\Troll Applications\Bots\Fish Dropper\Screenshots\"
Global Const $sBackupFolder = @AppDataDir & "\Troll Applications\Bots\Fish Dropper\Backup\" & $sUploadName & "\"

If DirGetSize($sImageFolder) = -1 Then
	DirCreate($sImageFolder)
EndIf

; RunTime variables
Global $Stage
Global $aiCurrentCursorPos
Global $iStartTime = 0
Global $iOffsetY = 0
Global $file
Global $iMessageTimer
Global $iStatisticsTimer
Global $iImageCount = 0
Global $hBmp
Global $bScreenshotTaken
Global $Paused
Global $fSecondAttempt = False
Global $b1gpCommand = False
Global $b2gpCommand = False
Global $b3gpCommand = False
Global $hTradeTimeOut1 = 0
Global $hTradeTimeOut2 = 0
Global $iDropAttempt = 0
Global $bUnkownitems = False
Global $bDoneMessage = False
Global $hDropTimer = 0
Global $bDropTimer = False
Global $iFishDropped = 0
Global $hUploadTime = 0
Global $sStatus = "Online"
Global $sLastUpdate = 0
Global $iPreviousTime = 0

; Colours
Global $iRawSalmonColour = 0x945D53
Global $iCookedSalmonColour = 0xB73B1A
Global $iRawTroutColour = 0x989191
Global $iCookedTroutColour = 0x645856
Global $iRawPikeColour = 0x606F60
Global $iCookedPikeColour = 0x5F7D53
Global $iBurntFishColour = 0x3A3737

; Session Statistics
Global $iRawSalmonDropped = 0
Global $iCookedSalmonDropped = 0
Global $iRawTroutDropped = 0
Global $iCookedTroutDropped = 0
Global $iRawPikeDropped = 0
Global $iCookedPikeDropped = 0
Global $iBurntFishDropped = 0
Global $iPriceOfFish = 0
Global $iRunTime = 0
Global $iTradesDone = 0

; Total Statistics
Global $iTotalRawSalmonDropped = 0
Global $iTotalCookedSalmonDropped = 0
Global $iTotalRawTroutDropped = 0
Global $iTotalCookedTroutDropped = 0
Global $iTotalRawPikeDropped = 0
Global $iTotalCookedPikeDropped = 0
Global $iTotalBurntFishDropped = 0
Global $iTotalPriceOfFish = 0
Global $iTotalRunTime = 0
Global $iTotalTradesDone = 0

; Prices
Global Const $iCookedPikePrice = 90
Global Const $iCookedSalmonPrice = 118
Global Const $iCookedTroutPrice = 109
Global Const $iRawPikePrice = 102
Global Const $iRawSalmonPrice = 88
Global Const $iRawTroutPrice = 69

; Count screenshots
While 1
	If FileExists($sImageFolder & "Screenshot" & $iImageCount & ".png") Then
		$iImageCount += 1
	Else
		ExitLoop 1
	EndIf
WEnd

; Start timers and load statistics
$iRunTime = TimerInit()
$iMessageTimer = TimerInit()
$iStatisticsTimer = TimerInit()
$hUploadTime = TimerInit()
LoadTotalStatistics()
; _UploadStatistics()

;;;; Start ;;;;
While 1

	WinActivate("[TITLE:RuneScape; CLASS:SunAwtFrame]")

	If WinExists("[TITLE:RuneScape; CLASS:SunAwtFrame]") = 0 Then
		Exit 1
	EndIf

	GetStage()
	ToolTip($Stage, $iGameX + 766, $iGameY + 146)
	Select
		Case $Stage = "LoginScreen"
			Login()
		Case $Stage = "Lobby"
			LoginLobby()
		Case $Stage = "InGame"
			WaitForTrade()
		Case $Stage = "TradeScreen1"
			TradeScreen1()
		Case $Stage = "TradeScreen2"
			TradeScreen2()
		Case $Stage = "FishInInv"
			DropInventory()
	EndSelect

	If $bAdvertise = True Then
		; 180,000 default
		If TimerDiff($iMessageTimer) > 180000 Then
			; Look for text in the chat
			PixelSearch($iGameX + 97, $iGameY + 460, $iGameX + 124, $iGameY + 471, 0x0000FF)
			If @error Then
				$iMessageTimer = TimerInit()
				Send("Taking Raw, Cooked and Burnt fish. (Trout and Salmon)")
				Send("{ENTER}")
			EndIf
		EndIf
	EndIf

	If (TimerDiff($hUploadTime) > 300000) Then
		; _UploadStatistics()
		SaveTotalStatistics()
		_BackupStatistics()
		$hUploadTime = TimerInit()
	EndIf


	Sleep($iLoopSleep)
WEnd
;;;;;;;;

Func GetStage()
	ToolTip("Get Stage", $iGameX + 766, $iGameY + 146)

	; Search for red heart
	PixelSearch($iGameX + 706, $iGameY + 20, $iGameX + 706, $iGameY + 20, 0xB30804, $iShadeTolerence)
	If @error = 0 Then
		$Stage = "InGame"
	EndIf

	If $bUnkownitems = False Then
		SearchInventory()
	EndIf

	; Search for "Login" colour
	PixelSearch($iGameX + 381, $iGameY + 357, $iGameX + 381, $iGameY + 357, 0x5B8BD4, $iShadeTolerence)
	If @error = 0 Then
		$Stage = "LoginScreen"
	EndIf

	; Search for 3 green men
	PixelSearch($iGameX + 389, $iGameY + 31, $iGameX + 389, $iGameY + 31, 0x5FA13E, 5)
	If @error = 0 Then
		$Stage = "Lobby"
	EndIf

	; Search for orange text, "Your offer"
	PixelSearch($iGameX + 51, $iGameY + 47, $iGameX + 51, $iGameY + 47, 0xFF981F, 5)
	If @error = 0 Then
		$Stage = "TradeScreen1"
	EndIf

	; Search for red "No Way" text
	PixelSearch($iGameX + 153, $iGameY + 53, $iGameX + 153, $iGameY + 53, 0xFF0000, 5)
	If @error = 0 Then
		$Stage = "TradeScreen2"
	EndIf

EndFunc   ;==>GetStage

Func SearchInventory()
	; Search for Gold trim on inventory button
	PixelSearch($iGameX + 657, $iGameY + 169, $iGameX + 657, $iGameY + 169, 0xE69D3A, 3)
	If @error = 0 Then

		;; Search whole inventory
		; Raw Salmon
		PixelSearch($iGameX + 560, $iGameY + 213, $iGameX + 724, $iGameY + 459, $iRawSalmonColour, $iShadeTolerence)
		If @error = 0 Then
			$Stage = "FishInInv"
		EndIf

		; Cooked Salmon
		PixelSearch($iGameX + 560, $iGameY + 213, $iGameX + 724, $iGameY + 459, $iCookedSalmonColour, $iShadeTolerence)
		If @error = 0 Then
			$Stage = "FishInInv"
		EndIf

		; Raw Trout
		PixelSearch($iGameX + 560, $iGameY + 213, $iGameX + 724, $iGameY + 459, $iRawTroutColour, $iShadeTolerence)
		If @error = 0 Then
			$Stage = "FishInInv"
		EndIf

		; Cooked Trout
		PixelSearch($iGameX + 560, $iGameY + 213, $iGameX + 724, $iGameY + 459, $iCookedTroutColour, $iShadeTolerence)
		If @error = 0 Then
			$Stage = "FishInInv"
		EndIf

		; Raw Pike
		PixelSearch($iGameX + 560, $iGameY + 213, $iGameX + 724, $iGameY + 459, $iRawPikeColour, $iShadeTolerence)
		If @error = 0 Then
			$Stage = "FishInInv"
		EndIf

		; Cooked Pike
		PixelSearch($iGameX + 560, $iGameY + 213, $iGameX + 724, $iGameY + 459, $iCookedPikeColour, $iShadeTolerence)
		If @error = 0 Then
			$Stage = "FishInInv"
		EndIf

		; Burnt Fish
		PixelSearch($iGameX + 560, $iGameY + 213, $iGameX + 724, $iGameY + 459, $iBurntFishColour, 5)
		If @error = 0 Then
			$Stage = "FishInInv"
		EndIf
	EndIf
EndFunc   ;==>SearchInventory

Func Login()
	ToolTip("Login", $iGameX + 766, $iGameY + 146)

	$iStartTime = TimerInit()
	While 1
		; Search for Login Text
		PixelSearch($iGameX + 381, $iGameY + 357, $iGameX + 381, $iGameY + 357, 0x5B8BD4, $iShadeTolerence)
		If @error = 0 Then
			MouseClick("left", $iGameX + 291, $iGameY + 208, 1, $iMouseSpeed)
			; Enter account details
			Send($sUsername)
			Send("{TAB}")
			Send($sPassword)
			Send("{ENTER}")
			Sleep(3000)
		EndIf
		If TimerDiff($iStartTime) > 2000 Then
			ExitLoop 1
		EndIf
		Sleep($iLoopSleep)
	WEnd
EndFunc   ;==>Login
Func LoginLobby()
	ToolTip("Login Lobby", $iGameX + 766, $iGameY + 146)

	$iStartTime = TimerInit()
	While 1
		; Search for 3 green men
		PixelSearch($iGameX + 389, $iGameY + 31, $iGameX + 389, $iGameY + 31, 0x5FA13E, 5)
		If @error = 0 Then
			; Click on World Tab
			MouseClick("left", $iGameX + 211, $iGameY + 36, 1, $iMouseSpeed)
			ExitLoop 1
		EndIf
		If TimerDiff($iStartTime) > 2000 Then
			ExitLoop 1
		EndIf
		Sleep($iLoopSleep)
	WEnd

	; Wait for Sort button to apear
	$iStartTime = TimerInit()
	While 1
		PixelSearch($iGameX + 125, $iGameY + 188, $iGameX + 125, $iGameY + 188, 0x906510, $iShadeTolerence)
		If @error = 0 Then
			; Sort Worlds
			MouseClick("left", $iGameX + 125, $iGameY + 188, 1, $iMouseSpeed)
			; Click on world 1
			MouseClick("left", $iGameX + 131, $iGameY + 209, 1, 10)
			Sleep(500)
			; Click Play button
			MouseClick("left", $iGameX + 375, $iGameY + 459, 1, 20)
			Sleep(5000)
			$Stage = ""
			While 1
				GetStage()
				If $Stage = "InGame" Then
					; Set chat to 'Trade'
					MouseClick("left", $iGameX + 373, $iGameY + 489, 1, 20)
					ExitLoop 2
				EndIf
			WEnd
			ExitLoop 1
		EndIf
		If TimerDiff($iStartTime) > 2000 Then
			ExitLoop 1
		EndIf
		Sleep($iLoopSleep)
	WEnd
EndFunc   ;==>LoginLobby
Func WaitForTrade()
	ToolTip("Waiting for trade request", $iGameX + 766, $iGameY + 146)
	$iStartTime = TimerInit()
	While 1
		; Search for pink trade request
		PixelSearch($iGameX + 7, $iGameY + 443, $iGameX + 50, $iGameY + 457, 0x800080)
		If @error = 0 Then
			; Accept Trade
			MouseClick("left", $iGameX + 95, $iGameY + 450, 1, 2)
			$iFishDropped = 0
			$hTradeTimeOut1 = 0
			$hTradeTimeOut1 = TimerInit()
			$b1gpCommand = False
			$b2gpCommand = False
			$b3gpCommand = False
			Sleep(1000)
			ExitLoop 1
		EndIf
		If TimerDiff($iStartTime) > 3000 Then
			ExitLoop 1
		EndIf
		Sleep($iLoopSleep)
	WEnd
EndFunc   ;==>WaitForTrade

Func TradeScreen1()
	ToolTip("Trade 1", $iGameX + 766, $iGameY + 146)

	$iStartTime = 0
	$iStartTime = TimerInit()

	; Wait for other player to accept
	While 1
		; Search for "Other player accepted"
		PixelSearch($iGameX + 184, $iGameY + 291, $iGameX + 184, $iGameY + 291, 0xFFFFFF, 0)
		If @error = 0 Then

			If $b1gpCommand = False Then
				; Search first slot for gold coin (1)
				; 628, 85
				If PixelGetColor($iGameX + 328, $iGameY + 62) = 0xFFFF00 Then
					$b1gpCommand = True
					_PutInventoryInTrade()
				EndIf
			EndIf
			#cs
				If $b2gpCommand = False Then
				; Search first slot for gold coin (2)
				; 631, 88
				If PixelGetColor($iGameX + 331, $iGameY + 68) = 0xFFFF00 Then
				$b2gpCommand = True
				ToggleDoneMessage()
				EndIf
				EndIf
				
				If $b3gpCommand = False Then
				; Search first slot for gold coin (3)
				; 630, 86
				If PixelGetColor($iGameX + 330, $iGameY + 66) = 0xFFFF00 Then
				$b3gpCommand = True
				ToggleDropTimer()
				EndIf
				EndIf
			#ce
			$bScreenshotTaken = False
			; Click accept button
			MouseClick("left", $iGameX + 258, $iGameY + 145, 1, 2)
			$hTradeTimeOut2 = 0
			$hTradeTimeOut2 = TimerInit()
			ExitLoop 1
		EndIf
		If TimerDiff($iStartTime) > 2000 Then
			ExitLoop 1
		EndIf
		Sleep($iLoopSleep)

		If TimerDiff($hTradeTimeOut1) > 20000 Then
			PixelSearch($iGameX + 97, $iGameY + 460, $iGameX + 124, $iGameY + 471, 0x0000FF)
			If @error Then
				; Decline
				MouseClick("left", $iGameX + 258, $iGameY + 183, 1, $iMouseSpeed)
				Send("Trade Timed Out")
				Send("{ENTER}")
				Sleep(1000)
				ExitLoop 1
			EndIf
		EndIf
	WEnd
EndFunc   ;==>TradeScreen1

Func TradeScreen2()

	ToolTip("Trade 2", $iGameX + 766, $iGameY + 146)
	; Take screenshot
	If $bScreenshotTaken = False Then
		$bScreenshotTaken = True
		ToolTip(@HOUR & ":" & @MIN & ":" & @SEC, $iGameX + 685, $iGameY + 146)
		$hBmp = _ScreenCapture_Capture("", $iGameX, $iGameY, $iGameX + 764, $iGameY + 502, False)
		_ScreenCapture_SaveImage($sImageFolder & "\Screenshot" & $iImageCount & ".png", $hBmp, True)
		$iImageCount += 1
	EndIf

	; Click Accept button
	MouseClick("left", $iGameX + 221, $iGameY + 313, 1, 2)

	#cs
		If $bUnkownitems = True Then
		If $b1gpCommand = True Then
		_BombBot_WaitForColourChange($iGameX + 67, $iGameY + 311, 10000, 100)
		If Not @error Then
		$iDropAttempt = 0
		$bUnkownitems = False
		EndIf
		EndIf
		EndIf
	#ce

	; wait for fish to appear in inventory
	$iStartTime = TimerInit()
	While 1
		PixelSearch($iGameX + 575, $iGameY + 231, $iGameX + 575, $iGameY + 231, 0x484034, 2)
		If @error = 1 Then
			$hDropTimer = TimerInit()
			$iTradesDone += 1
			$iDropAttempt = 0
			DropInventory()
			ExitLoop 1
		EndIf
		; Get Stage
		If TimerDiff($iStartTime) > 3000 Then
			ExitLoop 1
		EndIf
		Sleep($iLoopSleep)

		If TimerDiff($hTradeTimeOut2) > 20000 Then
			; Look for text in the chat
			PixelSearch($iGameX + 97, $iGameY + 460, $iGameX + 124, $iGameY + 471, 0x0000FF)
			If @error Then
				; Decline
				MouseClick("left", $iGameX + 294, $iGameY + 311, 1, $iMouseSpeed)
				Send("Trade Timed Out")
				Send("{ENTER}")
				Sleep(1000)
				ExitLoop 1
			EndIf
		EndIf

	WEnd
EndFunc   ;==>TradeScreen2
Func DropInventory()

	ToolTip("Drop Inventory", $iGameX + 766, $iGameY + 146)

	; Reset variables
	$iBaseX = $iGameX + 575
	$iBaseY = $iGameY + 231
	$iOffsetY = 0
	$iOffsetX = 0

	For $Counter = 1 To 28
		ToolTip($Counter, $iGameX + 766, $iGameY + 146)
		MouseMove($iBaseX + $iOffsetX, $iBaseY + $iOffsetY, $iDropSpeed1)
		$aiCurrentCursorPos = MouseGetPos()

		If $fSecondAttempt = False Then
			; Search for empty space
			PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], 0x484034, 19)
			If @error = 0 Then
				; Search for burnt fish
				PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $iBurntFishColour, 7)
				If @error = 0 Then
					$iBurntFishDropped += 1
					DropCookedFish()

					If $iOffsetY = 216 Then ; Last Row
						If $iOffsetX = 126 Then ; last column
							ExitLoop 1
						EndIf
						$iOffsetY = 0 ; first row
						$iOffsetX += 42 ; next column
					Else
						$iOffsetY += 36 ; next row
					EndIf

					#cs Delete if not working
						If $iOffsetY = 216 Then ; Last Row
						If $iOffsetX = 126 Then ; last column
						ExitLoop 1
						Else
						$iOffsetY = 0 ; First Row
						$iOffsetX += 42 ; Next column
						EndIf
						Else
						If $iOffsetX <> 126 Then
						$iOffsetY += 36 ; Next Row
						EndIf
						EndIf
					#ce

				Else ; Empty slot, but not a burnt fish

					If $iOffsetX = 126 Then ; last column
						ExitLoop 1
					EndIf

					If $iOffsetX = 126 Then
						If $iOffsetY = 36 Then
							ExitLoop 1
						EndIf
					EndIf
					$iOffsetX += 42 ; Next Column
					$iOffsetY = 0 ; first row
				EndIf
			Else
				_IdentifyFish()
				If $iOffsetY = 216 Then ; Last Row
					If $iOffsetX = 126 Then ; last column
						ExitLoop 1
					EndIf
					$iOffsetY = 0 ; first row
					$iOffsetX += 42 ; next column
				Else
					$iOffsetY += 36 ; next row
				EndIf
			EndIf
		Else
			_IdentifyFish()
			If $iOffsetY = 216 Then ; Last Row
				If $iOffsetX = 126 Then ; last column
					ExitLoop 1
				EndIf
				$iOffsetY = 0 ; First row
				$iOffsetX += 42 ; next column
			Else
				$iOffsetY += 36 ; next row
			EndIf
		EndIf
	Next

	$iStartTime = TimerInit()
	While 1
		$Stage = ""
		SearchInventory()
		If $Stage = "" Then
			; Search Chat
			PixelSearch($iGameX + 97, $iGameY + 460, $iGameX + 124, $iGameY + 471, 0x0000FF)
			If @error = 1 Then
				If $bDropTimer = True Then
					Send("Dropped in " & Round(TimerDiff($hDropTimer) / 1000, 1) & " Seconds. (" & $iFishDropped & " fish)")
					Send("{ENTER}")
				EndIf

				If $bDoneMessage = True Then
					If $bDropTimer = False Then
						Send("Done.")
						Send("{ENTER}")
					EndIf
				EndIf
			EndIf
			$fSecondAttempt = False
			ExitLoop 1
		EndIf

		If TimerDiff($iStartTime) > 3000 Then
			$fSecondAttempt = True

			If $iDropAttempt = 3 Then
				$bUnkownitems = True
				Send("Unknown items in inventory... waiting for 1 gp. (In first trade slot)")
				Send("{Enter}")
				ExitLoop 1
			Else
				$iDropAttempt += 1
			EndIf

			; Reset variables
			$iOffsetX = 0
			$iOffsetY = 0
			DropInventory()
			ExitLoop 1
		EndIf
		Sleep(50)
	WEnd
	; Reset variables
	$iOffsetX = 0
	$iOffsetY = 0
EndFunc   ;==>DropInventory

Func _IdentifyFish()
	;; Search current mouse position, used to identify and count fish.

	; Raw Salmon
	PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $iRawSalmonColour, $iShadeTolerence)
	If @error = 0 Then
		$iRawSalmonDropped += 1
		DropRawFish()
	EndIf

	; Cooked Salmon
	PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $iCookedSalmonColour, $iShadeTolerence)
	If @error = 0 Then
		$iCookedSalmonDropped += 1
		DropCookedFish()
	EndIf

	; Raw Trout
	PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $iRawTroutColour, $iShadeTolerence)
	If @error = 0 Then
		$iRawTroutDropped += 1
		DropRawFish()
	EndIf

	; Cooked Trout
	PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $iCookedTroutColour, $iShadeTolerence)
	If @error = 0 Then
		$iCookedTroutDropped += 1
		DropCookedFish()
	EndIf

	; Raw Pike
	PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $iRawPikeColour, $iShadeTolerence)
	If @error = 0 Then
		$iRawPikeDropped += 1
		DropRawFish()
	EndIf

	; Cooked Pike
	PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $iCookedPikeColour, $iShadeTolerence)
	If @error = 0 Then
		$iCookedPikeDropped += 1
		DropCookedFish()
	EndIf


	; Burnt Fish
	PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], $iBurntFishColour, 7)
	If @error = 0 Then
		$iBurntFishDropped += 1
		DropCookedFish()
	EndIf


EndFunc   ;==>_IdentifyFish

Func _MouseMoveRelativeAU3($iX, $iY)
	Local $pos = MouseGetPos()
	MouseMove($pos[0] + $iX, $pos[1] + $iY, 0)
EndFunc   ;==>_MouseMoveRelativeAU3

Func DropRawFish()
	$iFishDropped += 1
	MouseClick("right", $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], 1, 0)
	Select
		; Last row
		Case $iOffsetY = 216
			$iStartTime = TimerInit()
			While 1
				; Wait for menu to open
				PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1] - 28, $aiCurrentCursorPos[0], $aiCurrentCursorPos[1] - 28, 0xFFFFFF, 1)
				If @error = 0 Then
					_MouseMoveRelativeAU3(0, 15)
					Local $pos = MouseGetPos()
					MouseClick("left", $pos[0], $pos[1], 1, 0)
					;Sleep($iLoopSleep)
					ExitLoop 1
				EndIf
				If TimerDiff($iStartTime) > 1000 Then
					ExitLoop 1
				EndIf
				Sleep($iLoopSleep)
			WEnd
		Case Else
			$iStartTime = TimerInit()
			While 1
				; Wait for menu to open
				PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1] + 1, $aiCurrentCursorPos[0], $aiCurrentCursorPos[1] + 1, 0xFFFFFF, 1)
				If @error = 0 Then
					; Click Drop
					_MouseMoveRelativeAU3(0, 46)
					Local $pos = MouseGetPos()
					MouseClick("left", $pos[0], $pos[1], 1, 0)
					;;;Sleep($iLoopSleep)
					ExitLoop 1
				EndIf
				If TimerDiff($iStartTime) > 1000 Then
					ExitLoop 1
				EndIf
				Sleep($iLoopSleep)
			WEnd
	EndSelect
EndFunc   ;==>DropRawFish

Func DropCookedFish()
	$iFishDropped += 1
	MouseClick("right", $aiCurrentCursorPos[0], $aiCurrentCursorPos[1], 1, 0)
	; Last row
	Select
		; Second last row
		Case $iOffsetY = 180
			$iStartTime = TimerInit()
			While 1
				; Wait for menu to open
				PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1] - 8, $aiCurrentCursorPos[0], $aiCurrentCursorPos[1] - 8, 0xFFFFFF, 2)
				If @error = 0 Then
					_MouseMoveRelativeAU3(0, 53)
					Local $pos = MouseGetPos()
					MouseClick("left", $pos[0], $pos[1], 1, 0)
					;Sleep($iLoopSleep)
					ExitLoop 1
				EndIf
				If TimerDiff($iStartTime) > 1000 Then
					ExitLoop 1
				EndIf
				Sleep($iLoopSleep)
			WEnd
			; Last Row
		Case $iOffsetY = 216
			$iStartTime = TimerInit()
			While 1
				; Wait for menu to open
				PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1] - 44, $aiCurrentCursorPos[0], $aiCurrentCursorPos[1] - 44, 0xFFFFFF, 1)
				If @error = 0 Then
					_MouseMoveRelativeAU3(0, 15)
					Local $pos = MouseGetPos()
					MouseClick("left", $pos[0], $pos[1], 1, 0)
					;Sleep($iLoopSleep)
					ExitLoop 1
				EndIf
				If TimerDiff($iStartTime) > 1000 Then
					ExitLoop 1
				EndIf
				Sleep($iLoopSleep)
			WEnd
			; Other rows
		Case Else
			$iStartTime = TimerInit()
			While 1
				; Wait for menu to open
				PixelSearch($aiCurrentCursorPos[0], $aiCurrentCursorPos[1] + 1, $aiCurrentCursorPos[0], $aiCurrentCursorPos[1] + 1, 0xFFFFFF, 1)
				If @error = 0 Then
					; Click Drop
					_MouseMoveRelativeAU3(0, 60)
					Local $pos = MouseGetPos()
					MouseClick("left", $pos[0], $pos[1], 1, 0)
					;;;Sleep($iLoopSleep)
					ExitLoop 1
				EndIf
				If TimerDiff($iStartTime) > 1000 Then
					ExitLoop 1
				EndIf
				Sleep($iLoopSleep)
			WEnd
	EndSelect
EndFunc   ;==>DropCookedFish

Func _PutInventoryInTrade()

	Local $iBaseXB = $iGameX + 575
	Local $iBaseYB = $iGameY + 231
	Local $iSleepB = 40
	Local $iOffsetXB = 0
	Local $iOffsetYB = 0
	Local $iMouseSpeedB = 0
	Local $aiMousePosB

	For $iSlotB = 1 To 28

		MouseMove($iBaseXB + $iOffsetXB, $iBaseYB + $iOffsetYB, $iMouseSpeedB)
		$aiMousePosB = MouseGetPos()

		MouseClick("left", $aiMousePosB[0], $aiMousePosB[1], 1, $iMouseSpeedB)
		Sleep(70)

		; Last Row

		If $iOffsetXB = 126 Then
			$iOffsetXB = 0
			$iOffsetYB += 36
		Else
			$iOffsetXB += 42
		EndIf

	Next

EndFunc   ;==>_PutInventoryInTrade

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

Func _UploadStatistics()

	SaveTotalStatistics()
	_BackupStatistics()

	ToolTip("Uploading Statistics", $iGameX + 766, $iGameY + 146)

	$sLastUpdate = @YEAR & '-' & @MON & '-' & @MDAY & " " & @HOUR & ":" & @MIN & ":" & @SEC

	$iPriceOfFish = ($iRawSalmonDropped * $iRawSalmonPrice) + ($iCookedSalmonDropped * $iCookedSalmonPrice) _
			 + ($iRawTroutDropped * $iRawTroutPrice) + ($iCookedTroutDropped * $iCookedTroutPrice) _
			 + ($iRawPikeDropped * $iRawPikePrice) + ($iCookedPikeDropped * $iCookedPikePrice)

	$URL = "http://dropstatsv1.vacau.com/save.php?name=" & $sUploadName & "&lastupdate=" & $sLastUpdate & "&status=" & $sStatus & _
			"&runtime=" & ($iTotalRunTime + (TimerDiff($iRunTime))) & "&rawsalmon=" & ($iTotalRawSalmonDropped + $iRawSalmonDropped) & _
			"&rawtrout=" & ($iTotalRawTroutDropped + $iRawTroutDropped) & "&rawpike=" & ($iTotalRawPikeDropped + $iRawPikeDropped) & _
			"&cookedsalmon=" & ($iTotalCookedSalmonDropped + $iCookedSalmonDropped) & "&cookedtrout=" & ($iTotalCookedTroutDropped + $iCookedTroutDropped) & _
			"&cookedpike=" & ($iTotalCookedPikeDropped + $iCookedPikeDropped) & "&burntfish=" & ($iTotalBurntFishDropped + $iBurntFishDropped) & _
			"&price=" & ($iTotalPriceOfFish + $iPriceOfFish) & "&tradesdone=" & ($iTotalTradesDone + $iTradesDone) & "&password=" & ("no-encrypt")

	$httpObj = ObjCreate("winhttp.winhttprequest.5.1")
	$httpObj.open("GET", $URL, False)
	$httpObj.send()

	$oReceived = $httpObj.ResponseText
	ConsoleWrite($oReceived & @CR)

EndFunc   ;==>_UploadStatistics

Func _BackupStatistics()
	ToolTip("Backup Statistics", $iGameX + 766, $iGameY + 146)
	Local $iFileCount = 1

	Do
		If (FileExists($sBackupFolder & $sUploadName & "_" & $iFileCount & ".txt")) Then
			$iFileCount += 1
		EndIf

	Until ((FileExists($sBackupFolder & $sUploadName & "_" & $iFileCount & ".txt") = False))

	FileCopy($sFilePath, $sBackupFolder & $sUploadName & "_" & $iFileCount & ".txt", 8)

EndFunc   ;==>_BackupStatistics


Func DisplaySessionStats()
	ToolTip("Session Stats", $iGameX + 766, $iGameY + 146)
	Send("Statistics for this session: (Run time: " & Round((TimerDiff($iRunTime) / 60000), 2) & " mins)")
	Send("{ENTER}")
	Sleep(2000)
	Send("Raw Salmon dropped: " & $iRawSalmonDropped & ", Raw Trout dropped: " & $iRawTroutDropped & ", Raw Pike dropped: " & $iRawPikeDropped)
	Send("{ENTER}")
	Sleep(2000)
	Send("Cooked Salmon dropped: " & $iCookedSalmonDropped & ", Cooked Trout dropped: " & $iCookedTroutDropped _
			 & ", Cooked Pike dropped: " & $iCookedPikeDropped)
	Send("{ENTER}")
	Sleep(2000)

	$iPriceOfFish = ($iRawSalmonDropped * $iRawSalmonPrice) + ($iCookedSalmonDropped * $iCookedSalmonPrice) _
			 + ($iRawTroutDropped * $iRawTroutPrice) + ($iCookedTroutDropped * $iCookedTroutPrice) _
			 + ($iRawPikeDropped * $iRawPikePrice) + ($iCookedPikeDropped * $iCookedPikePrice)

	Send("Burnt Fish dropped: " & $iBurntFishDropped & ", Trades Done: " & $iTradesDone & ", Price of dropped fish: " & $iPriceOfFish & " gp")
	Send("{ENTER}")
	Sleep(2000)
EndFunc   ;==>DisplaySessionStats

Func DisplayTotalStats()
	ToolTip("Total Stats", $iGameX + 766, $iGameY + 146)
	Send("Total Statistics: (Run time: " & Round((TimerDiff($iRunTime) / 3600000 + ($iTotalRunTime / 3600000)), 2) & " hours)")
	Send("{ENTER}")
	Sleep(2000)
	Send("Raw Salmon dropped: " & ($iTotalRawSalmonDropped + $iRawSalmonDropped) _
			 & ", Raw Trout dropped: " & ($iTotalRawTroutDropped + $iRawTroutDropped) _
			 & ", Raw Pike dropped: " & ($iTotalRawPikeDropped + $iRawPikeDropped))
	Send("{ENTER}")
	Sleep(2000)
	Send("Cooked Salmon dropped: " & ($iTotalCookedSalmonDropped + $iCookedSalmonDropped) _
			 & ", Cooked Trout dropped: " & ($iTotalCookedTroutDropped + $iCookedTroutDropped) _
			 & ", Cooked Pike Dropped: " & ($iTotalCookedPikeDropped + $iRawPikeDropped))
	Send("{ENTER}")
	Sleep(2000)

	$iPriceOfFish = ($iRawSalmonDropped * $iRawSalmonPrice) + ($iCookedSalmonDropped * $iCookedSalmonPrice) _
			 + ($iRawTroutDropped * $iRawTroutPrice) + ($iCookedTroutDropped * $iCookedTroutPrice) _
			 + ($iRawPikeDropped * $iRawPikePrice) + ($iCookedPikeDropped * $iCookedPikePrice)

	Send("Burnt Fish dropped: " & ($iBurntFishDropped + $iTotalBurntFishDropped) _
			 & ", Trades Done: " & ($iTotalTradesDone + $iTradesDone) _
			 & ", Price of dropped fish: " & ($iPriceOfFish + $iTotalPriceOfFish) & " gp")
	Send("{ENTER}")
	Sleep(2000)
EndFunc   ;==>DisplayTotalStats

Func LoadTotalStatistics()
	ToolTip("Load Total Stats", $iGameX + 766, $iGameY + 146)

	$file = FileOpen($sFilePath, 0)
	If $file <> -1 Then
		$iLine = 0
		Do
			$iLine += 1
			$sLineText = FileReadLine($file, $iLine)
			$sLineText = StringSplit($sLineText, "=")
			Select
				Case $sLineText[1] = "Raw Salmon"
					$iTotalRawSalmonDropped = $sLineText[2]
				Case $sLineText[1] = "Cooked Salmon"
					$iTotalCookedSalmonDropped = $sLineText[2]
				Case $sLineText[1] = "Raw Trout"
					$iTotalRawTroutDropped = $sLineText[2]
				Case $sLineText[1] = "Cooked Trout"
					$iTotalCookedTroutDropped = $sLineText[2]
				Case $sLineText[1] = "Raw Pike"
					$iTotalRawPikeDropped = $sLineText[2]
				Case $sLineText[1] = "Cooked Pike"
					$iTotalCookedPikeDropped = $sLineText[2]
				Case $sLineText[1] = "Burnt Fish"
					$iTotalBurntFishDropped = $sLineText[2]
				Case $sLineText[1] = "Price"
					$iTotalPriceOfFish = $sLineText[2]
				Case $sLineText[1] = "Run Time"
					$iTotalRunTime = $sLineText[2]
				Case $sLineText[1] = "Trades Done"
					$iTotalTradesDone = $sLineText[2]
			EndSelect
		Until $iLine = 12
	EndIf
	FileClose($file)
EndFunc   ;==>LoadTotalStatistics

Func SaveTotalStatistics()
	ToolTip("Save Total Stats", $iGameX + 766, $iGameY + 146)

	$iPriceOfFish = ($iRawSalmonDropped * $iRawSalmonPrice) + ($iCookedSalmonDropped * $iCookedSalmonPrice) _
			 + ($iRawTroutDropped * $iRawTroutPrice) + ($iCookedTroutDropped * $iCookedTroutPrice) _
			 + ($iRawPikeDropped * $iRawPikePrice) + ($iCookedPikeDropped * $iCookedPikePrice)

	$file = FileOpen($sFilePath, 10)
	If $file <> -1 Then
		FileWriteLine($file, "Run Time=" & ($iTotalRunTime + TimerDiff($iRunTime)))

		FileWriteLine($file, "Raw Salmon=" & ($iTotalRawSalmonDropped + $iRawSalmonDropped))
		FileWriteLine($file, "Raw Trout=" & ($iTotalRawTroutDropped + $iRawTroutDropped))
		FileWriteLine($file, "Raw Pike=" & ($iTotalRawPikeDropped + $iRawPikeDropped))

		FileWriteLine($file, "Cooked Salmon=" & ($iTotalCookedSalmonDropped + $iCookedSalmonDropped))
		FileWriteLine($file, "Cooked Trout=" & ($iTotalCookedTroutDropped + $iCookedTroutDropped))
		FileWriteLine($file, "Cooked Pike=" & ($iTotalCookedPikeDropped + $iCookedPikeDropped))

		FileWriteLine($file, "Burnt Fish=" & ($iTotalBurntFishDropped + $iBurntFishDropped))
		FileWriteLine($file, "Price=" & ($iTotalPriceOfFish + $iPriceOfFish))

		FileWriteLine($file, "Trades Done=" & ($iTotalTradesDone + $iTradesDone))

	EndIf

	FileClose($file)
EndFunc   ;==>SaveTotalStatistics

Func ToggleDoneMessage()
	$bDoneMessage = Not $bDoneMessage
	If $bDoneMessage = True Then
		Send("""Done"" message has been enabled.")
		Send("{ENTER}")
	Else
		Send("""Done"" message has been disabled.")
		Send("{ENTER}")
	EndIf
EndFunc   ;==>ToggleDoneMessage

Func ToggleDropTimer()
	$bDropTimer = Not $bDropTimer
	If $bDropTimer = True Then
		Send("Drop Timer has been enabled.")
		Send("{ENTER}")
	Else
		Send("Drop Timer has been disabled.")
		Send("{ENTER}")
	EndIf
EndFunc   ;==>ToggleDropTimer

Func TogglePause()
	$Paused = Not $Paused
	While $Paused
		Sleep(100)
		ToolTip("Paused", $iGameX + 766, $iGameY + 146)
	WEnd
	ToolTip("")
EndFunc   ;==>TogglePause

Func _Finish()
	$sStatus = 'Offline'
	SaveTotalStatistics()
	_BackupStatistics()
	; _UploadStatistics()
EndFunc   ;==>_Finish


Func Terminate()
	Exit 0
EndFunc   ;==>Terminate

