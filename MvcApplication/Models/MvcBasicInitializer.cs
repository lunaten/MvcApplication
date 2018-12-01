using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;

namespace MvcApplication.Models
{
    //コンテキストクラスでの追加
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    //継承の追加
    public class MvcBasicInitializer : DropCreateDatabaseAlways<MvcBasicContext>
    {
        protected override void Seed(MvcBasicContext context)
        {
            var members = new List<Member>
            {
                new Member
                {
                    Name = "Bob",
                    Email = "bob@axd.jp,",
                    Birth = DateTime.Parse("1900.01.01"),
                    Married = 1,
                    Memo = "I like sports."
                },
                new Member
                {
                    Name = "Carry",
                    Email = "carry@axd.jp,",
                    Birth = DateTime.Parse("1900.09.01"),
                    Married = 1,
                    Memo = "I like chocolate."
                }
            };
            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
        }
    }
}