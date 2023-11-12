Module Items
	Public ComputerRoomKey As KeyItemModel
	Public ArtRoomKey As KeyItemModel

	Public Sub GenerateItems()
		ComputerRoomKey = New KeyItemModel("Computer Room Key", 1)
		ArtRoomKey = New KeyItemModel("Art Room Key", 2)
	End Sub
End Module
