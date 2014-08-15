#include <Inet.au3>
#include <Array.au3>

;; Hotkeys ;;
HotKeySet("{F1}", "_Start")
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

Global $fPaused = False
Global $fStopped = False
Global $asWords[1]

;;; Start Main Loop;;;
While 1

	Sleep(100)
WEnd
;;; End Main Loop;;;


Func _Start()
	Local $iChar
	While 1
		; send a to z
		For $i = 97 To 122
			Send("{" & Chr($i) & "}")
		Next

		; send special characters
		For $i = 33 To 46
			Send("{" & Chr($i) & "}")
		Next

		; Send space
		Send("{SPACE}")
	WEnd

EndFunc   ;==>_Start

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate


