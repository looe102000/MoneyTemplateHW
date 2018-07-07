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
            MBV.MoneyBookData_List = MBV.MoneyBookData_List.AsEnumerable().OrderByDescending(x => x.date).ToList();

            return View(MBV);
        }
    }
}