Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Logging

Public Class Startup
    Public Sub New(ByVal env As IHostingEnvironment)
        Dim builder = (New ConfigurationBuilder()).SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional:=False, reloadOnChange:=True).AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:=True).AddEnvironmentVariables()
        Configuration = builder.Build()
    End Sub

    Public ReadOnly Property Configuration() As IConfigurationRoot

    ' This method gets called by the runtime. Use this method to add services to the container.
    Public Sub ConfigureServices(ByVal services As IServiceCollection)
        ' Add framework services.
        services.AddAuthentication("Cookies").AddCookie(Function(options) 
            options.AccessDeniedPath = "/Account/Forbidden/"
            options.LoginPath = "/Account/SignIn/"
            return options
        End Function)
        services.AddMvc()
    End Sub

    ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IHostingEnvironment, ByVal loggerFactory As ILoggerFactory)
        loggerFactory.AddConsole(Configuration.GetSection("Logging"))
        loggerFactory.AddDebug()

        app.UseAuthentication()
        app.UseMvc()
    End Sub
End Class
