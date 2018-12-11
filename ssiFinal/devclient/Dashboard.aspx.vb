Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Dashboard
		Inherits System.Web.UI.Page
		Protected Overridable Property hdUserEmail As HiddenField

		Protected Overridable Property hdUserFullName As HiddenField

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property sectionsFaqs As HtmlGenericControl

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceLoadAnswers As SqlDataSource

		Protected Overridable Property SqlDataSourceLoadSections As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property supervisorDiv As HtmlGenericControl

		Protected Overridable Property tabContent As HtmlGenericControl

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

		Protected Sub Faqs()
			Dim htmlGenericControl As System.Web.UI.HtmlControls.HtmlGenericControl
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceLoadSections.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			Dim strArrays(-1) As String
			Dim str As String = ""
			While sqlDataReader.Read()
				str = Conversions.ToString(Operators.AddObject(str, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(sqlDataReader("FAQSection"), ">"), sqlDataReader("Id")), ",")))
			End While
			strArrays = str.Split(New Char() { ","C })
			Dim num As Integer = 1
			Dim num1 As Integer = 0
			Dim num2 As Integer = 0
			Dim strArrays1 As String() = strArrays
			For i As Integer = 0 To CInt(strArrays1.Length) Step 1
				Dim str1 As String = strArrays1(i)
				If (num <> CInt(strArrays.Length)) Then
					If (num <> 1) Then
						Dim htmlGenericControl1 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.sectionsFaqs
						htmlGenericControl = htmlGenericControl1
						Dim innerHtml() As String = { htmlGenericControl.InnerHtml, "<li class=''><a href=#tab", num.ToString(), " data-toggle='tab'>", Nothing, Nothing }
						innerHtml(4) = str1.Split(New Char() { ">"C }).ToArray()(0)
						innerHtml(5) = "</a></li>"
						htmlGenericControl1.InnerHtml = String.Concat(innerHtml)
						Me.Session("SectionId") = str1.Split(New Char() { ">"C }).ToArray()(1)
						Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceLoadAnswers.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
						Dim htmlGenericControl2 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.tabContent
						htmlGenericControl = htmlGenericControl2
						Dim innerHtml1() As String = { htmlGenericControl.InnerHtml, "<div class='tab-pane' id=tab", num.ToString(), "><h4>", Nothing, Nothing, Nothing, Nothing }
						innerHtml1(4) = str1.Split(New Char() { ">"C }).ToArray()(0).ToString()
						innerHtml1(5) = "</h4><div id='accordionCollapse"
						innerHtml1(6) = num2.ToString()
						innerHtml1(7) = "' class='accordion in collapse' style='height: auto;'>"
						htmlGenericControl2.InnerHtml = String.Concat(innerHtml1)
						While sqlDataReader1.Read()
							Dim htmlGenericControl3 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.tabContent
							htmlGenericControl = htmlGenericControl3
							htmlGenericControl3.InnerHtml = String.Concat(New String() { htmlGenericControl.InnerHtml, "<div class='accordion-group'><div class='accordion-heading'><a href=#accordion", num1.ToString(), " data-parent='#accordionCollapse", num2.ToString(), "' data-toggle='collapse' class='accordion-toggle'> ", sqlDataReader1("Question").ToString(), "</a></div><div class='accordion-body collapse' id=accordion", num1.ToString(), "><div class='accordion-inner'>", sqlDataReader1("Answer").ToString(), "</div></div></div>" })
							num1 = num1 + 1
						End While
						num2 = num2 + 1
						Dim htmlGenericControl4 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.tabContent
						htmlGenericControl4.InnerHtml = String.Concat(htmlGenericControl4.InnerHtml, "</div></div>")
					Else
						Try
							Dim htmlGenericControl5 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.sectionsFaqs
							htmlGenericControl = htmlGenericControl5
							Dim array() As String = { htmlGenericControl.InnerHtml, "<li class='active'><a href=#tab", num.ToString(), " data-toggle='tab'>", Nothing, Nothing }
							array(4) = str1.Split(New Char() { ">"C }).ToArray()(0)
							array(5) = "</a></li>"
							htmlGenericControl5.InnerHtml = String.Concat(array)
							Me.Session("SectionId") = str1.Split(New Char() { ">"C }).ToArray()(1)
							Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceLoadAnswers.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
							Dim htmlGenericControl6 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.tabContent
							htmlGenericControl = htmlGenericControl6
							Dim innerHtml2() As String = { htmlGenericControl.InnerHtml, "<div class='tab-pane active' id=tab", num.ToString(), "><h4>", Nothing, Nothing, Nothing, Nothing }
							innerHtml2(4) = str1.Split(New Char() { ">"C }).ToArray()(0).ToString()
							innerHtml2(5) = "</h4><div id='accordionCollapse"
							innerHtml2(6) = num2.ToString()
							innerHtml2(7) = "' class='accordion in collapse' style='height: auto;'>"
							htmlGenericControl6.InnerHtml = String.Concat(innerHtml2)
							While sqlDataReader2.Read()
								Dim htmlGenericControl7 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.tabContent
								htmlGenericControl = htmlGenericControl7
								htmlGenericControl7.InnerHtml = String.Concat(New String() { htmlGenericControl.InnerHtml, "<div class='accordion-group'><div class='accordion-heading'><a href=#accordion", num1.ToString(), " data-parent='#accordionCollapse", num2.ToString(), "' data-toggle='collapse' class='accordion-toggle'> ", sqlDataReader2("Question").ToString(), "</a></div><div class='accordion-body collapse' id='accordion", num1.ToString(), "'><div class='accordion-inner'>", sqlDataReader2("Answer").ToString(), "</div></div></div>" })
								num1 = num1 + 1
							End While
							num2 = num2 + 1
							Dim htmlGenericControl8 As System.Web.UI.HtmlControls.HtmlGenericControl = Me.tabContent
							htmlGenericControl8.InnerHtml = String.Concat(htmlGenericControl8.InnerHtml, "</div></div>")
						Catch exception As System.Exception
							ProjectData.SetProjectError(exception)
							ProjectData.ClearProjectError()
						End Try
					End If
				End If
				num = num + 1
			Next

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
			If (Not MyBase.User.IsInRole("clientSupervisor")) Then
				Me.supervisorDiv.Visible = False
			Else
				Me.supervisorDiv.Visible = True
			End If
			Me.Faqs()
			Me.Alerts()
			Me.messages()
		End Sub
	End Class
End Namespace