Imports System
Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class WebForm2
		Inherits System.Web.UI.Page

        Private _Button1 As Button

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

        Protected Overridable Property DropDownList1 As DropDownList

		Protected Overridable Property GridView1 As GridView

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property TextBox1 As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (Me.DropDownList1.SelectedIndex = 0) Then
				Me.SqlDataSource1.FilterExpression = String.Concat("Status = '", Me.TextBox1.Text, "'")
			ElseIf (Me.DropDownList1.SelectedIndex = 1) Then
				Me.SqlDataSource1.FilterExpression = String.Concat("Type = '", Me.TextBox1.Text, "'")
			ElseIf (Me.DropDownList1.SelectedIndex = 2) Then
				Me.SqlDataSource1.FilterExpression = String.Concat("Id = '", Me.TextBox1.Text, "'")
			End If
			Me.SqlDataSource1.[Select](DataSourceSelectArguments.Empty)
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace