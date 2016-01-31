#If WINDOWS_UWP Or WINDOWS_PHONE_APP Then
Friend Module RichEditBoxExtension
    <Extension>
    Public Function GetText(txb As RichEditBox) As String
        Dim s = ""
        txb.Document.GetText(Windows.UI.Text.TextGetOptions.None, s)
        Return s
    End Function
    <Extension>
    Public Sub SetText(txb As RichEditBox, Content As String)
        txb.Document.SetText(Windows.UI.Text.TextSetOptions.None, Content)
    End Sub
End Module
#End If
