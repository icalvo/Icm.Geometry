Public Interface ICompositeFigure
    Inherits IFigure, IEnumerable(Of IFigure)

    ReadOnly Property Children As SortedDictionary(Of String, IFigure)

End Interface

