Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Http
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection

Public Class Startup
    Public Sub New(ByVal configuration As IConfiguration)
        configuration = configuration
    End Sub

    Public ReadOnly Property Configuration() As IConfiguration

    ' This method gets called by the runtime. Use this method to add services to the container.
    Public Sub ConfigureServices(ByVal services As IServiceCollection)

        services.Configure(Of CookiePolicyOptions)(Function(options)
                                                       options.CheckConsentNeeded = Function(context)
                                                                                        Return True
                                                                                    End Function
                                                       options.MinimumSameSitePolicy = SameSiteMode.None
                                                       Return options
                                                   End Function)

        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
    End Sub

    ' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IHostingEnvironment)

        If env.IsDevelopment() Then
            app.UseDeveloperExceptionPage()
        Else
            app.UseExceptionHandler("/Home/Error")
        End If

        app.UseStaticFiles()
        app.UseCookiePolicy()

        app.UseMvc(Function(routes)
                       routes.MapRoute(name:="default", template:="{controller=Home}/{action=Index}/{id?}")
                       Return routes
                   End Function)
    End Sub
End Class
