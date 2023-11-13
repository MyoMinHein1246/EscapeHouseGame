Public Class PlayerPresenter
	Private ReadOnly View As IPlayerView
	Private ReadOnly Model As PlayerModel
	Private ReadOnly RoomPresenter As RoomPresenter

	Public Sub New(View As IPlayerView, Model As PlayerModel, ByRef RoomPresenter As RoomPresenter)
		Me.View = View
		Me.Model = Model
		Me.RoomPresenter = RoomPresenter

		ShowPlayerInventory()
	End Sub

	Public Sub ShowPlayerInventory()
		' Update View
		View.CurrentRoomName = Model.GetCurrentRoom.GetName
		View.Inventory.Clear()
		' Add items to inventory
		For Each Item In Model.GetItems
			Dim listViewItem As New ListViewItem({Item.GetName, Item.GetLifeTime & " Use Left"}, View.InventoryGroups.Item("gpItems"))
			View.Inventory.Add(listViewItem)
		Next
		' Add unlocked rooms to inventory
		For Each Room In Model.GetUnlockedRooms
			' If room puzzle solved, "Unlocked", else, "Puzzled"
			Dim RoomStatus = If(Room.HasPuzzleSolved, "Unlocked", "Puzzled")
			Dim listViewItem As New ListViewItem({Room.GetName, RoomStatus}, View.InventoryGroups.Item("gpUnlockedRooms"))
			View.Inventory.Add(listViewItem)
		Next
	End Sub

	Public Function SavePlayerData() As Boolean
		Return PersistentManager.SaveData(Model.ComposeSaveData())
	End Function

	Public Function LoadPlayerData() As Boolean
		Dim data As SaveData = PersistentManager.LoadData()
		If Not IsNothing(data) Then
			If Model.LoadPlayerData(data) Then
				RoomPresenter.EnterRoom(Model.GetCurrentRoom)
				ShowPlayerInventory()
			End If
			Return True
		End If

		Return False
	End Function
End Class
