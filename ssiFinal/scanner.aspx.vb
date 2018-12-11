Imports System
Imports System.Data.Common
Imports System.Runtime.CompilerServices
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class scanner
		Inherits System.Web.UI.Page

        Private _Button1 As Button
        Private _SqlDataSource2 As SqlDataSource
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

        Protected Overridable Property form1 As HtmlForm

		Protected Overridable Property RequiredFieldValidator1 As RequiredFieldValidator

		Protected Overridable Property RequiredFieldValidator2 As RequiredFieldValidator

		Protected Overridable Property RequiredFieldValidator3 As RequiredFieldValidator

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
			Get
				Return Me._SqlDataSource2
			End Get
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(ByVal value As System.Web.UI.WebControls.SqlDataSource)
				Dim sqlDataSourceStatusEventHandler As System.Web.UI.WebControls.SqlDataSourceStatusEventHandler = New System.Web.UI.WebControls.SqlDataSourceStatusEventHandler(AddressOf Me.SqlDataSource2_Inserted)
				Dim sqlDataSource As System.Web.UI.WebControls.SqlDataSource = Me._SqlDataSource2
				If (sqlDataSource IsNot Nothing) Then
					RemoveHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
				Me._SqlDataSource2 = value
				sqlDataSource = Me._SqlDataSource2
				If (sqlDataSource IsNot Nothing) Then
					AddHandler sqlDataSource.Inserted,  sqlDataSourceStatusEventHandler
				End If
			End Set
		End Property

		Protected Overridable Property TextBox1 As TextBox

		Protected Overridable Property TextBox2 As TextBox

		Protected Overridable Property TextBox3 As TextBox

		Public Sub New()
			MyBase.New()
			AddHandler MyBase.Load,  New EventHandler(AddressOf Me.Page_Load)
		End Sub

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			Me.Validate()
			If (MyBase.IsValid) Then
				Me.Session("DateNowScan") = DateTime.Now
				Me.SqlDataSource1.Insert()
			End If
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Protected Sub SqlDataSource1_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.Session("LastInsertID") = RuntimeHelpers.GetObjectValue(e.Command.Parameters("@NewParameter").Value)
			Dim strArrays As String() = Me.TextBox1.Text.Split(New Char() { Strings.ChrW(13) })
			For i As Integer = 0 To CInt(strArrays.Length) Step 1
				Dim str As String = strArrays(i)
				Me.Session("brRow") = str
				Me.SqlDataSource2.Insert()
			Next

		End Sub

		Protected Sub SqlDataSource2_Inserted(ByVal sender As Object, ByVal e As SqlDataSourceStatusEventArgs)
			Me.TextBox1.Text = ""
			Me.TextBox2.Text = ""
			Me.TextBox3.Text = ""
		End Sub
	End Class
End Namespace