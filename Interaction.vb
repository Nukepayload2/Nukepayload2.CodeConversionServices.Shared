#If WINDOWS_UWP Then
Imports Windows.UI.Popups

Friend Module Interaction
    Async Function MsgBoxAsync(Prompt$, HasCancel As Boolean, Title$, Optional OK$ = "确定", Optional Cancel$ = "取消") As Task(Of Boolean?)
        Dim dlg As New MessageDialog(Prompt, Title)
        Dim Result As Boolean?
        If HasCancel Then
            Dim msg As New MessageDialog(Prompt, Title)
            msg.Commands.Add(New UICommand(OK, Sub(command) Result = True))
            msg.Commands.Add(New UICommand(Cancel, Sub(command) Result = False))
            msg.DefaultCommandIndex = 0
            msg.CancelCommandIndex = 1
            Dim tsk = msg.ShowAsync
            Await tsk
            Return Result
        Else
            Await New MessageDialog(Prompt, Title).ShowAsync
            Return True
        End If
    End Function
End Module

#End If
