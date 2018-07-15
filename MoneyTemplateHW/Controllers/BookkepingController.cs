using MoneyTemplateHW.Models;
using MoneyTemplateHW.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MoneyTemplateHW.Controllers
{
    public class BookkepingController : Controller
    {
        // GET: BookkepingController
        public ActionResult Index(MoneyBookViewModel MBV)
        {
            if (string.IsNullOrWhiteSpace(MBV.Category) == false
               && string.IsNullOrWhiteSpace(MBV.Date) == false
               && string.IsNullOrWhiteSpace(MBV.Money.ToString()) == false
               && string.IsNullOrWhiteSpace(MBV.Description) == false)
            {
                SkillTreeHomeworkEntities db = new SkillTreeHomeworkEntities();

                db.AccountBook.Add(new AccountBook
                {
                    Id = Guid.NewGuid(),
                    Categoryyy = Convert.ToInt32(MBV.Category),
                    Amounttt = Convert.ToInt32(MBV.Money),
                    Dateee = Convert.ToDateTime(MBV.Date),
                    Remarkkk = MBV.Description
                });

                db.SaveChanges();
            }

            GetCategoryDropdownListModel();

            return View();
        }

        [ChildActionOnly]
        public ActionResult DataListAction(int? page)
        {
            if (page == null)
            {
                page = 0;
            }

            var pageCnt = (int)page;
            //分 10 頁
            var pageRows = 50;

            //日期大到小；金額大到小
            //MBV.MoneyBookDataList = MBV.MoneyBookDataList.AsEnumerable()
            //                                                .OrderByDescending(x => x.date)
            //                                                .ThenByDescending(x =>x.money).Skip((pageCnt -1) * pageRows).Take(pageRows).ToList();
            ViewData["ListSource"] = MoneyBookViewComponents.GetFakeData()
                                                            .OrderByDescending(d => d.Date)
                                                            .ThenByDescending(d => d.Money)
                                                            .Skip((pageCnt - 1) * pageRows).Take(pageRows)
                                                            .ToList();

            return View();
        }


        private void GetCategoryDropdownListModel()
        {
            var options = new List<CategoryItem>
            {
                new CategoryItem() { name = "請選擇", value = null},
                new CategoryItem() { name = "支出", value = 0},
                new CategoryItem() { name = "收入", value = 1},
            };

            ViewData["CategoryListItem"] = new SelectList(options,  "value", "name", 0);
        }


        class CategoryItem
        {
            public string name { get; set; }
            public int? value { get; set; }
        }
    }
}