#cs ----------------------------------------------------------------------------

	AutoIt Version: 3.3.8.1
	Author:         myName

	Script Function:
	Template AutoIt script.

#ce ----------------------------------------------------------------------------

; Script Start - Add your code below here

HotKeySet("^+!1", "_Suicide") ; Control + Shift + Alt + 1
;HotKeySet("{ESC}", "_Terminate")

While 1

	Sleep(100)
WEnd

Func _Suicide()
	Send("{ESC}")
	sleep(10)
	Send("{ENTER}")
	sleep(10)
	Send("{ENTER}")
EndFunc   ;==>Suicide


Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate