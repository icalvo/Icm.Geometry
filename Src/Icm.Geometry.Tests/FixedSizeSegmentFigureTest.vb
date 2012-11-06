Imports Icm.Geometry

<TestFixture(), Category("Icm.Geometry")>
Public Class FixedSizeSegmentFigureTest

    <Test(), Category("Icm.Geometry")>
    Public Sub FixedSizeSegmentFigureTest()

        Dim fig As New FixedSizeSegmentFigure("Figura", {"Prueba"}, GPoint.At(1, 1), 4, 10, FigureCenter.Center)
        Assert.IsTrue(fig.FixedLength = 4)
        Assert.IsTrue(fig.ModelCenter.X = fig.ModelCenter.Y)
        Assert.IsTrue(fig.DrawClasses(0) = "Prueba")

    End Sub
End Class

