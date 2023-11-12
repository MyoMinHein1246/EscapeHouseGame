Imports ITPAssignment.Room

Module Rooms
	Public GameRooms As New Dictionary(Of String, Room)

	Public ReadOnly Property GetDefaultRoom As Room

	Public Function GetRoom(RoomName As String) As Room
		If GameRooms.ContainsKey(RoomName) Then
			Return GameRooms(RoomName)
		End If

		Return Nothing
	End Function

	Public Function AddRoom(Room As Room) As Room
		' If this is new room
		If Not GameRooms.ContainsKey(Room.GetName) Then
			' If adding succeed
			If GameRooms.TryAdd(Room.GetName, Room) Then
				Return Room
			End If
		End If

		Return Nothing
	End Function

	Sub New()

		Dim Hall = New RoomBuilder() _
							.WithName("Hall") _
							.WithText("You are trapped in a room inside a house.\n You need to find your way out.\n The room you are in has THREE (3) doors, there might be something shiny on the floor just in front of you.") _
							.WithAvailableRooms(New List(Of String) From {"Living Room", "Store Room", "Kitchen"}) _
							.WithSecretQA("", "") _
							.Build

		GetDefaultRoom = Hall

		Dim Bathroom1 = New RoomBuilder() _
							.WithName("Bathroom 1") _
							.WithText("Wow! This bathroom is so clean and it also has toilet. Hmm... What might I find here?") _
							.WithAvailableRooms(New List(Of String) From {"Hall"}) _
							.WithSecretQA("", "") _
							.Build()
	End Sub
End Module
