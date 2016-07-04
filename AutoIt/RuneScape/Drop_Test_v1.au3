#cs ----------------------------------------------------------------------------
	
	AutoIt Version: 3.3.9.0 (beta)
	Author:         myName
	
	Script Function:
	Template AutoIt script.
	
#ce ----------------------------------------------------------------------------

#cs
	TODO:
	
#ce

;; Includes ;;
#include "BombBot.au3"

;; Hotkeys ;;
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

;; Variables ;;
Global $fPaused = False
;Global $iGameX = _BombBot_FindGame("x")
;Global $iGameY = _BombBot_FindGame("y")
Global $iMouseSpeed = 10

; Runescape.exe = "[TITLE:RuneScape; CLASS:SunAwtFrame]"
; Chrome = "[TITLE:RuneScape - MMORPG - The No.1 Free Online Multiplayer Game - Google Chrome; CLASS:Chrome_WidgetWin_1]"

Global $sWindow = "[TITLE:RuneScape - MMORPG - The No.1 Free Online Multiplayer Game - Google Chrome; CLASS:Chrome_WidgetWin_1]"

;;; Start ;;;
While 1
	WinActivate($sWindow)
	Sleep(3000)
	ToolTip("Started", 1120, 432)
	_BombBot_Drop_FromMenu()
	Exit 0

	Sleep(100)
WEnd
;;; End ;;;

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

