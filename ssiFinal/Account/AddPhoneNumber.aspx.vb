Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class AddPhoneNumber
		Inherits System.Web.UI.Page
		Protected Overridable Property ErrorMessage As Literal

		Protected Overridable Property PhoneNumber As TextBox

		Public Sub New()
			MyBase.New()
		End Sub

		Protected Sub PhoneNumber_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
			Dim str As String = userManager.GenerateChangePhoneNumberToken(MyBase.User.Identity.GetUserId(), Me.PhoneNumber.Text)
			If (userManager.SmsService IsNot Nothing) Then
				Dim identityMessage As Microsoft.AspNet.Identity.IdentityMessage = New Microsoft.AspNet.Identity.IdentityMessage() With
				{
					.Destination = Me.PhoneNumber.Text,
					.Body = String.Concat("Your security code is ", Convert.ToString(str))
				}
				userManager.SmsService.Send(identityMessage)
			End If
			MyBase.Response.Redirect(String.Concat("/Account/VerifyPhoneNumber?PhoneNumber=", HttpUtility.UrlEncode(Me.PhoneNumber.Text)))
		End Sub
	End Class
End Namespace