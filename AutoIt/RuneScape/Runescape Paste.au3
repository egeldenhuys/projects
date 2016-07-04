HotKeySet("{F6}", "_PasteText")
HotKeySet("{F7}", "_ToggleEnter")
HotKeySet("{F8}", "_ToggleRemoveLastChar")
HotKeySet("{F9}", "_Quit")

Global $fEnterPress = False
Global $fRemoveLast = False
While 1
	Sleep(5000)
WEnd

Func _PasteText()

	; If WinActive("[TITLE:RuneScape; CLASS:SunAwtFrame; INSTANCE:1]") Then
		$sText = ClipGet()

		If $fRemoveLast = True Then
			$sText = StringTrimRight($sText, 2)
		EndIf

		Send($sText, 1)
		If $fEnterPress = True Then
			Send("{ENTER}")
		EndIf
	; EndIf

EndFunc   ;==>_PasteText

Func _ToggleEnter()
	$fEnterPress = Not $fEnterPress
EndFunc   ;==>_ToggleEnter

Func _ToggleRemoveLastChar()
	$fRemoveLast = Not $fRemoveLast
EndFunc   ;==>_ToggleRemoveLastChar

Func _Quit()

	If WinActive("[TITLE:RuneScape; CLASS:SunAwtFrame; INSTANCE:1]") Then
		Exit 0
	EndIf

EndFunc   ;==>_Quit
