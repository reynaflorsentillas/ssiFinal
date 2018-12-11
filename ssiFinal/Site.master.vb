Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class SiteMaster
		Inherits ssiFinal.MasterPage
		Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"

		Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"

		Private _antiXsrfTokenValue As String

		Protected Overridable Property MainContent As ContentPlaceHolder

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub master_Page_PreLoad(ByVal sender As Object, ByVal e As EventArgs)
			If (Not MyBase.IsPostBack) Then
				Me.ViewState("__AntiXsrfToken") = Me.Page.ViewStateUserKey
				Me.ViewState("__AntiXsrfUserName") = If(Me.Context.User.Identity.Name, String.Empty)
				Return
			End If
			If (Operators.CompareString(CStr(Me.ViewState("__AntiXsrfToken")), Me._antiXsrfTokenValue, False) = 0) Then
				If (Operators.CompareString(CStr(Me.ViewState("__AntiXsrfUserName")), If(Me.Context.User.Identity.Name, String.Empty), False) = 0) Then
					Return
				End If
			End If
			Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
		End Sub

		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			Dim guid As System.Guid
			Dim item As System.Web.HttpCookie = MyBase.Request.Cookies("__AntiXsrfToken")
			If (item Is Nothing OrElse Not System.Guid.TryParse(item.Value, guid)) Then
				Me._antiXsrfTokenValue = System.Guid.NewGuid().ToString("N")
				Me.Page.ViewStateUserKey = Me._antiXsrfTokenValue
				Dim httpCookie As System.Web.HttpCookie = New System.Web.HttpCookie("__AntiXsrfToken") With
				{
					.HttpOnly = True,
					.Value = Me._antiXsrfTokenValue
				}
				If (FormsAuthentication.RequireSSL AndAlso MyBase.Request.IsSecureConnection) Then
					httpCookie.Secure = True
				End If
				MyBase.Response.Cookies.[Set](httpCookie)
			Else
				Me._antiXsrfTokenValue = item.Value
				Me.Page.ViewStateUserKey = Me._antiXsrfTokenValue
			End If
			AddHandler Me.Page.PreLoad,  New EventHandler(AddressOf Me.master_Page_PreLoad)
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Protected Shadows Sub Unnamed_LoggingOut(ByVal sender As Object, ByVal e As LoginCancelEventArgs)
			Me.Context.GetOwinContext().Authentication.SignOut(New String(-1) {})
		End Sub
	End Class
End Namespace