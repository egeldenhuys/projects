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
Global $iMouseSpeed = 10
Global $sWindow = "[TITLE:RuneScape - MMORPG - The No.1 Free Online Multiplayer Game - Google Chrome; CLASS:Chrome_WidgetWin_1]"
Global $text = "[Cheap Gold] [$5 for 50k rsgp] [FreeVirus4You.C()M]"
#cs Windows
	Runescape Client = "[TITLE:RuneScape; CLASS:SunAwtFrame]"
	Google Chrome = "[TITLE:RuneScape - MMORPG - The No.1 Free Online Multiplayer Game - Google Chrome; CLASS:Chrome_WidgetWin_1]"
#ce

;;; Start Main Loop;;;
While 1
	WinActivate($sWindow)
	Send($text)
	Send("{ENTER}")
	Sleep(2000)
WEnd
;;; End Main Loop;;;

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

