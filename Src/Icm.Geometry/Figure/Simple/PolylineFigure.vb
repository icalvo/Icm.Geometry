Public Class PolylineFigure
    Inherits SimpleFigure
    Implements IPathDrawable

    Protected Sub New(ByVal key As String)
        MyBase.New(key)
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String), ByVal ParamArray points() As GPoint)
        MyBase.New(key, drawClasses, points)
    End Sub

    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New PolylineFigure(newKey)
    End Function
    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        Return False
    End Function

    Public Overrides Function Area() As Double
        Return 0
    End Function
End Class

