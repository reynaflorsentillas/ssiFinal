Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ReportSpaceUtilization
		Inherits System.Web.UI.Page
		Private totalSumBin As Double

		Private totalSumBay As Double

		Private utilizedBin As Double

		Private locCount As Double

		Private rowCnt As Double
        Private _DownloadReportSpaceUtilization As LinkButton
        Private _DownloadReportSpaceUtilizationEXCEL As LinkButton
        Private _GridView1 As GridView
        Private _GridViewSpaceutilization As GridView
        Private _lnkPrint As LinkButton

        Protected Overridable Property DownloadReportSpaceUtilization As LinkButton
            Get
                Return Me._DownloadReportSpaceUtilization
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.LinkButton)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadReportSpaceUtilization_Click)
                Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._DownloadReportSpaceUtilization
                If (linkButton IsNot Nothing) Then
                    RemoveHandler linkButton.Click, eventHandler
                End If
                Me._DownloadReportSpaceUtilization = value
                linkButton = Me._DownloadReportSpaceUtilization
                If (linkButton IsNot Nothing) Then
                    AddHandler linkButton.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property DownloadReportSpaceUtilizationEXCEL As LinkButton
			Get
				Return Me._DownloadReportSpaceUtilizationEXCEL
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.LinkButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadReportSpaceUtilizationEXCEL_Click)
				Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._DownloadReportSpaceUtilizationEXCEL
				If (linkButton IsNot Nothing) Then
					RemoveHandler linkButton.Click,  eventHandler
				End If
				Me._DownloadReportSpaceUtilizationEXCEL = value
				linkButton = Me._DownloadReportSpaceUtilizationEXCEL
				If (linkButton IsNot Nothing) Then
					AddHandler linkButton.Click,  eventHandler
				End If
			End Set
		End Property

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

		Protected Overridable Property GridViewSpaceutilization As GridView
			Get
				Return Me._GridViewSpaceutilization
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridViewSpaceutilization_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewSpaceutilization
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridViewSpaceutilization = value
				gridView = Me._GridViewSpaceutilization
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property Image1 As System.Web.UI.WebControls.Image

		Protected Overridable Property Label1 As Label

		Protected Overridable Property Label2 As Label

		Protected Overridable Property Label3 As Label

		Protected Overridable Property Label4 As Label

		Protected Overridable Property Label5 As Label

		Protected Overridable Property LabelAverageBoxes As Label

		Protected Overridable Property LabelEmptyBin As Label

		Protected Overridable Property LabelTotalBay As Label

		Protected Overridable Property LabelTotalBinLoc As Label

		Protected Overridable Property LabelUtilizedBin As Label

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

		Protected Overridable Property MonthandYear As TableHeaderCell

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property Panel1 As Panel

		Protected Overridable Property ReportLabel As Label

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceBinLocation As SqlDataSource

		Protected Overridable Property SqlDataSourceGetBay As SqlDataSource

		Protected Overridable Property SqlDataSourceGetBayGrid As SqlDataSource

		Protected Overridable Property SqlDataSourceGetLevel As SqlDataSource

		Protected Overridable Property SqlDataSourceGetLocation As SqlDataSource

		Protected Overridable Property SqlDataSourceGetRack As SqlDataSource

		Protected Overridable Property SqlDataSourceGetSpaceUtilization As SqlDataSource

		Protected Overridable Property SqlDataSourceGetUtilizedBin As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceTotalBay As SqlDataSource

		Protected Overridable Property SqlDataSourceTotalLevel As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TableSummary As Table

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me.totalSumBin = 0
			Me.totalSumBay = 0
			Me.utilizedBin = 0
			Me.locCount = 0
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

		Protected Sub DownloadReportSpaceUtilization_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Clear()
			MyBase.Response.Buffer = True
			MyBase.Response.ContentType = "application/pdf"
			MyBase.Response.AddHeader("content-disposition", "attachment;filename=SpaceUtilizationPdf.pdf")
			MyBase.Response.Cache.SetCacheability(HttpCacheability.NoCache)
			Dim stringWriter As System.IO.StringWriter = New System.IO.StringWriter()
			Dim htmlTextWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stringWriter)
			Me.GridViewSpaceutilization.DataBind()
			Me.Image1.Visible = True
			Me.Image1.ImageUrl = MyBase.Server.MapPath("~/devadmin/ssi.png")
			Me.ReportLabel.Text = String.Concat("Space Utilization Monthly Report - ", Me.MonthandYear.Text, "<br/>")
			Me.GridView1.HeaderRow.Style.Add("width", "15%")
			Me.GridView1.HeaderRow.Style.Add("font-size", "10px")
			Me.GridView1.Style.Add("text-decoration", "none")
			Me.GridView1.Style.Add("font-family", "Arial, Helvetica, sans-serif;")
			Me.GridView1.Style.Add("font-size", "8px")
			Me.GridViewSpaceutilization.HeaderRow.Style.Add("width", "15%")
			Me.GridViewSpaceutilization.HeaderRow.Style.Add("font-size", "10px")
			Me.GridViewSpaceutilization.Style.Add("text-decoration", "none")
			Me.GridViewSpaceutilization.Style.Add("font-family", "Arial, Helvetica, sans-serif;")
			Me.GridViewSpaceutilization.Style.Add("font-size", "8px")
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

		Protected Sub DownloadReportSpaceUtilizationEXCEL_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Clear()
			MyBase.Response.Buffer = True
			MyBase.Response.AddHeader("content-disposition", "attachment;filename=SpaceUtilizationExcel.xls")
			MyBase.Response.Charset = ""
			MyBase.Response.ContentType = "application/vnd.ms-excel"
			Using stringWriter As System.IO.StringWriter = New System.IO.StringWriter()
				Dim htmlTextWriter As System.Web.UI.HtmlTextWriter = New System.Web.UI.HtmlTextWriter(stringWriter)
				Me.GridViewSpaceutilization.DataBind()
				Me.Panel1.RenderControl(htmlTextWriter)
				MyBase.Response.Write("<style> .textmode { } </style>")
				MyBase.Response.Output.Write(stringWriter.ToString())
				MyBase.Response.Flush()
				MyBase.Response.[End]()
			End Using
		End Sub

		Public Sub GetLocation()
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetLocation.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			While sqlDataReader.Read()
				Try
					Dim strArrays As String() = Regex.Split(Conversions.ToString(sqlDataReader("LocationCode")), ":")
					Dim str As String = strArrays(0)
					Dim str1 As String = strArrays(1)
					Dim str2 As String = strArrays(2)
					Me.Session("RackCode") = str
					Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetRack.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
					If (sqlDataReader1.Read()) Then
						Me.Session("RackCode") = str
						Me.Session("BayCode") = str1
						Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetBayGrid.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						If (sqlDataReader2.Read()) Then
							Me.Session("RackCode") = str
							Me.Session("LevelNumber") = str2
							Dim sqlDataReader3 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetLevel.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
							If (sqlDataReader3.Read()) Then
								Me.locCount += 1
							End If
							sqlDataReader3.Close()
						End If
						sqlDataReader2.Close()
					End If
					sqlDataReader1.Close()
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			End While
			sqlDataReader.Close()
		End Sub

		Public Sub GetUtillizedBin()
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetUtilizedBin.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			While sqlDataReader.Read()
				Try
					Dim strArrays As String() = Regex.Split(Conversions.ToString(sqlDataReader("SubStr")), ":")
					Dim str As String = strArrays(0)
					Dim str1 As String = strArrays(1)
					Dim str2 As String = strArrays(2)
					Me.Session("RackCode") = str
					Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetRack.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
					If (sqlDataReader1.Read()) Then
						Me.Session("RackCode") = str
						Me.Session("BayCode") = str1
						Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetBayGrid.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						If (sqlDataReader2.Read()) Then
							Me.Session("RackCode") = str
							Me.Session("LevelNumber") = str2
							Dim sqlDataReader3 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetLevel.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
							If (sqlDataReader3.Read()) Then
								Me.utilizedBin += 1
							End If
							sqlDataReader3.Close()
						End If
						sqlDataReader2.Close()
					End If
					sqlDataReader1.Close()
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			End While
			sqlDataReader.Close()
			Me.LabelUtilizedBin.Text = Conversions.ToString(Me.utilizedBin)
		End Sub

		Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Dim num As Double
			Dim num1 As Double
			If (e.Row.RowType = DataControlRowType.Header) Then
				e.Row.Cells(0).Text = "Rack Name"
				e.Row.Cells(1).Text = "Total Bays"
				e.Row.Cells(2).Text = "Total Level"
				e.Row.Cells(3).Text = "Total BIN"
			End If
			If (e.Row.RowType = DataControlRowType.DataRow) Then
				Me.Session("RackCode") = e.Row.Cells(0).Text
				Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceTotalBay.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				Dim num2 As Double = 0
				While sqlDataReader.Read()
					num2 += 1
				End While
				sqlDataReader.Close()
				Me.Session("RackCode") = e.Row.Cells(0).Text
				Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceTotalLevel.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				Dim num3 As Double = 0
				While sqlDataReader1.Read()
					num3 += 1
				End While
				sqlDataReader1.Close()
				e.Row.Cells(1).Text = num2.ToString()
				e.Row.Cells(2).Text = num3.ToString()
				Dim num4 As Double = 0
				num4 = num2 * num3
				e.Row.Cells(3).Text = num4.ToString()
				If (Double.TryParse(e.Row.Cells(3).Text, num)) Then
					Me.totalSumBin += num
				End If
				If (Double.TryParse(e.Row.Cells(1).Text, num1)) Then
					Me.totalSumBay += num1
				End If
			End If
			If (e.Row.RowType = DataControlRowType.Footer) Then
				e.Row.Cells(3).Text = Me.totalSumBin.ToString()
			End If
			Me.LabelTotalBinLoc.Text = Me.totalSumBin.ToString()
			Me.LabelTotalBay.Text = Me.totalSumBay.ToString()
			Dim num5 As Double = 0
			num5 = Me.totalSumBin - Me.utilizedBin
			Me.LabelEmptyBin.Text = num5.ToString()
			Dim num6 As Double = Me.locCount / Me.utilizedBin
			If (num6 <= 0) Then
				Me.LabelAverageBoxes.Text = Conversions.ToString(0)
				Return
			End If
			Me.LabelAverageBoxes.Text = Math.Floor(num6).ToString()
		End Sub

		Private Sub GridViewSpaceutilization_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			If (e.Row.RowType = DataControlRowType.DataRow) Then
				Dim num As Integer = 1
				Do
					Dim str As String = String.Concat("L", Convert.ToString(num))
					If (Operators.CompareString(str, "L1", False) = 0) Then
						Me.Session("RackCode") = e.Row.Cells(1).Text
						Me.Session("BayCode") = e.Row.Cells(2).Text
						Me.Session("LevelCode") = str
						Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetSpaceUtilization.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num1 As Double = 0
						While sqlDataReader.Read()
							num1 += 1
						End While
						e.Row.Cells(3).Text = Conversions.ToString(num1)
						sqlDataReader.Close()
					End If
					If (Operators.CompareString(str, "L2", False) = 0) Then
						Me.Session("RackCode") = e.Row.Cells(1).Text
						Me.Session("BayCode") = e.Row.Cells(2).Text
						Me.Session("LevelCode") = str
						Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetSpaceUtilization.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num2 As Double = 0
						While sqlDataReader1.Read()
							num2 += 1
						End While
						e.Row.Cells(4).Text = Conversions.ToString(num2)
						sqlDataReader1.Close()
					End If
					If (Operators.CompareString(str, "L3", False) = 0) Then
						Me.Session("RackCode") = e.Row.Cells(1).Text
						Me.Session("BayCode") = e.Row.Cells(2).Text
						Me.Session("LevelCode") = str
						Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetSpaceUtilization.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num3 As Double = 0
						While sqlDataReader2.Read()
							num3 += 1
						End While
						e.Row.Cells(5).Text = Conversions.ToString(num3)
						sqlDataReader2.Close()
					End If
					If (Operators.CompareString(str, "L4", False) = 0) Then
						Me.Session("RackCode") = e.Row.Cells(1).Text
						Me.Session("BayCode") = e.Row.Cells(2).Text
						Me.Session("LevelCode") = str
						Dim sqlDataReader3 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetSpaceUtilization.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num4 As Double = 0
						While sqlDataReader3.Read()
							num4 += 1
						End While
						e.Row.Cells(6).Text = Conversions.ToString(num4)
						sqlDataReader3.Close()
					End If
					If (Operators.CompareString(str, "L5", False) = 0) Then
						Me.Session("RackCode") = e.Row.Cells(1).Text
						Me.Session("BayCode") = e.Row.Cells(2).Text
						Me.Session("LevelCode") = str
						Dim sqlDataReader4 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetSpaceUtilization.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num5 As Double = 0
						While sqlDataReader4.Read()
							num5 += 1
						End While
						e.Row.Cells(7).Text = Conversions.ToString(num5)
						sqlDataReader4.Close()
					End If
					num = num + 1
				Loop While num <= 5
			End If
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
			Dim month As Integer = DateTime.Today.Month
			Dim str As String = month.ToString()
			month = DateTime.Today.Year
			Dim str1 As String = month.ToString()
			str = (New DateTimeFormatInfo()).GetMonthName(Convert.ToInt16(str))
			Me.MonthandYear.Text = String.Concat(str, " ", str1)
			Me.GetUtillizedBin()
			Me.GetLocation()
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