Imports Microsoft.AspNet.FriendlyUrls
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Web.Routing

Namespace ssiFinal
	Public Module RouteConfig
		Public Sub RegisterRoutes(ByVal routes As RouteCollection)
			routes.EnableFriendlyUrls(New FriendlyUrlSettings() With
			{
				.AutoRedirectMode = RedirectMode.Permanent
			})
		End Sub
	End Module
End Namespace