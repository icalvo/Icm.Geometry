Public Class FixedSizeSegmentFigure
    Inherits FixedSizeSimpleFigure
    Implements ILineDrawable


    Property Angle As Double

    ''' <summary>
    ''' Square, given point and a side length
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="modelPoint"></param>
    ''' <param name="screenLength"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal modelPoint As GPoint, ByVal screenLength As Double, ByVal alpha As Double, ByVal fc As FigureCenter)
        MyBase.New(key, drawClasses, modelPoint, screenLength, fc)
        Angle = alpha
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal x As Double, ByVal y As Double, ByVal screenLength As Double, ByVal alpha As Double, ByVal fc As FigureCenter)
        MyBase.New(key, drawClasses, x, y, screenLength, fc)
        Angle = alpha
    End Sub

    Public Overrides ReadOnly Property Points As System.Collections.Generic.List(Of GPoint)
        Get
            Return New List(Of GPoint) From {
                ModelCenter.TrasladarPolar(Angle, FixedLength / 2),
                ModelCenter.TrasladarPolar(Angle, -FixedLength / 2)
            }
        End Get
    End Property

    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New FixedSizeSegmentFigure(newKey, DrawClasses, ModelCenter, FixedLength, Angle, FigureCenter)
    End Function

    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Return False
    End Function

End Class
