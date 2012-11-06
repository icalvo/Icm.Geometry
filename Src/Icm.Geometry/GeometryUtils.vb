Public Module GeometryUtils
    Private epsilon_ As Double = 0.00001
    ''' <summary>
    ''' Determines whether two directions are close enough to consider them to be longitudinally aligned.
    ''' </summary>
    ''' <param name="angle1">Angle indicating first direction in radians</param>
    ''' <param name="angle2">Angle indicating first direction in radians</param>
    ''' <param name="marginAngle">Maximum difference between directions for them to be considered longitudinal.</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' <para>A direction is indicated with an angle over the X axis. Both directions must be compared in both ways to 
    ''' determine if they are aligned (for example, both 7º, 187º and -173º indicate the same direction).</para>
    ''' </remarks>
    Public Function AreLongitudinal(ByVal angle1 As Double, ByVal angle2 As Double, Optional ByVal marginAngle As Double = Math.PI / 2) As Boolean
        Dim normalAngle1, normalAngle2 As Double

        normalAngle1 = angle1
        normalAngle2 = angle2

        Do Until normalAngle1 >= 0
            normalAngle1 += Math.PI
        Loop
        Do Until normalAngle1 < Math.PI
            normalAngle1 -= Math.PI
        Loop
        Do Until normalAngle2 >= 0
            normalAngle2 += Math.PI
        Loop
        Do Until normalAngle2 < Math.PI
            normalAngle2 -= Math.PI
        Loop

        Dim dif As Double

        dif = Math.Abs(normalAngle1 - normalAngle2)

        Return dif < marginAngle
    End Function

    Public Function AreTransversal(ByVal angle1 As Double, ByVal angle2 As Double, Optional ByVal marginAngle As Double = Math.PI / 2) As Boolean
        Return Not AreLongitudinal(angle1, angle2, marginAngle)
    End Function
    Public Function PuntoEnRecta(ByVal p As GPoint, ByVal ángulo As Double, ByVal x As GPoint) As GPoint

        Dim v1 As Double = x.X
        Dim v2 As Double = x.Y
        If Double.IsNaN(Slope(ángulo)) Then
            v1 = p.X
            v2 = x.Y

        Else
            If Math.Abs(Grad(ángulo)) < 45 Then
                If ángulo >= 0 Then
                    If x.X < p.X Then
                        v2 = p.Y - Math.Abs(x.X - p.X) * Slope(ángulo)
                    Else
                        v2 = p.Y + Math.Abs(x.X - p.X) * Slope(ángulo)
                    End If
                Else

                    If x.X < p.X Then
                        v2 = p.Y + Math.Abs(x.X - p.X) * Slope(-ángulo)
                    Else
                        v2 = p.Y - Math.Abs(x.X - p.X) * Slope(-ángulo)
                    End If
                End If
            Else
                If ángulo >= 0 Then
                    If x.Y < p.Y Then
                        v1 = p.X - Math.Abs(x.Y - p.Y) / Slope(ángulo)
                    Else
                        v1 = p.X + Math.Abs(x.Y - p.Y) / Slope(ángulo)
                    End If
                Else

                    If x.Y < p.Y Then
                        v1 = p.X + Math.Abs(x.Y - p.Y) / Slope(-ángulo)
                    Else
                        v1 = p.X - Math.Abs(x.Y - p.Y) / Slope(-ángulo)
                    End If
                End If

            End If
        End If

        Return GPoint.At(v1, v2)
    End Function
    Public Function PuntoEnSegmento(ByVal pt1 As GPoint, ByVal pt2 As GPoint, ByVal x As GPoint) As GPoint
        Dim seg As New GSegment(pt1, pt2)
        Dim v As GPoint = PuntoEnRecta(pt1, seg.Angle, x)
        If seg.DistanceToPoint(v) <= epsilon_ Then
            Return v
        Else
            If v.Distance(pt1) < v.Distance(pt2) Then
                Return pt1
            Else
                Return pt2
            End If
        End If
    End Function
    Public Function PuntoEnPolilínea(ByVal x As GPoint, ByVal ParamArray poli() As GPoint) As GPoint

        Dim v As GPoint
        Dim dist As Double = Double.MaxValue

        For j As Integer = 1 To poli.Length - 1
            v = PuntoEnSegmento(poli(j - 1), poli(j), x)
            If v.Distance(x) < dist Then
                PuntoEnPolilínea = v
                dist = v.Distance(x)
            End If
        Next
    End Function

End Module
