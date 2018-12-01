using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;
namespace MvcApplication.Models
{
    //Global.asax以外での設定は非推奨のためコメントアウト
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]

    public class MvcBasicContext : DbContext
    {
        public MvcBasicContext() : base("DefaultConnection")
        {
        }
        //DbSet<データモデル>型のプロパティを定義する（名前は複数形）
        public DbSet<Member> Members { get; set; }
    }
}