Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports Microsoft.VisualBasic.CompilerServices
Imports System
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
	Public Class BoxCountPerDepartment
		Inherits System.Web.UI.Page
		Private totalBoxesCount As Integer
        Private _DownloadReportBoxCount As LinkButton
        Private _DownloadReportBoxCountEXCEL As LinkButton
        Private _GridView1 As GridView
        Private _lnkPrint As LinkButton
        Protected Overridable Property DateLabel As Label

        Protected Overridable Property DownloadReportBoxCount As LinkButton
			Get
				Return Me._DownloadReportBoxCount
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.LinkButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadReportBoxCount_Click)
				Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._DownloadReportBoxCount
				If (linkButton IsNot Nothing) Then
					RemoveHandler linkButton.Click,  eventHandler
				End If
				Me._DownloadReportBoxCount = value
				linkButton = Me._DownloadReportBoxCount
				If (linkButton IsNot Nothing) Then
					AddHandler linkButton.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DownloadReportBoxCountEXCEL As LinkButton
			Get
				Return Me._DownloadReportBoxCountEXCEL
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.LinkButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadReportBoxCountEXCEL_Click)
				Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._DownloadReportBoxCountEXCEL
				If (linkButton IsNot Nothing) Then
					RemoveHandler linkButton.Click,  eventHandler
				End If
				Me._DownloadReportBoxCountEXCEL = value
				linkButton = Me._DownloadReportBoxCountEXCEL
				If (linkButton IsNot Nothing) Then
					AddHandler linkButton.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DropDownList1 As DropDownList

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

		Protected Overridable Property Image1 As System.Web.UI.WebControls.Image

		Protected Overridable Property LabelCompany As Label

		Protected Overridable Property lnkPrint As LinkButton
			Get
				Return Me._lnkPrint
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.LinkButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.lnkPrint_Click)
				Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._lnkPrint
				If (linkButton IsNot Nothing) Then
					RemoveHandler linkButton.Click,  eventHandler
				End If
				Me._lnkPrint = value
				linkButton = Me._lnkPrint
				If (linkButton IsNot Nothing) Then
					AddHandler linkButton.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property Panel1 As Panel

		Protected Overridable Property ReportLabel As Label

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceAlerts0 As SqlDataSource

		Protected Overridable Property SqlDataSourceCompanyList As SqlDataSource

		Protected Overridable Property SqlDataSourceDepartmentList As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages0 As SqlDataSource

		Protected Overridable Property SqlDataSourceTotalBoxes As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
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

		Protected Sub DownloadReportBoxCount_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Clear()
			MyBase.Response.Buffer = True
			MyBase.Response.ContentType = "application/pdf"
			MyBase.Response.AddHeader("content-disposition", "attachment;filename=BoxCountPerDepartmentPdf.pdf")
			MyBase.Response.Cache.SetCacheability(HttpCacheability.NoCache)
			Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter()
			Dim htmlTextWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stringWriter)
			Me.GridView1.DataBind()
			Me.Image1.Visible = True
			Me.Image1.ImageUrl = MyBase.Server.MapPath("~/devadmin/ssi.png")
			Me.ReportLabel.Text = String.Concat("Box Count Per Department Report - ", Me.DateLabel.Text)
			Me.LabelCompany.Text = String.Concat("Company: ", Me.DropDownList1.SelectedItem.Text, "<br/>")
			Me.GridView1.HeaderRow.Style.Add("width", "15%")
			Me.GridView1.HeaderRow.Style.Add("font-size", "10px")
			Me.GridView1.Style.Add("text-decoration", "none")
			Me.GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;")
			Me.GridView1.Style.Add("font-size", "8px")
			Me.Panel1.RenderControl(htmlTextWriter)
			Dim stringReader As System.IO.StringReader = New System.IO.StringReader(stringWriter.ToString())
			Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(PageSize.A4, 7!, 7!, 7!, 7!)
			Dim hTMLWorker As iTextSharp.text.html.simpleparser.HTMLWorker = New iTextSharp.text.html.simpleparser.HTMLWorker(document)
			PdfWriter.GetInstance(document, MyBase.Response.OutputStream)
			document.Open()
			hTMLWorker.Parse(stringReader)
			document.Close()
			MyBase.Response.Write(document)
			MyBase.Response.[End]()
		End Sub

		Protected Sub DownloadReportBoxCountEXCEL_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Clear()
			MyBase.Response.Buffer = True
			MyBase.Response.AddHeader("content-disposition", "attachment;filename=BoxCountPerDepartmentExcel.xls")
			MyBase.Response.Charset = ""
			MyBase.Response.ContentType = "application/vnd.ms-excel"
			Using stringWriter As System.IO.StringWriter = New System.IO.StringWriter()
				Dim htmlTextWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stringWriter)
				Me.GridView1.DataBind()
				Me.ReportLabel.Text = String.Concat("Box Count Per Department Report - ", Me.DateLabel.Text)
				Me.LabelCompany.Text = String.Concat("Company: ", Me.DropDownList1.SelectedItem.Text)
				Me.Panel1.RenderControl(htmlTextWriter)
				MyBase.Response.Write("<style> .textmode { } </style>")
				MyBase.Response.Output.Write(stringWriter.ToString())
				MyBase.Response.Flush()
				MyBase.Response.[End]()
			End Using
		End Sub

		Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			' 
			' Current member / type: System.Void ssiFinal.BoxCountPerDepartment::GridView1_RowDataBound(System.Object,System.Web.UI.WebControls.GridViewRowEventArgs)
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void GridView1_RowDataBound(System.Object,System.Web.UI.WebControls.GridViewRowEventArgs)
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

		Protected Sub lnkPrint_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.GridView1.AllowPaging = False
			Me.GridView1.DataBind()
			Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter()
			Dim htmlTextWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stringWriter)
			Me.GridView1.RenderControl(htmlTextWriter)
			Dim str As String = stringWriter.ToString().Replace("""", "'").Replace(Environment.NewLine, "")
			Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
			stringBuilder.Append("<script type = 'text/javascript'>")
			stringBuilder.Append("window.onload = new function(){")
			stringBuilder.Append("var printWin = window.open('', '', 'left=0")
			stringBuilder.Append(",top=0,width=1000,height=1000,status=0');")
			stringBuilder.Append("printWin.document.write(""")
			stringBuilder.Append(str)
			stringBuilder.Append(""");")
			stringBuilder.Append("printWin.document.close();")
			stringBuilder.Append("printWin.focus();")
			stringBuilder.Append("printWin.print();")
			stringBuilder.Append("printWin.close();};")
			stringBuilder.Append("</script>")
			MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "GridPrint", stringBuilder.ToString())
			Me.GridView1.AllowPaging = True
			Me.GridView1.DataBind()
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
						str.InnerHtml = Conversions.ToString(Operators.AddObject(htmlGenericControl.InnerHtml, Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(String.Concat("<li><a class='none' href='AdminMessage.aspx?InboxID=", sqlDataReader("ConvoId").ToString(), "'>You have a new message from "), sqlDataReader("Sender")), "<br /><strong>"), sqlDataReader("DateCreated")), "</strong></a></li>")))
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
			Dim dateLabel As Label = Me.DateLabel
			Dim dateTime As System.DateTime = System.DateTime.UtcNow.AddHours(8)
			dateLabel.Text = dateTime.ToString("MM/dd/yyyy")
			Try
				Me.Alerts()
				Me.messages()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)
		End Sub
	End Class
End Namespace