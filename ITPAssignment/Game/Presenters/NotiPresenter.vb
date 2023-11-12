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

	Public Sub AddNoti(NotiText As String, Optional Format As Boolean = True)
		If Format Then
			NotiTexts.Enqueue(FormatText(NotiText))
		Else
			NotiTexts.Enqueue(NotiText)
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
