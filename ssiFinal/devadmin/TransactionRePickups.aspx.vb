Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports ZXing

Namespace ssiFinal
	Public Class TransactionRePickups
		Inherits System.Web.UI.Page
		Public nl As List(Of TransactionRePickups.ssiItem)

		Private barCodeDocument As Document

		Public errMsg As String

		Protected _isEditMode As Boolean
        Private _UploadQrButton As Button
        Private _UploadButton As Button
        Private _ButtonPackingList As Button
        Private _CancelBtn As Button
        Private _TransactionPickupDetailsView As DetailsView
        Private _TransactionPickupItemsGridView As GridView
        Private _SqlDataSourceTransactionPickupItems As SqlDataSource
        Private _EditBtn As Button
        Private _SearchButton As Button
        Private _ReceiveSqlDataSource As SqlDataSource
        Private _ButtonSearch As Button
        Private _ReceiveButton As Button
        Private _RefreshButton As Button
        Private _SaveBtn As Button
        Private _ButtonBarCodePdf As Button
        Private _ButtonRefresh As Button
        Private _ButtonBarCode As Button

        Protected Overridable Property ButtonBarCode As Button
            Get
                Return Me._ButtonBarCode
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonBarCode_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._ButtonBarCode
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._ButtonBarCode = value
                button = Me._ButtonBarCode
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property ButtonBarCodePdf As Button
			Get
				Return Me._ButtonBarCodePdf
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonBarCodePdf_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonBarCodePdf
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonBarCodePdf = value
				button = Me._ButtonBarCodePdf
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ButtonPackingList As Button
			Get
				Return Me._ButtonPackingList
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonPackingList_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonPackingList
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonPackingList = value
				button = Me._ButtonPackingList
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

		Protected Overridable Property FileUpload1 As FileUpload

		Protected Overridable Property FileUpload2 As FileUpload

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

		Protected Overridable Property ReceiveButton As Button
			Get
				Return Me._ReceiveButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ReceiveButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ReceiveButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ReceiveButton = value
				button = Me._ReceiveButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ReceiveSqlDataSource As SqlDataSource
			Get
				Return Me._ReceiveSqlDataSource
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.ReceiveSqlDataSource_Updated)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._ReceiveSqlDataSource
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Updated,  sqlDataSourceStatusEventHandler
				End If
				Me._ReceiveSqlDataSource = value
				sqlDataSource = Me._ReceiveSqlDataSource
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Updated,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

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

		Protected Overridable Property SqlDataSourceDonwloadBarCode As SqlDataSource

		Protected Overridable Property SqlDataSourceGetId As SqlDataSource

		Protected Overridable Property SqlDataSourceHistory As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceReadUserDetails As SqlDataSource

		Protected Overridable Property SqlDataSourceTransactionPickupGrid As SqlDataSource

		Protected Overridable Property SqlDataSourceTransactionPickupItems As SqlDataSource
			Get
				Return Me._SqlDataSourceTransactionPickupItems
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceTransactionPickupItems_Deleted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceTransactionPickupItems
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Deleted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceTransactionPickupItems = value
				sqlDataSource = Me._SqlDataSourceTransactionPickupItems
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Deleted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceTransactionRepickupDetails As SqlDataSource

		Protected Overridable Property SqlDataSourceUpdatePickupItems As SqlDataSource

		Protected Overridable Property SqlDataSourceUpdateTransactionPickup As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TextBoxSearch As TextBox

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Protected Overridable Property TransactionPickupDetailsView As DetailsView
			Get
				Return Me._TransactionPickupDetailsView
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.DetailsView)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.TransactionPickupDetailsView_DataBound)
				Dim detailsView As System.Web.UI.WebControls.DetailsView = Me._TransactionPickupDetailsView
				If (detailsView IsNot Nothing) Then
					RemoveHandler detailsView.DataBound,  eventHandler
				End If
				Me._TransactionPickupDetailsView = value
				detailsView = Me._TransactionPickupDetailsView
				If (detailsView IsNot Nothing) Then
					AddHandler detailsView.DataBound,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property TransactionPickupItemsGridView As GridView
			Get
				Return Me._TransactionPickupItemsGridView
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewCancelEditEventHandler As System.Web.UI.WebControls.GridViewCancelEditEventHandler = New System.Web.UI.WebControls.GridViewCancelEditEventHandler(AddressOf Me.TransactionPickupItemsGridView_RowCancelingEdit)
				Dim gridViewEditEventHandler As System.Web.UI.WebControls.GridViewEditEventHandler = New System.Web.UI.WebControls.GridViewEditEventHandler(AddressOf Me.TransactionPickupItemsGridView_RowEditing)
				Dim gridViewUpdatedEventHandler As System.Web.UI.WebControls.GridViewUpdatedEventHandler = New System.Web.UI.WebControls.GridViewUpdatedEventHandler(AddressOf Me.TransactionPickupItemsGridView_RowUpdated)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.TransactionPickupItemsGridView_SelectedIndexChanged)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._TransactionPickupItemsGridView
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowCancelingEdit,  gridViewCancelEditEventHandler
					RemoveHandler gridView.RowEditing,  gridViewEditEventHandler
					RemoveHandler gridView.RowUpdated,  gridViewUpdatedEventHandler
					RemoveHandler gridView.SelectedIndexChanged,  eventHandler
				End If
				Me._TransactionPickupItemsGridView = value
				gridView = Me._TransactionPickupItemsGridView
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowCancelingEdit,  gridViewCancelEditEventHandler
					AddHandler gridView.RowEditing,  gridViewEditEventHandler
					AddHandler gridView.RowUpdated,  gridViewUpdatedEventHandler
					AddHandler gridView.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property TransactionPickupsGridView As GridView

		Protected Overridable Property UploadButton As Button
			Get
				Return Me._UploadButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.UploadButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._UploadButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._UploadButton = value
				button = Me._UploadButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property UploadQrButton As Button
			Get
				Return Me._UploadQrButton
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.UploadQrButton_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._UploadQrButton
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._UploadQrButton = value
				button = Me._UploadQrButton
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me.barCodeDocument = New Document(PageSize.A7.Rotate(), 10!, 10!, 50!, 0!)
			Me._isEditMode = False
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

		Protected Sub ButtonBarCode_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				Try
					Using streamWriter As System.IO.StreamWriter = File.CreateText(String.Concat(MyBase.Server.MapPath("CSV"), "/BarCode.txt"))
						Try
							enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
							While enumerator.MoveNext()
								Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
								streamWriter.WriteLine(HttpUtility.HtmlDecode(DirectCast(current.FindControl("BarCodeLbl"), Label).Text))
							End While
						Finally
							If (TypeOf enumerator Is IDisposable) Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					End Using
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					ProjectData.ClearProjectError()
				End Try
			Finally
				MyBase.Response.ContentType = "text/plain"
				MyBase.Response.AppendHeader("Content-Disposition", "attachment; filename=BarCode.txt")
				MyBase.Response.WriteFile("CSV/BarCode.txt")
				MyBase.Response.[End]()
			End Try
		End Sub

		Protected Sub ButtonBarCodePdf_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			FontFactory.GetFont("Arial", 12!, 0, BaseColor.BLACK)
			Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
				Dim instance As PdfWriter = PdfWriter.GetInstance(Me.barCodeDocument, memoryStream)
				Dim pdfPCell As iTextSharp.text.pdf.PdfPCell = Nothing
				Dim pdfPTable As iTextSharp.text.pdf.PdfPTable = Nothing
				Me.barCodeDocument.Open()
				Dim directContent As PdfContentByte = instance.DirectContent
				Try
					enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As TableRow = DirectCast(enumerator.Current, TableRow)
						pdfPTable = New iTextSharp.text.pdf.PdfPTable(1) With
						{
							.TotalWidth = 200!,
							.LockedWidth = True
						}
						pdfPCell = New iTextSharp.text.pdf.PdfPCell()
						Dim phrase As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
						phrase.Add(New Chunk("SSI Storage Solutions Incorporated", FontFactory.GetFont("Arial", 10!, 1, BaseColor.BLACK)))
						pdfPCell = TransactionRePickups.PhraseCell(phrase, 8)
						pdfPTable.AddCell(pdfPCell)
						pdfPCell = New iTextSharp.text.pdf.PdfPCell() With
						{
							.BorderColor = BaseColor.WHITE
						}
						Dim barcode128 As iTextSharp.text.pdf.Barcode128 = New iTextSharp.text.pdf.Barcode128() With
						{
							.X = 1!,
							.N = 10!,
							.BarHeight = 60!,
							.ChecksumText = True,
							.GenerateChecksum = True,
							.StartStopText = True,
							.Code = DirectCast(current.FindControl("BarCodeLbl"), Label).Text
						}
						Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(New Bitmap(barcode128.CreateDrawingImage(Color.Black, Color.White)), ImageFormat.Bmp)
						pdfPCell.AddElement(image)
						pdfPTable.AddCell(pdfPCell)
						Dim phrase1 As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
						phrase1.Add(New Chunk(DirectCast(current.FindControl("BarCodeLbl"), Label).Text, FontFactory.GetFont("Arial", 10!, 1, BaseColor.BLACK)))
						pdfPCell = TransactionRePickups.PhraseCell(phrase1, 8)
						pdfPTable.AddCell(pdfPCell)
						Dim phrase2 As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
						phrase2.Add(New Chunk(String.Concat("Box No: ", DirectCast(current.Cells(7).FindControl("BoxNumberLbl"), Label).Text, "" & VbCrLf & ""), FontFactory.GetFont("Arial", 8!, 1, BaseColor.BLACK)))
						pdfPCell = TransactionRePickups.PhraseCell(phrase2, 0)
						pdfPTable.AddCell(pdfPCell)
						Dim phrase3 As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
						phrase3.Add(New Chunk(String.Concat("Description: ", DirectCast(current.Cells(8).FindControl("DescriptionLbl"), Label).Text), FontFactory.GetFont("Arial", 8!, 1, BaseColor.BLACK)))
						pdfPCell = TransactionRePickups.PhraseCell(phrase3, 0)
						pdfPTable.AddCell(pdfPCell)
						Me.barCodeDocument.Add(pdfPTable)
						Me.barCodeDocument.NewPage()
					End While
				Finally
					If (TypeOf enumerator Is IDisposable) Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.barCodeDocument.Close()
				Dim array As Byte() = memoryStream.ToArray()
				memoryStream.Close()
				MyBase.Response.ContentType = "application/pdf"
				MyBase.Response.AppendHeader("Content-Disposition", "attachment; filename=BarCode.pdf")
				MyBase.Response.BinaryWrite(array)
				MyBase.Response.[End]()
			End Using
		End Sub

		Protected Sub ButtonPackingList_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim enumerator1 As IEnumerator = Nothing
			If (Me.TransactionPickupItemsGridView.Rows.Count = 0) Then
				Me.renderErrMsgs("Please select a transaction below.")
				Return
			End If
			Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(PageSize.A4, 50!, 50!, 100!, 100!)
			Try
				Dim random As System.Random = New System.Random()
				Dim str As String = String.Concat("Picklist_", Conversions.ToString(random.[Next](0, 1000000)), ".pdf")
				Dim fileStream As System.IO.FileStream = New System.IO.FileStream(MyBase.Server.MapPath(String.Concat("PDF/", str)), FileMode.Create)
				Dim _generatePackingList As generatePackingList = New generatePackingList()
				Dim instance As PdfWriter = PdfWriter.GetInstance(document, fileStream)
				instance.PageEvent = _generatePackingList
				document.Open()
				Dim pdfPTable As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
				{
					.HorizontalAlignment = 1,
					.TotalWidth = 500!
				}
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Department", FontFactory.GetFont("Calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Retention", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Picked up?", FontFactory.GetFont("calibri", 10!, 1)))
				Dim pdfPTable1 As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1) With
				{
					.TotalWidth = document.PageSize.Width
				}
				Dim phrase As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
				Dim phrase1 As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
				Dim pdfPCell As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase)
				Dim pdfPCell1 As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase1)
				Dim num As Integer = 0
				Dim num1 As Integer = 1
				Try
					enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As System.Web.UI.WebControls.GridViewRow = DirectCast(enumerator.Current, System.Web.UI.WebControls.GridViewRow)
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(current.FindControl("DepartmentLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(current.FindControl("BoxNumberLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(current.FindControl("DescriptionLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(current.FindControl("RetentionLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Yes___ No___", FontFactory.GetFont("Calibri", 8!, 0)))
						If (pdfPTable.TotalHeight < 350!) Then
							Continue While
						End If
						num = num + 1
						pdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
						{
							.HorizontalAlignment = 1,
							.LockedWidth = True,
							.TotalWidth = 500!
						}
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Department", FontFactory.GetFont("Calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Retention", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Picked up?", FontFactory.GetFont("calibri", 10!, 1)))
					End While
				Finally
					If (TypeOf enumerator Is IDisposable) Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				If (pdfPTable.Rows.Count <> 0) Then
					num = num + 1
				End If
				document.Close()
				document = New iTextSharp.text.Document(PageSize.A4, 50!, 50!, 100!, 100!)
				random = New System.Random()
				str = String.Concat("Picklist_", Conversions.ToString(random.[Next](0, 1000000)), ".pdf")
				fileStream = New System.IO.FileStream(MyBase.Server.MapPath(String.Concat("PDF/", str)), FileMode.Create)
				_generatePackingList = New generatePackingList()
				instance = PdfWriter.GetInstance(document, fileStream)
				instance.PageEvent = _generatePackingList
				document.Open()
				pdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
				{
					.HorizontalAlignment = 1,
					.LockedWidth = True,
					.TotalWidth = 500!
				}
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Department", FontFactory.GetFont("Calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Retention", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Picked up?", FontFactory.GetFont("calibri", 10!, 1)))
				Try
					enumerator1 = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
					While enumerator1.MoveNext()
						Dim gridViewRow As System.Web.UI.WebControls.GridViewRow = DirectCast(enumerator1.Current, System.Web.UI.WebControls.GridViewRow)
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("DepartmentLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("BoxNumberLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("DescriptionLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("RetentionLbl"), Label).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Yes___ No___", FontFactory.GetFont("Calibri", 8!, 0)))
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
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Department", FontFactory.GetFont("Calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Retention", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Picked up?", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable1 = New iTextSharp.text.pdf.PdfPTable(1) With
						{
							.TotalWidth = document.PageSize.Width
						}
						phrase = New iTextSharp.text.Phrase()
						phrase.Add(New Chunk(String.Concat("Page: ", Conversions.ToString(num1), "/", Conversions.ToString(num)), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Document No: ", Me.TransactionPickupDetailsView.Rows(0).Cells(1).Text, "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase.Add(New Chunk(String.Concat("Total No. of Boxes: ", Conversions.ToString(Me.TransactionPickupItemsGridView.Rows.Count), "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase1 = New iTextSharp.text.Phrase()
						phrase1.Add(New Chunk(String.Concat("" & VbCrLf & "" & VbCrLf & "Requested: ", Me.TransactionPickupDetailsView.Rows(5).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
						phrase1.Add(New Chunk(String.Concat("Customer: ", Me.TransactionPickupDetailsView.Rows(19).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
						phrase1.Add(New Chunk(String.Concat("Contact Name: ", Me.TransactionPickupDetailsView.Rows(1).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
						phrase1.Add(New Chunk(String.Concat(New String() { "Contact Details: ", Me.TransactionPickupDetailsView.Rows(3).Cells(1).Text, "/", Me.TransactionPickupDetailsView.Rows(7).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & "" }), FontFactory.GetFont("Calibri", 10!, 1)))
						phrase1.Add(New Chunk(String.Concat("Rush: ", Me.TransactionPickupDetailsView.Rows(10).Cells(1).Text), FontFactory.GetFont("Calibri", 10!, 1)))
						pdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase)
						pdfPCell1 = New iTextSharp.text.pdf.PdfPCell(phrase1)
						pdfPCell.PaddingLeft = 350!
						pdfPCell1.PaddingLeft = 50!
						pdfPCell.Border = 0
						pdfPCell1.Border = 0
						pdfPTable1.AddCell(pdfPCell)
						pdfPTable1.AddCell(pdfPCell1)
						pdfPTable1.WriteSelectedRows(0, -1, 0!, document.PageSize.Height - 110!, instance.DirectContent)
						If (num1 <> num) Then
							document.NewPage()
						End If
						num1 = num1 + 1
					End While
				Finally
					If (TypeOf enumerator1 Is IDisposable) Then
						TryCast(enumerator1, IDisposable).Dispose()
					End If
				End Try
				If (num1 <= num) Then
					pdfPTable1 = New iTextSharp.text.pdf.PdfPTable(1) With
					{
						.TotalWidth = document.PageSize.Width
					}
					phrase = New iTextSharp.text.Phrase()
					phrase.Add(New Chunk(String.Concat("Page: ", Conversions.ToString(num1), "/", Conversions.ToString(num)), FontFactory.GetFont("Calibri", 10!, 0)))
					phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Document No: ", Me.TransactionPickupDetailsView.Rows(0).Cells(1).Text, "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
					phrase.Add(New Chunk(String.Concat("Total No. of Boxes: ", Conversions.ToString(Me.TransactionPickupItemsGridView.Rows.Count), "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
					phrase1 = New iTextSharp.text.Phrase()
					phrase1.Add(New Chunk(String.Concat("" & VbCrLf & "" & VbCrLf & "Requested: ", Me.TransactionPickupDetailsView.Rows(5).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
					phrase1.Add(New Chunk(String.Concat("Customer: ", Me.TransactionPickupDetailsView.Rows(19).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
					phrase1.Add(New Chunk(String.Concat("Contact Name: ", Me.TransactionPickupDetailsView.Rows(1).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
					phrase1.Add(New Chunk(String.Concat(New String() { "Contact Details: ", Me.TransactionPickupDetailsView.Rows(3).Cells(1).Text, "/", Me.TransactionPickupDetailsView.Rows(7).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & "" }), FontFactory.GetFont("Calibri", 10!, 1)))
					phrase1.Add(New Chunk(String.Concat("Rush: ", Me.TransactionPickupDetailsView.Rows(10).Cells(1).Text), FontFactory.GetFont("Calibri", 10!, 1)))
					pdfPCell = New iTextSharp.text.pdf.PdfPCell(phrase)
					pdfPCell1 = New iTextSharp.text.pdf.PdfPCell(phrase1)
					pdfPCell.PaddingLeft = 350!
					pdfPCell1.PaddingLeft = 50!
					pdfPCell.Border = 0
					pdfPCell1.Border = 0
					pdfPTable1.AddCell(pdfPCell)
					pdfPTable1.AddCell(pdfPCell1)
					pdfPTable1.WriteSelectedRows(0, -1, 0!, document.PageSize.Height - 110!, instance.DirectContent)
					pdfPTable.WriteSelectedRows(0, -1, 45!, document.PageSize.Height - 300!, instance.DirectContent)
				End If
				document.Close()
				MyBase.Response.ContentType = "application/pdf"
				MyBase.Response.AppendHeader("Content-Disposition", "attachment; filename=PackingList.pdf")
				MyBase.Response.TransmitFile(MyBase.Server.MapPath(String.Concat("PDF/", str)))
				MyBase.Response.[End]()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ButtonRefresh_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.TransactionPickupItemsGridView.DataBind()
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
					Me.SqlDataSourceTransactionPickupItems.FilterExpression = String.Concat("BarCode LIKE '%", Me.TextBoxSearch.Text.Trim(), "%'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 1) Then
					Me.SqlDataSourceTransactionPickupItems.FilterExpression = String.Concat("Description LIKE '%", Me.TextBoxSearch.Text.Trim(), "%'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 2) Then
					Me.SqlDataSourceTransactionPickupItems.FilterExpression = String.Concat("BoxNumber = '", Me.TextBoxSearch.Text.Trim(), "'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 3) Then
					Me.SqlDataSourceTransactionPickupItems.FilterExpression = String.Concat("Department = '", Me.TextBoxSearch.Text.Trim(), "'")
				End If
				Me.SqlDataSourceTransactionPickupItems.[Select](DataSourceSelectArguments.Empty)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub CancelBtn_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.SqlDataSourceTransactionPickupItems.Delete()
		End Sub

		Protected Sub chkboxSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim checkBox As System.Web.UI.WebControls.CheckBox = DirectCast(Me.TransactionPickupItemsGridView.HeaderRow.FindControl("chkboxSelectAll"), System.Web.UI.WebControls.CheckBox)
			Try
				enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
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

		Private Shared Function ImageCell(ByVal path As String, ByVal scale As Single, ByVal align As Integer) As PdfPCell
			Dim instance As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path))
			instance.ScalePercent(scale)
			Return New PdfPCell(instance) With
			{
				.BorderColor = BaseColor.WHITE,
				.VerticalAlignment = 4,
				.HorizontalAlignment = align,
				.PaddingBottom = 0!,
				.PaddingTop = 0!
			}
		End Function

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
				Me.nl = New List(Of TransactionRePickups.ssiItem)()
				Me.Alerts()
				Me.messages()
				If (Operators.CompareString(MyBase.Request("Notif"), "true", False) = 0) Then
					Me.Session("Type") = "REPICKUP"
					Me.SqlDataSourceAlerts.Update()
					Me.Session.Remove("Notif")
					MyBase.Response.Redirect("TransactionRePickups")
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Shared Function PhraseCell(ByVal phrase As iTextSharp.text.Phrase, ByVal align As Integer) As PdfPCell
			Return New PdfPCell(phrase) With
			{
				.BorderColor = BaseColor.WHITE,
				.VerticalAlignment = 4,
				.HorizontalAlignment = align,
				.PaddingBottom = 2!,
				.PaddingTop = 0!
			}
		End Function

		Protected Sub ReceiveButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim enumerator1 As IEnumerator = Nothing
			Dim utcNow As DateTime
			Dim num As Integer = 0
			Try
				enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As System.Web.UI.WebControls.GridViewRow = DirectCast(enumerator.Current, System.Web.UI.WebControls.GridViewRow)
					If (current.RowType <> DataControlRowType.DataRow) Then
						Continue While
					End If
					Dim checkBox As System.Web.UI.WebControls.CheckBox = TryCast(current.Cells(13).FindControl("ValidationCheckBox"), System.Web.UI.WebControls.CheckBox)
					current.Cells(9).FindControl("LocationCodeTextBox")
					If (Not checkBox.Checked) Then
						Continue While
					End If
					num = num + 1
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Dim text As String = Me.TransactionPickupDetailsView.Rows(0).Cells(1).Text
			Try
				enumerator1 = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
				While enumerator1.MoveNext()
					Dim gridViewRow As System.Web.UI.WebControls.GridViewRow = DirectCast(enumerator1.Current, System.Web.UI.WebControls.GridViewRow)
					If (gridViewRow.RowType <> DataControlRowType.DataRow OrElse Not TryCast(gridViewRow.Cells(1).FindControl("ValidationCheckBox"), System.Web.UI.WebControls.CheckBox).Checked) Then
						Continue While
					End If
					Me.ReceiveSqlDataSource.UpdateParameters("Id").DefaultValue = gridViewRow.Cells(11).Text
					Me.ReceiveSqlDataSource.UpdateParameters("Status").DefaultValue = "IN"
					Me.ReceiveSqlDataSource.UpdateParameters("StockReceipt_id").DefaultValue = text
					Me.ReceiveSqlDataSource.UpdateParameters("BarCode").DefaultValue = HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("BarCodeLbl"), Label).Text)
					Me.ReceiveSqlDataSource.UpdateParameters("QRCode").DefaultValue = HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("QRCodeLbl"), Label).Text)
					Me.ReceiveSqlDataSource.UpdateParameters("Department").DefaultValue = HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("DepartmentLbl"), Label).Text)
					Me.ReceiveSqlDataSource.UpdateParameters("BoxNumber").DefaultValue = HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("BoxNumberLbl"), Label).Text)
					Me.ReceiveSqlDataSource.UpdateParameters("Description").DefaultValue = HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("DescriptionLbl"), Label).Text)
					Me.ReceiveSqlDataSource.UpdateParameters("Retention").DefaultValue = HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("RetentionLbl"), Label).Text)
					Me.Session("_Barcode") = HttpUtility.HtmlDecode(DirectCast(gridViewRow.FindControl("BarCodeLbl"), Label).Text)
					Me.ReceiveSqlDataSource.Update()
					Me.SqlDataSourceUpdatePickupItems.UpdateParameters("Status").DefaultValue = "PROCESSED"
					Dim item As Parameter = Me.SqlDataSourceUpdatePickupItems.UpdateParameters("ModifiedDate")
					utcNow = DateTime.UtcNow
					item.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
					Me.SqlDataSourceUpdatePickupItems.UpdateParameters("ModifiedBy").DefaultValue = MyBase.User.Identity.GetUserName()
					Me.SqlDataSourceUpdatePickupItems.UpdateParameters("Id").DefaultValue = gridViewRow.Cells(2).Text
					Me.SqlDataSourceUpdatePickupItems.Update()
				End While
			Finally
				If (TypeOf enumerator1 Is IDisposable) Then
					TryCast(enumerator1, IDisposable).Dispose()
				End If
			End Try
			Me.SqlDataSourceUpdateTransactionPickup.UpdateParameters("Alerts").DefaultValue = "2"
			Me.SqlDataSourceUpdateTransactionPickup.UpdateParameters("Status").DefaultValue = "PROCESSED"
			Dim str As Parameter = Me.SqlDataSourceUpdateTransactionPickup.UpdateParameters("ModifiedDate")
			utcNow = DateTime.UtcNow
			str.DefaultValue = Conversions.ToString(utcNow.AddHours(8))
			Me.SqlDataSourceUpdateTransactionPickup.UpdateParameters("ModifiedBy").DefaultValue = MyBase.User.Identity.GetUserName()
			Me.SqlDataSourceUpdateTransactionPickup.UpdateParameters("Id").DefaultValue = Convert.ToString(Me.TransactionPickupDetailsView.Rows(0).Cells(1).Text)
			Me.SqlDataSourceUpdateTransactionPickup.Update()
			MyBase.Response.Redirect(String.Concat("ProcessedRepickupTransactions?ID=", text))
			MyBase.Response.Redirect("SuccessPage?SuccessMessage=RePick Up item/s has been successfully accepted.&Type=Repickup")
		End Sub

		Private Sub ReceiveSqlDataSource_Updated(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.Session("HistoryMasterListId") = RuntimeHelpers.GetObjectValue(e.Command.Parameters("@masterID").Value)
			Me.Session("HistoryDesc") = "REPICK UP"
			Me.Session("HistoryCreatedBy") = MyBase.User.Identity.Name
			Dim session As HttpSessionState = Me.Session
			Dim dateTime As System.DateTime = System.DateTime.UtcNow.AddHours(8)
			session("HistoryCreatedDate") = dateTime.ToShortDateString()
			Me.SqlDataSourceHistory.Insert()
		End Sub

		Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.TransactionPickupsGridView.DataBind()
				Me.SearchTextbox.Text = ""
				Me.SearchDropDownList.SelectedIndex = 0
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Sub renderErrMsgs(ByVal thisErrMsg As String)
			' 
			' Current member / type: System.Void ssiFinal.TransactionRePickups::renderErrMsgs(System.String)
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
				enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
					Me.TransactionPickupItemsGridView.UpdateRow(current.RowIndex, False)
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
					Me.SqlDataSourceTransactionPickupGrid.FilterExpression = String.Concat("DepartmentCode LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 1) Then
					Me.SqlDataSourceTransactionPickupGrid.FilterExpression = String.Concat("ContactName LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 2) Then
					Me.SqlDataSourceTransactionPickupGrid.FilterExpression = String.Concat("Id = '", Me.SearchTextbox.Text.Trim(), "'")
				End If
				Me.SqlDataSourceTransactionPickupGrid.[Select](DataSourceSelectArguments.Empty)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub SqlDataSourceTransactionPickupItems_Deleted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.SqlDataSourceTransactionPickupGrid.Delete()
			MyBase.Response.Redirect("~/devadmin/TransactionRePickups.aspx", False)
		End Sub

		Private Sub TransactionPickupDetailsView_DataBound(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Private Sub TransactionPickupItemsGridView_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
			Me.ReceiveButton.Enabled = True
		End Sub

		Private Sub TransactionPickupItemsGridView_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
			Me.ReceiveButton.Enabled = False
		End Sub

		Private Sub TransactionPickupItemsGridView_RowUpdated(ByVal sender As Object, ByVal e As GridViewUpdatedEventArgs)
			Me.ReceiveButton.Enabled = True
		End Sub

		Private Sub TransactionPickupItemsGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.SaveBtn.Enabled = False
			Me.EditBtn.Enabled = True
		End Sub

		Protected Sub UploadButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				If (Not Me.FileUpload1.HasFile) Then
					Me.renderErrMsgs("No file uploaded.")
				Else
					Dim fileName As String = Path.GetFileName(Me.FileUpload1.PostedFile.FileName)
					Path.GetExtension(Me.FileUpload1.PostedFile.FileName)
					Dim item As String = ConfigurationManager.AppSettings("FolderPath")
					Dim str As String = MyBase.Server.MapPath(String.Concat(item, fileName))
					If (File.Exists(str)) Then
						File.Delete(str)
					End If
					Me.FileUpload1.SaveAs(str)
					Dim strArrays As String() = File.ReadAllLines(str)
					For i As Integer = 0 To CInt(strArrays.Length) Step 1
						Dim str1 As String = strArrays(i)
						Try
							enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
							While enumerator.MoveNext()
								Dim current As TableRow = DirectCast(enumerator.Current, TableRow)
								If (Operators.CompareString(str1, HttpUtility.HtmlDecode(current.Cells(4).Text.ToString()), False) <> 0) Then
									Continue While
								End If
								TryCast(current.Cells(1).FindControl("ValidationCheckBox"), CheckBox).Checked = True
								Exit While
							End While
						Finally
							If (TypeOf enumerator Is IDisposable) Then
								TryCast(enumerator, IDisposable).Dispose()
							End If
						End Try
					Next

				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub UploadQrButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator(Of HttpPostedFile) = Nothing
			Dim enumerator1 As IEnumerator(Of HttpPostedFile) = Nothing
			Dim enumerator2 As IEnumerator = Nothing
			Try
				If (Not Me.FileUpload2.HasFiles) Then
					Me.renderErrMsgs("No file uploaded.")
				Else
					Using enumerator
						enumerator = Me.FileUpload2.PostedFiles.GetEnumerator()
						While enumerator.MoveNext()
							Dim current As HttpPostedFile = enumerator.Current
							Dim fileName As String = Path.GetFileName(current.FileName)
							Path.GetExtension(fileName)
							Dim item As String = ConfigurationManager.AppSettings("FolderPath")
							Dim str As String = MyBase.Server.MapPath(String.Concat(item, fileName))
							current.SaveAs(str)
						End While
					End Using
					If (Me.Session("tableBackUp") IsNot Nothing) Then
						Me.nl = DirectCast(Me.Session("tableBackUp"), List(Of TransactionRePickups.ssiItem))
					End If
					Using enumerator1
						enumerator1 = Me.FileUpload2.PostedFiles.GetEnumerator()
						While enumerator1.MoveNext()
							Dim fileName1 As String = Path.GetFileName(enumerator1.Current.FileName)
							Path.GetExtension(fileName1)
							Dim item1 As String = ConfigurationManager.AppSettings("FolderPath")
							Dim str1 As String = MyBase.Server.MapPath(String.Concat(item1, fileName1))
							Dim barcodeReader As ZXing.BarcodeReader = New ZXing.BarcodeReader()
							Dim bitmap As System.Drawing.Bitmap = DirectCast(System.Drawing.Image.FromFile(str1), System.Drawing.Bitmap)
							Dim result As ZXing.Result = DirectCast(barcodeReader, IBarcodeReader).Decode(bitmap)
							If (result Is Nothing) Then
								Continue While
							End If
							Try
								enumerator2 = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
								While enumerator2.MoveNext()
									Dim tableRow As System.Web.UI.WebControls.TableRow = DirectCast(enumerator2.Current, System.Web.UI.WebControls.TableRow)
									If (Operators.CompareString(tableRow.Cells(4).Text.ToString(), result.Text, False) <> 0) Then
										Continue While
									End If
									TryCast(tableRow.Cells(1).FindControl("ValidationCheckBox"), CheckBox).Checked = True
									Exit While
								End While
							Finally
								If (TypeOf enumerator2 Is IDisposable) Then
									TryCast(enumerator2, IDisposable).Dispose()
								End If
							End Try
						End While
					End Using
					Me.Session("tableBackUp") = Me.nl
				End If
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