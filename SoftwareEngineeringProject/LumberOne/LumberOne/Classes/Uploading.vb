Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO

Public Class Uploading
    'Method to uplaod .txt file to databae
    Public Sub SaveTXTtoDB(FileName As String, Dimensions As String)
        Dim filebyte As New FileStream(FileName, FileMode.Open)
        Dim filesize = CInt(filebyte.Length)
        Dim Buffer(filesize - 1) As Byte
        filebyte.Read(Buffer, 0, filesize)

        Dim provider As String
        Dim dataFile As String
        Dim connString As String
        Dim myConnection As OleDbConnection = New OleDbConnection

        provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        dataFile = "J:\SoftwareEngineeringProject\LumberOne\UsersDatabase.accdb"
        connString = provider & dataFile
        myConnection.ConnectionString = connString

        Dim cmd As OleDbCommand = New OleDbCommand("Insert into UsersDatabase()VALUES()", myConnection)
        cmd.Parameters.Add("@txt", OleDbType.VarBinary, filesize - 1).Value = Buffer
        cmd.Parameters.Add("@fileName", OleDbType.VarChar, 20).Value = Dimensions
        myConnection.Open()
        cmd.ExecuteNonQuery()
        myConnection.Close()
        Interaction.MsgBox("File saved to database", MsgBoxStyle.Information)


    End Sub

    'Method to save file as .txt file
    Public Sub sqlBlob2File(Dimensions As String)

        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim PictureCol = 0 ' the column # of the BLOB field
        Dim cmd As OleDbCommand = New OleDbCommand("" + Dimensions + "'")
        myConnection.Open()
        Dim dr As OleDbDataReader = cmd.ExecuteReader
        dr.Read()
        Dim b(CInt(dr.GetBytes(PictureCol, 0, Nothing, 0, Integer.MaxValue) - 1)) As Byte
        dr.GetBytes(PictureCol, 0, b, 0, b.Length)
        dr.Close()
        myConnection.Close()
        Dim fs As New FileStream("C:\Windows\Temp\" + Dimensions + ".txt", FileMode.Create, FileAccess.Write)
        fs.Write(b, 0, b.Length)
        fs.Close()
        Process.Start("C:\Windows\Temp\" + Dimensions + ".txt")

    End Sub

End Class
