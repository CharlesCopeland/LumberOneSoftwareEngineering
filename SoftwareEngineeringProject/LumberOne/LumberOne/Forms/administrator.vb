Imports System.Data.OleDb
Imports System.IO

Public Class administrator

    Dim source1 As New BindingSource
    Public Queries As New DataFileSettings
    Public LogDblList As New List(Of Log)
    Public LumberDblList As New List(Of Lumber)

    'Center WINDOW when loading
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.CenterToScreen()
        Dim DateNow = Date.Now
        WelcomeLbl.Text = "Welcome " + Form1.txtUsername.Text + ", You are logged on as of " + DateNow
        Form1.txtUsername.Text = ""
        Form1.txtPassword.Text = ""
        Queries.FetchLogTbl()
        Queries.FetchLumberTbl()
        Queries.ScrapValue()
    End Sub

    'Browse to File Explorer and add path to textbox
    Private Sub Browser_Click(sender As Object, e As EventArgs) Handles Browser.Click
        If (ofd.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = ofd.FileName
        End If
    End Sub

    'Hides ADMINview and persists LOGIN window
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()
    End Sub

    'Upload .txt file to database
    Private Sub ButtonUpload_Click(sender As Object, e As EventArgs) Handles ButtonUpload.Click
        Dim FilePath = ofd.FileName
        Dim fStream As New System.IO.FileStream(FilePath, IO.FileMode.Open)
        Dim sReader As New System.IO.StreamReader(fStream)



            Dim List As New List(Of String)
            Do While sReader.Peek >= 0
                List.Add(sReader.ReadLine)
            Loop

            'to go back to an array
            Dim thisArray As String() = List.ToArray

            fStream.Close()
            sReader.Close()
            For Each item In thisArray
                Parser(item)
            Next
            'Add code to import .txt file here. Call method from Uploading class'
            Dim Queries As New DataFileSettings
            Queries.FetchLogTbl()
    End Sub

    Public Sub Parser(IndexContent As String)
        Dim Value1 As Int16
        Dim Value2 As Int16
        Dim Value3 As Int16


        Dim Dimensions As String() = IndexContent.Split(New Char() {" "c})
        Value1 = Dimensions(0)
        Value2 = Dimensions(1)
        Value3 = Dimensions(2)

        Queries.InsertLog(Value1, Value2, Value3)
        Dim logs As New Log(CDbl(Value1), CDbl(Value2), CDbl(Value3))
        LogDblList.Add(logs)
    End Sub

    Public Sub LumberParser(IndexContent As String, LastValue As String)
        Dim Value1 As Double
        Dim Value2 As Double
        Dim Value3 As Double
        Dim Value4 As Double
        Dim ScrapValue = CDbl(LastValue)


        Dim Dimensions As String() = IndexContent.Split(New Char() {" "c})
        Value1 = CDbl(Dimensions(0))
        Value2 = CDbl(Dimensions(1))
        Value3 = CDbl(Dimensions(2))
        Value4 = CDbl(Dimensions(3))


        Queries.InsertLumber(Value1, Value2, Value3, Value4, ScrapValue)
        Dim lumber As New Lumber(CDbl(Value1), CDbl(Value2), CDbl(Value3), CDbl(Value3))
        LumberDblList.Add(lumber)
    End Sub

    Private Sub clearlumber_Click(sender As Object, e As EventArgs) Handles clearlumberTbl.Click
        Dim Queries As New DataFileSettings
        Queries.ClearLumberTbl()
        Queries.FetchLumberTbl()
        Me.ScrapValueLbl.Text = "No File Uploaded "
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (ofd.ShowDialog() = DialogResult.OK) Then
            TextBox2.Text = ofd.FileName
        End If
    End Sub

    Private Sub ClearTblBtn_Click(sender As Object, e As EventArgs) Handles ClearTblBtn.Click
        Queries.ClearLogTbl()
        Queries.FetchLogTbl()
    End Sub

    Private Sub UploadLumber_Click(sender As Object, e As EventArgs) Handles UploadLumber.Click
        Try
            Dim FilePath = ofd.FileName
            Dim ScrapValue As String
            Dim fStream As New System.IO.FileStream(FilePath, IO.FileMode.Open)
            Dim sReader As New System.IO.StreamReader(fStream)

            Dim List As New List(Of String)
            Do While sReader.Peek >= 0
                List.Add(sReader.ReadLine)
            Loop


            'to go back to an array
            Dim thisArray As String() = List.ToArray
            ScrapValue = thisArray(thisArray.Length - 1)
            thisArray = RemoveAt(thisArray, thisArray.Length - 1)

            fStream.Close()
            sReader.Close()
            For Each item In thisArray
                LumberParser(item, ScrapValue)
            Next
            'Add code to import .txt file here. Call method from Uploading class'
            Dim Queries As New DataFileSettings
            Queries.FetchLumberTbl()
            Queries.ScrapValue()
        Catch ex As Exception
            MessageBox.Show("Enter a path")
        End Try

    End Sub

    '  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    'Dim Queries As New DataFileSettings
    '  Queries.FetchLogs()
    ' End Sub

    Public Function RemoveAt(Of T)(ByVal arr As T(), ByVal index As Integer) As T()
        Dim uBound = arr.GetUpperBound(0)
        Dim lBound = arr.GetLowerBound(0)
        Dim arrLen = uBound - lBound

        If index < lBound OrElse index > uBound Then
            Throw New ArgumentOutOfRangeException(
            String.Format("Index must be from {0} to {1}.", lBound, uBound))

        Else
            'create an array 1 element less than the input array
            Dim outArr(arrLen - 1) As T
            'copy the first part of the input array
            Array.Copy(arr, 0, outArr, 0, index)
            'then copy the second part of the input array
            Array.Copy(arr, index + 1, outArr, index, uBound - index)

            Return outArr
        End If
    End Function

    'Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
    '    If (e.ColumnIndex = 5) Then '' Here I assume that your column is the fifth
    '        If (e.Value IsNot Nothing) Then
    '            DataGridView2.Columns("Value").ValueType = GetType(Decimal)
    '            Dim stringValue As String = e.Value.ToString("0.00")
    '            e.Value = stringValue
    '            e.FormattingApplied = True
    '        End If
    '    End If
    'End Sub

    Private Sub dataGridView2_DataBindingComplete(ByVal sender As Object, ByVal e As DataGridViewBindingCompleteEventArgs) Handles DataGridView2.DataBindingComplete

        ' Hide some of the columns.
        With DataGridView2
            .RowHeadersVisible = False
            .Columns("ScrapValue").Visible = False
            .Columns("ID").Visible = False
        End With

        ' Disable sorting for the DataGridView.
        Dim i As DataGridViewColumn
        For Each i In DataGridView2.Columns
            i.SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        DataGridView2.AutoResizeColumns()
        'DataGridView2.Columns("Value").DefaultCellStyle.Format = "F11"

    End Sub


    Private Sub CutBtn_Click(sender As Object, e As EventArgs) Handles CutBtn.Click
        LoggingCompany.Main()
        MessageBox.Show("Warning! Your report has errors and may not have been generated correctly. Please try again.")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim folder As New DirectoryInfo("C:\ProgramData\Microsoft\Windows\Start Menu\Programs\jGRASP\jGRASP.lnk")
        'Dim files = folder.GetFiles("*.exe")

        'With Me.ListBox1
        '    .DisplayMember = "Name"
        '    .ValueMember = "FullName"
        '    .DataSource = files
        'End With

        'Process.Start(CStr(Me.ListBox1.SelectedValue))
        Process.Start("C:\ProgramData\Microsoft\Windows\Start Menu\Programs\jGRASP\jGRASP.lnk")

    End Sub
End Class