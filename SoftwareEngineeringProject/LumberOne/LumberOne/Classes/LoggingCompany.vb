Imports System
Imports System.Collections.Generic

Public Class LoggingCompany
    'Public Shared Sub Main(ByVal args() As String)
    Public Shared Sub Main()
        '  Dim input As New FileInput()

        ' Import log/lumber data
        Dim log As List(Of Log) = administrator.LogDblList
        Dim lumber As List(Of Lumber) = administrator.LumberDblList

        ' Determine log matrix dimensions
        Dim dimensions As Integer = 0
        For i As Integer = 0 To log.Count - 1
            dimensions = Math.Max(dimensions, Math.Max(log(i).height, log(i).width))
        Next i

        ' Build the log matrix
        Dim matrix As New LogMatrix(dimensions, lumber)

        ' Get total value for all logs
        For i As Integer = 0 To log.Count - 1
            administrator.ListBox1.Items.Add("Log #" & (i + 1) & ": " & matrix.calculate(log(i)))
        Next i
        For i As Integer = 0 To log.Count - 1
            administrator.ListBox1.Items.Add("Value" & (i + 1) & ": " & matrix.calculate(log(i)))
        Next i

    End Sub
End Class