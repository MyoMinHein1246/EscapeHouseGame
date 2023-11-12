Public Class PlayerModel
	Private CurrentRoom As Room
	Public ReadOnly Property GetCurrentRoom() As Room
		Get
			Return CurrentRoom
		End Get
	End Property

	' TODO: items

	Public Sub New(CurrentRoom As Room)
		Me.CurrentRoom = CurrentRoom
	End Sub

	Public Sub ChangeRoom(Room As Room)
		CurrentRoom = Room
	End Sub
End Class
