using MoneyTemplateHW.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateHW.Controllers
{
    public class BookkepingController : Controller
    {
        // GET: Bookkeping
        public ActionResult Index(MoneyBook MB)
        {

            MB.TypeSelectItemList = new List<SelectListItem>
            {
                new SelectListItem{Text="請選擇",Value=null,Selected = true},
                new SelectListItem{Text="支出",Value=null},
                new SelectListItem{Text="收入",Value=null}
            };

            return View(MB);
        }
    }
}