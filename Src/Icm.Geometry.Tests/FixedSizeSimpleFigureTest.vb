Imports Icm.Geometry.SegmentFigure
Imports Icm.Geometry
<TestFixture()>
Public Class FixedSizeSimpleFigureTest

    <Test(), Category("Icm.Geometry")>
    Public Sub ScaleMeTest()

        Dim segmentfig As New FixedSizeSegmentFigure("Segmento", {"Draw"}, GPoint.At(1, 2), 12, 9, FigureCenter.Center)
        Dim actual As FixedSizeSimpleFigure = segmentfig
        Dim factorX As Double = 1
        Dim factorY As Double = 2
        actual.ScaleMe(factorX, factorY)
        Assert.IsTrue(actual.ModelCenter.X = 1 And actual.ModelCenter.Y = 4)

    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub RotateMeTest()

        Dim angule As Double = 2
        Dim segmentfig As New FixedSizeSegmentFigure("SGM", {"Hola"}, GPoint.At(1, 1), 1, 1, FigureCenter.TopLeft)
        Dim actual As FixedSizeSimpleFigure = segmentfig
        actual.RotateMe(angule)
        Assert.IsTrue(actual.ModelCenter.X = -1.3254442633728241 And actual.ModelCenter.Y = 0.4931505902785393)

    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub TranslateMeTest()

        Dim x As Double = 2
        Dim y As Double = 2
        Dim segmentfig As New FixedSizeSegmentFigure("SEG", {"RR"}, GPoint.At(1, 1), 1, 1, FigureCenter.TopLeft)
        Dim actual As FixedSizeSimpleFigure = segmentfig
        actual.TranslateMe(x, y)
        Assert.IsTrue(actual.ModelCenter.X = 3 And actual.ModelCenter.Y = 3)

    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub BoundsTest()

        Dim segmentfig As New FixedSizeSegmentFigure("Segmento", {"ooii"}, GPoint.At(-2, 1), 1, 1, FigureCenter.TopLeft)
        Dim actual As FixedSizeSimpleFigure = segmentfig
        actual.Bounds()
        Assert.IsTrue(actual.ModelCenter.X = -2 And actual.ModelCenter.Y = 1)

    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub CloneTest()

        Dim segmentfig As New FixedSizeSegmentFigure("Segmento", {"Draw"}, GPoint.At(-2, 1), 1, 1, FigureCenter.TopLeft)
        Dim actual As FixedSizeSimpleFigure = segmentfig
        Dim FiguraClonada As New FixedSizeSegmentFigure("", {""}, GPoint.At(0, 0), 0, 0, FigureCenter.TopLeft)
        FiguraClonada = CType(segmentfig.Clone("clon"), FixedSizeSegmentFigure)
        Assert.IsFalse(FiguraClonada Is segmentfig)
        Assert.IsTrue(FiguraClonada.Points(1).X = segmentfig.Points(1).X)
        Assert.IsTrue(FiguraClonada.Points(1).Y = segmentfig.Points(1).Y)

    End Sub

End Class
