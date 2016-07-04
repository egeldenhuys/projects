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

;; Hotkeys ;;
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

;; Global Variables ;;
Global $fPaused = False
Global $iMouseSpeed = 10
Global $sWindow = "[TITLE:SMARTv8.3 - SMART Minimizing Autoing Resource Thing - By BenLand100 [2600]]"

#cs Windows
	Runescape Client = "[TITLE:RuneScape; CLASS:SunAwtFrame]"
	Google Chrome = "[TITLE:RuneScape - MMORPG - The No.1 Free Online Multiplayer Game - Google Chrome; CLASS:Chrome_WidgetWin_1]"
#ce

;;; Start Main Loop;;;
While 1
	WinActivate($sWindow)
	GetText()
WEnd
;;; End Main Loop;;;

Func GetText()
	Local $x1, $x2, $y1, $y2

	$pixelA = PixelSearch(621, 845, 1173, 860, 0x7FA9FF, 20)
	ConsoleWrite($pixelA[0] & ", " & $pixelA[1] & @CRLF)

	If Not @error Then
		MouseMove($a[0], $a[1], 0)
	EndIf



EndFunc   ;==>GetText

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

