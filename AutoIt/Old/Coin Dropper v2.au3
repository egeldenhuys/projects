#cs ----------------------------------------------------------------------------

	AutoIt Version: 3.3.9.0 (beta)
	Author:         myName

	Script Function:
	Drops coins from money pouch

#ce ----------------------------------------------------------------------------
; TODO:
;	add runtime tooltip
;

#include "BombBot.au3"

HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

Global $fPaused = False

#cs
	== Laptop Ad ==
	Global $iGameX = 257
	Global $iGameY = 122

	== Computer Ad ==
	Global $iGameX = 300
	Global $iGameY = 116
#ce
;;;; Variables ;;;;

Global $iGameX = 299
Global $iGameY = 163

Global $iMouseSpeed = 5
Global $iCoinAmount = 10

;;;; Start ;;;;
While 1
	WinActivate("[TITLE:SwiftKit for RuneScape | Integrated with Zybez; CLASS:ThunderRT6FormDC]")
	_DropCoinsFromPouch()
	_Walk()
	Sleep(100)
WEnd

Func _DropCoinsFromPouch()
	_WithdrawCoins()
	_DropCoins()
EndFunc   ;==>_DropCoinsFromPouch

Func _WithdrawCoins()
	Local $aiMousePos
	MouseClick("right", 1109 - $iGameX, 208 - $iGameY, $iMouseSpeed)
	_Bomb
	If Not @error Then
		_BombBot_WaitForColour(436, 569, 0x000000, 0, 3000, 50)
		If Not @error Then
			Send($iCoinAmount)
			Send("{ENTER}")
		EndIf
	EndIf
EndFunc   ;==>_WithdrawCoins

Func _DropCoins()
	_BombBot_RegionWaitForColour(863, 376, 868, 383, 0xFFFF00, 0, 4000, 50)
	If Not @error Then
		MouseClick("right", 875, 391, $iMouseSpeed)
		_BombBot_SelectOption(3, $iMouseSpeed, 2000, 50)
		If Not @error Then

		EndIf
	EndIf
EndFunc   ;==>_DropCoins

Func _Walk()
	MouseClick("left", 560, 306, 1, $iMouseSpeed)
	Sleep(300)
EndFunc   ;==>_Walk

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

