Public Class PlayerForm
	Implements IPlayerView

	Public Property CurrentRoomName As String Implements IPlayerView.CurrentRoomName
		Get
			Return lblCurrentRoom.Text
		End Get
		Set(value As String)
			lblCurrentRoom.Text = value
		End Set
	End Property

	Public ReadOnly Property Inventory As ListView.ListViewItemCollection Implements IPlayerView.Inventory
		Get
			Return lsvInventory.Items
		End Get
	End Property

	Public ReadOnly Property InventoryGroups As ListViewGroupCollection Implements IPlayerView.InventoryGroups
		Get
			Return lsvInventory.Groups
		End Get
	End Property

	Private PlayerPresenter As PlayerPresenter
	Private PlayerModel As PlayerModel

	Public Sub New(PlayerModel As PlayerModel, ByRef RoomPresenter As RoomPresenter)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me.PlayerModel = PlayerModel
		Me.PlayerPresenter = New PlayerPresenter(Me, PlayerModel, RoomPresenter)
	End Sub

	Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
		PlayerPresenter.SavePlayerData()
	End Sub

	Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
		PlayerPresenter.LoadPlayerData()
	End Sub
End Class