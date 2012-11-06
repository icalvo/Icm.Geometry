Imports Icm.Geometry
<TestFixture()>
Public Class MathUtilsTest

    'TEST GRAD
    <Test(), Category("Icm.Geometry")>
    Public Sub GradTest()

        'Caso 1
        Dim alfa As Double = 0
        Dim actual As Double
        Dim expected As Double = 0
        actual = Grad(alfa)
        Assert.AreEqual(actual, expected)

        'Caso 2
        alfa = -1
        expected = -57.295779513082323
        actual = Grad(alfa)
        Assert.AreEqual(actual, expected)

    End Sub

    'TEST RAD
    <Test(), Category("Icm.Geometry")>
    Public Sub RadTest()

        'Caso 1
        Dim alfa As Double = 0
        Dim actual As Double
        Dim expected As Double = 0
        actual = Grad(alfa)
        Assert.AreEqual(actual, expected)

        'Caso 2
        alfa = -1
        expected = -57.295779513082323
        actual = Grad(alfa)
        Assert.AreEqual(actual, expected)
        Assert.IsTrue(Math.PI / 2 = Rad(90))

    End Sub

    'TEST CHORD
    <Test(), Category("Icm.Geometry")>
    Public Sub ChordTest()

        'Caso 1
        Dim radius As Double = 0
        Dim angle As Double = 0
        Dim actual As Double
        actual = Chord(radius, angle)
        Dim expected As Double = 0
        Assert.AreEqual(expected, actual)

        'Caso 2
        radius = 1
        angle = 90
        expected = 1.7018070490682369
        actual = Chord(radius, angle)
        Assert.AreEqual(expected, actual)

    End Sub

    'TEST SLOPE
    <Test(), Category("Icm.Geometry")>
    Public Sub SlopeTest()

        'Caso 1
        Dim angle As Double = 90
        Dim actual As Double
        Dim expected As Double = -1.9952004122082421
        actual = Slope(angle)
        Assert.AreEqual(expected, actual)

        'Caso 2
        angle = 1.5707963267948966
        actual = Slope(angle)
        expected = Double.NaN
        Assert.AreEqual(expected, actual)

    End Sub

    'TEST HYPOTENUSE
    <Test(), Category("Icm.Geometry")>
    Public Sub HypotenuseTest()

        'Caso 1
        Dim leg1 As Double = 1
        Dim leg2 As Double = 1
        Dim expected As Double = 1.4142135623730951
        Dim actual As Double
        actual = Hypotenuse(leg1, leg2)
        Assert.AreEqual(expected, actual)

        'Caso 2
        leg1 = 0
        leg2 = 0
        expected = 0
        actual = Hypotenuse(leg1, leg2)
        Assert.AreEqual(expected, actual)

        'Caso 3
        leg1 = 5
        leg2 = 5
        expected = 7.0710678118654755
        actual = Hypotenuse(leg1, leg2)
        Assert.AreEqual(expected, actual)

    End Sub

    'TEST LEG
    <Test(), Category("Icm.Geometry")>
    Public Sub LegTest()

        'Caso 1
        Dim hypothenuse As Double = 1
        Dim otherleg As Double = 1
        Dim expected As Double = 0
        Dim actual As Double
        actual = Leg(hypothenuse, otherleg)
        Assert.AreEqual(expected, actual)

        'Caso 2
        hypothenuse = 0
        otherleg = 0
        expected = 0
        actual = Leg(hypothenuse, actual)
        Assert.AreEqual(expected, actual)


    End Sub

    'TEST IFNAN
    <Test(), Category("Icm.Geometry")>
    Public Sub IfNaNTest()

        Dim d As Double = 0
        Dim subs As Double = 0
        Dim actual As Double
        Dim expected = 0
        actual = IfNaN(d, subs)
        Assert.AreEqual(expected, actual)

        'Caso 2
        d = 3
        subs = 3
        expected = 3
        actual = IfNaN(d, subs)
        Assert.AreEqual(expected, actual)



    End Sub

End Class
