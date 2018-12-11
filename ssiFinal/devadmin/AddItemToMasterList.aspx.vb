Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class AddItemToMasterList
		Inherits System.Web.UI.Page

        Private _SqlDataSourceAddItemToMasterList As SqlDataSource
        Private _ClearButton As Button
        Private _SaveButton As Button
        Protected Overridable Property BarCodeTextBox As TextBox

        Protected Overridable Property BoxNumberTextBox As TextBox

		Protected Overridable Property ClearButton As Button
			Get
				Return Me._ClearButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ClearButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ClearButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ClearButton = value
				button = Me._ClearButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DescriptionTextBox As TextBox

		Protected Overridable Property DestructionDateTextBox As TextBox

		Protected Overridable Property DropDownListCompanyCode As DropDownList

		Protected Overridable Property DropDownListDepartmentCode As DropDownList

		Protected Overridable Property LocationCodeTextBox As TextBox

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property QRCodeTextBox As TextBox

		Protected Overridable Property SaveButton As Button
			Get
				Return Me._SaveButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.SaveButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._SaveButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._SaveButton = value
				button = Me._SaveButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceAddItemToMasterList As SqlDataSource
			Get
				Return Me._SqlDataSourceAddItemToMasterList
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceAddItemToMasterList_Inserted)
				Dim sqlDataSourceCommandEventHandler As System.Web.UI.WebControls.SqlDataSourceCommandEventHandler = New System.Web.UI.WebControls.SqlDataSourceCommandEventHandler(AddressOf Me.SqlDataSourceAddItemToMasterList_Inserting)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceAddItemToMasterList
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
					RemoveHandler sqlDataSource.Inserting,  sqlDataSourceCommandEventHandler
				End If
				Me._SqlDataSourceAddItemToMasterList = value
				sqlDataSource = Me._SqlDataSourceAddItemToMasterList
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
					AddHandler sqlDataSource.Inserting,  sqlDataSourceCommandEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceGetBarcode As SqlDataSource

		Protected Overridable Property SqlDataSourceGetBay As SqlDataSource

		Protected Overridable Property SqlDataSourceGetCompany As SqlDataSource

		Protected Overridable Property SqlDataSourceGetDepartment As SqlDataSource

		Protected Overridable Property SqlDataSourceGetLevel As SqlDataSource

		Protected Overridable Property SqlDataSourceGetRack As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property StatusList As DropDownList

		Protected Overridable Property StockReceiptIdTextBox As TextBox

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

		Protected Sub ClearButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.DropDownListCompanyCode.SelectedIndex = 0
			Me.DropDownListDepartmentCode.SelectedIndex = 0
			Me.BarCodeTextBox.Text = ""
			Me.QRCodeTextBox.Text = ""
			Me.BoxNumberTextBox.Text = ""
			Me.DescriptionTextBox.Text = ""
			Me.StatusList.SelectedIndex = 0
			Me.LocationCodeTextBox.Text = ""
			Me.DestructionDateTextBox.Text = ""
			Me.StockReceiptIdTextBox.Text = ""
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

		Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("CompanyCode").DefaultValue = Me.DropDownListCompanyCode.SelectedValue.ToString()
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("Department").DefaultValue = Me.DropDownListDepartmentCode.SelectedValue.ToString()
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("BarCode").DefaultValue = Me.BarCodeTextBox.Text
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("BoxNumber").DefaultValue = Me.BoxNumberTextBox.Text
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("Description").DefaultValue = Me.DescriptionTextBox.Text
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("Status").DefaultValue = Me.StatusList.SelectedItem.Text
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("LocationCode").DefaultValue = Me.LocationCodeTextBox.Text
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("DestructionDate").DefaultValue = Me.DestructionDateTextBox.Text
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("StockReceipt_id").DefaultValue = Me.StockReceiptIdTextBox.Text
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("QRCode").DefaultValue = Me.QRCodeTextBox.Text
			Me.SqlDataSourceAddItemToMasterList.InsertParameters("CreatedBy").DefaultValue = MyBase.User.Identity.GetUserName()
			Dim item As Parameter = Me.SqlDataSourceAddItemToMasterList.InsertParameters("CreatedDate")
			Dim utcNow As DateTime = DateTime.UtcNow
			item.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
			Me.SqlDataSourceAddItemToMasterList.Insert()
		End Sub

		Private Sub SqlDataSourceAddItemToMasterList_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Dim empty As String = String.Empty
			empty = "New item added to the Master List."
			MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
			Me.DropDownListCompanyCode.SelectedIndex = 0
			Me.DropDownListDepartmentCode.SelectedIndex = 0
			Me.BarCodeTextBox.Text = ""
			Me.QRCodeTextBox.Text = ""
			Me.BoxNumberTextBox.Text = ""
			Me.DescriptionTextBox.Text = ""
			Me.StatusList.SelectedIndex = 0
			Me.LocationCodeTextBox.Text = ""
			Me.DestructionDateTextBox.Text = ""
			Me.StockReceiptIdTextBox.Text = ""
		End Sub

		Private Sub SqlDataSourceAddItemToMasterList_Inserting(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)
			If (Not (Operators.CompareString(Me.BarCodeTextBox.Text, "", False) <> 0 And Operators.CompareString(Me.QRCodeTextBox.Text, "", False) <> 0)) Then
				Dim empty As String = String.Empty
				empty = "Barcode and QR code is required. Please try again."
				MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty, "');"), True)
				e.Cancel = True
			Else
				Me.Session("BarCode") = Me.BarCodeTextBox.Text
				Me.Session("QRCode") = Me.QRCodeTextBox.Text
				If (DirectCast(Me.SqlDataSourceGetBarcode.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader).Read()) Then
					Dim str As String = String.Empty
					str = "Insert Cancelled. Barcode and/or QRCode already exist. Please try again."
					MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), str, "');"), True)
					e.Cancel = True
					Return
				End If
				Dim text As String = Me.LocationCodeTextBox.Text
				If (Operators.CompareString(text, "", False) <> 0) Then
					Dim strArrays As String() = Regex.Split(text, ":")
					Me.Session("RackCode") = strArrays(0).ToString()
					Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetRack.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
					If (Not sqlDataReader.Read()) Then
						Dim empty1 As String = String.Empty
						empty1 = "Insert Cancelled. Location does not exist. Please try again."
						MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty1, "');"), True)
						e.Cancel = True
						Return
					End If
					Dim str1 As String = Conversions.ToString(sqlDataReader("RackCode"))
					If (Operators.CompareString(strArrays(0).ToString(), str1, False) <> 0) Then
						Dim empty2 As String = String.Empty
						empty2 = "Insert Cancelled. Location does not exist. Please try again."
						MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty2, "');"), True)
						e.Cancel = True
						Return
					End If
					Me.Session("RackCode") = strArrays(0).ToString()
					Me.Session("BayCode") = strArrays(1).ToString()
					Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetBay.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
					If (Not sqlDataReader1.Read()) Then
						Dim str2 As String = String.Empty
						str2 = "Insert Cancelled. Location does not exist. Please try again."
						MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), str2, "');"), True)
						e.Cancel = True
						Return
					End If
					Dim str3 As String = Conversions.ToString(sqlDataReader1("BayCode"))
					If (Operators.CompareString(strArrays(1).ToString(), str3, False) <> 0) Then
						Dim empty3 As String = String.Empty
						empty3 = "Insert Cancelled. Location does not exist. Please try again."
						MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty3, "');"), True)
						e.Cancel = True
						Return
					End If
					Me.Session("RackCode") = strArrays(0).ToString()
					Me.Session("LevelNumber") = strArrays(2).ToString()
					Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetLevel.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
					If (Not sqlDataReader2.Read()) Then
						Dim empty4 As String = String.Empty
						empty4 = "Insert Cancelled. Location does not exist. Please try again."
						MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty4, "');"), True)
						e.Cancel = True
						Return
					End If
					Dim str4 As String = Conversions.ToString(sqlDataReader2("LevelNumber"))
					If (Operators.CompareString(strArrays(2).ToString(), str4, False) <> 0) Then
						Dim empty5 As String = String.Empty
						empty5 = "Insert Cancelled. Location does not exist. Please try again."
						MyBase.ClientScript.RegisterStartupScript(MyBase.[GetType](), "myalert", String.Concat(Convert.ToString("alert('"), empty5, "');"), True)
						Return
					End If
				End If
			End If
		End Sub
	End Class
End Namespace