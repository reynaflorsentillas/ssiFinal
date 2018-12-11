Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Configuration
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
	Public Class ReportSalesRevenue
		Inherits System.Web.UI.Page
		Private fromValue As String

		Private toValue As String

		Private total As Double

		Private totalJanuary As Double

		Private totalFebruary As Double

		Private totalMarch As Double

		Private totalApril As Double

		Private totalMay As Double

		Private totalJune As Double

		Private totalJuly As Double

		Private totalAugust As Double

		Private totalSeptember As Double

		Private totalOctober As Double

		Private totalNovember As Double

		Private totalDecember As Double

		Private crystalReport As ReportDocument

		Private crystalReport2 As ReportDocument
        Private _ButtonGenerate As Button
        Private _DownloadMonthlyBoxOverview As LinkButton
        Private _DownloadMonthlyBoxOverviewDetails As LinkButton
        Private _DownloadMonthlyBoxOverviewDetailsExcel As LinkButton
        Private _DropDownListFrom As DropDownList
        Private _DownloadMonthlyBoxOverviewEXCEL As LinkButton
        Private _DropDownListTo As DropDownList
        Private _GridView1 As GridView
        Private _GridView2 As GridView

        Protected Overridable Property ButtonGenerate As Button
            Get
                Return Me._ButtonGenerate
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonGenerate_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._ButtonGenerate
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._ButtonGenerate = value
                button = Me._ButtonGenerate
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property DownloadMonthlyBoxOverview As LinkButton
			Get
				Return Me._DownloadMonthlyBoxOverview
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.LinkButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadMonthlyBoxOverview_Click)
				Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._DownloadMonthlyBoxOverview
				If (linkButton IsNot Nothing) Then
					RemoveHandler linkButton.Click,  eventHandler
				End If
				Me._DownloadMonthlyBoxOverview = value
				linkButton = Me._DownloadMonthlyBoxOverview
				If (linkButton IsNot Nothing) Then
					AddHandler linkButton.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DownloadMonthlyBoxOverviewDetails As LinkButton
			Get
				Return Me._DownloadMonthlyBoxOverviewDetails
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.LinkButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadMonthlyBoxOverviewDetails_Click)
				Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._DownloadMonthlyBoxOverviewDetails
				If (linkButton IsNot Nothing) Then
					RemoveHandler linkButton.Click,  eventHandler
				End If
				Me._DownloadMonthlyBoxOverviewDetails = value
				linkButton = Me._DownloadMonthlyBoxOverviewDetails
				If (linkButton IsNot Nothing) Then
					AddHandler linkButton.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DownloadMonthlyBoxOverviewDetailsExcel As LinkButton
			Get
				Return Me._DownloadMonthlyBoxOverviewDetailsExcel
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.LinkButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadMonthlyBoxOverviewDetailsExcel_Click)
				Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._DownloadMonthlyBoxOverviewDetailsExcel
				If (linkButton IsNot Nothing) Then
					RemoveHandler linkButton.Click,  eventHandler
				End If
				Me._DownloadMonthlyBoxOverviewDetailsExcel = value
				linkButton = Me._DownloadMonthlyBoxOverviewDetailsExcel
				If (linkButton IsNot Nothing) Then
					AddHandler linkButton.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DownloadMonthlyBoxOverviewEXCEL As LinkButton
			Get
				Return Me._DownloadMonthlyBoxOverviewEXCEL
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.LinkButton)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DownloadMonthlyBoxOverviewEXCEL_Click)
				Dim linkButton As System.Web.UI.WebControls.LinkButton = Me._DownloadMonthlyBoxOverviewEXCEL
				If (linkButton IsNot Nothing) Then
					RemoveHandler linkButton.Click,  eventHandler
				End If
				Me._DownloadMonthlyBoxOverviewEXCEL = value
				linkButton = Me._DownloadMonthlyBoxOverviewEXCEL
				If (linkButton IsNot Nothing) Then
					AddHandler linkButton.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DropDownListFrom As DropDownList
			Get
				Return Me._DropDownListFrom
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.DropDownList)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DropDownListFrom_SelectedIndexChanged)
				Dim dropDownList As System.Web.UI.WebControls.DropDownList = Me._DropDownListFrom
				If (dropDownList IsNot Nothing) Then
					RemoveHandler dropDownList.SelectedIndexChanged,  eventHandler
				End If
				Me._DropDownListFrom = value
				dropDownList = Me._DropDownListFrom
				If (dropDownList IsNot Nothing) Then
					AddHandler dropDownList.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DropDownListTo As DropDownList
			Get
				Return Me._DropDownListTo
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.DropDownList)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DropDownListTo_SelectedIndexChanged)
				Dim dropDownList As System.Web.UI.WebControls.DropDownList = Me._DropDownListTo
				If (dropDownList IsNot Nothing) Then
					RemoveHandler dropDownList.SelectedIndexChanged,  eventHandler
				End If
				Me._DropDownListTo = value
				dropDownList = Me._DropDownListTo
				If (dropDownList IsNot Nothing) Then
					AddHandler dropDownList.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DropDownListYear As DropDownList

		Protected Overridable Property DropDownListYear2 As DropDownList

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
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridView2_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView2
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridView2 = value
				gridView = Me._GridView2
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property Label1 As Label

		Protected Overridable Property Label4 As Label

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceSalesRevenue As SqlDataSource

		Protected Overridable Property SqlDataSourceSalesRevenue2 As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me.total = 0
			Me.totalJanuary = 0
			Me.totalFebruary = 0
			Me.totalMarch = 0
			Me.totalApril = 0
			Me.totalMay = 0
			Me.totalJune = 0
			Me.totalJuly = 0
			Me.totalAugust = 0
			Me.totalSeptember = 0
			Me.totalOctober = 0
			Me.totalNovember = 0
			Me.totalDecember = 0
			Me.crystalReport = New ReportDocument()
			Me.crystalReport2 = New ReportDocument()
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

		Private Sub ApplyTextObject(ByVal vstrTextObject As String, ByVal vstrTextValue As String)
			Try
				DirectCast(Me.crystalReport.ReportDefinition.ReportObjects(vstrTextObject), TextObject).Text = vstrTextValue
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub ApplyTextObject2(ByVal vstrTextObject As String, ByVal vstrTextValue As String)
			Try
				DirectCast(Me.crystalReport2.ReportDefinition.ReportObjects(vstrTextObject), TextObject).Text = vstrTextValue
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ButtonGenerate_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim str As String = String.Concat(Me.DropDownListFrom.SelectedValue.ToString(), "/", Me.DropDownListYear.SelectedValue.ToString())
				Dim str1 As String = String.Concat(Me.DropDownListTo.SelectedValue.ToString(), "/", Me.DropDownListYear2.SelectedValue.ToString())
				Me.Session("@From") = str
				Me.Session("@To") = str1
				Me.SqlDataSourceSalesRevenue2.[Select](DataSourceSelectArguments.Empty)
				Me.GridView2.DataBind()
				If (Me.GridView2.Rows.Count <> 0) Then
					Me.DownloadMonthlyBoxOverviewDetails.Visible = True
					Me.DownloadMonthlyBoxOverviewDetailsExcel.Visible = True
				Else
					Me.DownloadMonthlyBoxOverviewDetails.Visible = False
					Me.DownloadMonthlyBoxOverviewDetailsExcel.Visible = False
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub DownloadMonthlyBoxOverview_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim footerRow As GridViewRow = Me.GridView1.FooterRow
				Dim data As DataSet1 = Me.GetData(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT CompanyCode, COUNT(CASE WHEN MONTH(CreatedDate) = 1 THEN 1 ELSE NULL END) AS January, COUNT(CASE WHEN MONTH(CreatedDate) = 2 THEN 1 ELSE NULL END) AS February, COUNT(CASE WHEN MONTH(CreatedDate) = 3 THEN 1 ELSE NULL END) AS March, COUNT(CASE WHEN MONTH(CreatedDate) = 4 THEN 1 ELSE NULL END) AS April, COUNT(CASE WHEN MONTH(CreatedDate) = 5 THEN 1 ELSE NULL END) AS May, COUNT(CASE WHEN MONTH(CreatedDate) = 6 THEN 1 ELSE NULL END) AS June, COUNT(CASE WHEN MONTH(CreatedDate) = 7 THEN 1 ELSE NULL END) AS July, COUNT(CASE WHEN MONTH(CreatedDate) = 8 THEN 1 ELSE NULL END) AS August, COUNT(CASE WHEN MONTH(CreatedDate) = 9 THEN 1 ELSE NULL END) AS September, COUNT(CASE WHEN MONTH(CreatedDate) = 10 THEN 1 ELSE NULL END) AS October, COUNT(CASE WHEN MONTH(CreatedDate) = 11 THEN 1 ELSE NULL END) AS November, COUNT(CASE WHEN MONTH(CreatedDate) = 12 THEN 1 ELSE NULL END) AS December FROM MasterList WHERE (YEAR(CreatedDate) = '", Me.Session("Year")), "') GROUP BY CompanyCode")))
				Me.crystalReport.Load(MyBase.Server.MapPath("~/devadmin/ExportSalesRevenue.rpt"))
				Me.crystalReport.SetDataSource(data)
				Me.ApplyTextObject("TextJanuary", footerRow.Cells(1).Text)
				Me.ApplyTextObject("TextFebruary", footerRow.Cells(2).Text)
				Me.ApplyTextObject("TextMarch", footerRow.Cells(3).Text)
				Me.ApplyTextObject("TextApril", footerRow.Cells(4).Text)
				Me.ApplyTextObject("TextMay", footerRow.Cells(5).Text)
				Me.ApplyTextObject("TextJune", footerRow.Cells(6).Text)
				Me.ApplyTextObject("TextJuly", footerRow.Cells(7).Text)
				Me.ApplyTextObject("TextAugust", footerRow.Cells(8).Text)
				Me.ApplyTextObject("TextSeptember", footerRow.Cells(9).Text)
				Me.ApplyTextObject("TextOctober", footerRow.Cells(10).Text)
				Me.ApplyTextObject("TextNovember", footerRow.Cells(11).Text)
				Me.ApplyTextObject("TextDecember", footerRow.Cells(12).Text)
				Me.crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, MyBase.Response, True, "MonthlyBoxOverviewPdf")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub DownloadMonthlyBoxOverviewDetails_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim footerRow As GridViewRow = Me.GridView2.FooterRow
				Dim data2 As DataSet1 = Me.GetData2(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT CompanyCode, COUNT(CreatedDate) AS Month FROM MasterList WHERE (CreatedDate >= '", Me.Session("@From")), "' ) AND (CreatedDate <= '"), Me.Session("@To")), "' ) GROUP BY CompanyCode")))
				Me.crystalReport2.Load(MyBase.Server.MapPath("~/devadmin/ExportSalesRevenue2.rpt"))
				Me.crystalReport2.SetDataSource(data2)
				Me.ApplyTextObject2("TextTotalBoxes", footerRow.Cells(1).Text)
				Me.ApplyTextObject2("TextMonthHeader", String.Concat(New String() { Me.fromValue, ", ", Me.DropDownListYear.Text, " To ", Me.toValue, ", ", Me.DropDownListYear2.Text }))
				Me.crystalReport2.ExportToHttpResponse(ExportFormatType.PortableDocFormat, MyBase.Response, True, "MonthlyBoxOverview")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub DownloadMonthlyBoxOverviewDetailsExcel_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim footerRow As GridViewRow = Me.GridView2.FooterRow
				Dim data2 As DataSet1 = Me.GetData2(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT CompanyCode, COUNT(CreatedDate) AS Month FROM MasterList WHERE (CreatedDate >= '", Me.Session("@From")), "' ) AND (CreatedDate <= '"), Me.Session("@To")), "' ) GROUP BY CompanyCode")))
				Me.crystalReport2.Load(MyBase.Server.MapPath("~/devadmin/ExportSalesRevenue2.rpt"))
				Me.crystalReport2.SetDataSource(data2)
				Me.ApplyTextObject2("TextTotalBoxes", footerRow.Cells(1).Text)
				Me.ApplyTextObject2("TextMonthHeader", String.Concat(New String() { Me.fromValue, ", ", Me.DropDownListYear.Text, " To ", Me.toValue, ", ", Me.DropDownListYear2.Text }))
				Me.crystalReport2.ExportToHttpResponse(ExportFormatType.Excel, MyBase.Response, True, "MonthlyBoxOverviewEXCEL")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub DownloadMonthlyBoxOverviewEXCEL_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Dim footerRow As GridViewRow = Me.GridView1.FooterRow
				Dim data As DataSet1 = Me.GetData(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT CompanyCode, COUNT(CASE WHEN MONTH(CreatedDate) = 1 THEN 1 ELSE NULL END) AS January, COUNT(CASE WHEN MONTH(CreatedDate) = 2 THEN 1 ELSE NULL END) AS February, COUNT(CASE WHEN MONTH(CreatedDate) = 3 THEN 1 ELSE NULL END) AS March, COUNT(CASE WHEN MONTH(CreatedDate) = 4 THEN 1 ELSE NULL END) AS April, COUNT(CASE WHEN MONTH(CreatedDate) = 5 THEN 1 ELSE NULL END) AS May, COUNT(CASE WHEN MONTH(CreatedDate) = 6 THEN 1 ELSE NULL END) AS June, COUNT(CASE WHEN MONTH(CreatedDate) = 7 THEN 1 ELSE NULL END) AS July, COUNT(CASE WHEN MONTH(CreatedDate) = 8 THEN 1 ELSE NULL END) AS August, COUNT(CASE WHEN MONTH(CreatedDate) = 9 THEN 1 ELSE NULL END) AS September, COUNT(CASE WHEN MONTH(CreatedDate) = 10 THEN 1 ELSE NULL END) AS October, COUNT(CASE WHEN MONTH(CreatedDate) = 11 THEN 1 ELSE NULL END) AS November, COUNT(CASE WHEN MONTH(CreatedDate) = 12 THEN 1 ELSE NULL END) AS December FROM MasterList WHERE (YEAR(CreatedDate) = '", Me.Session("Year")), "') GROUP BY CompanyCode")))
				Me.crystalReport.Load(MyBase.Server.MapPath("~/devadmin/ExportSalesRevenue.rpt"))
				Me.crystalReport.SetDataSource(data)
				Me.ApplyTextObject("TextJanuary", footerRow.Cells(1).Text)
				Me.ApplyTextObject("TextFebruary", footerRow.Cells(2).Text)
				Me.ApplyTextObject("TextMarch", footerRow.Cells(3).Text)
				Me.ApplyTextObject("TextApril", footerRow.Cells(4).Text)
				Me.ApplyTextObject("TextMay", footerRow.Cells(5).Text)
				Me.ApplyTextObject("TextJune", footerRow.Cells(6).Text)
				Me.ApplyTextObject("TextJuly", footerRow.Cells(7).Text)
				Me.ApplyTextObject("TextAugust", footerRow.Cells(8).Text)
				Me.ApplyTextObject("TextSeptember", footerRow.Cells(9).Text)
				Me.ApplyTextObject("TextOctober", footerRow.Cells(10).Text)
				Me.ApplyTextObject("TextNovember", footerRow.Cells(11).Text)
				Me.ApplyTextObject("TextDecember", footerRow.Cells(12).Text)
				Me.crystalReport.ExportToHttpResponse(ExportFormatType.Excel, MyBase.Response, True, "MonthlyBoxOverviewExcel")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub DropDownListFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.SelectFrom()
		End Sub

		Private Sub DropDownListTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.SelectTo()
		End Sub

		Private Function GetData(ByVal query As String) As ssiFinal.DataSet1
			Dim dataSet1 As ssiFinal.DataSet1
			Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
			Dim sqlCommand As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(query)
			Using sqlConnection As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(connectionString)
				Using sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter()
					sqlCommand.Connection = sqlConnection
					sqlDataAdapter.SelectCommand = sqlCommand
					Using dataSet11 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
						sqlDataAdapter.Fill(dataSet11, "SalesRevenue")
						dataSet1 = dataSet11
					End Using
				End Using
			End Using
			Return dataSet1
		End Function

		Private Function GetData2(ByVal query As String) As ssiFinal.DataSet1
			Dim dataSet1 As ssiFinal.DataSet1
			Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
			Dim sqlCommand As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(query)
			Using sqlConnection As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(connectionString)
				Using sqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = New System.Data.SqlClient.SqlDataAdapter()
					sqlCommand.Connection = sqlConnection
					sqlDataAdapter.SelectCommand = sqlCommand
					Using dataSet11 As ssiFinal.DataSet1 = New ssiFinal.DataSet1()
						sqlDataAdapter.Fill(dataSet11, "SalesRevenue2")
						dataSet1 = dataSet11
					End Using
				End Using
			End Using
			Return dataSet1
		End Function

		Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Dim num As Double
			Dim num1 As Double
			Dim num2 As Double
			Dim num3 As Double
			Dim num4 As Double
			Dim num5 As Double
			Dim num6 As Double
			Dim num7 As Double
			Dim num8 As Double
			Dim num9 As Double
			Dim num10 As Double
			Dim num11 As Double
			If (e.Row.RowType = DataControlRowType.Header) Then
				e.Row.Cells(0).Text = "Sales/Revenues (Record Management Client)"
				Dim item As System.Web.UI.WebControls.TableCell = e.Row.Cells(1)
				Dim year As Integer = DateTime.Now.Year
				item.Text = String.Concat("January ", year.ToString())
				Dim tableCell As System.Web.UI.WebControls.TableCell = e.Row.Cells(2)
				year = DateTime.Now.Year
				tableCell.Text = String.Concat("February ", year.ToString())
				Dim item1 As System.Web.UI.WebControls.TableCell = e.Row.Cells(3)
				year = DateTime.Now.Year
				item1.Text = String.Concat("March ", year.ToString())
				Dim tableCell1 As System.Web.UI.WebControls.TableCell = e.Row.Cells(4)
				year = DateTime.Now.Year
				tableCell1.Text = String.Concat("April ", year.ToString())
				Dim item2 As System.Web.UI.WebControls.TableCell = e.Row.Cells(5)
				year = DateTime.Now.Year
				item2.Text = String.Concat("May ", year.ToString())
				Dim tableCell2 As System.Web.UI.WebControls.TableCell = e.Row.Cells(6)
				year = DateTime.Now.Year
				tableCell2.Text = String.Concat("June ", year.ToString())
				Dim item3 As System.Web.UI.WebControls.TableCell = e.Row.Cells(7)
				year = DateTime.Now.Year
				item3.Text = String.Concat("July ", year.ToString())
				Dim tableCell3 As System.Web.UI.WebControls.TableCell = e.Row.Cells(8)
				year = DateTime.Now.Year
				tableCell3.Text = String.Concat("August ", year.ToString())
				Dim item4 As System.Web.UI.WebControls.TableCell = e.Row.Cells(9)
				year = DateTime.Now.Year
				item4.Text = String.Concat("September ", year.ToString())
				Dim tableCell4 As System.Web.UI.WebControls.TableCell = e.Row.Cells(10)
				year = DateTime.Now.Year
				tableCell4.Text = String.Concat("October ", year.ToString())
				Dim item5 As System.Web.UI.WebControls.TableCell = e.Row.Cells(11)
				year = DateTime.Now.Year
				item5.Text = String.Concat("November ", year.ToString())
				Dim tableCell5 As System.Web.UI.WebControls.TableCell = e.Row.Cells(12)
				year = DateTime.Now.Year
				tableCell5.Text = String.Concat("December ", year.ToString())
			End If
			If (e.Row.RowType = DataControlRowType.DataRow) Then
				If (Double.TryParse(e.Row.Cells(1).Text, num)) Then
					Me.totalJanuary += num
				End If
				If (Double.TryParse(e.Row.Cells(2).Text, num1)) Then
					Me.totalFebruary += num1
				End If
				If (Double.TryParse(e.Row.Cells(3).Text, num2)) Then
					Me.totalMarch += num2
				End If
				If (Double.TryParse(e.Row.Cells(4).Text, num3)) Then
					Me.totalApril += num3
				End If
				If (Double.TryParse(e.Row.Cells(5).Text, num4)) Then
					Me.totalMay += num4
				End If
				If (Double.TryParse(e.Row.Cells(6).Text, num5)) Then
					Me.totalJune += num5
				End If
				If (Double.TryParse(e.Row.Cells(7).Text, num6)) Then
					Me.totalJuly += num6
				End If
				If (Double.TryParse(e.Row.Cells(8).Text, num7)) Then
					Me.totalAugust += num7
				End If
				If (Double.TryParse(e.Row.Cells(9).Text, num8)) Then
					Me.totalSeptember += num8
				End If
				If (Double.TryParse(e.Row.Cells(10).Text, num9)) Then
					Me.totalOctober += num9
				End If
				If (Double.TryParse(e.Row.Cells(11).Text, num10)) Then
					Me.totalNovember += num10
				End If
				If (Double.TryParse(e.Row.Cells(12).Text, num11)) Then
					Me.totalDecember += num11
				End If
				e.Row.Cells(1).Text = String.Concat(e.Row.Cells(1).Text, " Boxes")
				e.Row.Cells(2).Text = String.Concat(e.Row.Cells(2).Text, " Boxes")
				e.Row.Cells(3).Text = String.Concat(e.Row.Cells(3).Text, " Boxes")
				e.Row.Cells(4).Text = String.Concat(e.Row.Cells(4).Text, " Boxes")
				e.Row.Cells(5).Text = String.Concat(e.Row.Cells(5).Text, " Boxes")
				e.Row.Cells(6).Text = String.Concat(e.Row.Cells(6).Text, " Boxes")
				e.Row.Cells(7).Text = String.Concat(e.Row.Cells(7).Text, " Boxes")
				e.Row.Cells(8).Text = String.Concat(e.Row.Cells(8).Text, " Boxes")
				e.Row.Cells(9).Text = String.Concat(e.Row.Cells(9).Text, " Boxes")
				e.Row.Cells(10).Text = String.Concat(e.Row.Cells(10).Text, " Boxes")
				e.Row.Cells(11).Text = String.Concat(e.Row.Cells(11).Text, " Boxes")
				e.Row.Cells(12).Text = String.Concat(e.Row.Cells(12).Text, " Boxes")
			End If
			If (e.Row.RowType = DataControlRowType.Footer) Then
				e.Row.Cells(0).Text = "Total Boxes "
				e.Row.Cells(1).Text = String.Concat(Me.totalJanuary.ToString(), " Boxes")
				e.Row.Cells(2).Text = String.Concat(Me.totalFebruary.ToString(), " Boxes")
				e.Row.Cells(3).Text = String.Concat(Me.totalMarch.ToString(), " Boxes")
				e.Row.Cells(4).Text = String.Concat(Me.totalApril.ToString(), " Boxes")
				e.Row.Cells(5).Text = String.Concat(Me.totalMay.ToString(), " Boxes")
				e.Row.Cells(6).Text = String.Concat(Me.totalJune.ToString(), " Boxes")
				e.Row.Cells(7).Text = String.Concat(Me.totalJuly.ToString(), " Boxes")
				e.Row.Cells(8).Text = String.Concat(Me.totalAugust.ToString(), " Boxes")
				e.Row.Cells(9).Text = String.Concat(Me.totalSeptember.ToString(), " Boxes")
				e.Row.Cells(10).Text = String.Concat(Me.totalOctober.ToString(), " Boxes")
				e.Row.Cells(11).Text = String.Concat(Me.totalNovember.ToString(), " Boxes")
				e.Row.Cells(12).Text = String.Concat(Me.totalDecember.ToString(), " Boxes")
			End If
		End Sub

		Private Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Dim num As Double
			If (e.Row.RowType = DataControlRowType.Header) Then
				e.Row.Cells(0).Text = "Sales/Revenues (Record Management Client)"
				e.Row.Cells(1).Text = String.Concat(New String() { Me.fromValue, ", ", Me.DropDownListYear.Text, " To ", Me.toValue, ", ", Me.DropDownListYear2.Text })
			End If
			If (e.Row.RowType = DataControlRowType.DataRow) Then
				Dim text As String = e.Row.Cells(1).Text
				If (Double.TryParse(e.Row.Cells(1).Text, num)) Then
					Me.total += num
				End If
				e.Row.Cells(1).Text = String.Concat(text, " Boxes")
			End If
			If (e.Row.RowType = DataControlRowType.Footer) Then
				e.Row.Cells(0).Text = "Total Boxes "
				e.Row.Cells(1).Text = String.Concat(Me.total.ToString(), " Boxes")
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
			Try
				Me.Alerts()
				Me.messages()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			Me.PopulateYear()
			Me.PopulateYear2()
			Me.SelectFrom()
			Me.SelectTo()
			Me.Session("Year") = DateTime.Now.Year.ToString()
			Me.SqlDataSourceSalesRevenue.[Select](DataSourceSelectArguments.Empty)
		End Sub

		Private Sub PopulateYear()
			Me.DropDownListYear.Items.Clear()
			Dim listItem As System.Web.UI.WebControls.ListItem = New System.Web.UI.WebControls.ListItem() With
			{
				.Text = "YYYY",
				.Value = "0"
			}
			Me.DropDownListYear.Items.Add(listItem)
			For i As Integer = DateTime.Now.Year To 2005 Step -1
				listItem = New System.Web.UI.WebControls.ListItem() With
				{
					.Text = i.ToString(),
					.Value = i.ToString()
				}
				Me.DropDownListYear.Items.Add(listItem)
			Next

			Dim items As ListItemCollection = Me.DropDownListYear.Items
			Dim year As Integer = DateTime.Now.Year
			items.FindByValue(year.ToString()).Selected = True
		End Sub

		Private Sub PopulateYear2()
			Me.DropDownListYear2.Items.Clear()
			Dim listItem As System.Web.UI.WebControls.ListItem = New System.Web.UI.WebControls.ListItem() With
			{
				.Text = "YYYY",
				.Value = "0"
			}
			Me.DropDownListYear2.Items.Add(listItem)
			For i As Integer = DateTime.Now.Year To 2005 Step -1
				listItem = New System.Web.UI.WebControls.ListItem() With
				{
					.Text = i.ToString(),
					.Value = i.ToString()
				}
				Me.DropDownListYear2.Items.Add(listItem)
			Next

			Dim items As ListItemCollection = Me.DropDownListYear2.Items
			Dim year As Integer = DateTime.Now.Year
			items.FindByValue(year.ToString()).Selected = True
		End Sub

		Protected Sub SelectFrom()
			If (Me.DropDownListFrom.SelectedIndex = 0) Then
				Me.fromValue = "January 26"
				Me.DropDownListTo.SelectedIndex = 1
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 1) Then
				Me.fromValue = "February 26"
				Me.DropDownListTo.SelectedIndex = 2
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 2) Then
				Me.fromValue = "March 26"
				Me.DropDownListTo.SelectedIndex = 3
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 3) Then
				Me.fromValue = "April 26"
				Me.DropDownListTo.SelectedIndex = 4
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 4) Then
				Me.fromValue = "May 26"
				Me.DropDownListTo.SelectedIndex = 5
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 5) Then
				Me.fromValue = "June 26"
				Me.DropDownListTo.SelectedIndex = 6
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 6) Then
				Me.fromValue = "July 26"
				Me.DropDownListTo.SelectedIndex = 7
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 7) Then
				Me.fromValue = "August 26"
				Me.DropDownListTo.SelectedIndex = 8
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 8) Then
				Me.fromValue = "September 26"
				Me.DropDownListTo.SelectedIndex = 9
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 9) Then
				Me.fromValue = "October 26"
				Me.DropDownListTo.SelectedIndex = 10
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 10) Then
				Me.fromValue = "November 26"
				Me.DropDownListTo.SelectedIndex = 11
				Return
			End If
			If (Me.DropDownListFrom.SelectedIndex = 11) Then
				Me.fromValue = "December 26"
				Me.DropDownListTo.SelectedIndex = 0
				Me.DropDownListYear.SelectedIndex = 2
				Me.DropDownListYear2.SelectedIndex = 1
			End If
		End Sub

		Protected Sub SelectTo()
			If (Me.DropDownListTo.SelectedIndex = 0) Then
				Me.toValue = "January 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 1) Then
				Me.toValue = "February 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 2) Then
				Me.toValue = "March 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 3) Then
				Me.toValue = "April 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 4) Then
				Me.toValue = "May 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 5) Then
				Me.toValue = "June 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 6) Then
				Me.toValue = "July 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 7) Then
				Me.toValue = "August 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 8) Then
				Me.toValue = "September 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 9) Then
				Me.toValue = "October 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 10) Then
				Me.toValue = "November 25"
				Return
			End If
			If (Me.DropDownListTo.SelectedIndex = 11) Then
				Me.toValue = "December 25"
			End If
		End Sub
	End Class
End Namespace