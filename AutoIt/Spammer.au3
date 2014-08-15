#include <Inet.au3>
#include <Array.au3>

;; Hotkeys ;;
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

Global $fPaused = False
Global $fStopped = False
Global $asWords[1]


_TogglePause()
;;; Start Main Loop;;;
While 1

	Send("{t}")
	Sleep(100)
	Send("{UP}")
	Sleep(100)
	Send("{ENTER}")
	Sleep(100)

	;Sleep(100)
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

