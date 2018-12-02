using MvcApplication.Models;

namespace MvcApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /*
     * EntityFrameworkで自動マイグレーションを設定する方法
     * https://docs.microsoft.com/ja-jp/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
     */

    internal sealed class Configuration : DbMigrationsConfiguration<MvcBasicContext>
    {
        public Configuration()
        {
            //列の追加、テーブルの追加などを許可
            AutomaticMigrationsEnabled = true;
            // 列の削除やテーブルの削除などを許可
            AutomaticMigrationDataLossAllowed = true;

            ContextKey = "MvcBasicContext";
        }

        protected override void Seed(MvcBasicContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
