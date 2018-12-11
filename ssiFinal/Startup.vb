Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Owin
Imports System
Imports System.Runtime.CompilerServices
Imports System.Security.Claims
Imports System.Threading.Tasks

<Assembly: OwinStartup(GetType(ssiFinal.Startup))>

Namespace ssiFinal
    Public Class Startup
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub Configuration(ByVal app As IAppBuilder)
            Me.ConfigureAuth(app)
            app.MapSignalR()
        End Sub

        Public Sub ConfigureAuth(ByVal app As IAppBuilder)
            Dim func As Func(Of ApplicationUserManager, ApplicationUser, Task(Of ClaimsIdentity))
            app.CreatePerOwinContext(Of ApplicationDbContext)(New Func(Of ApplicationDbContext)(AddressOf ApplicationDbContext.Create))
            app.CreatePerOwinContext(Of ApplicationUserManager)(New Func(Of IdentityFactoryOptions(Of ApplicationUserManager), IOwinContext, ApplicationUserManager)(AddressOf ApplicationUserManager.Create))
            app.CreatePerOwinContext(Of ApplicationSignInManager)(New Func(Of IdentityFactoryOptions(Of ApplicationSignInManager), IOwinContext, ApplicationSignInManager)(AddressOf ApplicationSignInManager.Create))
            Dim appBuilder As IAppBuilder = app
            Dim cookieAuthenticationOption As CookieAuthenticationOptions = New CookieAuthenticationOptions() With
            {
                .AuthenticationType = "ApplicationCookie"
            }
            Dim cookieAuthenticationProvider As Microsoft.Owin.Security.Cookies.CookieAuthenticationProvider = New Microsoft.Owin.Security.Cookies.CookieAuthenticationProvider()
            Dim timeSpan As System.TimeSpan = System.TimeSpan.FromMinutes(30)
            'If (Startup._Closure$__.$I1-0 Is Nothing) Then
            '    func = Function(manager As ApplicationUserManager, user As ApplicationUser) user.GenerateUserIdentityAsync(manager)
            '    Startup._Closure$__.$I1-0 = func
            'Else
            '    func = Startup._Closure$__.$I1-0
            'End If
            func = Function(manager As ApplicationUserManager, user As ApplicationUser) user.GenerateUserIdentityAsync(manager)
            cookieAuthenticationProvider.OnValidateIdentity = SecurityStampValidator.OnValidateIdentity(Of ApplicationUserManager, ApplicationUser)(timeSpan, func)
            cookieAuthenticationOption.Provider = cookieAuthenticationProvider
            cookieAuthenticationOption.LoginPath = New PathString("/Login.aspx")
            appBuilder.UseCookieAuthentication(cookieAuthenticationOption)
            app.UseExternalSignInCookie("ExternalCookie")
            app.UseTwoFactorSignInCookie("TwoFactorCookie", System.TimeSpan.FromMinutes(5))
            app.UseTwoFactorRememberBrowserCookie("TwoFactorRememberBrowser")
        End Sub
    End Class
End Namespace