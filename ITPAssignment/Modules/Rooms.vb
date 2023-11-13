Imports ITPAssignment.RoomModel

Module Rooms
	Public GameRooms As New Dictionary(Of String, RoomModel)

	Private DefaultRoom As RoomModel
	Private ExitRoom As RoomModel

	' Getter for Default Room
	Public ReadOnly Property GetDefaultRoom As RoomModel
		Get
			Return DefaultRoom
		End Get
	End Property

	' Getter for Default Room
	Public ReadOnly Property GetExitRoom As RoomModel
		Get
			Return ExitRoom
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
		GameRooms.Clear()
		GeneratePuzzle()

		' Create Rooms
		Dim Hall = New RoomBuilder(ResourceManager) _
							.WithName("Hall") _
							.WithText("What a Hall!") _
							.WithToRooms(New List(Of String)({"Art Room", "Kitchen", "Living Room", "Store Room"})) _
							.Build()

		Dim ExitBuilder = New RoomBuilder(ResourceManager) _
							.WithName("Exit") _
							.WithTexts(New List(Of String)({"Yay!!! I got exit! I felt so lonely in that big house.", "But man, that was some incredible experience!"})) _
							.WithToRooms(New List(Of String)({"Living Room"})) _
							.WithPuzzle(LetterEPuzzle, False) _
							.WithRequiredItems(New List(Of ItemModel)({ComputerRoomKey, ExitKey})) _
							.Build()

		' Make Hall the default room
		DefaultRoom = Hall
		ExitRoom = ExitBuilder

		' Other rooms
		Dim LivingRoom = New RoomBuilder(ResourceManager) _
							.WithName("Living Room") _
							.WithText("OMG! This is the biggest living room I have ever seen!") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName})) _
							.WithToRooms(New List(Of String)({"Bathroom 1", "Bedroom", "Computer Room", GetExitRoom.GetName})) _
							.WithPuzzle(KeyboardPuzzle) _
							.Build()
		Dim KitchenRoom = New RoomBuilder(ResourceManager) _
							.WithName("Kitchen") _
							.WithText("Smells delicious! Hmm... What might I find here?") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName})) _
							.WithToRooms(New List(Of String)({"Bathroom 2"})) _
							.WithPuzzle(FootstepPuzzle) _
							.Build()

		' End rooms without forward rooms
		Dim ArtRoom = New RoomBuilder(ResourceManager) _
							.WithName("Art Room") _
							.WithTexts(New List(Of String)({"Marvellous! Look at all these paintings! So elegant!", "Huh... Is that Mona Lisa..."})) _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName})) _
							.Build()
		Dim ComputerRoom = New RoomBuilder(ResourceManager) _
							.WithName("Computer Room") _
							.WithText("Holy! Look at all those computers. Hmm... What might I find here?") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName, LivingRoom.GetName})) _
							.WithPuzzle(CoffinPuzzle) _
							.WithRequiredItems(New List(Of ItemModel)({ArtRoomKey, ComputerRoomKey})) _
							.Build()
		Dim Bathroom1 = New RoomBuilder(ResourceManager) _
							.WithName("Bathroom 1") _
							.WithText("Wow! This bathroom is so clean and it also has toilet. Hmm... What might I find here?") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName, LivingRoom.GetName})) _
							.Build()
		Dim Bathroom2 = New RoomBuilder(ResourceManager) _
							.WithName("Bathroom 2") _
							.WithText($"Another bathroom near '{KitchenRoom.GetName}'!") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName, KitchenRoom.GetName})) _
							.Build()
		Dim Bedroom = New RoomBuilder(ResourceManager) _
							.WithName("Bedroom 1") _
							.WithText("Wah... I feel sleepy. The bed seems cozy. Hmm... What might I find here?") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName, LivingRoom.GetName})) _
							.Build()
		Dim StoreRoom = New RoomBuilder(ResourceManager) _
							.WithName("Store Room") _
							.WithText("I must not lost my way out! This is so big and messy. Hmm... What might I find here?") _
							.WithFromRooms(New List(Of String)({GetDefaultRoom.GetName})) _
							.WithPuzzle(CloudPuzzle) _
							.Build()
	End Sub
End Module
