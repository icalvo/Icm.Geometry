Imports System.Runtime.CompilerServices

Public Module MathUtils

    ''' <summary>
    ''' Converts an angle from radians to sexagesimal degrees.
    ''' </summary>
    ''' <param name="alfa"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Grad(ByVal alfa As Double) As Double
        Return alfa * 180 / Math.PI
    End Function

    ''' <summary>
    ''' Converts an angle from sexagesimal degrees to radians.
    ''' </summary>
    ''' <param name="alfa"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Rad(ByVal alfa As Double) As Double
        Return alfa * Math.PI / 180
    End Function

    Public Function Chord(ByVal radius As Double, ByVal angle As Double) As Double
        Return 2 * radius * Math.Sin(angle / 2)
    End Function

    ''' <summary>
    ''' Slope of an angle (tangent), returning NaN if the angle is PI/2.
    ''' </summary>
    ''' <param name="angle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Slope(ByVal angle As Double) As Double
        If Math.Abs(angle) = Math.PI / 2 Then
            Return Double.NaN
        Else
            Return Math.Tan(angle)
        End If
    End Function

    ''' <summary>
    ''' Hypotenuse of a right triangle.
    ''' </summary>
    ''' <param name="leg1">One leg of the triangle</param>
    ''' <param name="leg2">The other leg of the triangle</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Hypotenuse(ByVal leg1 As Double, ByVal leg2 As Double) As Double
        Return Math.Sqrt(leg1 * leg1 + leg2 * leg2)
    End Function

    ''' <summary>
    ''' Leg of a right triangle.
    ''' </summary>
    ''' <param name="hypothenuse">Hypotenuse</param>
    ''' <param name="otherLeg">The other leg of the triangle</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Leg(ByVal hypothenuse As Double, ByVal otherLeg As Double) As Double
        Return Math.Sqrt(hypothenuse * hypothenuse - otherLeg * otherLeg)
    End Function

    ''' <summary>
    ''' Substitutes a double if it is NaN.
    ''' </summary>
    ''' <param name="d"></param>
    ''' <param name="subs"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function IfNaN(ByVal d As Double, ByVal subs As Double) As Double
        Return d.IfNaN(subs, d)
    End Function

    ''' <summary>
    ''' Substitutes a double if it is NaN.
    ''' </summary>
    ''' <param name="d"></param>
    ''' <param name="ifIsNaN"></param>
    ''' <param name="ifElse"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension()>
    Public Function IfNaN(ByVal d As Double, ByVal ifIsNaN As Double, ByVal ifElse As Double) As Double
        If Double.IsNaN(d) Then
            Return ifIsNaN
        Else
            Return ifElse
        End If
    End Function
    Public Function IsEven(ByVal n As Integer) As Boolean
        Dim r As Integer
        Math.DivRem(n, 2, r)
        Return r = 0
    End Function
 
End Module
