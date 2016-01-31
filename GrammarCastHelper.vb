Friend Module GrammarCastHelper
    Public Function SetValue(Of T)(ByRef Target As T, Source As T) As T
        Target = Source
        Return Source
    End Function
End Module
