Public Class PlayerPresenter
	' Reference to the view
	Private ReadOnly View As IPlayerView
	' Reference to the model
	Private Model As Player
	Private NotiPresenter As NotiPresenter

	Public Sub New(View As IPlayerView, NotiView As INotiView)
		' Assign the reference of the view
		Me.View = View
		Model = New Player(GetDefaultRoom)
		NotiPresenter = New NotiPresenter(NotiView)
		Me.View.CurrentRoomName = ""
		Me.View.SecretQuestion = ""
		Me.View.SecretAnswer = ""
	End Sub

	Public Function EnterRoom(Room As Room) As Boolean
		If Room.GetHasUnlocked Then
			Model.CurrentRoom = Room
			View.CurrentRoomName = Room.GetName
			View.AvailableRoomsName = Room.GetAvailableRooms
			NotiPresenter.AddNoti(Room.GetText)
			NotiPresenter.ShowNoti()
			Return True
		Else
			AskQuestion(Room.SecretQuestion)
		End If

		Return False
	End Function

	Public Sub AskQuestion(Question As String)
		' TODO: ask if question
		View.SecretQuestion = Question
		View.SecretAnswer = ""
		NotiPresenter.AddNoti("Hmm... I need to solve this problem to enter the room.")
		NotiPresenter.ShowNoti()
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
End Class
