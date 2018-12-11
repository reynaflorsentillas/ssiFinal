Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class RePickup
		Inherits System.Web.UI.Page
		Public errMsg As String
        Private _SqlDataSourceTransHeader As SqlDataSource
        Private _AddToRepickupButton As Button
        Private _Button1 As Button
        Private _GridView1 As GridView
        Private _GridView2 As GridView
        Private _RefreshButton As Button
        Private _SearchButton As Button

        Protected Overridable Property AddToRepickupButton As Button
            Get
                Return Me._AddToRepickupButton
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.AddToRepickupButton_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._AddToRepickupButton
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._AddToRepickupButton = value
                button = Me._AddToRepickupButton
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property Button1 As Button
			Get
				Return Me._Button1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button1_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._Button1
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._Button1 = value
				button = Me._Button1
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property CheckBox1 As CheckBox

		Protected Overridable Property CompanyNameTextBox As TextBox

		Protected Overridable Property contactNameTextBox As TextBox

		Protected Overridable Property contactNumberTextBox As TextBox

		Protected Overridable Property DropDownListDepartment As DropDownList

		Protected Overridable Property GridView1 As GridView
			Get
				Return Me._GridView1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridView1_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView1
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridView1 = value
				gridView = Me._GridView1
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridView2 As GridView
			Get
				Return Me._GridView2
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewCommandEventHandler As System.Web.UI.WebControls.GridViewCommandEventHandler = New System.Web.UI.WebControls.GridViewCommandEventHandler(AddressOf Me.GridView2_RowCommand)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView2
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowCommand,  gridViewCommandEventHandler
				End If
				Me._GridView2 = value
				gridView = Me._GridView2
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowCommand,  gridViewCommandEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property hdUserEmail As HiddenField

		Protected Overridable Property hdUserFullName As HiddenField

		Private ReadOnly Property ItemIDs As List(Of Integer)
			Get
				If (Me.ViewState("ItemIDs") Is Nothing) Then
					Me.ViewState("ItemIDs") = New List(Of Integer)()
				End If
				Return TryCast(Me.ViewState("ItemIDs"), List(Of Integer))
			End Get
		End Property

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property pickUpAddressTextBox As TextBox

		Protected Overridable Property pickUpDateTextBox As TextBox

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

		Protected Overridable Property SqlDataSourceGetClientInfo As SqlDataSource

		Protected Overridable Property SqlDataSourceGetCompany As SqlDataSource

		Protected Overridable Property SqlDataSourceGetDepartments As SqlDataSource

		Protected Overridable Property SqlDataSourceInsertPickupItems As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceReadMasterlist As SqlDataSource

		Protected Overridable Property SqlDataSourceReadPickUpItems As SqlDataSource

		Protected Overridable Property SqlDataSourceTransHeader As SqlDataSource
			Get
				Return Me._SqlDataSourceTransHeader
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceTransHeader_Inserted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceTransHeader
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceTransHeader = value
				sqlDataSource = Me._SqlDataSourceTransHeader
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property TextBoxRequestDate As TextBox

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub AddToRepickupButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Me.GridView1.AllowPaging = False
			Me.GridView1.DataBind()
			Try
				Try
					enumerator = Me.GridView1.Rows.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
						If (Not TryCast(current.Cells(0).FindControl("addToRepickupCheckBox"), CheckBox).Checked) Then
							Continue While
						End If
						Dim item As DataTable = DirectCast(Me.ViewState("currentTable"), DataTable)
						If (Me.ViewState("currentTable") IsNot Nothing) Then
							item = DirectCast(Me.ViewState("currentTable"), DataTable)
						End If
						Dim dataRow As System.Data.DataRow = item.NewRow()
						dataRow("MasterList Id") = HttpUtility.HtmlDecode(current.Cells(1).Text)
						dataRow("BarCode") = HttpUtility.HtmlDecode(current.Cells(3).Text)
						dataRow("QRCode") = HttpUtility.HtmlDecode(current.Cells(4).Text)
						dataRow("Box Number") = HttpUtility.HtmlDecode(current.Cells(5).Text)
						dataRow("Description") = HttpUtility.HtmlDecode(current.Cells(7).Text)
						dataRow("Department") = HttpUtility.HtmlDecode(current.Cells(6).Text)
						dataRow("Retention") = HttpUtility.HtmlDecode(current.Cells(8).Text)
						item.Rows.Add(dataRow)
						Me.GridView2.DataSource = item
						Me.GridView2.DataBind()
						Me.ViewState("currentTable") = item
					End While
				Finally
					If (TypeOf enumerator Is IDisposable) Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
			Me.GridView1.AllowPaging = True
			Me.GridView1.DataBind()
		End Sub

		Protected Sub addToRepickupCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				enumerator = Me.GridView1.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
					Dim checkBox As System.Web.UI.WebControls.CheckBox = TryCast(current.FindControl("addToRepickupCheckBox"), System.Web.UI.WebControls.CheckBox)
					If (checkBox Is Nothing) Then
						Continue While
					End If
					Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(Me.GridView1.DataKeys(current.RowIndex)("Id")))
					If (Not checkBox.Checked OrElse Me.ItemIDs.Contains(num)) Then
						If (checkBox.Checked OrElse Not Me.ItemIDs.Contains(num)) Then
							Continue While
						End If
						Me.ItemIDs.Remove(num)
					Else
						Me.ItemIDs.Add(num)
					End If
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
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

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim num As Integer = 0
			Try
				enumerator = Me.GridView2.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
					num = num + 1
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			If (num = 0) Then
				Me.renderErrMsgs("There are no items in Repick Up List.")
				Return
			End If
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.pickUpDateTextBox.Text, "", False) = 0) Then
				Me.renderErrMsgs("Pickup date is required.")
				Return
			End If
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.pickUpAddressTextBox.Text, "", False) = 0) Then
				Me.renderErrMsgs("Pickup address is required.")
				Return
			End If
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.contactNameTextBox.Text, "", False) = 0) Then
				Me.renderErrMsgs("Contact name is required.")
				Return
			End If
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.contactNumberTextBox.Text, "", False) = 0) Then
				Me.renderErrMsgs("Contact number is required.")
				Return
			End If
			If (Not Me.CheckBox1.Checked) Then
				Me.SqlDataSourceTransHeader.InsertParameters("isRush").DefaultValue = "NO"
			Else
				Me.SqlDataSourceTransHeader.InsertParameters("isRush").DefaultValue = "YES"
			End If
			If (MyBase.User.IsInRole("ssiClient")) Then
				Me.Session("Status") = "FORAPPROVAL"
			ElseIf (MyBase.User.IsInRole("clientSupervisor")) Then
				Me.Session("Status") = "NEW"
			End If
			Me.SqlDataSourceTransHeader.Insert()
			MyBase.Response.Redirect("SuccessPage?SuccessMessage=Your request has been successfully submitted.&Type=Repickup")
		End Sub

		Protected Sub chkboxSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim checkBox As System.Web.UI.WebControls.CheckBox = DirectCast(Me.GridView1.HeaderRow.FindControl("chkboxSelectAll"), System.Web.UI.WebControls.CheckBox)
			Try
				enumerator = Me.GridView1.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
					Dim checkBox1 As System.Web.UI.WebControls.CheckBox = DirectCast(current.FindControl("addToRepickupCheckBox"), System.Web.UI.WebControls.CheckBox)
					Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(Me.GridView1.DataKeys(current.RowIndex)("Id")))
					If (Not checkBox.Checked) Then
						checkBox1.Checked = False
						If (checkBox1.Checked OrElse Not Me.ItemIDs.Contains(num)) Then
							Continue While
						End If
						Me.ItemIDs.Remove(num)
					Else
						checkBox1.Checked = True
						If (Not checkBox1.Checked OrElse Me.ItemIDs.Contains(num)) Then
							Continue While
						End If
						Me.ItemIDs.Add(num)
					End If
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		Public Sub EmailNotification()
			Try
				If (MyBase.User.IsInRole("clientSupervisor")) Then
					Using mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("ssi_mailsender@ssistorage.com", "ssi_mail@ssistorage.com")
						mailMessage.Subject = "Repickup Request"
						Dim str As String = "image1"
						Dim str1 As String = String.Concat(String.Concat(MyBase.Server.MapPath("~"), "devclient\theme\img\"), "STORAGE.png")
						Dim alternateView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(String.Concat(New String() { "<div style=""border-top:3px solid #FFCC00"">&nbsp;</div><table><tr><td><img src=""cid:image1"" height=""75x"" width=""75px""/></td><td><b>SSI Storage Solutions Inc.</b></td></tr></table><br/><br/>You have new repickup request from ", Me.contactNameTextBox.Text, " of ", Me.CompanyNameTextBox.Text, ".<br/><br/><div style=""border-top:3px solid #FFCC00"">&nbsp;</div>" }), Nothing, "text/html")
						Dim linkedResource As System.Net.Mail.LinkedResource = New System.Net.Mail.LinkedResource(str1) With
						{
							.ContentId = str
						}
						linkedResource.ContentType.Name = str1
						alternateView.LinkedResources.Add(linkedResource)
						mailMessage.AlternateViews.Add(alternateView)
						mailMessage.IsBodyHtml = True
						Dim smtpClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient() With
						{
							.Host = "smtp.1and1.com",
							.EnableSsl = True
						}
						Dim networkCredential As System.Net.NetworkCredential = New System.Net.NetworkCredential("ssi_mailsender@ssistorage.com", "SSIWgtd2015")
						smtpClient.UseDefaultCredentials = True
						smtpClient.Credentials = networkCredential
						smtpClient.Port = 587
						smtpClient.Send(mailMessage)
					End Using
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Dim row As GridViewRow = e.Row
			If (row.RowType = DataControlRowType.DataRow) Then
				Dim checkBox As System.Web.UI.WebControls.CheckBox = TryCast(row.FindControl("addToRepickupCheckBox"), System.Web.UI.WebControls.CheckBox)
				If (checkBox IsNot Nothing) Then
					Dim num As Integer = Convert.ToInt32(RuntimeHelpers.GetObjectValue(Me.GridView1.DataKeys(row.RowIndex)("Id")))
					checkBox.Checked = Me.ItemIDs.Contains(num)
				End If
			End If
		End Sub

		Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
			Try
				Dim item As DataTable = DirectCast(Me.ViewState("currentTable"), DataTable)
				item.Rows.RemoveAt(Conversions.ToInteger(e.CommandArgument))
				Me.GridView2.DataSource = item
				Me.GridView2.DataBind()
				Me.ViewState("currentTable") = item
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
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
						str.InnerHtml = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(htmlGenericControl.InnerHtml, Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(String.Concat("<li><a class='none' href='ClientMessage.aspx?InboxID=", sqlDataReader("ConvoId").ToString(), "'>You have a new message from "), sqlDataReader("Sender")), "<br /><strong>"), sqlDataReader("DateCreated")), "</strong></a></li>")))
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
			Me.Session("clientUserName") = MyBase.User.Identity.GetUserName()
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetClientInfo.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			If (sqlDataReader.Read()) Then
				Me.Session("CompanyCode") = RuntimeHelpers.GetObjectValue(sqlDataReader("CompanyCode"))
				Me.Session("DepartmentCode") = RuntimeHelpers.GetObjectValue(sqlDataReader("DepartmentCode"))
				Me.Session("ContactName") = Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(sqlDataReader("LastName"), ", "), sqlDataReader("FirstName"))
				Me.Session("ContactNumber") = RuntimeHelpers.GetObjectValue(sqlDataReader("ContactNumber"))
				Me.Session("Address") = RuntimeHelpers.GetObjectValue(sqlDataReader("address"))
			End If
			If (Not Me.Page.IsPostBack) Then
				Try
					Me.contactNameTextBox.Text = Conversions.ToString(Me.Session("ContactName"))
					Me.contactNumberTextBox.Text = Conversions.ToString(Me.Session("ContactNumber"))
					Me.pickUpAddressTextBox.Text = Conversions.ToString(Me.Session("Address"))
					Dim textBoxRequestDate As TextBox = Me.TextBoxRequestDate
					Dim dateTime As System.DateTime = System.DateTime.UtcNow.AddHours(8)
					textBoxRequestDate.Text = dateTime.ToString("MM/dd/yyyy")
					Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetCompany.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
					sqlDataReader1.Read()
					Me.CompanyNameTextBox.Text = Conversions.ToString(sqlDataReader1("CompanyName"))
					Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetDepartments.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
					sqlDataReader2.Read()
					Me.DropDownListDepartment.Text = Conversions.ToString(sqlDataReader2("DepartmentName"))
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Me.renderErrMsgs(exception.Message.ToString())
					ProjectData.ClearProjectError()
				End Try
			End If
			Try
				Me.Alerts()
				Me.messages()
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				ProjectData.ClearProjectError()
			End Try
			If (Not MyBase.IsPostBack) Then
				Dim dataTable As System.Data.DataTable = New System.Data.DataTable()
				dataTable.Columns.Add("MasterList Id", GetType(String))
				dataTable.Columns.Add("BarCode", GetType(String))
				dataTable.Columns.Add("QRCode", GetType(String))
				dataTable.Columns.Add("Box Number", GetType(String))
				dataTable.Columns.Add("Description", GetType(String))
				dataTable.Columns.Add("Department", GetType(String))
				dataTable.Columns.Add("Retention", GetType(String))
				Me.GridView2.DataSource = dataTable
				Me.GridView2.DataBind()
				Me.ViewState("currentTable") = dataTable
			End If
			Try
				Me.Session("LoggedUser") = MyBase.User.Identity.Name
				Dim sqlDataReader3 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSource1.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				If (sqlDataReader3.Read()) Then
					Me.hdUserFullName.Value = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(sqlDataReader3("FirstName"), " "), sqlDataReader3("LastName")))
					Me.hdUserEmail.Value = Conversions.ToString(sqlDataReader3("email"))
				End If
			Catch exception2 As System.Exception
				ProjectData.SetProjectError(exception2)
				Me.renderErrMsgs(exception2.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.GridView1.DataBind()
				Me.SearchTextbox.Text = ""
				Me.SearchDropDownList.SelectedIndex = 0
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub RemoveAllButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim item As DataTable = DirectCast(Me.ViewState("currentTable"), DataTable)
				item.Rows.Clear()
				Me.GridView2.DataSource = item
				Me.GridView2.DataBind()
				Me.ViewState("currentTable") = item
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Sub renderErrMsgs(ByVal thisErrMsg As String)
			' 
			' Current member / type: System.Void ssiFinal.RePickup::renderErrMsgs(System.String)
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void renderErrMsgs(System.String)
			' 
			' The unary opperator AddressReference is not supported in VisualBasic
			'    at ..(DecompilationContext ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Steps\DetermineNotSupportedVBCodeStep.cs:line 22
			'    at ..(MethodBody ,  , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 88
			'    at ..(MethodBody , ILanguage ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\DecompilationPipeline.cs:line 70
			'    at Telerik.JustDecompiler.Decompiler.Extensions.( , ILanguage , MethodBody , DecompilationContext& ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 95
			'    at Telerik.JustDecompiler.Decompiler.Extensions.(MethodBody , ILanguage , DecompilationContext& ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\Extensions.cs:line 58
			'    at ..(ILanguage , MethodDefinition ,  ) in C:\DeveloperTooling_JD_Agent1\_work\15\s\OpenSource\Cecil.Decompiler\Decompiler\WriterContextServices\BaseWriterContextService.cs:line 117
			' 
			' mailto: JustDecompilePublicFeedback@telerik.com

		End Sub

		Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.SearchDropDownList.SelectedIndex = 0) Then
					Me.SqlDataSourceReadMasterlist.FilterExpression = String.Concat("BarCode LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 1) Then
					Me.SqlDataSourceReadMasterlist.FilterExpression = String.Concat("Description LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 2) Then
					Me.SqlDataSourceReadMasterlist.FilterExpression = String.Concat("BoxNumber LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 3) Then
					Me.SqlDataSourceReadMasterlist.FilterExpression = String.Concat("Department LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub SqlDataSourceTransHeader_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim [integer] As Integer = Conversions.ToInteger(e.Command.Parameters("@transID").Value)
			Try
				enumerator = Me.GridView2.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
					Dim text As String = current.Cells(3).Text
					Me.SqlDataSourceInsertPickupItems.InsertParameters("TransactionHeaders_id").DefaultValue = Conversions.ToString([integer])
					Me.SqlDataSourceInsertPickupItems.InsertParameters("Department").DefaultValue = HttpUtility.HtmlDecode(current.Cells(7).Text)
					Me.SqlDataSourceInsertPickupItems.InsertParameters("BarCode").DefaultValue = HttpUtility.HtmlDecode(current.Cells(3).Text)
					Me.SqlDataSourceInsertPickupItems.InsertParameters("QRCode").DefaultValue = HttpUtility.HtmlDecode(current.Cells(3).Text)
					Me.SqlDataSourceInsertPickupItems.InsertParameters("Description").DefaultValue = HttpUtility.HtmlDecode(current.Cells(6).Text)
					Me.SqlDataSourceInsertPickupItems.InsertParameters("BoxNumber").DefaultValue = HttpUtility.HtmlDecode(current.Cells(5).Text)
					Dim item As Parameter = Me.SqlDataSourceInsertPickupItems.InsertParameters("CreatedDate")
					Dim utcNow As DateTime = DateTime.UtcNow
					item.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
					Me.SqlDataSourceInsertPickupItems.InsertParameters("Retention").DefaultValue = HttpUtility.HtmlDecode(current.Cells(8).Text)
					Me.SqlDataSourceInsertPickupItems.InsertParameters("Status").DefaultValue = "NEW"
					Me.SqlDataSourceInsertPickupItems.InsertParameters("MasterList_Id").DefaultValue = HttpUtility.HtmlDecode(current.Cells(2).Text)
					Me.SqlDataSourceInsertPickupItems.Insert()
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.EmailNotification()
		End Sub
	End Class
End Namespace