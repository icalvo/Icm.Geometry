Imports Icm.Geometry

<TestFixture()>
Public Class IAffineTransformableExtensionsTests

    <Test(), Category("Icm.Geometry")>
    Public Sub RotarCTest()

        'Caso 1
        Dim x As Double = 1
        Dim y As Double = 1
        Dim angule As Double = 3
        Dim actual As GPoint
        Dim other As GPoint = GPoint.At(3, 4)
        Dim expected As GPoint
        expected = GPoint.At(-1.4033450173804924, -1.6877374736816022)
        actual = RotarC(other, angule, x, y)
        Assert.AreEqual(expected, actual)

        'Caso 2
        x = 0
        y = 0
        angule = 0
        expected = GPoint.At(3, 4)
        actual = RotarC(other, angule, x, y)
        Assert.AreEqual(expected, actual)

        'Caso 3
        x = -3
        y = 4
        angule = 0
        expected = GPoint.At(3, 4)
        actual = RotarC(other, angule, x, y)
        Assert.AreEqual(expected, actual)

    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub TrasladarPolarTest()

        'Caso 1
        Dim magnitude As Double = 3
        Dim angule As Double = 3
        Dim actual As GPoint
        Dim other As GPoint = GPoint.At(3, 4)
        Dim expected As GPoint
        expected = GPoint.At(0.030022510198663532, 4.4233600241796012)
        actual = TrasladarPolar(other, angule, magnitude)
        Assert.AreEqual(expected, actual)

        'Caso 2
        magnitude = 0
        angule = 0
        expected = GPoint.At(3, 4)
        actual = TrasladarPolar(other, angule, magnitude)
        Assert.AreEqual(expected, actual)

        'Caso 3
        magnitude = -2
        angule = 2
        expected = GPoint.At(3.8322936730942847, 2.1814051463486366)
        actual = TrasladarPolar(other, angule, magnitude)
        Assert.AreEqual(expected, actual)

        'Caso 4
        magnitude = 3
        angule = -1
        expected = GPoint.At(4.6209069176044189, 1.4755870455763107)
        actual = TrasladarPolar(other, angule, magnitude)
        Assert.AreEqual(expected, actual)

    End Sub

    <Test(), Category("Icm.Geometry")>
    Public Sub EscalarCTest()

        'Caso 1
        Dim x As Double = 1
        Dim y As Double = 1
        Dim factor As Double = 3
        Dim actual As GPoint
        Dim other As GPoint = GPoint.At(3, 4)
        Dim expected As GPoint
        expected = GPoint.At(7, 10)
        actual = EscalarC(other, factor, x, y)
        Assert.AreEqual(expected, actual)

        'Caso 2
        x = 0
        y = 0
        factor = 0
        expected = GPoint.At(0, 0)
        actual = EscalarC(other, factor, x, y)
        Assert.AreEqual(expected, actual)

        'Caso 3
        x = -3
        y = 4
        factor = 0
        expected = GPoint.At(-3, 4)
        actual = EscalarC(other, factor, x, y)
        Assert.AreEqual(expected, actual)

    End Sub


    <Test(), Category("Icm.Geometry")>
    Public Sub EscalarPTest()

        'Caso 1
        Dim factor As Double = 3
        Dim actual As GPoint
        Dim other As GPoint = GPoint.At(3, 4)
        Dim expected As GPoint
        expected = GPoint.At(9, 12)
        actual = EscalarP(other, factor)
        Assert.AreEqual(expected, actual)

        'Caso 2
        factor = 0
        expected = GPoint.At(0, 0)
        actual = EscalarP(other, factor)
        Assert.AreEqual(expected, actual)

        'Caso 3
        factor = -1
        expected = GPoint.At(-3, -4)
        actual = EscalarP(other, factor)
        Assert.AreEqual(expected, actual)
    End Sub
End Class
