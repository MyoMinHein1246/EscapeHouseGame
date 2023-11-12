Public Interface IPlayerView
	Property AvailableRoomsName As List(Of String)
	Property CurrentToRoomName As String
	Property CurrentRoomName As String
	' TODO: add room picture
	Property SecretQuestion As String
	Property SecretAnswer As String
End Interface
