Public Class PlayerModel
	Private CurrentRoom As RoomModel
	Public ReadOnly Items As List(Of ItemModel)
	Public ReadOnly UnlockedRooms As List(Of RoomModel)
	Private ReadOnly NotiPresenter As NotiPresenter

	Public ReadOnly Property GetCurrentRoom() As RoomModel
		Get
			Return CurrentRoom
		End Get
	End Property

	Public Sub New(NotiPresenter As NotiPresenter, CurrentRoom As RoomModel, Optional Items As List(Of ItemModel) = Nothing, Optional UnlockedRooms As List(Of RoomModel) = Nothing)
		' Initialise values
		If IsNothing(Items) Then
			Me.Items = New List(Of ItemModel)()
		Else
			Me.Items = Items
		End If
		If IsNothing(UnlockedRooms) Then
			Me.UnlockedRooms = New List(Of RoomModel)()
		Else
			Me.UnlockedRooms = UnlockedRooms
		End If

		Me.CurrentRoom = CurrentRoom
		Me.NotiPresenter = NotiPresenter
	End Sub

	Public Sub ClaimItems(rewards As List(Of ItemModel))
		For Each reward In rewards
			ClaimItem(reward)
		Next
	End Sub

	Public Sub ClaimItem(Item As ItemModel)
		NotiPresenter.AddNoti($"Wow! I found a new item.\n '{Item.GetName}' was added to your inventory.")
		Items.Add(Item)
	End Sub

	Public Function GetItem(ItemName As String) As ItemModel
		For Each item In Items
			If item.GetName.ToUpper.Equals(ItemName.ToUpper) Then
				Return item
			End If
		Next

		Return Nothing
	End Function

	Public Sub ChangeRoom(Room As RoomModel)
		CurrentRoom = Room

		For Each UnlockedRoom In UnlockedRooms
			' If this room is already unlocked
			If UnlockedRoom.Equals(Room) Then
				' Do nothing
				Return
			End If
		Next

		' Otherwise, add this to unlocked rooms
		UnlockedRooms.Add(Room)
	End Sub
End Class
