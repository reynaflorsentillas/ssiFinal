Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports Microsoft.VisualBasic.CompilerServices
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
	Public Class Manage
		Inherits System.Web.UI.Page
		Private m_SuccessMessage As String

		Private m_HasPhoneNumber As String

		Private m_TwoFactorEnabled As String

		Private m_TwoFactorBrowserRemembered As String

		Protected Overridable Property ChangePassword As HyperLink

		Protected Overridable Property CreatePassword As HyperLink

		Protected Property HasPhoneNumber As String
			Get
				Return Me.m_HasPhoneNumber
			End Get
			Private Set(ByVal value As String)
				Me.m_HasPhoneNumber = value
			End Set
		End Property

		Public Property LoginsCount As Integer

		Protected Overridable Property PhoneNumber As Label

		Protected Property SuccessMessage As String
			Get
				Return Me.m_SuccessMessage
			End Get
			Private Set(ByVal value As String)
				Me.m_SuccessMessage = value
			End Set
		End Property

		Protected Overridable Property SuccessMessagePlaceHolder As PlaceHolder

		Protected Property TwoFactorBrowserRemembered As String
			Get
				Return Me.m_TwoFactorBrowserRemembered
			End Get
			Private Set(ByVal value As String)
				Me.m_TwoFactorBrowserRemembered = value
			End Set
		End Property

		Protected Property TwoFactorEnabled As String
			Get
				Return Me.m_TwoFactorEnabled
			End Get
			Private Set(ByVal value As String)
				Me.m_TwoFactorEnabled = value
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

		Private Function HasPassword(ByVal manager As ApplicationUserManager) As Boolean
			Dim applicationUser As ssiFinal.ApplicationUser = manager.FindById(MyBase.User.Identity.GetUserId())
			If (applicationUser Is Nothing) Then
				Return False
			End If
			Return applicationUser.PasswordHash IsNot Nothing
		End Function

		Protected Sub Page_Load()
			Dim str As String
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Me.HasPhoneNumber = Conversions.ToString(String.IsNullOrEmpty(userManager.GetPhoneNumber(MyBase.User.Identity.GetUserId())))
			Me.TwoFactorEnabled = Conversions.ToString(userManager.GetTwoFactorEnabled(MyBase.User.Identity.GetUserId()))
			Me.LoginsCount = userManager.GetLogins(MyBase.User.Identity.GetUserId()).Count
			Dim authentication As IAuthenticationManager = HttpContext.Current.GetOwinContext().Authentication
			If (Not MyBase.IsPostBack) Then
				If (Not Me.HasPassword(userManager)) Then
					Me.CreatePassword.Visible = True
					Me.ChangePassword.Visible = False
				Else
					Me.ChangePassword.Visible = True
				End If
				Dim item As String = MyBase.Request.QueryString("m")
				If (item IsNot Nothing) Then
					MyBase.Form.Action = MyBase.ResolveUrl("~/Account/Manage")
					If (Operators.CompareString(item, "ChangePwdSuccess", False) = 0) Then
						str = "Your password has been changed."
					ElseIf (Operators.CompareString(item, "SetPwdSuccess", False) = 0) Then
						str = "Your password has been set."
					ElseIf (Operators.CompareString(item, "RemoveLoginSuccess", False) = 0) Then
						str = "The account was removed."
					ElseIf (Operators.CompareString(item, "AddPhoneNumberSuccess", False) = 0) Then
						str = "Phone number has been added"
					Else
						str = If(Operators.CompareString(item, "RemovePhoneNumberSuccess", False) = 0, "Phone number was removed", String.Empty)
					End If
					Me.SuccessMessage = str
					Me.SuccessMessagePlaceHolder.Visible = Not String.IsNullOrEmpty(Me.SuccessMessage)
				End If
			End If
		End Sub

		Protected Sub RemovePhone_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Dim applicationSignInManager As ssiFinal.ApplicationSignInManager = Me.Context.GetOwinContext().[Get](Of ssiFinal.ApplicationSignInManager)()
			If (userManager.SetPhoneNumber(MyBase.User.Identity.GetUserId(), Nothing).Succeeded) Then
				Dim applicationUser As ssiFinal.ApplicationUser = userManager.FindById(MyBase.User.Identity.GetUserId())
				If (applicationUser IsNot Nothing) Then
					applicationSignInManager.SignIn(applicationUser, False, False)
					MyBase.Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess")
				End If
			End If
		End Sub

		Protected Sub TwoFactorDisable_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)().SetTwoFactorEnabled(MyBase.User.Identity.GetUserId(), False)
			MyBase.Response.Redirect("/Account/Manage")
		End Sub

		Protected Sub TwoFactorEnable_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)().SetTwoFactorEnabled(MyBase.User.Identity.GetUserId(), True)
			MyBase.Response.Redirect("/Account/Manage")
		End Sub
	End Class
End Namespace