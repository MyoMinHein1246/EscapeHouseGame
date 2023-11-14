Public Class RoomPresenter
	' Reference to the view
	Private ReadOnly View As IRoomView
	' Reference to the model
	Private ReadOnly PlayerModel As PlayerModel
	Private ReadOnly NotiPresenter As NotiPresenter
	Private GameOver As Boolean = False

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
		EnterRoom(GetDefaultRoom)
	End Sub

	Public Function EnterRoom() As Boolean
		' Get the current specified room
		Dim Room = GetToRoom()

		' If room valid
		If Not IsNothing(Room) Then
			' If room is forward room and current room puzzle is not solved
			If Not PlayerModel.GetCurrentRoom.HasPuzzleSolved And PlayerModel.GetCurrentRoom.IsForwardRoom(Room.GetName) Then
				AskQuestion(PlayerModel.GetCurrentRoom.GetPuzzle.Question)
				Return False
			End If

			' Try to enter the room
			Return EnterRoom(Room)
		End If

		Return False
	End Function

	Public Function EnterRoom(Room As RoomModel) As Boolean
		' If Room has unlocked already
		If Room.GetHasUnlocked Then
			PlayerModel.ChangeRoom(Room)

			' Update View
			View.CurrentRoomName = Room.GetName
			View.AvailableRoomsName = Room.GetAvailableRooms
			View.SecretQuestion = ""
			View.SecretAnswer = ""
			View.RoomPicture = Room.RoomPicture
			' Show noti of room's text
			NotiPresenter.AddNotis(Room.GetTexts, SoundType:=SoundPresenter.SoundType.RoomEnter)
			NotiPresenter.ShowNoti(True)

			If Not Room.HasPuzzleSolved Then
				' Ask puzzle question if any
				AskQuestion(Room.GetPuzzle.Question)
			End If

			' Has player entered exit room?
			CheckGameOver()
			Return True
		End If

		' If not unlocked
		' Update View
		View.SecretQuestion = "Please enter the item name to be used: "
		View.SecretAnswer = ""
		' Noti player
		NotiPresenter.AddNoti("Ahh... I can't enter this room. It's locked! I need something to unlock it.", SoundType:=SoundPresenter.SoundType.Wrong)
		NotiPresenter.ShowNoti(ClearInEnd:=True)
		Return False
	End Function

	Private Sub CheckGameOver()
		' Show noti
		If HasGameOver() Then
			ShowInfoMsgBox("Congratulations! The game is over!", "Game Over")
			NotiPresenter.AddNoti("You can wonder around this marvellous house freely!", SoundType:=SoundPresenter.SoundType.GameOver)
			NotiPresenter.ShowNoti(ClearInEnd:=True)
		ElseIf IsInExitRoom() Then
			NotiPresenter.AddNoti("Ahh... I need to solve this puzzle to WIN! I am sick of these puzzles!!!")
			NotiPresenter.ShowNoti()
		End If
	End Sub

	Private Function HasGameOver() As Boolean
		Return IsInExitRoom() AndAlso PlayerModel.GetCurrentRoom.HasPuzzleSolved
	End Function

	Private Function IsInExitRoom() As Boolean
		Return PlayerModel.GetCurrentRoom.Equals(GetExitRoom)
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
		' If current room's puzzle has been solved, try to unlock selected room in combo box
		If PlayerModel.GetCurrentRoom.HasPuzzleSolved Then
			' Split the response into array using comma
			For Each item In View.SecretAnswer.Split(", ", StringSplitOptions.TrimEntries)
				' If valid string
				If Not String.IsNullOrEmpty(item) Then
					' Try to get the item from player, whether or not has been claimed
					Dim ItemModel = PlayerModel.GetItem(item)
					' If not has claimed, not in inventory
					If IsNothing(ItemModel) Then
						' Show noti
						NotiPresenter.AddNoti($"Ohh... I don't have '{item}' in my inventory.", SoundType:=SoundPresenter.SoundType.Wrong)
						NotiPresenter.ShowNoti(ClearInEnd:=True)
					End If

					' Try to unlock the room using the item, even if it's nothing
					UnlockRoom(ItemModel, View.CurrentToRoomName)
				End If
			Next
		Else
			' If current room puzzle is not solved, solve current puzzle
			SolveCurrentRoomPuzzle()
		End If
	End Sub

	Private Sub SolveCurrentRoomPuzzle()
		' If current room is none, or has no puzzle or has puzzle solved
		If IsNothing(PlayerModel.GetCurrentRoom) OrElse PlayerModel.GetCurrentRoom.HasPuzzleSolved Then
			' Do nothing
			Return
		End If

		' If the player successfully solbed the puzzle
		If PlayerModel.GetCurrentRoom.SolvePuzzle(View.SecretAnswer) Then
			' Grant player rewards
			PlayerModel.ClaimItems(PlayerModel.GetCurrentRoom.GetPuzzle.Rewards)
			' Update View
			View.SecretQuestion = ""
			View.SecretAnswer = ""
			' Stop previous noti
			NotiPresenter.AddNoti("Yes! I solved it. Smart me.", 2000, SoundPresenter.SoundType.Unlock)
			' Show noti of room's text
			NotiPresenter.AddNotis(PlayerModel.GetCurrentRoom.GetTexts, SoundType:=SoundPresenter.SoundType.RoomEnter)
			' Show noti
			NotiPresenter.ShowNoti(True)
		Else
			' Show noti
			NotiPresenter.AddNoti("Wrong! Ahh... I should try again.", 2000, SoundPresenter.SoundType.Wrong)
			' Ask Question again????
			' AskQuestion(PlayerModel.GetCurrentRoom.GetPuzzle.Question)

			' If player might need hint
			If PlayerModel.GetCurrentRoom.GetPuzzle.ShouldShowHint Then
				' Show hint
				NotiPresenter.AddNoti("HINT: " & PlayerModel.GetCurrentRoom.GetPuzzle.Hint)
			End If
			' Show pending notis
			NotiPresenter.ShowNoti(True)
		End If
	End Sub

	Public Function UnlockAndEnterRoom(item As ItemModel, RoomName As String) As Boolean
		' If unlocked the room
		If UnlockRoom(item, RoomName) Then
			' Get current specified room
			Dim Room As RoomModel = GetRoom(RoomName)
			' Enter the room
			Return EnterRoom(Room)
		End If
		Return False
	End Function

	Public Function UnlockRoom(item As ItemModel, RoomName As String) As Boolean
		' Get current specified room
		Dim Room As RoomModel = GetRoom(RoomName)
		' If room is invalid
		If IsNothing(Room) Then
			Return False
		End If
		' Error or success noti, will be updated by Room.UnlockRoom
		Dim noti As New NotiPresenter.Noti With {
			.Text = "",
			.SoundType = SoundPresenter.SoundType.Noti,
			.Delay = 5000
		}
		' Try unlock
		Dim HasUnlocked = Room.UnlockRoom(item, noti)
		' Show error or success noti
		NotiPresenter.AddNoti(noti)

		' If room has been unlocked and the item is expired
		If HasUnlocked AndAlso Not IsNothing(item) AndAlso Not item.CanUse Then
			NotiPresenter.AddNoti($"Oh... I can't use '{item.GetName}' anymore.", 3000, SoundPresenter.SoundType.Wrong)
		End If
		' Show pending noti
		NotiPresenter.ShowNoti(True, True)
		Return HasUnlocked
	End Function

	Private Function GetToRoom() As RoomModel
		' Get the current selected room
		Return GetRoom(View.CurrentToRoomName)
	End Function
End Class
