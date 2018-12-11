Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Invoice
		Inherits System.Web.UI.Page
		Private MonthlyStorageTotal As Double

		Private totalBoxes As Integer

		Private handlingINtotalBox As Integer

		Private HandlingInTotal As Double

		Private handlingOuttotalBox As Integer

		Private handlingOutTotal As Double

		Private othersTotal As Double

		Private othersTotalBox As Integer
        Private _GridViewOthers As GridView
        Private _GridViewMonthlyStorage As GridView
        Private _GridViewInvoiceList As GridView
        Private _GridViewHandlingOut As GridView
        Private _FormView1 As FormView
        Private _ButtonGenerateInvoice As Button
        Private _DropDownList1 As DropDownList
        Private _GridViewItemHandlingIn As GridView
        Private _SqlDataSourceInsertInvoice As SqlDataSource

        Protected Overridable Property ButtonGenerateInvoice As Button
            Get
                Return Me._ButtonGenerateInvoice
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonGenerateInvoice_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._ButtonGenerateInvoice
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._ButtonGenerateInvoice = value
                button = Me._ButtonGenerateInvoice
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property CheckBox1 As CheckBox

		Protected Overridable Property dp1 As TextBox

		Protected Overridable Property DropDownList1 As DropDownList
			Get
				Return Me._DropDownList1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.DropDownList)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.DropDownList1_SelectedIndexChanged)
				Dim dropDownList As System.Web.UI.WebControls.DropDownList = Me._DropDownList1
				If (dropDownList IsNot Nothing) Then
					RemoveHandler dropDownList.SelectedIndexChanged,  eventHandler
				End If
				Me._DropDownList1 = value
				dropDownList = Me._DropDownList1
				If (dropDownList IsNot Nothing) Then
					AddHandler dropDownList.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DropDownListCompanyList As DropDownList

		Protected Overridable Property FormView1 As FormView
			Get
				Return Me._FormView1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.FormView)
				Dim formViewInsertedEventHandler As System.Web.UI.WebControls.FormViewInsertedEventHandler = New System.Web.UI.WebControls.FormViewInsertedEventHandler(AddressOf Me.FormView1_ItemInserted)
				Dim formViewInsertEventHandler As System.Web.UI.WebControls.FormViewInsertEventHandler = New System.Web.UI.WebControls.FormViewInsertEventHandler(AddressOf Me.FormView1_ItemInserting)
				Dim formView As System.Web.UI.WebControls.FormView = Me._FormView1
				If (formView IsNot Nothing) Then
					RemoveHandler formView.ItemInserted,  formViewInsertedEventHandler
					RemoveHandler formView.ItemInserting,  formViewInsertEventHandler
				End If
				Me._FormView1 = value
				formView = Me._FormView1
				If (formView IsNot Nothing) Then
					AddHandler formView.ItemInserted,  formViewInsertedEventHandler
					AddHandler formView.ItemInserting,  formViewInsertEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewHandlingOut As GridView
			Get
				Return Me._GridViewHandlingOut
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridViewHandlingOut_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewHandlingOut
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridViewHandlingOut = value
				gridView = Me._GridViewHandlingOut
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewInvoiceList As GridView
			Get
				Return Me._GridViewInvoiceList
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.GridViewInvoiceList_SelectedIndexChanged)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewInvoiceList
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.SelectedIndexChanged,  eventHandler
				End If
				Me._GridViewInvoiceList = value
				gridView = Me._GridViewInvoiceList
				If (gridView IsNot Nothing) Then
					AddHandler gridView.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewItemHandlingIn As GridView
			Get
				Return Me._GridViewItemHandlingIn
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridViewItemHandlingIn_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewItemHandlingIn
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridViewItemHandlingIn = value
				gridView = Me._GridViewItemHandlingIn
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewMonthlyStorage As GridView
			Get
				Return Me._GridViewMonthlyStorage
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridViewMonthlyStorage_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewMonthlyStorage
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridViewMonthlyStorage = value
				gridView = Me._GridViewMonthlyStorage
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridViewOthers As GridView
			Get
				Return Me._GridViewOthers
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridViewOthers_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewOthers
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridViewOthers = value
				gridView = Me._GridViewOthers
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property LabelConsumptionTax As Label

		Protected Overridable Property LabelSubTotalCharges As Label

		Protected Overridable Property LabelTitle As Label

		Protected Overridable Property LabelTotalChargesItemHandling As Label

		Protected Overridable Property LabelTotalChargesSpecialServices As Label

		Protected Overridable Property LabelTotalChargesStorage As Label

		Protected Overridable Property LabelTotalTransaction As Label

		Protected Overridable Property lnkPrint As LinkButton

		Protected Overridable Property messagesNotif As HtmlGenericControl

		Protected Overridable Property Notifications As HtmlGenericControl

		Protected Overridable Property Panel1 As Panel

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceCompanyList As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingIn As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingINInsert As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingOut As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingOutInsert As SqlDataSource

		Protected Overridable Property SqlDataSourceInsertInvoice As SqlDataSource
			Get
				Return Me._SqlDataSourceInsertInvoice
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSourceInsertInvoice_Inserted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSourceInsertInvoice
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSourceInsertInvoice = value
				sqlDataSource = Me._SqlDataSourceInsertInvoice
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSourceInsertItem As SqlDataSource

		Protected Overridable Property SqlDataSourceInvoiceList As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceMonthlyStorage As SqlDataSource

		Protected Overridable Property SqlDataSourceOthers As SqlDataSource

		Protected Overridable Property SqlDataSourcePickupBoxNewStorage As SqlDataSource

		Protected Overridable Property SqlDataSourceStorageFee As SqlDataSource

		Protected Overridable Property SqlDataSourceUserLoginAlert As SqlDataSource

		Protected Overridable Property SqlDataSourceVat As SqlDataSource

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

		Protected Sub ButtonGenerateInvoice_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("CompanyName") = Me.DropDownListCompanyList.SelectedItem.Text
			Me.Session("CompanyCode") = Me.DropDownListCompanyList.SelectedItem.Value
			Dim session As HttpSessionState = Me.Session
			Dim text As String = Me.dp1.Text
			Dim dateTime As System.DateTime = Convert.ToDateTime(Me.dp1.Text)
			dateTime = dateTime.AddMonths(1)
			session("DateRange") = String.Concat(text, "-", dateTime.ToShortDateString())
			Me.Session("DateRange1") = Me.dp1.Text
			Dim shortDateString As HttpSessionState = Me.Session
			dateTime = Convert.ToDateTime(Me.dp1.Text)
			dateTime = dateTime.AddMonths(1)
			shortDateString("DateRange2") = dateTime.ToShortDateString()
			Me.Session("vat") = 0
			Me.SqlDataSourceInsertInvoice.Insert()
		End Sub

		Private Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Me.FormView1.DataSourceID = Nothing
				If (Me.DropDownList1.SelectedIndex = 0) Then
					Me.FormView1.DataSourceID = Me.SqlDataSourceHandlingIn.ID
					Me.FormView1.DataBind()
				ElseIf (Me.DropDownList1.SelectedIndex = 1) Then
					Me.FormView1.DataSourceID = Me.SqlDataSourceHandlingOut.ID
					Me.FormView1.DataBind()
				ElseIf (Me.DropDownList1.SelectedIndex = 2) Then
					Me.FormView1.DataSourceID = Me.SqlDataSourceStorageFee.ID
					Me.FormView1.DataBind()
				ElseIf (Me.DropDownList1.SelectedIndex = 3) Then
					Me.FormView1.DataSourceID = Me.SqlDataSourceOthers.ID
					Me.FormView1.DataBind()
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As FormViewInsertedEventArgs)
			Try
				Me.GridViewMonthlyStorage.DataBind()
				Me.GridViewOthers.DataBind()
				Me.GridViewItemHandlingIn.DataBind()
				Me.GridViewHandlingOut.DataBind()
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub FormView1_ItemInserting(ByVal sender As Object, ByVal e As FormViewInsertEventArgs)
		End Sub

		Protected Sub getOthers()
			' 
			' Current member / type: System.Void ssiFinal.Invoice::getOthers()
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void getOthers()
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

		Protected Sub getTotalHandlingOut()
			' 
			' Current member / type: System.Void ssiFinal.Invoice::getTotalHandlingOut()
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void getTotalHandlingOut()
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

		Protected Sub getTotalHandlinIn()
			' 
			' Current member / type: System.Void ssiFinal.Invoice::getTotalHandlinIn()
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void getTotalHandlinIn()
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

		Protected Sub getTotalStorageFee()
			' 
			' Current member / type: System.Void ssiFinal.Invoice::getTotalStorageFee()
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void getTotalStorageFee()
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

		Private Sub GridViewHandlingOut_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				Dim label As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelQuantity"), System.Web.UI.WebControls.Label)
				Dim str As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelTotal"), System.Web.UI.WebControls.Label)
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					e.Row.Cells(6).Text = "X"
					Dim num As Double = Convert.ToDouble(label.Text) * Convert.ToDouble(e.Row.Cells(7).Text)
					str.Text = num.ToString()
				End If
				If (e.Row.RowType = DataControlRowType.Footer) Then
					Me.getTotalHandlingOut()
					e.Row.Cells(5).Text = String.Concat(Conversions.ToString(Me.handlingOuttotalBox), " Boxes")
					e.Row.Cells(8).Text = Me.handlingOutTotal.ToString("c", CultureInfo.GetCultureInfo("en-PH"))
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub GridViewInvoiceList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim strArrays(-1) As String
			strArrays = Me.GridViewInvoiceList.SelectedRow.Cells(3).Text.Split(New Char() { "-"C })
			Dim labelTitle As Label = Me.LabelTitle
			Dim str() As String = { "Invoice Detail (Summary) Transaction Period from ", Nothing, Nothing, Nothing, Nothing, Nothing }
			Dim dateTime As System.DateTime = Convert.ToDateTime(strArrays(0))
			str(1) = dateTime.ToString("MMM dd")
			str(2) = " to "
			dateTime = Convert.ToDateTime(strArrays(1))
			str(3) = dateTime.ToString("MMM dd,yyyy")
			str(4) = "<br />"
			str(5) = Me.GridViewInvoiceList.SelectedRow.Cells(2).Text
			labelTitle.Text = String.Concat(str)
		End Sub

		Private Sub GridViewItemHandlingIn_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				Dim label As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelQuantity"), System.Web.UI.WebControls.Label)
				Dim str As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelTotal"), System.Web.UI.WebControls.Label)
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					e.Row.Cells(6).Text = "X"
					Dim num As Double = Convert.ToDouble(label.Text) * Convert.ToDouble(e.Row.Cells(7).Text)
					str.Text = num.ToString()
				End If
				If (e.Row.RowType = DataControlRowType.Footer) Then
					Me.getTotalHandlinIn()
					e.Row.Cells(5).Text = String.Concat(Conversions.ToString(Me.handlingINtotalBox), " Boxes")
					e.Row.Cells(8).Text = Me.HandlingInTotal.ToString("c", CultureInfo.GetCultureInfo("en-PH"))
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub GridViewMonthlyStorage_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				Dim label As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelQuantity"), System.Web.UI.WebControls.Label)
				Dim str As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelTotal"), System.Web.UI.WebControls.Label)
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					e.Row.Cells(6).Text = "X"
					Dim num As Double = Convert.ToDouble(label.Text) * Convert.ToDouble(e.Row.Cells(7).Text)
					str.Text = num.ToString()
				End If
				If (e.Row.RowType = DataControlRowType.Footer) Then
					Me.getTotalStorageFee()
					e.Row.Cells(5).Text = String.Concat(Conversions.ToString(Me.totalBoxes), " Boxes")
					e.Row.Cells(8).Text = Me.MonthlyStorageTotal.ToString("c", CultureInfo.GetCultureInfo("en-PH"))
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub GridViewOthers_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				Dim label As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelQuantity"), System.Web.UI.WebControls.Label)
				Dim str As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelTotal"), System.Web.UI.WebControls.Label)
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					e.Row.Cells(6).Text = "X"
					Dim num As Double = Convert.ToDouble(label.Text) * Convert.ToDouble(e.Row.Cells(7).Text)
					str.Text = num.ToString()
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			Try
				If (e.Row.RowType = DataControlRowType.Footer) Then
					Me.getOthers()
					e.Row.Cells(5).Text = String.Concat(Conversions.ToString(Me.othersTotalBox), " Boxes")
					e.Row.Cells(8).Text = Me.othersTotal.ToString("c", CultureInfo.GetCultureInfo("en-PH"))
				End If
			Catch exception1 As System.Exception
				ProjectData.SetProjectError(exception1)
				ProjectData.ClearProjectError()
			End Try
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
			Me.Alerts()
			Me.messages()
			If (MyBase.IsPostBack) Then
				Me.GridViewInvoiceList.DataBind()
				If (Not Me.CheckBox1.Checked) Then
					Me.Session("vat") = 0
					Me.SqlDataSourceVat.Update()
				Else
					Me.Session("vat") = 1
					Me.SqlDataSourceVat.Update()
				End If
			End If
			If (Not MyBase.IsPostBack) Then
				Me.FormView1.DataSourceID = Me.SqlDataSourceHandlingIn.ID
				Me.FormView1.DataBind()
			End If
		End Sub

		Private Sub SqlDataSourceInsertInvoice_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.Session("InvoiceId") = RuntimeHelpers.GetObjectValue(e.Command.Parameters("@InvoiceId").Value)
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceMonthlyStorage.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			While sqlDataReader.Read()
				Me.Session("ItemType") = "MonthlyStorageFee"
				Me.Session("Item") = Operators.ConcatenateObject("Storage Fee ", sqlDataReader("Department"))
				Me.Session("Quantity") = RuntimeHelpers.GetObjectValue(sqlDataReader("Expr1"))
				Me.Session("Rate") = 11
				Me.SqlDataSourceInsertItem.Insert()
			End While
			sqlDataReader.Close()
			Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourcePickupBoxNewStorage.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			While sqlDataReader1.Read()
				Me.Session("ItemType") = "ItemHandling_HandlingIn"
				Me.Session("Item") = "Pick-up for Box  New For Storage"
				Me.Session("Quantity") = RuntimeHelpers.GetObjectValue(sqlDataReader1("BoxCount"))
				Me.Session("Rate") = 0
				Me.SqlDataSourceInsertItem.Insert()
			End While
			sqlDataReader1.Close()
			Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceHandlingINInsert.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			While sqlDataReader2.Read()
				Me.Session("ItemType") = "ItemHandling_HandlingIn"
				If (Operators.ConditionalCompareObjectEqual(sqlDataReader2("isRush"), "NO", False)) Then
					Me.Session("Item") = "Pick-up for Box  Return (Regular)"
					Me.Session("Quantity") = RuntimeHelpers.GetObjectValue(sqlDataReader2("BoxCount"))
					Me.Session("Rate") = 50
				ElseIf (Operators.ConditionalCompareObjectEqual(sqlDataReader2("isRush"), "YES", False)) Then
					Me.Session("Item") = "Pick-up for Box  Return (Rush)"
					Me.Session("Quantity") = RuntimeHelpers.GetObjectValue(sqlDataReader2("BoxCount"))
					Me.Session("Rate") = 100
				End If
				Me.SqlDataSourceInsertItem.Insert()
			End While
			sqlDataReader2.Close()
			Dim sqlDataReader3 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceHandlingOutInsert.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			While sqlDataReader3.Read()
				Me.Session("ItemType") = "ItemHandling_HandlingOut"
				If (Operators.ConditionalCompareObjectEqual(sqlDataReader3("isRush"), "NO", False)) Then
					Me.Session("Item") = "Box Delivery (Regular)"
					Me.Session("Quantity") = RuntimeHelpers.GetObjectValue(sqlDataReader3("BoxCount"))
					Me.Session("Rate") = 50
				ElseIf (Operators.ConditionalCompareObjectEqual(sqlDataReader3("isRush"), "YES", False)) Then
					Me.Session("Item") = "Box Delivery (Rush)"
					Me.Session("Quantity") = RuntimeHelpers.GetObjectValue(sqlDataReader3("BoxCount"))
					Me.Session("Rate") = 100
				End If
				Me.SqlDataSourceInsertItem.Insert()
			End While
			sqlDataReader3.Close()
		End Sub
	End Class
End Namespace