Imports System
Imports System.Web.UI

Namespace ssiFinal
	Public Class WebForm4
		Inherits System.Web.UI.Page
		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace