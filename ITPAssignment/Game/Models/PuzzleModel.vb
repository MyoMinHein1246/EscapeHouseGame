Imports System.Text.Json.Serialization

Public Class PuzzleModel
	' Holds the data that can be saved
	Public Property Question As String
	Public Property Answer As String
	Public Property Hint As String
	Public Property Rewards As List(Of ItemModel)
	Public Property TriesBeforeHint As Integer
	Public Property Tries As Integer
	Public Property HasSolved As Boolean

	' Empty constructor for JSON converter
	<JsonConstructor>
	Public Sub New()

	End Sub

	Public Sub New(Question As String, Answer As String, ByRef Rewards As List(Of ItemModel), Optional Hint As String = "", Optional TriesBeforeHint As Integer = 3)
		Me.Question = Question
		Me.Answer = Answer
		Me.Rewards = Rewards
		Me.Hint = Hint
		Me.TriesBeforeHint = TriesBeforeHint
		Me.Tries = 0
	End Sub

	Public Function ShouldShowHint() As Boolean
		' If puzzle not solved and tries has more than threshold and hint exists
		Return Tries >= TriesBeforeHint And Not HasSolved And Hint.Trim().Length > 0
	End Function

	Public Function Solve(Answer As String) As Boolean
		' Update tries
		Tries += 1

		' Loop the player answer word by word
		For Each word In Answer.Split(" ", StringSplitOptions.TrimEntries)
			' If the player answer include the correct answer, whether or not current word equals to answer
			If Me.Answer.ToUpper.Equals(word.ToUpper) Then
				' Player nailed it
				HasSolved = True
				Return True
			End If
		Next
		' Wrong answer
		Return False
	End Function

	' Static function
	Public Shared Function Copy(OtherPuzzle As PuzzleModel, Optional CopyRewards As Boolean = True) As PuzzleModel
		' If other puzzle to copy is nothing
		If IsNothing(OtherPuzzle) Then
			Return Nothing
		End If

		' Return copied puzzle
		Return New PuzzleModel(
			OtherPuzzle.Question,
			OtherPuzzle.Answer,
			If(CopyRewards, OtherPuzzle.Rewards, Nothing),
			OtherPuzzle.Hint,
			OtherPuzzle.TriesBeforeHint
		)
	End Function

End Class
