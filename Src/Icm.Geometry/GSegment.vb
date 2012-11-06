Public Class GSegment
    Implements IAffineTransformable

    Public p1_ As GPoint
    Public p2_ As GPoint

    Public Sub New(ByVal p1 As GPoint, ByVal p2 As GPoint)
        p1_ = p1
        p2_ = p2
    End Sub

    Public Function Rotate(ByVal angle As Double) As IAffineTransformable Implements IAffineTransformable.Rotate
        Return New GSegment(p1_.RotateT(angle), p2_.RotateT(angle))
    End Function

    Public Function Scale(ByVal factorX As Double, ByVal factorY As Double) As IAffineTransformable Implements IAffineTransformable.Scale
        Return New GSegment(p1_.ScaleT(factorX, factorY), p2_.ScaleT(factorX, factorY))
    End Function

    Public Function Translate(ByVal x As Double, ByVal y As Double) As IAffineTransformable Implements IAffineTransformable.Translate
        Return New GSegment(p1_.TranslateT(x, y), p2_.TranslateT(x, y))
    End Function

    ''' <summary>
    ''' Determines the type of intersection between 2 segments
    ''' </summary>
    ''' <param name="other">The other segment</param>
    ''' <returns>Value of type IntersectionData</returns>
    ''' <remarks></remarks>
    Public Function Intersects(ByVal other As GSegment) As Boolean
        Dim a1x, a1y, a2x, a2y, b1x, b1y, b2x, b2y As Double

        a1x = p1_.X
        a1y = p1_.Y
        a2x = p2_.X
        a2y = p2_.Y
        b1x = other.p1_.X
        b1y = other.p1_.Y
        b2x = other.p2_.X
        b2y = other.p2_.Y

        If (a1x = b1x AndAlso a1y = b1y) OrElse _
           (a1x = b2x AndAlso a1y = b2y) Then
            ' End intersecting
            Return True
        End If

        If (a2x = b1x AndAlso a2y = b1y) OrElse _
           (a2x = b2x AndAlso a2y = b2y) Then
            ' End intersecting
            Return True
        End If

        Dim ua_t = (b2x - b1x) * (a1y - b1y) - (b2y - b1y) * (a1x - b1x)
        Dim ub_t = (a2x - a1x) * (a1y - b1y) - (a2y - a1y) * (a1x - b1x)
        Dim u_b = (b2y - b1y) * (a2x - a1x) - (b2x - b1x) * (a2y - a1y)

        If u_b <> 0 Then
            Dim ua = ua_t / u_b
            Dim ub = ub_t / u_b

            ' If true: Inside, if false: Non intersecting
            Return (0 <= ua AndAlso ua <= 1 AndAlso 0 <= ub AndAlso ub <= 1)
        Else
            ' If true: Coincident, if false: Parallel
            Return (ua_t = 0 OrElse ub_t = 0)
        End If
    End Function

    ''' <summary>
    ''' Determines the type of intersection between 2 segments
    ''' </summary>
    ''' <param name="other">The other segment</param>
    ''' <returns>Value of type IntersectionData</returns>
    ''' <remarks></remarks>
    Public Function Intersection(ByVal other As GSegment) As IntersectionData
        Dim a1x, a1y, a2x, a2y, b1x, b1y, b2x, b2y As Double

        a1x = p1_.X
        a1y = p1_.Y
        a2x = p2_.X
        a2y = p2_.Y
        b1x = other.p1_.X
        b1y = other.p1_.Y
        b2x = other.p2_.X
        b2y = other.p2_.Y

        Dim result As IntersectionData

        If (a1x = b1x AndAlso a1y = b1y) OrElse _
           (a1x = b2x AndAlso a1y = b2y) Then
            result = New IntersectionData( _
                    IntersectionType.EndIntersecting, _
                    GPoint.At(a1x, a1y))
            Return result
        End If

        If (a2x = b1x AndAlso a2y = b1y) OrElse _
           (a2x = b2x AndAlso a2y = b2y) Then
            result = New IntersectionData( _
                    IntersectionType.EndIntersecting, _
                    GPoint.At(a2x, a2y))
            Return result
        End If

        Dim ua_t = (b2x - b1x) * (a1y - b1y) - (b2y - b1y) * (a1x - b1x)
        Dim ub_t = (a2x - a1x) * (a1y - b1y) - (a2y - a1y) * (a1x - b1x)
        Dim u_b = (b2y - b1y) * (a2x - a1x) - (b2x - b1x) * (a2y - a1y)

        If u_b <> 0 Then
            Dim ua = ua_t / u_b
            Dim ub = ub_t / u_b

            If 0 <= ua AndAlso ua <= 1 AndAlso 0 <= ub AndAlso ub <= 1 Then
                result = New IntersectionData( _
                        IntersectionType.InsideIntersecting, _
                        GPoint.At(a1x + ua * (a2x - a1x), a1y + ua * (a2y - a1y)))
            Else
                result = New IntersectionData(IntersectionType.NonIntersecting)
            End If
        Else
            If ua_t = 0 OrElse ub_t = 0 Then
                result = New IntersectionData(IntersectionType.Coincident)
            Else
                result = New IntersectionData(IntersectionType.Parallel)
            End If
        End If

        Return result
    End Function
    Public Function MiddlePoint() As GPoint
        MiddlePoint = p1_.Mean(p2_)
    End Function

    Public Function Length() As Double
        Return p1_.Distance(p2_)
    End Function

    ''' <summary>
    ''' Angle respect to the abcissa axis.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Angle() As Double
        If p1_.X = p2_.X Then
            If p1_.Y < p2_.Y Then
                Return Math.PI / 2
            Else
                Return -Math.PI / 2
            End If
        Else
            If p1_.X < p2_.X Then
                Return Math.Atan((p2_.Y - p1_.Y) / (p2_.X - p1_.X))
            Else
                Return Math.Atan((p2_.Y - p1_.Y) / (p2_.X - p1_.X)) + Math.PI
            End If

        End If

    End Function

    Public Function DistanceToPoint(ByVal C As GPoint) As Double
        Dim r_numerador As Double
        Dim r_demominador As Double
        Dim r As Double

        Dim P As New GPoint

        Dim s As Double
        Dim distanceLine As Double
        Dim distanceSegment As Double
        Dim distAC As Double
        Dim distBC As Double

        Dim A As Icm.Geometry.GPoint
        Dim B As Icm.Geometry.GPoint


        A = p1_
        B = p2_
        r_numerador = (C.X - A.X) * (B.X - A.X) + (C.Y - A.Y) * (B.Y - A.Y)
        r_demominador = Math.Pow((B.X - A.X), 2) + Math.Pow((B.Y - A.Y), 2)
        r = r_numerador / r_demominador

        P.X = A.X + r * (B.X - A.X)
        P.Y = A.Y + r * (B.Y - A.Y)

        s = ((A.Y - C.Y) * (B.X - A.X) - (A.Y - C.Y) * (B.Y - A.Y)) / r_demominador
        distanceLine = C.Distance(P)

        If r >= 0 AndAlso r <= 1 Then

            distanceSegment = distanceLine
        Else
            distAC = A.Distance(C)
            distBC = B.Distance(C)
            distanceSegment = Math.Min(distAC, distBC)
        End If
        Return distanceSegment
    End Function

    ''' <summary>
    ''' Segment starting at P1 with module m, with the same direction as the current one.
    ''' </summary>
    ''' <param name="m"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SegmentoDeMódulo(ByVal m As Double) As GSegment
        'Genera un segmento que empieza en p1_, tiene módulo m y es proporcional a Me
        ' EQUIVALENTE:
        Dim result As New GSegment(p1_, p2_)
        result.TranslateT(-p1_.X, -p1_.Y)
        result.ScaleT(m / Length(), m / Length())
        result.TranslateT(p1_.X, p1_.Y)
        Return result
        Return New GSegment(p1_, GPoint.At(((m * (p2_.X - p1_.X)) / Length()) + p1_.X, ((m * (p2_.Y - p1_.Y)) / Length()) + p1_.Y))
    End Function
End Class
