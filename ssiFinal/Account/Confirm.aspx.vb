Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Confirm
		Inherits System.Web.UI.Page
		Protected Overridable Property errorPanel As PlaceHolder

		Protected Overridable Property login As HyperLink

		Protected Property StatusMessage As String

		Protected Overridable Property successPanel As PlaceHolder

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim codeFromRequest As String = IdentityHelper.GetCodeFromRequest(MyBase.Request)
			Dim userIdFromRequest As String = IdentityHelper.GetUserIdFromRequest(MyBase.Request)
			If (codeFromRequest IsNot Nothing AndAlso userIdFromRequest IsNot Nothing AndAlso Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)().ConfirmEmail(userIdFromRequest, codeFromRequest).Succeeded) Then
				Me.successPanel.Visible = True
				Return
			End If
			Me.successPanel.Visible = False
			Me.errorPanel.Visible = True
		End Sub
	End Class
End Namespace