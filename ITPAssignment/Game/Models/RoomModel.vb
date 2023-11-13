Imports System.Text.Json.Serialization

Public Class RoomModel
	Private RoomData As RoomData
	Public RoomPicture As Image
	Public ReadOnly Property GetName() As String
		Get
			Return RoomData.Name
		End Get
	End Property

	Public ReadOnly Property GetTexts() As List(Of String)
		Get
			Return RoomData.Texts
		End Get
	End Property

	Public ReadOnly Property GetFromRooms() As List(Of String)
		Get
			Return RoomData.FromRooms
		End Get
	End Property

	Public ReadOnly Property HasFromRooms As Boolean
		Get
			Return Not IsNothing(GetFromRooms) AndAlso GetFromRooms.Count > 0
		End Get
	End Property

	Public ReadOnly Property GetToRooms() As List(Of String)
		Get
			Return RoomData.ToRooms
		End Get
	End Property

	Public ReadOnly Property HasToRooms As Boolean
		Get
			Return Not IsNothing(GetToRooms) AndAlso GetToRooms.Count > 0
		End Get
	End Property

	Public ReadOnly Property GetAvailableRooms() As List(Of String)
		Get
			' If previous rooms are not null, and no room to go forward
			If HasFromRooms And Not HasToRooms Then
				' Return previous rooms
				Return GetFromRooms
			End If
			' If previous rooms are null but forward room are not
			If HasToRooms And Not HasFromRooms Then
				' Return forward rooms
				Return GetToRooms
			End If

			' If both room type are not null
			' Return both
			Return GetToRooms.Concat(GetFromRooms).ToList()
		End Get
	End Property

	Public ReadOnly Property GetPuzzle() As PuzzleModel
		Get
			Return RoomData.Puzzle
		End Get
	End Property

	Public ReadOnly Property HasPuzzle() As Boolean
		Get
			Return Not IsNothing(GetPuzzle)
		End Get
	End Property

	Public ReadOnly Property HasPuzzleSolved() As Boolean
		Get
			Return Not HasPuzzle OrElse GetPuzzle.HasSolved
		End Get
	End Property

	Public ReadOnly Property GetRequiredItems() As List(Of ItemModel)
		Get
			Return RoomData.RequiredItems
		End Get
	End Property

	Public ReadOnly Property GetHasUnlocked() As Boolean
		Get
			Return IsNothing(GetRequiredItems) OrElse GetRequiredItems.Count = 0
		End Get
	End Property

	Public Function UnlockRoom(ByRef item As ItemModel, ByRef Noti As NotiPresenter.Noti) As Boolean

		' If already unlocked
		If GetHasUnlocked Then
			' Do nothing
			Noti.Text = "Ohh... It's already unlocked. Perfect!"
			Noti.Delay = 1000
			Noti.SoundType = SoundPresenter.SoundType.Unlock
			Return True
		End If

		' If keys or codes are required but player has none or item cannot be used
		If IsNothing(item) Then
			Noti.Text = $"'{RoomData.Name}' is locked! Hmm... Seems like I will need a specific item for this one."
			Noti.SoundType = SoundPresenter.SoundType.Wrong
			Return False
		ElseIf Not item.CanUse Then
			Noti.Text = $"No. I cannot use '{item.GetName}' anymore."
			Noti.SoundType = SoundPresenter.SoundType.Wrong
			Return False
		End If

		' Compare required item name with player's item
		For index As Integer = 0 To GetRequiredItems.Count - 1
			If GetRequiredItems(index).Equals(item) Then
				' Use the item
				Noti.Text = "Yes! It worked!"
				Noti.SoundType = SoundPresenter.SoundType.UseItem
				item.Use()
				GetRequiredItems.RemoveAt(index)

				If Not GetHasUnlocked Then
					Noti.Text += " Are you kidding me? I need more items!!!"
				Else
					Noti.Text += " I can enter now."
				End If
				Exit For
			Else
				' Failed to unlock, readd the requirement
				Noti.Text = "Ahh... Wrong one!"
				Noti.SoundType = SoundPresenter.SoundType.Wrong
			End If
		Next

		' Whether or not player has unlocked all requirements
		Return GetHasUnlocked
	End Function

	Public Function SolvePuzzle(Answer As String) As Boolean
		Return GetPuzzle.Solve(Answer)
	End Function

	Public Function IsForwardRoom(RoomName As String) As Boolean
		If Not HasToRooms Or IsNothing(RoomName) Then
			Return False
		End If

		For Each ForwardRoom In GetToRooms
			If ForwardRoom.ToUpper.Equals(RoomName.ToUpper) Then
				Return True
			End If
		Next

		Return False
	End Function

	Public Function CopyData(Data As RoomData) As RoomModel
		Me.RoomData = Data
		Return Me
	End Function

	Public Function ComposeRoomData() As RoomData
		Return New RoomData With {
			.Name = GetName,
			.Texts = GetTexts,
			.FromRooms = GetFromRooms,
			.ToRooms = GetToRooms,
			.Puzzle = GetPuzzle,
			.RequiredItems = GetRequiredItems
		}
	End Function

	Public Class RoomBuilder
		Private RoomData As New RoomData
		Private RoomPicture As Image
		Private ReadOnly ResourceManager

		Public Sub New(ByRef ResourceManager As Resources.ResourceManager)
			Me.ResourceManager = ResourceManager
		End Sub

		Public Function WithRoomPicture(Picture As Image) As RoomBuilder
			Me.RoomPicture = Picture

			Return Me
		End Function

		Public Function WithName(Name As String) As RoomBuilder
			Me.RoomData.Name = Name

			Return WithRoomPicture(DirectCast(ResourceManager.GetObject(Name.Replace(" ", "")), Image))
		End Function

		Public Function WithText(Text As String) As RoomBuilder
			RoomData.Texts.Add(Text)

			Return Me
		End Function

		Public Function WithTexts(Texts As List(Of String)) As RoomBuilder
			RoomData.Texts = Texts

			Return Me
		End Function

		Public Function WithFromRooms(FromRooms As List(Of String)) As RoomBuilder
			RoomData.FromRooms = FromRooms

			Return Me
		End Function

		Public Function WithToRooms(ToRooms As List(Of String)) As RoomBuilder
			RoomData.ToRooms = ToRooms

			Return Me
		End Function

		Public Function WithPuzzle(Puzzle As PuzzleModel, Optional CopyRewards As Boolean = True) As RoomBuilder
			RoomData.Puzzle = PuzzleModel.Copy(Puzzle, CopyRewards)
			Return Me
		End Function

		Public Function WithRequiredItems(ByRef RequiredItems As List(Of ItemModel)) As RoomBuilder
			RoomData.RequiredItems = RequiredItems

			Return Me
		End Function

		Public Function WithRoomData(RoomData As RoomData) As RoomBuilder
			Me.RoomData = RoomData

			Return Me
		End Function

		Public Function Build(Optional Replace As Boolean = False) As RoomModel
			Dim Room As New RoomModel With {
				.RoomData = Me.RoomData,
				.RoomPicture = RoomPicture
			}

			AddRoom(Room, Replace)

			Return Room
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

Public Class RoomData
	Public Property Name As String
	Public Property Texts As New List(Of String)()
	Public Property FromRooms As New List(Of String)() ' Previous Rooms
	Public Property ToRooms As New List(Of String)() ' Forward Rooms
	Public Property Puzzle As PuzzleModel
	Public Property RequiredItems As List(Of ItemModel)

	<JsonConstructor>
	Public Sub New()

	End Sub
End Class
