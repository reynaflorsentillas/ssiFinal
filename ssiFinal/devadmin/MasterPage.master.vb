Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports System
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class MasterPage
		Inherits System.Web.UI.MasterPage
		Protected Overridable Property addClientAdmin As HtmlGenericControl

		Protected Overridable Property AlertsPlaceHolder As ContentPlaceHolder

		Protected Overridable Property changePasswordAdmin As HtmlGenericControl

		Protected Overridable Property Chat As HtmlGenericControl

		Protected Overridable Property ContentPlaceHolder1 As ContentPlaceHolder

		Protected Overridable Property FaqsAdmin As HtmlGenericControl

		Protected Overridable Property head As ContentPlaceHolder

		Protected Overridable Property historyAdmin As HtmlGenericControl

		Protected Overridable Property LocationSettings As HtmlGenericControl

		Protected Overridable Property masterlistHistory As HtmlGenericControl

		Protected Overridable Property MessagesPlaceHolder As ContentPlaceHolder

		Protected Overridable Property messagingAdmin As HtmlGenericControl

		Protected Overridable Property reports As HtmlGenericControl

		Protected Overridable Property ScriptManager1 As ScriptManager

		Protected Overridable Property userLogins As HtmlGenericControl

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Me.Page.User.IsInRole("ssiAdmin")) Then
				Me.messagingAdmin.Style.Add("display", "none")
				Me.addClientAdmin.Style.Add("display", "none")
				Me.changePasswordAdmin.Style.Add("display", "none")
				Me.historyAdmin.Style.Add("display", "none")
				Me.reports.Style.Add("display", "none")
				Me.FaqsAdmin.Style.Add("display", "none")
				Me.LocationSettings.Style.Add("display", "none")
			End If
		End Sub

		Protected Sub Unnamed_LoggingOut(ByVal sender As Object, ByVal e As LoginCancelEventArgs)
			Me.Context.GetOwinContext().Authentication.SignOut(New String(-1) {})
		End Sub
	End Class
End Namespace