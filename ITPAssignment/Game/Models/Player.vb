Public Class Player
	Public CurrentRoom As Room

	Public ReadOnly Property GetCurrentRoom() As Room
		Get
			Return CurrentRoom
		End Get
	End Property

	' TODO: items

	Public Sub New(CurrentRoom As Room)
		Me.CurrentRoom = CurrentRoom
	End Sub
End Class
