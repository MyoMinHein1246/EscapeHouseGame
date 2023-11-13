Module Items
	Public ComputerRoomKey As ItemModel
	Public ExitKey As ItemModel
	Public ArtRoomKey As ItemModel
	Public StoreRoomKey As ItemModel

	Public Sub GenerateItems()
		ArtRoomKey = New ItemModel("Art Room Key", 99999)
		ComputerRoomKey = New ItemModel("Computer Room Key", 1)
		ExitKey = New ItemModel("Exit Key", 1)
		StoreRoomKey = New ItemModel("Store Room Key", 5)
	End Sub
End Module
