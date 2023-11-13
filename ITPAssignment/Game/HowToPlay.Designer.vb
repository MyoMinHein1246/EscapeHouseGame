<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HowToPlayForm
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
		Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(HowToPlayForm))
		Dim ListViewGroup1 As ListViewGroup = New ListViewGroup("Tips", HorizontalAlignment.Left)
		Dim ListViewItem1 As ListViewItem = New ListViewItem("TIP: You can always view items you have by clicking 'Player' button.")
		Dim ListViewItem2 As ListViewItem = New ListViewItem("TIP: If you don't know which items a room require, TRY BRUTE FORCE.")
		Dim ListViewItem3 As ListViewItem = New ListViewItem("TIP: Did you know that you can use more than one item by separating your input with comma.")
		Dim ListViewItem4 As ListViewItem = New ListViewItem("TIP: Win the game by solving the puzzle from 'Exit' Room.")
		Dim ListViewItem5 As ListViewItem = New ListViewItem("TIPS: Don't forget to save your progress")
		Dim ListViewGroup2 As ListViewGroup = New ListViewGroup("Credit", HorizontalAlignment.Left)
		Dim ListViewGroup3 As ListViewGroup = New ListViewGroup("Bing Image Query", HorizontalAlignment.Left)
		Dim ListViewItem6 As ListViewItem = New ListViewItem(New String() {"Sound Effect", "created using 'ChipTone'", "https://sfbgames.itch.io/chiptone"}, -1)
		Dim ListViewItem7 As ListViewItem = New ListViewItem(New String() {"Images", "created using 'Bing Image Create'", "https://www.bing.com/create"}, -1)
		Dim ListViewItem8 As ListViewItem = New ListViewItem(New String() {"Art Room Image", "magnificent view of authentic classic house's exquisite art gallery, digital art"}, -1)
		Dim ListViewItem9 As ListViewItem = New ListViewItem(New String() {"Bathroom 1 Image", "magnificent view of authentic classic house's bathroom with toilet, no doors, digital art"}, -1)
		Dim ListViewItem10 As ListViewItem = New ListViewItem(New String() {"Bathroom 2 Image", "magnificent view of authentic classic house's bathroom with basins, and 1 door way, digital art"}, -1)
		Dim ListViewItem11 As ListViewItem = New ListViewItem(New String() {"Bedroom 1 Image", "magnificent view of authentic classic house's spotless, luxurious bedroom with 1 door, digital art"}, -1)
		Dim ListViewItem12 As ListViewItem = New ListViewItem(New String() {"Computer Room Image", "magnificent view of authentic classic house's room with computers 1 door, digital art"}, -1)
		Dim ListViewItem13 As ListViewItem = New ListViewItem(New String() {"Exit Room Image", "magnificent view of authentic classic house, digital art"}, -1)
		Dim ListViewItem14 As ListViewItem = New ListViewItem(New String() {"Hall Image", "magnificent view of authentic classic house's big hall with 3 doors, digital art"}, -1)
		Dim ListViewItem15 As ListViewItem = New ListViewItem(New String() {"Kitchen Image", "magnificent view of authentic classic house's spotless kitchen with 2 door way, digital art"}, -1)
		Dim ListViewItem16 As ListViewItem = New ListViewItem(New String() {"Living Room Image", "magnificent view of authentic classic house's big living room with 6 doors, digital art"}, -1)
		Dim ListViewItem17 As ListViewItem = New ListViewItem(New String() {"Store Room Image", "magnificent view of authentic classic house's store room with full of stuff, digital art"}, -1)
		Label1 = New Label()
		Label2 = New Label()
		btnClose = New Button()
		ListView1 = New ListView()
		ListView2 = New ListView()
		ColumnHeader1 = New ColumnHeader()
		ColumnHeader2 = New ColumnHeader()
		ColumnHeader3 = New ColumnHeader()
		SuspendLayout()
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Font = New Font("Bookman Old Style", 16F, FontStyle.Bold, GraphicsUnit.Point)
		Label1.Location = New Point(8, 5)
		Label1.Name = "Label1"
		Label1.Size = New Size(500, 32)
		Label1.TabIndex = 0
		Label1.Text = "Escape From CODGE: How To Play"
		' 
		' Label2
		' 
		Label2.Location = New Point(8, 37)
		Label2.Name = "Label2"
		Label2.Size = New Size(859, 147)
		Label2.TabIndex = 1
		Label2.Text = resources.GetString("Label2.Text")
		' 
		' btnClose
		' 
		btnClose.Location = New Point(718, 593)
		btnClose.Name = "btnClose"
		btnClose.Size = New Size(149, 40)
		btnClose.TabIndex = 2
		btnClose.Text = "&Close"
		btnClose.UseVisualStyleBackColor = True
		' 
		' ListView1
		' 
		ListViewGroup1.Header = "Tips"
		ListViewGroup1.Name = "ListViewGroup1"
		ListView1.Groups.AddRange(New ListViewGroup() {ListViewGroup1})
		ListViewItem1.Group = ListViewGroup1
		ListViewItem2.Group = ListViewGroup1
		ListViewItem3.Group = ListViewGroup1
		ListViewItem4.Group = ListViewGroup1
		ListViewItem5.Group = ListViewGroup1
		ListView1.Items.AddRange(New ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5})
		ListView1.Location = New Point(8, 187)
		ListView1.MultiSelect = False
		ListView1.Name = "ListView1"
		ListView1.Size = New Size(859, 154)
		ListView1.TabIndex = 3
		ListView1.UseCompatibleStateImageBehavior = False
		ListView1.View = View.List
		' 
		' ListView2
		' 
		ListView2.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3})
		ListViewGroup2.Header = "Credit"
		ListViewGroup2.Name = "ListViewGroup1"
		ListViewGroup3.Header = "Bing Image Query"
		ListViewGroup3.Name = "ListViewGroup2"
		ListView2.Groups.AddRange(New ListViewGroup() {ListViewGroup2, ListViewGroup3})
		ListViewItem6.Group = ListViewGroup2
		ListViewItem7.Group = ListViewGroup2
		ListViewItem8.Group = ListViewGroup3
		ListViewItem9.Group = ListViewGroup3
		ListViewItem10.Group = ListViewGroup3
		ListViewItem11.Group = ListViewGroup3
		ListViewItem12.Group = ListViewGroup3
		ListViewItem13.Group = ListViewGroup3
		ListViewItem14.Group = ListViewGroup3
		ListViewItem15.Group = ListViewGroup3
		ListViewItem16.Group = ListViewGroup3
		ListViewItem17.Group = ListViewGroup3
		ListView2.Items.AddRange(New ListViewItem() {ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12, ListViewItem13, ListViewItem14, ListViewItem15, ListViewItem16, ListViewItem17})
		ListView2.Location = New Point(8, 347)
		ListView2.MultiSelect = False
		ListView2.Name = "ListView2"
		ListView2.Size = New Size(859, 240)
		ListView2.TabIndex = 4
		ListView2.UseCompatibleStateImageBehavior = False
		ListView2.View = View.Details
		' 
		' ColumnHeader1
		' 
		ColumnHeader1.Text = "Item"
		ColumnHeader1.Width = 300
		' 
		' ColumnHeader2
		' 
		ColumnHeader2.Text = "Source"
		ColumnHeader2.Width = 300
		' 
		' ColumnHeader3
		' 
		ColumnHeader3.Text = "Link"
		ColumnHeader3.Width = 300
		' 
		' HowToPlayForm
		' 
		AutoScaleDimensions = New SizeF(13F, 23F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(875, 641)
		Controls.Add(ListView2)
		Controls.Add(ListView1)
		Controls.Add(btnClose)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		FormBorderStyle = FormBorderStyle.FixedDialog
		HelpButton = True
		Icon = CType(resources.GetObject("$this.Icon"), Icon)
		Margin = New Padding(5, 3, 5, 3)
		MaximizeBox = False
		Name = "HowToPlayForm"
		Padding = New Padding(5)
		Text = "Escape From CODGE: How To Play"
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents btnClose As Button
	Friend WithEvents ListView1 As ListView
	Friend WithEvents ListView2 As ListView
	Friend WithEvents ColumnHeader1 As ColumnHeader
	Friend WithEvents ColumnHeader2 As ColumnHeader
	Friend WithEvents ColumnHeader3 As ColumnHeader
End Class
