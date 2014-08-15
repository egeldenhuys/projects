#include <ScreenCapture.au3>
#include <FTPEx.au3>
#include <Date.au3>

OnAutoItExitRegister("_Finish")

;;;; Hotkeys ;;;;
HotKeySet("{ESC}", "Terminate")
HotKeySet("{PAUSE}", "TogglePause")
HotKeySet("{F1}", "DisplaySessionStats")
HotKeySet("{F6}", "DisplayTotalStats")



;;;; Settings ;;;;

#cs
	No Ads:
	Laptop = ?
	Computer = 300, 20

	Ads:
	Laptop = 257, 122
	Computer = 300, 116

	; Drop-Bot01@bonshaw.4ward.com
	; Dp02@123.com
	; Dp1@123.com
	; 7
#ce

#cs == laptop Settings==
	Global $iGameX = 257
	Global $iGameY = 122
	Global $iDropSpeed1 = 7
	Global $sUploadName = "Drop_B0T_01"
	Global $sUsername = "Drop-Bot01@bonshaw.e4ward.com"
#ce

;;;; Variables ;;;;

Global $iGameX = 257
Global $iGameY = 122
Global $iDropSpeed1 = 7
Global $sUploadName = "Drop_B0T_01"
Global $sUsername = "Drop-Bot01@bonshaw.e4ward.com"

Global $sPassword = "123123"

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
Global Const $iCookedPikePrice = 154
Global Const $iCookedSalmonPrice = 185
Global Const $iCookedTroutPrice = 156
Global Const $iRawPikePrice = 144
Global Const $iRawSalmonPrice = 139
Global Const $iRawTroutPrice = 84

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
_UploadStatistics()

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

	If (TimerDiff($hUploadTime) > 300000) Then
		_UploadStatistics()
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

Func _MouseMoveRelativeAU3($iX, $iY)
	Local $pos = MouseGetPos()
	MouseMove($pos[0] + $iX, $pos[1] + $iY, 0)
EndFunc   ;==>_MouseMoveRelativeAU3


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

EndFunc   ;==>_Finish


Func Terminate()
	Exit 0
EndFunc   ;==>Terminate

