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
     * Web.Configに設定したので、今はコメント中
     */
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]    

    public class MvcBasicContext : DbContext
    {
        //DbSet<データモデル>型のプロパティを定義する（名前は複数形）
        public DbSet<Member> Members { get; set; }
    }
}