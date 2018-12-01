using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;
namespace MvcApplication.Models
{
    /*
     * DbContextを継承する（要System.Data.SqlClientの参照追加）
     * 
     * DbConfigurationTypeについて：
     * Web.Configに設定してたが、Scaffoldingでエラーが発生するため、
     * MvcBasicContextへ設定中。Global.asaxの設定でも問題ない。
     */
    [DbConfigurationType(typeof(MySqlEFConfiguration))]    

    public class MvcBasicContext : DbContext
    {
        public MvcBasicContext() : base("DefaultConnection")
        {
        }
        //DbSet<データモデル>型のプロパティを定義する（名前は複数形）
        public DbSet<Member> Members { get; set; }
    }
}