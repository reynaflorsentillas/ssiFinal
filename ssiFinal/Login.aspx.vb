Imports Microsoft.AspNet.Identity.Owin
Imports System
Imports System.Runtime.CompilerServices
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

Namespace ssiFinal
	Public Class Login1
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

        Protected Overridable Property form1 As HtmlForm

		Protected Overridable Property Label1 As Label

		Protected Overridable Property passwordTextBox1 As HtmlInputPassword

		Protected Overridable Property SqlDataSourceUsers As SqlDataSource

		Protected Overridable Property style_color As HtmlLink

		Protected Overridable Property usernameTextBox1 As HtmlInputText

		Public Sub New()
			MyBase.New()
		End Sub

		Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
			If (MyBase.IsValid) Then
				Me.Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
				Dim signInStatu As SignInStatus = Me.Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)().PasswordSignIn(Me.usernameTextBox1.Value, Me.passwordTextBox1.Value, False, False)
				Me.Session("loginUsername") = Me.usernameTextBox1.Value
				If (signInStatu = SignInStatus.Success) Then
					MyBase.Response.Redirect("redirectUser.aspx", False)
					Return
				End If
				Me.Label1.Text = "Invalid login attempt"
				Me.Label1.Visible = True
			End If
		End Sub
	End Class
End Namespace