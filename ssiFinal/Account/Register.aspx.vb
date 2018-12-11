Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Collections.Specialized
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Register
		Inherits System.Web.UI.Page
		Protected Overridable Property ConfirmPassword As TextBox

		Protected Overridable Property Email As TextBox

		Protected Overridable Property ErrorMessage As Literal

		Protected Overridable Property Password As TextBox

		Public Sub New()
			MyBase.New()
		End Sub

		Protected Sub CreateUser_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim text As String = Me.Email.Text
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Dim applicationSignInManager As ssiFinal.ApplicationSignInManager = Me.Context.GetOwinContext().[Get](Of ssiFinal.ApplicationSignInManager)()
			Dim applicationUser As ssiFinal.ApplicationUser = New ssiFinal.ApplicationUser() With
			{
				.UserName = text,
				.Email = text
			}
			Dim identityResult As Microsoft.AspNet.Identity.IdentityResult = userManager.Create(applicationUser, Me.Password.Text)
			If (Not identityResult.Succeeded) Then
				Me.ErrorMessage.Text = identityResult.Errors.FirstOrDefault()
				Return
			End If
			applicationSignInManager.SignIn(applicationUser, False, False)
			IdentityHelper.RedirectToReturnUrl(MyBase.Request.QueryString("ReturnUrl"), MyBase.Response)
		End Sub
	End Class
End Namespace