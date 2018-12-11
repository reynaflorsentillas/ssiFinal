Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ClientMessage
		Inherits System.Web.UI.Page
		Public errMsg As String
        Private _SqlDataSourceInsertConversation As SqlDataSource
        Private _SendButton As Button
        Private _SearchButton As Button
        Private _ReplyButton As Button
        Private _RefreshButton As Button
        Private _MessagesGridView As GridView
        Protected Overridable Property BodyTextBox As TextBox

        Protected Overridable Property hdUserEmail As HiddenField

		Protected Overridable Property hdUserFullName As HiddenField

		Protected Overridable Property ListView1 As ListView

		Protected Overridable Property MessagesGridView As GridView
			Get
				Return Me._MessagesGridView
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.MessagesGridView_RowDataBound)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.MessagesGridView_SelectedIndexChanged)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._MessagesGridView
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
					RemoveHandler gridView.SelectedIndexChanged,  eventHandler
				End If
				Me._MessagesGridView = value
				gridView = Me._MessagesGridView
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
					AddHandler gridView.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property Panel1 As Panel

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

		Protected Overridable Property ReplyButton As Button
			Get
				Return Me._ReplyButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ReplyButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ReplyButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ReplyButton = value
				button = Me._ReplyButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ReplyTextBox As TextBox

		Protected Overridable Property RequiredFieldValidator1 As RequiredFieldValidator

		Protected Overridable Property RequiredFieldValidator2 As RequiredFieldValidator

		Protected Overridable Property RequiredFieldValidator3 As RequiredFieldValidator

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

		Protected Overridable Property SearchTextBox As TextBox

		Protected Overridable Property SendButton As Button
			Get
				Return Me._SendButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.SendButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._SendButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._SendButton = value
				button = Me._SendButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceAlertUpdate As SqlDataSource

		Protected Overridable Property SqlDataSourceInsertConversation As SqlDataSource
			Get
				Return Me._SqlDataSourceInsertConversation
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceInsertConversation_Inserted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceInsertConversation
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceInsertConversation = value
				sqlDataSource = Me._SqlDataSourceInsertConversation
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceInsertMessage As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceReply As SqlDataSource

		Protected Overridable Property SqlDataSourceViewMessages As SqlDataSource

		Protected Overridable Property subjectLabel As HtmlGenericControl

		Protected Overridable Property SubjectTextBox As TextBox

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

		Private Sub MessagesGridView_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					e.Row.Cells(1).Text = HttpUtility.HtmlDecode(e.Row.Cells(1).Text)
					e.Row.Cells(2).Text = HttpUtility.HtmlDecode(e.Row.Cells(2).Text)
					e.Row.Cells(3).Text = HttpUtility.HtmlDecode(e.Row.Cells(3).Text)
					e.Row.Cells(4).Text = HttpUtility.HtmlDecode(e.Row.Cells(4).Text)
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub MessagesGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("ViewConvoId") = Me.MessagesGridView.SelectedRow.Cells(1).Text
			Me.subjectLabel.InnerHtml = String.Concat("Subject: <strong>", Me.MessagesGridView.SelectedRow.Cells(3).Text, "</strong>")
			Me.ListView1.DataBind()
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
				Dim session As HttpSessionState = Me.Session
				Dim utcNow As DateTime = DateTime.UtcNow
				session("DateCreated") = utcNow.AddHours(8)
				Me.Alerts()
				Me.messages()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			If (MyBase.Request("InboxID") IsNot Nothing) Then
				Me.SqlDataSourceInsertConversation.FilterExpression = String.Concat("Id = '", MyBase.Request("InboxID"), "'")
				Me.MessagesGridView.SelectedIndex = 0
				Me.Session("InboxID") = MyBase.Request("InboxID")
				Me.SqlDataSourceMessages.Update()
			End If
		End Sub

		Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Redirect("ClientMessage")
		End Sub

		Public Sub renderErrMsgs(ByVal thisErrMsg As String)
			' 
			' Current member / type: System.Void ssiFinal.ClientMessage::renderErrMsgs(System.String)
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

		Private Sub ReplyButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("ViewConvoId") = Me.MessagesGridView.SelectedRow.Cells(1).Text
			Me.Session("Sender") = MyBase.User.Identity.GetUserName()
			Dim session As HttpSessionState = Me.Session
			Dim utcNow As DateTime = DateTime.UtcNow
			session("DateCreated") = utcNow.AddHours(8)
			Me.Session("ReplyRecipient") = Me.MessagesGridView.SelectedRow.Cells(3).Text
			Me.SqlDataSourceReply.Insert()
			Me.ListView1.DataBind()
			Me.ReplyTextBox.Text = ""
		End Sub

		Private Sub SearchButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Not Information.IsDate(Me.SearchTextBox.Text)) Then
					Me.SqlDataSourceInsertConversation.FilterExpression = String.Concat("Subject Like '%", Me.SearchTextBox.Text.Trim(), "%'")
				Else
					Me.SqlDataSourceInsertConversation.FilterExpression = String.Concat("DateCreated = '", Me.SearchTextBox.Text.Trim(), "'")
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub SendButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.SqlDataSourceInsertConversation.Insert()
		End Sub

		Private Sub SqlDataSourceInsertConversation_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.Session("ConvoId") = RuntimeHelpers.GetObjectValue(e.Command.Parameters("@ConvoId").Value)
			Dim session As HttpSessionState = Me.Session
			Dim utcNow As DateTime = DateTime.UtcNow
			session("DateSend") = utcNow.AddHours(8)
			Me.Session("clientUserName") = MyBase.User.Identity.GetUserName()
			Me.Session("Message") = Me.BodyTextBox.Text
			Me.SqlDataSourceInsertMessage.Insert()
			Me.MessagesGridView.SelectedIndex = 0
		End Sub
	End Class
End Namespace