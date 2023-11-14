Imports System.Text.Json.Serialization

Public Class ItemModel
	Private Property ItemData As New ItemData

	Public ReadOnly Property GetName As String
		Get
			Return ItemData.Name
		End Get
	End Property
	Public ReadOnly Property GetLifeTime As Integer
		Get
			Return ItemData.LifeTime
		End Get
	End Property

	<JsonConstructor>
	Public Sub New()

	End Sub

	Public Sub New(ItemData As ItemData)
		Me.ItemData = ItemData
	End Sub

	Public Sub New(Name As String, LifeTime As Integer)
		Me.ItemData = New ItemData With {
			.Name = Name,
			.LifeTime = LifeTime
		}
	End Sub

	Public Overridable Function CanUse() As Boolean
		Return GetLifeTime > 0
	End Function

	Public Overridable Sub Use()
		' If item data is not '99999', making '99999' infinite
		If Not ItemData.LifeTime = 99999 Then
			ItemData.LifeTime -= 1
		End If
	End Sub

	Public Sub Add(LifeTime As Integer)
		ItemData.LifeTime += LifeTime
	End Sub

	Public Function CopyData(Data As ItemData) As ItemModel
		Me.ItemData = Data
		Return Me
	End Function

	Public Function ComposeItemData() As ItemData
		Return New ItemData With {
			.Name = GetName,
			.LifeTime = GetLifeTime
		}
	End Function

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

' Holds the data that can be saved
Public Class ItemData
	Public Property Name As String
	Public Property LifeTime As Integer

	' Empty constructor for JSON converter
	<JsonConstructor>
	Public Sub New()

	End Sub
End Class
