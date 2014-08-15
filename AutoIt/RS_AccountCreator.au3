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
HotKeySet("{F1}", "_EnterAccountDetails")
HotKeySet("{F2}", "_EnterVerifyEmail")
HotKeySet("{ESC}", "_Terminate")

Global $VerifyEmail = "rs.activate@hotmail.com"

Global $Email1 = "aa"
Global $Email2 = "@123.com"
Global $Password = "123123"
Global $Age = "46"

Global $iCounter = 12

;;; Start Main Loop;;;
While 1

	Sleep(100)
WEnd
;;; End Main Loop;;;

Func _EnterAccountDetails()
	Send($Email1 & $iCounter & $Email2)
	Send("{TAB}")
	Sleep(2000)
	Send($Email1 & $iCounter & $Email2)
	Send("{TAB}")
	Send($Password)
	Send("{TAB}")
	Send($Password)
	Send("{TAB}")
	Send($Age)

	$iCounter += 1
EndFunc   ;==>_EnterAccountDetails

Func _EnterVerifyEmail()
	Send($VerifyEmail)
EndFunc   ;==>_EnterVerifyEmail

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate



