Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class WebForm3
		Inherits System.Web.UI.Page
		Private finalTotal As Integer

		Private handlingInTotal As Integer

		Private handlingOutTotal As Integer
        Private _ButtonGenerateInvoice As Button
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

        Protected Overridable Property DropDownList1 As DropDownList

		Protected Overridable Property Label1 As Label

		Protected Overridable Property Label2 As Label

		Protected Overridable Property Label3 As Label

		Protected Overridable Property SqlDataSourceCompany As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingIn As SqlDataSource

		Protected Overridable Property SqlDataSourceHandlingOut As SqlDataSource

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

		Protected Overridable Property SqlDataSourceMonthlyStorage As SqlDataSource

		Protected Overridable Property SqlDataSourcePickupBoxNewStorage As SqlDataSource

		Protected Overridable Property TextBoxFrom As TextBox

		Protected Overridable Property TextBoxTo As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
			Me.finalTotal = 0
			Me.handlingInTotal = 0
			Me.handlingOutTotal = 0
		End Sub

		Protected Sub ButtonGenerateInvoice_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("CompanyName") = Me.DropDownList1.SelectedItem.Text
			Me.Session("DateRange") = String.Concat(Me.TextBoxFrom.Text, "-", Me.TextBoxTo.Text)
			Me.SqlDataSourceInsertInvoice.Insert()
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
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
			Dim sqlDataReader2 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceHandlingIn.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
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
			Dim sqlDataReader3 As System.Data.SqlClient.SqlDataReader = DirectCast(Me.SqlDataSourceHandlingOut.[Select](DataSourceSelectArguments.Empty), System.Data.SqlClient.SqlDataReader)
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