Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ManageLogins
		Inherits System.Web.UI.Page
		Private m_SuccessMessage As String

		Private m_CanRemoveExternalLogins As Boolean

		Protected Property CanRemoveExternalLogins As Boolean
			Get
				Return Me.m_CanRemoveExternalLogins
			End Get
			Private Set(ByVal value As Boolean)
				Me.m_CanRemoveExternalLogins = value
			End Set
		End Property

		Protected Property SuccessMessage As String
			Get
				Return Me.m_SuccessMessage
			End Get
			Private Set(ByVal value As String)
				Me.m_SuccessMessage = value
			End Set
		End Property

		Protected Overridable Property SuccessMessagePlaceholder As PlaceHolder

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Public Function GetLogins() As IEnumerable(Of UserLoginInfo)
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Dim logins As IList(Of UserLoginInfo) = userManager.GetLogins(MyBase.User.Identity.GetUserId())
			Me.CanRemoveExternalLogins = If(logins.Count > 1, True, Me.HasPassword(userManager))
			Return logins
		End Function

		Private Function HasPassword(ByVal manager As ApplicationUserManager) As Boolean
			Return manager.HasPassword(MyBase.User.Identity.GetUserId())
		End Function

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Me.CanRemoveExternalLogins = userManager.GetLogins(MyBase.User.Identity.GetUserId()).Count > 1
			Me.SuccessMessage = String.Empty
			Me.SuccessMessagePlaceholder.Visible = Not String.IsNullOrEmpty(Me.SuccessMessage)
		End Sub

		Public Sub RemoveLogin(ByVal loginProvider As String, ByVal providerKey As String)
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Dim applicationSignInManager As ssiFinal.ApplicationSignInManager = Me.Context.GetOwinContext().[Get](Of ssiFinal.ApplicationSignInManager)()
			Dim identityResult As Microsoft.AspNet.Identity.IdentityResult = userManager.RemoveLogin(MyBase.User.Identity.GetUserId(), New UserLoginInfo(loginProvider, providerKey))
			Dim empty As String = String.Empty
			If (identityResult.Succeeded) Then
				Dim applicationUser As ssiFinal.ApplicationUser = userManager.FindById(MyBase.User.Identity.GetUserId())
				applicationSignInManager.SignIn(applicationUser, False, False)
				empty = "?m=RemoveLoginSuccess"
			End If
			MyBase.Response.Redirect(String.Concat("~/Account/ManageLogins", empty))
		End Sub
	End Class
End Namespace