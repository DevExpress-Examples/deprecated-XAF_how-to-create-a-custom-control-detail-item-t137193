Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
' Uncomment the following code if you use ReportsMobileModuleV2 module. 
'using DevExpress.ExpressApp.ReportsV2.Mobile;
'using DevExpress.XtraReports.Web.WebDocumentViewer;

Namespace MySolution.Mobile
    Public Class [Global]
        Inherits System.Web.HttpApplication

        Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            ' Uncomment the following code if you use ReportsMobileModuleV2 module. 
            'DefaultWebDocumentViewerContainer.Register<IWebDocumentViewerReportResolver, XafReportsResolver<MySolutionMobileApplication>>();
        End Sub
        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            CorsSupport.HandlePreflightRequest(HttpContext.Current)
        End Sub
    End Class
End Namespace