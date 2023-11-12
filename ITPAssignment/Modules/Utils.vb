Module Utils
	Public Function FormatText(Text As String, Optional NewLineIndicator As String = "\n", Optional RemoveIndicator As Boolean = True) As String
		' If text is valid
		If Not IsNothing(Text) AndAlso Not Text.Length = 0 Then
			' If new line indicator is valid
			If NewLineIndicator.Length > 0 Then
				Dim FormattedText = ""
				' Split the text using indicator
				For Each sentence As String In Text.Split(NewLineIndicator, StringSplitOptions.TrimEntries)
					' Append sentence
					FormattedText += sentence

					' If not remove indicator
					If Not RemoveIndicator Then
						' Append indicator
						FormattedText += NewLineIndicator
					End If
					' Add new line
					FormattedText += " " & vbCrLf
				Next

				Return FormattedText
			End If
			' Indicator is not valid
			Return Text
		End If
		' Text is not valid
		Return ""
	End Function
End Module
