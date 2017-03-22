Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Friend Class LogMatrix
   Private matrix()() As String
   Private lumber As List(Of Lumber)

   Public Sub New(ByVal a As Integer, ByVal b As List(Of Lumber))
'JAVA TO VB CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
'ORIGINAL LINE: matrix = new String[a+1][a+1]
	  matrix = RectangularArrays.ReturnRectangularStringArray(a+1, a+1)
	  lumber = b
	  buildMatrix()
	  printMatrix()
   End Sub

   Public Overridable Sub buildMatrix()
	  ' Populate our profit table with the values of each cut
	  For i As Integer = 0 To lumber.Count - 1
		 matrix(lumber(i).Width)(lumber(i).Height) = "" & lumber(i).Value
		 matrix(lumber(i).Height)(lumber(i).Width) = "" & lumber(i).Value
		 Console.WriteLine(lumber(i).ToString())
	  Next i

	  For i As Integer = 1 To matrix.Length - 1
		 Dim j As Integer=i
		 Do While j<matrix(i).Length
			Dim bestCut As String = "-1"

			' For a piece of lumber size i by j, try every cut
			For k As Integer = 0 To lumber.Count - 1
			   ' Make sure this size cut is possible
			   If i - lumber(k).Height < 0 OrElse j - lumber(k).Width < 0 Then
				  Continue For
			   End If

			   ' The profit we get from cutting a single board of size cut.size
			   Dim cutProfit As Double = lumber(k).Value

			   ' We can split up the leftovers in one of two ways
			   Dim leftover As String = "" & matrix(i-lumber(k).Height)(j) & " " & matrix(lumber(k).Height)(j-lumber(k).Width)
			   Dim leftovers As String = "" & matrix(i-lumber(k).Height)(lumber(k).Width) & " " & matrix(i)(j-lumber(k).Width)

			   ' Pick the greatest profit from the leftover boards
			   Dim leftoverProfits As String
			   If count(leftover) > count(leftovers) Then
				  leftoverProfits = "" & leftover
			   Else
				  leftoverProfits = "" & leftovers
			   End If

			   ' Take the highest profit from all possible cuts
			   If cutProfit + count(leftoverProfits) > count(bestCut) Then
				  bestCut = "" & cutProfit & " " & leftoverProfits
			   End If
			Next k

			' If no cuts are possible, we can only make 0 profit.
			If count(bestCut) > count(matrix(i)(j)) Then
			   matrix(i)(j) = "" & bestCut
			End If
			matrix(j)(i) = matrix(i)(j)
			 j += 1
		 Loop
	  Next i
   End Sub

   Public Overridable Function count(ByVal str As String) As Double
	  If str Is Nothing Then
		 Return -1.0
	  End If

'JAVA TO VB CONVERTER NOTE: The local variable count was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
	  Dim count_Renamed As Double = 0.0
	  Dim parser() As String = str.Split(" ", True)
	  For k As Integer = 0 To parser.Length - 1
		 If parser(k).matches("[a-zA-Z ]*\d+.*") Then
			count_Renamed += Double.Parse(parser(k))
		 End If
	  Next k
	  Return count_Renamed
   End Function

   Public Overridable Sub printMatrix()
	  Console.Write(ControlChars.Lf)
	  For i As Integer = 1 To matrix.Length - 1
		 For j As Integer = 1 To matrix.Length - 1
			Dim parser() As String = matrix(i)(j).Split(" ", True)
			For k As Integer = 0 To parser.Length - 1
			   If parser(k).matches("[a-zA-Z ]*\d+.*") Then
				  Console.Write(Double.Parse(parser(k)) & " ")
			   End If
			Next k
			Console.Write("|" & ControlChars.Tab)
		 Next j
	  Console.Write(ControlChars.Lf)
	  Next i
   End Sub

   Public Overridable Function calculate(ByVal log As Log) As Double
	  Dim total As Double = 0.0
	  Do While log.Length> lumber(0).Length
		 Dim parser() As String = matrix(log.Height)(log.Width).Split(" ", True)
			For i As Integer = 0 To parser.Length - 1
			   If parser(i).matches("[a-zA-Z ]*\d+.*") Then
				  Dim j As Integer=0
				  Do While j<lumber.Count
					 If Double.Parse(parser(i))=lumber(j).Value Then
						lumber(j).Quantity = lumber(j).Quantity + 1
						total += lumber(j).Value
						log.Length = log.Length-lumber(0).Length
					 End If
					  j += 1
				  Loop
			   End If
			Next i
	  Loop

	  Dim leftover As Integer = log.Width * log.Height * log.Length
	  lumber(lumber.Count-1).Quantity = lumber(lumber.Count-1).Quantity + leftover
	  total += lumber(lumber.Count-1).Value * leftover
	  Return total
   End Function
End Class