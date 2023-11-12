Public Class RoomModel
	Private Name As String
	Public ReadOnly Property GetName() As String
		Get
			Return Name
		End Get
	End Property
	Private Text As String
	Public ReadOnly Property GetText() As String
		Get
			Return Text
		End Get
	End Property
	Private AvailableRooms As List(Of String)
	Public ReadOnly Property GetAvailableRooms() As List(Of String)
		Get
			Return AvailableRooms
		End Get
	End Property
	Private Puzzle As PuzzleModel
	Public ReadOnly Property GetPuzzle() As PuzzleModel
		Get
			Return Puzzle
		End Get
	End Property
	Public ReadOnly Property HasPuzzle() As Boolean
		Get
			Return Not IsNothing(Puzzle)
		End Get
	End Property
	Public ReadOnly Property HasPuzzleSolved() As Boolean
		Get
			Return Not HasPuzzle OrElse Puzzle.GetHasSolved
		End Get
	End Property
	Private RequiredItems As List(Of ItemModel)
	Public ReadOnly Property GetRequiredItems() As List(Of ItemModel)
		Get
			Return RequiredItems
		End Get
	End Property
	Public ReadOnly Property GetHasUnlocked() As Boolean
		Get
			Return IsNothing(RequiredItems) OrElse RequiredItems.Count = 0
		End Get
	End Property

	Public Function UnlockRoom(ByRef item As ItemModel, ByRef msg As String) As Boolean

		' If already unlocked
		If GetHasUnlocked Then
			' Do nothing
			msg = "Ohh... It's already unlocked. Perfect!"
			Return True
		End If

		' If keys or codes are required but player has none or item cannot be used
		If IsNothing(item) Then
			msg = $"'{Name}' is locked! Hmm... Seems like I will need a specific item for this one."
			Return False
		ElseIf Not item.CanUse Then
			msg = $"I cannot use '{item.GetName}' anymore."
			Return False
		End If

		' Compare required item name with player's item
		For i = 0 To RequiredItems.Count - 1
			If RequiredItems(i).Equals(item) Then
				RequiredItems.RemoveAt(i)
				' Use the item
				msg = "Yes! It worked!"
				item.Use()

				If Not GetHasUnlocked Then
					msg += " Are you kidding me? I need more items!!!"
				Else
					msg += " I can enter now."
				End If
			Else
				' Failed to unlock, readd the requirement
				msg = "Ahh... Wrong one!"
			End If
		Next

		' Whether or not player has unlocked all requirements
		Return GetHasUnlocked
	End Function

	Public Function SolvePuzzle(Answer As String) As Boolean
		Return Puzzle.Solve(Answer)
	End Function

	Public Class RoomBuilder
		Private Name As String = ""
		Private Text As String = ""
		' TODO: add room picture
		Private AvailableRooms As List(Of String) = Nothing
		Private Puzzle As PuzzleModel = Nothing
		Private RequiredItems As List(Of ItemModel) = Nothing

		Public Function WithName(Name As String) As RoomBuilder
			Me.Name = Name

			Return Me
		End Function

		Public Function WithText(Text As String) As RoomBuilder
			Me.Text = Text

			Return Me
		End Function

		Public Function WithAvailableRooms(AvailableRooms As List(Of String)) As RoomBuilder
			Me.AvailableRooms = AvailableRooms

			Return Me
		End Function

		Public Function WithPuzzle(Puzzle As PuzzleModel) As RoomBuilder
			Me.Puzzle = PuzzleModel.Copy(Puzzle)
			Return Me
		End Function

		Public Function WithRequiredItems(ByRef RequiredItems As List(Of ItemModel)) As RoomBuilder
			Me.RequiredItems = RequiredItems

			Return Me
		End Function

		Public Function Build() As RoomModel
			Dim Room As New RoomModel With {
				.AvailableRooms = AvailableRooms,
				.Name = Name,
				.Puzzle = Puzzle,
				.RequiredItems = RequiredItems,
				.Text = Text
			}

			Return AddRoom(Room)
		End Function
	End Class

	Public Overrides Function Equals(obj As Object) As Boolean
		' Try to cast the obj to RoomModel
		Dim room = TryCast(obj, RoomModel)
		' If succeed
		If Not IsNothing(room) Then
			' Compare their name
			Return Me.GetName.ToUpper.Equals(room.GetName.ToUpper)
		End If

		Return False
	End Function

	Public Overrides Function GetHashCode() As Integer
		Return HashCode.Combine(Me)
	End Function
End Class
