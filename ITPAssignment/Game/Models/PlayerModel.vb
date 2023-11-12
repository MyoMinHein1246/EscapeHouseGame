Public Class PlayerModel
	Private CurrentRoom As RoomModel
	Public ReadOnly Property GetCurrentRoom() As RoomModel
		Get
			Return CurrentRoom
		End Get
	End Property

	' TODO: items

	Public Sub New(CurrentRoom As RoomModel)
		Me.CurrentRoom = CurrentRoom
	End Sub

	Public Sub ChangeRoom(Room As RoomModel)
		CurrentRoom = Room
	End Sub
End Class
