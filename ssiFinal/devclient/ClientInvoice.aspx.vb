Imports Microsoft.AspNet.Identity
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ClientInvoice
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
        Private _GridViewItemHandlingIn As GridView
        Private _GridViewInvoiceList As GridView
        Private _GridViewHandlingOut As GridView

        Protected Overridable Property GridViewHandlingOut As GridView
            Get
                Return Me._GridViewHandlingOut
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.GridView)
                Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridViewHandlingOut_RowDataBound)
                Dim gridView As System.Web.UI.WebControls.GridView = Me._GridViewHandlingOut
                If (gridView IsNot Nothing) Then
                    RemoveHandler gridView.RowDataBound, gridViewRowEventHandler
                End If
                Me._GridViewHandlingOut = value
                gridView = Me._GridViewHandlingOut
                If (gridView IsNot Nothing) Then
                    AddHandler gridView.RowDataBound, gridViewRowEventHandler
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

		Protected Overridable Property hdUserEmail As HiddenField

		Protected Overridable Property hdUserFullName As HiddenField

		Protected Overridable Property HiddenField1 As HiddenField

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

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property SqlDataSourceAlerts As SqlDataSource

		Protected Overridable Property SqlDataSourceCompanyList As SqlDataSource

		Protected Overridable Property SqlDataSourceGetClientInfo As SqlDataSource

		Protected Overridable Property SqlDataSourceGetCompany As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingIn As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingINInsert As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingOut As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingOutInsert As SqlDataSource

		Protected Overridable Property SqlDataSourceInsertInvoice As SqlDataSource

		Protected Overridable Property SqlDataSourceInsertItem As SqlDataSource

		Protected Overridable Property SqlDataSourceInvoiceList As SqlDataSource

		Protected Overridable Property SqlDataSourceMessages As SqlDataSource

		Protected Overridable Property SqlDataSourceMonthlyStorage As SqlDataSource

		Protected Overridable Property SqlDataSourceOthers As SqlDataSource

		Protected Overridable Property SqlDataSourcePickupBoxNewStorage As SqlDataSource

		Protected Overridable Property SqlDataSourceStorageFee As SqlDataSource

		Protected Overridable Property SqlDataSourceVat As SqlDataSource

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

		Protected Sub getOthers()
			' 
			' Current member / type: System.Void ssiFinal.ClientInvoice::getOthers()
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
			' Current member / type: System.Void ssiFinal.ClientInvoice::getTotalHandlingOut()
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
			' Current member / type: System.Void ssiFinal.ClientInvoice::getTotalHandlinIn()
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
			' Current member / type: System.Void ssiFinal.ClientInvoice::getTotalStorageFee()
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
					e.Row.Cells(5).Text = "X"
					Dim num As Double = Convert.ToDouble(label.Text) * Convert.ToDouble(e.Row.Cells(6).Text)
					str.Text = num.ToString()
				End If
				If (e.Row.RowType = DataControlRowType.Footer) Then
					Me.getTotalHandlingOut()
					e.Row.Cells(4).Text = String.Concat(Conversions.ToString(Me.handlingOuttotalBox), " Boxes")
					e.Row.Cells(7).Text = Me.handlingOutTotal.ToString("c", CultureInfo.GetCultureInfo("en-PH"))
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Private Sub GridViewInvoiceList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Try
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
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceVat.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			If (sqlDataReader.Read()) Then
				Me.HiddenField1.Value = Conversions.ToString(sqlDataReader("Vat"))
			End If
		End Sub

		Private Sub GridViewItemHandlingIn_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				Dim label As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelQuantity"), System.Web.UI.WebControls.Label)
				Dim str As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("LabelTotal"), System.Web.UI.WebControls.Label)
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					e.Row.Cells(5).Text = "X"
					Dim num As Double = Convert.ToDouble(label.Text) * Convert.ToDouble(e.Row.Cells(6).Text)
					str.Text = num.ToString()
				End If
				If (e.Row.RowType = DataControlRowType.Footer) Then
					Me.getTotalHandlinIn()
					e.Row.Cells(4).Text = String.Concat(Conversions.ToString(Me.handlingINtotalBox), " Boxes")
					e.Row.Cells(7).Text = Me.HandlingInTotal.ToString("c", CultureInfo.GetCultureInfo("en-PH"))
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
					e.Row.Cells(5).Text = "X"
					Dim num As Double = Convert.ToDouble(label.Text) * Convert.ToDouble(e.Row.Cells(6).Text)
					str.Text = num.ToString()
				End If
				If (e.Row.RowType = DataControlRowType.Footer) Then
					Me.getTotalStorageFee()
					e.Row.Cells(4).Text = String.Concat(Conversions.ToString(Me.totalBoxes), " Boxes")
					e.Row.Cells(7).Text = Me.MonthlyStorageTotal.ToString("c", CultureInfo.GetCultureInfo("en-PH"))
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
					e.Row.Cells(5).Text = "X"
					Dim num As Double = Convert.ToDouble(label.Text) * Convert.ToDouble(e.Row.Cells(6).Text)
					str.Text = num.ToString()
				End If
				If (e.Row.RowType = DataControlRowType.Footer) Then
					Me.getOthers()
					e.Row.Cells(4).Text = String.Concat(Conversions.ToString(Me.othersTotalBox), " Boxes")
					e.Row.Cells(7).Text = Me.othersTotal.ToString("c", CultureInfo.GetCultureInfo("en-PH"))
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
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
			Me.Alerts()
			Me.messages()
			If (Not MyBase.IsPostBack) Then
				Me.Session("clientUserName") = MyBase.User.Identity.GetUserName()
				Dim sqlDataReader1 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetClientInfo.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
				If (sqlDataReader1.Read()) Then
					Me.Session("CompanyCode") = RuntimeHelpers.GetObjectValue(sqlDataReader1("CompanyCode"))
					Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceGetCompany.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
					sqlDataReader2.Read()
					Me.Session("CompanyName") = RuntimeHelpers.GetObjectValue(sqlDataReader2("CompanyName"))
					Me.GridViewInvoiceList.DataBind()
					sqlDataReader2.Close()
				End If
				sqlDataReader1.Close()
			End If
		End Sub
	End Class
End Namespace