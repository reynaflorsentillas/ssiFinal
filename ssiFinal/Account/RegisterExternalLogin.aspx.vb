Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.ModelBinding
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class RegisterExternalLogin
		Inherits System.Web.UI.Page
		Protected Overridable Property email As TextBox

		Protected Property ProviderAccountKey As String
			Get
				Return If(CStr(Me.ViewState("ProviderAccountKey")), String.Empty)
			End Get
			Private Set(ByVal value As String)
				Me.ViewState("ProviderAccountKey") = value
			End Set
		End Property

		Protected Property ProviderName As String
			Get
				Return If(CStr(Me.ViewState("ProviderName")), String.Empty)
			End Get
			Private Set(ByVal value As String)
				Me.ViewState("ProviderName") = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(Sub(a0 As Object, a1 As EventArgs) Me.Page_Load())
		End Sub

		Private Sub AddErrors(ByVal result As IdentityResult)
			Dim enumerator As IEnumerator(Of String) = Nothing
			Try
				enumerator = result.Errors.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As String = enumerator.Current
					MyBase.ModelState.AddModelError("", current)
				End While
			Finally
				If (enumerator IsNot Nothing) Then
					enumerator.Dispose()
				End If
			End Try
		End Sub

		Private Sub CreateAndLoginUser()
			If (MyBase.IsValid) Then
				Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
				Dim applicationSignInManager As ssiFinal.ApplicationSignInManager = Me.Context.GetOwinContext().[Get](Of ssiFinal.ApplicationSignInManager)()
				Dim applicationUser As ssiFinal.ApplicationUser = New ssiFinal.ApplicationUser() With
				{
					.UserName = Me.email.Text,
					.Email = Me.email.Text
				}
				Dim identityResult As Microsoft.AspNet.Identity.IdentityResult = userManager.Create(applicationUser)
				If (Not identityResult.Succeeded) Then
					Me.AddErrors(identityResult)
					Return
				End If
				Dim externalLoginInfo As Microsoft.AspNet.Identity.Owin.ExternalLoginInfo = Me.Context.GetOwinContext().Authentication.GetExternalLoginInfo()
				If (externalLoginInfo Is Nothing) Then
					Me.RedirectOnFail()
					Return
				End If
				identityResult = userManager.AddLogin(applicationUser.Id, externalLoginInfo.Login)
				If (Not identityResult.Succeeded) Then
					Me.AddErrors(identityResult)
					Return
				End If
				applicationSignInManager.SignIn(applicationUser, False, False)
				IdentityHelper.RedirectToReturnUrl(MyBase.Request.QueryString("ReturnUrl"), MyBase.Response)
			End If
		End Sub

		Protected Sub LogIn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.CreateAndLoginUser()
		End Sub

		Protected Sub Page_Load()
			Me.ProviderName = IdentityHelper.GetProviderNameFromRequest(MyBase.Request)
			If (String.IsNullOrEmpty(Me.ProviderName)) Then
				Me.RedirectOnFail()
				Return
			End If
			If (Not MyBase.IsPostBack) Then
				Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
				Dim applicationSignInManager As ssiFinal.ApplicationSignInManager = Me.Context.GetOwinContext().[Get](Of ssiFinal.ApplicationSignInManager)()
				Dim externalLoginInfo As Microsoft.AspNet.Identity.Owin.ExternalLoginInfo = Me.Context.GetOwinContext().Authentication.GetExternalLoginInfo()
				If (externalLoginInfo Is Nothing) Then
					Me.RedirectOnFail()
					Return
				End If
				Dim applicationUser As ssiFinal.ApplicationUser = userManager.Find(externalLoginInfo.Login)
				If (applicationUser IsNot Nothing) Then
					applicationSignInManager.SignIn(applicationUser, False, False)
					IdentityHelper.RedirectToReturnUrl(MyBase.Request.QueryString("ReturnUrl"), MyBase.Response)
					Return
				End If
				If (MyBase.User.Identity.IsAuthenticated) Then
					Dim externalLoginInfo1 As Microsoft.AspNet.Identity.Owin.ExternalLoginInfo = Me.Context.GetOwinContext().Authentication.GetExternalLoginInfo("xsrfKey", MyBase.User.Identity.GetUserId())
					If (externalLoginInfo1 Is Nothing) Then
						Me.RedirectOnFail()
						Return
					End If
					Dim identityResult As Microsoft.AspNet.Identity.IdentityResult = userManager.AddLogin(MyBase.User.Identity.GetUserId(), externalLoginInfo1.Login)
					If (Not identityResult.Succeeded) Then
						Me.AddErrors(identityResult)
						Return
					End If
					IdentityHelper.RedirectToReturnUrl(MyBase.Request.QueryString("ReturnUrl"), MyBase.Response)
					Return
				End If
				Me.email.Text = externalLoginInfo.Email
			End If
		End Sub

		Private Sub RedirectOnFail()
			MyBase.Response.Redirect(If(MyBase.User.Identity.IsAuthenticated, "~/Account/Manage", "~/Account/Login"))
		End Sub
	End Class
End Namespace