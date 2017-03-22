Imports System
Imports Microsoft.VisualBasic

Public Class Lumber
    Implements IComparable(Of Lumber)

    Public height As Integer
    Public width As Integer
    Public length As Integer
    Public quantity As Integer
    Public value As Integer

    Public Sub New(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer, ByVal d As Integer)
        height = Math.Min(a, b)
        width = Math.Max(a, b)
        length = c
        quantity = 0
        value = d
    End Sub

    Public Overridable Function CompareTo(ByVal a As Lumber) As Integer Implements IComparable(Of Lumber).CompareTo
        Return ((a.value / (a.height * a.width * a.length))).CompareTo(value / (height * width * length))
    End Function
    'Public Overridable Function CompareTo(ByVal a As Lumber) As Integer Implements IComparable(Of Lumber).CompareTo
    '    Return (New Integer(a.value / (a.height * a.width * a.length))).CompareTo(value / (height * width * length))
    'End Function

    Public Overridable Property xHeight As Integer
        Set(ByVal a As Integer)
            height = a
        End Set
        Get
            Return height
        End Get
    End Property


    Public Overridable Property xWidth As Integer
        Set(ByVal a As Integer)
            width = a
        End Set
        Get
            Return width
        End Get
    End Property


    Public Overridable Property xLength As Integer
        Set(ByVal a As Integer)
            length = a
        End Set
        Get
            Return length
        End Get
    End Property


    Public Overridable Property xQuantity As Integer
        Set(ByVal a As Integer)
            quantity = a
        End Set
        Get
            Return quantity
        End Get
    End Property


    Public Overridable Property xValue As Double
        Set(ByVal a As Double)
            value = a
        End Set
        Get
            Return value
        End Get
    End Property


    Public Overrides Function ToString() As String
        Return "Quantity: " & quantity & ControlChars.Tab & "Height: " & height & ControlChars.Tab & "Width: " & width & ControlChars.Tab & "Length: " & length & ControlChars.Tab & "Value: " & value & ControlChars.Tab & "Weighted Value: " & String.Format("{0:F2}", value / (height * width * length))
    End Function
End Class

