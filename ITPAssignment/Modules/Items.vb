Module Items
	Public ComputerRoomKey As ItemModel
	Public ExitKey As ItemModel
	Public ArtRoomKey As ItemModel

	Public Sub GenerateItems()
		ComputerRoomKey = New ItemModel("Computer Room Key", 1)
		ArtRoomKey = New ItemModel("Art Room Key", 99999)
		ExitKey = New ItemModel("Exit Key", 99999)
	End Sub
End Module
