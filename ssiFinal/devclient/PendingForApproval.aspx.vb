Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.ObjectModel
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
	Public Class PendingForApproval
		Inherits System.Web.UI.Page
		Public errMsg As String
        Private _TransactionPickupsGridView As GridView
        Private _ReceiveButton As Button
        Private _RefreshButton As Button
        Private _SearchButton As Button
        Private _SqlDataSourceSelectTransactions As SqlDataSource
        Private _TransactionPickupItemsGridView As GridView
        Protected Overridable Property hdUserEmail As HiddenField

        Protected Overridable Property hdUserFullName As HiddenField

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property ReceiveButton As Button
			Get
				Return Me._ReceiveButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ReceiveButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ReceiveButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ReceiveButton = value
				button = Me._ReceiveButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

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

		Protected Overridable Property SqlDataSourceBoxesPickUp As SqlDataSource

		Protected Overridable Property SqlDataSourceBoxesRetrival As SqlDataSource

		Protected Overridable Property SqlDataSourceDestruction As SqlDataSource

		Protected Overridable Property SqlDataSourceGetClientInfo As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceRepickup As SqlDataSource

		Protected Overridable Property SqlDataSourceSelectTransactions As SqlDataSource
			Get
				Return Me._SqlDataSourceSelectTransactions
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceSelectTransactions_Updated)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceSelectTransactions
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Updated,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceSelectTransactions = value
				sqlDataSource = Me._SqlDataSourceSelectTransactions
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Updated,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceSelectTransactionsDetails As SqlDataSource

		Protected Overridable Property SqlDataSourceUpdateTransaction As SqlDataSource

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Protected Overridable Property TransactionPickupDetailsView As DetailsView

		Protected Overridable Property TransactionPickupItemsGridView As GridView
			Get
				Return Me._TransactionPickupItemsGridView
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.TransactionPickupItemsGridView_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._TransactionPickupItemsGridView
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._TransactionPickupItemsGridView = value
				gridView = Me._TransactionPickupItemsGridView
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property TransactionPickupsGridView As GridView
			Get
				Return Me._TransactionPickupsGridView
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.TransactionPickupsGridView_SelectedIndexChanged)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._TransactionPickupsGridView
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.SelectedIndexChanged,  eventHandler
				End If
				Me._TransactionPickupsGridView = value
				gridView = Me._TransactionPickupsGridView
				If (gridView IsNot Nothing) Then
					AddHandler gridView.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

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

		Public Sub EmailNotification()
			Dim str As String = Nothing
			Try
				If (MyBase.User.IsInRole("clientSupervisor")) Then
					Dim text As String = Me.TransactionPickupDetailsView.Rows(10).Cells(1).Text
					Dim text1 As String = Me.TransactionPickupDetailsView.Rows(1).Cells(1).Text
					Dim str1 As String = Me.TransactionPickupDetailsView.Rows(2).Cells(1).Text
					Using mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("ssi_mailsender@ssistorage.com", "ssi_mail@ssistorage.com")
						mailMessage.Subject = String.Concat(text, " Request")
						Dim str2 As String = "image1"
						Dim str3 As String = String.Concat(String.Concat(MyBase.Server.MapPath("~"), "devclient\theme\img\"), "STORAGE.png")
						If (Operators.CompareString(text, "PICKUP", False) = 0) Then
							str = String.Concat(New String() { "<div style=""border-top:3px solid #009933"">&nbsp;</div><table><tr><td><img src=""cid:image1"" height=""75x"" width=""75px""/></td><td><b>SSI Storage Solutions Inc.</b></td></tr></table><br/><br/>You have new pickup request from ", str1, " of ", text1, ".<br/><br/><div style=""border-top:3px solid #009933"">&nbsp;</div>" })
						ElseIf (Operators.CompareString(text, "REPICKUP", False) = 0) Then
							str = String.Concat(New String() { "<div style=""border-top:3px solid #FFCC00"">&nbsp;</div><table><tr><td><img src=""cid:image1"" height=""75x"" width=""75px""/></td><td><b>SSI Storage Solutions Inc.</b></td></tr></table><br/><br/>You have new repickup request from ", str1, " of ", text1, ".<br/><br/><div style=""border-top:3px solid #FFCC00"">&nbsp;</div>" })
						ElseIf (Operators.CompareString(text, "RETRIEVAL", False) = 0) Then
							str = String.Concat(New String() { "<div style=""border-top:3px solid #22BCE5"">&nbsp;</div><table><tr><td><img src=""cid:image1"" height=""75x"" width=""75px""/></td><td><b>SSI Storage Solutions Inc.</b></td></tr></table><br/><br/>You have new retrieval request from ", str1, " of ", text1, ".<br/><br/><div style=""border-top:3px solid #22BCE5"">&nbsp;</div>" })
						ElseIf (Operators.CompareString(text, "DESTRUCTION", False) = 0) Then
							str = String.Concat(New String() { "<div style=""border-top:3px solid #FF0000"">&nbsp;</div><table><tr><td><img src=""cid:image1"" height=""75x"" width=""75px""/></td><td><b>SSI Storage Solutions Inc.</b></td></tr></table><br/><br/>You have new ", text, " request from ", str1, " of ", text1, ".<br/><br/><div style=""border-top:3px solid #FF0000"">&nbsp;</div>" })
						End If
						Dim alternateView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(str, Nothing, "text/html")
						Dim linkedResource As System.Net.Mail.LinkedResource = New System.Net.Mail.LinkedResource(str3) With
						{
							.ContentId = str2
						}
						linkedResource.ContentType.Name = str3
						alternateView.LinkedResources.Add(linkedResource)
						mailMessage.AlternateViews.Add(alternateView)
						mailMessage.IsBodyHtml = False
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
				Me.Session("clientUserName") = MyBase.User.Identity.GetUserName()
				Me.Alerts()
				Me.messages()
				Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetClientInfo.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				sqlDataReader1.Read()
				Me.Session("CompanyCode") = RuntimeHelpers.GetObjectValue(sqlDataReader1("CompanyCode"))
				Me.TransactionPickupsGridView.DataBind()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ReceiveButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.ReceiveButton.Enabled = False
			Try
				Me.SqlDataSourceSelectTransactions.UpdateParameters("Status").DefaultValue = "NEW"
				Dim item As Parameter = Me.SqlDataSourceSelectTransactions.UpdateParameters("RequestDate")
				Dim dateTime As System.DateTime = System.DateTime.UtcNow.AddHours(8)
				item.DefaultValue = dateTime.ToString("MM/dd/yyyy")
				Me.SqlDataSourceSelectTransactions.Update()
				MyBase.Response.Redirect("SuccessPage?SuccessMessage=Your request has been successfully submitted.&Type=Approval")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.TransactionPickupsGridView.DataBind()
				Me.SearchTextbox.Text = ""
				Me.SearchDropDownList.SelectedIndex = 0
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Sub renderErrMsgs(ByVal thisErrMsg As String)
			' 
			' Current member / type: System.Void ssiFinal.PendingForApproval::renderErrMsgs(System.String)
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
			If (Me.SearchDropDownList.SelectedIndex = 0) Then
				Me.SqlDataSourceSelectTransactions.FilterExpression = String.Concat("ContactName LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				Return
			End If
			If (Me.SearchDropDownList.SelectedIndex = 1) Then
				Me.SqlDataSourceSelectTransactions.FilterExpression = If(String.Concat("ID = ", Me.SearchTextbox.Text.Trim()), "")
			End If
		End Sub

		Private Sub SqlDataSourceSelectTransactions_Updated(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.EmailNotification()
		End Sub

		Private Sub TransactionPickupItemsGridView_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
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
					e.Row.Cells(11).Text = HttpUtility.HtmlDecode(e.Row.Cells(11).Text)
					e.Row.Cells(12).Text = HttpUtility.HtmlDecode(e.Row.Cells(12).Text)
					e.Row.Cells(13).Text = HttpUtility.HtmlDecode(e.Row.Cells(13).Text)
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub TransactionPickupsGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Operators.CompareString(Me.TransactionPickupsGridView.SelectedRow.Cells(10).Text, "PICKUP", False) = 0) Then
					Me.TransactionPickupItemsGridView.DataSourceID = Me.SqlDataSourceBoxesPickUp.ID
					Me.TransactionPickupItemsGridView.DataBind()
				ElseIf (Operators.CompareString(Me.TransactionPickupsGridView.SelectedRow.Cells(10).Text, "RETRIEVAL", False) = 0) Then
					Me.TransactionPickupItemsGridView.DataSourceID = Me.SqlDataSourceBoxesRetrival.ID
					Me.TransactionPickupItemsGridView.DataBind()
				ElseIf (Operators.CompareString(Me.TransactionPickupsGridView.SelectedRow.Cells(10).Text, "DESTRUCTION", False) = 0) Then
					Me.TransactionPickupItemsGridView.DataSourceID = Me.SqlDataSourceDestruction.ID
					Me.TransactionPickupItemsGridView.DataBind()
				ElseIf (Operators.CompareString(Me.TransactionPickupsGridView.SelectedRow.Cells(10).Text, "REPICKUP", False) = 0) Then
					Me.TransactionPickupItemsGridView.DataSourceID = Me.SqlDataSourceRepickup.ID
					Me.TransactionPickupItemsGridView.DataBind()
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub
	End Class
End Namespace