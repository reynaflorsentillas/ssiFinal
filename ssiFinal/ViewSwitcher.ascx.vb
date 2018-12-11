Imports Microsoft.AspNet.FriendlyUrls.Resolvers
Imports System
Imports System.Web
Imports System.Web.UI

Namespace ssiFinal
	Public Class ViewSwitcher
		Inherits UserControl
		Private m_CurrentView As String

		Private m_AlternateView As String

		Private m_SwitchUrl As String

		Protected Property AlternateView As String
			Get
				Return Me.m_AlternateView
			End Get
			Private Set(ByVal value As String)
				Me.m_AlternateView = value
			End Set
		End Property

		Protected Property CurrentView As String
			Get
				Return Me.m_CurrentView
			End Get
			Private Set(ByVal value As String)
				Me.m_CurrentView = value
			End Set
		End Property

		Protected Property SwitchUrl As String
			Get
				Return Me.m_SwitchUrl
			End Get
			Private Set(ByVal value As String)
				Me.m_SwitchUrl = value
			End Set
		End Property

		Public Sub New()
			MyBase.New()
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim flag As Boolean = WebFormsFriendlyUrlResolver.IsMobileView(New HttpContextWrapper(Me.Context))
			Me.CurrentView = If(flag, "Mobile", "Desktop")
			Me.AlternateView = If(flag, "Desktop", "Mobile")
			Dim routeUrl As String = MyBase.GetRouteUrl("AspNet.FriendlyUrls.SwitchView", New With { Key .view = Me.AlternateView })
			routeUrl = String.Concat(routeUrl, "?ReturnUrl=", HttpUtility.UrlEncode(MyBase.Request.RawUrl))
			Me.SwitchUrl = routeUrl
		End Sub
	End Class
End Namespace