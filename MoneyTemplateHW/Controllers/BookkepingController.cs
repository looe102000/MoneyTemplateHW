using MoneyTemplateHW.Models.ViewModels;
using System.Web.Mvc;
using System.Linq;

namespace MoneyTemplateHW.Controllers
{
    public class BookkepingController : Controller
    {
        // GET: BookkepingController
        public ActionResult Index(MoneyBookViewModel MBV)
        {
            MBV.MoneyBookData_List = MBV.MoneyBookData_List.AsEnumerable().OrderByDescending(x => x.date).ToList();

            return View(MBV);
        }
    }
}