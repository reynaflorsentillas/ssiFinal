Imports System
Imports System.Collections.Specialized
Imports System.Web

Namespace ssiFinal
	Public Class IdentityHelper
		Public Const XsrfKey As String = "xsrfKey"

		Public Const ProviderNameKey As String = "providerName"

		Public Const CodeKey As String = "code"

		Public Const UserIdKey As String = "userId"

		Public Sub New()
			MyBase.New()
		End Sub

		Public Shared Function GetCodeFromRequest(ByVal request As HttpRequest) As String
			Return request.QueryString("code")
		End Function

		Public Shared Function GetProviderNameFromRequest(ByVal request As HttpRequest) As String
			Return request.QueryString("providerName")
		End Function

		Public Shared Function GetResetPasswordRedirectUrl(ByVal code As String, ByVal request As HttpRequest) As String
			Dim str As String = String.Concat("/Account/ResetPassword?code=", HttpUtility.UrlEncode(code))
			Return (New Uri(request.Url, str)).AbsoluteUri.ToString()
		End Function

		Public Shared Function GetUserConfirmationRedirectUrl(ByVal code As String, ByVal userId As String, ByVal request As HttpRequest) As String
			Dim str As String = String.Concat("/Account/Confirm?code=", HttpUtility.UrlEncode(code), "&userId=", HttpUtility.UrlEncode(userId))
			Return (New Uri(request.Url, str)).AbsoluteUri.ToString()
		End Function

		Public Shared Function GetUserIdFromRequest(ByVal request As HttpRequest) As String
			Return HttpUtility.UrlDecode(request.QueryString("userId"))
		End Function

		Private Shared Function IsLocalUrl(ByVal url As String) As Boolean
			If (String.IsNullOrEmpty(url)) Then
				Return False
			End If
			If (url(0) = "/"C AndAlso (url.Length = 1 OrElse url(1) <> "/"C AndAlso url(1) <> "\"C)) Then
				Return True
			End If
			If (url.Length <= 1 OrElse url(0) <> "~"C) Then
				Return False
			End If
			Return url(1) = "/"C
		End Function

		Public Shared Sub RedirectToReturnUrl(ByVal returnUrl As String, ByVal response As HttpResponse)
			If (Not String.IsNullOrEmpty(returnUrl) AndAlso IdentityHelper.IsLocalUrl(returnUrl)) Then
				response.Redirect(returnUrl)
				Return
			End If
			response.Redirect("~/")
		End Sub
	End Class
End Namespace