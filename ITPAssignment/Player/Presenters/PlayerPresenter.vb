Public Class PlayerPresenter
	Private View As IPlayerView
	Private Model As PlayerModel

	Public Sub New(View As IPlayerView, Model As PlayerModel)
		Me.View = View
		Me.Model = Model

		ShowPlayerInventory()
	End Sub

	Public Sub ShowPlayerInventory()
		' Update View
		View.CurrentRoomName = Model.GetCurrentRoom.GetName
		View.Inventory.Clear()
		' Add items to inventory
		For Each Item In Model.Items
			Dim listViewItem As New ListViewItem({Item.GetName, Item.GetLifeTime & " Use Left"}, View.InventoryGroups.Item("gpItems"))
			View.Inventory.Add(listViewItem)
		Next
		' Add unlocked rooms to inventory
		For Each Room In Model.UnlockedRooms
			Dim listViewItem As New ListViewItem({Room.GetName, "Unlocked"}, View.InventoryGroups.Item("gpUnlockedRooms"))
			View.Inventory.Add(listViewItem)
		Next
	End Sub

	Public Function SaveInventory() As Boolean
		' TODO: save inventory to a file
	End Function

	Public Function LoadInventory() As Boolean
		' TODO: load inventory from file
	End Function
End Class
