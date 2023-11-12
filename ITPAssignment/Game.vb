Public Class frmRoom
	Implements IPlayerView, INotiView

	Public Property AvailableRoomsName As List(Of String) Implements IPlayerView.AvailableRoomsName
		Get
			Return cmbToRoom.Items.Cast(Of List(Of String))()
		End Get
		Set(value As List(Of String))
			cmbToRoom.Items.Clear()
			cmbToRoom.Items.AddRange(value.ToArray())
		End Set
	End Property

	Public Property CurrentAvailableRoomName As String Implements IPlayerView.CurrentAvailableRoomName
		Get
			Return cmbToRoom.SelectedItem.ToString()
		End Get
		Set(value As String)
			cmbToRoom.SelectedItem = value
		End Set
	End Property

	Public Property CurrentRoomName As String Implements IPlayerView.CurrentRoomName
		Get
			Return lblRoomName.Text
		End Get
		Set(value As String)
			lblRoomName.Text = value
		End Set
	End Property

	Public Property SecretQuestion As String Implements IPlayerView.SecretQuestion
		Get
			Return lblSecurityQuestion.Text
		End Get
		Set(value As String)
			If IsNothing(value) OrElse value.Trim().Length = 0 Then
				lblSecurity.Text = ""
			Else
				lblSecurity.Text = "Security:"
			End If

			lblSecurityQuestion.Text = value
		End Set
	End Property

	Public Property SecretAnswer As String Implements IPlayerView.SecretAnswer
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

	Public PlayerPresenter As PlayerPresenter

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		PlayerPresenter = New PlayerPresenter(Me, Me)

		PlayerPresenter.UnlockAndEnter("", GetDefaultRoom.GetName)
	End Sub

	Private Sub btnEnterRoom_Click(sender As Object, e As EventArgs) Handles btnEnterRoom.Click

	End Sub

	Private Sub btnSubmitAns_Click(sender As Object, e As EventArgs) Handles btnSubmitAns.Click

	End Sub
End Class
