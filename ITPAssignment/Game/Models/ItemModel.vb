Public MustInherit Class ItemModel
	Protected Name As String
	Protected LifeTime As Integer

	Public MustOverride ReadOnly Property GetName As String
	Public MustOverride ReadOnly Property GetLifeTime As Integer

	Public Overridable Function CanUse() As Boolean
		Return LifeTime > 0
	End Function

	Public Overridable Sub Use()
		LifeTime -= 1
	End Sub

	Public Overrides Function Equals(obj As Object) As Boolean
		' Try to cast the obj to ItemModel
		Dim item = TryCast(obj, ItemModel)
		' If succeed
		If Not IsNothing(item) Then
			' Compare their name
			Return Me.GetName.ToUpper.Equals(item.GetName.ToUpper)
		End If

		Return False
	End Function
End Class

Public Class KeyItemModel
	Inherits ItemModel

	Public Sub New(Name As String, LifeTime As Integer)
		Me.Name = Name
		Me.LifeTime = LifeTime
	End Sub

	Public Overrides ReadOnly Property GetName As String
		Get
			Return Name
		End Get
	End Property

	Public Overrides ReadOnly Property GetLifeTime As Integer
		Get
			Return LifeTime
		End Get
	End Property
End Class

Public Class PasswordItemModel
	Inherits ItemModel

	Private ReadOnly Value As String

	Public Sub New(Name As String, Value As String, LifeTime As Integer)
		Me.Name = Name
		Me.Value = Value
		Me.LifeTime = LifeTime
	End Sub

	Public Overrides ReadOnly Property GetName As String
		Get
			Return Name
		End Get
	End Property

	Public ReadOnly Property GetValue As String
		Get
			Return Value
		End Get
	End Property

	Public Overrides ReadOnly Property GetLifeTime As Integer
		Get
			Return LifeTime
		End Get
	End Property
End Class
