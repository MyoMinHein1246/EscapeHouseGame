Public Class RoomPresenter
	' Reference to the view
	Private ReadOnly View As IRoomView
	' Reference to the model
	Private PlayerModel As PlayerModel
	Private ReadOnly NotiPresenter As NotiPresenter
	Private ReadOnly SoundPresenter As SoundPresenter

	Public Sub New(View As IRoomView, ByRef NotiPresenter As NotiPresenter, ByRef PlayerModel As PlayerModel, ByRef SoundPresenter As SoundPresenter)
		' Assign the reference of the view
		Me.View = View
		' Clear view
		Me.View.CurrentRoomName = ""
		Me.View.SecretQuestion = ""
		Me.View.SecretAnswer = ""

		' Assign Presenters and models
		Me.NotiPresenter = NotiPresenter
		Me.PlayerModel = PlayerModel
		Me.SoundPresenter = SoundPresenter

		' Unlock and enter the default room
		Me.NotiPresenter.AddNoti("You are trapped in a room inside a house.\n You need to find your way out.\n The room you are in has THREE (3) doors, there might be something shiny on the floor just in front of you.")
		UnlockAndEnter("", GetDefaultRoom.GetName)
	End Sub

	Public Function EnterRoom() As Boolean
		' Get the current specified room
		Dim Room = GetToRoom()

		' If room valid
		If Not IsNothing(Room) Then
			' Try to enter the room
			Return EnterRoom(Room)
		End If

		Return False
	End Function

	Private Function EnterRoom(Room As RoomModel) As Boolean
		' If Room has unlocked already
		If Room.GetHasUnlocked Then
			PlayerModel.ChangeRoom(Room)

			View.CurrentRoomName = Room.GetName
			View.AvailableRoomsName = Room.GetAvailableRooms
			NotiPresenter.AddNoti(Room.GetText)
			NotiPresenter.ShowNoti()
			Return True
		ElseIf Room.HasQA Then
			' If not unlocked and has secret questions
			' Ask secret question
			AskQuestion(Room.GetSecretQuestion)
		Else
			' If not unlocked but doesn't require questions
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
		Dim Room As RoomModel = GetRoom(RoomName)

		If IsNothing(Room) Then
			Return False
		End If

		' If Unlocked
		If Room.Unlock(Answer) Then
			EnterRoom(Room)
			Return True
		Else
			NotiPresenter.AddNoti("Ahh... Incorrect!!! I should try again.")
			NotiPresenter.AddNoti(Room.GetHint)
		End If

		Return False
	End Function

	Private Function GetToRoom() As RoomModel
		Return GetRoom(View.CurrentToRoomName)
	End Function
End Class
