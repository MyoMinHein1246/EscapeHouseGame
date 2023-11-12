Public Class NotiPresenter
	Private ReadOnly View As INotiView
	Private ReadOnly SoundPresenter As SoundPresenter
	Private ReadOnly NotiTexts As New Queue(Of String)
	Private IsShowing As Boolean = False

	Public Sub New(View As INotiView, ByRef SoundPresenter As SoundPresenter)
		Me.View = View
		Me.View.NotiText = ""
		Me.SoundPresenter = SoundPresenter
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

				NotiTexts.Enqueue(FormattedText)
			Else
				NotiTexts.Enqueue(NotiText)
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

		IsShowing = True

		While NotiTexts.Count > 0
			View.NotiText = NotiTexts.Dequeue()
			If Not IsNothing(SoundPresenter) Then
				SoundPresenter.PlaySoundOnce(SoundPresenter.SoundType.Noti)
			End If

			Await Task.Delay(5000)
		End While

		IsShowing = False
	End Sub
End Class
