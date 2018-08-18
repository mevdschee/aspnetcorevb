Imports Microsoft.AspNetCore
Imports Microsoft.AspNetCore.Hosting

Module Program

    Sub Main(args As String())
        CreateWebHostBuilder(args).Build().Run()
    End Sub

    Function CreateWebHostBuilder(args As String()) As IWebHostBuilder
        Return WebHost.CreateDefaultBuilder(args).UseStartup(Of Startup)
    End Function
End Module