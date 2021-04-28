﻿using System.Web;
using System.Web.Optimization;

namespace ConsommiTounsi
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {



            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/FrontEnd/assets/libs/jquery/jquery.min.js",
                      "~/FrontEnd/assets/libs/bootstrap/js/bootstrap.bundle.min.js",
                      "~/FrontEnd/assets/libs/metismenu/metisMenu.min.js",
                      "~/FrontEnd/assets/libs/simplebar/simplebar.min.js",
                      "~/FrontEnd/assets/libs/node-waves/waves.min.js",
                      "~/FrontEnd/assets/libs/waypoints/lib/jquery.waypoints.min.js",
                      "~/FrontEnd/assets/libs/jquery.counterup/jquery.counterup.min.js",
                      "~/FrontEnd/assets/libs/apexcharts/apexcharts.min.js",
                      "~/FrontEnd/assets/js/pages/dashboard.init.js",
                      "~/FrontEnd/assets/libs/datatables.net/js/jquery.dataTables.min.js",
                      "~/FrontEnd/assets/libs/datatables.net-bs4/js/dataTables.bootstrap4.min.js",
                      "~/FrontEnd/assets/libs/datatables.net-responsive/js/dataTables.responsive.min.js",
                      "~/FrontEnd/assets/libs/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js",
                      "~/FrontEnd/assets/js/pages/ecommerce-datatables.init.js",
                      "~/FrontEnd/assets/js/script.js",
                      "~/FrontEnd/assets/libs/bootstrap-datepicker/js/bootstrap-datepicker.min.js",
                      "~/FrontEnd/assets/libs/dropzone/min/dropzone.min.js",
                      "~/FrontEnd/assets/js/app.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/FrontEnd/assets/css/bootstrap.min.css",
            "~/FrontEnd/assets/css/app-dark.min.css",
            "~/FrontEnd/assets/css/app-rtl.min.css",
            "~/FrontEnd/assets/css/icons.min.css",
            "~/FrontEnd/assets/css/app.min.css",
            "~/FrontEnd/assets/css/line.css",
            "~/FrontEnd/assets/libs/select2/css/select2.min.css",
            "~/FrontEnd/assets/libs/spectrum-colorpicker2/spectrum.min.css",
            "~/FrontEnd/assets/libs/bootstrap-datepicker/css/bootstrap-datepicker.min.css",
            "~/FrontEnd/assets/libs/bootstrap-touchspin/jquery.bootstrap-touchspin.min.css",
            "~/FrontEnd/assets/libs/@chenfengyuan/datepicker/datepicker.min.css",
            "~/FrontEnd/assets/libs/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css",
            "~/FrontEnd/assets/libs/dropzone/min/dropzone.min.css",
            "~/FrontEnd/assets/libs/datatables.net-bs4/css/responsive.bootstrap4.min.css"
            ));

        }
    }
}
