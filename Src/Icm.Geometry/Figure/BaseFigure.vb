<Serializable()>
Public MustInherit Class BaseFigure
    Implements IFigure
    Private ReadOnly _key As String

    Public Sub New(ByVal key As String, ByVal ParamArray drawClasses As String())
        _key = key
        Me.DrawClasses.AddRange(drawClasses)
    End Sub

    Public ReadOnly Property Key As String Implements IFigure.Key
        Get
            Return _key
        End Get
    End Property

    Public MustOverride Function Bounds() As Bound Implements IFigure.Bounds
    Public MustOverride Function Clone(ByVal key As String) As IFigure Implements IFigure.Clone
    Public MustOverride Sub ScaleMe(ByVal factorX As Double, ByVal factorY As Double) Implements IFigure.ScaleMe
    Public MustOverride Sub RotateMe(ByVal angle As Double) Implements IFigure.RotateMe
    Public MustOverride Sub TranslateMe(ByVal x As Double, ByVal y As Double) Implements IFigure.TranslateMe
    Public MustOverride Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean Implements IFigure.IsPointInPerimeter
    Public MustOverride Function IsPointInArea(ByVal punto As GPoint) As Boolean Implements IFigure.IsPointInArea

    Public Function Scale(ByVal factorX As Double, ByVal factorY As Double) As IAffineTransformable Implements IFigure.Scale
        Dim res = DirectCast(Me.Clone(Nothing), IFigure)
        res.ScaleMe(factorX, factorY)

        Debug.Assert(Not res Is Me)
        Return res
    End Function

    Public Function Rotate(ByVal angle As Double) As IAffineTransformable Implements IFigure.Rotate
        Dim res = DirectCast(Me.Clone(Nothing), IFigure)
        res.RotateMe(angle)
        Debug.Assert(Not res Is Me)
        Return res
    End Function

    Public Function Translate(ByVal x As Double, ByVal y As Double) As IAffineTransformable Implements IFigure.Translate
        Dim res = DirectCast(Me.Clone(Nothing), IFigure)
        res.TranslateMe(x, y)
        Debug.Assert(Not res Is Me)
        Return res
    End Function

    Property Observer As IPositionObserver Implements IPositionObservable.Observer

    Property DrawClasses As ICollection(Of String) = New List(Of String) Implements IFigure.DrawClasses

End Class
