using MvcApplication.Models;

namespace MvcApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /*
     * EntityFramework�Ŏ����}�C�O���[�V������ݒ肷����@
     * https://docs.microsoft.com/ja-jp/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
     */

    internal sealed class Configuration : DbMigrationsConfiguration<MvcBasicContext>
    {
        public Configuration()
        {
            //��̒ǉ��A�e�[�u���̒ǉ��Ȃǂ�����
            AutomaticMigrationsEnabled = true;
            // ��̍폜��e�[�u���̍폜�Ȃǂ�����
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
