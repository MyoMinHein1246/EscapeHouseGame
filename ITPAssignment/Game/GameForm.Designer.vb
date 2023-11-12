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
		btnPlayer = New Button()
		Panel1.SuspendLayout()
		CType(picRoom, ComponentModel.ISupportInitialize).BeginInit()
		Panel2.SuspendLayout()
		SuspendLayout()
		' 
		' lblRoomName
		' 
		lblRoomName.AutoSize = True
		lblRoomName.Font = New Font("Bookman Old Style", 20F, FontStyle.Bold, GraphicsUnit.Point)
		lblRoomName.Location = New Point(15, 5)
		lblRoomName.Margin = New Padding(6, 0, 6, 0)
		lblRoomName.Name = "lblRoomName"
		lblRoomName.Size = New Size(327, 40)
		lblRoomName.TabIndex = 0
		lblRoomName.Text = "Room Name Here"
		' 
		' lblNoti
		' 
		lblNoti.AutoSize = True
		lblNoti.Font = New Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point)
		lblNoti.Location = New Point(13, 6)
		lblNoti.Margin = New Padding(5, 0, 5, 0)
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
		Panel1.Location = New Point(9, 564)
		Panel1.Margin = New Padding(6, 2, 6, 2)
		Panel1.Name = "Panel1"
		Panel1.Padding = New Padding(9, 5, 9, 5)
		Panel1.Size = New Size(1185, 107)
		Panel1.TabIndex = 2
		' 
		' lblNotiCount
		' 
		lblNotiCount.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
		lblNotiCount.AutoEllipsis = True
		lblNotiCount.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
		lblNotiCount.Location = New Point(6, 85)
		lblNotiCount.Margin = New Padding(4, 0, 4, 0)
		lblNotiCount.Name = "lblNotiCount"
		lblNotiCount.Size = New Size(170, 17)
		lblNotiCount.TabIndex = 2
		lblNotiCount.Text = "1"
		lblNotiCount.TextAlign = ContentAlignment.BottomLeft
		' 
		' picRoom
		' 
		picRoom.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
		picRoom.Image = My.Resources.Resources.smile_face_ascii
		picRoom.Location = New Point(15, 48)
		picRoom.Margin = New Padding(6, 2, 6, 2)
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
		Label1.Font = New Font("Bookman Old Style", 12F, FontStyle.Bold, GraphicsUnit.Point)
		Label1.Location = New Point(538, 48)
		Label1.Margin = New Padding(5, 0, 5, 0)
		Label1.Name = "Label1"
		Label1.Size = New Size(188, 24)
		Label1.TabIndex = 4
		Label1.Text = "Available Rooms:"
		' 
		' cmbToRoom
		' 
		cmbToRoom.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		cmbToRoom.DropDownStyle = ComboBoxStyle.DropDownList
		cmbToRoom.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		cmbToRoom.FormattingEnabled = True
		cmbToRoom.Location = New Point(538, 74)
		cmbToRoom.Margin = New Padding(5, 2, 5, 2)
		cmbToRoom.Name = "cmbToRoom"
		cmbToRoom.Size = New Size(656, 31)
		cmbToRoom.TabIndex = 5
		' 
		' btnEnterRoom
		' 
		btnEnterRoom.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		btnEnterRoom.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btnEnterRoom.Location = New Point(538, 109)
		btnEnterRoom.Margin = New Padding(4, 2, 4, 2)
		btnEnterRoom.Name = "btnEnterRoom"
		btnEnterRoom.Size = New Size(656, 40)
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
		Panel2.Location = New Point(538, 153)
		Panel2.Margin = New Padding(5, 2, 5, 2)
		Panel2.Name = "Panel2"
		Panel2.Padding = New Padding(8, 4, 8, 4)
		Panel2.Size = New Size(656, 407)
		Panel2.TabIndex = 7
		' 
		' btnSubmitAns
		' 
		btnSubmitAns.Dock = DockStyle.Bottom
		btnSubmitAns.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btnSubmitAns.Location = New Point(8, 363)
		btnSubmitAns.Margin = New Padding(4, 2, 4, 2)
		btnSubmitAns.Name = "btnSubmitAns"
		btnSubmitAns.Size = New Size(640, 40)
		btnSubmitAns.TabIndex = 3
		btnSubmitAns.Text = "Submit"
		btnSubmitAns.UseVisualStyleBackColor = True
		' 
		' txtAnswer
		' 
		txtAnswer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		txtAnswer.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		txtAnswer.Location = New Point(13, 328)
		txtAnswer.Margin = New Padding(5, 2, 5, 2)
		txtAnswer.MaxLength = 100
		txtAnswer.Name = "txtAnswer"
		txtAnswer.Size = New Size(630, 31)
		txtAnswer.TabIndex = 2
		' 
		' lblSecurityQuestion
		' 
		lblSecurityQuestion.AutoSize = True
		lblSecurityQuestion.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		lblSecurityQuestion.Location = New Point(9, 27)
		lblSecurityQuestion.Margin = New Padding(4, 0, 4, 0)
		lblSecurityQuestion.Name = "lblSecurityQuestion"
		lblSecurityQuestion.Size = New Size(99, 23)
		lblSecurityQuestion.TabIndex = 1
		lblSecurityQuestion.Text = "Question"
		' 
		' lblSecurity
		' 
		lblSecurity.AutoSize = True
		lblSecurity.Font = New Font("Bookman Old Style", 14F, FontStyle.Bold, GraphicsUnit.Point)
		lblSecurity.Location = New Point(9, 4)
		lblSecurity.Margin = New Padding(4, 0, 4, 0)
		lblSecurity.Name = "lblSecurity"
		lblSecurity.Size = New Size(126, 28)
		lblSecurity.TabIndex = 0
		lblSecurity.Text = "Security:"
		' 
		' btnPlayer
		' 
		btnPlayer.Location = New Point(1033, 5)
		btnPlayer.Name = "btnPlayer"
		btnPlayer.Size = New Size(161, 40)
		btnPlayer.TabIndex = 8
		btnPlayer.Text = "Player"
		btnPlayer.UseVisualStyleBackColor = True
		' 
		' GameForm
		' 
		AutoScaleDimensions = New SizeF(13F, 23F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(1203, 676)
		Controls.Add(btnPlayer)
		Controls.Add(Panel2)
		Controls.Add(btnEnterRoom)
		Controls.Add(cmbToRoom)
		Controls.Add(Label1)
		Controls.Add(picRoom)
		Controls.Add(Panel1)
		Controls.Add(lblRoomName)
		Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		FormBorderStyle = FormBorderStyle.Fixed3D
		HelpButton = True
		Margin = New Padding(6, 2, 6, 2)
		MinimumSize = New Size(1225, 727)
		Name = "GameForm"
		Padding = New Padding(9, 5, 9, 5)
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
