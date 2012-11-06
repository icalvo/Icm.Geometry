Imports Icm.Geometry

<TestFixture(), Category("Icm.Geometry")>
Public Class FixedSizeCrossFigureTest

    <Test(), Category("Icm.Geometry")>
    Public Sub ClonFigureCrossTest()

        Dim fig As New FixedSizeCrossFigure("Cross", {""}, GPoint.At(2, 2), 4)
        Dim clon As New FixedSizeCrossFigure("", {""}, GPoint.At(0, 0), 0)
        clon = CType(fig.Clone("CLON"), FixedSizeCrossFigure)
        Assert.IsFalse(fig Is clon)
        Assert.IsTrue(fig.Center.X = clon.Center.X)
        Assert.IsTrue(fig.Center.Y = clon.Center.Y)

    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub ScaleFigureCrossTest()

        Dim fig As New FixedSizeCrossFigure("Escala", {""}, GPoint.At(1, 1), 4)
        Dim Escalada As New FixedSizeCrossFigure("", {""}, GPoint.At(0, 0), 0)
        Dim factorX As Double = 3
        Dim factorY As Double = 3
        Escalada = CType(fig.Scale(factorX, factorY), FixedSizeCrossFigure)
        Assert.IsTrue(CType(Escalada.Children.Values(0), FixedSizeSegmentFigure).ModelCenter.X = CType(Escalada.Children.Values(0), FixedSizeSegmentFigure).ModelCenter.Y)

    End Sub

End Class
