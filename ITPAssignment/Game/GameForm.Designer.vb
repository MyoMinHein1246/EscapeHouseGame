<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GameForm
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		lblRoomName = New Label()
		lblNoti = New Label()
		Panel1 = New Panel()
		lblNotiCount = New Label()
		picRoom = New PictureBox()
		Label1 = New Label()
		cmbToRoom = New ComboBox()
		btnEnterRoom = New Button()
		Panel2 = New Panel()
		btnSubmitAns = New Button()
		txtAnswer = New TextBox()
		lblSecurityQuestion = New Label()
		lblSecurity = New Label()
		Panel1.SuspendLayout()
		CType(picRoom, ComponentModel.ISupportInitialize).BeginInit()
		Panel2.SuspendLayout()
		SuspendLayout()
		' 
		' lblRoomName
		' 
		lblRoomName.AutoSize = True
		lblRoomName.Font = New Font("Bookman Old Style", 20.0F, FontStyle.Bold, GraphicsUnit.Point)
		lblRoomName.Location = New Point(13, 6)
		lblRoomName.Margin = New Padding(5, 0, 5, 0)
		lblRoomName.Name = "lblRoomName"
		lblRoomName.Size = New Size(327, 40)
		lblRoomName.TabIndex = 0
		lblRoomName.Text = "Room Name Here"
		' 
		' lblNoti
		' 
		lblNoti.AutoSize = True
		lblNoti.Font = New Font("Comic Sans MS", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
		lblNoti.Location = New Point(11, 7)
		lblNoti.Margin = New Padding(4, 0, 4, 0)
		lblNoti.Name = "lblNoti"
		lblNoti.Size = New Size(121, 28)
		lblNoti.TabIndex = 1
		lblNoti.Text = "Noti here ..."
		' 
		' Panel1
		' 
		Panel1.AutoScroll = True
		Panel1.Controls.Add(lblNotiCount)
		Panel1.Controls.Add(lblNoti)
		Panel1.Dock = DockStyle.Bottom
		Panel1.Location = New Point(8, 566)
		Panel1.Margin = New Padding(5, 3, 5, 3)
		Panel1.Name = "Panel1"
		Panel1.Padding = New Padding(8, 6, 8, 6)
		Panel1.Size = New Size(1002, 104)
		Panel1.TabIndex = 2
		' 
		' lblNotiCount
		' 
		lblNotiCount.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
		lblNotiCount.AutoEllipsis = True
		lblNotiCount.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
		lblNotiCount.Location = New Point(10, 101)
		lblNotiCount.Name = "lblNotiCount"
		lblNotiCount.Size = New Size(144, 21)
		lblNotiCount.TabIndex = 2
		lblNotiCount.Text = "1"
		lblNotiCount.TextAlign = ContentAlignment.BottomLeft
		' 
		' picRoom
		' 
		picRoom.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
		picRoom.Image = My.Resources.Resources.smile_face_ascii
		picRoom.Location = New Point(13, 49)
		picRoom.Margin = New Padding(5, 3, 5, 3)
		picRoom.Name = "picRoom"
		picRoom.Size = New Size(512, 512)
		picRoom.SizeMode = PictureBoxSizeMode.Zoom
		picRoom.TabIndex = 3
		picRoom.TabStop = False
		' 
		' Label1
		' 
		Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		Label1.AutoSize = True
		Label1.Font = New Font("Bookman Old Style", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
		Label1.Location = New Point(530, 43)
		Label1.Margin = New Padding(4, 0, 4, 0)
		Label1.Name = "Label1"
		Label1.Size = New Size(188, 24)
		Label1.TabIndex = 4
		Label1.Text = "Available Rooms:"
		' 
		' cmbToRoom
		' 
		cmbToRoom.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		cmbToRoom.DropDownStyle = ComboBoxStyle.DropDownList
		cmbToRoom.Font = New Font("Bookman Old Style", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
		cmbToRoom.FormattingEnabled = True
		cmbToRoom.Location = New Point(535, 75)
		cmbToRoom.Margin = New Padding(4, 2, 4, 2)
		cmbToRoom.Name = "cmbToRoom"
		cmbToRoom.Size = New Size(469, 31)
		cmbToRoom.TabIndex = 5
		' 
		' btnEnterRoom
		' 
		btnEnterRoom.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		btnEnterRoom.Font = New Font("Bookman Old Style", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
		btnEnterRoom.Location = New Point(530, 112)
		btnEnterRoom.Name = "btnEnterRoom"
		btnEnterRoom.Size = New Size(470, 34)
		btnEnterRoom.TabIndex = 6
		btnEnterRoom.Text = "Enter"
		btnEnterRoom.UseVisualStyleBackColor = True
		' 
		' Panel2
		' 
		Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
		Panel2.Controls.Add(btnSubmitAns)
		Panel2.Controls.Add(txtAnswer)
		Panel2.Controls.Add(lblSecurityQuestion)
		Panel2.Controls.Add(lblSecurity)
		Panel2.Location = New Point(535, 147)
		Panel2.Margin = New Padding(4, 2, 4, 2)
		Panel2.Name = "Panel2"
		Panel2.Padding = New Padding(7, 5, 7, 5)
		Panel2.Size = New Size(470, 414)
		Panel2.TabIndex = 7
		' 
		' btnSubmitAns
		' 
		btnSubmitAns.Dock = DockStyle.Bottom
		btnSubmitAns.Font = New Font("Bookman Old Style", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
		btnSubmitAns.Location = New Point(5, 352)
		btnSubmitAns.Name = "btnSubmitAns"
		btnSubmitAns.Size = New Size(456, 34)
		btnSubmitAns.TabIndex = 3
		btnSubmitAns.Text = "Submit"
		btnSubmitAns.UseVisualStyleBackColor = True
		' 
		' txtAnswer
		' 
		txtAnswer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		txtAnswer.Font = New Font("Bookman Old Style", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
		txtAnswer.Location = New Point(9, 340)
		txtAnswer.Margin = New Padding(4, 2, 4, 2)
		txtAnswer.MaxLength = 100
		txtAnswer.Name = "txtAnswer"
		txtAnswer.Size = New Size(450, 31)
		txtAnswer.TabIndex = 2
		' 
		' lblSecurityQuestion
		' 
		lblSecurityQuestion.AutoSize = True
		lblSecurityQuestion.Font = New Font("Bookman Old Style", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
		lblSecurityQuestion.Location = New Point(8, 33)
		lblSecurityQuestion.Name = "lblSecurityQuestion"
		lblSecurityQuestion.Size = New Size(99, 23)
		lblSecurityQuestion.TabIndex = 1
		lblSecurityQuestion.Text = "Question"
		' 
		' lblSecurity
		' 
		lblSecurity.AutoSize = True
		lblSecurity.Font = New Font("Bookman Old Style", 14.0F, FontStyle.Bold, GraphicsUnit.Point)
		lblSecurity.Location = New Point(8, 5)
		lblSecurity.Name = "lblSecurity"
		lblSecurity.Size = New Size(126, 28)
		lblSecurity.TabIndex = 0
		lblSecurity.Text = "Security:"
		' 
		' btnPlayer
		' 
		btnPlayer.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		btnPlayer.Font = New Font("Bookman Old Style", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
		btnPlayer.Location = New Point(887, 6)
		btnPlayer.Margin = New Padding(4, 2, 4, 2)
		btnPlayer.Name = "btnPlayer"
		btnPlayer.Size = New Size(119, 34)
		btnPlayer.TabIndex = 8
		btnPlayer.Text = "&Player"
		btnPlayer.UseVisualStyleBackColor = True
		' 
		' frmRoom
		' 
		AutoScaleDimensions = New SizeF(11.0F, 28.0F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(1018, 676)
		Controls.Add(btnPlayer)
		Controls.Add(Panel2)
		Controls.Add(btnEnterRoom)
		Controls.Add(cmbToRoom)
		Controls.Add(Label1)
		Controls.Add(picRoom)
		Controls.Add(Panel1)
		Controls.Add(lblRoomName)
		Font = New Font("Segoe UI", 12.0F, FontStyle.Regular, GraphicsUnit.Point)
		FormBorderStyle = FormBorderStyle.Fixed3D
		HelpButton = True
		Margin = New Padding(5, 3, 5, 3)
		MinimumSize = New Size(1040, 727)
		Name = "GameForm"
		Padding = New Padding(8, 6, 8, 6)
		StartPosition = FormStartPosition.CenterScreen
		Text = "Escape From CODGE"
		Panel1.ResumeLayout(False)
		Panel1.PerformLayout()
		CType(picRoom, ComponentModel.ISupportInitialize).EndInit()
		Panel2.ResumeLayout(False)
		Panel2.PerformLayout()
		ResumeLayout(False)
		PerformLayout()
	End Sub

	Friend WithEvents lblRoomName As Label
	Friend WithEvents lblNoti As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents picRoom As PictureBox
	Friend WithEvents Label1 As Label
	Friend WithEvents cmbToRoom As ComboBox
	Friend WithEvents btnEnterRoom As Button
	Friend WithEvents Panel2 As Panel
	Friend WithEvents lblSecurity As Label
	Friend WithEvents lblSecurityQuestion As Label
	Friend WithEvents txtAnswer As TextBox
	Friend WithEvents btnSubmitAns As Button
	Friend WithEvents lblNotiCount As Label
	Friend WithEvents btnPlayer As Button
End Class
