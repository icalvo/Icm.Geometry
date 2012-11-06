Public Interface ISimpleFigure
    Inherits IFigure

    ReadOnly Property Points As List(Of GPoint)

    Function Area() As Double

End Interface
