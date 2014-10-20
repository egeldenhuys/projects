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
#include <Array.au3>

;; Hotkeys ;;
HotKeySet("{F1}", "_SetLoc")
HotKeySet("{F2}", "_ClickAll")
HotKeySet("{F3}", "_EnterName")
HotKeySet("{F4}", "_EnterEmail")
HotKeySet("{F5}", "Clear") ; Locations
HotKeySet("{F5}", "Clear2") ; Names
HotKeySet("{ESC}", "_Terminate")


Global $ClickArrayX[1]
Global $ClickArrayY[1]
Global $a = 0
Global $Name = ""
Global $Name2 = ""
Global $NameCounter = 1
Global $Password = ""
Global $Email = ""
Global $Email2 = ""

;;; Start Main Loop;;;
While 1

	Sleep(100)
WEnd
;;; End Main Loop;;;

func Clear()
	Global $ClickArrayX[1]
	Global $ClickArrayY[1]
	$a = 0
EndFunc

func Clear2()
	$NameCounter = 1
EndFunc

Func _EnterName()
	Send($Name & $NameCounter & $Name2)
	Send("{TAB}")
	Send($Password)
	$NameCounter += 1
EndFunc   ;==>_EnterName

Func _EnterEmail()


EndFunc   ;==>_EnterEmail


Func _SetLoc()
	_ArrayAdd($ClickArrayX, MouseGetPos(0))
	_ArrayAdd($ClickArrayY, MouseGetPos(1))
	ConsoleWrite(MouseGetPos(0) & ', ' & MouseGetPos(1) & @CRLF)
	ConsoleWrite($ClickArrayX[$a] & ', ' & $ClickArrayY[$a] & @CRLF)
	$a += 1
EndFunc   ;==>_SetLoc

Func _ClickAll()
	For $i = 1 To UBound($ClickArrayX) - 1
		MouseClick("left", $ClickArrayX[$i], $ClickArrayY[$i], 1, 0)
	Next
EndFunc   ;==>_ClickAll

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate


