Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ResetPassword
		Inherits System.Web.UI.Page
		Protected Overridable Property ConfirmPassword As TextBox

		Protected Overridable Property Email As TextBox

		Protected Overridable Property ErrorMessage As Literal

		Protected Overridable Property Password As TextBox

		Protected Property StatusMessage As String

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Protected Sub Reset_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim codeFromRequest As String = IdentityHelper.GetCodeFromRequest(MyBase.Request)
			If (codeFromRequest Is Nothing) Then
				Me.ErrorMessage.Text = "An error has occurred"
				Return
			End If
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Dim applicationUser As ssiFinal.ApplicationUser = userManager.FindByName(Me.Email.Text)
			If (applicationUser Is Nothing) Then
				Me.ErrorMessage.Text = "No user found"
				Return
			End If
			Dim identityResult As Microsoft.AspNet.Identity.IdentityResult = userManager.ResetPassword(applicationUser.Id, codeFromRequest, Me.Password.Text)
			If (identityResult.Succeeded) Then
				MyBase.Response.Redirect("~/Account/ResetPasswordConfirmation")
				Return
			End If
			Me.ErrorMessage.Text = identityResult.Errors.FirstOrDefault()
		End Sub
	End Class
End Namespace