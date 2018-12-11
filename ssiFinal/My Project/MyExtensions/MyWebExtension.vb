Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.VisualBasic.Logging
Imports System
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Web
Imports ssiFinal.My

Namespace ssiFinal.My
    <HideModuleName>
    Friend Module MyWebExtension
        Private s_Computer As MyProject.ThreadSafeObjectProvider(Of ServerComputer)

        Private s_User As MyProject.ThreadSafeObjectProvider(Of WebUser)

        Private s_Log As MyProject.ThreadSafeObjectProvider(Of AspLog)

        Friend ReadOnly Property Computer As ServerComputer
            Get
                Return MyWebExtension.s_Computer.GetInstance
            End Get
        End Property

        Friend ReadOnly Property Log As AspLog
            Get
                Return MyWebExtension.s_Log.GetInstance
            End Get
        End Property

        <HelpKeyword("My.Request")>
        Friend ReadOnly Property Request As HttpRequest
            <DebuggerHidden>
            Get
                Dim httpRequest As System.Web.HttpRequest
                Dim current As HttpContext = HttpContext.Current
                If (current Is Nothing) Then
                    httpRequest = Nothing
                Else
                    httpRequest = current.Request
                End If
                Return httpRequest
            End Get
        End Property

        <HelpKeyword("My.Response")>
        Friend ReadOnly Property Response As HttpResponse
            <DebuggerHidden>
            Get
                Dim httpResponse As System.Web.HttpResponse
                Dim current As HttpContext = HttpContext.Current
                If (current Is Nothing) Then
                    httpResponse = Nothing
                Else
                    httpResponse = current.Response
                End If
                Return httpResponse
            End Get
        End Property

        Friend ReadOnly Property User As WebUser
            Get
                Return MyWebExtension.s_User.GetInstance
            End Get
        End Property

        Sub New()
            MyWebExtension.s_Computer = New MyProject.ThreadSafeObjectProvider(Of ServerComputer)()
            MyWebExtension.s_User = New MyProject.ThreadSafeObjectProvider(Of WebUser)()
            MyWebExtension.s_Log = New MyProject.ThreadSafeObjectProvider(Of AspLog)()
        End Sub
    End Module
End Namespace