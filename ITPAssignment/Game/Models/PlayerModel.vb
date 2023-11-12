Public Class PlayerModel
	Private CurrentRoom As RoomModel
	Private ReadOnly Items As List(Of ItemModel)

	Public ReadOnly Property GetCurrentRoom() As RoomModel
		Get
			Return CurrentRoom
		End Get
	End Property

	Public Sub New(CurrentRoom As RoomModel)
		Items = New List(Of ItemModel)()
		Me.CurrentRoom = CurrentRoom
	End Sub

	Public Function GetItem(ItemName As String) As ItemModel
		For Each item In Items
			If item.GetName.ToUpper.Equals(ItemName.ToUpper) Then
				Return item
			End If
		Next

		Return Nothing
	End Function

	Public Sub ChangeRoom(Room As RoomModel)
		CurrentRoom = Room
	End Sub
End Class
