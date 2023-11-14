Public Interface IRoomView
	' Holds available rooms of current room
	Property AvailableRoomsName As List(Of String)
	' Holds current selected room of available rooms
	Property CurrentToRoomName As String
	' Holds the name of the current room user in
	Property CurrentRoomName As String
	' Holds the room picture of the current room to display
	Property RoomPicture As Image
	' Holds the puzzle questions and security of the current room
	Property SecretQuestion As String
	' Holds the answer or response of the player
	Property SecretAnswer As String
End Interface
