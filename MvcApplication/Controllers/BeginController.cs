using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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