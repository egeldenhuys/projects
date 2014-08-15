#cs ----------------------------------------------------------------------------

	AutoIt Version: 3.3.8.1
	Author:         myName

	Script Function:
	Template AutoIt script.

#ce ----------------------------------------------------------------------------

; Script Start - Add your code below here

HotKeySet("{F1}", "_Spam")
HotKeySet("{ESC}", "_Terminate")

While 1

	Sleep(100)
WEnd

Func _Spam()

	For $i = 1 To 720 Step 1
		Send("aepgse", 1)
		Send("{ENTER}")
	Next

EndFunc   ;==>_Spam

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate