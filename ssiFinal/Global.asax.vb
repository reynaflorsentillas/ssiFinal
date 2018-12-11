Imports System
Imports System.Globalization
Imports System.Threading
Imports System.Web
Imports System.Web.Optimization
Imports System.Web.Routing
Imports System.Web.SessionState

Namespace ssiFinal
    Public Class Global_asax
        Inherits System.Web.HttpApplication
        Public Sub New()
            MyBase.New()
        End Sub

        Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when the application is started
            RouteConfig.RegisterRoutes(RouteTable.Routes)
            BundleConfig.RegisterBundles(BundleTable.Bundles)
            Dim cultureInfo As System.Globalization.CultureInfo = DirectCast(Thread.CurrentThread.CurrentCulture.Clone(), System.Globalization.CultureInfo)
            cultureInfo.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            cultureInfo.DateTimeFormat.DateSeparator = "-"
            Thread.CurrentThread.CurrentCulture = cultureInfo
        End Sub

        Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when the session is started
        End Sub

        Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires at the beginning of each request
        End Sub

        Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires upon attempting to authenticate the use
        End Sub

        Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when an error occurs
        End Sub

        Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when the session ends
        End Sub

        Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when the application ends
        End Sub

    End Class
End Namespace