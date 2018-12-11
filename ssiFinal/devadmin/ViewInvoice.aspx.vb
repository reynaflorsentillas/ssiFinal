Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ViewInvoice
		Inherits System.Web.UI.Page
		Private StorageMonthlyFeeTotal As Double

		Private HandlingIN As Double

		Private HandlingOut As Double

		Private Others As Double
        Private _GridView4 As GridView
        Private _GridView3 As GridView
        Private _GridView2 As GridView
        Private _GridView1 As GridView
        Private _FormView1 As FormView
        Private _ButtonGenerateInvoice As Button
        Private _GridView5 As GridView

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

        Protected Overridable Property CompanyNameLabel As Label

		Protected Overridable Property DropDownList1 As DropDownList

		Protected Overridable Property DropDownList2 As DropDownList

		Protected Overridable Property FormView1 As FormView
			Get
				Return Me._FormView1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.FormView)
				Dim formViewInsertedEventHandler As System.Web.UI.WebControls.FormViewInsertedEventHandler = New System.Web.UI.WebControls.FormViewInsertedEventHandler(AddressOf Me.FormView1_ItemInserted)
				Dim formView As System.Web.UI.WebControls.FormView = Me._FormView1
				If (formView IsNot Nothing) Then
					RemoveHandler formView.ItemInserted,  formViewInsertedEventHandler
				End If
				Me._FormView1 = value
				formView = Me._FormView1
				If (formView IsNot Nothing) Then
					AddHandler formView.ItemInserted,  formViewInsertedEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridView1 As GridView
			Get
				Return Me._GridView1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridView1_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView1
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridView1 = value
				gridView = Me._GridView1
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridView2 As GridView
			Get
				Return Me._GridView2
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridView2_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView2
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridView2 = value
				gridView = Me._GridView2
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridView3 As GridView
			Get
				Return Me._GridView3
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridView3_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView3
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridView3 = value
				gridView = Me._GridView3
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridView4 As GridView
			Get
				Return Me._GridView4
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.GridView4_SelectedIndexChanged)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView4
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.SelectedIndexChanged,  eventHandler
				End If
				Me._GridView4 = value
				gridView = Me._GridView4
				If (gridView IsNot Nothing) Then
					AddHandler gridView.SelectedIndexChanged,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property GridView5 As GridView
			Get
				Return Me._GridView5
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.GridView)
				Dim gridViewRowEventHandler As System.Web.UI.WebControls.GridViewRowEventHandler = New System.Web.UI.WebControls.GridViewRowEventHandler(AddressOf Me.GridView5_RowDataBound)
				Dim gridView As System.Web.UI.WebControls.GridView = Me._GridView5
				If (gridView IsNot Nothing) Then
					RemoveHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
				Me._GridView5 = value
				gridView = Me._GridView5
				If (gridView IsNot Nothing) Then
					AddHandler gridView.RowDataBound,  gridViewRowEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property Label1 As Label

		Protected Overridable Property Label2 As Label

		Protected Overridable Property Label3 As Label

		Protected Overridable Property LabelItemHandling As Label

		Protected Overridable Property LabelStorage As Label

		Protected Overridable Property SqlDataSourceCompany As SqlDataSource

		Protected Overridable Property SqlDataSourceDateRange As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingIn As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingOut As SqlDataSource

		Protected Overridable Property SqlDataSourceInsertInvoice As SqlDataSource

		Protected Overridable Property SqlDataSourceOthers As SqlDataSource

		Protected Overridable Property SqlDataSourceSelectInvoice As SqlDataSource

		Protected Overridable Property SqlDataSourceStorageFee As SqlDataSource

		Protected Overridable Property TextBoxFrom As TextBox

		Protected Overridable Property TextBoxTo As TextBox

		Protected Overridable Property TransactionPeriodLabel As Label

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me.StorageMonthlyFeeTotal = 0
			Me.HandlingIN = 0
			Me.HandlingOut = 0
			Me.Others = 0
		End Sub

		Protected Sub ButtonGenerateInvoice_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("CompanyName") = Me.DropDownList2.SelectedItem.Text
			Me.Session("DateRange") = String.Concat(Me.TextBoxFrom.Text, "-", Me.TextBoxTo.Text)
			Me.SqlDataSourceInsertInvoice.Insert()
		End Sub

		Private Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As FormViewInsertedEventArgs)
			Me.GridView5.DataBind()
			Me.GridView1.DataBind()
			Me.GridView2.DataBind()
			Me.GridView3.DataBind()
		End Sub

		Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			' 
			' Current member / type: System.Void ssiFinal.ViewInvoice::GridView1_RowDataBound(System.Object,System.Web.UI.WebControls.GridViewRowEventArgs)
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void GridView1_RowDataBound(System.Object,System.Web.UI.WebControls.GridViewRowEventArgs)
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

		Private Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			' 
			' Current member / type: System.Void ssiFinal.ViewInvoice::GridView2_RowDataBound(System.Object,System.Web.UI.WebControls.GridViewRowEventArgs)
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void GridView2_RowDataBound(System.Object,System.Web.UI.WebControls.GridViewRowEventArgs)
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

		Private Sub GridView3_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			' 
			' Current member / type: System.Void ssiFinal.ViewInvoice::GridView3_RowDataBound(System.Object,System.Web.UI.WebControls.GridViewRowEventArgs)
			' File path: C:\Users\Rein Duque\Downloads\ssiFinal\Content\C_C\Users\reynaflor.sentillas\Source\Repos\ssiFinal\ssiFinal\ssiFinal\obj\Release\Package\PackageTmp\bin\ssiFinal.dll
			' 
			' Product version: 2018.2.803.0
			' Exception in: System.Void GridView3_RowDataBound(System.Object,System.Web.UI.WebControls.GridViewRowEventArgs)
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

		Private Sub GridView4_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim strArrays(-1) As String
			Dim sqlDataReader As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceDateRange.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
			If (sqlDataReader.Read()) Then
				strArrays = sqlDataReader("DateRange").ToString().Split(New Char() { "-"C })
				Me.CompanyNameLabel.Text = Conversions.ToString(sqlDataReader("CompanyName"))
			End If
			Dim transactionPeriodLabel As Label = Me.TransactionPeriodLabel
			Dim dateTime As System.DateTime = Convert.ToDateTime(strArrays(0))
			Dim str As String = dateTime.ToString("MMMM d")
			dateTime = Convert.ToDateTime(strArrays(1))
			transactionPeriodLabel.Text = String.Concat(str, " to ", dateTime.ToString("MMMM d yyyy"))
		End Sub

		Private Sub GridView5_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
			Try
				If (e.Row.RowType = DataControlRowType.DataRow) Then
					Dim item As TableCell = e.Row.Cells(7)
					Dim num As Double = Convert.ToDouble(e.Row.Cells(6).Text) * Convert.ToDouble(e.Row.Cells(5).Text)
					item.Text = If(num.ToString("c", CultureInfo.GetCultureInfo("en-PH")), "")
				End If
			Catch exception As System.Exception
				ProjectData.SetProjectError(exception)
				ProjectData.ClearProjectError()
			End Try
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace