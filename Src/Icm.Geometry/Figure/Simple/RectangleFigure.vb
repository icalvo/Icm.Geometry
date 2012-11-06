Public Enum FigureCenter As Integer
    TopLeft = 1
    Center = 2
    BottomLeft = 3
End Enum

Public Class RectangleFigure
    Inherits SimpleFigure
    Implements IPolygonDrawable

    Protected Sub New(ByVal key As String)
        MyBase.New(key)
    End Sub

    ''' <summary>
    ''' Rectangle, given coordinates, width and length
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="w"></param>
    ''' <param name="h"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal x As Double, ByVal y As Double, ByVal w As Double, ByVal h As Double, Optional ByVal rc As FigureCenter = FigureCenter.BottomLeft)
        MyBase.New(key, drawClasses)

        Select Case rc
            Case FigureCenter.Center
                Points.AddRange({
                                GPoint.At(x - w / 2, y - h / 2),
                                GPoint.At(x + w / 2, y - h / 2),
                                GPoint.At(x + w / 2, y + h / 2),
                                GPoint.At(x - w / 2, y + h / 2)
                                })
            Case FigureCenter.TopLeft
                Points.AddRange({
                                GPoint.At(x, y),
                                GPoint.At(x + w, y),
                                GPoint.At(x + w, y - h),
                                GPoint.At(x, y - h)
                                })
            Case FigureCenter.BottomLeft
                Points.AddRange({
                                GPoint.At(x, y),
                                GPoint.At(x + w, y),
                                GPoint.At(x + w, y + h),
                                GPoint.At(x, y + h)
                                })
            Case Else
        End Select
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal pt As GPoint, ByVal w As Double, ByVal h As Double, Optional ByVal rc As FigureCenter = FigureCenter.BottomLeft)
        MyClass.New(key, drawClasses, pt.X, pt.Y, w, h, rc)
    End Sub

    ''' <summary>
    ''' Rectangle at origin, given width and height
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="w"></param>
    ''' <param name="h"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal w As Double, ByVal h As Double, Optional ByVal rc As FigureCenter = FigureCenter.BottomLeft)
        MyClass.New(key, drawClasses, 0, 0, w, h, rc)
    End Sub


    ''' <summary>
    ''' Square, given point and a side length
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="pt"></param>
    ''' <param name="l"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal pt As GPoint, ByVal l As Double, Optional ByVal rc As FigureCenter = FigureCenter.BottomLeft)
        MyClass.New(key, drawClasses, pt.X, pt.Y, l, l, rc)
    End Sub

    ''' <summary>
    ''' Square, given coordinates and a side length
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <param name="l"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal x As Double, ByVal y As Double, ByVal l As Double, Optional ByVal rc As FigureCenter = FigureCenter.BottomLeft)
        MyClass.New(key, drawClasses, x, y, l, l, rc)
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal l As Double, Optional ByVal rc As FigureCenter = FigureCenter.BottomLeft)
        MyClass.New(key, drawClasses, 0, 0, l, l, rc)
    End Sub

    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New RectangleFigure(newKey)
    End Function

    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Dim b1 As New GSegment(Points(0), Points(1))
        Dim b2 As New GSegment(Points(1), Points(2))
        Dim b3 As New GSegment(Points(2), Points(3))
        Dim b4 As New GSegment(Points(3), Points(0))

        Return b1.DistanceToPoint(p) <= epsilon OrElse b2.DistanceToPoint(p) <= epsilon OrElse b3.DistanceToPoint(p) <= epsilon _
                OrElse b4.DistanceToPoint(p) <= epsilon
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
