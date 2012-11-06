''' <summary>
'''  Cross marker (fixed-size).
''' </summary>
''' <remarks>
''' This is an useful example of composite figure with non-editable children.
''' </remarks>
Public Class FixedSizeCrossFigure
    Inherits CompositeFigure

    Property Length As Double
    Property Center As GPoint

    Overrides ReadOnly Property Children As SortedDictionary(Of String, IFigure)
        Get
            Dim pt = Center
            Dim l = Length
            Dim dic As New SortedDictionary(Of String, IFigure) From {
                {"blade1", New FixedSizeSegmentFigure("blade1", DrawClasses.ToArray, pt, l, Rad(45), FigureCenter.Center)},
                {"blade2", New FixedSizeSegmentFigure("blade2", DrawClasses.ToArray, pt, l, Rad(-45), FigureCenter.Center)}
            }
            Return dic
        End Get
    End Property

    Public Sub New(ByVal key As String, ByVal drawClasses As IEnumerable(Of String), ByVal pt As GPoint, ByVal l As Double)
        MyBase.New(key, drawClasses.ToArray)
        Center = pt
        Length = l
    End Sub

    Public Overrides Sub ScaleMe(ByVal factorX As Double, ByVal factorY As Double)
        Center = Center.ScaleT(factorX, factorY)
    End Sub

    Public Overrides Sub RotateMe(ByVal ángulo As Double)
        Center = Center.RotateT(ángulo)
    End Sub

    Public Overrides Sub TranslateMe(ByVal x As Double, ByVal y As Double)
        Center = Center.TranslateT(x, y)
    End Sub

    Public Overrides Function Clone(ByVal clave As String) As IFigure
        Return New FixedSizeCrossFigure(If(String.IsNullOrEmpty(clave), Me.Key, clave), DrawClasses.ToArray, Center, Length)
    End Function

End Class

