''' <summary>
''' Bounds, defined with the LTRB tuple, and implementing heigth and width.
''' </summary>
''' <remarks></remarks>
Public Class Bound
    Property Left As Double
    Property Top As Double
    Property Right As Double
    Property Bottom As Double

    Public Sub New(ByVal l As Double, ByVal t As Double, ByVal r As Double, ByVal b As Double)
        Left = l
        Top = t
        Right = r
        Bottom = b
    End Sub

    ReadOnly Property Height As Double
        Get
            Return Bottom - Top
        End Get
    End Property

    ReadOnly Property Width As Double
        Get
            Return Right - Left
        End Get
    End Property
End Class
