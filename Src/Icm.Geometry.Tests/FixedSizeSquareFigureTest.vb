Imports Icm.Geometry

<TestFixture(), Category("Icm.Geometry")>
Public Class FixedSizeSquareFigureTest

    <Test(), Category("Icm.Geometry")>
    Public Sub FixedSizeSquareFigureTest()

        Dim fig As New FixedSizeSquareFigure("Cuadrado", {""}, GPoint.At(0, 0), 5, FigureCenter.Center)
        Assert.IsTrue(fig.Points(0).Y = fig.Points(1).Y)
        Assert.IsTrue(fig.Points(0).X = fig.Points(3).X)
        Assert.IsTrue(fig.Points(1).X = fig.Points(2).X)
        Assert.IsTrue(fig.Points(2).Y = fig.Points(3).Y)
        Assert.IsTrue((fig.Points(0).Distance(fig.Points(1)) = 5))
        Assert.IsTrue((fig.Points(1).Distance(fig.Points(2)) = 5))
        Assert.IsTrue((fig.Points(2).Distance(fig.Points(3)) = 5))
        Assert.IsTrue((fig.Points(3).Distance(fig.Points(0)) = 5))

    End Sub
End Class
