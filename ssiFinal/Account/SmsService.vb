Imports Microsoft.AspNet.Identity
Imports System
Imports System.Threading.Tasks

Namespace ssiFinal
	Public Class SmsService
		Implements IIdentityMessageService
		Public Sub New()
			MyBase.New()
		End Sub

		Public Function SendAsync(ByVal message As IdentityMessage) As Task Implements IIdentityMessageService.SendAsync
			Return Task.FromResult(Of Integer)(0)
		End Function
	End Class
End Namespace