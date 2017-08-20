Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection

Public Class Startup
    Public Sub New(ByVal conf As IConfiguration)
        Configuration = conf
    End Sub

    Public ReadOnly Property Configuration() As IConfigurationRoot

    ' This method gets called by the runtime. Use this method to add services to the container.
    Public Sub ConfigureServices(ByVal services As IServiceCollection)
        'services.AddAuthentication("Cookies").AddCookie(Function(options)
        '                                                    options.AccessDeniedPath = "/Account/Forbidden/"
        '                                                    options.LoginPath = "/Account/SignIn/"
        '                                                    Return options
        '                                                End Function)
        services.AddMvc()
    End Sub

    ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IHostingEnvironment)

        If env.IsDevelopment() Then
            app.UseDeveloperExceptionPage()
            app.UseBrowserLink()
        Else
            app.UseExceptionHandler("/Home/Error")
        End If

        app.UseStaticFiles()
        'app.UseAuthentication()
        app.UseMvc(Function(routes)
                       routes.MapRoute(name:="default", template:="{controller=Home}/{action=Index}/{id?}")
                       Return routes
                   End Function)
    End Sub
End Class
