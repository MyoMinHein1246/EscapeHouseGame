Imports System.Reflection.Emit

Public Class NotiPresenter
	Private ReadOnly View As INotiView
	Private ReadOnly SoundPresenter As SoundPresenter
	Private ReadOnly NotiTexts As New Queue(Of String)
	Private WithEvents TypingTimer As New Timer()
	Private CurrentNotiText As String = ""
	Private HasStarted = False

	Public Sub New(View As INotiView, ByRef SoundPresenter As SoundPresenter)
		Me.View = View
		Me.View.NotiText = ""
		Me.SoundPresenter = SoundPresenter
		TypingTimer.Interval = 10
		NotiTexts.Clear()
	End Sub

	Public Sub AddNoti(NotiText As String, Optional Format As Boolean = True)
		If Format Then
			NotiTexts.Enqueue(FormatText(NotiText))
		Else
			NotiTexts.Enqueue(NotiText)
		End If
		' Update View
		View.NotiCount = NotiTexts.Count.ToString()
	End Sub

	Private Sub TypingTimer_Tick(sender As Object, e As EventArgs) Handles TypingTimer.Tick
		' If Text to type does not exist
		If IsNothing(CurrentNotiText) OrElse CurrentNotiText.Length = 0 Then
			EndNoti()
			Return
		End If

		' Check if there are characters left to type
		If Not CurrentNotiText.Equals(View.NotiText) Then
			' Add the next character to the label
			HasStarted = True
			View.NotiText = CurrentNotiText.Substring(0, View.NotiText.Length + 1)
		Else
			' Update View
			View.NotiCount = NotiTexts.Count.ToString()

			If NotiTexts.TryDequeue(CurrentNotiText) Then
				SoundPresenter.PlaySoundOnce(SoundPresenter.SoundType.Noti)
				View.NotiText = ""
			Else
				CurrentNotiText = ""
			End If
		End If
	End Sub

	Public Sub ShowNoti(Optional Interrupt As Boolean = False, Optional ClearInEnd As Boolean = False)
		If NotiTexts.Count = 0 Then
			Return
		End If

		If ClearInEnd Then
			AddNoti(" ", False)
		End If

		If Interrupt Then
			EndNoti(True)
		End If
		SoundPresenter.PlaySoundOnce(SoundPresenter.SoundType.Noti)

		If Not HasStarted Then
			CurrentNotiText = NotiTexts.Dequeue
			TypingTimer.Start()
		End If
	End Sub

	Private Sub EndNoti(Optional ClearNotiText As Boolean = False)
		If HasStarted Then
			TypingTimer.Stop()
			HasStarted = False
			CurrentNotiText = ""
			' Update View
			View.NotiCount = NotiTexts.Count.ToString()
		End If

		If ClearNotiText Then
			View.NotiText = ""
		End If
	End Sub
End Class
