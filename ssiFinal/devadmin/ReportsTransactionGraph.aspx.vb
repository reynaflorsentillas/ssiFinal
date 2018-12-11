Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ReportsTransactionGraph
		Inherits System.Web.UI.Page

        Private _Button1 As Button

        Protected Overridable Property Button1 As Button
            Get
                Return Me._Button1
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button1_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._Button1
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._Button1 = value
                button = Me._Button1
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property Chart1 As Chart

		Protected Overridable Property DropDownList1 As DropDownList

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceDestructionALL As SqlDataSource

		Protected Overridable Property SqlDataSourceDestructionNew As SqlDataSource

		Protected Overridable Property SqlDataSourceDestructionPROCESSED As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourcePickupALL As SqlDataSource

		Protected Overridable Property SqlDataSourcePickupsNEW As SqlDataSource

		Protected Overridable Property SqlDataSourcePickupsPROCESSED As SqlDataSource

		Protected Overridable Property SqlDataSourceRepickupALL As SqlDataSource

		Protected Overridable Property SqlDataSourceRepickupNEW As SqlDataSource

		Protected Overridable Property SqlDataSourceRepickupPROCESSED As SqlDataSource

		Protected Overridable Property SqlDataSourceRetrievalALL As SqlDataSource

		Protected Overridable Property SqlDataSourceRetrievalNEW As SqlDataSource

		Protected Overridable Property SqlDataSourceRetrievalPROCESSED As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Protected Overridable Property txtFrom As TextBox

		Protected Overridable Property txtTo As TextBox

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

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Operators.CompareString(Me.txtFrom.Text, "", False) <> 0 And Operators.CompareString(Me.txtTo.Text, "", False) <> 0) Then
				If (Me.DropDownList1.SelectedIndex = 0) Then
					Try
						Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourcePickupsNEW.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num As Integer = 0
						While sqlDataReader.Read()
							num = num + 1
						End While
						Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourcePickupsPROCESSED.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num1 As Integer = 0
						While sqlDataReader1.Read()
							num1 = num1 + 1
						End While
						Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourcePickupALL.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num2 As Integer = 0
						While sqlDataReader2.Read()
							num2 = num2 + 1
						End While
						Dim item As System.Web.UI.DataVisualization.Charting.Series = Me.Chart1.Series("Transactions")
						item.Points.AddXY(String.Concat(num.ToString(), " New Pickup Transactions"), New Object() { num })
						item.Points.AddXY(String.Concat(num1.ToString(), " Processed Pickup Transactions"), New Object() { num1 })
						item.Points.AddXY(String.Concat(num2.ToString(), " Total Pickup Transactions"), New Object() { num2 })
					Catch exception As System.Exception
						ProjectData.SetProjectError(exception)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList1.SelectedIndex = 1) Then
					Try
						Dim sqlDataReader3 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceRepickupNEW.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num3 As Integer = 0
						While sqlDataReader3.Read()
							num3 = num3 + 1
						End While
						Dim sqlDataReader4 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceRepickupPROCESSED.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num4 As Integer = 0
						While sqlDataReader4.Read()
							num4 = num4 + 1
						End While
						Dim sqlDataReader5 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceRepickupALL.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num5 As Integer = 0
						While sqlDataReader5.Read()
							num5 = num5 + 1
						End While
						Dim series As System.Web.UI.DataVisualization.Charting.Series = Me.Chart1.Series("Transactions")
						series.Points.AddXY(String.Concat(num3.ToString(), " New Re-Pickup Transactions"), New Object() { num3 })
						series.Points.AddXY(String.Concat(num4.ToString(), " Processed Re-Pickup Transactions"), New Object() { num4 })
						series.Points.AddXY(String.Concat(num5.ToString(), " Total Re-Pickup Transactions"), New Object() { num5 })
					Catch exception1 As System.Exception
						ProjectData.SetProjectError(exception1)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList1.SelectedIndex = 2) Then
					Try
						Dim sqlDataReader6 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceRetrievalNEW.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num6 As Integer = 0
						While sqlDataReader6.Read()
							num6 = num6 + 1
						End While
						Dim sqlDataReader7 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceRetrievalPROCESSED.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num7 As Integer = 0
						While sqlDataReader7.Read()
							num7 = num7 + 1
						End While
						Dim sqlDataReader8 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceRetrievalALL.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num8 As Integer = 0
						While sqlDataReader8.Read()
							num8 = num8 + 1
						End While
						Dim item1 As System.Web.UI.DataVisualization.Charting.Series = Me.Chart1.Series("Transactions")
						item1.Points.AddXY(String.Concat(num6.ToString(), " New Retrieval Transactions"), New Object() { num6 })
						item1.Points.AddXY(String.Concat(num7.ToString(), " Processed Retrieval Transactions"), New Object() { num7 })
						item1.Points.AddXY(String.Concat(num8.ToString(), " Total Retrieval Transactions"), New Object() { num8 })
					Catch exception2 As System.Exception
						ProjectData.SetProjectError(exception2)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList1.SelectedIndex = 3) Then
					Try
						Dim sqlDataReader9 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceDestructionNew.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num9 As Integer = 0
						While sqlDataReader9.Read()
							num9 = num9 + 1
						End While
						Dim sqlDataReader10 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceDestructionPROCESSED.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num10 As Integer = 0
						While sqlDataReader10.Read()
							num10 = num10 + 1
						End While
						Dim sqlDataReader11 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceDestructionALL.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num11 As Integer = 0
						While sqlDataReader11.Read()
							num11 = num11 + 1
						End While
						Dim series1 As System.Web.UI.DataVisualization.Charting.Series = Me.Chart1.Series("Transactions")
						series1.Points.AddXY(String.Concat(num9.ToString(), " New Destruction Transactions"), New Object() { num9 })
						series1.Points.AddXY(String.Concat(num10.ToString(), " Processed Destruction Transactions"), New Object() { num10 })
						series1.Points.AddXY(String.Concat(num11.ToString(), " Total Destruction Transactions"), New Object() { num11 })
					Catch exception3 As System.Exception
						ProjectData.SetProjectError(exception3)
						ProjectData.ClearProjectError()
					End Try
				ElseIf (Me.DropDownList1.SelectedIndex = 4) Then
					Try
						Dim sqlDataReader12 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourcePickupALL.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num12 As Integer = 0
						While sqlDataReader12.Read()
							num12 = num12 + 1
						End While
						Dim sqlDataReader13 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceRepickupALL.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num13 As Integer = 0
						While sqlDataReader13.Read()
							num13 = num13 + 1
						End While
						Dim sqlDataReader14 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceRetrievalALL.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num14 As Integer = 0
						While sqlDataReader14.Read()
							num14 = num14 + 1
						End While
						Dim sqlDataReader15 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceDestructionALL.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim num15 As Integer = 0
						While sqlDataReader15.Read()
							num15 = num15 + 1
						End While
						Dim item2 As System.Web.UI.DataVisualization.Charting.Series = Me.Chart1.Series("Transactions")
						item2.Points.AddXY(String.Concat(num12.ToString(), " Total Pickup Transactions"), New Object() { num12 })
						item2.Points.AddXY(String.Concat(num13.ToString(), " Total Re-Pickup Transactions"), New Object() { num13 })
						item2.Points.AddXY(String.Concat(num14.ToString(), " Total Retrieval Transactions"), New Object() { num14 })
						item2.Points.AddXY(String.Concat(num15.ToString(), " Total Destruction Transactions"), New Object() { num15 })
					Catch exception4 As System.Exception
						ProjectData.SetProjectError(exception4)
						ProjectData.ClearProjectError()
					End Try
				End If
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
		End Sub
	End Class
End Namespace