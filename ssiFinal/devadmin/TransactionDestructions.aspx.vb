Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class TransactionDestructions
		Inherits System.Web.UI.Page
		Public errMsg As String

		Protected _isEditMode As Boolean
        Private _SqlDataSourceUpdateMasterListDestruction As SqlDataSource
        Private _SqlDataSourceDestructionItems As SqlDataSource
        Private _SearchButton As Button
        Private _SaveBtn As Button
        Private _RefreshButton As Button
        Private _CancelBtn As Button
        Private _AcceptButton As Button
        Private _ButtonPickList As Button
        Private _ButtonSearch As Button
        Private _ButtonRefresh As Button
        Private _EditBtn As Button
        Private _GridViewDestruction As GridView
        Private _GridViewDestructionItems As GridView

        Protected Overridable Property AcceptButton As Button
            Get
                Return Me._AcceptButton
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.AcceptButton_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._AcceptButton
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._AcceptButton = value
                button = Me._AcceptButton
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property ButtonPickList As Button
			Get
				Return Me._ButtonPickList
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonPickList_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonPickList
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonPickList = value
				button = Me._ButtonPickList
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ButtonRefresh As Button
			Get
				Return Me._ButtonRefresh
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonRefresh_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonRefresh
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonRefresh = value
				button = Me._ButtonRefresh
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ButtonSearch As Button
			Get
				Return Me._ButtonSearch
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonSearch_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonSearch
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonSearch = value
				button = Me._ButtonSearch
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property CancelBtn As Button
			Get
				Return Me._CancelBtn
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.CancelBtn_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._CancelBtn
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._CancelBtn = value
				button = Me._CancelBtn
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DetailsView1 As DetailsView

		Protected Overridable Property DropDownListSearch As DropDownList

		Protected Overridable Property EditBtn As Button
			Get
				Return Me._EditBtn
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.EditBtn_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._EditBtn
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._EditBtn = value
				button = Me._EditBtn
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewDestruction As GridView
			Get
				Return Me._GridViewDestruction
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.GridViewDestruction_SelectedIndexChanged)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewDestruction
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.SelectedIndexChanged,  eventHandler
				End If
				Me._GridViewDestruction = value
				gridView = Me._GridViewDestruction
				If (gridView IsNot Nothing) Then
					AddHandler gridView.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewDestructionItems As GridView
			Get
				Return Me._GridViewDestructionItems
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewCancelEditEventHandler As System.Web.UI.WebControls.GridViewCancelEditEventHandler = New System.Web.UI.WebControls.GridViewCancelEditEventHandler(AddressOf Me.GridViewDestructionItems_RowCancelingEdit)
				Dim gridViewEditEventHandler As System.Web.UI.WebControls.GridViewEditEventHandler = New System.Web.UI.WebControls.GridViewEditEventHandler(AddressOf Me.GridViewDestructionItems_RowEditing)
				Dim gridViewUpdatedEventHandler As System.Web.UI.WebControls.GridViewUpdatedEventHandler = New System.Web.UI.WebControls.GridViewUpdatedEventHandler(AddressOf Me.GridViewDestructionItems_RowUpdated)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewDestructionItems
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowCancelingEdit,  gridViewCancelEditEventHandler
					RemoveHandler gridView.RowEditing,  gridViewEditEventHandler
					RemoveHandler gridView.RowUpdated,  gridViewUpdatedEventHandler
				End If
				Me._GridViewDestructionItems = value
				gridView = Me._GridViewDestructionItems
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowCancelingEdit,  gridViewCancelEditEventHandler
					AddHandler gridView.RowEditing,  gridViewEditEventHandler
					AddHandler gridView.RowUpdated,  gridViewUpdatedEventHandler
				End If
			End Set
		End Property

		Protected Property IsInEditMode As Boolean
			Get
				Return Me._isEditMode
			End Get
			Set(ByVal value As Boolean)
				Me._isEditMode = value
			End Set
		End Property

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property RefreshButton As Button
			Get
				Return Me._RefreshButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.RefreshButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._RefreshButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._RefreshButton = value
				button = Me._RefreshButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SaveBtn As Button
			Get
				Return Me._SaveBtn
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.SaveBtn_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._SaveBtn
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._SaveBtn = value
				button = Me._SaveBtn
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SearchButton As Button
			Get
				Return Me._SearchButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.SearchButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._SearchButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._SearchButton = value
				button = Me._SearchButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SearchDropDownList As DropDownList

		Protected Overridable Property SearchTextbox As TextBox

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceDestructionDetails As SqlDataSource

		Protected Overridable Property SqlDataSourceDestructionGrid As SqlDataSource

		Protected Overridable Property SqlDataSourceDestructionItems As SqlDataSource
			Get
				Return Me._SqlDataSourceDestructionItems
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceDestructionItems_Deleted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceDestructionItems
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Deleted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceDestructionItems = value
				sqlDataSource = Me._SqlDataSourceDestructionItems
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Deleted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceGetId As SqlDataSource

		Protected Overridable Property SqlDataSourceHistory As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceReadMasterList As SqlDataSource

		Protected Overridable Property SqlDataSourceUpdateDestructionItems As SqlDataSource

		Protected Overridable Property SqlDataSourceUpdateMasterListDestruction As SqlDataSource
			Get
				Return Me._SqlDataSourceUpdateMasterListDestruction
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceUpdateMasterListDestruction_Updated)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceUpdateMasterListDestruction
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Updated,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceUpdateMasterListDestruction = value
				sqlDataSource = Me._SqlDataSourceUpdateMasterListDestruction
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Updated,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceUpdateTransactionDestruction As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TextBoxSearch As TextBox

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me._isEditMode = False
		End Sub

		Protected Sub AcceptButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim utcNow As DateTime
			Try
				Try
					enumerator = Me.GridViewDestructionItems.Rows.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
						If (current.RowType <> DataControlRowType.DataRow OrElse Not TryCast(current.Cells(0).FindControl("ValidationCheckBox"), CheckBox).Checked) Then
							Continue While
						End If
						Me.SqlDataSourceUpdateDestructionItems.UpdateParameters("Id").DefaultValue = current.Cells(2).Text
						Dim item As System.Web.UI.WebControls.Parameter = Me.SqlDataSourceUpdateDestructionItems.UpdateParameters("ModifiedDate")
						utcNow = DateTime.UtcNow
						item.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
						Me.SqlDataSourceUpdateDestructionItems.UpdateParameters("ModifiedBy").DefaultValue = MyBase.User.Identity.GetUserName()
						Me.Session("_Barcode") = current.Cells(3).Text
						Me.SqlDataSourceUpdateDestructionItems.Update()
						Me.SqlDataSourceUpdateMasterListDestruction.UpdateParameters("Id").DefaultValue = current.Cells(11).Text
						Dim str As System.Web.UI.WebControls.Parameter = Me.SqlDataSourceUpdateMasterListDestruction.UpdateParameters("ModifiedDate")
						utcNow = DateTime.UtcNow
						str.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
						Me.SqlDataSourceUpdateMasterListDestruction.UpdateParameters("ModifiedBy").DefaultValue = MyBase.User.Identity.GetUserName()
						Me.SqlDataSourceUpdateMasterListDestruction.UpdateParameters("LocationCode").DefaultValue = ""
						Me.SqlDataSourceUpdateMasterListDestruction.Update()
					End While
				Finally
					If (TypeOf enumerator Is IDisposable) Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.SqlDataSourceUpdateTransactionDestruction.UpdateParameters("Alerts").DefaultValue = "2"
				Me.SqlDataSourceUpdateTransactionDestruction.UpdateParameters("Status").DefaultValue = "PROCESSED"
				Dim parameter As System.Web.UI.WebControls.Parameter = Me.SqlDataSourceUpdateTransactionDestruction.UpdateParameters("ModifiedDate")
				utcNow = DateTime.UtcNow
				parameter.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
				Me.SqlDataSourceUpdateTransactionDestruction.UpdateParameters("ModifiedBy").DefaultValue = MyBase.User.Identity.GetUserName()
				Me.SqlDataSourceUpdateTransactionDestruction.UpdateParameters("Id").DefaultValue = Convert.ToString(Me.DetailsView1.Rows(0).Cells(1).Text)
				Me.SqlDataSourceUpdateTransactionDestruction.Update()
				MyBase.Response.Redirect(String.Concat("ProcessedDestructionTransactions?ID=", Me.GridViewDestruction.SelectedRow.Cells(1).Text))
				MyBase.Response.Redirect("SuccessPage?SuccessMessage=Item/s has been successfully destroyed.&Type=Destruction")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
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

		Protected Sub ButtonPickList_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim enumerator1 As IEnumerator = Nothing
			If (Me.GridViewDestructionItems.Rows.Count = 0) Then
				Me.renderErrMsgs("Please select a transaction below.")
				Return
			End If
			Try
				Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(PageSize.A4, 50!, 50!, 100!, 100!)
				Dim random As System.Random = New System.Random()
				Dim str As String = String.Concat("Picklist_", Conversions.ToString(random.[Next](0, 1000000)), ".pdf")
				Dim fileStream As System.IO.FileStream = New System.IO.FileStream(MyBase.Server.MapPath(String.Concat("PDF/", str)), FileMode.Create)
				Dim generatePickList As ssiFinal.GeneratePickList = New ssiFinal.GeneratePickList()
				Dim instance As PdfWriter = PdfWriter.GetInstance(document, fileStream)
				instance.PageEvent = generatePickList
				document.Open()
				Dim pdfPTable As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
				{
					.HorizontalAlignment = 1,
					.TotalWidth = 500!
				}
				Dim num As Integer = 0
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Department", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("BarCode", FontFactory.GetFont("Calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Location Code", FontFactory.GetFont("calibri", 10!, 1)))
				Dim pdfPTable1 As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1) With
				{
					.TotalWidth = document.PageSize.Width
				}
				Dim phrase As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
				Dim phrase1 As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
				Dim pdfPCell As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase)
				Dim pdfPCell1 As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase1)
				Dim num1 As Integer = 0
				Dim num2 As Integer = 1
				Try
					enumerator = Me.GridViewDestructionItems.Rows.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As System.Web.UI.WebControls.GridViewRow = DirectCast(enumerator.Current, System.Web.UI.WebControls.GridViewRow)
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(current.FindControl("DepartmentLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(current.FindControl("BarCodeLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(current.FindControl("BoxNumberLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(current.FindControl("DescriptionLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("", FontFactory.GetFont("Calibri", 8!, 0)))
						If (pdfPTable.TotalHeight < 350!) Then
							Continue While
						End If
						num1 = num1 + 1
						pdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
						{
							.HorizontalAlignment = 1,
							.TotalWidth = 500!
						}
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Department", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("BarCode", FontFactory.GetFont("Calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Location Code", FontFactory.GetFont("calibri", 10!, 1)))
					End While
				Finally
					If (TypeOf enumerator Is IDisposable) Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				If (pdfPTable.Rows.Count <> 0) Then
					num1 = num1 + 1
				End If
				document.Close()
				document = New iTextSharp.text.Document(PageSize.A4, 50!, 50!, 100!, 100!)
				random = New System.Random()
				str = String.Concat("Picklist_", Conversions.ToString(random.[Next](0, 1000000)), ".pdf")
				fileStream = New System.IO.FileStream(MyBase.Server.MapPath(String.Concat("PDF/", str)), FileMode.Create)
				generatePickList = New ssiFinal.GeneratePickList()
				instance = PdfWriter.GetInstance(document, fileStream)
				instance.PageEvent = generatePickList
				document.Open()
				pdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
				{
					.HorizontalAlignment = 1,
					.TotalWidth = 500!
				}
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Department", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("BarCode", FontFactory.GetFont("Calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Location Code", FontFactory.GetFont("calibri", 10!, 1)))
				Try
					enumerator1 = Me.GridViewDestructionItems.Rows.GetEnumerator()
					While enumerator1.MoveNext()
						Dim gridViewRow As System.Web.UI.WebControls.GridViewRow = DirectCast(enumerator1.Current, System.Web.UI.WebControls.GridViewRow)
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("DepartmentLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("BarCodeLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("BoxNumberLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("DescriptionLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("", FontFactory.GetFont("Calibri", 8!, 0)))
						num = num + 1
						If (pdfPTable.TotalHeight < 350!) Then
							Continue While
						End If
						pdfPTable.WriteSelectedRows(0, -1, 45!, document.PageSize.Height - 300!, instance.DirectContent)
						pdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
						{
							.HorizontalAlignment = 1,
							.LockedWidth = True,
							.TotalWidth = 500!
						}
						num = 0
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Department", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("BarCode", FontFactory.GetFont("Calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Location Code", FontFactory.GetFont("calibri", 10!, 1)))
						Dim pdfPTable2 As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1) With
						{
							.TotalWidth = document.PageSize.Width
						}
						phrase = New iTextSharp.text.Phrase()
						phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Page: ", Conversions.ToString(num2), "/", Conversions.ToString(num1)), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Document No: ", Me.DetailsView1.Rows(0).Cells(1).Text, "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase.Add(New Chunk(String.Concat("Total No. of Boxes: ", Conversions.ToString(Me.GridViewDestructionItems.Rows.Count), "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase1 = New iTextSharp.text.Phrase()
						phrase1.Add(New Chunk(String.Concat("" & VbCrLf & "" & VbCrLf & "Date Picked: ", Me.DetailsView1.Rows(5).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
						phrase1.Add(New Chunk(String.Concat("Customer: ", Me.DetailsView1.Rows(19).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
						phrase1.Add(New Chunk(String.Concat("Contact Name: ", Me.DetailsView1.Rows(1).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
						pdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase)
						pdfPCell1 = New iTextSharp.text.pdf.PdfPCell(phrase1)
						pdfPCell.PaddingLeft = 350!
						pdfPCell1.PaddingLeft = 50!
						pdfPCell.Border = 0
						pdfPCell1.Border = 0
						pdfPTable2.AddCell(pdfPCell)
						pdfPTable2.AddCell(pdfPCell1)
						pdfPTable2.WriteSelectedRows(0, -1, 0!, document.PageSize.Height - 110!, instance.DirectContent)
						If (num2 <> num1) Then
							document.NewPage()
						End If
						num2 = num2 + 1
					End While
				Finally
					If (TypeOf enumerator1 Is IDisposable) Then
						TryCast(enumerator1, IDisposable).Dispose()
					End If
				End Try
				If (num2 <= num1) Then
					Dim pdfPTable3 As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1) With
					{
						.TotalWidth = document.PageSize.Width
					}
					phrase = New iTextSharp.text.Phrase()
					phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Page: ", Conversions.ToString(num2), "/", Conversions.ToString(num1)), FontFactory.GetFont("Calibri", 10!, 0)))
					phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Document No: ", Me.DetailsView1.Rows(0).Cells(1).Text, "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
					phrase.Add(New Chunk(String.Concat("Total No. of Boxes: ", Conversions.ToString(Me.GridViewDestructionItems.Rows.Count), "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
					phrase1 = New iTextSharp.text.Phrase()
					phrase1.Add(New Chunk(String.Concat("" & VbCrLf & "" & VbCrLf & "Date Picked: ", Me.DetailsView1.Rows(5).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
					phrase1.Add(New Chunk(String.Concat("Customer: ", Me.DetailsView1.Rows(19).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
					phrase1.Add(New Chunk(String.Concat("Contact Name: ", Me.DetailsView1.Rows(1).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
					pdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase)
					pdfPCell1 = New iTextSharp.text.pdf.PdfPCell(phrase1)
					pdfPCell.PaddingLeft = 350!
					pdfPCell1.PaddingLeft = 50!
					pdfPCell.Border = 0
					pdfPCell1.Border = 0
					pdfPTable3.AddCell(pdfPCell)
					pdfPTable3.AddCell(pdfPCell1)
					pdfPTable3.WriteSelectedRows(0, -1, 0!, document.PageSize.Height - 110!, instance.DirectContent)
					pdfPTable.WriteSelectedRows(0, -1, 45!, document.PageSize.Height - 300!, instance.DirectContent)
				End If
				document.Close()
				MyBase.Response.ContentType = "application/pdf"
				MyBase.Response.AppendHeader("Content-Disposition", "attachment; filename=PickList.pdf")
				MyBase.Response.TransmitFile(MyBase.Server.MapPath(String.Concat("PDF/", str)))
				MyBase.Response.[End]()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ButtonRefresh_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.GridViewDestructionItems.DataBind()
				Me.TextBoxSearch.Text = ""
				Me.DropDownListSearch.SelectedIndex = 0
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.DropDownListSearch.SelectedIndex = 0) Then
					Me.SqlDataSourceDestructionItems.FilterExpression = String.Concat("BarCode LIKE '%", Me.TextBoxSearch.Text.Trim(), "%'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 1) Then
					Me.SqlDataSourceDestructionItems.FilterExpression = String.Concat("Description LIKE '%", Me.TextBoxSearch.Text.Trim(), "%'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 2) Then
					Me.SqlDataSourceDestructionItems.FilterExpression = String.Concat("BoxNumber = '", Me.TextBoxSearch.Text.Trim(), "'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 3) Then
					Me.SqlDataSourceDestructionItems.FilterExpression = String.Concat("Department = '", Me.TextBoxSearch.Text.Trim(), "'")
				End If
				Me.SqlDataSourceDestructionItems.[Select](DataSourceSelectArguments.Empty)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub CancelBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.SqlDataSourceDestructionItems.Delete()
		End Sub

		Protected Sub chkboxSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim checkBox As System.Web.UI.WebControls.CheckBox = DirectCast(Me.GridViewDestructionItems.HeaderRow.FindControl("chkboxSelectAll"), System.Web.UI.WebControls.CheckBox)
			Try
				enumerator = Me.GridViewDestructionItems.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim checkBox1 As System.Web.UI.WebControls.CheckBox = DirectCast(DirectCast(enumerator.Current, GridViewRow).FindControl("ValidationCheckBox"), System.Web.UI.WebControls.CheckBox)
					If (Not checkBox.Checked) Then
						checkBox1.Checked = False
					Else
						checkBox1.Checked = True
					End If
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
		End Sub

		Protected Sub EditBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Not Me._isEditMode) Then
				Me._isEditMode = True
				Me.DataBind()
				Me.EditBtn.Enabled = False
				Me.SaveBtn.Enabled = True
			End If
		End Sub

		Private Sub GridViewDestruction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("DestructionID") = Me.GridViewDestruction.SelectedRow.Cells(1).Text
			Me.DetailsView1.DataBind()
			Me.SaveBtn.Enabled = False
			Me.EditBtn.Enabled = True
		End Sub

		Private Sub GridViewDestructionItems_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
			Me.AcceptButton.Enabled = True
		End Sub

		Private Sub GridViewDestructionItems_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
			Me.AcceptButton.Enabled = False
		End Sub

		Private Sub GridViewDestructionItems_RowUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)
			Me.AcceptButton.Enabled = True
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
				If (Operators.CompareString(MyBase.Request("Notif"), "true", False) = 0) Then
					Me.Session("Type") = "DESTRUCTION"
					Me.SqlDataSourceAlerts.Update()
					Me.Session.Remove("Notif")
					MyBase.Response.Redirect("TransactionDestructions")
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.GridViewDestruction.DataBind()
				Me.SearchTextbox.Text = ""
				Me.SearchDropDownList.SelectedIndex = 0
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Sub renderErrMsgs(ByVal thisErrMsg As String)
			' 
			' Current member / type: System.Void ssiFinal.TransactionDestructions::renderErrMsgs(System.String)
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void renderErrMsgs(System.String)
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

		Protected Sub SaveBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				enumerator = Me.GridViewDestructionItems.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
					Me.GridViewDestructionItems.UpdateRow(current.RowIndex, False)
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me._isEditMode = False
			Me.EditBtn.Text = "Edit Mode"
			Me.SaveBtn.Enabled = False
			Me.EditBtn.Enabled = True
		End Sub

		Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.SearchDropDownList.SelectedIndex = 0) Then
					Me.SqlDataSourceDestructionGrid.FilterExpression = String.Concat("DepartmentCode LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 1) Then
					Me.SqlDataSourceDestructionGrid.FilterExpression = String.Concat("ContactName LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 2) Then
					Me.SqlDataSourceDestructionGrid.FilterExpression = String.Concat("Id = '", Me.SearchTextbox.Text.Trim(), "'")
				End If
				Me.SqlDataSourceDestructionGrid.[Select](DataSourceSelectArguments.Empty)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub SqlDataSourceDestructionItems_Deleted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.SqlDataSourceDestructionGrid.Delete()
			MyBase.Response.Redirect("~/devadmin/TransactionDestructions.aspx", False)
		End Sub

		Private Sub SqlDataSourceUpdateMasterListDestruction_Updated(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Try
				Me.Session("HistoryMasterListId") = RuntimeHelpers.GetObjectValue(e.Command.Parameters("@Id").Value)
				Me.Session("HistoryDesc") = "DESTRUCTION"
				Me.Session("HistoryCreatedBy") = MyBase.User.Identity.Name
				Dim session As HttpSessionState = Me.Session
				Dim dateTime As System.DateTime = System.DateTime.UtcNow.AddHours(8)
				session("HistoryCreatedDate") = dateTime.ToShortDateString()
				Me.SqlDataSourceHistory.Insert()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub
	End Class
End Namespace