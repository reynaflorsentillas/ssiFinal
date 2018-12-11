Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports CrystalDecisions.Web
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ReportsTransactions
		Inherits System.Web.UI.Page
		Public nl As List(Of ReportsTransactions.ssiItem)

		Private dsCustomers As DataSet1

		Private crystalReport As ReportDocument

		Private reportQuery As String
        Private _DropDownList3 As DropDownList
        Private _ButtonViewReport As Button
        Private _ButtonExportReportExcel As Button
        Private _ButtonExportReport As Button

        Protected Overridable Property ButtonExportReport As Button
            Get
                Return Me._ButtonExportReport
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonExportReport_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._ButtonExportReport
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._ButtonExportReport = value
                button = Me._ButtonExportReport
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property ButtonExportReportExcel As Button
			Get
				Return Me._ButtonExportReportExcel
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonExportReportExcel_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonExportReportExcel
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonExportReportExcel = value
				button = Me._ButtonExportReportExcel
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ButtonViewReport As Button
			Get
				Return Me._ButtonViewReport
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button1_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonViewReport
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonViewReport = value
				button = Me._ButtonViewReport
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property CrystalReportSource1 As CrystalReportSource

		Protected Overridable Property CrystalReportViewer1 As CrystalReportViewer

		Protected Overridable Property DropDownList1 As DropDownList

		Protected Overridable Property DropDownList3 As DropDownList
			Get
				Return Me._DropDownList3
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.DropDownList)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DropDownList3_SelectedIndexChanged)
				Dim dropDownList As System.Web.UI.WebControls.DropDownList = Me._DropDownList3
				If (dropDownList IsNot Nothing) Then
					RemoveHandler dropDownList.SelectedIndexChanged,  eventHandler
				End If
				Me._DropDownList3 = value
				dropDownList = Me._DropDownList3
				If (dropDownList IsNot Nothing) Then
					AddHandler dropDownList.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewTransactions As GridView

		Protected Overridable Property LabelQuery As Label

		Protected Overridable Property LabelTransactionCount As Label

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Protected Overridable Property txtFrom As TextBox

		Protected Overridable Property txtTo As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me.crystalReport = New ReportDocument()
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

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim empty As String = String.Empty
			Dim str As String = ""
			Dim str1 As String = ""
			Dim str2 As String = ""
			Dim count As Integer = 0
			If (Me.DropDownList1.SelectedIndex = 0) Then
				If (Me.DropDownList3.SelectedIndex = 0) Then
					Try
						If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
							str = "PICKUP"
							str1 = "NEW"
							Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
							Me.dsCustomers = Me.GetData(Me.reportQuery)
							count = Me.dsCustomers.Tables("Transactions").Rows.Count
							If (count <= 0) Then
								Me.LabelTransactionCount.Text = "No results found."
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = False
								Me.ButtonExportReportExcel.Visible = False
								Me.LabelQuery.Text = ""
							Else
								Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = True
								Me.ButtonExportReportExcel.Visible = True
								Me.LabelQuery.Text = Me.reportQuery
							End If
						Else
							empty = "Date range is required. Please select one."
							MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
						End If
					Catch exception As System.Exception
						ProjectData.SetProjectError(exception)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList3.SelectedIndex = 1) Then
					Try
						If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
							str = "PICKUP"
							str1 = "PROCESSED"
							Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
							Me.dsCustomers = Me.GetData(Me.reportQuery)
							count = Me.dsCustomers.Tables("Transactions").Rows.Count
							If (count <= 0) Then
								Me.LabelTransactionCount.Text = "No results found."
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = False
								Me.ButtonExportReportExcel.Visible = False
								Me.LabelQuery.Text = ""
							Else
								Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = True
								Me.ButtonExportReportExcel.Visible = True
								Me.LabelQuery.Text = Me.reportQuery
							End If
						Else
							empty = "Date range is required. Please select one."
							MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
						End If
					Catch exception1 As System.Exception
						ProjectData.SetProjectError(exception1)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList3.SelectedIndex = 2) Then
					Try
						str = "PICKUP"
						str2 = "FORAPPROVAL"
						Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status <> '", str2, "' ORDER BY CAST(RequestDate as date) DESC" })
						Me.dsCustomers = Me.GetData(Me.reportQuery)
						count = Me.dsCustomers.Tables("Transactions").Rows.Count
						If (count <= 0) Then
							Me.LabelTransactionCount.Text = "No results found."
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = Me.dsCustomers
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = False
							Me.ButtonExportReportExcel.Visible = False
							Me.LabelQuery.Text = ""
						Else
							Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = Me.dsCustomers
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = True
							Me.ButtonExportReportExcel.Visible = True
							Me.LabelQuery.Text = Me.reportQuery
						End If
					Catch exception2 As System.Exception
						ProjectData.SetProjectError(exception2)
						ProjectData.ClearProjectError()
					End Try
				End If
			ElseIf (Me.DropDownList1.SelectedIndex = 1) Then
				If (Me.DropDownList3.SelectedIndex = 0) Then
					Try
						If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
							str = "REPICKUP"
							str1 = "NEW"
							Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
							Me.dsCustomers = Me.GetData(Me.reportQuery)
							count = Me.dsCustomers.Tables("Transactions").Rows.Count
							If (count <= 0) Then
								Me.LabelTransactionCount.Text = "No results found."
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = False
								Me.ButtonExportReportExcel.Visible = False
								Me.LabelQuery.Text = ""
							Else
								Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = True
								Me.ButtonExportReportExcel.Visible = True
								Me.LabelQuery.Text = Me.reportQuery
							End If
						Else
							empty = "Date range is required. Please select one."
							MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
						End If
					Catch exception3 As System.Exception
						ProjectData.SetProjectError(exception3)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList3.SelectedIndex = 1) Then
					Try
						If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
							str = "REPICKUP"
							str1 = "PROCESSED"
							Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
							Me.dsCustomers = Me.GetData(Me.reportQuery)
							count = Me.dsCustomers.Tables("Transactions").Rows.Count
							If (count <= 0) Then
								Me.LabelTransactionCount.Text = "No results found."
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = False
								Me.ButtonExportReportExcel.Visible = False
								Me.LabelQuery.Text = ""
							Else
								Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = True
								Me.ButtonExportReportExcel.Visible = True
								Me.LabelQuery.Text = Me.reportQuery
							End If
						Else
							empty = "Date range is required. Please select one."
							MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
						End If
					Catch exception4 As System.Exception
						ProjectData.SetProjectError(exception4)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList3.SelectedIndex = 2) Then
					Try
						str = "REPICKUP"
						str2 = "FORAPPROVAL"
						Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status <> '", str2, "' ORDER BY CAST(RequestDate as date) DESC" })
						Dim data As DataSet1 = Me.GetData(Me.reportQuery)
						count = data.Tables("Transactions").Rows.Count
						If (count <= 0) Then
							Me.LabelTransactionCount.Text = "No results found."
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = data
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = False
							Me.ButtonExportReportExcel.Visible = False
							Me.LabelQuery.Text = ""
						Else
							Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = data
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = True
							Me.ButtonExportReportExcel.Visible = True
							Me.LabelQuery.Text = Me.reportQuery
						End If
					Catch exception5 As System.Exception
						ProjectData.SetProjectError(exception5)
						ProjectData.ClearProjectError()
					End Try
				End If
			ElseIf (Me.DropDownList1.SelectedIndex = 2) Then
				If (Me.DropDownList3.SelectedIndex = 0) Then
					Try
						If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
							str = "RETRIEVAL"
							str1 = "NEW"
							Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
							Me.dsCustomers = Me.GetData(Me.reportQuery)
							count = Me.dsCustomers.Tables("Transactions").Rows.Count
							If (count <= 0) Then
								Me.LabelTransactionCount.Text = "No results found."
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = False
								Me.ButtonExportReportExcel.Visible = False
								Me.LabelQuery.Text = ""
							Else
								Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = True
								Me.ButtonExportReportExcel.Visible = True
								Me.LabelQuery.Text = Me.reportQuery
							End If
						Else
							empty = "Date range is required. Please select one."
							MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
						End If
					Catch exception6 As System.Exception
						ProjectData.SetProjectError(exception6)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList3.SelectedIndex = 1) Then
					Try
						If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
							str = "RETRIEVAL"
							str1 = "PROCESSED"
							Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
							Me.dsCustomers = Me.GetData(Me.reportQuery)
							count = Me.dsCustomers.Tables("Transactions").Rows.Count
							If (count <= 0) Then
								Me.LabelTransactionCount.Text = "No results found."
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = False
								Me.ButtonExportReportExcel.Visible = False
								Me.LabelQuery.Text = ""
							Else
								Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = True
								Me.ButtonExportReportExcel.Visible = True
								Me.LabelQuery.Text = Me.reportQuery
							End If
						Else
							empty = "Date range is required. Please select one."
							MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
						End If
					Catch exception7 As System.Exception
						ProjectData.SetProjectError(exception7)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList3.SelectedIndex = 2) Then
					Try
						str = "RETRIEVAL"
						str2 = "FORAPPROVAL"
						Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status <> '", str2, "' ORDER BY CAST(RequestDate as date) DESC" })
						Me.dsCustomers = Me.GetData(Me.reportQuery)
						count = Me.dsCustomers.Tables("Transactions").Rows.Count
						If (count <= 0) Then
							Me.LabelTransactionCount.Text = "No results found."
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = Me.dsCustomers
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = False
							Me.ButtonExportReportExcel.Visible = False
							Me.LabelQuery.Text = ""
						Else
							Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = Me.dsCustomers
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = True
							Me.ButtonExportReportExcel.Visible = True
							Me.LabelQuery.Text = Me.reportQuery
						End If
					Catch exception8 As System.Exception
						ProjectData.SetProjectError(exception8)
						ProjectData.ClearProjectError()
					End Try
				End If
			ElseIf (Me.DropDownList1.SelectedIndex <> 3) Then
				If (Me.DropDownList1.SelectedIndex = 4) Then
					If (Me.DropDownList3.SelectedIndex = 0) Then
						Try
							If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
								str1 = "NEW"
								Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
								Me.dsCustomers = Me.GetData(Me.reportQuery)
								count = Me.dsCustomers.Tables("Transactions").Rows.Count
								If (count <= 0) Then
									Me.LabelTransactionCount.Text = "No results found."
									Me.LabelTransactionCount.Visible = True
									Me.GridViewTransactions.DataSource = Me.dsCustomers
									Me.GridViewTransactions.DataBind()
									Me.ButtonExportReport.Visible = False
									Me.ButtonExportReportExcel.Visible = False
									Me.LabelQuery.Text = ""
								Else
									Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
									Me.LabelTransactionCount.Visible = True
									Me.GridViewTransactions.DataSource = Me.dsCustomers
									Me.GridViewTransactions.DataBind()
									Me.ButtonExportReport.Visible = True
									Me.ButtonExportReportExcel.Visible = True
									Me.LabelQuery.Text = Me.reportQuery
								End If
							Else
								empty = "Date range is required. Please select one."
								MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
							End If
						Catch exception9 As System.Exception
							ProjectData.SetProjectError(exception9)
							ProjectData.ClearProjectError()
						End Try
					ElseIf (Me.DropDownList3.SelectedIndex = 1) Then
						Try
							If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
								str1 = "PROCESSED"
								Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
								Me.dsCustomers = Me.GetData(Me.reportQuery)
								count = Me.dsCustomers.Tables("Transactions").Rows.Count
								If (count <= 0) Then
									Me.LabelTransactionCount.Text = "No results found."
									Me.LabelTransactionCount.Visible = True
									Me.GridViewTransactions.DataSource = Me.dsCustomers
									Me.GridViewTransactions.DataBind()
									Me.ButtonExportReport.Visible = False
									Me.ButtonExportReportExcel.Visible = False
									Me.LabelQuery.Text = ""
								Else
									Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
									Me.LabelTransactionCount.Visible = True
									Me.GridViewTransactions.DataSource = Me.dsCustomers
									Me.GridViewTransactions.DataBind()
									Me.ButtonExportReport.Visible = True
									Me.ButtonExportReportExcel.Visible = True
									Me.LabelQuery.Text = Me.reportQuery
								End If
							Else
								empty = "Date range is required. Please select one."
								MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
							End If
						Catch exception10 As System.Exception
							ProjectData.SetProjectError(exception10)
							ProjectData.ClearProjectError()
						End Try
					ElseIf (Me.DropDownList3.SelectedIndex = 2) Then
						Try
							Me.reportQuery = String.Concat("SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Status <> '", "FORAPPROVAL", "' ORDER BY CAST(RequestDate as date) DESC")
							Me.dsCustomers = Me.GetData(Me.reportQuery)
							count = Me.dsCustomers.Tables("Transactions").Rows.Count
							If (count <= 0) Then
								Me.LabelTransactionCount.Text = "No results found."
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = False
								Me.ButtonExportReportExcel.Visible = False
								Me.LabelQuery.Text = ""
							Else
								Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
								Me.LabelTransactionCount.Visible = True
								Me.GridViewTransactions.DataSource = Me.dsCustomers
								Me.GridViewTransactions.DataBind()
								Me.ButtonExportReport.Visible = True
								Me.ButtonExportReportExcel.Visible = True
								Me.LabelQuery.Text = Me.reportQuery
							End If
						Catch exception11 As System.Exception
							ProjectData.SetProjectError(exception11)
							ProjectData.ClearProjectError()
						End Try
					End If
				End If
			ElseIf (Me.DropDownList3.SelectedIndex = 0) Then
				Try
					If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
						str = "DESTRUCTION"
						str1 = "NEW"
						Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
						Me.dsCustomers = Me.GetData(Me.reportQuery)
						count = Me.dsCustomers.Tables("Transactions").Rows.Count
						If (count <= 0) Then
							Me.LabelTransactionCount.Text = "No results found."
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = Me.dsCustomers
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = False
							Me.ButtonExportReportExcel.Visible = False
							Me.LabelQuery.Text = ""
						Else
							Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = Me.dsCustomers
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = True
							Me.ButtonExportReportExcel.Visible = True
							Me.LabelQuery.Text = Me.reportQuery
						End If
					Else
						empty = "Date range is required. Please select one."
						MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
					End If
				Catch exception12 As System.Exception
					ProjectData.SetProjectError(exception12)
					ProjectData.ClearProjectError()
				End Try
			ElseIf (Me.DropDownList3.SelectedIndex = 1) Then
				Try
					If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtFrom.Text, "", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.txtTo.Text, "", False) = 0)) Then
						str = "DESTRUCTION"
						str1 = "PROCESSED"
						Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status = '", str1, "' AND (CAST(RequestDate as date) BETWEEN '", Me.txtFrom.Text, "' AND '", Me.txtTo.Text, "') ORDER BY CAST(RequestDate as date) DESC" })
						Me.dsCustomers = Me.GetData(Me.reportQuery)
						count = Me.dsCustomers.Tables("Transactions").Rows.Count
						If (count <= 0) Then
							Me.LabelTransactionCount.Text = "No results found."
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = Me.dsCustomers
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = False
							Me.ButtonExportReportExcel.Visible = False
							Me.LabelQuery.Text = ""
						Else
							Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
							Me.LabelTransactionCount.Visible = True
							Me.GridViewTransactions.DataSource = Me.dsCustomers
							Me.GridViewTransactions.DataBind()
							Me.ButtonExportReport.Visible = True
							Me.ButtonExportReportExcel.Visible = True
							Me.LabelQuery.Text = Me.reportQuery
						End If
					Else
						empty = "Date range is required. Please select one."
						MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
					End If
				Catch exception13 As System.Exception
					ProjectData.SetProjectError(exception13)
					ProjectData.ClearProjectError()
				End Try
			ElseIf (Me.DropDownList3.SelectedIndex = 2) Then
				Try
					str = "DESTRUCTION"
					str2 = "FORAPPROVAL"
					Me.reportQuery = String.Concat(New String() { "SELECT CompanyCode, DepartmentCode, ContactName, RequestDate, Status, Type FROM TransactionHeaders WHERE Type = '", str, "' AND Status <> '", str2, "' ORDER BY CAST(RequestDate as date) DESC" })
					Me.dsCustomers = Me.GetData(Me.reportQuery)
					count = Me.dsCustomers.Tables("Transactions").Rows.Count
					If (count <= 0) Then
						Me.LabelTransactionCount.Text = "No results found."
						Me.LabelTransactionCount.Visible = True
						Me.GridViewTransactions.DataSource = Me.dsCustomers
						Me.GridViewTransactions.DataBind()
						Me.ButtonExportReport.Visible = False
						Me.ButtonExportReportExcel.Visible = False
						Me.LabelQuery.Text = ""
					Else
						Me.LabelTransactionCount.Text = String.Concat(count.ToString(), " results found.")
						Me.LabelTransactionCount.Visible = True
						Me.GridViewTransactions.DataSource = Me.dsCustomers
						Me.GridViewTransactions.DataBind()
						Me.ButtonExportReport.Visible = True
						Me.ButtonExportReportExcel.Visible = True
						Me.LabelQuery.Text = Me.reportQuery
					End If
				Catch exception14 As System.Exception
					ProjectData.SetProjectError(exception14)
					ProjectData.ClearProjectError()
				End Try
			End If
		End Sub

		Protected Sub ButtonExportReport_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.reportQuery = Me.LabelQuery.Text
				Me.dsCustomers = Me.GetData(Me.reportQuery)
				Me.crystalReport.Load(MyBase.Server.MapPath("~/devadmin/ReportsTransactionsCR.rpt"))
				Me.crystalReport.SetDataSource(Me.dsCustomers)
				Me.crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, MyBase.Response, True, "Transactions")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ButtonExportReportExcel_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.reportQuery = Me.LabelQuery.Text
				Me.dsCustomers = Me.GetData(Me.reportQuery)
				Me.crystalReport.Load(MyBase.Server.MapPath("~/devadmin/ReportsTransactionsCR.rpt"))
				Me.crystalReport.SetDataSource(Me.dsCustomers)
				Me.crystalReport.ExportToHttpResponse(ExportFormatType.Excel, MyBase.Response, True, "TransactionsExcel")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub DropDownList3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.Page.IsPostBack) Then
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownList3.SelectedValue, "ALL", False) = 0) Then
					Me.txtFrom.Enabled = False
					Me.txtTo.Enabled = False
					Me.txtFrom.Text = ""
					Me.txtTo.Text = ""
					Return
				End If
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownList3.SelectedValue, "NEW", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownList3.SelectedValue, "PROCESSED", False) = 0) Then
					Me.txtFrom.Enabled = True
					Me.txtTo.Enabled = True
				End If
			End If
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
						sqlDataAdapter.Fill(dataSet11, "Transactions")
						dataSet1 = dataSet11
					End Using
				End Using
			End Using
			Return dataSet1
		End Function

		Public Sub messages()
			Me.Session("AdminUserName") = MyBase.User.Identity.Name
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceMessages.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Me.messagesNotif.InnerHtml = ""
			Dim num As Integer = 0
			Dim str(-1) As String
			Try
				Try
					While sqlDataReader.Read()
						If (str.Contains(Conversions.ToString(sqlDataReader("Sender")))) Then
							Continue While
						End If
						Dim htmlGenericControl As System.Web.UI.HtmlControls.HtmlGenericControl = Me.messagesNotif
						Dim htmlGenericControl1 As System.Web.UI.HtmlControls.HtmlGenericControl = htmlGenericControl
						htmlGenericControl.InnerHtml = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(htmlGenericControl1.InnerHtml, Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(Microsoft.VisualBasic.CompilerServices.Operators.AddObject(String.Concat("<li><a class='none' href='AdminMessage.aspx?InboxID=", sqlDataReader("ConvoId").ToString(), "'>You have a new message from "), sqlDataReader("Sender")), "<br /><strong>"), sqlDataReader("DateCreated")), "</strong></a></li>")))
						num = num + 1
						str(CInt(str.Length) + 1) = Conversions.ToString(sqlDataReader("Sender"))
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
				Me.nl = New List(Of ReportsTransactions.ssiItem)()
				Me.Alerts()
				Me.messages()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Class ssiItem
			Public Property Barcode As String

			Public Sub New()
				MyBase.New()
			End Sub
		End Class
	End Class
End Namespace