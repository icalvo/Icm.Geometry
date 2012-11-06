''' <summary>
''' IFigure assumes that the affine transformations from IAffineTransformable always return a new object.
''' It defines its own set of affine transformations that DO transform the same object.
''' It defines an object associated with the figure.
''' Finally it defines a Clone operation.
''' </summary>
''' <remarks></remarks>
Public Interface IFigure
    Inherits IAffineTransformable, IPositionObservable

    ReadOnly Property Key As String

    Property DrawClasses As ICollection(Of String)

    Function Bounds() As Bound

    Sub ScaleMe(ByVal factorX As Double, ByVal factorY As Double)

    Sub RotateMe(ByVal angle As Double)

    Sub TranslateMe(ByVal x As Double, ByVal y As Double)

    Function Clone(ByVal key As String) As IFigure
    Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
    Function IsPointInArea(ByVal p As GPoint) As Boolean

End Interface

