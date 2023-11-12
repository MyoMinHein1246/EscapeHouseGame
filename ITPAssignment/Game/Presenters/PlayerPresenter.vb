Public Class PlayerPresenter
	Private View As IPlayerView

	Public Sub New(View As IPlayerView)
		Me.View = View
	End Sub
End Class
