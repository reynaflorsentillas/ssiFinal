Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ForgotPassword
		Inherits System.Web.UI.Page
		Protected Overridable Property DisplayEmail As PlaceHolder

		Protected Overridable Property Email As TextBox

		Protected Overridable Property ErrorMessage As PlaceHolder

		Protected Overridable Property FailureText As Literal

		Protected Overridable Property loginForm As PlaceHolder

		Protected Property StatusMessage As String

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Forgot(ByVal sender As Object, ByVal e As EventArgs)
			If (MyBase.IsValid) Then
				Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
				Dim applicationUser As ssiFinal.ApplicationUser = userManager.FindByName(Me.Email.Text)
				If (applicationUser Is Nothing OrElse Not userManager.IsEmailConfirmed(applicationUser.Id)) Then
					Me.FailureText.Text = "The user either does not exist or is not confirmed."
					Me.ErrorMessage.Visible = True
					Return
				End If
				Me.loginForm.Visible = False
				Me.DisplayEmail.Visible = True
			End If
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace