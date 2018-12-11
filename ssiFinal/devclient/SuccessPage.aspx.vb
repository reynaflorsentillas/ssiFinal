Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class SuccessPage
		Inherits System.Web.UI.Page

        Private _ButtonYes As Button
        Private _ButtonNo As Button

        Protected Overridable Property ButtonNo As Button
            Get
                Return Me._ButtonNo
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonNo_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._ButtonNo
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._ButtonNo = value
                button = Me._ButtonNo
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property ButtonYes As Button
			Get
				Return Me._ButtonYes
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonYes_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonYes
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonYes = value
				button = Me._ButtonYes
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property hdUserEmail As HiddenField

		Protected Overridable Property hdUserFullName As HiddenField

		Protected Overridable Property Label1 As Label

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceAlertUpdate As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

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

		Protected Sub ButtonNo_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Redirect("masterListClient")
		End Sub

		Protected Sub ButtonYes_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Operators.CompareString(MyBase.Request("Type"), "PickUp", False) = 0) Then
				MyBase.Response.Redirect("pickUp")
				Return
			End If
			If (Operators.CompareString(MyBase.Request("Type"), "Retrieval", False) = 0) Then
				MyBase.Response.Redirect("retrieval")
				Return
			End If
			If (Operators.CompareString(MyBase.Request("Type"), "Repickup", False) = 0) Then
				MyBase.Response.Redirect("RePickUp")
				Return
			End If
			If (Operators.CompareString(MyBase.Request("Type"), "Destruction", False) = 0) Then
				MyBase.Response.Redirect("destruction")
				Return
			End If
			If (Operators.CompareString(MyBase.Request("Type"), "Approval", False) = 0) Then
				MyBase.Response.Redirect("PendingForApproval")
				Return
			End If
			MyBase.Response.Redirect("masterListClient")
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
				Me.Label1.Text = MyBase.Request("SuccessMessage")
				Me.Alerts()
				Me.messages()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub
	End Class
End Namespace