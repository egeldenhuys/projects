#cs ----------------------------------------------------------------------------
	
	AutoIt Version: 3.3.9.0 (beta)
	Author:         myName
	
	Script Function:
	Template AutoIt script.
	
#ce ----------------------------------------------------------------------------

HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")
HotKeySet("{ENTER}", "_WriteText")

Global $fPaused = False

#cs
	== Laptop Ad ==
	Global $iGameX = 257
	Global $iGameY = 122
	
	== Computer Ad ==
	Global $iGameX = 300
	Global $iGameY = 116
#ce
;;;; Variables ;;;;

Global $iGameX = 299
Global $iGameY = 163
Global $sEffect = "Cyan:"
Global $bRandomEffects = True

;;;; Start ;;;;
While 1
	; WinActivate("[TITLE:SwiftKit for RuneScape | Integrated with Zybez; CLASS:ThunderRT6FormDC]")

	Sleep(100)
WEnd

Func _WriteText()
	; If WinActive("[TITLE:SwiftKit for RuneScape | Integrated with Zybez; CLASS:ThunderRT6FormDC]") = True Then
	If WinActive("[TITLE:RuneScape; CLASS:SunAwtFrame]") = True Then
		Local $iRndNum = Int(Random(5)) + 1

		HotKeySet("{Enter}") ; Unregister hotkey
		Send("{Enter}") ; Send current text
		HotKeySet("{Enter}", "_WriteText") ; Register hotkey

		If $bRandomEffects = True Then
			Select
				Case $iRndNum = 1
					Send("White:")
				Case $iRndNum = 2
					Send("Cyan:")
				Case $iRndNum = 3
					Send("Purple:")
				Case $iRndNum = 4
					Send("Green:")
				Case $iRndNum = 5
					Send("Red:")
					#cs
						Case $iRndNum = 6
						Send("Glow1:")
						Case $iRndNum = 7
						Send("Glow2:")
						Case $iRndNum = 8
						Send("Flash1:")
						Case $iRndNum = 9
						Send("Flash2:")
						Case $iRndNum = 10
						Send("Flash3:")
						Case $iRndNum = 11
						Send("Glow3:")
					#ce
			EndSelect
		Else
			Send($sEffect)
		EndIf

		; put effect in

	EndIf
EndFunc   ;==>_WriteText

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

