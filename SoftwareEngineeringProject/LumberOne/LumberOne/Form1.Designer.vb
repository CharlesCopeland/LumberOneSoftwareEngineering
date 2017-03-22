<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.LogoText = New System.Windows.Forms.Label()
        Me.Username = New System.Windows.Forms.Label()
        Me.Password = New System.Windows.Forms.Label()
        Me.IntroText = New System.Windows.Forms.Label()
        Me.Login = New System.Windows.Forms.Button()
        Me.Close = New System.Windows.Forms.Button()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Logo1 = New System.Windows.Forms.PictureBox()
        CType(Me.Logo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoText
        '
        Me.LogoText.AutoSize = True
        Me.LogoText.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogoText.Location = New System.Drawing.Point(337, 232)
        Me.LogoText.Name = "LogoText"
        Me.LogoText.Size = New System.Drawing.Size(249, 15)
        Me.LogoText.TabIndex = 1
        Me.LogoText.Text = "Your Source for Premium Timber Solutions"
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Username.Location = New System.Drawing.Point(26, 123)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(77, 15)
        Me.Username.TabIndex = 2
        Me.Username.Text = "Username:"
        '
        'Password
        '
        Me.Password.AutoSize = True
        Me.Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Password.Location = New System.Drawing.Point(26, 167)
        Me.Password.Name = "Password"
        Me.Password.Size = New System.Drawing.Size(73, 15)
        Me.Password.TabIndex = 3
        Me.Password.Text = "Password:"
        '
        'IntroText
        '
        Me.IntroText.AutoSize = True
        Me.IntroText.Font = New System.Drawing.Font("Arial Black", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IntroText.Location = New System.Drawing.Point(24, 29)
        Me.IntroText.Name = "IntroText"
        Me.IntroText.Size = New System.Drawing.Size(284, 56)
        Me.IntroText.TabIndex = 4
        Me.IntroText.Text = "Welcome to LumberOne! " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Please Log In Below " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Login
        '
        Me.Login.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Login.Location = New System.Drawing.Point(105, 227)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(75, 34)
        Me.Login.TabIndex = 5
        Me.Login.Text = "Login"
        Me.Login.UseVisualStyleBackColor = True
        '
        'Close
        '
        Me.Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close.Location = New System.Drawing.Point(186, 227)
        Me.Close.Name = "Close"
        Me.Close.Size = New System.Drawing.Size(75, 34)
        Me.Close.TabIndex = 6
        Me.Close.Text = "Exit"
        Me.Close.UseVisualStyleBackColor = True
        '
        'Copyright
        '
        Me.Copyright.AutoSize = True
        Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.Location = New System.Drawing.Point(496, 271)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(92, 13)
        Me.Copyright.TabIndex = 7
        Me.Copyright.Text = "Copyright 2016"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(105, 122)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(199, 20)
        Me.txtUsername.TabIndex = 8
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(105, 167)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(199, 20)
        Me.txtPassword.TabIndex = 9
        '
        'Logo1
        '
        Me.Logo1.Image = Global.LumberOne.My.Resources.Resources.logo
        Me.Logo1.Location = New System.Drawing.Point(365, 29)
        Me.Logo1.Name = "Logo1"
        Me.Logo1.Size = New System.Drawing.Size(200, 200)
        Me.Logo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.Logo1.TabIndex = 0
        Me.Logo1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(600, 293)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.Close)
        Me.Controls.Add(Me.Login)
        Me.Controls.Add(Me.IntroText)
        Me.Controls.Add(Me.Password)
        Me.Controls.Add(Me.Username)
        Me.Controls.Add(Me.LogoText)
        Me.Controls.Add(Me.Logo1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "LumberOne, LLC."
        CType(Me.Logo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Logo1 As PictureBox
    Friend WithEvents LogoText As Label
    Friend WithEvents Username As Label
    Friend WithEvents Password As Label
    Friend WithEvents IntroText As Label
    Friend WithEvents Login As Button
    Friend WithEvents Close As Button
    Friend WithEvents Copyright As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
End Class
