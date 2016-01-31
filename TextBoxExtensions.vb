Module TextBoxExtensions
    <Extension>
    Sub AppendText(txt As TextBox, Text As String)
        txt.SelectionStart = txt.Text.Length
        txt.SelectionLength = 0
        txt.SelectedText = Text
    End Sub
    <Extension>
    Sub InsertText(txt As TextBox, Text As String)
        txt.SelectionLength = 0
        txt.SelectedText = Text
        txt.SelectionStart += Text.Length
    End Sub
    <Extension>
    Sub Backspace(txt As TextBox)
        If txt.SelectionStart > 0 Then
            txt.SelectionStart -= 1
            txt.SelectionLength = 1
            txt.SelectedText = ""
        End If
    End Sub
End Module
