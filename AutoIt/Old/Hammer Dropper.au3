#cs ----------------------------------------------------------------------------
	
	AutoIt Version: 3.3.9.0 (beta)
	Author:         myName
	
	Script Function:
	Takes hammers from the crate near the furnace in lumbridge and drops it.
	
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
Global $iGameX = 300
Global $iGameY = 116
Global $iMouseSpeed = 0
Global $sWindow = "[TITLE:RuneScape; CLASS:SunAwtFrame]"

;;; Start ;;;
While 1
	WinActivate($sWindow)

	TakeHammer()
	WaitForHammer()


WEnd
;;; End ;;;

Func TakeHammer()
	MouseClick("left", 522, 283, 1, $iMouseSpeed)
EndFunc   ;==>TakeHammer

Func WaitForHammer()
	_BombBot_WaitForColour(882, 334, 0x575353, 5, 3000, 10)
	If Not @error Then
		DropHammer()
		;sleep(100)
	EndIf
EndFunc   ;==>WaitForHammer

Func DropHammer()
	MouseClick("right", 884, 332, 1, $iMouseSpeed)
	_BombBot_Mouse_ClickRelative("left", 0, 60, $iMouseSpeed)
EndFunc   ;==>DropHammer

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

