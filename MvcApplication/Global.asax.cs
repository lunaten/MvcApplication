using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcApplication.Models;
using System.Data.Entity;
using MySql.Data.Entity;
namespace MvcApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            /*
             * DbConfigurationTypeについて
             * Web.ConfigまたはMvcBasicContextで設定すると
             * Scaffoldingでエラーが発生するため、Global.asaxへ変更。
             * 設定後はMvcApplication.dllを再作成したいためリビルド必須！！！
             */
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer<MvcBasicContext>(new MvcBasicInitializer());
        }
    }
}
