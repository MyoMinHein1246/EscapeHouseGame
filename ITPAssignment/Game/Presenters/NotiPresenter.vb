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

	Public Sub AddNotis(Texts As List(Of String), Optional Format As Boolean = True)
		For Each noti In Texts
			AddNoti(noti, Format)
		Next
	End Sub

	Public Sub AddNoti(NotiText As String, Optional Delay As Double = 5000, Optional Format As Boolean = True)
		If Format Then
			NotiTexts.Enqueue(New Noti(FormatText(NotiText), Delay))
		Else
			NotiTexts.Enqueue(New Noti(NotiText, Delay))
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
		If Not CurrentNoti.Equals(View.NotiText) Then
			' Add the next character to the label
			HasStarted = True
			If View.NotiText.Length + 1 <= CurrentNoti.Text.Trim().Length Then
				View.NotiText = CurrentNoti.Text.Substring(0, View.NotiText.Length + 1)
			ElseIf NotiTexts.Count > 0 Then
				Coundown -= TypingTimer.Interval
				If Coundown <= 0 Then
					CurrentNoti = NotiTexts.Dequeue()
					Coundown = CurrentNoti.Delay
					' Update View
					View.NotiCount = NotiTexts.Count.ToString()
					SoundPresenter.PlaySoundOnce(SoundPresenter.SoundType.Noti)
					View.NotiText = ""
				End If
			Else
				CurrentNoti = Nothing
			End If
		End If
	End Sub

	Public Sub ShowNoti(Optional Interrupt As Boolean = False, Optional ClearInEnd As Boolean = False)
		If NotiTexts.Count = 0 Then
			Return
		End If

		If ClearInEnd Then
			AddNoti("...", False)
		End If

		If Interrupt Then
			EndNoti(True)
		End If

		If Not HasStarted Then
			SoundPresenter.PlaySoundOnce(SoundPresenter.SoundType.Noti)
			CurrentNoti = NotiTexts.Dequeue
			Coundown = CurrentNoti.Delay
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

	Public Structure Noti
		Public Property Text As String
		Public Property Delay As Double

		Public Sub New(Text As String, Delay As Double)
			Me.Text = Text
			Me.Delay = Delay
		End Sub
	End Structure
End Class
