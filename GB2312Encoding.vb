#If WINDOWS_UWP Then
Imports Windows.Storage
Imports Windows.Storage.AccessCache

Friend Module GB2312Encoding
    '需要Nuget包System.Text.Encoding.CodePages和文件访问权限
    Dim OpenPicker As New Pickers.FileOpenPicker
    Sub New()
        OpenPicker.FileTypeFilter.Add(".ini")
        OpenPicker.CommitButtonText = "选取"
    End Sub
    Async Function ReadAllTextAsync(File As IStorageFile) As Task(Of String)
        Dim Bytes = (Await FileIO.ReadBufferAsync(File)).ToArray
        Dim gb2312 = System.Text.CodePagesEncodingProvider.Instance.GetEncoding("gb2312")
        Return gb2312.GetString(Bytes)
    End Function
    Function ReadAllTextAsync(Bytes As Byte()) As String
        Dim gb2312 = System.Text.CodePagesEncodingProvider.Instance.GetEncoding("gb2312")
        Return gb2312.GetString(Bytes)
    End Function
    Async Function ReadAllTextAsync(FilePath As String) As Task(Of String)
        Dim Bytes As Byte() = Nothing
        Dim lastex As UnauthorizedAccessException = Nothing
        Try
            Bytes = (Await PathIO.ReadBufferAsync(FilePath)).ToArray
        Catch ex As UnauthorizedAccessException
            lastex = ex
        End Try
        If Bytes Is Nothing Then
            Dim f As StorageFile = Nothing
            If Await MsgBoxAsync($"文件{FilePath}没有读取权限。请手动选取文件以获得这个读取权。", True, "无法读取") Then
                f = Await OpenPicker.PickSingleFileAsync
                Do While f?.Path IsNot Nothing AndAlso f.Path.ToLower <> FilePath.ToLower
                    If Await MsgBoxAsync($"嗯。。。我想，你可能把文件名搞错了。
我重复一遍，文件名是{FilePath}。
如果你想重选，就请按确定。否则这个文件不能被读取。", True, "文件路径错误") Then
                        f = Await OpenPicker.PickSingleFileAsync
                    Else
                        f = Nothing
                        Exit Do
                    End If
                Loop
            End If
            If f Is Nothing Then
                Throw lastex
            End If
            StorageApplicationPermissions.FutureAccessList.Add(f)
            Bytes = (Await FileIO.ReadBufferAsync(f)).ToArray
        End If
        Dim gb2312 = System.Text.CodePagesEncodingProvider.Instance.GetEncoding("gb2312")
        Return gb2312.GetString(Bytes)
    End Function
    '需要Nuget包System.Text.Encoding.CodePages和文件访问权限
    Async Function WriteAllTextAsync(FilePath As String, Content$) As Task
        Dim gb2312 = System.Text.CodePagesEncodingProvider.Instance.GetEncoding("gb2312")
        Dim Bytes = gb2312.GetBytes(Content)
        Await PathIO.WriteBytesAsync(FilePath, Bytes)
    End Function
End Module
#End If
