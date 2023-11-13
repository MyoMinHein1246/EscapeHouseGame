Imports ITPAssignment.RoomModel

Module Rooms
	Public GameRooms As New Dictionary(Of String, RoomModel)

	Private DefaultRoom As RoomModel
	' Getter for Default Room
	Public ReadOnly Property GetDefaultRoom As RoomModel
		Get
			Return DefaultRoom
		End Get
	End Property

	Public Function GetRoom(RoomName As String) As RoomModel
		If Not IsNothing(RoomName) AndAlso GameRooms.ContainsKey(RoomName) Then
			Return GameRooms(RoomName)
		End If

		Return Nothing
	End Function

	Public Function AddRoom(Room As RoomModel, Optional Replace As Boolean = False) As RoomModel
		' If replace and exist
		If Replace And GameRooms.ContainsKey(Room?.GetName) Then
			Room.RoomPicture = GameRooms.Item(Room.GetName).RoomPicture
			' Remove the room first
			GameRooms.Remove(Room.GetName)
		End If

		' If this is new room
		If Not GameRooms.ContainsKey(Room?.GetName) Then
			' If adding succeed
			If GameRooms.TryAdd(Room.GetName, Room) Then
				Return Room
			End If
		End If

		Return Nothing
	End Function

	Public Sub GenerateRooms(ByRef ResourceManager As Resources.ResourceManager)
		GeneratePuzzle()

		Dim Hall = New RoomBuilder(ResourceManager) _
							.WithName("Hall") _
							.WithText("What a Hall!") _
							.WithToRooms(New List(Of String)({"Living Room", "Store Room", "Kitchen"})) _
							.Build()

		' Make Hall the default room
		DefaultRoom = Hall

		' Other rooms
		Dim LivingRoom = New RoomBuilder(ResourceManager) _
							.WithName("Living Room") _
							.WithText("OMG! This is the biggest living room I have ever seen!") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName})) _
							.WithToRooms(New List(Of String)({"Art Room", "Bathroom 1", "Bedroom", "Computer Room"})) _
							.WithPuzzle(KeyboardPuzzle) _
							.Build()

		Dim Bathroom1 = New RoomBuilder(ResourceManager) _
							.WithName("Bathroom 1") _
							.WithText("Wow! This bathroom is so clean and it also has toilet. Hmm... What might I find here?") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName, LivingRoom.GetName})) _
							.WithPuzzle(KeyboardPuzzle) _
							.Build()
		Dim ComputerRoom = New RoomBuilder(ResourceManager) _
							.WithName("Computer Room") _
							.WithText("Holy! Look at all those computers. Hmm... What might I find here?") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName, LivingRoom.GetName})) _
							.WithToRooms(New List(Of String)({"Bathroom 2"})) _
							.WithRequiredItems(New List(Of ItemModel)({ArtRoomKey, ComputerRoomKey})) _
							.Build()
	End Sub
End Module
