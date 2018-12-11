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
	Public Class LocationSettings
		Inherits System.Web.UI.Page

        Private _ButtonAddLevel As Button
        Private _ButtonCreate As Button
        Private _SqlDataSourceGetBay As SqlDataSource
        Private _SqlDataSourceGetRack As SqlDataSource
        Private _ButtonAddBay As Button
        Private _SqlDataSourceGetLevel As SqlDataSource

        Protected Overridable Property ButtonAddBay As Button
            Get
                Return Me._ButtonAddBay
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonAddBay_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._ButtonAddBay
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._ButtonAddBay = value
                button = Me._ButtonAddBay
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property ButtonAddLevel As Button
			Get
				Return Me._ButtonAddLevel
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonAddLevel_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonAddLevel
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonAddLevel = value
				button = Me._ButtonAddLevel
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ButtonCreate As Button
			Get
				Return Me._ButtonCreate
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonCreate_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonCreate
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonCreate = value
				button = Me._ButtonCreate
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DropDownList1 As DropDownList

		Protected Overridable Property GridView1 As GridView

		Protected Overridable Property GridView2 As GridView

		Protected Overridable Property GridView3 As GridView

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceGetBay As SqlDataSource
			Get
				Return Me._SqlDataSourceGetBay
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceGetBay_Inserted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceGetBay
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceGetBay = value
				sqlDataSource = Me._SqlDataSourceGetBay
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceGetLevel As SqlDataSource
			Get
				Return Me._SqlDataSourceGetLevel
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceGetLevel_Inserted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceGetLevel
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceGetLevel = value
				sqlDataSource = Me._SqlDataSourceGetLevel
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceGetRack As SqlDataSource
			Get
				Return Me._SqlDataSourceGetRack
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceGetRack_Inserted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceGetRack
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceGetRack = value
				sqlDataSource = Me._SqlDataSourceGetRack
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceGetRackCode As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TextBoxAddBay As TextBox

		Protected Overridable Property TextBoxAddLevel As TextBox

		Protected Overridable Property TextBoxLength As TextBox

		Protected Overridable Property TextBoxRackCode As TextBox

		Protected Overridable Property TextBoxRemarks As TextBox

		Protected Overridable Property TextBoxSqInch As TextBox

		Protected Overridable Property TextBoxSqm As TextBox

		Protected Overridable Property TextBoxWidth As TextBox

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

		Protected Sub ButtonAddBay_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.SqlDataSourceGetBay.InsertParameters("RackCode").DefaultValue = Me.DropDownList1.SelectedValue.ToString()
			Me.SqlDataSourceGetBay.InsertParameters("BayCode").DefaultValue = Me.TextBoxAddBay.Text
			Me.SqlDataSourceGetBay.Insert()
		End Sub

		Protected Sub ButtonAddLevel_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.SqlDataSourceGetLevel.InsertParameters("RackCode").DefaultValue = Me.DropDownList1.SelectedValue.ToString()
			Me.SqlDataSourceGetLevel.InsertParameters("LevelNumber").DefaultValue = Me.TextBoxAddLevel.Text
			Me.SqlDataSourceGetLevel.Insert()
		End Sub

		Protected Sub ButtonCreate_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (DirectCast(Me.SqlDataSourceGetRackCode.[Select](DataSourceSelectArguments.Empty), SqlDataReader).Read()) Then
				Dim empty As String = String.Empty
				empty = "Rack already exist. Please try again."
				MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
				Return
			End If
			Me.SqlDataSourceGetRack.InsertParameters("RackCode").DefaultValue = Me.TextBoxRackCode.Text
			Me.SqlDataSourceGetRack.InsertParameters("Length").DefaultValue = Me.TextBoxLength.Text
			Me.SqlDataSourceGetRack.InsertParameters("Width").DefaultValue = Me.TextBoxWidth.Text
			Me.SqlDataSourceGetRack.InsertParameters("SqInch").DefaultValue = Me.TextBoxSqInch.Text
			Me.SqlDataSourceGetRack.InsertParameters("Sqm").DefaultValue = Me.TextBoxSqm.Text
			Me.SqlDataSourceGetRack.InsertParameters("Remarks").DefaultValue = Me.TextBoxRemarks.Text
			Me.SqlDataSourceGetRack.Insert()
			Dim str As String = String.Empty
			str = "New Rack Inserted"
			MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), str, "');"), True)
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

		Private Sub SqlDataSourceGetBay_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.TextBoxAddBay.Text = ""
		End Sub

		Private Sub SqlDataSourceGetLevel_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.TextBoxAddLevel.Text = ""
		End Sub

		Private Sub SqlDataSourceGetRack_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.TextBoxRackCode.Text = ""
			Me.TextBoxLength.Text = ""
			Me.TextBoxWidth.Text = ""
			Me.TextBoxSqInch.Text = ""
			Me.TextBoxSqm.Text = ""
			Me.TextBoxRemarks.Text = ""
		End Sub
	End Class
End Namespace