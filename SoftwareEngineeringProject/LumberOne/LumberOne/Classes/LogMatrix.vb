Imports System
Imports System.Collections.Generic
Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Friend Module RectangularArrays
    Friend Function ReturnRectangularStringArray(ByVal size1 As Integer, ByVal size2 As Integer) As String()()
        Dim newArray As String()() = New String(size1 - 1)() {}
        For array1 As Integer = 0 To size1 - 1
            newArray(array1) = New String(size2 - 1) {}
        Next array1

        Return newArray
    End Function
End Module


Public Class LogMatrix
    Public matrix()() As String
    Dim lumber As List(Of Lumber)

    Public Sub New(ByVal a As Integer, ByVal b As List(Of Lumber))

        'JAVA TO VB CONVERTER NOTE: The following call to the 'RectangularArrays' helper class reproduces the rectangular array initialization that is automatic in Java:
        'matrix = New String[a+1][a+1]
        'Dim matrix As String()() = New String(0)() {}
        matrix = RectangularArrays.ReturnRectangularStringArray(a + 1, a + 1)
        'matrix = Matrix(a + 1, a + 1)
        lumber = b
        buildMatrix()
        printMatrix()
    End Sub

    Public Overridable Sub buildMatrix()
        ' Populate our profit table with the values of each cut
        For i As Integer = 0 To lumber.Count - 1
            matrix(lumber(i).width)(lumber(i).height) = "" & lumber(i).value
            matrix(lumber(i).height)(lumber(i).width) = "" & lumber(i).value
            administrator.ListBox1.Items.Add(lumber(i).ToString())
            'administrator.ListBox1.Items.Add(lumber(i))
        Next i

        For i As Integer = 1 To matrix.Length - 1
            Dim j As Integer = i
            Do While j < matrix(i).Length
                Dim bestCut As String = "-1"

                ' For a piece of lumber size i by j, try every cut
                For k As Integer = 0 To lumber.Count - 1
                    ' Make sure this size cut is possible
                    If i - lumber(k).height < 0 OrElse j - lumber(k).width < 0 Then
                        Continue For
                    End If

                    ' The profit we get from cutting a single board of size cut.size
                    Dim cutProfit As Double = lumber(k).value

                    ' We can split up the leftovers in one of two ways
                    Dim leftover As String = "" & matrix(i - lumber(k).height)(j) & " " & matrix(lumber(k).height)(j - lumber(k).width)
                    Dim leftovers As String = "" & matrix(i - lumber(k).height)(lumber(k).width) & " " & matrix(i)(j - lumber(k).width)

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

        Dim count_Renamed As Double = 0.0
        Dim parser() As String = str.Split(New Char() {" "c})
        'Dim parser() As String = str.Split(" ", True)
        For k As Integer = 0 To parser.Length - 1
            If Regex.IsMatch(parser(k), "[a-zA-Z ]*\d+.*") Then
                count_Renamed += Double.Parse(parser(k))
            End If
            'If parser(k).matches("[a-zA-Z ]*\d+.*") Then
            '    count_Renamed += Double.Parse(parser(k))
            'End If
        Next k
        Return count_Renamed
    End Function

    'Private Function DoubleConverter(ByVal text As String) As String
    '    Dim value As String = 0
    '    Double.TryParse(text, value)
    '    Return value
    'End Function


    Public Overridable Sub printMatrix()
        Dim matrix(0)()
        'Dim matrix(0)(0)
        administrator.ListBox1.Items.Add(ControlChars.Lf)
        For i As Integer = 1 To matrix.Length - 1
            For j As Integer = 1 To matrix.Length - 1
                'Dim parser() As String = matrix(i)(j).Split(New Char() {" "c})
                Dim parser() As String = matrix(i)(j).Split(New Char() {}, StringSplitOptions.RemoveEmptyEntries)
                'Dim parser() As String = Array.ConvertAll(matrix(i)(j).Split(New Char() {" "c}), New Converter(Of String, String)(AddressOf Double.Parse))
                'Dim parser() As String = Array.ConvertAll(matrix(i)(j).Split(New Char() {" "c}), New Converter(Of String, String)(AddressOf DoubleConverter))
                'Dim array As String() = matrix(i)(j).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                For k As Integer = 0 To parser.Length - 1
                    If Regex.IsMatch(parser(k), "[a-zA-Z ]*\d+.*") Then
                        Console.Write(Double.Parse(parser(k)) & " ")
                    End If
                    'If parser(k).matches("[a-zA-Z ]*\d+.*") Then
                    '    Console.Write(Double.Parse(parser(k)) & " ")
                    'End If
                Next k
                administrator.ListBox1.Items.Add("|" & ControlChars.Tab)
            Next j
            administrator.ListBox1.Items.Add(ControlChars.Lf)
        Next i
    End Sub

    Public Overridable Function calculate(ByVal log As Log) As Double
        Dim total As Double = 0.0
        Do While log.length > lumber(0).length
            Dim parser() As String = matrix(log.height)(log.width).Split(New Char() {" "c})
            'Dim parser() As String = matrix(log.height)(log.width).Split(" ", True)
            For i As Integer = 0 To parser.Length - 1
                If Regex.IsMatch(parser(i), "[a-zA-Z ]*\d+.*") Then
                    ' If parser(i).matches("[a-zA-Z ]*\d+.*") Then
                    Dim j As Integer = 0
                    Do While j < lumber.Count
                        If Double.Parse(parser(i)) = lumber(j).value Then
                            lumber(j).quantity = lumber(j).quantity + 1
                            total += lumber(j).value
                            log.length = log.length - lumber(0).length
                        End If
                        j += 1
                    Loop
                End If
            Next i
        Loop

        Dim leftover As Integer = log.width * log.height * log.length
        lumber(lumber.Count - 1).quantity = lumber(lumber.Count - 1).quantity + leftover
        total += lumber(lumber.Count - 1).value * leftover
        Return total
    End Function
End Class