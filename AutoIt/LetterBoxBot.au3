#include <Inet.au3>
#include <Array.au3>

;; Hotkeys ;;
HotKeySet("{F1}", "_GetWords")
HotKeySet("{F2}", "_GetWords2")
HotKeySet("{F3}", "_GetWords3")
HotKeySet("{F4}", "_Start")
HotKeySet("{PAUSE}", "_TogglePause")
HotKeySet("{ESC}", "_Terminate")

Global $fPaused = False
Global $fStopped = False
Global $asWords[1]

;;; Start Main Loop;;;
While 1

	Sleep(100)
WEnd
;;; End Main Loop;;;

Func _GetWords()
	Local $sLetters = InputBox("Input", "SOURCE 1. letters to build words from:")
	If @error = 0 Then
		Local $sRawData = _INetGetSource("http://www.wineverygame.com/wbg.php?letters=" & $sLetters & "&lettersh=" & $sLetters & "&preffix=&preffixh=&oa=or&suffix=&suffixh=&submit=View+Words&pr=")
		Local $aRawDataLines = StringSplit($sRawData, @CRLF)

		Local $aSubStrings

		; Extract the words from the raw data lines

		For $element In $aRawDataLines

			If StringInStr($element, "word/meaning/") = 40 Then
				$aSubStrings = StringSplit($element, ">")
				$aSubStrings = StringSplit($aSubStrings[4], "<")
				_ArrayAdd($asWords, $aSubStrings[1])
			EndIf

		Next

		MsgBox(0, "Done", "Words have been build. Select game and press F4")

	EndIf

EndFunc   ;==>_GetWords

Func _GetWords2()

	Local $sLetters = InputBox("Input", "SOURCE 2. letters to build words from:")
	If @error = 0 Then
		Local $sRawData = _INetGetSource("http://wordsolver.net/?tpl=search&setdiccookie=true&anagram=" & $sLetters & _
				"&mode=anagram&dictionary=sowpods&patternmatching=&maxresults=500&minlength=2&sorting=wordlength&sw=1920&sh=1080")

		Local $aRawDataParts = StringSplit($sRawData, "<")

		Local $aSubStrings

		; Extract the words from the raw data lines

		For $element In $aRawDataParts

			If StringInStr($element, "span style='color:black;'>") = 1 Then
				$aSubStrings = StringSplit($element, ">")
				_ArrayAdd($asWords, $aSubStrings[2])
			EndIf

		Next

		MsgBox(0, "Done", "Words have been build. Select game and press F4")
	EndIf

EndFunc   ;==>_GetWords2

func _GetWords3()
	Local $sLetters = InputBox("Input", "SOURCE 3. letters to build words from:")
	If @error = 0 Then
		Local $sRawData = _INetGetSource("http://wordsolver.net/?tpl=search&setdiccookie=true&anagram=" & $sLetters & _
				"&mode=anagram&dictionary=twl&patternmatching=&maxresults=500&minlength=2&sorting=wordlength&sw=1920&sh=1080")

		Local $aRawDataParts = StringSplit($sRawData, "<")

		Local $aSubStrings

		; Extract the words from the raw data lines

		For $element In $aRawDataParts

			If StringInStr($element, "span style='color:black;'>") = 1 Then
				$aSubStrings = StringSplit($element, ">")
				_ArrayAdd($asWords, $aSubStrings[2])
			EndIf

		Next

		MsgBox(0, "Done", "Words have been build. Select game and press F4")
	EndIf

EndFunc


Func _Start()

	For $sWord In $asWords
		Send($sWord, 1)
		Send("{ENTER}")
	Next

	MsgBox(0, "Done", "All words has been sent")
	Dim $asWords[2]
	$asWords[0] = "A"
	$asWords[1] = "B"

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

