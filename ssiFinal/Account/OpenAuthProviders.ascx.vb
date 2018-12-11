Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin
Imports Microsoft.Owin.Security
Imports System
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Globalization
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class OpenAuthProviders
		Inherits UserControl
		Private m_ReturnUrl As String

		Protected Overridable Property providerDetails As ListView

		Public Property ReturnUrl As String
			Get
				Return Me.m_ReturnUrl
			End Get
			Set(ByVal value As String)
				Me.m_ReturnUrl = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Public Function GetProviderNames() As IEnumerable(Of String)
			Dim authenticationType As Func(Of AuthenticationDescription, String)
			Dim externalAuthenticationTypes As IEnumerable(Of AuthenticationDescription) = Me.Context.GetOwinContext().Authentication.GetExternalAuthenticationTypes()
            'If (OpenAuthProviders._Closure$__.$I10-0 Is Nothing) Then
            '    authenticationType = Function(t As AuthenticationDescription) t.AuthenticationType
            '    OpenAuthProviders._Closure$__.$I10-0 = authenticationType
            'Else
            '    authenticationType = OpenAuthProviders._Closure$__.$I10-0
            'End If
            authenticationType = Function(t As AuthenticationDescription) t.AuthenticationType
            Return externalAuthenticationTypes.[Select](Of String)(authenticationType)
		End Function

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (MyBase.IsPostBack) Then
				Dim item As String = MyBase.Request.Form("provider")
				If (item IsNot Nothing) Then
					Dim str As String = MyBase.ResolveUrl(String.Format(CultureInfo.InvariantCulture, "~/Account/RegisterExternalLogin?{0}={1}&returnUrl={2}", New Object() { "providerName", item, Me.ReturnUrl }))
					Dim authenticationProperty As AuthenticationProperties = New AuthenticationProperties() With
					{
						.RedirectUri = str
					}
					If (Me.Context.User.Identity.IsAuthenticated) Then
						authenticationProperty.Dictionary("xsrfKey") = Me.Context.User.Identity.GetUserId()
					End If
					Me.Context.GetOwinContext().Authentication.Challenge(authenticationProperty, New String() { item })
					MyBase.Response.StatusCode = 401
					MyBase.Response.[End]()
				End If
			End If
		End Sub
	End Class
End Namespace