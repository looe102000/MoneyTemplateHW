using MoneyTemplateHW.Models;
using MoneyTemplateHW.Models.ViewModels;
using MoneyTemplateHW.Service;
using System.Collections.Generic;
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
            GetCategoryDropdownListModel();
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

            GetCategoryDropdownListModel();

            return View();
        }

        [ChildActionOnly]
        public ActionResult DataListAction(int? page)
        {
            var pageCnt = page ?? 0;
            //分 10 頁
            var pageRows = 50;

            //日期大到小；金額大到小
            //MBV.MoneyBookDataList = MBV.MoneyBookDataList.AsEnumerable()
            //                                                .OrderByDescending(x => x.date)
            //                                                .ThenByDescending(x =>x.money).Skip((pageCnt -1) * pageRows).Take(pageRows).ToList();
          var result= MoneyBookViewComponents.GetFakeData()
                                                            .OrderByDescending(d => d.Date)
                                                            .ThenByDescending(d => d.Money)
                                                            .Skip((pageCnt - 1) * pageRows).Take(pageRows)
                                                            .ToList();

            return View(result);
        }

        private void GetCategoryDropdownListModel()
        {
            var options = new List<CategoryItem>
            {
                new CategoryItem() {Name = "請選擇", Value = null},
                new CategoryItem() {Name = "支出", Value  = 0},
                new CategoryItem() {Name = "收入", Value  = 1},
            };

            ViewData["CategoryListItem"] = new SelectList(options, "value", "name", 0);
        }

        private class CategoryItem
        {
            public string Name  { get; set; }
            public int?   Value { get; set; }
        }
    }
}