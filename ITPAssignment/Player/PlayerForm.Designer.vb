<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayerForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim ListViewGroup1 As ListViewGroup = New ListViewGroup("Unlocked Rooms", HorizontalAlignment.Left)
		Dim ListViewGroup2 As ListViewGroup = New ListViewGroup("Items", HorizontalAlignment.Left)
		Dim ListViewItem1 As ListViewItem = New ListViewItem(New String() {"ItemName", "1 Use Left"}, -1)
		Dim ListViewItem2 As ListViewItem = New ListViewItem(New String() {"Hall", "Unlocked"}, -1)
		Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(PlayerForm))
		lblCurrentRoom = New Label()
		lsvInventory = New ListView()
		hdName = New ColumnHeader()
		hdLifeTime = New ColumnHeader()
		btnSave = New Button()
		btnLoad = New Button()
		SuspendLayout()
		' 
		' lblCurrentRoom
		' 
		lblCurrentRoom.AutoSize = True
		lblCurrentRoom.Font = New Font("Bookman Old Style", 16F, FontStyle.Bold, GraphicsUnit.Point)
		lblCurrentRoom.Location = New Point(8, 5)
		lblCurrentRoom.Name = "lblCurrentRoom"
		lblCurrentRoom.Size = New Size(213, 32)
		lblCurrentRoom.TabIndex = 0
		lblCurrentRoom.Text = "Current Room"
		' 
		' lsvInventory
		' 
		lsvInventory.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
		lsvInventory.Columns.AddRange(New ColumnHeader() {hdName, hdLifeTime})
		ListViewGroup1.Header = "Unlocked Rooms"
		ListViewGroup1.Name = "gpUnlockedRooms"
		ListViewGroup2.Header = "Items"
		ListViewGroup2.Name = "gpItems"
		lsvInventory.Groups.AddRange(New ListViewGroup() {ListViewGroup1, ListViewGroup2})
		ListViewItem1.Group = ListViewGroup2
		ListViewItem2.Group = ListViewGroup1
		lsvInventory.Items.AddRange(New ListViewItem() {ListViewItem1, ListViewItem2})
		lsvInventory.Location = New Point(8, 40)
		lsvInventory.Name = "lsvInventory"
		lsvInventory.Size = New Size(639, 366)
		lsvInventory.TabIndex = 1
		lsvInventory.UseCompatibleStateImageBehavior = False
		lsvInventory.View = View.Tile
		' 
		' hdName
		' 
		hdName.Text = "Name"
		hdName.Width = 300
		' 
		' hdLifeTime
		' 
		hdLifeTime.Text = "Status"
		hdLifeTime.Width = 100
		' 
		' btnSave
		' 
		btnSave.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
		btnSave.Location = New Point(8, 412)
		btnSave.Name = "btnSave"
		btnSave.Size = New Size(145, 40)
		btnSave.TabIndex = 2
		btnSave.Text = "&Save"
		btnSave.UseVisualStyleBackColor = True
		' 
		' btnLoad
		' 
		btnLoad.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
		btnLoad.Location = New Point(159, 412)
		btnLoad.Name = "btnLoad"
		btnLoad.Size = New Size(145, 40)
		btnLoad.TabIndex = 3
		btnLoad.Text = "&Load"
		btnLoad.UseVisualStyleBackColor = True
		' 
		' PlayerForm
		' 
		AutoScaleDimensions = New SizeF(13F, 23F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(655, 460)
		Controls.Add(btnLoad)
		Controls.Add(btnSave)
		Controls.Add(lsvInventory)
		Controls.Add(lblCurrentRoom)
		Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		FormBorderStyle = FormBorderStyle.FixedDialog
		Icon = CType(resources.GetObject("$this.Icon"), Icon)
		Margin = New Padding(5, 3, 5, 3)
		Name = "PlayerForm"
		Padding = New Padding(5)
		Text = "Player Inventory"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lblCurrentRoom As Label
	Friend WithEvents lsvInventory As ListView
	Friend WithEvents btnSave As Button
	Friend WithEvents btnLoad As Button
	Friend WithEvents hdName As ColumnHeader
	Friend WithEvents hdLifeTime As ColumnHeader
End Class
