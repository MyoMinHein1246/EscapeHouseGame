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

	Public Function AddRoom(Room As RoomModel) As RoomModel
		' If this is new room
		If Not GameRooms.ContainsKey(Room.GetName) Then
			' If adding succeed
			If GameRooms.TryAdd(Room.GetName, Room) Then
				Return Room
			End If
		End If

		Return Nothing
	End Function

	Public Sub GenerateRooms()
		GeneratePuzzle()

		Dim Hall = New RoomBuilder() _
							.WithName("Hall") _
							.WithText("What a Hall!") _
							.WithAvailableRooms(New List(Of String) From {"Living Room", "Store Room", "Kitchen"}) _
							.Build

		' Make Hall the default room
		DefaultRoom = Hall

		' Other rooms
		Dim LivingRoom = New RoomBuilder() _
							.WithName("Living Room") _
							.WithText("OMG! This is the biggest living room I have ever seen!") _
							.WithAvailableRooms(New List(Of String) From {GetDefaultRoom.GetName, "Art Room", "Bathroom 1", "Bedroom", "Computer Room"}) _
							.WithPuzzle(KeyboardPuzzle) _
							.Build()
		Dim Bathroom1 = New RoomBuilder() _
							.WithName("Bathroom 1") _
							.WithText("Wow! This bathroom is so clean and it also has toilet. Hmm... What might I find here?") _
							.WithAvailableRooms(New List(Of String) From {GetDefaultRoom.GetName, LivingRoom.GetName}) _
							.WithPuzzle(KeyboardPuzzle) _
							.Build()

		Dim ComputerRoom = New RoomBuilder() _
							.WithName("Computer Room") _
							.WithText("Holy! Look at all those broken computers. Hmm... What might I find here?") _
							.WithAvailableRooms(New List(Of String) From {GetDefaultRoom.GetName, LivingRoom.GetName, "Bathroom 2"}) _
							.WithRequiredItems(New Stack(Of ItemModel)({ComputerRoomKey})) _
							.Build()
	End Sub
End Module
