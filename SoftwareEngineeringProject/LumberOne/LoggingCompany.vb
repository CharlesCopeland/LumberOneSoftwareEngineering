Imports System
Imports System.Collections.Generic

Public Class LoggingCompany
   Public Shared Sub Main(ByVal args() As String)
	  Dim input As New FileInput()

	  ' Import log/lumber data
	  Dim log As List(Of Log) = input.inputLog()
	  Dim lumber As List(Of Lumber) = input.inputLumber()

	  ' Determine log matrix dimensions
	  Dim dimensions As Integer = 0
	  For i As Integer = 0 To log.Count - 1
		 dimensions = Math.Max(dimensions, Math.Max(log(i).Height,log(i).Width))
	  Next i

	  ' Build the log matrix
	  Dim matrix As New LogMatrix(dimensions, lumber)

	  ' Get total value for all logs
	  For i As Integer = 0 To log.Count - 1
		 Console.WriteLine("Log #" & (i+1) & ": " & matrix.calculate(log(i)))
	  Next i
   End Sub
End Class