Module Puzzles
	Public KeyboardPuzzle As PuzzleModel
	Public FootstepPuzzle As PuzzleModel
	Public CloudPuzzle As PuzzleModel
	Public CoffinPuzzle As PuzzleModel
	Public LetterEPuzzle As PuzzleModel

	Public Sub GeneratePuzzle()
		GenerateItems()

		KeyboardPuzzle = New PuzzleModel(
			"I have keys but open no locks.\n I have space but no room.\n You can enter, but you can't go inside.\n What am I?",
			"Keyboard",
			New List(Of ItemModel) From {ComputerRoomKey},
			"I am usually pressed."
		)

		FootstepPuzzle = New PuzzleModel(
			"The more you take, the more you leave behind.\n What am I?",
			"Footstep",
			New List(Of ItemModel) From {ComputerRoomKey},
			"I am usually on the ground."
		)

		CloudPuzzle = New PuzzleModel(
			"I fly without wings, I cry without eyes.\n Wherever I go, darkness follows me.\n What am I?",
			"Cloud",
			New List(Of ItemModel) From {ArtRoomKey},
			"The sun can change my colour."
		)

		CoffinPuzzle = New PuzzleModel(
			"The person who makes it, sells it.\n The person who buys it never uses it.\n The person who uses it never knows they're using it.\n What is it?",
			"Coffin",
			New List(Of ItemModel) From {ExitKey}
		)

		LetterEPuzzle = New PuzzleModel(
			"The beginning of eternity, the end of time and space.\n The beginning of every end, and the end of every place.\n What am I?",
			"E",
			New List(Of ItemModel) From {ExitKey}
		)
	End Sub
End Module
