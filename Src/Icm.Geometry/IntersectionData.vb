
Public Class IntersectionData
    Private type_ As IntersectionType

    Private intersectionPoints_() As GPoint

    Sub New()

    End Sub

    ReadOnly Property Type() As IntersectionType
        Get
            Return type_
        End Get
    End Property

    ReadOnly Property IntersectionPoints() As GPoint()
        Get
            Return intersectionPoints_
        End Get
    End Property

    Public Sub New(ByVal t As IntersectionType, ByVal ParamArray ip() As GPoint)
        type_ = t
        intersectionPoints_ = ip
    End Sub
End Class


Public Enum IntersectionType
    NonIntersecting
    InsideIntersecting
    EndIntersecting
    Parallel
    Coincident
End Enum
