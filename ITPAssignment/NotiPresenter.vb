Public Class NotiPresenter
	Private ReadOnly View As INotiView

	Private ReadOnly NotiTexts As New List(Of String)
	Private IsShowing As Boolean = False

	Public Sub New(View As INotiView)
		Me.View = View
		Me.View.NotiText = ""
	End Sub

	Public Sub AddNoti(NotiText As String, Optional NewLineIndicator As String = "\n", Optional ReplaceIndicator As Boolean = True)
		If Not IsNothing(NotiText) AndAlso Not NotiText.Trim().Length = 0 Then
			If NewLineIndicator.Length > 0 Then
				Dim FormattedText = ""
				For Each text As String In NotiText.Split(NewLineIndicator, StringSplitOptions.TrimEntries)
					FormattedText += text

					If Not ReplaceIndicator Then
						FormattedText += NewLineIndicator
					End If

					FormattedText += " " & vbCrLf
				Next

				NotiTexts.Add(FormattedText)
			Else
				NotiTexts.Add(NotiText)
			End If

		End If
	End Sub

	Public Async Sub ShowNoti(Optional ClearInEnd As Boolean = False)
		If IsShowing Then
			Return
		End If

		If ClearInEnd Then
			AddNoti("")
		End If

		Dim index As Integer = 0
		IsShowing = True

		While NotiTexts.Count > 0
			View.NotiText = NotiTexts(index)

			Await Task.Delay(5000)

			NotiTexts.RemoveAt(index)

			index += 1
		End While

		IsShowing = False
	End Sub
End Class
