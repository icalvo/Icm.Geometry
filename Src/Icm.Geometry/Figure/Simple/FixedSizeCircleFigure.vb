Public Class FixedSizeCircleFigure
    Inherits FixedSizeSimpleFigure
    Implements IEllipseDrawable

    ''' <summary>
    ''' Square, given point and a side length
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="pt"></param>
    ''' <param name="r"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal pt As GPoint, ByVal r As Double)
        MyBase.New(key, drawClasses, pt, r, FigureCenter.Center)
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal x As Double, ByVal y As Double, ByVal r As Double)
        MyBase.New(key, drawClasses, x, y, r, FigureCenter.Center)
    End Sub

    Public Overrides ReadOnly Property Points As System.Collections.Generic.List(Of GPoint)
        Get
            Dim x, y As Double
            x = ModelCenter.X
            y = ModelCenter.Y

            Return New List(Of GPoint) From {
                                GPoint.At(x - FixedLength, y - FixedLength),
                                GPoint.At(x + FixedLength, y + FixedLength)
                                }
        End Get
    End Property

    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Dim r As Double = FixedLength
        Return Math.Abs(GPoint.At(Points(0).X + r, Points(0).Y - r).Distance(p)) <= r + epsilon
    End Function
    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New FixedSizeCircleFigure(newKey, DrawClasses, ModelCenter, FixedLength)
    End Function

End Class
