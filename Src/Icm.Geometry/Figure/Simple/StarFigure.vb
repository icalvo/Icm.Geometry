Public Class StarFigure
    Inherits SimpleFigure
    Implements IPolygonDrawable

    Protected Sub New(ByVal key As String)
        MyBase.New(key)
    End Sub
    Public Sub New(key As String, drawClasses As IEnumerable(Of String), center As GPoint, radiusExt As Double, radiusInt As Double, puntas As Integer)

        MyBase.New(key, drawClasses)
        Dim mitadPuntas = CInt(puntas / 2)
        For i As Integer = 0 To mitadPuntas - 1
            Points.Add(center.TrasladarPolar(((2 * i) * Math.PI) / mitadPuntas, radiusExt))
            Points.Add(center.TrasladarPolar(((2 * i + 1) * Math.PI) / mitadPuntas, radiusInt))
        Next
    End Sub
    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New StarFigure(newKey)
    End Function
    Public Overrides Function Area() As Double
        Area = 0
        Dim i As Integer, j As Integer = 0

        For i = 0 To Points.Count - 1
            j += 1
            If j = Points.Count Then
                j = 0
            End If
            Area += (Points(i).X + Points(j).X) * (Points(i).Y - Points(j).Y)
        Next

        Area = Math.Abs(Area * 0.5)
    End Function
    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Dim b1 As New GSegment(Points(0), Points(1))
        Dim b2 As New GSegment(Points(1), Points(2))
        Dim b3 As New GSegment(Points(2), Points(3))
        Dim b4 As New GSegment(Points(3), Points(0))

        Return b1.DistanceToPoint(p) <= epsilon OrElse b2.DistanceToPoint(p) <= epsilon OrElse b3.DistanceToPoint(p) <= epsilon _
                OrElse b4.DistanceToPoint(p) <= epsilon
    End Function
End Class
