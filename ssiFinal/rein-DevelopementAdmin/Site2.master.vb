Imports System
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Site2
		Inherits System.Web.UI.MasterPage
		Protected Overridable Property ContentPlaceHolder1 As ContentPlaceHolder

		Protected Overridable Property DropDownList1 As DropDownList

		Protected Overridable Property form1 As HtmlForm

		Protected Overridable Property head As ContentPlaceHolder

		Protected Overridable Property TextBox1 As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace