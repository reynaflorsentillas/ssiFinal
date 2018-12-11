Imports System
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class exportcodes
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

		Protected Overridable Property form1 As HtmlForm

		Protected Overridable Property GridView1 As GridView

		Protected Overridable Property SqlDataSource1 As SqlDataSource

		Protected Overridable Property SqlDataSource2 As SqlDataSource

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			MyBase.Response.Clear()
			MyBase.Response.Buffer = True
			MyBase.Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.csv")
			MyBase.Response.Charset = ""
			MyBase.Response.ContentType = "application/text"
			Me.GridView1.AllowPaging = False
			Me.GridView1.DataBind()
			Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
			Dim count As Integer = Me.GridView1.Columns.Count - 1
			Dim num As Integer = 0
			Do
				stringBuilder.Append(Me.GridView1.Columns(num).HeaderText)
				num = num + 1
			Loop While num <= count
			stringBuilder.Append("" & VbCrLf & "")
			Dim count1 As Integer = Me.GridView1.Rows.Count - 1
			Dim num1 As Integer = 0
			Do
				Dim count2 As Integer = Me.GridView1.Columns.Count - 1
				Dim num2 As Integer = 0
				Do
					stringBuilder.Append(Me.GridView1.Rows(num1).Cells(num2).Text)
					num2 = num2 + 1
				Loop While num2 <= count2
				stringBuilder.Append("" & VbCrLf & "")
				num1 = num1 + 1
			Loop While num1 <= count1
			MyBase.Response.Output.Write(stringBuilder.ToString())
			MyBase.Response.Flush()
			MyBase.Response.[End]()
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub
	End Class
End Namespace