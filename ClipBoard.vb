#If WINDOWS_UWP Then
Imports Windows.ApplicationModel

Friend Module ClipBoard
    Public Sub SetText(Text As String)
        Dim Pkg As New DataTransfer.DataPackage
        Pkg.SetText(Text)
        DataTransfer.Clipboard.SetContent(Pkg)
    End Sub
End Module
#End If
