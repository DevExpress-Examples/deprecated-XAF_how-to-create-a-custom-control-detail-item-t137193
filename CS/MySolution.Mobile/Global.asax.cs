using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
// Uncomment the following code if you use ReportsMobileModuleV2 module. 
//using DevExpress.ExpressApp.ReportsV2.Mobile;
//using DevExpress.XtraReports.Web.WebDocumentViewer;

namespace MySolution.Mobile {
    public class Global : System.Web.HttpApplication {
        protected void Application_Start(Object sender, EventArgs e) {
            // Uncomment the following code if you use ReportsMobileModuleV2 module. 
            //DefaultWebDocumentViewerContainer.Register<IWebDocumentViewerReportResolver, XafReportsResolver<MySolutionMobileApplication>>();
        }
		protected void Application_BeginRequest(object sender, EventArgs e) {
            CorsSupport.HandlePreflightRequest(HttpContext.Current);
        }
    }
}