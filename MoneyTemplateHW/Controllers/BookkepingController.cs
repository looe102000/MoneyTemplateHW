using MoneyTemplateHW.Models.ViewModels;
using MoneyTemplateHW.Service;
using System.Linq;
using System.Web.Mvc;

namespace MoneyTemplateHW.Controllers
{
    public class BookkepingController : Controller
    {
        private readonly MoneyBookService _MoneyBookService;

        public BookkepingController()
        {
            _MoneyBookService = new MoneyBookService();
        }

        public ActionResult Index()
        {
            ViewData["CategoryListItem"] = new SelectList(CategoryModel.CategoryListItem, "value", "name", 0);

            return View();
        }

        // GET: BookkepingController
        [HttpPost]
        public ActionResult Index([Bind(Include = "Category,Money,Date,Description")]
                                  MoneyBookViewModel dailyRecord)
        {
            if (ModelState.IsValid)
            {
                _MoneyBookService.Add(dailyRecord);
                _MoneyBookService.Save();
            }

            ViewData["CategoryListItem"] = new SelectList(CategoryModel.CategoryListItem, "value", "name", 0);

            return View();
        }

        [ChildActionOnly]
        public ActionResult DataListAction(int? page)
        {
            var pageCnt = page ?? 0;
            //分 10 頁
            var pageRows = 50;

            var result = MoneyBookViewComponents.GetFakeData()
                                                              .OrderByDescending(d => d.Date)
                                                              .ThenByDescending(d => d.Money)
                                                              .Skip((pageCnt - 1) * pageRows).Take(pageRows)
                                                              .ToList();

            return View(result);
        }
    }
}