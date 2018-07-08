﻿using MoneyTemplateHW.Models.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MoneyTemplateHW.Controllers
{
    public class BookkepingController : Controller
    {
        // GET: BookkepingController
        public ActionResult Index(MoneyBookViewModel MBV, int? page)
        {
            if (page == null)
            {
                page = 0;
            }

            var pageCnt = (int)page;
            //分 10 頁
            var pageRows = 50;

            //日期大到小；金額大到小
            MBV.MoneyBookData_List = MBV.MoneyBookData_List.AsEnumerable()
                                                            .OrderByDescending(x => x.date)
                                                            .ThenByDescending(x =>x.money).Skip((pageCnt -1) * pageRows).Take(pageRows).ToList();


            return View(MBV);
        }
    }
}