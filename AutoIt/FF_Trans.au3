Opt("TrayIconHide", 1) ;0=show, 1=hide tray icon

;Func main() ; Main loop
While 1
	Local $title = WinGetTitle("[active]")
	ConsoleWrite($title & @CRLF)

	If (StringInStr($title, "YouTube") = Not 0) Then
		ConsoleWrite(WinSetTrans("[TITLE:" & $title & "]", "", 50) & @CRLF)
	Else
		ConsoleWrite(WinSetTrans("[TITLE:" & $title & "]", "", 255) & @CRLF)

		If (StringInStr($title, "Adobe Flash Player") = Not 0) Then
			ConsoleWrite(WinSetTrans("[TITLE:" & $title & "]", "", 50) & @CRLF)
		Else
			ConsoleWrite(WinSetTrans("[TITLE:" & $title & "]", "", 255) & @CRLF)
		EndIf

	EndIf



	Sleep(1000)

WEnd
;EndFunc   ;==>main



