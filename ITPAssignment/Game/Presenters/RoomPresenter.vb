﻿Public Class RoomPresenter
	' Reference to the view
	Private ReadOnly View As IRoomView
	' Reference to the model
	Private ReadOnly PlayerModel As PlayerModel
	Private ReadOnly NotiPresenter As NotiPresenter

	Public Sub New(View As IRoomView, ByRef NotiPresenter As NotiPresenter, ByRef PlayerModel As PlayerModel)
		' Assign the reference of the view
		Me.View = View
		' Clear view
		Me.View.CurrentRoomName = ""
		Me.View.SecretQuestion = ""
		Me.View.SecretAnswer = ""

		' Assign Presenters and models
		Me.NotiPresenter = NotiPresenter
		Me.PlayerModel = PlayerModel

		' Unlock and enter the default room
		Me.NotiPresenter.AddNoti("You are trapped in a room inside a house.\n You need to find your way out.\n The room you are in has THREE (3) doors, there might be something shiny on the floor just in front of you.")
		UnlockAndEnterRoom(Nothing, GetDefaultRoom.GetName)
	End Sub

	Public Function EnterRoom() As Boolean
		' Get the current specified room
		Dim Room = GetToRoom()

		' If room valid
		If Not IsNothing(Room) Then
			' If room is not default room and current room puzzle is not solved
			If Not PlayerModel.GetCurrentRoom.HasPuzzleSolved And Not Room.Equals(GetDefaultRoom) Then
				SolveCurrentRoomPuzzle()
				Return False
			End If

			' Try to enter the room
			Return EnterRoom(Room)
		End If

		Return False
	End Function

	Private Function EnterRoom(Room As RoomModel) As Boolean
		' If Room has unlocked already
		If Room.GetHasUnlocked Then
			PlayerModel.ChangeRoom(Room)

			' Update View
			View.CurrentRoomName = Room.GetName
			View.AvailableRoomsName = Room.GetAvailableRooms
			View.SecretQuestion = ""
			View.SecretAnswer = ""
			' Show noti of room's text
			NotiPresenter.AddNoti(Room.GetText)
			NotiPresenter.ShowNoti()

			If Room.HasPuzzle Then
				' Ask puzzle question if any
				AskQuestion(Room.GetPuzzle.Question)
			End If
			Return True
		End If

		Return False
	End Function

	Private Sub AskQuestion(Question As String)
		If IsNothing(Question) OrElse Question.Trim().Length = 0 Then
			Return
		End If

		View.SecretQuestion = FormatText(Question)
		View.SecretAnswer = ""
		NotiPresenter.AddNoti("Hmm... I need to solve this problem to enter other rooms.")
		NotiPresenter.ShowNoti()
	End Sub

	Public Sub TryUnlock()
		' If current room's puzzle has been solved, allow player to move to other rooms
		If PlayerModel.GetCurrentRoom.HasPuzzleSolved Then
			UnlockRoom(PlayerModel.GetItem(View.SecretAnswer), View.CurrentToRoomName)
		Else
			' If not, ask to solve puzzle
			SolveCurrentRoomPuzzle()
		End If
	End Sub

	Private Sub SolveCurrentRoomPuzzle()
		' If current room is none, or has no puzzle or has puzzle solved
		If IsNothing(PlayerModel.GetCurrentRoom) OrElse Not PlayerModel.GetCurrentRoom.HasPuzzleSolved Then
			' Do nothing
			Return
		End If

		If PlayerModel.GetCurrentRoom.SolvePuzzle(View.SecretAnswer) Then
			NotiPresenter.AddNoti("Yes! I solved it. Smart me.")
			NotiPresenter.ShowNoti(True)
		Else
			NotiPresenter.AddNoti("Wrong! Ahh... I should try again.")
			NotiPresenter.ShowNoti()
			' AskQuestion(PlayerModel.GetCurrentRoom.GetPuzzle.Question)

			If PlayerModel.GetCurrentRoom.GetPuzzle.ShouldShowHint Then
				NotiPresenter.AddNoti(PlayerModel.GetCurrentRoom.GetPuzzle.Hint)
			End If
		End If

	End Sub

	Public Function UnlockAndEnterRoom(item As ItemModel, RoomName As String) As Boolean
		If UnlockRoom(item, RoomName) Then
			' Get current specified room
			Dim Room As RoomModel = GetRoom(RoomName)

			Return EnterRoom(Room)
		End If
		Return False
	End Function

	Public Function UnlockRoom(item As ItemModel, RoomName As String) As Boolean
		' Get current specified room
		Dim Room As RoomModel = GetRoom(RoomName)

		If IsNothing(Room) Then
			Return False
		End If

		' If Unlocked
		Dim msg = ""
		If Room.UnlockRoom(item, msg) Then
			Return True
		Else
			NotiPresenter.AddNoti(msg)
			NotiPresenter.ShowNoti()
			Return False
		End If
	End Function

	Private Function GetToRoom() As RoomModel
		Return GetRoom(View.CurrentToRoomName)
	End Function
End Class
