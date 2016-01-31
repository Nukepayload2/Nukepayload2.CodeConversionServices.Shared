#If WINDOWS_UWP Then
Friend MustInherit Class Xaml2HtmlNavigationPage
    Inherits Page
    Sub New()
        MyBase.New
    End Sub
    Public MustOverride ReadOnly Property HtmlPageUri As Uri
    Protected Shared Function GetUriFromPagePath(PagePath As String) As Uri
        Return New Uri("ms-appx-web:///" & PagePath, UriKind.Absolute)
    End Function
    WithEvents Webv As New WebView
    Private Sub Xaml2HtmlNavigationPage_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Webv.Navigate(HtmlPageUri)
    End Sub

    Private Sub Xaml2HtmlNavigationPage_Loading(sender As FrameworkElement, args As Object) Handles Me.Loading
        Content = New TextBlock With {.VerticalAlignment = VerticalAlignment.Center, .HorizontalAlignment = HorizontalAlignment.Center, .Text = "马上就好...", .FontSize = 50}
    End Sub

    Private Sub Webv_LoadCompleted(sender As Object, e As NavigationEventArgs) Handles Webv.LoadCompleted
        Content = Webv
    End Sub
End Class
#End If
