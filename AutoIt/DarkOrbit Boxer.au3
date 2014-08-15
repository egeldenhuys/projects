#cs ----------------------------------------------------------------------------

	AutoIt Version: 3.3.8.1
	Author:         B0T-Maker

	Script Function:
	Runescape Template Script

	Version: 0.01

#ce ----------------------------------------------------------------------------


;; Hotkeys ;;
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

;; Global Variables ;;
Global $fPaused = False
Global $iMouseSpeed = 10
Global $sWindow = "[TITLE:DarkOrbit - Google Chrome; CLASS:Chrome_WidgetWin_1]"
Global $winLoc

WinActivate($sWindow)
$winLoc = WinGetPos("[active]")
WinSetTrans("[TITLE:DarkOrbit - Google Chrome; CLASS:Chrome_WidgetWin_1]", "", 255)

;;; Start Main Loop;;;
While 1
	WinActivate($sWindow)
	$winLoc = WinGetPos("[active]")

	$boxLoc = PixelSearch($winLoc[0], $winLoc[1], $winLoc[0] + $winLoc[2], $winLoc[1] + $winLoc[3], 0xF5FAC7, 5, 2)

	if not @Error Then
		MouseMove($boxLoc[0], $boxLoc[1], $iMouseSpeed)
	EndIf

	Sleep(100)
WEnd
;;; End Main Loop;;;

Func _TogglePause()
	$fPaused = Not $fPaused

	While $fPaused = True
		Sleep(1000)
	WEnd
EndFunc   ;==>_TogglePause

Func _Terminate()
	Exit 0
EndFunc   ;==>_Terminate

