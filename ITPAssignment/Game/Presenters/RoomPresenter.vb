﻿Public Class RoomPresenter
	' Reference to the view
	Private ReadOnly View As IRoomView
	' Reference to the model
	Private PlayerModel As PlayerModel
	Private ReadOnly NotiPresenter As NotiPresenter
	Private ReadOnly SoundPresenter As SoundPresenter

	Public Sub New(View As IRoomView, ByRef NotiPresenter As NotiPresenter, ByRef PlayerModel As PlayerModel, ByRef SoundPresenter As SoundPresenter)
		' Assign the reference of the view
		Me.View = View
		Me.View.CurrentRoomName = ""
		Me.View.SecretQuestion = ""
		Me.View.SecretAnswer = ""

		Me.NotiPresenter = NotiPresenter
		Me.PlayerModel = PlayerModel
		Me.SoundPresenter = SoundPresenter

		UnlockAndEnter("", GetDefaultRoom.GetName)
	End Sub

	Public Function EnterRoom() As Boolean
		Dim Room = GetToRoom()

		If Not IsNothing(Room) Then
			Return EnterRoom(Room)
		End If

		Return False
	End Function

	Private Function EnterRoom(Room As Room) As Boolean
		If Room.GetHasUnlocked Then
			PlayerModel.ChangeRoom(Room)

			View.CurrentRoomName = Room.GetName
			View.AvailableRoomsName = Room.GetAvailableRooms
			NotiPresenter.AddNoti(Room.GetText)
			NotiPresenter.ShowNoti()
			Return True
		ElseIf Room.HasQA Then
			AskQuestion(Room.SecretQuestion)
		Else
			UnlockAndEnter("", Room.GetName)
		End If

		Return False
	End Function

	Private Sub AskQuestion(Question As String)
		If IsNothing(Question) OrElse Question.Trim().Length = 0 Then
			Return
		End If

		View.SecretQuestion = Question
		View.SecretAnswer = ""
		NotiPresenter.AddNoti("Hmm... I need to solve this problem to enter the room.")
		NotiPresenter.ShowNoti()
	End Sub

	Public Sub AnswerQuestion()
		UnlockAndEnter(View.SecretAnswer, View.CurrentToRoomName)
	End Sub

	Public Function UnlockAndEnter(Answer As String, RoomName As String) As Boolean
		' Get current specified room
		Dim Room As Room = GetRoom(RoomName)

		If IsNothing(Room) Then
			Return False
		End If

		' If Unlocked
		If Room.Unlock(Answer) Then
			EnterRoom(Room)
			Return True
		Else
			NotiPresenter.AddNoti("Ahh... Incorrect!!! I should try again.")
			NotiPresenter.AddNoti(Room.Hint)
		End If

		Return False
	End Function

	Private Function GetToRoom() As Room
		Return GetRoom(View.CurrentToRoomName)
	End Function
End Class