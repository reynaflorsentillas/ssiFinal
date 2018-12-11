Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class redirectUser
		Inherits System.Web.UI.Page
		Protected Overridable Property form1 As HtmlForm

		Protected Overridable Property SqlDataSourceGetClientInfo As SqlDataSource

		Protected Overridable Property SqlDataSourceGetCompany As SqlDataSource

		Protected Overridable Property SqlDataSourceGetDepartments As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLogin As SqlDataSource

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not (MyBase.User.IsInRole("ssiClient") Or MyBase.User.IsInRole("clientSupervisor"))) Then
				If (MyBase.User.IsInRole("ssiAdmin") Or MyBase.User.IsInRole("ssiEmployee")) Then
					MyBase.Response.Redirect("~/devadmin/Dashboard.aspx", False)
				End If
				Return
			End If
			Try
				Me.SqlDataSourceUserLogin.InsertParameters("User").DefaultValue = MyBase.User.Identity.Name
				Dim item As Parameter = Me.SqlDataSourceUserLogin.InsertParameters("DateLogin")
				Dim utcNow As DateTime = DateTime.UtcNow
				item.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
				Me.SqlDataSourceUserLogin.Insert()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			MyBase.Response.Redirect("~/devclient/Dashboard.aspx", False)
		End Sub
	End Class
End Namespace