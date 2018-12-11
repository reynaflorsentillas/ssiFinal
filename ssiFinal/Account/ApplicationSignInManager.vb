Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports System
Imports System.Security.Claims
Imports System.Threading.Tasks

Namespace ssiFinal
	Public Class ApplicationSignInManager
		Inherits SignInManager(Of ApplicationUser, String)
		Public Sub New(ByVal userManager As ApplicationUserManager, ByVal authenticationManager As IAuthenticationManager)
			MyBase.New(userManager, authenticationManager)
		End Sub

		Public Shared Function Create(ByVal options As IdentityFactoryOptions(Of ApplicationSignInManager), ByVal context As IOwinContext) As ApplicationSignInManager
			Return New ApplicationSignInManager(context.GetUserManager(Of ApplicationUserManager)(), context.Authentication)
		End Function

		Public Overrides Function CreateUserIdentityAsync(ByVal user As ApplicationUser) As Task(Of ClaimsIdentity)
			Return user.GenerateUserIdentityAsync(DirectCast(MyBase.UserManager, ApplicationUserManager))
		End Function
	End Class
End Namespace