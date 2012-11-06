Public MustInherit Class FixedSizeSimpleFigure
    Inherits SimpleFigure
    Implements IFixedSizeFigure

    Property FigureCenter As FigureCenter
    Property FixedLength As Double
    Property ModelCenter As GPoint

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
        MyBase.New(key, drawClasses)
        ModelCenter = pt
        FixedLength = l
        FigureCenter = fc
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String),
                   ByVal x As Double, ByVal y As Double, ByVal l As Double, ByVal fc As FigureCenter)
        MyBase.New(key, drawClasses)
        ModelCenter = GPoint.At(x, y)
        FixedLength = l
        FigureCenter = fc
    End Sub

    Public Overrides Sub ScaleMe(ByVal factorX As Double, ByVal factorY As Double)
        ModelCenter = ModelCenter.ScaleT(factorX, factorY)
    End Sub

    Public Overrides Sub RotateMe(ByVal angle As Double)
        ModelCenter = ModelCenter.RotateT(angle)
    End Sub

    Public Overrides Sub TranslateMe(ByVal x As Double, ByVal y As Double)
        ModelCenter = ModelCenter.TranslateT(x, y)
    End Sub

    Public Overrides Function Bounds() As Bound
        Return New Bound(ModelCenter.X, ModelCenter.Y, ModelCenter.X, ModelCenter.Y)
    End Function

    Public Overrides Function Clone(ByVal keySuffix As String) As IFigure
        Dim newFig = DirectCast(GetInstance(Me.Key & keySuffix), FixedSizeSimpleFigure)
        Debug.Assert(newFig.Key IsNot Nothing)
        newFig.DrawClasses.AddRange(DrawClasses)
        newFig.ModelCenter = ModelCenter
        newFig.FixedLength = FixedLength
        newFig.FigureCenter = FigureCenter

        Return newFig
    End Function

    Public Overrides Function Area() As Double
        Return 0
    End Function

End Class

