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

	Public Sub New(PlayerModel As PlayerModel)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me.PlayerModel = PlayerModel
		Me.PlayerPresenter = New PlayerPresenter(Me, PlayerModel)
	End Sub
End Class