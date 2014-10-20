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

;; Hotkeys ;;
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

HotKeySet("{F5}", "PasteName")
HotKeySet("{F6}", "Increase")
HotKeySet("{F7}", "PasteEmail")
HotKeySet("{F8}", "Decrease")

;; Variables ;;
Global $fPaused = False
Global $iCount = ""
Global $iMouseSpeed = 10
Global $sWindow = "[TITLE:RuneScape; CLASS:SunAwtFrame]"

;;; Start ;;;
While 1

	Sleep(1000)
WEnd

Func PasteEmail()
	Send("", 1)
	Sleep(100)
	Send("{TAB}", 0)
	Sleep(100)
	Send("", 1)
	Sleep(100)
	Send("{ENTER}")
	Sleep(100)
EndFunc   ;==>PasteEmail

Func PasteName()
	Send("" & $iCount & "", 1)
	Sleep(100)
	; $iCount += 1
	Send("{TAB}", 0)
	Sleep(100)
	Send("123123", 1)
	Sleep(100)
	;Send("{ENTER}", 0)
	;Sleep(100)
EndFunc   ;==>PasteName

Func Decrease()
	$iCount -= 1
EndFunc   ;==>Decrease

Func Increase()
	$iCount += 1
EndFunc   ;==>Increase

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

