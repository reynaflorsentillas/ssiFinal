Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.DataProtection
Imports System

Namespace ssiFinal
	Public Class ApplicationUserManager
		Inherits UserManager(Of ApplicationUser)
		Public Sub New(ByVal store As IUserStore(Of ApplicationUser))
			MyBase.New(store)
		End Sub

        Public Shared Function Create(ByVal options As IdentityFactoryOptions(Of ssiFinal.ApplicationUserManager), ByVal context As IOwinContext) As ssiFinal.ApplicationUserManager
            Dim applicationUserManager As ssiFinal.ApplicationUserManager = New ssiFinal.ApplicationUserManager(New UserStore(Of ApplicationUser)(context.[Get](Of ApplicationDbContext)())) With
            {
                .UserValidator = New UserValidator(Of ApplicationUser)(applicationUserManager) With
                {
                    .AllowOnlyAlphanumericUserNames = False,
                    .RequireUniqueEmail = True
                },
                .PasswordValidator = New Microsoft.AspNet.Identity.PasswordValidator() With
                {
                    .RequiredLength = 6,
                    .RequireNonLetterOrDigit = True,
                    .RequireDigit = True,
                    .RequireLowercase = True,
                    .RequireUppercase = True
                }
            }
            applicationUserManager.RegisterTwoFactorProvider("Phone Code", New PhoneNumberTokenProvider(Of ApplicationUser)() With
            {
                .MessageFormat = "Your security code is {0}"
            })
            applicationUserManager.RegisterTwoFactorProvider("Email Code", New EmailTokenProvider(Of ApplicationUser)() With
            {
                .Subject = "Security Code",
                .BodyFormat = "Your security code is {0}"
            })
            applicationUserManager.UserLockoutEnabledByDefault = True
            applicationUserManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5)
            applicationUserManager.MaxFailedAccessAttemptsBeforeLockout = 5
            applicationUserManager.EmailService = New ssiFinal.EmailService()
            applicationUserManager.SmsService = New ssiFinal.SmsService()
            Dim dataProtectionProvider As IDataProtectionProvider = options.DataProtectionProvider
            If (dataProtectionProvider IsNot Nothing) Then
                applicationUserManager.UserTokenProvider = New DataProtectorTokenProvider(Of ApplicationUser)(dataProtectionProvider.Create(New String() {"ASP.NET Identity"}))
            End If
            Return applicationUserManager
        End Function
    End Class
End Namespace