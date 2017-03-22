Imports System.Data.OleDb

Public Class Form1

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        InitiateLogin()
    End Sub

    Private Sub EnterClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode.Equals(Keys.Enter) Then
            e.Handled = True
            e.SuppressKeyPress = True
            InitiateLogin()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        Call EnterClick(sender, e)
    End Sub

    'Center WINDOW when loading
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
    End Sub

    'Exit button control
    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Application.Exit()
    End Sub

    'Hide PASSSWORD characters in textbox
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        txtPassword.PasswordChar = "*"c
    End Sub
    Private Sub InitiateLogin()
        ''1=admin 2=employee
        Dim AuthenObj As New authentication
        Dim test As Integer
        'Test LOGIN credentials
        If AuthenObj.adminAuthenticate() = False And AuthenObj.employeeAuthenticate() = False Then
            MsgBox("Sorry, Username or Password not found!", MsgBoxStyle.OkOnly, "Invalid Login")
        ElseIf txtUsername.Text = "" Or txtPassword.Text = "" Then
            MsgBox("You must enter a username and password!", MsgBoxStyle.OkOnly, "Insufficient credentials")
        ElseIf AuthenObj.adminAuthenticate() = True And AuthenObj.employeeAuthenticate() = False Then
            test = 1
        ElseIf AuthenObj.adminAuthenticate() = False And AuthenObj.employeeAuthenticate() = True Then
            test = 2
        End If
        'Show WINDOW based on login credentials
        If test = 1 Then

            Me.Hide()
            administrator.Show()
        ElseIf test = 2 Then

            Me.Hide()
            employee.Show()
        End If
    End Sub
End Class
