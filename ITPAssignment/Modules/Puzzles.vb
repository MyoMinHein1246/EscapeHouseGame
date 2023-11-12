Module Puzzles
	Public KeyboardPuzzle As PuzzleModel

	Public Sub GeneratePuzzle()
		GenerateItems()

		KeyboardPuzzle = New PuzzleModel("I have keys but open no locks.\n I have space but no room.\n You can enter, but you can't go inside.\n What am I?",
										 "Keyboard",
										 New List(Of ItemModel) From {ComputerRoomKey},
										 "I am usually pressed."
										 )
	End Sub
End Module
