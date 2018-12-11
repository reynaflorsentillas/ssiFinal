Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class transactionsClient
		Inherits System.Web.UI.Page

        Private _SearchButton As Button
        Private _GridViewBoxes As GridView
        Private _RefreshButton As Button
        Private _GridViewTransactions As GridView
        Protected Overridable Property DetailsViewTransations As DetailsView

        Protected Overridable Property GridViewBoxes As GridView
			Get
				Return Me._GridViewBoxes
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridViewBoxes_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewBoxes
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridViewBoxes = value
				gridView = Me._GridViewBoxes
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewTransactions As GridView
			Get
				Return Me._GridViewTransactions
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridViewTransactions_RowDataBound)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.GridViewTransactions_SelectedIndexChanged)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewTransactions
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
					RemoveHandler gridView.SelectedIndexChanged,  eventHandler
				End If
				Me._GridViewTransactions = value
				gridView = Me._GridViewTransactions
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
					AddHandler gridView.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property hdUserEmail As HiddenField

		Protected Overridable Property hdUserFullName As HiddenField

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property RefreshButton As Button
			Get
				Return Me._RefreshButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.RefreshButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._RefreshButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._RefreshButton = value
				button = Me._RefreshButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SearchButton As Button
			Get
				Return Me._SearchButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.SearchButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._SearchButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._SearchButton = value
				button = Me._SearchButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SearchDropDownList As DropDownList

		Protected Overridable Property SearchTextbox As TextBox

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceAlertUpdate As SqlDataSource

		Protected Overridable Property SqlDataSourceBoxesDestruction As SqlDataSource

		Protected Overridable Property SqlDataSourceBoxesPickUp As SqlDataSource

		Protected Overridable Property SqlDataSourceBoxesRepickup As SqlDataSource

		Protected Overridable Property SqlDataSourceBoxesRetrieval As SqlDataSource

		Protected Overridable Property SqlDataSourceDetails As SqlDataSource

		Protected Overridable Property SqlDataSourceGetClientInfo As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceReadTransactions As SqlDataSource

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Public Sub Alerts()
			Dim num As Integer = 0
			Me.Session("clientUserName") = MyBase.User.Identity.GetUserName()
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceAlerts.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			While sqlDataReader.Read()
				Dim notifications As System.Web.UI.HtmlControls.HtmlGenericControl = Me.Notifications
				Dim htmlGenericControl As System.Web.UI.HtmlControls.HtmlGenericControl = notifications
				notifications.InnerHtml = String.Concat(New String() { htmlGenericControl.InnerHtml, "<li><a class='none' href='transactionsClient?Id=", sqlDataReader("Id").ToString(), "'>Transaction ID: ", sqlDataReader("Id").ToString(), "<br />transactions has been processed in ", sqlDataReader("Type").ToString(), "</a></li>" })
				num = num + 1
			End While
			Try
				Try
					If (num = 0) Then
						Me.Notifications.Visible = False
					Else
						Me.TotalCount.InnerHtml = num.ToString()
					End If
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			Finally
				sqlDataReader.Close()
			End Try
		End Sub

		Private Sub GridViewBoxes_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					e.Row.Cells(1).Text = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
					e.Row.Cells(2).Text = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
					e.Row.Cells(3).Text = HttpUtility.HtmlDecode(e.Row.Cells(3).Text)
					e.Row.Cells(4).Text = HttpUtility.HtmlDecode(e.Row.Cells(4).Text)
					e.Row.Cells(5).Text = HttpUtility.HtmlDecode(e.Row.Cells(5).Text)
					e.Row.Cells(6).Text = HttpUtility.HtmlDecode(e.Row.Cells(6).Text)
					e.Row.Cells(7).Text = HttpUtility.HtmlDecode(e.Row.Cells(7).Text)
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub GridViewTransactions_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					e.Row.Cells(1).Text = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
					e.Row.Cells(2).Text = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
					e.Row.Cells(3).Text = HttpUtility.HtmlDecode(e.Row.Cells(3).Text)
					e.Row.Cells(4).Text = HttpUtility.HtmlDecode(e.Row.Cells(4).Text)
					e.Row.Cells(5).Text = HttpUtility.HtmlDecode(e.Row.Cells(5).Text)
					e.Row.Cells(6).Text = HttpUtility.HtmlDecode(e.Row.Cells(6).Text)
					e.Row.Cells(7).Text = HttpUtility.HtmlDecode(e.Row.Cells(7).Text)
					e.Row.Cells(8).Text = HttpUtility.HtmlDecode(e.Row.Cells(8).Text)
					e.Row.Cells(9).Text = HttpUtility.HtmlDecode(e.Row.Cells(9).Text)
					e.Row.Cells(10).Text = HttpUtility.HtmlDecode(e.Row.Cells(10).Text)
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub GridViewTransactions_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.Session("DetailType") = Me.GridViewTransactions.SelectedRow.Cells(10).Text
				If (Operators.ConditionalCompareObjectEqual(Me.Session("DetailType"), "PICKUP", False)) Then
					Me.GridViewBoxes.DataSourceID = Me.SqlDataSourceBoxesPickUp.ID
					Me.GridViewTransactions.DataBind()
				ElseIf (Operators.ConditionalCompareObjectEqual(Me.Session("DetailType"), "RETRIEVAL", False)) Then
					Me.GridViewBoxes.DataSourceID = Me.SqlDataSourceBoxesRetrieval.ID
					Me.GridViewTransactions.DataBind()
				ElseIf (Operators.ConditionalCompareObjectEqual(Me.Session("DetailType"), "DESTRUCTION", False)) Then
					Me.GridViewBoxes.DataSourceID = Me.SqlDataSourceBoxesDestruction.ID
					Me.GridViewTransactions.DataBind()
				ElseIf (Operators.ConditionalCompareObjectEqual(Me.Session("DetailType"), "REPICKUP", False)) Then
					Me.GridViewBoxes.DataSourceID = Me.SqlDataSourceBoxesRepickup.ID
					Me.GridViewTransactions.DataBind()
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Sub messages()
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceMessages.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Me.messagesNotif.InnerHtml = ""
			Dim num As Integer = 0
			Try
				Try
					While sqlDataReader.Read()
						Dim str As System.Web.UI.HtmlControls.HtmlGenericControl = Me.messagesNotif
						Dim htmlGenericControl As System.Web.UI.HtmlControls.HtmlGenericControl = str
						str.InnerHtml = Conversions.ToString(Operators.AddObject(htmlGenericControl.InnerHtml, Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(String.Concat("<li><a class='none' href='ClientMessage.aspx?InboxID=", sqlDataReader("ConvoId").ToString(), "'>You have a new message from "), sqlDataReader("Sender")), "<br /><strong>"), sqlDataReader("DateCreated")), "</strong></a></li>")))
						num = num + 1
					End While
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			Finally
				sqlDataReader.Close()
			End Try
			If (num = 0) Then
				Me.TotalMessages.InnerHtml = ""
				Return
			End If
			Me.TotalMessages.InnerHtml = num.ToString()
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("LoggedUser") = MyBase.User.Identity.Name
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSource1.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			If (sqlDataReader.Read()) Then
				Me.hdUserFullName.Value = Conversions.ToString(Operators.AddObject(Operators.AddObject(sqlDataReader("FirstName"), " "), sqlDataReader("LastName")))
				Me.hdUserEmail.Value = Conversions.ToString(sqlDataReader("email"))
			End If
			Try
				Me.Alerts()
				Me.messages()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			If (Not Information.IsNothing(MyBase.Request("Id"))) Then
				Me.SqlDataSourceReadTransactions.FilterExpression = String.Concat("Id =", MyBase.Request("Id"))
				Me.GridViewTransactions.SelectedIndex = 0
				Me.Session("transRequestedId") = MyBase.Request("Id")
				Me.SqlDataSourceAlertUpdate.Update()
			End If
			Try
				Me.Session("clientUserName") = MyBase.User.Identity.GetUserName()
				Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetClientInfo.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				sqlDataReader1.Read()
				Me.Session("CompanyCode") = RuntimeHelpers.GetObjectValue(sqlDataReader1("CompanyCode"))
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.GridViewTransactions.DataBind()
				Me.SearchTextbox.Text = ""
				Me.SearchDropDownList.SelectedIndex = 0
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.SearchDropDownList.SelectedIndex = 0) Then
					Me.SqlDataSourceReadTransactions.FilterExpression = String.Concat("DepartmentCode LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 1) Then
					Me.SqlDataSourceReadTransactions.FilterExpression = String.Concat("ContactName LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 2) Then
					Me.SqlDataSourceReadTransactions.FilterExpression = String.Concat("username LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 3) Then
					Me.SqlDataSourceReadTransactions.FilterExpression = String.Concat("Type LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 4) Then
					Me.SqlDataSourceReadTransactions.FilterExpression = String.Concat("Status LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				End If
				Me.SqlDataSourceReadTransactions.[Select](DataSourceSelectArguments.Empty)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub
	End Class
End Namespace