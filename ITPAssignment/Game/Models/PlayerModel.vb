Public Class PlayerModel
	Private CurrentRoom As RoomModel
	Private ReadOnly Items As List(Of ItemModel)
	Private ReadOnly NotiPresenter As NotiPresenter

	Public ReadOnly Property GetCurrentRoom() As RoomModel
		Get
			Return CurrentRoom
		End Get
	End Property

	Public Sub New(NotiPresenter As NotiPresenter, CurrentRoom As RoomModel)
		Items = New List(Of ItemModel)()
		Me.CurrentRoom = CurrentRoom
		Me.NotiPresenter = NotiPresenter
	End Sub

	Public Sub ClaimItems(rewards As List(Of ItemModel))
		For Each reward In rewards
			ClaimItem(reward)
		Next
	End Sub

	Public Sub ClaimItem(Item As ItemModel)
		NotiPresenter.AddNoti($"Wow! I found a new item.\n '{Item.GetName}' was added to your inventory.")
		Items.Add(Item)
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
