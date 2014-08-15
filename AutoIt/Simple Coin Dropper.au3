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

; Hotkeys
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

; Globals
Global $fPaused = False
Global $speed = 1
Global $sWindow = "[TITLE:RuneScape - MMORPG - The No.1 Free Online Multiplayer Game - Google Chrome; CLASS:Chrome_WidgetWin_1]"
Global $count = 1

While 1
	WinActivate($sWindow)

	;$ran = Random(1, 500, 1)

	;If $ran > 250 Then
	;	$ran = 250
	;EndIf


	If WithdrawCoins($count) = True Then
		If DropCoins() = True Then
			;Walk()
			$count += 1
		EndIf
	EndIf

WEnd

Func WithdrawCoins($amount)

	; Click the pouch
	MouseClick("left", 1247, 664, 1, 2)

	; Wait for pouch to open
	Local $timer = TimerInit()
	Local $fail = False

	While PixelGetColor(1097, 535) <> 0xB3A383
		Sleep(1)
		If TimerDiff($timer) > 2000 Then
			$fail = True
			ExitLoop
		EndIf
	WEnd

	If $fail = False Then
		Send($amount)
		Send("{ENTER}")
	EndIf

	Return  Not $fail

EndFunc   ;==>WithdrawCoins

Func DropCoins()
	; wait for coins

	Local $timer = TimerInit()
	Local $pixels
	Local $fail = False
	While UBound($pixels) < 1
		$pixels = PixelSearch(1145, 413, 1177, 420, 0xFFFF00)

		If TimerDiff($timer) > 2000 Then
			$fail = True
			ExitLoop
		EndIf

		Sleep(1)
	WEnd

	If $fail = False Then
		Sleep(10)
		MouseClick("right", 1161, 427, 1, 2)
		Sleep(10)

		MouseClick("left", 1172, 486, 1, 0)

	EndIf

	Return Not $fail

EndFunc   ;==>DropCoins

Func Walk()
	MouseClick("left", 849, 255, 1, 0)
EndFunc   ;==>Walk



Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate


