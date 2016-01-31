''' <summary>
''' VB6的Strings模块
''' </summary>
Friend Module Strings
    Public Function Split(Src As String, Spl As String) As String()
        Return Src.Split({Spl}, StringSplitOptions.None)
    End Function
End Module
