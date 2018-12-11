Imports System
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class TransactionRePickup
		Inherits System.Web.UI.Page
		Protected Overridable Property GridView1 As GridView

		Protected Overridable Property SqlDataSourceTransactionRepickup As SqlDataSource

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace