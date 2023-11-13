Imports System.Text.Json.Serialization

Public Class PlayerModel
	Private PlayerData As PlayerData
	Public ReadOnly Property GetItems() As List(Of ItemModel)
		Get
			Return PlayerData.Items
		End Get
	End Property
	Public ReadOnly Property GetUnlockedRooms() As List(Of RoomModel)
		Get
			Return PlayerData.UnlockedRooms
		End Get
	End Property

	Private ReadOnly NotiPresenter As NotiPresenter

	Public ReadOnly Property GetCurrentRoom() As RoomModel
		Get
			Return PlayerData.CurrentRoom
		End Get
	End Property

	Public Sub New(NotiPresenter As NotiPresenter, CurrentRoom As RoomModel, Optional Items As List(Of ItemModel) = Nothing, Optional UnlockedRooms As List(Of RoomModel) = Nothing)
		' Initialise values
		PlayerData = New PlayerData() With {
						.Items = If(Items, New List(Of ItemModel)()),
						.UnlockedRooms = If(UnlockedRooms, New List(Of RoomModel)()),
						.CurrentRoom = CurrentRoom
					}

		Me.NotiPresenter = NotiPresenter
	End Sub

	Public Sub ClaimItems(rewards As List(Of ItemModel))
		If IsNothing(rewards) Then
			Return
		End If

		For Each reward In rewards
			ClaimItem(reward)
		Next
	End Sub

	Public Sub ClaimItem(Item As ItemModel)
		NotiPresenter.AddNoti($"Wow! I found a new item.\n '{Item.GetName}' was added to your inventory.")
		GetItems.Add(Item)
	End Sub

	Public Function GetItem(ItemName As String) As ItemModel
		For Each item In GetItems
			If item.GetName.ToUpper.Equals(ItemName.ToUpper) Then
				Return item
			End If
		Next

		Return Nothing
	End Function

	Public Sub ChangeRoom(Room As RoomModel)
		PlayerData.CurrentRoom = Room

		For Each UnlockedRoom In GetUnlockedRooms
			' If this room is already unlocked
			If UnlockedRoom.Equals(Room) Then
				' Do nothing
				Return
			End If
		Next

		' Otherwise, add this to unlocked rooms
		GetUnlockedRooms.Add(Room)
	End Sub

	Friend Function LoadPlayerData(PlayerData As SaveData) As Boolean
		' Update noti
		NotiPresenter.ShowNoti(True, True)
		' Update unlocked rooms
		Me.PlayerData.UnlockedRooms.Clear()
		For Each roomData In PlayerData.UnlockedRoomsData
			Me.PlayerData.UnlockedRooms.Add(New RoomModel.RoomBuilder(Nothing).WithRoomData(roomData).Build(True))
		Next
		' Update items
		Me.PlayerData.Items.Clear()
		For Each itemData In PlayerData.ItemsData
			Me.PlayerData.Items.Add(New ItemModel(itemData))
		Next
		Dim currentRoom = GetRoom(PlayerData.CurrentRoomData.Name)
		If Not IsNothing(currentRoom) Then
			' Update current room
			Me.PlayerData.CurrentRoom.CopyData(currentRoom.ComposeRoomData())
			' Update room picture
			Me.PlayerData.CurrentRoom.RoomPicture = currentRoom.RoomPicture
		End If

		Return True
	End Function

	Friend Function ComposeSaveData() As SaveData
		Return New SaveData With {
			.ItemsData = If(GetItems.Select(Function(item) item.ComposeItemData()).ToList(), New List(Of ItemData)()),
			.UnlockedRoomsData = If(GetUnlockedRooms.Select(Function(room) room.ComposeRoomData()).ToList(), New List(Of RoomData)()),
			.CurrentRoomData = GetCurrentRoom.ComposeRoomData()
		}
	End Function
End Class

Public Class PlayerData
	Public Property CurrentRoom As RoomModel
	Public Property Items As List(Of ItemModel)
	Public Property UnlockedRooms As List(Of RoomModel)

	<JsonConstructor>
	Public Sub New()

	End Sub
End Class
