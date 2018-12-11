Imports System
Imports System.Web.Optimization
Imports System.Web.UI

Namespace ssiFinal
	Public Class BundleConfig
		Public Sub New()
			MyBase.New()
		End Sub

		Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
			bundles.Add((New ScriptBundle("~/bundles/WebFormsJs")).Include(New String() { "~/Scripts/WebForms/WebForms.js", "~/Scripts/WebForms/WebUIValidation.js", "~/Scripts/WebForms/MenuStandards.js", "~/Scripts/WebForms/Focus.js", "~/Scripts/WebForms/GridView.js", "~/Scripts/WebForms/DetailsView.js", "~/Scripts/WebForms/TreeView.js", "~/Scripts/WebForms/WebParts.js" }))
			bundles.Add((New ScriptBundle("~/bundles/MsAjaxJs")).Include(New String() { "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js", "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js" }))
			bundles.Add((New ScriptBundle("~/bundles/modernizr")).Include("~/Scripts/modernizr-*", New IItemTransform(-1) {}))
			ScriptManager.ScriptResourceMapping.AddDefinition("respond", New ScriptResourceDefinition() With
			{
				.Path = "~/Scripts/respond.min.js",
				.DebugPath = "~/Scripts/respond.js"
			})
		End Sub
	End Class
End Namespace