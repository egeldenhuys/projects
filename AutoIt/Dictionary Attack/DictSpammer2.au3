;; Hotkeys ;;
HotKeySet("{F1}", "_Start")
HotKeySet("{F2}", "_Stop")
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

Global $fPaused = False
Global $fStopped = False

;;; Start Main Loop;;;
While 1

	Sleep(100)
WEnd
;;; End Main Loop;;;

Func _Start()
	$fStopped = False
	Local $wordsDone = 0

	Local $hFile = FileOpen("Words.txt")
	Local $line

	While $fStopped = False
		$wordsDone += 1
		$line = FileReadLine($hFile)
		Send($wordsDone & " " & $line, 1)
		Send("{ENTER}")
	WEnd

	FileClose($hFile)

EndFunc   ;==>_Start

Func _Stop()
	$fStopped = True

EndFunc   ;==>_Stop


Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

