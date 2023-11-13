Imports System.Media

Public Class SoundPresenter

	Public Enum SoundType
		ThemeSong = 0
		Noti = 1
		GotItem = 2
		UseItem = 3
		Unlock = 4
		RoomEnter = 5
		Wrong = 6
		GameOver = 7
	End Enum

	Private ReadOnly ResourceManager As Resources.ResourceManager

	Public Sub New(ByRef ResourceManager As Resources.ResourceManager)
		Me.ResourceManager = ResourceManager
	End Sub

	Public Sub PlaySoundOnce(Type As SoundType)
		Dim SoundName = GetSoundName(Type)

		If SoundName.Length = 0 Then
			Return
		End If

		Dim soundLocation = ResourceManager.GetStream(SoundName)

		' Check if the resource was found
		If IsNothing(soundLocation) Then
			Return
		End If

		Dim soundPlayer = New SoundPlayer(soundLocation)
		soundPlayer.Play()
	End Sub

	Public Shared Function GetSoundName(SoundType As SoundType) As String
		Select Case SoundType
			Case SoundType.ThemeSong
				Return "theme_song"
			Case SoundType.Noti
				Return "noti"
			Case SoundType.GotItem
				Return "get_item"
			Case SoundType.UseItem
				Return "use_item"
			Case SoundType.Unlock
				Return "unlock"
			Case SoundType.RoomEnter
				Return "room_enter"
			Case SoundType.Wrong
				Return "wrong"
			Case SoundType.GameOver
				Return "game_over"
			Case Else
				Return ""
		End Select
	End Function
End Class
