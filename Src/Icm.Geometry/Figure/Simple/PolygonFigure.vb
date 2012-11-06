Public Class PolygonFigure
    Inherits SimpleFigure
    Implements IPolygonDrawable

    Protected Sub New(ByVal key As String)
        MyBase.New(key)
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String), ByVal ParamArray points() As GPoint)
        MyBase.New(key, drawClasses, points)
    End Sub

    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New PolygonFigure(newKey)
    End Function

    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Dim p1 As GPoint, p2 As GPoint
        Dim inside As Boolean = False

        If Points.Count < 3 Then
            Return inside
        End If

        Dim oldPoint = GPoint.At(Points(Points.Count - 1).X, Points(Points.Count - 1).Y)

        For i As Integer = 0 To Points.Count - 1
            Dim newPoint = GPoint.At(Points(i).X, Points(i).Y)

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
End Class
