Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class TwoFactorAuthenticationSignIn
		Inherits System.Web.UI.Page
		Private signinManager As ApplicationSignInManager

		Private manager As ApplicationUserManager

		Protected Overridable Property Code As TextBox

		Protected Overridable Property CodeSubmit As Button

		Protected Overridable Property ErrorMessage As PlaceHolder

		Protected Overridable Property FailureText As Literal

		Protected Overridable Property Providers As DropDownList

		Protected Overridable Property ProviderSubmit As Button

		Protected Overridable Property RememberBrowser As CheckBox

		Protected Overridable Property SelectedProvider As HiddenField

		Protected Overridable Property sendcode As PlaceHolder

		Protected Overridable Property verifycode As PlaceHolder

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me.manager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Me.signinManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)()
		End Sub

		Protected Sub CodeSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim flag As Boolean
			Boolean.TryParse(MyBase.Request.QueryString("RememberMe"), flag)
			Dim signInStatu As SignInStatus = Me.signinManager.TwoFactorSignIn(Me.SelectedProvider.Value, Me.Code.Text, flag, Me.RememberBrowser.Checked)
			If (signInStatu = SignInStatus.Success) Then
				IdentityHelper.RedirectToReturnUrl(MyBase.Request.QueryString("ReturnUrl"), MyBase.Response)
				Return
			End If
			If (signInStatu = SignInStatus.LockedOut) Then
				MyBase.Response.Redirect("/Account/Lockout")
				Return
			End If
			Me.FailureText.Text = "Invalid code"
			Me.ErrorMessage.Visible = True
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim func As Func(Of String, String)
			Dim verifiedUserId As String = Me.signinManager.GetVerifiedUserId()
			If (verifiedUserId Is Nothing) Then
				MyBase.Response.Redirect("/Account/Error", True)
			End If
			Dim validTwoFactorProviders As IList(Of String) = Me.manager.GetValidTwoFactorProviders(verifiedUserId)
			Dim providers As DropDownList = Me.Providers
			Dim strs As IList(Of String) = validTwoFactorProviders
            'If (TwoFactorAuthenticationSignIn._Closure$__.$I43-0 Is Nothing) Then
            '    func = Function(x As String) x
            '    TwoFactorAuthenticationSignIn._Closure$__.$I43-0 = func
            'Else
            '    func = TwoFactorAuthenticationSignIn._Closure$__.$I43-0
            'End If
            func = Function(x As String) x
            providers.DataSource = strs.[Select](Of String)(func).ToList()
			Me.Providers.DataBind()
		End Sub

		Protected Sub ProviderSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Me.signinManager.SendTwoFactorCode(Me.Providers.SelectedValue)) Then
				MyBase.Response.Redirect("/Account/Error")
			End If
			Dim applicationUser As ssiFinal.ApplicationUser = Me.manager.FindById(Me.signinManager.GetVerifiedUserId())
			If (applicationUser IsNot Nothing) Then
				Me.manager.GenerateTwoFactorToken(applicationUser.Id, Me.Providers.SelectedValue)
			End If
			Me.SelectedProvider.Value = Me.Providers.SelectedValue
			Me.sendcode.Visible = False
			Me.verifycode.Visible = True
		End Sub
	End Class
End Namespace