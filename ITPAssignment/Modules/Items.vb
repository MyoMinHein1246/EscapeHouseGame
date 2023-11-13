Module Items
	Public ComputerRoomKey As ItemModel
	Public ArtRoomKey As ItemModel

	Public Sub GenerateItems()
		ComputerRoomKey = New ItemModel("Computer Room Key", 1)
		ArtRoomKey = New ItemModel("Art Room Key", 2)
	End Sub
End Module
