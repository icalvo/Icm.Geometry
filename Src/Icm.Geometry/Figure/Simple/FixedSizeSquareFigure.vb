Public Class FixedSizeSquareFigure
    Inherits FixedSizeSimpleFigure
    Implements IPolygonDrawable

    ''' <summary>
    ''' Square, given point and a side length
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="pt"></param>
    ''' <param name="l"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal pt As GPoint, ByVal l As Double, ByVal fc As FigureCenter)
        MyBase.New(key, drawClasses, pt, l, fc)
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal x As Double, ByVal y As Double, ByVal l As Double, ByVal fc As FigureCenter)
        MyBase.New(key, drawClasses, x, y, l, fc)
    End Sub

    Public Overrides ReadOnly Property Points As System.Collections.Generic.List(Of GPoint)
        Get
            Dim x, y As Double
            x = ModelCenter.X
            y = ModelCenter.Y

            Return New List(Of GPoint) From {
                                GPoint.At(x - FixedLength / 2, y - FixedLength / 2),
                                GPoint.At(x + FixedLength / 2, y - FixedLength / 2),
                                GPoint.At(x + FixedLength / 2, y + FixedLength / 2),
                                GPoint.At(x - FixedLength / 2, y + FixedLength / 2)
                                }
        End Get
    End Property


    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New FixedSizeSquareFigure(newKey, DrawClasses, ModelCenter, FixedLength, FigureCenter)
    End Function
    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Dim b1 As GSegment = New GSegment(Points(0), Points(1))
        Dim b2 As GSegment = New GSegment(Points(1), Points(2))
        Dim b3 As GSegment = New GSegment(Points(2), Points(3))
        Dim b4 As GSegment = New GSegment(Points(3), Points(0))

        Return b1.DistanceToPoint(p) <= epsilon OrElse b2.DistanceToPoint(p) <= epsilon OrElse b3.DistanceToPoint(p) <= epsilon _
                OrElse b4.DistanceToPoint(p) <= epsilon
    End Function

End Class

