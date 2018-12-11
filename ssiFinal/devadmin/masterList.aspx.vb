Imports ClosedXML.Excel
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Text
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class masterList
		Inherits System.Web.UI.Page
		Public locCode As String

		Protected _isEditMode As Boolean
        Private _ExportToExcel As Button
        Private _MasterListGridView As GridView
        Private _AddNewItemToMasterlist As Button
        Private _EditBtn As Button
        Private _RefreshButton As Button
        Private _SearchButton As Button
        Private _SaveBtn As Button

        Protected Overridable Property AddNewItemToMasterlist As Button
            Get
                Return Me._AddNewItemToMasterlist
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.AddNewItemToMasterlist_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._AddNewItemToMasterlist
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._AddNewItemToMasterlist = value
                button = Me._AddNewItemToMasterlist
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property DropDownListExport As DropDownList

		Protected Overridable Property EditBtn As Button
			Get
				Return Me._EditBtn
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.EditBtn_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._EditBtn
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._EditBtn = value
				button = Me._EditBtn
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ExportToExcel As Button
			Get
				Return Me._ExportToExcel
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ExportToExcel_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ExportToExcel
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ExportToExcel = value
				button = Me._ExportToExcel
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property HiddenFieldSelectedBay As HiddenField

		Protected Overridable Property HiddenFieldSelectedLevel As HiddenField

		Protected Overridable Property HiddenFieldSelectedRack As HiddenField

		Protected Property IsInEditMode As Boolean
			Get
				Return Me._isEditMode
			End Get
			Set(ByVal value As Boolean)
				Me._isEditMode = value
			End Set
		End Property

		Protected Overridable Property MasterListGridView As GridView
			Get
				Return Me._MasterListGridView
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewPageEventHandler As System.Web.UI.WebControls.GridViewPageEventHandler = New System.Web.UI.WebControls.GridViewPageEventHandler(AddressOf Me.MasterListGridView_PageIndexChanging)
				Dim gridViewEditEventHandler As System.Web.UI.WebControls.GridViewEditEventHandler = New System.Web.UI.WebControls.GridViewEditEventHandler(AddressOf Me.MasterListGridView_RowEditing)
				Dim gridViewDeletedEventHandler As System.Web.UI.WebControls.GridViewDeletedEventHandler = New System.Web.UI.WebControls.GridViewDeletedEventHandler(AddressOf Me.MasterListGridView_RowDeleted)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._MasterListGridView
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.PageIndexChanging,  gridViewPageEventHandler
					RemoveHandler gridView.RowEditing,  gridViewEditEventHandler
					RemoveHandler gridView.RowDeleted,  gridViewDeletedEventHandler
				End If
				Me._MasterListGridView = value
				gridView = Me._MasterListGridView
				If (gridView IsNot Nothing) Then
					AddHandler gridView.PageIndexChanging,  gridViewPageEventHandler
					AddHandler gridView.RowEditing,  gridViewEditEventHandler
					AddHandler gridView.RowDeleted,  gridViewDeletedEventHandler
				End If
			End Set
		End Property

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

		Protected Overridable Property SaveBtn As Button
			Get
				Return Me._SaveBtn
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.SaveBtn_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._SaveBtn
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._SaveBtn = value
				button = Me._SaveBtn
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
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.btnSearch_Click)
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

		Protected Overridable Property SearchTextBox As TextBox

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceExportThisData As SqlDataSource

		Protected Overridable Property SqlDataSourceExportToExcel As SqlDataSource

		Protected Overridable Property SqlDataSourceGetBay As SqlDataSource

		Protected Overridable Property SqlDataSourceGetLevel As SqlDataSource

		Protected Overridable Property SqlDataSourceGetLoc As SqlDataSource

		Protected Overridable Property SqlDataSourceGetRack As SqlDataSource

		Protected Overridable Property SqlDataSourceMasterlist As SqlDataSource

		Protected Overridable Property SqlDataSourceMasterlistHistory As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceSelectBay As SqlDataSource

		Protected Overridable Property SqlDataSourceSelectLevel As SqlDataSource

		Protected Overridable Property SqlDataSourceSelectRack As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me._isEditMode = False
		End Sub

		Protected Sub AddNewItemToMasterlist_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Redirect("AddItemToMasterList.aspx")
		End Sub

		Public Sub Alerts()
			Dim htmlGenericControl As System.Web.UI.HtmlControls.HtmlGenericControl
			Dim num As Integer = 0
			Me.Notifications.InnerHtml = ""
			Me.Session("AlertType") = "PICKUP"
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceAlerts.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Dim num1 As Integer = 0
			While sqlDataReader.Read()
				num1 = num1 + 1
			End While
			Me.Session("AlertType") = "RETRIEVAL"
			sqlDataReader = DirectCast(Me.SqlDataSourceAlerts.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Dim num2 As Integer = 0
			While sqlDataReader.Read()
				num2 = num2 + 1
			End While
			Me.Session("AlertType") = "DESTRUCTION"
			sqlDataReader = DirectCast(Me.SqlDataSourceAlerts.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Dim num3 As Integer = 0
			While sqlDataReader.Read()
				num3 = num3 + 1
			End While
			Me.Session("AlertType") = "REPICKUP"
			sqlDataReader = DirectCast(Me.SqlDataSourceAlerts.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Dim num4 As Integer = 0
			While sqlDataReader.Read()
				num4 = num4 + 1
			End While
			Try
				Try
					num = num + num1 + num2 + num3 + num4
					If (num1 <> 0) Then
						Dim notifications As System.Web.UI.HtmlControls.HtmlGenericControl = Me.Notifications
						htmlGenericControl = notifications
						notifications.InnerHtml = String.Concat(htmlGenericControl.InnerHtml, "<li><a href='TransactionPickups?Notif=true'>You have ", num1.ToString(), " new request/s in PICKUP</a></li>")
					End If
					If (num2 <> 0) Then
						Dim notifications1 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.Notifications
						htmlGenericControl = notifications1
						notifications1.InnerHtml = String.Concat(htmlGenericControl.InnerHtml, "<li><a href='TransactionRetrievals?Notif=true'>You have ", num2.ToString(), " new request/s in RETRIEVAL</a></li>")
					End If
					If (num3 <> 0) Then
						Dim htmlGenericControl1 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.Notifications
						htmlGenericControl = htmlGenericControl1
						htmlGenericControl1.InnerHtml = String.Concat(htmlGenericControl.InnerHtml, "<li><a href='TransactionDestructions?Notif=true'>You have ", num3.ToString(), " new request/s in DESTRUCTION</a></li>")
					End If
					If (num4 <> 0) Then
						Dim notifications2 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.Notifications
						htmlGenericControl = notifications2
						notifications2.InnerHtml = String.Concat(htmlGenericControl.InnerHtml, "<li><a href='TransactionRePickups?Notif=true'>You have ", num4.ToString(), " new request/s in REPICKUP</a></li>")
					End If
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			Finally
				sqlDataReader.Close()
			End Try
			Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceUserLoginAlert.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Dim num5 As Integer = 0
			Try
				While sqlDataReader1.Read()
					Dim htmlGenericControl2 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.Notifications
					htmlGenericControl = htmlGenericControl2
					htmlGenericControl2.InnerHtml = String.Concat(New String() { htmlGenericControl.InnerHtml, "<li><a href='UserLogins?ID=", sqlDataReader1("Id").ToString(), "'>New sign in from ", sqlDataReader1("User").ToString(), ".</br><small>", sqlDataReader1("DateLogin").ToString(), "</small></a></li>" })
					num5 = num5 + 1
				End While
				num = num + num5
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				sqlDataReader1.Close()
				ProjectData.ClearProjectError()
			End Try
			If (num = 0) Then
				Me.Notifications.Visible = False
				Return
			End If
			Me.TotalCount.InnerHtml = num.ToString()
		End Sub

		Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.SearchDropDownList.SelectedIndex = 0) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("BarCode Like '%", Me.SearchTextBox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 1) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("QRCode Like '%", Me.SearchTextBox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 2) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("BoxNumber Like '%", Me.SearchTextBox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 3) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("LocationCode Like '%", Me.SearchTextBox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 4) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("StockReceipt_id = '", Me.SearchTextBox.Text.Trim(), "'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 5) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("Id = '", Me.SearchTextBox.Text.Trim(), "'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 6) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("Description Like '%", Me.SearchTextBox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 7) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("CompanyCode Like '%", Me.SearchTextBox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 8) Then
					Me.SqlDataSourceMasterlist.FilterExpression = String.Concat("Department Like '%", Me.SearchTextBox.Text.Trim(), "%'")
				End If
				Me.SqlDataSourceMasterlist.[Select](DataSourceSelectArguments.Empty)
				Me.ViewState.Add("filter", Me.SqlDataSourceMasterlist.FilterExpression)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub EditBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Me._isEditMode) Then
				Me._isEditMode = True
				Me.DataBind()
				Me.EditBtn.Enabled = False
				Me.SaveBtn.Enabled = True
			End If
		End Sub

		Protected Sub ExportToExcel_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim table As DataTable = DirectCast(Me.SqlDataSourceExportThisData.[Select](DataSourceSelectArguments.Empty), DataView).ToTable()
				Using xLWorkbook As ClosedXML.Excel.XLWorkbook = New ClosedXML.Excel.XLWorkbook()
					xLWorkbook.Worksheets.Add(table)
					MyBase.Response.Clear()
					MyBase.Response.Buffer = True
					MyBase.Response.Charset = ""
					MyBase.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
					MyBase.Response.AddHeader("content-disposition", "attachment;filename=mastert_list.xlsx")
					Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
						xLWorkbook.SaveAs(memoryStream)
						memoryStream.WriteTo(MyBase.Response.OutputStream)
						MyBase.Response.Flush()
						MyBase.Response.[End]()
					End Using
				End Using
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Function getLocCodes(ByVal dt As DataTable) As Object
			Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
			stringBuilder.Append("[")
			Dim count As Integer = dt.Rows.Count - 1
			Dim num As Integer = 0
			Do
				stringBuilder.Append(String.Concat("""", dt.Rows(num)("LocationCode").ToString(), """"))
				If (num <> dt.Rows.Count - 1) Then
					stringBuilder.Append(",")
				End If
				num = num + 1
			Loop While num <= count
			stringBuilder.Append("];")
			Return stringBuilder.ToString()
		End Function

		Private Sub MasterListGridView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
			Me.MasterListGridView.PageIndex = e.NewPageIndex
			Me.MasterListGridView.DataBind()
		End Sub

		Private Sub MasterListGridView_RowDeleted(ByVal sender As Object, ByVal e As GridViewDeletedEventArgs)
			Me.Session("MasterlistID") = Convert.ToInt32(e.Keys("Id").ToString())
			Me.Session("Barcode") = e.Values(2).ToString()
			Me.SqlDataSourceMasterlistHistory.InsertParameters("Details").DefaultValue = "DELETED"
			Me.SqlDataSourceMasterlistHistory.InsertParameters("ModifiedBy").DefaultValue = MyBase.User.Identity.Name
			Dim item As Parameter = Me.SqlDataSourceMasterlistHistory.InsertParameters("ModifiedDate")
			Dim utcNow As DateTime = DateTime.UtcNow
			item.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
			Me.SqlDataSourceMasterlistHistory.Insert()
		End Sub

		Private Sub MasterListGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
			If (Me.MasterListGridView.Rows(e.NewEditIndex).RowState <> (DataControlRowState.Selected Or DataControlRowState.Edit)) Then
				Me.MasterListGridView.SelectedIndex = e.NewEditIndex
			End If
		End Sub

		Public Sub messages()
			Me.Session("AdminUserName") = MyBase.User.Identity.Name
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceMessages.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Me.messagesNotif.InnerHtml = ""
			Dim num As Integer = 0
			Try
				Try
					While sqlDataReader.Read()
						Dim str As System.Web.UI.HtmlControls.HtmlGenericControl = Me.messagesNotif
						Dim htmlGenericControl As System.Web.UI.HtmlControls.HtmlGenericControl = str
						str.InnerHtml = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(htmlGenericControl.InnerHtml, Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(String.Concat("<li><a class='none' href='AdminMessage.aspx?InboxID=", sqlDataReader("ConvoId").ToString(), "'>You have a new message from "), sqlDataReader("Sender")), "<br /><strong>"), sqlDataReader("DateCreated")), "</strong></a></li>")))
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
			Try
				Me.Alerts()
				Me.messages()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			Dim dataTable As System.Data.DataTable = New System.Data.DataTable()
			Dim dataViews As DataView = New DataView()
			dataTable = DirectCast(Me.SqlDataSourceGetLoc.[Select](DataSourceSelectArguments.Empty), DataView).ToTable()
			Me.locCode = Conversions.ToString(Me.getLocCodes(dataTable))
			Try
				If (Me.Page.IsPostBack AndAlso Me.ViewState("filter") IsNot Nothing) Then
					Me.SqlDataSourceMasterlist.FilterExpression = Me.ViewState("filter").ToString()
				End If
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.SqlDataSourceMasterlist.FilterExpression = Nothing
				Me.MasterListGridView.DataBind()
				Me.SearchTextBox.Text = ""
				Me.SearchDropDownList.SelectedIndex = 0
				Me.DropDownListExport.ClearSelection()
				Me.ViewState.Remove("filter")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub SaveBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				enumerator = Me.MasterListGridView.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
					Me.MasterListGridView.UpdateRow(current.RowIndex, False)
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me._isEditMode = False
			Me.EditBtn.Text = "Edit Mode"
			Me.SaveBtn.Enabled = False
			Me.EditBtn.Enabled = True
		End Sub
	End Class
End Namespace