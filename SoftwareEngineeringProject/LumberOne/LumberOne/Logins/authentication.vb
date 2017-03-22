Imports System.Data.OleDb

Public Class authentication
    Dim DataBasePath = "E:\SoftwareEngineeringProject\LumberOne\UsersDatabase.accdb"
    Public Function adminAuthenticate() As Boolean

        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim flag As Boolean

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = DataBasePath
        connString = provider & dataFile
        myConnection.ConnectionString = connString

        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM admTbl WHERE admin_username = '" & Form1.txtUsername.Text & "' AND admin_password = '" & Form1.txtPassword.Text & "' ", myConnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim adminUserFound As Boolean = False

        Dim adminUserName As String = ""
        Dim adminUserPass As String = ""

        While dr.Read
            adminUserFound = True
            adminUserName = dr("admin_username").ToString
            adminUserPass = dr("admin_password").ToString
        End While

        If adminUserFound = True Then
            flag = True
        Else
            flag = False
        End If
        Return flag
    End Function

    Public Function employeeAuthenticate() As Boolean

        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim flag As Boolean

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = DataBasePath
        connString = provider & dataFile
        myConnection.ConnectionString = connString

        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM employeeTbl WHERE username = '" & Form1.txtUsername.Text & "' AND password = '" & Form1.txtPassword.Text & "' ", myConnection)
        Dim dr As OleDbDataReader = cmd.ExecuteReader

        Dim employeeUserFound As Boolean = False

        Dim employeeUserName As String = ""
        Dim employeePass As String = ""

        While dr.Read
            employeeUserFound = True
            employeeUserName = dr("username").ToString
            employeePass = dr("password").ToString
        End While

        If employeeUserFound = True Then
            flag = True
        Else
            Return False
            flag = False
        End If
        Return flag
    End Function

End Class
