Imports Windows.System.Profile.AnalyticsInfo
Friend Module SystemVersion
    <Extension>
    Function ToDisplayString$(ver As PackageVersion)
        Return $"{ver.Revision}.{ver.Build}.{ver.Minor}.{ver.Major}"
    End Function
    Friend Function GetWindowsVersionAndType$()
        Return VersionInfo.DeviceFamily & ", 
" & CULng(VersionInfo.DeviceFamilyVersion).static_cast(Of PackageVersion).ToDisplayString
    End Function
End Module