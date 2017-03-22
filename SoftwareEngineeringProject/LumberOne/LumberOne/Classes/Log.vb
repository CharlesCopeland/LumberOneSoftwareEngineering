Imports Microsoft.VisualBasic

Public Class Log
    Public height As Integer
    Public width As Integer
    Public length As Integer

    Public Sub New()
        height = 0
        width = 0
        length = 0
    End Sub

    Public Sub New(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer)
        height = a
        width = b
        length = c
    End Sub

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


    Public Overrides Function ToString() As String
        Return "Height: " & height & ControlChars.Tab & "Width: " & width & ControlChars.Tab & "Length: " & length
    End Function
End Class