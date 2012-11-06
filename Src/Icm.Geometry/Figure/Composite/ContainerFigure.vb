''' <summary>
''' The most typical composite figure, composed by an arbitrary, modifiable list of
''' children figures.
''' </summary>
''' <remarks></remarks>
Public Class ContainerFigure
    Inherits CompositeFigure

    Private ReadOnly children_ As New SortedDictionary(Of String, IFigure)()


    Overrides ReadOnly Property Children As SortedDictionary(Of String, IFigure)
        Get
            Return children_
        End Get
    End Property

    Public Sub New(ByVal key As String, ByVal ParamArray drawClasses As String())
        MyBase.New(key, drawClasses)
    End Sub


    Public Sub Add(ByVal fig As IFigure)
        children_.Add(fig.Key, fig)
    End Sub

    Public Sub AddMany(ByVal ParamArray figures() As IFigure)
        For Each fig In figures
            Add(fig)
        Next
    End Sub

    Public Sub SustituirHijo(ByVal fig As IFigure)
        children_(fig.Key) = fig
    End Sub

    Public Overrides Function Clone(ByVal clave As String) As IFigure
        Dim nueva As ContainerFigure
        If String.IsNullOrEmpty(clave) Then
            nueva = New ContainerFigure(Me.Key)
        Else
            nueva = New ContainerFigure(clave)
        End If

        For Each h In Children.Values
            nueva.Add(h.Clone(Nothing))
        Next
        nueva.DrawClasses.AddRange(Me.DrawClasses)
        Return nueva
    End Function

End Class
