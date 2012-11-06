''' <summary>
''' Abstract composite figure
''' </summary>
''' <remarks>
''' Composite figure is still abstract because we can build classes whose elements
''' are not directly modifiable; hence Children is abstract here and to be implemented 
''' by descendants. If you want a "classical" composite figure, use <see cref="ContainerFigure"></see>.
''' </remarks>
Public MustInherit Class CompositeFigure
    Inherits BaseFigure
    Implements ICompositeFigure

    Public Sub New(ByVal key As String, ByVal ParamArray drawClasses As String())
        MyBase.New(key, drawClasses)
    End Sub


    Default Public ReadOnly Property Item(ByVal key As String) As IFigure
        Get
            Return Children(key)
        End Get
    End Property

    Public Overrides Sub ScaleMe(ByVal factorX As Double, ByVal factorY As Double)
        For Each h In Children.Values
            h.ScaleMe(factorX, factorY)
        Next
    End Sub

    Public Overrides Sub RotateMe(ByVal angle As Double)
        For Each h In Children.Values
            h.RotateMe(angle)
        Next
    End Sub

    Public Overrides Sub TranslateMe(ByVal x As Double, ByVal y As Double)
        For Each h In Children.Values
            h.TranslateMe(x, y)
        Next
    End Sub

    Public Overrides Function Bounds() As Bound
        Dim childrenLimits As New List(Of Bound)

        For Each child In Children.Values
            childrenLimits.Add(child.Bounds)
        Next
        If childrenLimits.Count = 0 Then
            Return Nothing
        End If
        Return New Bound(
            childrenLimits.Min(Function(l) l.Left),
            childrenLimits.Max(Function(l) l.Top),
            childrenLimits.Max(Function(l) l.Right),
            childrenLimits.Min(Function(l) l.Bottom)
        )
    End Function
    Public Overrides Function IsPointInPerimeter(ByVal p As GPoint, Optional ByVal epsilon As Double = 0.01) As Boolean
        For Each fig As IFigure In Children.Values
            If fig.IsPointInPerimeter(p, epsilon) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Overrides Function IsPointInArea(punto As GPoint) As Boolean
        For Each fig As IFigure In Children.Values
            If fig.IsPointInArea(punto) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Overrides Function ToString() As String
        Return "C " & Key
    End Function

    Protected Overridable Function GetEnumerator() As IEnumerator(Of IFigure) Implements IEnumerable(Of IFigure).GetEnumerator
        Return Children.Values.GetEnumerator
    End Function

    Private Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function

    MustOverride ReadOnly Property Children As SortedDictionary(Of String, IFigure) Implements ICompositeFigure.Children

End Class
