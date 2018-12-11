Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Login
		Inherits System.Web.UI.Page
		Protected Overridable Property Email As TextBox

		Protected Overridable Property ErrorMessage As PlaceHolder

		Protected Overridable Property FailureText As Literal

		Protected Overridable Property OpenAuthLogin As OpenAuthProviders

		Protected Overridable Property Password As TextBox

		Protected Overridable Property RegisterHyperLink As HyperLink

		Protected Overridable Property RememberMe As CheckBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub LogIn(ByVal sender As Object, ByVal e As EventArgs)
			If (MyBase.IsValid) Then
				Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
				Select Case Me.Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)().PasswordSignIn(Me.Email.Text, Me.Password.Text, Me.RememberMe.Checked, False)
					Case SignInStatus.Success
						IdentityHelper.RedirectToReturnUrl(MyBase.Request.QueryString("ReturnUrl"), MyBase.Response)
						Return
					Case SignInStatus.LockedOut
						MyBase.Response.Redirect("/Account/Lockout")
						Return
					Case SignInStatus.RequiresVerification
						MyBase.Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", MyBase.Request.QueryString("ReturnUrl"), Me.RememberMe.Checked), True)
						Return
					Case Else
						Me.FailureText.Text = "Invalid login attempt"
						Me.ErrorMessage.Visible = True
						Exit Select
				End Select
			End If
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Me.RegisterHyperLink.NavigateUrl = "Register"
			Me.OpenAuthLogin.ReturnUrl = MyBase.Request.QueryString("ReturnUrl")
			Dim str As String = HttpUtility.UrlEncode(MyBase.Request.QueryString("ReturnUrl"))
			If (Not String.IsNullOrEmpty(str)) Then
				Dim registerHyperLink As System.Web.UI.WebControls.HyperLink = Me.RegisterHyperLink
				Dim hyperLink As System.Web.UI.WebControls.HyperLink = registerHyperLink
				registerHyperLink.NavigateUrl = String.Concat(hyperLink.NavigateUrl, "?ReturnUrl=", str)
			End If
		End Sub
	End Class
End Namespace