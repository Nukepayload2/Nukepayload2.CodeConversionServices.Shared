#If WINDOWS_UWP Then
Friend Module ContentDialogSimulateWindow
    Public Async Function ShowInnerPageWithViewmodel(Of Tvm)(CurrentDialog As ContentDialog, ViewModel As Tvm, PageType As Type) As Task
        Dim Frm As New Frame
        CurrentDialog.Content = Frm
        Frm.Navigate(PageType, ViewModel)
        CurrentDialog.PrimaryButtonText = "确定"
        Await CurrentDialog.ShowAsync()
    End Function
End Module
#End If
