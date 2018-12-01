# MvcApplication
・Model  
・View  
・Controller  

# Model
##    1. エンティティを定義する
> Models/Member.csを作成  
```csharp:Member
//クラス名は単数形でテーブル名は複数形
public class Member
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public DateTime Birth { get; set; }
	public bool Married { get; set; }
	public string Memo { get; set; }
}
```
#### 2. コンテキストクラスを定義する  
> Models/MvcBasicContext.csを作成  
```csharp:MvcBasicContext
//参照を追加する
using System.Data.Entity;

namespace MvcApplication.Models
{
	//DbContextを継承する
	public class MvcBasicContext : DbContext
	{
		//DbSet<データモデル>型のプロパティを定義する（名前は複数形）
		public DbSet<Member> Members { get; set; }
	}
}
```

#### 3. データベース接続文字列を定義する
> Web.configを編集  
```config:web
<configuration>
	<!-- 接続文字列の追加 -->
	<connectionStrings>
	<add name="MvcBasicContext" connectionString="Data Sourse=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\MvcBasic.mdf;Integrated Security=True" providerName="System.Data.SqlClient" />
	</connectionStrings>
	・・・中略・・・
</configuration>
```
> 接続文字列が通らないのでここを参考にしてみた  
https://qiita.com/HAGITAKO/items/782e447ef11abdcb17cc  

 ### 4. イニシャライザーを準備する  
 > Models/MvcBasicInitializer.csを作成  
```csharp
//参照を追加する
using System.Data.Entity;

namespace MvcApplication.Models
{
	//継承の追加
	/*
	DropCreateDatabaseIfNotExits<TContext>    ：データベースが存在しないとき
	DropCreateDatabaseAlways<TContext>        ：アプリケーション実行時に常に
	DropCreateDatabaseIfModelChanges<TContext>：モデルが変更されたとき
	*/
	public class MvcBasicInitializer : DropCreateDatabaseAlways<MvcBasicContext>
	{
		protected override void Seed(MvcBasicContext context)
		{
			var members = new List<Member>
			{
				new Member
				{
					Name = "田中太郎",
					Email = "aaa@bbb.ccc,",
					Birth = DateTime.Parse("1900.01.01"),
					Married = true,
					Memo = "運動が好きです。"
				},
				new Member
				{
					Name = "田中花子",
					Email = "aaa@bbb.ccc,",
					Birth = DateTime.Parse("1900.09.01"),
					Married = true,
					Memo = "チョコが好きです。"
				}
			};

			//コンテキストの保存
			members.ForEach(m => context.Members.Add(m));
			context.SaveChanges();
		}
	}
}
```
 5. イニシャライザーを登録する  
・	Global.aspx.csを編集
	```csharp:Global
	protected void Application_Start()
    {
        //・・・中略・・・
        Database.SetInitializer<MvcBasicContext>(new MvcBasicInitializer());
    }
	```


# Controller
 1. アクションメソッドを準備する  
・	Models/BeginController.csを作成  
	```csharp:BeginController
    //参照の追加
    using System.Web.Mvc;
    using MvcApplication.Models;

    namespace MvcApplication.Controllers
    {
        //Biginコントローラーの作成
        public class BeginController : Controller
        {
            private MvcBasicContext db = new MvcBasicContext();

            //アクションメソッドの準備
            public ActionResult List()
            {
                //ビューにモデルを引き渡す
                return View(db.Members);
            }
        }
    }
    ```

# View
 2. ビュースクリプトを準備する  
・   /View/Begin/List.csを作成
    ```html:List.cshtml
    <!-- モデルからMemberを受け取る -->
    @using MvcApplication.Models;
    @model IEnumerable<Member>

    @{
        ViewBag.Title = "List";
    }

    <h2>List</h2>
    <table class="table">
        <tr>
            <td>氏名</td>
            <td>メールアドレス</td>
            <td>誕生日</td>
            <td>既婚</td>
            <td>備考</td>
        </tr>
        <!-- ＠から始まるのはRazor構文 -->
        @foreach (var item in Model)
        {
            <tr>
                <!-- インテリセンスが効く -->
                <td>@item.Name</td>
                <td>@item.Email</td>
                <td>@item.Birth</td>
                <td>@item.Married</td>
                <td>@item.Memo</td>
            </tr>
        }
    </table>
    ```
 3. 