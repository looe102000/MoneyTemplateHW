﻿using MoneyTemplateHW.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MoneyTemplateHW.Models.ViewModels
{
    /// <summary>
    /// 記帳本 View Components
    /// </summary>
    public static class MoneyBookViewComponents
    {
        /// <summary>
        /// The category select item list
        /// </summary>
        public static IEnumerable<SelectListItem> categorySelectItemList = new List<SelectListItem>
        {
            new SelectListItem {Text = "請選擇", Value = ""},
            new SelectListItem {Text = "支出", Value  = "1"},
            new SelectListItem {Text = "收入", Value  = "2"}
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyBookViewComponents"/> class.
        /// </summary>
        public static IEnumerable<MoneyBookViewModel> GetFakeData()
        {
            MoneyBookService _MoneyBookService = new MoneyBookService();

            var dbQuery = (from data in _MoneyBookService.Lookup()
                           select new MoneyBookViewModel
                           {
                               Date = data.Dateee.ToString("yyyy-MM-dd"),
                               Money = data.Amounttt,
                               Description = data.Remarkkk,
                               Category = data.Categoryyy.ToString(),
                           });

            return dbQuery;
        }
    }
}