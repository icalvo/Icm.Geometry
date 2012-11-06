Public Class StringFigure
    Inherits SimpleFigure
    Implements IStringDrawable



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
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String), text As String,
                   ByVal x As Double, ByVal y As Double)
        MyBase.New(key, drawClasses)
        Points.Add(GPoint.At(x, y))
        Me.Text = text

    End Sub



    ''' <summary>
    ''' Square, given point and a side length
    ''' </summary>
    ''' <param name="key"></param>
    ''' <param name="drawClasses"></param>
    ''' <param name="pt"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String), str As String,
                   ByVal pt As GPoint)
        MyClass.New(key, drawClasses, str, pt.X, pt.Y)
    End Sub

    Public Overrides Function Area() As Double
        Return 1
    End Function
    Public Overrides Function IsPointInPerimeter(p As GPoint, Optional epsilon As Double = 0.01) As Boolean
        Return p.Distance(Points(0)) < epsilon
    End Function
    Property Text As String Implements IStringDrawable.Text
       
    Protected Overrides Function GetInstance(ByVal newKey As String) As SimpleFigure
        Return New StringFigure(newKey)
    End Function

End Class
