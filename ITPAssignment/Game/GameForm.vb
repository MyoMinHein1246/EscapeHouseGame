Public Class GameForm
	Implements IRoomView, INotiView

	Public Property AvailableRoomsName As List(Of String) Implements IRoomView.AvailableRoomsName
		Get
			' Get the list in combo box
			Return cmbToRoom.Items.Cast(Of List(Of String))()
		End Get
		Set(value As List(Of String))
			' Clear the combo box
			cmbToRoom.Items.Clear()
			' Add the new value
			cmbToRoom.Items.AddRange(value.ToArray())
		End Set
	End Property

	Public Property CurrentToRoomName As String Implements IRoomView.CurrentToRoomName
		Get
			' If something is selected return it, else nothing
			Return cmbToRoom.SelectedItem?.ToString()
		End Get
		Set(value As String)
			' Change selected item to value
			cmbToRoom.SelectedItem = value
		End Set
	End Property

	Public Property CurrentRoomName As String Implements IRoomView.CurrentRoomName
		Get
			Return lblRoomName.Text
		End Get
		Set(value As String)
			lblRoomName.Text = value
		End Set
	End Property

	Public Property SecretQuestion As String Implements IRoomView.SecretQuestion
		Get
			' Get security question text
			Return lblSecurityQuestion.Text
		End Get
		Set(value As String)
			' If the value is not valid
			If IsNothing(value) OrElse value.Trim().Length = 0 Then
				' Clear the security text
				lblSecurity.Text = ""
			Else
				' Enable
				lblSecurity.Text = "Security:"
			End If
			' Change question to value
			lblSecurityQuestion.Text = value
		End Set
	End Property

	Public Property SecretAnswer As String Implements IRoomView.SecretAnswer
		Get
			Return txtAnswer.Text
		End Get
		Set(value As String)
			txtAnswer.Text = value
		End Set
	End Property

	Public Property NotiText As String Implements INotiView.NotiText
		Get
			Return lblNoti.Text
		End Get
		Set(value As String)
			lblNoti.Text = value
		End Set
	End Property

	Public Property NotiCount As String Implements INotiView.NotiCount
		Get
			Return lblNotiCount.Text
		End Get
		Set(value As String)
			lblNotiCount.Text = value
		End Set
	End Property

	Public Property RoomPicture As Image Implements IRoomView.RoomPicture
		Get
			Return picRoom.Image
		End Get
		Set(value As Image)
			picRoom.Image = value
		End Set
	End Property

	' Manages notifications
	Public NotiPresenter As NotiPresenter
	' Manages player data
	Public PlayerModel As PlayerModel
	' Manages room data
	Public RoomPresenter As RoomPresenter
	' Manages sound
	Public SoundPresenter As SoundPresenter

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Generate rooms the game has with room images from My Projects/Resources.resx
		GenerateRooms(My.Resources.ResourceManager)
		' Initialise
		SoundPresenter = New SoundPresenter(My.Resources.ResourceManager)
		NotiPresenter = New NotiPresenter(Me, SoundPresenter)

		PlayerModel = New PlayerModel(NotiPresenter, Nothing)
		RoomPresenter = New RoomPresenter(Me, NotiPresenter, PlayerModel)
	End Sub

	Private Sub btnEnterRoom_Click(sender As Object, e As EventArgs) Handles btnEnterRoom.Click
		' Enter the current selected room
		RoomPresenter.EnterRoom()
	End Sub

	Private Sub btnSubmitAns_Click(sender As Object, e As EventArgs) Handles btnSubmitAns.Click
		' If a room is selected in combo box and current room puzzle is solved try to unlock that room
		' Else try to solve the current room puzzle
		RoomPresenter.TryUnlock()
	End Sub

	Private Sub txtAnswer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnswer.KeyDown
		' If enter key pressed
		If e.KeyCode = Keys.Return Then
			' If room is selected try to unlock that room
			RoomPresenter.TryUnlock()
		End If
	End Sub

	Private Sub btnPlayer_Click(sender As Object, e As EventArgs) Handles btnPlayer.Click
		' Show player form
		Dim PlayerForm As New PlayerForm(PlayerModel, RoomPresenter)
		PlayerForm.ShowDialog(Me)
	End Sub

	Private Sub btnHowToPlay_Click(sender As Object, e As EventArgs) Handles btnHowToPlay.Click
		' Show how to play the game form
		Dim HowToPlayForm As New HowToPlayForm()
		HowToPlayForm.ShowDialog(Me)
	End Sub
End Class
