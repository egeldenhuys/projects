#include <Array.au3>

;; Hotkeys ;;
HotKeySet("{F1}", "_GetWords")
HotKeySet("{F2}", "_Start")
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

Global $fPaused = False
Global $aLetters[0]

;;; Start Main Loop;;;
While 1

	Sleep(100)
WEnd
;;; End Main Loop;;;

Func _GetWords()
	Local $sLetters = InputBox("Input", "letters to build words from:")

EndFunc   ;==>_GetWords

Func _Start()
	Local $hFile = FileOpen("Letters.txt")




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

