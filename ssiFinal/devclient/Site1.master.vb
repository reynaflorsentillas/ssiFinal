Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports System
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Site1
		Inherits System.Web.UI.MasterPage
		Protected Overridable Property AlertsPlaceHolder As ContentPlaceHolder

		Protected Overridable Property clientSupervisor As HtmlGenericControl

		Protected Overridable Property ContentPlaceHolder1 As ContentPlaceHolder

		Protected Overridable Property head As ContentPlaceHolder

		Protected Overridable Property HiddenField1 As HiddenField

		Protected Overridable Property MessagesPlaceHolder As ContentPlaceHolder

		Protected Overridable Property ScriptManager1 As ScriptManager

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Me.Page.User.IsInRole("clientSupervisor")) Then
				Me.clientSupervisor.Style.Add("display", "none")
			End If
		End Sub

		Protected Sub Unnamed_LoggingOut(ByVal sender As Object, ByVal e As LoginCancelEventArgs)
			Me.Context.GetOwinContext().Authentication.SignOut(New String(-1) {})
			MyBase.Session.Clear()
		End Sub
	End Class
End Namespace