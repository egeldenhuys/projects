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
Global $iGameX = _BombBot_FindGame("x")
Global $iGameY = _BombBot_FindGame("y")
Global $iMouseSpeed = 10
Global $sWindow = "[TITLE:RuneScape; CLASS:SunAwtFrame]"

;;; Start ;;;
While 1
	WinActivate($sWindow)
	_OpenBank()
	Sleep(100)
	_BombBot_Bank_DepositAll($iGameX, $iGameY, $iMouseSpeed)
	; HERE
	Exit 0
	Sleep(100)
WEnd

Func _OpenBank()
	MouseClick("right", $iGameX + 252, $iGameY + 85, 1, $iMouseSpeed)
	_BombBot_WaitForMenu($iGameX, $iGameY, 2000, 100)
	If Not @error Then
		_BombBot_Mouse_ClickRelative("left", 0, 45, $iMouseSpeed)
	EndIf
EndFunc   ;==>_OpenBank

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

