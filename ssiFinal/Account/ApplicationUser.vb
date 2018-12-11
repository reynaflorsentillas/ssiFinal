Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System
Imports System.Security.Claims
Imports System.Threading.Tasks

Namespace ssiFinal
	Public Class ApplicationUser
		Inherits IdentityUser
		Public Sub New()
			MyBase.New()
		End Sub

		Public Function GenerateUserIdentity(ByVal manager As ApplicationUserManager) As ClaimsIdentity
			Return manager.CreateIdentity(Me, "ApplicationCookie")
		End Function

		Public Function GenerateUserIdentityAsync(ByVal manager As ApplicationUserManager) As Task(Of ClaimsIdentity)
			Return Task.FromResult(Of ClaimsIdentity)(Me.GenerateUserIdentity(manager))
		End Function
	End Class
End Namespace