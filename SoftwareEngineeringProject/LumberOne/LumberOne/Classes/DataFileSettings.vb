Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbPermission
Imports System.Math

Public Class DataFileSettings
    Dim source1 As New BindingSource
    Dim DataBasePath = "E:\SoftwareEngineeringProject\LumberOne\UsersDatabase.accdb"

    Public Function DBConn1(Table As String) As DataSet
        Dim Ds As New DataSet
        Dim da As OleDbDataAdapter
        Dim tables As DataTableCollection
        tables = Ds.Tables
        Dim provider As String
        Dim dataFile As String

        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = DataBasePath
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        myConnection.Open()

        da = New OleDbDataAdapter("Select * from " + Table, myConnection)
        da.Fill(Ds, "UsersDatabase")
        Return Ds
    End Function

    Public Sub InsertLog(Value1 As String, Value2 As String, Value3 As String)
        Dim da As String
        Dim provider As String
        Dim dataFile As String

        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = DataBasePath
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        Try
            myConnection.Open()
            da = ("INSERT INTO logTbl (Length, Width, Height) VALUES (" + Value1 + ", " + Value2 + ", " + Value3 + ")")
            Dim Command As New OleDbCommand(da, myConnection)
            Command.ExecuteNonQuery()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("Database connection issue, refer to DataFileSetting.vb")
        End Try
    End Sub

    Public Sub ClearLogTbl()
        Dim da As String
        Dim provider As String
        Dim dataFile As String

        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = DataBasePath
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        Try
            myConnection.Open()
            da = ("Delete * from (logTbl)")
            Dim Command As New OleDbCommand(da, myConnection)
            Command.ExecuteNonQuery()
            myConnection.Close()

        Catch ex As Exception
            MessageBox.Show("Database connection issue (ClearLogTbl (delete query), refer to DataFileSetting.vb")
        End Try
        Try
            myConnection.Open()
            da = ("Alter Table logTbl Alter Column ID Counter(1,1)")
            Dim Command As New OleDbCommand(da, myConnection)
            Command.ExecuteNonQuery()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("Database connection issue (ClearLogTbl (Alter query), refer to DataFileSetting.vb")
        End Try
    End Sub

    Public Sub FetchLogTbl()
        Dim Test = "logTbl"
        Dim da As New DataSet
        Dim Connection As New DataFileSettings
        da = Connection.DBConn1(Test)
        Dim view As New DataView(da.Tables(0))
        source1.DataSource = view
        administrator.DataGridView1.DataSource = view
    End Sub

    ''-------------------------------------------------------------------------------------------------------------------------------------

    Public Sub InsertLumber(Value1 As Double, Value2 As Double, Value3 As Double, Value4 As Double, ScrapValue As Double)
        Dim da As String
        Dim provider As String
        Dim dataFile As String

        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = DataBasePath
        connString = provider & dataFile
        myConnection.ConnectionString = connString
        Try
            myConnection.Open()
            ' da = "INSERT INTO lumberTbl(Height, Width, Length, Value, ScrapValue) VALUES ( " + Value1 + ", " + Value2 + ", " + Value3 + ", " + Value4 + ", " + ScrapValue + ")"
            da += "INSERT INTO lumberTbl"
            da += "([Height] "
            da += ",[Width] "
            da += ",[Length]"
            da += ",[Value]"
            da += ",[ScrapValue])"
            da += "VALUES"
            da += "(@Value1,"
            da += "@Value2,"
            da += "@Value3,"
            da += "@Value4,"
            da += "@ScrapValue)"
            Dim Command As New OleDbCommand(da, myConnection)
            Command.Parameters.Add("@Value1", SqlDbType.Int)
            Command.Parameters("@Value1").Value = Value1
            Command.Parameters.Add("@Value2", SqlDbType.Int)
            Command.Parameters("@Value2").Value = Value2
            Command.Parameters.Add("@Value3", SqlDbType.Int)
            Command.Parameters("@Value3").Value = Value3
            Command.Parameters.Add("@Value4", SqlDbType.Int)
            Command.Parameters("@Value4").Value = Value4
            Command.Parameters.Add("@ScrapValue", SqlDbType.Int)
            Command.Parameters("@ScrapValue").Value = ScrapValue

            Command.ExecuteNonQuery()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("Database connection issue, refer to DataFileSetting.vb")
        End Try
      End Sub

    Public Sub ClearLumberTbl()
        Dim da As String
        Dim db As String
    
        Try
            Dim provider As String
            Dim dataFile As String

            Dim connString As String
            Dim myConnection As OleDbConnection = New OleDbConnection

            provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
            dataFile = DataBasePath
            connString = provider & dataFile
            myConnection.ConnectionString = connString
            myConnection.Open()
            da = ("Delete * from (lumberTbl)")
            Dim Command As New OleDbCommand(da, myConnection)
            Command.ExecuteNonQuery()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("Database connection issue (ClearLumberTbl (delete query), refer to DataFileSetting.vb")
        End Try
        Try
            Dim provider As String
            Dim dataFile As String

            Dim connString As String
            Dim myConnection As OleDbConnection = New OleDbConnection

            provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
            dataFile = DataBasePath
            connString = provider & dataFile
            myConnection.ConnectionString = connString
            myConnection.Open()
            da = ("Alter Table lumberTbl Alter Column ID Counter(1,1)")
            Dim Command As New OleDbCommand(da, myConnection)
            Command.ExecuteNonQuery()
            myConnection.Close()
        Catch ex As Exception
            MessageBox.Show("Database connection issue (ClearLumberTbl (Alter query), refer to DataFileSetting.vb")
        End Try
    End Sub

    Public Sub FetchLumberTbl()
        Dim Test = "lumberTbl"
        Dim da As New DataSet
        Dim Connection As New DataFileSettings
        da = Connection.DBConn1(Test)
        Dim view As New DataView(da.Tables(0))
        source1.DataSource = view
        administrator.DataGridView2.DataSource = view
    End Sub

    'Public Sub ScrapValue()
    '    Dim Test = "lumberTbl"
    '    Dim da As New DataSet
    '    Dim Connection As New DataFileSettings
    '    da = Connection.DBConn1(Test)
    '    Dim view As New DataView(da.Tables(0))
    '    If view.Table(0)(0).Rows.Count = 0 Then
    '        administrator.ScrapValueLbl.Text = "no lumber file has been uploaded to database"
    '    Else
    '        administrator.ScrapValueLbl.Text = "Scrap Value for the set of cuts is: " + FormatCurrency(view.Table(0)(0))
    '    End If

    'End Sub

    Public Sub ScrapValue()
        Dim tableName = "lumberTbl"
        Dim ds As New DataSet
        Dim Connection As New DataFileSettings
        ds = Connection.DBConn1(tableName)
        Dim view As New DataView(ds.Tables(0))
        Try
            administrator.ScrapValueLbl.Text = "Scrap Value for the set of cuts is: " + FormatCurrency(view.Table(0)(0))
        Catch ex As Exception
            administrator.ScrapValueLbl.Text = "No Lumber File Has Been Uploaded to the Database"
        End Try
        'If ds.Tables.Count = 0 AndAlso ds.Tables(tableName).Rows.Count = 0 Then
        '    administrator.ScrapValueLbl.Text = "no lumber file has been uploaded to database"
        'Else
        '    administrator.ScrapValueLbl.Text = "Scrap Value for the set of cuts is: " + FormatCurrency(view.Table(0)(0))
        'End If

    End Sub


    'Public Sub FetchLogs()
    '    Dim provider As String
    '    Dim dataFile As String

    '    Dim connString As String
    '    Dim myConnection As OleDbConnection = New OleDbConnection

    '    provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
    '    dataFile = DataBasePath
    '    connString = provider & dataFile
    '    myConnection.ConnectionString = connString

    '    Dim da As OleDbDataAdapter = New OleDbDataAdapter("Select * from logTbl", myConnection)

    '    Dim ds As DataSet = New DataSet
    '    Console.Write(ds)

    'End Sub

    Public Sub logArray(logs As List(Of String))


    End Sub

End Class
