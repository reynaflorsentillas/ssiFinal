Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
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
	Public Class WebForm1
		Inherits System.Web.UI.Page
		Public errMsg As String
        Private _GridView1 As GridView
        Private _btnUpload As Button
        Private _Button1 As Button
        Private _ButtonDownloadTemplate As Button
        Private _Button2 As Button
        Private _SqlDataSourceTransHeader As SqlDataSource

        Protected Overridable Property btnUpload As Button
            Get
                Return Me._btnUpload
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.btnUpload_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._btnUpload
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._btnUpload = value
                button = Me._btnUpload
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

		Protected Overridable Property Button2 As Button
			Get
				Return Me._Button2
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button2_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._Button2
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ButtonDownloadTemplate As Button
			Get
				Return Me._ButtonDownloadTemplate
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonDownloadTemplate_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonDownloadTemplate
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonDownloadTemplate = value
				button = Me._ButtonDownloadTemplate
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property CheckBox1 As CheckBox

		Protected Overridable Property CompanyNameTextBox As TextBox

		Protected Overridable Property contactNameTextBox As TextBox

		Protected Overridable Property contactNumberTextBox As TextBox

		Protected Overridable Property DepartmentTextBox As TextBox

		Protected Overridable Property DropDownList1 As DropDownList

		Protected Overridable Property FileUpload1 As FileUpload

		Protected Overridable Property GridView1 As GridView
			Get
				Return Me._GridView1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewCommandEventHandler As System.Web.UI.WebControls.GridViewCommandEventHandler = New System.Web.UI.WebControls.GridViewCommandEventHandler(AddressOf Me.GridView1_RowCommand)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView1
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowCommand,  gridViewCommandEventHandler
				End If
				Me._GridView1 = value
				gridView = Me._GridView1
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowCommand,  gridViewCommandEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property hdUserEmail As HiddenField

		Protected Overridable Property hdUserFullName As HiddenField

		Protected Overridable Property HiddenFieldDate As HiddenField

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property pickUpAddressTextBox As TextBox

		Protected Overridable Property pickUpDateTextBox As TextBox

		Protected Overridable Property RequiredFieldValidator5 As RequiredFieldValidator

		Protected Overridable Property RequiredFieldValidator6 As RequiredFieldValidator

		Protected Overridable Property RequiredFieldValidator7 As RequiredFieldValidator

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceAlertUpdate As SqlDataSource

		Protected Overridable Property SqlDataSourceBarCodeDups As SqlDataSource

		Protected Overridable Property SqlDataSourceGetClientInfo As SqlDataSource

		Protected Overridable Property SqlDataSourceGetCompany As SqlDataSource

		Protected Overridable Property SqlDataSourceGetDepartments As SqlDataSource

		Protected Overridable Property SqlDataSourceInsertPickupItems As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

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

		Protected Overridable Property TextBox2 As TextBox

		Protected Overridable Property TextBox7 As TextBox

		Protected Overridable Property TextBox8 As TextBox

		Protected Overridable Property TextBoxRequestDate As TextBox

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

		Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.FileUpload1.HasFile) Then
					Dim fileName As String = Path.GetFileName(Me.FileUpload1.PostedFile.FileName)
					Dim extension As String = Path.GetExtension(Me.FileUpload1.PostedFile.FileName)
					Dim item As String = ConfigurationManager.AppSettings("FolderPath")
					If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(extension, ".xls", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(extension, ".xlsx", False) = 0)) Then
						Me.renderErrMsgs("You have uploaded an invalid file. You can upload .xls or .xlsx only.")
					Else
						Dim str As String = MyBase.Server.MapPath(String.Concat(item, fileName))
						Me.FileUpload1.SaveAs(str)
						Me.Import_To_Grid(str, extension, "Yes")
					End If
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.Page.IsValid) Then
				If (Me.GridView1.Rows.Count <= 0) Then
					Me.renderErrMsgs("There are no items in Pick Up.")
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
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.contactNumberTextBox.Text, "", False) = 0) Then
					Me.renderErrMsgs("Contact number is required.")
					Return
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.contactNameTextBox.Text, "", False) = 0) Then
					Me.renderErrMsgs("Contact name is required.")
					Return
				End If
				Me.errMsg = ""
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
				MyBase.Response.Redirect("SuccessPage?SuccessMessage=Your request has been successfully submitted.&Type=PickUp")
			End If
		End Sub

		Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.ViewState("currentTable") IsNot Nothing) Then
					Dim item As DataTable = DirectCast(Me.ViewState("currentTable"), DataTable)
					Dim dataRow As System.Data.DataRow = item.NewRow()
					dataRow("Box Number") = HttpUtility.HtmlDecode(Me.TextBox7.Text)
					dataRow("Department") = HttpUtility.HtmlDecode(Me.DropDownList1.SelectedValue)
					dataRow("Description") = HttpUtility.HtmlDecode(Me.TextBox8.Text)
					dataRow("Retention") = HttpUtility.HtmlDecode(Me.TextBox2.Text)
					item.Rows.Add(dataRow)
					Me.GridView1.DataSource = item
					Me.GridView1.DataBind()
					Me.ViewState("currentTable") = item
					Me.TextBox2.Text = ""
					Me.TextBox7.Text = ""
					Me.TextBox8.Text = ""
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ButtonDownloadTemplate_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (File.Exists(MyBase.Server.MapPath("~/devclient/Template/BoxesTemplate.xlsx"))) Then
					MyBase.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
					MyBase.Response.AppendHeader("Content-Disposition", "attachment; filename=BoxesTemplate.xlsx")
					MyBase.Response.WriteFile(MyBase.Server.MapPath("~/devclient/Template/BoxesTemplate.xlsx"))
					MyBase.Response.[End]()
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Sub EmailNotification()
			Try
				If (MyBase.User.IsInRole("clientSupervisor")) Then
					Using mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage("ssi_mailsender@ssistorage.com", "ssi_mail@ssistorage.com")
						mailMessage.Subject = "Pickup Request"
						Dim str As String = "image1"
						Dim str1 As String = String.Concat(String.Concat(MyBase.Server.MapPath("~"), "devclient\theme\img\"), "STORAGE.png")
						Dim alternateView As System.Net.Mail.AlternateView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(String.Concat(New String() { "<div style=""border-top:3px solid #009933"">&nbsp;</div><table><tr><td><img src=""cid:image1"" height=""75x"" width=""75px""/></td><td><b>SSI Storage Solutions Inc.</b></td></tr></table><br/><br/>You have new pickup request from ", Me.contactNameTextBox.Text, " of ", Me.CompanyNameTextBox.Text, ".<br/><br/><div style=""border-top:3px solid #009933"">&nbsp;</div>" }), Nothing, "text/html")
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

		Private Function getCode(ByVal dept As String) As String
			Dim str As String
			Do
				str = ""
				Try
					Dim str1 As String = dept
					Dim str2 As String = Conversions.ToString(Me.Session("CompanyCode"))
					Dim length As Integer = str2.Length + str1.Length
					Dim random As System.Random = New System.Random()
					Dim num As Integer = 0
					Dim charArray As Char() = "0123456789".ToCharArray()
					Dim num1 As Integer = 0
					Do
						str = String.Concat(str, Conversions.ToString(charArray(random.[Next](0, CInt(charArray.Length)))))
						num1 = num1 + 1
					Loop While num1 <= 7
					num = length + 8
					Dim random1 As System.Random = New System.Random()
					Dim chrArray As Char() = "ABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789".ToCharArray()
					Dim str3 As String = ""
					Dim num2 As Integer = 24 - num
					Dim num3 As Integer = 0
					Do
						str3 = String.Concat(str3, Conversions.ToString(chrArray(random1.[Next](0, CInt(charArray.Length)))))
						num3 = num3 + 1
					Loop While num3 <= num2
					str = String.Concat(New String() { str2, "-", str1, "-", str, str3 })
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Me.renderErrMsgs(exception.Message.ToString())
					ProjectData.ClearProjectError()
				End Try
			Loop While Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(str, Me.Session("PrevBarCode"), False)
			Me.Session("PrevBarcode") = str
			Return str
		End Function

		Private Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
			Dim item As DataTable = DirectCast(Me.ViewState("currentTable"), DataTable)
			item.Rows.RemoveAt(Conversions.ToInteger(e.CommandArgument))
			Me.GridView1.DataSource = item
			Me.GridView1.DataBind()
			Me.ViewState("currentTable") = item
		End Sub

		Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
			Dim connectionString As String = ""
			Dim str As String = Extension
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, ".xls", False) = 0) Then
				connectionString = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, ".xlsx", False) = 0) Then
				connectionString = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
			End If
			connectionString = String.Format(connectionString, FilePath, isHDR)
			Dim oleDbConnection As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(connectionString)
			Dim oleDbCommand As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand()
			Dim oleDbDataAdapter As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter()
			Dim item As DataTable = DirectCast(Me.ViewState("currentTable"), DataTable)
			oleDbCommand.Connection = oleDbConnection
			oleDbConnection.Open()
			Dim str1 As String = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()
			oleDbConnection.Close()
			oleDbConnection.Open()
			oleDbCommand.CommandText = String.Concat("SELECT * From [", str1, "]")
			oleDbDataAdapter.SelectCommand = oleDbCommand
			oleDbDataAdapter.Fill(item)
			oleDbConnection.Close()
			Me.GridView1.DataSource = item
			Me.GridView1.DataBind()
			Me.ViewState("currentTable") = item
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
					Me.DepartmentTextBox.Text = Conversions.ToString(sqlDataReader2("DepartmentName"))
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
				Try
					Dim dataTable As System.Data.DataTable = New System.Data.DataTable()
					dataTable.Columns.Add("Box Number", GetType(String))
					dataTable.Columns.Add("Description", GetType(String))
					dataTable.Columns.Add("Department", GetType(String))
					dataTable.Columns.Add("Retention", GetType(String))
					Me.GridView1.DataSource = dataTable
					Me.GridView1.DataBind()
					Me.ViewState("currentTable") = dataTable
				Catch exception2 As System.Exception
					ProjectData.SetProjectError(exception2)
					Me.renderErrMsgs(exception2.Message.ToString())
					ProjectData.ClearProjectError()
				End Try
			End If
			Try
				Me.Session("LoggedUser") = MyBase.User.Identity.Name
				Dim sqlDataReader3 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSource1.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				If (sqlDataReader3.Read()) Then
					Me.hdUserFullName.Value = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(sqlDataReader3("FirstName"), " "), sqlDataReader3("LastName")))
					Me.hdUserEmail.Value = Conversions.ToString(sqlDataReader3("email"))
				End If
			Catch exception3 As System.Exception
				ProjectData.SetProjectError(exception3)
				Me.renderErrMsgs(exception3.Message)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub RemoveAllButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim item As DataTable = DirectCast(Me.ViewState("currentTable"), DataTable)
			item.Rows.Clear()
			Me.GridView1.DataSource = item
			Me.GridView1.DataBind()
			Me.ViewState("currentTable") = item
		End Sub

		Public Sub renderErrMsgs(ByVal thisErrMsg As String)
			' 
			' Current member / type: System.Void ssiFinal.WebForm1::renderErrMsgs(System.String)
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

		Private Sub SqlDataSourceTransHeader_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim [integer] As Integer = Conversions.ToInteger(e.Command.Parameters("@transID").Value)
			Me.Session("PrevBarcode") = ""
			Try
				enumerator = Me.GridView1.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As TableRow = DirectCast(enumerator.Current, TableRow)
					Me.Session("transactionID") = [integer]
					Me.Session("Department") = HttpUtility.HtmlDecode(current.Cells(3).Text)
					Me.Session("BarCode") = HttpUtility.HtmlDecode(Me.getCode(current.Cells(3).Text))
					Me.Session("QRCode") = RuntimeHelpers.GetObjectValue(Me.Session("BarCode"))
					Me.Session("Description") = HttpUtility.HtmlDecode(current.Cells(2).Text)
					Me.Session("BoxNumber") = HttpUtility.HtmlDecode(current.Cells(1).Text)
					Me.Session("Retention") = HttpUtility.HtmlDecode(current.Cells(4).Text)
					Dim session As HttpSessionState = Me.Session
					Dim utcNow As DateTime = DateTime.UtcNow
					session("CreatedDate") = utcNow.AddHours(8)
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