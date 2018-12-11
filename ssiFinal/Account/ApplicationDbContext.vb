Imports Microsoft.AspNet.Identity.EntityFramework
Imports System

Namespace ssiFinal
	Public Class ApplicationDbContext
		Inherits IdentityDbContext(Of ApplicationUser)
		Public Sub New()
			MyBase.New("DefaultConnection", False)
		End Sub

		Public Shared Function Create() As ApplicationDbContext
			Return New ApplicationDbContext()
		End Function
	End Class
End Namespace