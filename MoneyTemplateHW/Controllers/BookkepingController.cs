using MoneyTemplateHW.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MoneyTemplateHW.Controllers
{
    public class BookkepingController : Controller
    {
        // GET: BookkepingController
        public ActionResult Index(MoneyBookViewModel MBV)
        {
            //日期大到小；金額大到小
            MBV.MoneyBookData_List = MBV.MoneyBookData_List.AsEnumerable()
                                                            .OrderByDescending(x => x.date)
                                                            .ThenByDescending(x =>x.money).ToList();

            return View(MBV);
        }
    }
}