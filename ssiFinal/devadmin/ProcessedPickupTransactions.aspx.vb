Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.[Shared]
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Collections.Generic
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

Namespace ssiFinal
	Public Class ProcessedPickupTransactions
		Inherits System.Web.UI.Page
		Public errMsg As String

		Private barCodeDocument As Document

		Private QRCodeDocument As Document

		Public nl As List(Of ProcessedPickupTransactions.pickupItem)
        Private _Button1 As Button
        Private _Button2 As Button
        Private _Button3 As Button
        Private _Button4 As Button
        Private _ButtonRefresh As Button
        Private _ButtonSearch As Button
        Private _ButtonStockReceiptExcel As Button
        Private _RefreshButton As Button
        Private _SearchButton As Button
        Private _TransactionPickupsGridView As GridView

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

        Protected Overridable Property Button2 As Button
			Get
				Return Me._Button2
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button2_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._Button2
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._Button2 = value
				button = Me._Button2
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property Button3 As Button
			Get
				Return Me._Button3
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button3_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._Button3
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._Button3 = value
				button = Me._Button3
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property Button4 As Button
			Get
				Return Me._Button4
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.Button4_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._Button4
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._Button4 = value
				button = Me._Button4
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

		Protected Overridable Property ButtonStockReceiptExcel As Button
			Get
				Return Me._ButtonStockReceiptExcel
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonStockReceiptExcel_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonStockReceiptExcel
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonStockReceiptExcel = value
				button = Me._ButtonStockReceiptExcel
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DropDownListSearch As DropDownList

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

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourcePickUpItems As SqlDataSource

		Protected Overridable Property SqlDataSourceReadUserDetails As SqlDataSource

		Protected Overridable Property SqlDataSourceStockReceipt As SqlDataSource

		Protected Overridable Property SqlDataSourceTransactionPickups As SqlDataSource

		Protected Overridable Property SqlDataSourceTransactionPickupsDetails As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property TextBoxSearch As TextBox

		Protected Overridable Property TotalCount As HtmlGenericControl

		Protected Overridable Property TotalMessages As HtmlGenericControl

		Protected Overridable Property TransactionPickupDetailsView As DetailsView

		Protected Overridable Property TransactionPickupItemsGridView As GridView

		Protected Overridable Property TransactionPickupsGridView As GridView
			Get
				Return Me._TransactionPickupsGridView
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.TransactionPickupsGridView_SelectedIndexChanged)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._TransactionPickupsGridView
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.SelectedIndexChanged,  eventHandler
				End If
				Me._TransactionPickupsGridView = value
				gridView = Me._TransactionPickupsGridView
				If (gridView IsNot Nothing) Then
					AddHandler gridView.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me.barCodeDocument = New Document(PageSize.A7.Rotate(), 10!, 10!, 50!, 0!)
			Me.QRCodeDocument = New Document(New iTextSharp.text.Rectangle(140!, 160!), 5!, 5!, 10!, 10!)
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

		Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Try
				Try
					Using streamWriter As System.IO.StreamWriter = File.CreateText(String.Concat(MyBase.Server.MapPath("CSV"), "/BarCode.txt"))
						Try
							enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
							While enumerator.MoveNext()
								Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
								streamWriter.WriteLine(HttpUtility.HtmlDecode(current.Cells(2).Text))
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

		Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim enumerator1 As IEnumerator = Nothing
			If (Me.TransactionPickupItemsGridView.Rows.Count = 0) Then
				Me.renderErrMsgs("Please select a transaction below.")
				Return
			End If
			Try
				Dim document As iTextSharp.text.Document = New iTextSharp.text.Document(PageSize.A4, 50!, 50!, 100!, 100!)
				Dim random As System.Random = New System.Random()
				Dim str As String = String.Concat("StockReceipt_", Conversions.ToString(random.[Next](0, 1000000)), ".pdf")
				Dim fileStream As System.IO.FileStream = New System.IO.FileStream(MyBase.Server.MapPath(String.Concat("PDF/", str)), FileMode.Create)
				Dim _generateStockReceipt As generateStockReceipt = New generateStockReceipt()
				Dim instance As PdfWriter = PdfWriter.GetInstance(document, fileStream)
				instance.PageEvent = _generateStockReceipt
				document.Open()
				Dim pdfPTable As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
				{
					.HorizontalAlignment = 1,
					.TotalWidth = 500!
				}
				Dim num As Integer = 0
				pdfPTable.AddCell(New iTextSharp.text.Phrase("BarCode", FontFactory.GetFont("Calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Location Code", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Destruction", FontFactory.GetFont("calibri", 10!, 1)))
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
					enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As System.Web.UI.WebControls.GridViewRow = DirectCast(enumerator.Current, System.Web.UI.WebControls.GridViewRow)
						pdfPTable.AddCell(New iTextSharp.text.Phrase(current.Cells(2).Text, FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(current.Cells(5).Text, FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(current.Cells(6).Text, FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("", FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(current.Cells(7).Text, FontFactory.GetFont("Calibri", 8!, 0)))
						If (pdfPTable.TotalHeight < 350!) Then
							Continue While
						End If
						num1 = num1 + 1
						pdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
						{
							.HorizontalAlignment = 1,
							.TotalWidth = 500!
						}
						pdfPTable.AddCell(New iTextSharp.text.Phrase("BarCode", FontFactory.GetFont("Calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Location Code", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Destruction", FontFactory.GetFont("calibri", 10!, 1)))
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
				fileStream = New System.IO.FileStream(MyBase.Server.MapPath(String.Concat("PDF/", str)), FileMode.Create)
				_generateStockReceipt = New generateStockReceipt()
				instance = PdfWriter.GetInstance(document, fileStream)
				instance.PageEvent = _generateStockReceipt
				document.Open()
				pdfPTable = New iTextSharp.text.pdf.PdfPTable(5) With
				{
					.HorizontalAlignment = 1,
					.TotalWidth = 500!
				}
				pdfPTable.AddCell(New iTextSharp.text.Phrase("BarCode", FontFactory.GetFont("Calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Location Code", FontFactory.GetFont("calibri", 10!, 1)))
				pdfPTable.AddCell(New iTextSharp.text.Phrase("Destruction", FontFactory.GetFont("calibri", 10!, 1)))
				Try
					enumerator1 = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
					While enumerator1.MoveNext()
						Dim gridViewRow As System.Web.UI.WebControls.GridViewRow = DirectCast(enumerator1.Current, System.Web.UI.WebControls.GridViewRow)
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(gridViewRow.Cells(2).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(gridViewRow.Cells(5).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(gridViewRow.Cells(6).Text), FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("", FontFactory.GetFont("Calibri", 8!, 0)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase(HttpUtility.HtmlDecode(gridViewRow.Cells(7).Text), FontFactory.GetFont("Calibri", 8!, 0)))
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
						pdfPTable.AddCell(New iTextSharp.text.Phrase("BarCode", FontFactory.GetFont("Calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Box Number", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Description", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Location Code", FontFactory.GetFont("calibri", 10!, 1)))
						pdfPTable.AddCell(New iTextSharp.text.Phrase("Destruction", FontFactory.GetFont("calibri", 10!, 1)))
						Dim pdfPTable2 As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(1) With
						{
							.TotalWidth = document.PageSize.Width
						}
						phrase = New iTextSharp.text.Phrase()
						phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Page: ", Conversions.ToString(num2), "/", Conversions.ToString(num1)), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Document No: ", Me.TransactionPickupDetailsView.Rows(0).Cells(1).Text, "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase.Add(New Chunk(String.Concat("Total No. of Boxes: ", Conversions.ToString(Me.TransactionPickupItemsGridView.Rows.Count), "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
						phrase1 = New iTextSharp.text.Phrase()
						phrase1.Add(New Chunk(String.Concat("" & VbCrLf & "" & VbCrLf & "Requested: ", Me.TransactionPickupDetailsView.Rows(5).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
						phrase1.Add(New Chunk(String.Concat("Customer: ", Me.TransactionPickupDetailsView.Rows(11).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
						phrase1.Add(New Chunk(String.Concat("Contact Name: ", Me.TransactionPickupDetailsView.Rows(1).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
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
					phrase.Add(New Chunk(String.Concat("" & VbCrLf & "Document No: ", Me.TransactionPickupDetailsView.Rows(0).Cells(1).Text, "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
					phrase.Add(New Chunk(String.Concat("Total No. of Boxes: ", Conversions.ToString(Me.TransactionPickupItemsGridView.Rows.Count), "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 0)))
					phrase1 = New iTextSharp.text.Phrase()
					phrase1.Add(New Chunk(String.Concat("" & VbCrLf & "" & VbCrLf & "Requested: ", Me.TransactionPickupDetailsView.Rows(5).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
					phrase1.Add(New Chunk(String.Concat("Customer: ", Me.TransactionPickupDetailsView.Rows(11).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
					phrase1.Add(New Chunk(String.Concat("Contact Name: ", Me.TransactionPickupDetailsView.Rows(1).Cells(1).Text, "" & VbCrLf & "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 10!, 1)))
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
				MyBase.Response.AppendHeader("Content-Disposition", "attachment; filename=StockReceipt.pdf")
				MyBase.Response.TransmitFile(MyBase.Server.MapPath(String.Concat("PDF/", str)))
				MyBase.Response.[End]()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
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
							.TotalWidth = 280!,
							.LockedWidth = True
						}
						pdfPCell = New iTextSharp.text.pdf.PdfPCell()
						Dim phrase As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
						phrase.Add(New Chunk("SSI Storage Solutions Incorporated" & VbCrLf & "", FontFactory.GetFont("Arial", 12!, 1, BaseColor.BLACK)))
						pdfPCell = ProcessedPickupTransactions.PhraseCell(phrase, 8)
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
							.Code = current.Cells(2).Text
						}
						Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(New Bitmap(barcode128.CreateDrawingImage(Color.Black, Color.White)), System.Drawing.Imaging.ImageFormat.Bmp)
						pdfPCell.AddElement(image)
						pdfPTable.AddCell(pdfPCell)
						Dim phrase1 As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
						phrase1.Add(New Chunk(current.Cells(2).Text, FontFactory.GetFont("Arial", 10!, 1, BaseColor.BLACK)))
						pdfPCell = ProcessedPickupTransactions.PhraseCell(phrase1, 8)
						pdfPTable.AddCell(pdfPCell)
						Dim phrase2 As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
						phrase2.Add(New Chunk(String.Concat("Box No: ", current.Cells(5).Text, "" & VbCrLf & ""), FontFactory.GetFont("Arial", 10!, 1, BaseColor.BLACK)))
						pdfPCell = ProcessedPickupTransactions.PhraseCell(phrase2, 0)
						pdfPTable.AddCell(pdfPCell)
						Dim phrase3 As iTextSharp.text.Phrase = New iTextSharp.text.Phrase()
						phrase3.Add(New Chunk(String.Concat("Description: ", current.Cells(6).Text), FontFactory.GetFont("Arial", 10!, 1, BaseColor.BLACK)))
						pdfPCell = ProcessedPickupTransactions.PhraseCell(phrase3, 0)
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

		Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Using memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
				Dim instance As PdfWriter = PdfWriter.GetInstance(Me.QRCodeDocument, memoryStream)
				Me.QRCodeDocument.Open()
				Dim directContent As PdfContentByte = instance.DirectContent
				Try
					enumerator = Me.TransactionPickupItemsGridView.Rows.GetEnumerator()
					While enumerator.MoveNext()
						Dim current As GridViewRow = DirectCast(enumerator.Current, GridViewRow)
						Dim pdfPTable As iTextSharp.text.pdf.PdfPTable = New iTextSharp.text.pdf.PdfPTable(2)
						Dim pdfPCell As iTextSharp.text.pdf.PdfPCell = New iTextSharp.text.pdf.PdfPCell()
						Dim singleArray() As Single = { 20!, 80! }
						pdfPTable.TotalWidth = 150!
						pdfPTable.SetWidths(singleArray)
						pdfPCell = New iTextSharp.text.pdf.PdfPCell(New Paragraph("SSI Storage Solutions Incorporated", FontFactory.GetFont("Calibri", 8!, 1))) With
						{
							.Rotation = 90,
							.HorizontalAlignment = 1,
							.Border = 0
						}
						pdfPTable.AddCell(pdfPCell)
						Dim image As iTextSharp.text.Image = (New BarcodeQRCode(current.Cells(2).Text, 1, 1, Nothing)).GetImage()
						image.ScaleToFit(50!, 50!)
						image.Alignment = 4
						pdfPCell = New iTextSharp.text.pdf.PdfPCell()
						pdfPCell.AddElement(image)
						pdfPCell.AddElement(New Paragraph(String.Concat(current.Cells(2).Text, "" & VbCrLf & ""), FontFactory.GetFont("Calibri", 7!, 1)))
						pdfPCell.AddElement(New Paragraph(String.Concat("Box Number: ", current.Cells(5).Text, "" & VbCrLf & "Description: ", current.Cells(6).Text), FontFactory.GetFont("Calibri", 6!, 0)))
						pdfPCell.Rotation = 90
						pdfPCell.Border = 0
						pdfPCell.Padding = 0!
						pdfPTable.AddCell(pdfPCell)
						Me.QRCodeDocument.Add(pdfPTable)
						Me.QRCodeDocument.NewPage()
					End While
				Finally
					If (TypeOf enumerator Is IDisposable) Then
						TryCast(enumerator, IDisposable).Dispose()
					End If
				End Try
				Me.QRCodeDocument.Close()
				Dim array As Byte() = memoryStream.ToArray()
				MyBase.Response.Buffer = True
				MyBase.Response.Clear()
				MyBase.Response.ContentType = "application/pdf"
				MyBase.Response.AddHeader("content-disposition", "attachment; filename=BarCode.pdf")
				MyBase.Response.BinaryWrite(array)
				MyBase.Response.Flush()
				memoryStream.Close()
			End Using
		End Sub

		Protected Sub ButtonRefresh_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.TransactionPickupItemsGridView.DataBind()
				Me.TextBoxSearch.Text = ""
				Me.DropDownListSearch.SelectedIndex = 0
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ButtonSearch_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.DropDownListSearch.SelectedIndex = 0) Then
					Me.SqlDataSourcePickUpItems.FilterExpression = String.Concat("BarCode LIKE '%", Me.TextBoxSearch.Text.Trim(), "%'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 1) Then
					Me.SqlDataSourcePickUpItems.FilterExpression = String.Concat("Description LIKE '%", Me.TextBoxSearch.Text.Trim(), "%'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 2) Then
					Me.SqlDataSourcePickUpItems.FilterExpression = String.Concat("BoxNumber = '", Me.TextBoxSearch.Text.Trim(), "'")
				ElseIf (Me.DropDownListSearch.SelectedIndex = 3) Then
					Me.SqlDataSourcePickUpItems.FilterExpression = String.Concat("Department = '", Me.TextBoxSearch.Text.Trim(), "'")
				End If
				Me.SqlDataSourcePickUpItems.[Select](DataSourceSelectArguments.Empty)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub ButtonStockReceiptExcel_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.TransactionPickupItemsGridView.Rows.Count = 0) Then
				Me.renderErrMsgs("Please select a transaction below.")
				Return
			End If
			Try
				Dim data As DataSet1 = Me.GetData(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT BarCode, QRCode, Department, BoxNumber, Description, Retention, Status FROM PickUps WHERE TransactionHeaders_id = '", Me.Session("StockID")), "' AND Status = 'PROCESSED'")))
				Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument()
				reportDocument.Load(MyBase.Server.MapPath("~/devadmin/ExportSTRPickup.rpt"))
				reportDocument.SetDataSource(data)
				reportDocument.ExportToHttpResponse(ExportFormatType.Excel, MyBase.Response, True, "StockReceipt")
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
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
						sqlDataAdapter.Fill(dataSet11, "ProcessedPickupTransactionsItems")
						dataSet1 = dataSet11
					End Using
				End Using
			End Using
			Return dataSet1
		End Function

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
				Me.Alerts()
				Me.messages()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			If (Not Information.IsNothing(MyBase.Request("ID"))) Then
				Me.SqlDataSourceTransactionPickups.FilterExpression = String.Concat("Id = '", MyBase.Request("ID"), "'")
				Me.TransactionPickupsGridView.SelectedIndex = 0
				Me.Session("StockID") = MyBase.Request("ID")
				Me.TransactionPickupItemsGridView.DataBind()
			End If
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

		Protected Sub RefreshButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Redirect("ProcessedPickupTransactions")
			Try
				Me.TransactionPickupsGridView.DataBind()
				Me.SearchTextbox.Text = ""
				Me.SearchDropDownList.SelectedIndex = 0
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Public Sub renderErrMsgs(ByVal thisErrMsg As String)
			' 
			' Current member / type: System.Void ssiFinal.ProcessedPickupTransactions::renderErrMsgs(System.String)
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

		Protected Sub SearchButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				If (Me.SearchDropDownList.SelectedIndex = 0) Then
					Me.SqlDataSourceTransactionPickups.FilterExpression = String.Concat("DepartmentCode LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 1) Then
					Me.SqlDataSourceTransactionPickups.FilterExpression = String.Concat("ContactName LIKE '%", Me.SearchTextbox.Text.Trim(), "%'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 2) Then
					Me.SqlDataSourceTransactionPickups.FilterExpression = String.Concat("Id = '", Me.SearchTextbox.Text.Trim(), "'")
				ElseIf (Me.SearchDropDownList.SelectedIndex = 3) Then
					Me.SqlDataSourceTransactionPickups.FilterExpression = String.Concat("RequestDate = '", Me.SearchTextbox.Text.Trim(), "'")
				End If
				Me.SqlDataSourceTransactionPickups.[Select](DataSourceSelectArguments.Empty)
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				Me.renderErrMsgs(exception.Message.ToString())
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub TransactionPickupsGridView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("StockID") = Me.TransactionPickupsGridView.SelectedRow.Cells(1).Text
		End Sub

		Public Class pickupItem
			Public Property BarCode As String

			Public Property BoxNumber As String

			Public Property Description As String

			Public Sub New()
				MyBase.New()
			End Sub
		End Class
	End Class
End Namespace