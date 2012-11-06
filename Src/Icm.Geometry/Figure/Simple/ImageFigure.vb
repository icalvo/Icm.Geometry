<Serializable()>
Public Class ImageFigure
    Inherits SimpleFigure
    Implements IImageDrawable

    Protected Sub New(ByVal key As String)
        MyBase.New(key)
    End Sub

    ''' <summary>
    ''' Places the image at origin, with given width and height
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="width"></param>
    ''' <param name="height"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As String(), ByVal width As Double, height As Double)
        MyBase.New(key, drawClasses, GPoint.At(0, 0), GPoint.At(width, 0), GPoint.At(0, height))
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As String(), ByVal pt1 As GPoint, ByVal pt2 As GPoint, ByVal pt3 As GPoint)
        MyBase.New(key, drawClasses, pt1, pt2, pt3, GPoint.At(pt3.X + pt2.X - pt1.X, pt3.Y + pt2.Y - pt1.Y))
    End Sub

    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New ImageFigure(newKey)
    End Function
    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Dim pt4 = GPoint.At(Points(2).X + Points(1).X - Points(0).X, Points(2).Y + Points(1).Y - Points(0).Y)

        Dim b1 As New GSegment(Points(0), Points(1))
        Dim b2 As New GSegment(Points(1), Points(2))
        Dim b3 As New GSegment(Points(2), pt4)
        Dim b4 As New GSegment(pt4, Points(0))

        Return b1.DistanceToPoint(p) <= epsilon OrElse b2.DistanceToPoint(p) <= epsilon OrElse b3.DistanceToPoint(p) <= epsilon _
                OrElse b4.DistanceToPoint(p) <= epsilon
    End Function

    Public Overrides Function Area() As Double
        Return 1
    End Function

    'Rober. Punto dentro de la imagen
    Public Overrides Function IsPointInArea(ByVal p As GPoint) As Boolean
        Dim p1 As GPoint, p2 As GPoint
        Dim inside As Boolean = False
        Dim puntos As List(Of GPoint) = Points
        puntos.Add(New GPoint With {.X = Points(1).X, .Y = Points(2).Y})

        If Points.Count < 3 Then
            Return inside
        End If

        Dim oldPoint = GPoint.At(puntos(puntos.Count - 1).X, puntos(puntos.Count - 1).Y)

        For i As Integer = 0 To puntos.Count - 1
            Dim newPoint = GPoint.At(puntos(i).X, puntos(i).Y)

            If newPoint.X > oldPoint.X Then
                p1 = oldPoint
                p2 = newPoint
            Else
                p1 = newPoint
                p2 = oldPoint
            End If

            If (newPoint.X < p.X) = (p.X <= oldPoint.X) AndAlso
               (p.Y - p1.Y) * (p2.X - p1.X) < (p2.Y - p1.Y) * (p.X - p1.X) Then
                inside = Not inside
            End If

            oldPoint = newPoint
        Next
        Return inside
    End Function

End Class
