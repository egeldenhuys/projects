#cs ----------------------------------------------------------------------------
	
	AutoIt Version: 3.3.8.1
	Author:         B0T-Maker
	
	Script Function:
	Runescape Template Script
	
	Version: 0.01
	
#ce ----------------------------------------------------------------------------

#cs
	TODO:
	
#ce

;; Includes ;;
#include "BombBot.au3"

;; Hotkeys ;;
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

;; Global Variables ;;
Global $fPaused = False
Global $iGameX
Global $iGameY
_BombBot_FindGame($iGameX, $iGameY, 1)
Global $iMouseSpeed = 10
Global $sWindow = "[TITLE:RuneScape - MMORPG - The No.1 Free Online Multiplayer Game - Google Chrome; CLASS:Chrome_WidgetWin_1]"

#cs Windows
	Runescape Client = "[TITLE:RuneScape; CLASS:SunAwtFrame]"
	Google Chrome = "[TITLE:RuneScape - MMORPG - The No.1 Free Online Multiplayer Game - Google Chrome; CLASS:Chrome_WidgetWin_1]"
#ce

;;; Start Main Loop;;;
While 1
	WinActivate($sWindow)

	Sleep(100)
WEnd
;;; End Main Loop;;;

; WithdrawCoins
Func WithdrawCoins()
	Local $aiMousePos
	MouseClick("right", 1109 - $iGameX, 208 - $iGameY, $iMouseSpeed)
	_Bombot_WaitForMenu($iGameX, $iGameY, 1000, 10)
	If Not @error Then
		_BombBot_SelectOption(2, $iMouseSpeed, 1000, 10)
		If Not @error Then

			_BombBot_WaitForColour(436, 569, 0x000000, 0, 3000, 50)
			If Not @error Then
				Send($iCoinAmount)
				Send("{ENTER}")
			EndIf
		EndIf
	EndIf
EndFunc   ;==>WithdrawCoins


; DropCoins

; Walk

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

