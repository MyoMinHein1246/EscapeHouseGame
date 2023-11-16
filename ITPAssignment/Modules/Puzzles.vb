Module Puzzles
	Public KeyboardPuzzle As PuzzleModel
	Public FootstepPuzzle As PuzzleModel
	Public CloudPuzzle As PuzzleModel
	Public CoffinPuzzle As PuzzleModel
	Public LetterEPuzzle As PuzzleModel
	Public FirePuzzle As PuzzleModel

	Public Sub GeneratePuzzle()
		GenerateItems()

		' Living Room
		FirePuzzle = New PuzzleModel(
			"I'm not alive, but I can grow.\n I don't have lungs, but I need air.\n I don't have a mouth, but water kills me.\n What am I?",
			"Fire",
			New List(Of ItemModel) From {StoreRoomKey},
			"Boy, am I hot!",
			5
		)

		' Bedroom
		KeyboardPuzzle = New PuzzleModel(
			"I have keys but open no locks.\n I have space but no room.\n You can enter, but you can't go inside.\n What am I?",
			"Keyboard",
			New List(Of ItemModel) From {ComputerRoomKey},
			"I am usually pressed."
		)

		' Kitchen
		FootstepPuzzle = New PuzzleModel(
			"The more you take, the more you leave behind.\n What am I?",
			"Footstep",
			New List(Of ItemModel) From {ComputerRoomKey},
			"I am usually on the ground.",
			5
		)

		' Store Room
		CloudPuzzle = New PuzzleModel(
			"I fly without wings, I cry without eyes.\n Wherever I go, darkness follows me.\n What am I?",
			"Cloud",
			New List(Of ItemModel) From {ArtRoomKey},
			"The sun can change my colour.",
			10
		)

		' Computer Room
		CoffinPuzzle = New PuzzleModel(
			"The person who makes it, sells it.\n The person who buys it never uses it.\n The person who uses it never knows they're using it.\n What is it?",
			"Coffin",
			New List(Of ItemModel) From {ExitKey},
			15
		)

		' Exit
		LetterEPuzzle = New PuzzleModel(
			"The beginning of eternity, the end of time and space.\n The beginning of every end, and the end of every place.\n What am I?\n (Please solve this final puzzle to win the game.)",
			"E",
			New List(Of ItemModel) From {ExitKey},
			10
		)
	End Sub
End Module
