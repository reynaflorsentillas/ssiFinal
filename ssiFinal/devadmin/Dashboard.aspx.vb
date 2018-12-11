Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Dashboard1
		Inherits System.Web.UI.Page
		Public boxesIn As Integer

		Public boxesOut As Integer

		Public boxesDestroyed As Integer

		Public newPickup As Integer

		Public newRetrieval As Integer

		Public newRepickup As Integer

		Public newDestruction As Integer

		Public procPickup As Integer

		Public procRetrieval As Integer

		Public procRepickup As Integer

		Public procDestruction As Integer

		Protected Overridable Property adminPanel As HtmlGenericControl

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceGetBoxesCount As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceTransactions As SqlDataSource

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

		Public Sub messages()
			Me.Session("AdminUserName") = MyBase.User.Identity.Name
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceMessages.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Me.messagesNotif.InnerHtml = ""
			Dim num As Integer = 0
			Dim strArrays(-1) As String
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
			Me.Alerts()
			Me.messages()
			If (Not MyBase.User.IsInRole("ssiAdmin")) Then
				Me.adminPanel.Visible = False
			Else
				Me.adminPanel.Visible = True
			End If
			If (Not MyBase.IsPostBack) Then
				Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetBoxesCount.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				While sqlDataReader.Read()
					If (Information.IsDBNull(RuntimeHelpers.GetObjectValue(sqlDataReader("Status")))) Then
						Continue While
					End If
					If (Operators.ConditionalCompareObjectEqual(sqlDataReader("Status"), "IN", False)) Then
						Me.boxesIn = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlDataReader("Count")))
					ElseIf (Not Operators.ConditionalCompareObjectEqual(sqlDataReader("Status"), "OUT", False)) Then
						If (Not Operators.ConditionalCompareObjectEqual(sqlDataReader("Status"), "DESTROYED", False)) Then
							Continue While
						End If
						Me.boxesDestroyed = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlDataReader("Count")))
					Else
						Me.boxesOut = Convert.ToInt32(RuntimeHelpers.GetObjectValue(sqlDataReader("Count")))
					End If
				End While
				Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceTransactions.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				While sqlDataReader1.Read()
					Dim item As Object = sqlDataReader1("Type")
					If (Operators.ConditionalCompareObjectEqual(item, "PICKUP", False)) Then
						If (Not Operators.ConditionalCompareObjectEqual(sqlDataReader1("Status"), "NEW", False)) Then
							Me.procPickup = Conversions.ToInteger(sqlDataReader1("Count"))
						Else
							Me.newPickup = Conversions.ToInteger(sqlDataReader1("Count"))
						End If
					ElseIf (Operators.ConditionalCompareObjectEqual(item, "RETRIEVAL", False)) Then
						If (Not Operators.ConditionalCompareObjectEqual(sqlDataReader1("Status"), "NEW", False)) Then
							Me.procRetrieval = Conversions.ToInteger(sqlDataReader1("Count"))
						Else
							Me.newRetrieval = Conversions.ToInteger(sqlDataReader1("Count"))
						End If
					ElseIf (Not Operators.ConditionalCompareObjectEqual(item, "REPICKUP", False)) Then
						If (Not Operators.ConditionalCompareObjectEqual(item, "DESTRUCTION", False)) Then
							Continue While
						End If
						If (Not Operators.ConditionalCompareObjectEqual(sqlDataReader1("Status"), "NEW", False)) Then
							Me.procDestruction = Conversions.ToInteger(sqlDataReader1("Count"))
						Else
							Me.newDestruction = Conversions.ToInteger(sqlDataReader1("Count"))
						End If
					ElseIf (Not Operators.ConditionalCompareObjectEqual(sqlDataReader1("Status"), "NEW", False)) Then
						Me.procRepickup = Conversions.ToInteger(sqlDataReader1("Count"))
					Else
						Me.newRepickup = Conversions.ToInteger(sqlDataReader1("Count"))
					End If
				End While
			End If
		End Sub
	End Class
End Namespace