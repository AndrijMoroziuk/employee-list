using System.Web;
using System.Web.Optimization;

namespace EmployeeList.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/angular-toastr.css",
                      "~/Content/ui-bootstrap-custom-2.5.0-csp.css",
                      "~/Content/sass/layout.css",
                      "~/Content/sass/navbartop.css",
                      "~/Content/sass/dashboard.css",
                      "~/Content/icon-fonts/icon-fonts.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/angular-components").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-messages.js",
                        "~/Scripts/angular-ui-router.js",
                        "~/Scripts/angular-toastr.tpls.js",
                        "~/Scripts/angular-local-storage.js",
                        "~/Scripts/ui-bootstrap-custom-tpls-2.5.0.js",
                        "~/Scripts/ng-file-upload-all.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/app/app.js",
                      "~/app/error/error.js",
                      "~/app/error/errorService.js",
                      "~/app/error/interceptorRequestError.js",
                      "~/app/services/accountService.js",
                      "~/app/account/signinController.js",
                      "~/app/services/utilService.js",
                      "~/app/services/authorizationService.js",
                      "~/app/services/employeeService.js",
                      "~/app/services/currentUserService.js", 
                      "~/app/access/access.js",
                      "~/app/layout/loadingComponents.js",
                      "~/app/layout/navbartopController.js",
                      "~/app/dashboard/dashboardController.js",
                      "~/app/dashboard/dashboard.js",
                      "~/app/dashboard/addEmployee/addEmployeeController.js",
                      "~/app/dashboard/employeeList/employeeListController.js",
                      "~/app/modalComponents/confirmDeleteController.js"

            ));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true; 
#endif
        }
    }
}
