Imports System.Runtime.CompilerServices

Public Module ICollectionExtensions

    <Extension>
    Public Sub AddRange(Of T)(col As ICollection(Of T), other As IEnumerable(Of T))
        For Each item In other
            col.Add(item)
        Next
    End Sub

End Module
