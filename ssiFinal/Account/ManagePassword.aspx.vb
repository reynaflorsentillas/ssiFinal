Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.ModelBinding
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ManagePassword
		Inherits System.Web.UI.Page
		Private m_SuccessMessage As String

		Protected Overridable Property changePasswordHolder As PlaceHolder

		Protected Overridable Property ConfirmNewPassword As TextBox

		Protected Overridable Property ConfirmNewPasswordLabel As Label

		Protected Overridable Property confirmPassword As TextBox

		Protected Overridable Property CurrentPassword As TextBox

		Protected Overridable Property CurrentPasswordLabel As Label

		Protected Overridable Property NewPassword As TextBox

		Protected Overridable Property NewPasswordLabel As Label

		Protected Overridable Property password As TextBox

		Protected Overridable Property setPassword As PlaceHolder

		Protected Property SuccessMessage As String
			Get
				Return Me.m_SuccessMessage
			End Get
			Private Set(ByVal value As String)
				Me.m_SuccessMessage = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
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

		Protected Sub ChangePassword_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (MyBase.IsValid) Then
				Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
				Dim applicationSignInManager As ssiFinal.ApplicationSignInManager = Me.Context.GetOwinContext().[Get](Of ssiFinal.ApplicationSignInManager)()
				Dim identityResult As Microsoft.AspNet.Identity.IdentityResult = userManager.ChangePassword(MyBase.User.Identity.GetUserId(), Me.CurrentPassword.Text, Me.NewPassword.Text)
				If (identityResult.Succeeded) Then
					Dim applicationUser As ssiFinal.ApplicationUser = userManager.FindById(MyBase.User.Identity.GetUserId())
					applicationSignInManager.SignIn(applicationUser, False, False)
					MyBase.Response.Redirect("~/Account/Manage?m=ChangePwdSuccess")
					Return
				End If
				Me.AddErrors(identityResult)
			End If
		End Sub

		Private Function HasPassword(ByVal manager As ApplicationUserManager) As Boolean
			Return manager.HasPassword(MyBase.User.Identity.GetUserId())
		End Function

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			If (Not MyBase.IsPostBack) Then
				If (Not Me.HasPassword(userManager)) Then
					Me.setPassword.Visible = True
					Me.changePasswordHolder.Visible = False
				Else
					Me.changePasswordHolder.Visible = True
				End If
				If (MyBase.Request.QueryString("m") IsNot Nothing) Then
					MyBase.Form.Action = MyBase.ResolveUrl("~/Account/Manage")
				End If
			End If
		End Sub

		Protected Sub SetPassword_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (MyBase.IsValid) Then
				Dim identityResult As Microsoft.AspNet.Identity.IdentityResult = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)().AddPassword(MyBase.User.Identity.GetUserId(), Me.password.Text)
				If (identityResult.Succeeded) Then
					MyBase.Response.Redirect("~/Account/Manage?m=SetPwdSuccess")
					Return
				End If
				Me.AddErrors(identityResult)
			End If
		End Sub
	End Class
End Namespace