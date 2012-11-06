<Serializable()>
Public MustInherit Class SimpleFigure
    Inherits BaseFigure
    Implements IPositionObserver, ISimpleFigure

    Private position_ As GPoint = GPoint.Origin
    Private points_ As New List(Of GPoint)
    Private data_ As IPositionObservable

    Protected Sub New(ByVal key As String)
        MyBase.New(key)
    End Sub

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String), ByVal ParamArray points() As GPoint)
        MyBase.New(key, drawClasses.ToArray)
        points_.AddRange(points)
    End Sub

    Public Overrides Sub ScaleMe(ByVal factorX As Double, ByVal factorY As Double)
        For i = 0 To Points.Count - 1
            Points(i) = Points(i).ScaleT(factorX, factorY)
        Next
    End Sub

    Public Overrides Sub RotateMe(ByVal angle As Double)
        For i = 0 To Points.Count - 1
            Points(i) = Points(i).RotateT(angle)
        Next
    End Sub

    Public Overrides Sub TranslateMe(ByVal x As Double, ByVal y As Double)
        For i = 0 To Points.Count - 1
            Points(i) = Points(i).TranslateT(x, y)
        Next
    End Sub

    Public ReadOnly Property Children As System.Collections.Generic.List(Of IFigure)
        Get
            Return New List(Of IFigure)
        End Get
    End Property

    Overridable ReadOnly Property Points As List(Of GPoint) Implements ISimpleFigure.Points
        Get
            Return points_
        End Get
    End Property

    Public Overrides Function Clone(ByVal keySuffix As String) As IFigure

        Dim newFig = GetInstance(Me.Key & keySuffix)

        newFig.Data = data_
        newFig.Points.AddRange(Points)
        newFig.DrawClasses.AddRange(DrawClasses)

        Return newFig
    End Function

    Protected MustOverride Function GetInstance(ByVal newKey As String) As SimpleFigure



    Public Overrides Function Bounds() As Bound
        Return New Bound(
            Points.Min(Function(p) p.X),
            Points.Max(Function(p) p.Y),
            Points.Max(Function(p) p.X),
            Points.Min(Function(p) p.Y)
        )
    End Function

    Public Overrides Function ToString() As String
        Return Me.GetType.Name & " " & Key
    End Function

    Public Property Data As IPositionObservable
        Get
            Return data_
        End Get
        Set(ByVal value As IPositionObservable)
            data_ = value
        End Set
    End Property


    Public Sub Notify(ByVal x As Double, ByVal y As Double) Implements IPositionObserver.Notify
        Dim tx = x - position_.X
        Dim ty = x - position_.Y

        TranslateMe(tx, ty)
        position_ = position_.TranslateT(tx, ty)
    End Sub
    Public Overrides Function IsPointInArea(ByVal p As GPoint) As Boolean
        Dim p1 As GPoint, p2 As GPoint
        Dim inside As Boolean = False
        Dim puntos As New List(Of GPoint)
        puntos.AddRange(Points)
        puntos.Add(New GPoint With {.X = Points(1).X, .Y = Points(2).Y})

        If Points.Count < 3 Then
            Return inside
        End If

        Dim oldPoint = GPoint.At(puntos(puntos.Count - 1).X, puntos(puntos.Count - 1).Y)

        For i As Integer = 0 To puntos.Count - 1
            Dim newPoint = GPoint.At(puntos(i).X, puntos(i).Y)

            If newPoint.X > oldPoint.X Then
                p1 = oldPoint
                p2 = newPoint
            Else
                p1 = newPoint
                p2 = oldPoint
            End If

            If (newPoint.X < p.X) = (p.X <= oldPoint.X) AndAlso
               (p.Y - p1.Y) * (p2.X - p1.X) < (p2.Y - p1.Y) * (p.X - p1.X) Then
                inside = Not inside
            End If

            oldPoint = newPoint
        Next
        Return inside
    End Function
    Public MustOverride Function Area() As Double Implements ISimpleFigure.Area

End Class
