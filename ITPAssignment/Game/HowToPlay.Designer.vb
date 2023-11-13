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
		Label1 = New Label()
		Label2 = New Label()
		btnClose = New Button()
		ListView1 = New ListView()
		SuspendLayout()
		' 
		' Label1
		' 
		Label1.AutoSize = True
		Label1.Font = New Font("Bookman Old Style", 16F, FontStyle.Bold, GraphicsUnit.Point)
		Label1.Location = New Point(8, 5)
		Label1.Name = "Label1"
		Label1.Size = New Size(189, 32)
		Label1.TabIndex = 0
		Label1.Text = "How To Play"
		' 
		' Label2
		' 
		Label2.Location = New Point(8, 37)
		Label2.Name = "Label2"
		Label2.Size = New Size(859, 165)
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
		ListView1.Items.AddRange(New ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4})
		ListView1.Location = New Point(8, 205)
		ListView1.Name = "ListView1"
		ListView1.Size = New Size(859, 382)
		ListView1.TabIndex = 3
		ListView1.UseCompatibleStateImageBehavior = False
		ListView1.View = View.List
		' 
		' HowToPlayForm
		' 
		AutoScaleDimensions = New SizeF(13F, 23F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(875, 641)
		Controls.Add(ListView1)
		Controls.Add(btnClose)
		Controls.Add(Label2)
		Controls.Add(Label1)
		Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		FormBorderStyle = FormBorderStyle.FixedDialog
		HelpButton = True
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
End Class
