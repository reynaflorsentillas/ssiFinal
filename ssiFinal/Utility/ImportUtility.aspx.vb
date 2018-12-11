Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class ImportUtility
		Inherits System.Web.UI.Page
		Public errMsg As String
        Private _ButtonImport As Button
        Private _ButtonMasterLogin As Button
        Private _ButtonReset As Button
        Private _ButtonUpload As Button

        Protected Overridable Property ButtonImport As Button
            Get
                Return Me._ButtonImport
            End Get
            <MethodImpl(MethodImplOptions.Synchronized)>
            Set(ByVal value As System.Web.UI.WebControls.Button)
                Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonImport_Click)
                Dim button As System.Web.UI.WebControls.Button = Me._ButtonImport
                If (button IsNot Nothing) Then
                    RemoveHandler button.Click, eventHandler
                End If
                Me._ButtonImport = value
                button = Me._ButtonImport
                If (button IsNot Nothing) Then
                    AddHandler button.Click, eventHandler
                End If
            End Set
        End Property

        Protected Overridable Property ButtonMasterLogin As Button
			Get
				Return Me._ButtonMasterLogin
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonMasterLogin_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonMasterLogin
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonMasterLogin = value
				button = Me._ButtonMasterLogin
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ButtonReset As Button
			Get
				Return Me._ButtonReset
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonReset_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonReset
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonReset = value
				button = Me._ButtonReset
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property ButtonUpload As Button
			Get
				Return Me._ButtonUpload
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.Button)
				Dim eventHandler As System.EventHandler = New System.EventHandler(AddressOf Me.ButtonUpload_Click)
				Dim button As System.Web.UI.WebControls.Button = Me._ButtonUpload
				If (button IsNot Nothing) Then
					RemoveHandler button.Click,  eventHandler
				End If
				Me._ButtonUpload = value
				button = Me._ButtonUpload
				If (button IsNot Nothing) Then
					AddHandler button.Click,  eventHandler
				End If
			End Set
		End Property

		Protected Overridable Property DropDownListImport As DropDownList

		Protected Overridable Property FileUploadImport As FileUpload

		Protected Overridable Property form1 As HtmlForm

		Protected Overridable Property GridViewMasterlist As GridView

		Protected Overridable Property GridViewUsers As GridView

		Protected Overridable Property LabelImportStatus As Label

		Protected Overridable Property LabelMasterStatus As Label

		Protected Overridable Property PanelImport As Panel

		Protected Overridable Property PanelMsterLogin As Panel

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property SqlDataSourceCheckUser As SqlDataSource

		Protected Overridable Property SqlDataSourceMasterlist As SqlDataSource

		Protected Overridable Property TextBoxMasterPassword As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub ButtonImport_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim enumerator As IEnumerator = Nothing
			Dim enumerator1 As IEnumerator = Nothing
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownListImport.SelectedValue, "Users", False) <> 0) Then
				If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownListImport.SelectedValue, "Masterlist", False) = 0) Then
					Dim num As Integer = 0
					Try
						enumerator1 = Me.GridViewMasterlist.Rows.GetEnumerator()
						While enumerator1.MoveNext()
							Dim current As System.Web.UI.WebControls.TableRow = DirectCast(enumerator1.Current, System.Web.UI.WebControls.TableRow)
							Dim str As String = HttpUtility.HtmlDecode(current.Cells(0).Text)
							Dim str1 As String = HttpUtility.HtmlDecode(current.Cells(1).Text)
							Dim str2 As String = HttpUtility.HtmlDecode(current.Cells(2).Text)
							Dim str3 As String = HttpUtility.HtmlDecode(current.Cells(3).Text)
							Dim str4 As String = HttpUtility.HtmlDecode(current.Cells(4).Text)
							Dim str5 As String = HttpUtility.HtmlDecode(current.Cells(5).Text)
							Dim str6 As String = HttpUtility.HtmlDecode(current.Cells(6).Text)
							Dim str7 As String = HttpUtility.HtmlDecode(current.Cells(7).Text)
							Dim str8 As String = HttpUtility.HtmlDecode(current.Cells(8).Text)
							Dim str9 As String = HttpUtility.HtmlDecode(current.Cells(9).Text)
							Dim str10 As String = HttpUtility.HtmlDecode(current.Cells(10).Text)
							Dim str11 As String = HttpUtility.HtmlDecode(current.Cells(11).Text)
							Dim str12 As String = HttpUtility.HtmlDecode(current.Cells(12).Text)
							Dim dateTime As System.DateTime = System.DateTime.UtcNow.AddHours(8)
							Dim str13 As String = HttpUtility.HtmlDecode(current.Cells(14).Text)
							Try
								Me.SqlDataSourceMasterlist.InsertParameters("CompanyCode").DefaultValue = str1
								Me.SqlDataSourceMasterlist.InsertParameters("Department").DefaultValue = str2
								Me.SqlDataSourceMasterlist.InsertParameters("BarCode").DefaultValue = str3
								Me.SqlDataSourceMasterlist.InsertParameters("BoxNumber").DefaultValue = str4
								Me.SqlDataSourceMasterlist.InsertParameters("Description").DefaultValue = str5
								Me.SqlDataSourceMasterlist.InsertParameters("Status").DefaultValue = str6
								Me.SqlDataSourceMasterlist.InsertParameters("LocationCode").DefaultValue = str7
								Me.SqlDataSourceMasterlist.InsertParameters("DestructionDate").DefaultValue = str8
								Me.SqlDataSourceMasterlist.InsertParameters("StockReceipt_id").DefaultValue = str9
								Me.SqlDataSourceMasterlist.InsertParameters("QRCode").DefaultValue = str10
								Me.SqlDataSourceMasterlist.InsertParameters("Retention").DefaultValue = str11
								Me.SqlDataSourceMasterlist.InsertParameters("CreatedBy").DefaultValue = str12
								Me.SqlDataSourceMasterlist.InsertParameters("CreatedDate").DefaultValue = Conversions.ToString(dateTime)
								Me.SqlDataSourceMasterlist.InsertParameters("ModifiedBy").DefaultValue = str13
								Me.SqlDataSourceMasterlist.Insert()
								num = num + 1
							Catch exception1 As System.Exception
								ProjectData.SetProjectError(exception1)
								Dim exception As System.Exception = exception1
								Me.renderErrMsgs(String.Concat(exception.Message.ToString(), str))
								ProjectData.ClearProjectError()
							End Try
						End While
					Finally
						If (TypeOf enumerator1 Is IDisposable) Then
							TryCast(enumerator1, IDisposable).Dispose()
						End If
					End Try
					Me.LabelImportStatus.Text = String.Concat("DONE! ", num.ToString(), " items were imported.")
				End If
				Return
			End If
			Dim num1 As Integer = 0
			Try
				enumerator = Me.GridViewUsers.Rows.GetEnumerator()
				While enumerator.MoveNext()
					Dim tableRow As System.Web.UI.WebControls.TableRow = DirectCast(enumerator.Current, System.Web.UI.WebControls.TableRow)
					Dim str14 As String = HttpUtility.HtmlDecode(tableRow.Cells(0).Text)
					Dim str15 As String = HttpUtility.HtmlDecode(tableRow.Cells(1).Text)
					Dim str16 As String = HttpUtility.HtmlDecode(tableRow.Cells(2).Text)
					Dim str17 As String = HttpUtility.HtmlDecode(tableRow.Cells(3).Text)
					Dim str18 As String = HttpUtility.HtmlDecode(tableRow.Cells(4).Text)
					Dim str19 As String = HttpUtility.HtmlDecode(tableRow.Cells(5).Text)
					Dim str20 As String = HttpUtility.HtmlDecode(tableRow.Cells(6).Text)
					Try
						Me.Validate()
						If (MyBase.IsValid) Then
							Dim userManager As ApplicationUserManager = Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
							Dim applicationUser As ssiFinal.ApplicationUser = New ssiFinal.ApplicationUser() With
							{
								.UserName = str19,
								.Email = str19
							}
							Dim identityResult As Microsoft.AspNet.Identity.IdentityResult = userManager.Create(applicationUser, str20)
							If (Not identityResult.Succeeded) Then
								Me.renderErrMsgs(identityResult.Errors.FirstOrDefault())
							Else
								If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str15, "ADMIN", False) = 0) Then
									userManager.AddToRole(applicationUser.Id, "ssiAdmin")
								ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str15, "Employee", False) = 0) Then
									userManager.AddToRole(applicationUser.Id, "ssiEmployee")
								ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str15, "Client Supervisor", False) = 0) Then
									userManager.AddToRole(applicationUser.Id, "clientSupervisor")
									Me.SqlDataSource1.InsertParameters("username").DefaultValue = str19
									Me.SqlDataSource1.InsertParameters("DepartmentCode").DefaultValue = str16
									Me.SqlDataSource1.InsertParameters("FirstName").DefaultValue = str17
									Me.SqlDataSource1.InsertParameters("LastName").DefaultValue = str18
									Me.SqlDataSource1.InsertParameters("email").DefaultValue = str19
									Me.SqlDataSource1.InsertParameters("CompanyCode").DefaultValue = str14
									Me.SqlDataSource1.Insert()
								ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str15, "Client", False) = 0) Then
									userManager.AddToRole(applicationUser.Id, "ssiClient")
									Me.SqlDataSource1.InsertParameters("username").DefaultValue = str19
									Me.SqlDataSource1.InsertParameters("DepartmentCode").DefaultValue = str16
									Me.SqlDataSource1.InsertParameters("FirstName").DefaultValue = str17
									Me.SqlDataSource1.InsertParameters("LastName").DefaultValue = str18
									Me.SqlDataSource1.InsertParameters("email").DefaultValue = str19
									Me.SqlDataSource1.InsertParameters("CompanyCode").DefaultValue = str14
									Me.SqlDataSource1.Insert()
								End If
								num1 = num1 + 1
							End If
						End If
					Catch exception2 As System.Exception
						ProjectData.SetProjectError(exception2)
						Me.renderErrMsgs(exception2.Message.ToString())
						ProjectData.ClearProjectError()
					End Try
				End While
			Finally
				If (TypeOf enumerator Is IDisposable) Then
					TryCast(enumerator, IDisposable).Dispose()
				End If
			End Try
			Me.LabelImportStatus.Text = String.Concat("DONE! ", num1.ToString(), " users were imported.")
		End Sub

		Protected Sub ButtonMasterLogin_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.TextBoxMasterPassword.Text, "Cryptic_Black2017", False) <> 0) Then
				Me.LabelMasterStatus.Text = "Incorrect Master Password. Please try again."
				Return
			End If
			Me.LabelMasterStatus.Text = "Logged In!"
			Me.PanelImport.Visible = True
		End Sub

		Protected Sub ButtonReset_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Redirect(MyBase.Request.RawUrl)
		End Sub

		Protected Sub ButtonUpload_Click(ByVal sender As Object, ByVal e As EventArgs)
			Try
				Try
					If (Me.FileUploadImport.HasFile) Then
						Dim fileName As String = Path.GetFileName(Me.FileUploadImport.PostedFile.FileName)
						Dim extension As String = Path.GetExtension(Me.FileUploadImport.PostedFile.FileName)
						Dim str As String = "Files/"
						If (Not (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(extension, ".xls", False) = 0 Or Microsoft.VisualBasic.CompilerServices.Operators.CompareString(extension, ".xlsx", False) = 0)) Then
							Me.renderErrMsgs("You have uploaded an invalid file. You can upload .xls or .xlsx only.")
						Else
							Dim str1 As String = MyBase.Server.MapPath(String.Concat(str, fileName))
							Me.FileUploadImport.SaveAs(str1)
							Me.Import_To_Grid(str1, extension, "Yes")
						End If
					End If
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Me.renderErrMsgs(exception.Message.ToString())
					ProjectData.ClearProjectError()
				End Try
			Finally
				Me.DropDownListImport.Enabled = False
				Me.FileUploadImport.Enabled = False
				Me.ButtonUpload.Enabled = False
			End Try
		End Sub

		Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
			Dim item As DataTable = Nothing
			Dim connectionString As String = ""
			Dim str As String = Extension
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, ".xls", False) = 0) Then
				connectionString = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str, ".xlsx", False) = 0) Then
				connectionString = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString
			End If
			connectionString = String.Format(connectionString, FilePath, isHDR)
			Dim oleDbConnection As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(connectionString)
			Dim oleDbCommand As System.Data.OleDb.OleDbCommand = New System.Data.OleDb.OleDbCommand()
			Dim oleDbDataAdapter As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter()
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownListImport.SelectedValue, "Users", False) = 0) Then
				item = DirectCast(Me.ViewState("currentTable"), DataTable)
			ElseIf (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownListImport.SelectedValue, "Masterlist", False) = 0) Then
				item = DirectCast(Me.ViewState("tableMasterlist"), DataTable)
			End If
			oleDbCommand.Connection = oleDbConnection
			oleDbConnection.Open()
			Dim str1 As String = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()
			oleDbConnection.Close()
			oleDbConnection.Open()
			oleDbCommand.CommandText = String.Concat("SELECT * From [", str1, "]")
			oleDbDataAdapter.SelectCommand = oleDbCommand
			oleDbDataAdapter.Fill(item)
			oleDbConnection.Close()
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownListImport.SelectedValue, "Users", False) = 0) Then
				Me.GridViewUsers.DataSource = item
				Me.GridViewUsers.DataBind()
				Me.ViewState("currentTable") = item
				Return
			End If
			If (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Me.DropDownListImport.SelectedValue, "Masterlist", False) = 0) Then
				Me.GridViewMasterlist.DataSource = item
				Me.GridViewMasterlist.DataBind()
				Me.ViewState("tableMasterlist") = item
			End If
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			If (Not MyBase.IsPostBack) Then
				Try
					Dim dataTable As System.Data.DataTable = New System.Data.DataTable()
					dataTable.Columns.Add("Account Access", GetType(String))
					dataTable.Columns.Add("Role", GetType(String))
					dataTable.Columns.Add("Department", GetType(String))
					dataTable.Columns.Add("First Name", GetType(String))
					dataTable.Columns.Add("Last Name", GetType(String))
					dataTable.Columns.Add("User Name", GetType(String))
					dataTable.Columns.Add("Password", GetType(String))
					Me.GridViewUsers.DataSource = dataTable
					Me.GridViewUsers.DataBind()
					Me.ViewState("currentTable") = dataTable
				Catch exception As System.Exception
					ProjectData.SetProjectError(exception)
					Me.renderErrMsgs(exception.Message.ToString())
					ProjectData.ClearProjectError()
				End Try
				Try
					Dim dataTable1 As System.Data.DataTable = New System.Data.DataTable()
					dataTable1.Columns.Add("MasterlistId", GetType(String))
					dataTable1.Columns.Add("CompanyCode", GetType(String))
					dataTable1.Columns.Add("Department", GetType(String))
					dataTable1.Columns.Add("BarCode", GetType(String))
					dataTable1.Columns.Add("BoxNumber", GetType(String))
					dataTable1.Columns.Add("Description", GetType(String))
					dataTable1.Columns.Add("Status", GetType(String))
					dataTable1.Columns.Add("LocationCode", GetType(String))
					dataTable1.Columns.Add("DestructionDate", GetType(String))
					dataTable1.Columns.Add("StockReceipt_id", GetType(String))
					dataTable1.Columns.Add("QRCode", GetType(String))
					dataTable1.Columns.Add("Retention", GetType(String))
					dataTable1.Columns.Add("CreatedBy", GetType(String))
					dataTable1.Columns.Add("CreatedDate", GetType(String))
					dataTable1.Columns.Add("ModifiedBy", GetType(String))
					dataTable1.Columns.Add("ModifiedDate", GetType(String))
					Me.GridViewMasterlist.DataSource = dataTable1
					Me.GridViewMasterlist.DataBind()
					Me.ViewState("tableMasterlist") = dataTable1
				Catch exception1 As System.Exception
					ProjectData.SetProjectError(exception1)
					Me.renderErrMsgs(exception1.Message.ToString())
					ProjectData.ClearProjectError()
				End Try
			End If
		End Sub

		Public Sub renderErrMsgs(ByVal thisErrMsg As String)
			' 
			' Current member / type: System.Void ssiFinal.ImportUtility::renderErrMsgs(System.String)
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
	End Class
End Namespace