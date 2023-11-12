Imports System.Media
Imports NAudio.Wave

Public Class SoundPresenter

	Public Enum SoundType
		ThemeSong = 0
		Noti = 1
		GotItem = 2
		UseItem = 3
		Win = 4
		Lose = 5
	End Enum

	' Create a list To store WaveOutEvent instances
	Private playingSounds As New List(Of WaveOutEvent)()
	Private playingLoopSounds As New Dictionary(Of SoundType, SoundPlayer)

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

		' Create a new WaveOutEvent instance
		Dim waveOut As New WaveOutEvent()
		' Create a WaveFileReader from the sound stream
		Dim waveReader As New WaveFileReader(soundLocation)

		' Set the reader for the WaveOutEvent
		waveOut.Init(waveReader)

		' Adjust the volume
		waveOut.Volume = 0.5F

		' Add the WaveOutEvent to the list
		playingSounds.Add(waveOut)

		' Start playing the sound
		waveOut.Play()
	End Sub

	Public Sub StopLoopSound(Type As SoundType)
		If playingLoopSounds.ContainsKey(Type) Then
			playingLoopSounds(Type).Stop()
			playingLoopSounds.Remove(Type)
		End If
	End Sub

	Public Sub PlaySoundLoop(Type As SoundType)
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
		soundPlayer.PlayLooping()
		playingLoopSounds.TryAdd(Type, soundPlayer)
	End Sub

	Public Shared Function GetSoundName(SoundType As SoundType) As String
		Select Case SoundType
			Case SoundType.ThemeSong
				Return "theme_song"
			Case SoundType.Noti
				Return "type_1"
			Case SoundType.GotItem
				Return "get_item"
			Case SoundType.UseItem
				Return "pop"
			Case SoundType.Win
				Return "win"
			Case SoundType.Lose
				Return "lose"
			Case Else
				Return ""
		End Select
	End Function
End Class
