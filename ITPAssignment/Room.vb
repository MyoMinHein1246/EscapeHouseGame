Public Class Room
	Private Name As String
	Public Property GetName() As String
		Get
			Return Name
		End Get
		Private Set(value As String)
			Name = value
		End Set
	End Property
	Private Text As String
	Public Property GetText() As String
		Get
			Return Text
		End Get
		Private Set(ByVal value As String)
			Text = value
		End Set
	End Property

	' TODO: add room picture

	Private AvailableRooms As List(Of String)
	Public Property GetAvailableRooms() As List(Of String)
		Get
			Return AvailableRooms
		End Get
		Private Set(ByVal value As List(Of String))
			AvailableRooms = value
		End Set
	End Property
	Public SecretQuestion As String
	Public SecretAnswer As String
	Public Hint As String
	Private HasUnlocked As Boolean = False

	Public OnRoomEntered As Action

	Public ReadOnly Property GetHasUnlocked() As Boolean
		Get
			Return HasUnlocked
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

		Public Function Build() As Room
			Dim Room As New Room With {
				.AvailableRooms = AvailableRooms,
				.Hint = Hint,
				.Name = Name,
				.OnRoomEntered = OnRoomEntered,
				.SecretAnswer = SecretAnswer,
				.SecretQuestion = SecretQuestion,
				.Text = Text
			}

			Return AddRoom(Room)
		End Function
	End Class
End Class
