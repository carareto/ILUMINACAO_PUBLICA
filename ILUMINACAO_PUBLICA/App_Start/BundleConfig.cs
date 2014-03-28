using System.Web;
using System.Web.Optimization;

namespace ILUMINACAO_PUBLICA
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            // bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //           "~/Scripts/bootstrap.js",
            //           "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css",
                      "~/Content/jquery.multiselect.css",
                      "~/Content/jquery.multiselect.filter.css",
                      "~/Content/jquery.jqGrid/ui.jqgrid.css",
                      "~/Content/themes/ui-lightness/jquery.ui.dialog.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/base").Include(
                      "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/bootstrap").Include(
                               "~/Content/bootstrap/bootstrap-responsive.css",
                               "~/Content/bootstrap/bootstrap-theme.css",
                               "~/Content/bootstrap/bootstrap.css"));

            // Nao usar com multiselect
            //bundles.Add(new ScriptBundle("~/bundles/jquery1110").Include(
            //           "~/Scripts/jquery-1.11.0.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jquery191").Include(
            //           "~/Scripts/jquery-1.9.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery172").Include(
                       "~/Scripts/jquery-1.7.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery210").Include(
                       "~/Scripts/jquery-2.1.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                       "~/Scripts/jquery.unobtrusive*",
                       "~/Scripts/jquery.validate*",
                       "~/Scripts/jquery.activity-indicator*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/bundles/jtable/themes").Include(
                                "~/Scripts/jtable/themes/lightcolor/gray/jtable.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jtable").Include(
                       "~/Scripts/jtable/jquery.jtable.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                            "~/Scripts/bootstrap-3.0.0.js",
                            "~/Scripts/bootstrap-tooltip.js",
                            "~/Scripts/bootstrap-confirmation.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootbox").Include(
                        "~/Scripts/bootbox-4.1.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqgrid").Include(
                            "~/Scripts/jquery.jqGrid.js",
                            "~/Scripts/i18n/grid.locale-pt-br.js"));

            bundles.Add(new ScriptBundle("~/bundles/multiselect").Include(
                       "~/Scripts/multiSelect/jquery.jqGrid.src-multiple1.js",
                       "~/Scripts/multiSelect/jquery.multiselect.filter-1.5.0.js",
                       "~/Scripts/multiSelect/jquery.multiselect.js"));
        }
    }
}