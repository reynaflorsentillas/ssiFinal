Imports Microsoft.AspNet.Identity
Imports System
Imports System.Data.Common
Imports System.Runtime.CompilerServices
Imports System.Security.Principal
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class messages
		Inherits System.Web.UI.Page

        Private _Button1 As Button
        Private _SqlDataSource1 As SqlDataSource

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

        Protected Overridable Property SqlDataSource1 As SqlDataSource
			Get
				Return Me._SqlDataSource1
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSource1_Inserted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSource1
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSource1 = value
				sqlDataSource = Me._SqlDataSource1
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property SqlDataSource2 As SqlDataSource

		Protected Overridable Property TextBox1 As TextBox

		Protected Overridable Property TextBox2 As TextBox

		Protected Overridable Property TextBox3 As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Session("username") = MyBase.User.Identity.GetUserName()
			Me.SqlDataSource1.Insert()
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Me.TextBox1.Text = MyBase.User.Identity.GetUserName()
		End Sub

		Private Sub SqlDataSource1_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.Session("ConvoId") = RuntimeHelpers.GetObjectValue(e.Command.Parameters("@ConvoId").Value)
			Me.Session("DateCreated") = DateTime.Today
			Me.Session("username") = MyBase.User.Identity.GetUserName()
			Me.SqlDataSource2.Insert()
		End Sub
	End Class
End Namespace