Public Interface IPlayerView
	Property CurrentRoomName As String
	ReadOnly Property InventoryGroups As ListViewGroupCollection
	ReadOnly Property Inventory As ListView.ListViewItemCollection
End Interface
