Public Class PuzzleModel
	Public ReadOnly Question As String
	Public ReadOnly Answer As String
	Public ReadOnly Hint As String
	Public ReadOnly Rewards As List(Of ItemModel)
	Private ReadOnly TriesBeforeHint As Integer
	Private Tries As Integer = 0
	Private HasSolved As Boolean

	Public Sub New(Question As String, Answer As String, ByRef Rewards As List(Of ItemModel), Optional Hint As String = "", Optional TriesBeforeHint As Integer = 3)
		Me.Question = Question
		Me.Answer = Answer
		Me.Rewards = Rewards
		Me.Hint = Hint
		Me.TriesBeforeHint = TriesBeforeHint
	End Sub

	Public Function ShouldShowHint() As Boolean
		' If puzzle not solved and tries has more than threshold and hint exists
		Return Tries >= TriesBeforeHint And Not HasSolved And Hint.Trim().Length > 0
	End Function

	Public Function Solve(Answer As String) As Boolean
		Tries += 1

		If Me.Answer.ToUpper.Equals(Answer.ToUpper) Then
			HasSolved = True
			Return True
		End If

		Return False
	End Function

	Public Function GetHasSolved() As Boolean
		Return HasSolved
	End Function
End Class
