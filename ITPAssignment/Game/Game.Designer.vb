<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRoom
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
		picRoom = New PictureBox()
		Label1 = New Label()
		cmbToRoom = New ComboBox()
		btnEnterRoom = New Button()
		Panel2 = New Panel()
		btnSubmitAns = New Button()
		txtAnswer = New TextBox()
		lblSecurityQuestion = New Label()
		lblSecurity = New Label()
		lblNotiCount = New Label()
		Panel1.SuspendLayout()
		CType(picRoom, ComponentModel.ISupportInitialize).BeginInit()
		Panel2.SuspendLayout()
		SuspendLayout()
		' 
		' lblRoomName
		' 
		lblRoomName.AutoSize = True
		lblRoomName.Font = New Font("Bookman Old Style", 16F, FontStyle.Bold, GraphicsUnit.Point)
		lblRoomName.Location = New Point(11, 7)
		lblRoomName.Margin = New Padding(4, 0, 4, 0)
		lblRoomName.Name = "lblRoomName"
		lblRoomName.Size = New Size(259, 32)
		lblRoomName.TabIndex = 0
		lblRoomName.Text = "Room Name Here"
		' 
		' lblNoti
		' 
		lblNoti.AutoSize = True
		lblNoti.Font = New Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point)
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
		Panel1.Location = New Point(7, 561)
		Panel1.Margin = New Padding(4)
		Panel1.Name = "Panel1"
		Panel1.Padding = New Padding(7)
		Panel1.Size = New Size(914, 126)
		Panel1.TabIndex = 2
		' 
		' picRoom
		' 
		picRoom.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
		picRoom.Image = My.Resources.Resources.smile_face_ascii
		picRoom.Location = New Point(11, 43)
		picRoom.Margin = New Padding(4)
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
		cmbToRoom.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		cmbToRoom.FormattingEnabled = True
		cmbToRoom.Location = New Point(530, 70)
		cmbToRoom.Name = "cmbToRoom"
		cmbToRoom.Size = New Size(388, 31)
		cmbToRoom.TabIndex = 5
		' 
		' btnEnterRoom
		' 
		btnEnterRoom.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		btnEnterRoom.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btnEnterRoom.Location = New Point(530, 112)
		btnEnterRoom.Name = "btnEnterRoom"
		btnEnterRoom.Size = New Size(388, 40)
		btnEnterRoom.TabIndex = 6
		btnEnterRoom.Text = "Enter"
		btnEnterRoom.UseVisualStyleBackColor = True
		' 
		' Panel2
		' 
		Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
		Panel2.Controls.Add(btnSubmitAns)
		Panel2.Controls.Add(txtAnswer)
		Panel2.Controls.Add(lblSecurityQuestion)
		Panel2.Controls.Add(lblSecurity)
		Panel2.Location = New Point(530, 158)
		Panel2.Name = "Panel2"
		Panel2.Padding = New Padding(5)
		Panel2.Size = New Size(388, 397)
		Panel2.TabIndex = 7
		' 
		' btnSubmitAns
		' 
		btnSubmitAns.Dock = DockStyle.Bottom
		btnSubmitAns.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		btnSubmitAns.Location = New Point(5, 352)
		btnSubmitAns.Name = "btnSubmitAns"
		btnSubmitAns.Size = New Size(378, 40)
		btnSubmitAns.TabIndex = 3
		btnSubmitAns.Text = "Submit"
		btnSubmitAns.UseVisualStyleBackColor = True
		' 
		' txtAnswer
		' 
		txtAnswer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
		txtAnswer.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		txtAnswer.Location = New Point(8, 312)
		txtAnswer.MaxLength = 100
		txtAnswer.Name = "txtAnswer"
		txtAnswer.Size = New Size(372, 31)
		txtAnswer.TabIndex = 2
		' 
		' lblSecurityQuestion
		' 
		lblSecurityQuestion.AutoSize = True
		lblSecurityQuestion.Font = New Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point)
		lblSecurityQuestion.Location = New Point(8, 33)
		lblSecurityQuestion.Name = "lblSecurityQuestion"
		lblSecurityQuestion.Size = New Size(99, 23)
		lblSecurityQuestion.TabIndex = 1
		lblSecurityQuestion.Text = "Question"
		' 
		' lblSecurity
		' 
		lblSecurity.AutoSize = True
		lblSecurity.Font = New Font("Bookman Old Style", 14F, FontStyle.Bold, GraphicsUnit.Point)
		lblSecurity.Location = New Point(8, 5)
		lblSecurity.Name = "lblSecurity"
		lblSecurity.Size = New Size(126, 28)
		lblSecurity.TabIndex = 0
		lblSecurity.Text = "Security:"
		' 
		' lblNotiCount
		' 
		lblNotiCount.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
		lblNotiCount.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
		lblNotiCount.Location = New Point(10, 101)
		lblNotiCount.Name = "lblNotiCount"
		lblNotiCount.Size = New Size(122, 25)
		lblNotiCount.TabIndex = 2
		lblNotiCount.Text = "1"
		lblNotiCount.TextAlign = ContentAlignment.BottomLeft
		' 
		' frmRoom
		' 
		AutoScaleDimensions = New SizeF(11F, 28F)
		AutoScaleMode = AutoScaleMode.Font
		ClientSize = New Size(928, 694)
		Controls.Add(Panel2)
		Controls.Add(btnEnterRoom)
		Controls.Add(cmbToRoom)
		Controls.Add(Label1)
		Controls.Add(picRoom)
		Controls.Add(Panel1)
		Controls.Add(lblRoomName)
		Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
		FormBorderStyle = FormBorderStyle.Fixed3D
		Margin = New Padding(4)
		MinimumSize = New Size(950, 745)
		Name = "frmRoom"
		Padding = New Padding(7)
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
End Class
