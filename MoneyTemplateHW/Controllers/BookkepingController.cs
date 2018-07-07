using MoneyTemplateHW.Models.ViewModels;
using System.Web.Mvc;

namespace MoneyTemplateHW.Controllers
{
    public class BookkepingController : Controller
    {
        // GET: BookkepingController
        public ActionResult Index(MoneyBookViewModel MBV)
        {
            return View(MBV);
        }
    }
}