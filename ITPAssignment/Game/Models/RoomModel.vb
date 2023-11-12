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
	Private SecretQuestion As String
	Public ReadOnly Property GetSecretQuestion() As String
		Get
			Return SecretQuestion
		End Get
	End Property
	Public ReadOnly Property HasQA As String
		Get
			Return SecretQuestion.Trim().Length > 0
		End Get
	End Property
	Private SecretAnswer As String
	Public ReadOnly Property GetSecretAnswer() As String
		Get
			Return SecretAnswer
		End Get
	End Property
	Private Hint As String
	Public ReadOnly Property GetHint() As String
		Get
			Return Hint
		End Get
	End Property
	Private RewardItems As List(Of ItemModel)
	Public ReadOnly Property GetRewardItems() As List(Of ItemModel)
		Get
			Return RewardItems
		End Get
	End Property
	Private RequiredItems As List(Of ItemModel)
	Public ReadOnly Property GetRequiredItems() As List(Of ItemModel)
		Get
			Return RequiredItems
		End Get
	End Property
	Private HasUnlocked As Boolean = False
	Public ReadOnly Property GetHasUnlocked() As Boolean
		Get
			Return HasUnlocked
		End Get
	End Property

	Public ReadOnly Property HasRewardItems As String
		Get
			Return SecretQuestion.Trim().Length > 0
		End Get
	End Property
	Public ReadOnly Property HasRequiredItems As String
		Get
			Return SecretQuestion.Trim().Length > 0
		End Get
	End Property

	Public Function Unlock(SecretAnswer As String) As Boolean
		' If Secret Answer from player matches secret answer of this room
		If Not HasUnlocked And Me.SecretAnswer.Equals(SecretAnswer.Trim()) Then
			' Unlock the room
			HasUnlocked = True
			Return True
		End If

		' If already unlocked
		If HasUnlocked Then
			' Do nothing
			Return True
		End If

		Return False
	End Function

	Public Function GetRewards()
		If HasUnlocked Then
			' TODO: Return rewards
		End If
	End Function

	Public Class RoomBuilder
		Private Name As String
		Private Text As String
		' TODO: add room picture
		Private AvailableRooms As List(Of String)
		Private SecretQuestion As String
		Private SecretAnswer As String
		Private Hint As String
		Public OnRoomEntered As Action

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

		Public Function WithSecretQA(SecretQuestion As String, SecretAnswer As String, Optional Hint As String = "") As RoomBuilder
			Me.Hint = Hint
			Me.SecretAnswer = SecretAnswer
			Me.SecretQuestion = SecretQuestion

			Return Me
		End Function

		Public Function WithOnRoomEntered(ByVal OnRoomEntered As Action)
			Me.OnRoomEntered = OnRoomEntered

			Return Me
		End Function

		Public Function Build() As RoomModel
			Dim Room As New RoomModel With {
				.AvailableRooms = AvailableRooms,
				.Hint = Hint,
				.Name = Name,
				.SecretAnswer = SecretAnswer,
				.SecretQuestion = SecretQuestion,
				.Text = Text
			}

			Return AddRoom(Room)
		End Function
	End Class
End Class
