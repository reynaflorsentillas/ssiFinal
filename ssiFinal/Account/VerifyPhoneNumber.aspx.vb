Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Collections.Specialized
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.ModelBinding
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class VerifyPhoneNumber
		Inherits System.Web.UI.Page
		Protected Overridable Property Code As TextBox

		Protected Overridable Property ErrorMessage As Literal

		Protected Overridable Property PhoneNumber As HiddenField

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Code_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Not MyBase.ModelState.IsValid) Then
				MyBase.ModelState.AddModelError("", "Invalid code")
				Return
			End If
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Dim applicationSignInManager As ssiFinal.ApplicationSignInManager = Me.Context.GetOwinContext().[Get](Of ssiFinal.ApplicationSignInManager)()
			If (userManager.ChangePhoneNumber(MyBase.User.Identity.GetUserId(), Me.PhoneNumber.Value, Me.Code.Text).Succeeded) Then
				Dim applicationUser As ssiFinal.ApplicationUser = userManager.FindById(MyBase.User.Identity.GetUserId())
				If (applicationUser IsNot Nothing) Then
					applicationSignInManager.SignIn(applicationUser, False, False)
					MyBase.Response.Redirect("/Account/Manage?m=AddPhoneNumberSuccess")
				End If
			End If
			MyBase.ModelState.AddModelError("", "Failed to verify phone")
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Dim item As String = MyBase.Request.QueryString("PhoneNumber")
			userManager.GenerateChangePhoneNumberToken(MyBase.User.Identity.GetUserId(), item)
			Me.PhoneNumber.Value = item
		End Sub
	End Class
End Namespace