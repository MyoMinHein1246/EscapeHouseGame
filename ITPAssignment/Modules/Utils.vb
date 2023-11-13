Imports System.IO
Imports System.Text.Json
Imports System.Text.Json.Serialization

Module Utils
	Public Class PersistentManager
		Private Shared ReadOnly FileName As String = Path.Combine(Application.StartupPath, "Escape_From_CODGE_Data_DO_NOT_CHANGE.json")

		' Save player model to a file using JSON serialization
		Public Shared Function SaveData(Data As SaveData) As Boolean
			Try
				' Print pretty
				Dim options As New JsonSerializerOptions With {
					.WriteIndented = True
				}
				' Serialise JSON
				Dim jsonString As String = JsonSerializer.Serialize(Data, options)
				' Write to file
				File.WriteAllText(FileName, jsonString)
				ShowInfoMsgBox($"Saved successfully to: {FileName}")
				Return True
			Catch ex As Exception
				ShowErrorMsgBox($"Error saving data: {ex.Message}")
				Return False
			End Try
		End Function

		' Load player model object from a file using JSON serialization
		Public Shared Function LoadData() As SaveData
			Try
				If File.Exists(FileName) Then
					' Read file content
					Dim jsonString As String = File.ReadAllText(FileName)
					' Load JSON
					Return JsonSerializer.Deserialize(Of SaveData)(jsonString)
				Else
					' ShowErrorMsgBox("File not found. Returning an empty list.")
					Return Nothing
				End If
			Catch ex As Exception
				ShowErrorMsgBox($"Error loading data: {ex.Message}")
				Return Nothing
			End Try
		End Function
	End Class

	Public Function FormatText(Text As String, Optional NewLineIndicator As String = "\n", Optional RemoveIndicator As Boolean = True) As String
		' If text is valid
		If Not IsNothing(Text) AndAlso Not Text.Length = 0 Then
			' If new line indicator is valid
			If NewLineIndicator.Length > 0 Then
				Dim FormattedText = ""
				' Split the text using indicator
				For Each sentence As String In Text.Split(NewLineIndicator, StringSplitOptions.TrimEntries)
					' Append sentence
					FormattedText += sentence

					' If not remove indicator
					If Not RemoveIndicator Then
						' Append indicator
						FormattedText += NewLineIndicator
					End If
					' Add new line
					FormattedText += " " & vbCrLf
				Next

				Return FormattedText
			End If
			' Indicator is not valid
			Return Text
		End If
		' Text is not valid
		Return ""
	End Function

	Public Sub ShowInfoMsgBox(Message As String, Optional Title As String = "Info")
		MsgBox(Message, MsgBoxStyle.Information, Title)
	End Sub

	Public Sub ShowErrorMsgBox(Message As String, Optional Title As String = "Error")
		MsgBox(Message, MsgBoxStyle.Critical, Title)
	End Sub

	Public Class SaveData
		Implements IJsonOnDeserializing
		Public Property CurrentRoomData As RoomData
		Public Property UnlockedRoomsData As List(Of RoomData)
		Public Property ItemsData As List(Of ItemData)

		<JsonConstructor>
		Public Sub New()

		End Sub

		Public Sub OnDeserializing() Implements IJsonOnDeserializing.OnDeserializing
			CurrentRoomData = New RoomData()
			UnlockedRoomsData = New List(Of RoomData)()
			ItemsData = New List(Of ItemData)()
		End Sub
	End Class
End Module
