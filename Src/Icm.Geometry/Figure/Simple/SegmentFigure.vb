Public Class SegmentFigure
    Inherits SimpleFigure
    Implements ILineDrawable

    Protected Sub New(ByVal key As String)
        MyBase.New(key)
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As String(), ByVal pt1 As GPoint, ByVal pt2 As GPoint)
        MyBase.New(key, drawClasses, pt1, pt2)
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As String(), ByVal p1x As Double, ByVal p1y As Double, ByVal p2x As Double, ByVal p2y As Double)
        MyBase.New(key, drawClasses, GPoint.At(p1x, p1y), GPoint.At(p2x, p2y))
    End Sub

    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New SegmentFigure(newKey)
    End Function
    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Dim b1 As GSegment = New GSegment(Points(0), Points(1))

        Return b1.DistanceToPoint(p) <= epsilon

    End Function
   
    Public Overrides Function Area() As Double
        Return 0
    End Function
End Class
