Public Class CircleFigure
    Inherits SimpleFigure
    Implements IEllipseDrawable

    Protected Sub New(ByVal key As String)
        MyBase.New(key)
    End Sub

    Public Function Radius() As Double
        Return Points(0).Distance(Points(1)) / 2
    End Function

    Public Function Center() As GPoint
        Return New GSegment(Points(0), Points(1)).MiddlePoint
    End Function

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String), ByVal center As GPoint, ByVal r As Double)
        MyBase.New(key, drawClasses, CType(center.Translate(-r, r), GPoint), CType(center.Translate(r, -r), GPoint))
    End Sub

    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Return Math.Abs(GPoint.At(Points(0).X + Radius(), Points(0).Y - Radius()).Distance(p)) <= Radius() + epsilon
    End Function

    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New CircleFigure(newKey)
    End Function

    Public Overrides Function Bounds() As Bound
        Return New Bound(Center.TranslateT(-Radius(), 0).X, Center.TranslateT(0, Radius).Y, Center.TranslateT(Radius, 0).X, Center.TranslateT(0, -Radius()).Y)
    End Function


    Public Overrides Function Area() As Double
        Return Math.PI * Radius() ^ 2
    End Function
End Class
