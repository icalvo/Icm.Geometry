Imports System.ComponentModel
<Serializable(), DebuggerDisplay("({X},{Y})")>
Public Structure GPoint
    Implements IAffineTransformable

    Public X As Double
    Public Y As Double

    Private Sub New(ByVal px As Double, ByVal py As Double)
        X = px
        Y = py
    End Sub
    'Public Sub New(ByVal bx As Double, ByVal by As Double)
    '    X = bx
    '    Y = by
    'End Sub
    Public Shared Function At(ByVal px As Double, ByVal py As Double) As GPoint
        Return New GPoint(px, py)
    End Function

    Public Shared Function Origin() As GPoint
        Return New GPoint(0, 0)
    End Function


    Public Function Rotate(ByVal ángulo As Double) As IAffineTransformable Implements IAffineTransformable.Rotate
        Dim resultado As GPoint
        Dim cos As Double = Math.Cos(ángulo)
        Dim sen As Double = Math.Sin(ángulo)

        Dim antiguoX = X

        resultado = New GPoint() With {
            .X = X * cos - Y * sen,
            .Y = X * sen + Y * cos
        }

        Return resultado
    End Function

    Public Function Translate(ByVal dx As Double, ByVal dy As Double) As IAffineTransformable Implements IAffineTransformable.Translate
        Return New GPoint With {
            .X = X + dx,
            .Y = Y + dy
        }
    End Function

    Public Function Scale(ByVal factorX As Double, ByVal factorY As Double) As IAffineTransformable Implements IAffineTransformable.Scale
        Return New GPoint With {
            .X = X * factorX,
            .Y = Y * factorY
        }
    End Function

    Public Overrides Function ToString() As String
        Return ToString(4)
    End Function

    Public Overloads Function ToString(ByVal prec As Integer) As String
        Return String.Format("({0:#0." & New String("0"c, prec) & "} , {1:#0." & New String("0"c, prec) & "})", X, Y)
    End Function

    Public Function [Module]() As Double
        Return Math.Sqrt(X * X + Y * Y)
    End Function

    ''' <summary>
    ''' Euclidean distance
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Distance(ByVal other As GPoint) As Double
        If Double.IsNaN(other.X) OrElse Double.IsNaN(other.Y) Then
            Return Double.NaN
        Else
            Return Hypotenuse(other.X - X, other.Y - Y)
        End If
    End Function

    ''' <summary>
    ''' Mean point between two points
    ''' </summary>
    ''' <param name="other"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Mean(ByVal other As GPoint) As GPoint
        Return GPoint.At(
            (X + other.X) / 2,
            (Y + other.Y) / 2
        )
    End Function
End Structure
