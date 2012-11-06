Imports Icm.Geometry

<TestFixture()>
Public Class ContainerFigureTest

    <Test(), Category("Icm.Geometry")>
    Public Sub AddTest()

        'Caso1: Children are added (Figures triangle and rectangle) to the container
        'Add Rectangulo
        Dim contenedor As New ContainerFigure("Contenedor", {""})
        Dim segmentfig As New RectangleFigure("Rectangulo", {""}, 2, Icm.Geometry.FigureCenter.TopLeft)
        Dim actual As BaseFigure = segmentfig
        contenedor.Add(actual)

        'Add Triangulo
        Dim poligonFig As New PolygonFigure("Triangulo", {""}, GPoint.At(1, 1), GPoint.At(2, 2), GPoint.At(3, 3))
        Dim actual2 As BaseFigure = poligonFig
        contenedor.Add(actual2)

        Assert.IsTrue(contenedor.Children.Count = 2)
        Assert.IsTrue(contenedor.Children.Keys(1) = "Triangulo" And contenedor.Children.Keys(0) = "Rectangulo")
        Assert.IsTrue(contenedor.Children.ContainsKey("Triangulo") And contenedor.Children.ContainsKey("Rectangulo"))
    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub CloneTest()

        'Caso1: Container with children is cloned triangle and rectangle
        'Add Rectangulo
        Dim contenedor As New ContainerFigure("Contenedor", {"Maria"})
        Dim segmentfig As New RectangleFigure("Rectangulo", {""}, 2, Icm.Geometry.FigureCenter.TopLeft)
        Dim actual As BaseFigure = segmentfig
        contenedor.Add(actual)

        'Add Triangulo
        Dim poligonFig As New PolygonFigure("Triangulo", {""}, GPoint.At(1, 1), GPoint.At(2, 2), GPoint.At(3, 3))
        Dim actual2 As BaseFigure = poligonFig
        contenedor.Add(actual2)

        Dim ContenedorClonado As New ContainerFigure("", {""})
        ContenedorClonado = CType(contenedor.Clone("Contenedor"), ContainerFigure)
        Assert.IsFalse(contenedor Is ContenedorClonado)
        Assert.IsTrue(contenedor.DrawClasses(0) = ContenedorClonado.DrawClasses(0))

    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub SustituirHijoTest()

        'Caso1 : Replace rectangle contained by the triangle, the key must be equal

        Dim contenedor As New ContainerFigure("Contenedor", {"Maria"})
        Dim segmentfig As New RectangleFigure("Rectangulo", {""}, 2, Icm.Geometry.FigureCenter.TopLeft)
        Dim actual As BaseFigure = segmentfig
        contenedor.Add(actual)

        Dim poligonFig As New PolygonFigure("Rectangulo", {""}, GPoint.At(1, 1), GPoint.At(2, 2), GPoint.At(3, 3))
        Dim actual2 As BaseFigure = poligonFig

        Dim ContenedorClonado As New ContainerFigure("", {""})
        ContenedorClonado = CType(contenedor.Clone("Contenedor"), ContainerFigure)

        contenedor.SustituirHijo(actual2)
        Assert.IsFalse(contenedor.Children Is ContenedorClonado.Children)

    End Sub

End Class
