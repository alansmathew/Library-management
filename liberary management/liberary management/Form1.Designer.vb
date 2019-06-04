<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginform
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(loginform))
        Me.Username = New System.Windows.Forms.TextBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.login = New System.Windows.Forms.Button()
        Me.errorpicture = New System.Windows.Forms.PictureBox()
        Me.invalidmessage = New System.Windows.Forms.Label()
        CType(Me.errorpicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Username
        '
        Me.Username.BackColor = System.Drawing.Color.White
        Me.Username.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Username.Font = New System.Drawing.Font("Segoe UI Semilight", 10.25!)
        Me.Username.Location = New System.Drawing.Point(356, 240)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(189, 19)
        Me.Username.TabIndex = 3
        Me.Username.Text = "Username"
        '
        'Password
        '
        Me.Password.BackColor = System.Drawing.Color.White
        Me.Password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Password.Font = New System.Drawing.Font("Segoe UI Semilight", 10.25!)
        Me.Password.Location = New System.Drawing.Point(355, 282)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(189, 19)
        Me.Password.TabIndex = 4
        Me.Password.Text = "Password"
        '
        'login
        '
        Me.login.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.login.FlatAppearance.BorderSize = 0
        Me.login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SpringGreen
        Me.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.login.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.login.Location = New System.Drawing.Point(324, 317)
        Me.login.Name = "login"
        Me.login.Size = New System.Drawing.Size(228, 30)
        Me.login.TabIndex = 5
        Me.login.Text = "Login"
        Me.login.UseVisualStyleBackColor = False
        '
        'errorpicture
        '
        Me.errorpicture.BackColor = System.Drawing.Color.White
        Me.errorpicture.BackgroundImage = CType(resources.GetObject("errorpicture.BackgroundImage"), System.Drawing.Image)
        Me.errorpicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.errorpicture.Location = New System.Drawing.Point(375, 192)
        Me.errorpicture.Name = "errorpicture"
        Me.errorpicture.Size = New System.Drawing.Size(34, 28)
        Me.errorpicture.TabIndex = 6
        Me.errorpicture.TabStop = False
        Me.errorpicture.Visible = False
        '
        'invalidmessage
        '
        Me.invalidmessage.AutoSize = True
        Me.invalidmessage.BackColor = System.Drawing.Color.White
        Me.invalidmessage.ForeColor = System.Drawing.Color.Red
        Me.invalidmessage.Location = New System.Drawing.Point(415, 194)
        Me.invalidmessage.Name = "invalidmessage"
        Me.invalidmessage.Size = New System.Drawing.Size(92, 26)
        Me.invalidmessage.TabIndex = 7
        Me.invalidmessage.Text = "Invalid Username " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "or Password"
        Me.invalidmessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.invalidmessage.Visible = False
        '
        'loginform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(877, 539)
        Me.Controls.Add(Me.invalidmessage)
        Me.Controls.Add(Me.errorpicture)
        Me.Controls.Add(Me.login)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Username)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "loginform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.errorpicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Username As System.Windows.Forms.TextBox
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents login As System.Windows.Forms.Button
    Friend WithEvents errorpicture As System.Windows.Forms.PictureBox
    Friend WithEvents invalidmessage As System.Windows.Forms.Label

End Class
