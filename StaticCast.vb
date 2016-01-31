Friend Class StaticCast(Of T As Structure)
    Private Ptr As PinnedPointer(Of T)

    Sub New(Source As T)
        Ptr = New PinnedPointer(Of T)(Source)
    End Sub

    Public Function UnsafeCast(Of TDest As Structure)() As TDest
        Return Ptr.Cast(Of TDest).Target
    End Function
End Class
Friend Class StaticCast(Of TSource As Structure, TDest As Structure)
    Private Ptr As PinnedPointer(Of TSource)

    Sub New(Source As TSource)
        Ptr = New PinnedPointer(Of TSource)(Source)
    End Sub
    Shared Widening Operator CType(Source As StaticCast(Of TSource, TDest)) As TDest
        Return Source.Ptr.Cast(Of TDest).Target
    End Operator
End Class
Friend Module UnsafeCast
    <Extension>
    Public Function static_cast(Of TSource As Structure, TDest As Structure)(Source As TSource) As TDest
        Dim Ptr As New PinnedPointer(Of TSource)(Source)
        Return Ptr.Cast(Of TDest).Target
    End Function
End Module