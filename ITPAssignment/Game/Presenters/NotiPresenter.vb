﻿Public Class NotiPresenter
	Private ReadOnly View As INotiView
	Private ReadOnly SoundPresenter As SoundPresenter
	Private ReadOnly NotiTexts As New Queue(Of Noti)
	Private WithEvents TypingTimer As New Timer()
	Private CurrentNoti As Noti
	Private HasStarted = False

	Private Coundown As Double = 0

	Public Sub New(View As INotiView, ByRef SoundPresenter As SoundPresenter)
		Me.View = View
		Me.View.NotiText = ""
		Me.SoundPresenter = SoundPresenter
		TypingTimer.Interval = 10
		NotiTexts.Clear()
	End Sub

	Public Sub AddNotis(Texts As List(Of String), Optional Delay As Double = 5000, Optional SoundType As SoundPresenter.SoundType = SoundPresenter.SoundType.Noti, Optional Format As Boolean = True)
		For Each noti In Texts
			AddNoti(noti, Delay, SoundType, Format)
		Next
	End Sub

	Public Sub AddNoti(notiData As Noti)
		NotiTexts.Enqueue(notiData)
	End Sub

	Public Sub AddNoti(NotiText As String, Optional Delay As Double = 5000, Optional SoundType As SoundPresenter.SoundType = SoundPresenter.SoundType.Noti, Optional Format As Boolean = True)
		If Format Then
			AddNoti(New Noti(FormatText(NotiText), Delay, SoundType))
		Else
			AddNoti(New Noti(NotiText, Delay, SoundType))
		End If
		' Update View
		View.NotiCount = NotiTexts.Count.ToString()
	End Sub

	Private Sub TypingTimer_Tick(sender As Object, e As EventArgs) Handles TypingTimer.Tick
		' If Text to type does not exist
		If IsNothing(CurrentNoti) OrElse String.IsNullOrEmpty(CurrentNoti.Text) Then
			EndNoti()
			Return
		End If

		' Check if there are characters left to type
		If View.NotiText.Trim().Length < CurrentNoti.Text.Trim().Length And HasStarted Then
			View.NotiText = CurrentNoti.Text.Substring(0, View.NotiText.Length + 1)
		ElseIf View.NotiText.Trim.Equals(CurrentNoti.Text.Trim()) And HasStarted Then
			' If current noti is typed, try getting next
			If Not NotiTexts.TryDequeue(CurrentNoti) Then
				' If failed, update current noti
				CurrentNoti = Nothing
			End If
			HasStarted = False
		Else
			' Wait for delay
			Coundown -= TypingTimer.Interval
			' If delay is over
			If Coundown <= 0 Then
				' If there is noti to type
				If Not IsNothing(CurrentNoti) Then
					Coundown = CurrentNoti.Delay
					SoundPresenter.PlaySoundOnce(CurrentNoti.SoundType)
					HasStarted = True
				End If

				' Update View
				View.NotiText = ""
				View.NotiCount = NotiTexts.Count.ToString()
			End If
		End If
	End Sub

	Public Sub ShowNoti(Optional Interrupt As Boolean = False, Optional ClearInEnd As Boolean = False)
		If NotiTexts.Count = 0 Then
			Return
		End If

		If ClearInEnd Then
			AddNoti("...", 1000, Format:=False)
		End If

		If Interrupt Then
			EndNoti(True)
		End If

		If Not HasStarted Then
			CurrentNoti = NotiTexts.Dequeue
			Coundown = CurrentNoti.Delay
			SoundPresenter.PlaySoundOnce(CurrentNoti.SoundType)

			HasStarted = True
			TypingTimer.Start()
		End If
	End Sub

	Private Sub EndNoti(Optional ClearNotiText As Boolean = False, Optional ClearQueue As Boolean = False)
		If HasStarted Then
			TypingTimer.Stop()
			Coundown = 0
			HasStarted = False
			CurrentNoti = Nothing
			' Update View
			View.NotiCount = NotiTexts.Count.ToString()
		End If

		If ClearNotiText Then
			View.NotiText = ""
		End If

		If ClearQueue Then
			NotiTexts.Clear()
		End If
	End Sub

	' Holds the required data for notification
	Public Structure Noti
		Public Property Text As String
		Public Property Delay As Double
		Public Property SoundType As SoundPresenter.SoundType

		Public Sub New(Text As String, Delay As Double, SoundType As SoundPresenter.SoundType)
			Me.Text = Text
			Me.Delay = Delay
			Me.SoundType = SoundType
		End Sub
	End Structure
End Class
