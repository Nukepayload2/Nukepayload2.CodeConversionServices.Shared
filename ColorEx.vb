Option Strict Off
#If WINDOWS_UWP Then
Imports Windows.UI

Friend Module ColorEx
    Public Function ColorFromInt32(Color As Integer) As Color
        Return ColorFromUInt32(BitConverter.ToUInt32(BitConverter.GetBytes(Color), 0))
    End Function
    Public Function ColorFromUInt32(Color As UInteger) As Color
        Return New Color() With {.A = Color >> 24, .R = (Color >> 16) And 255, .G = (Color >> 8) And 255, .B = Color And 255}
    End Function
End Module
#End If
