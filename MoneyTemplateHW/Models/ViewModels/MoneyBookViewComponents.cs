using Bogus;
using System;
using System.Collections.Generic;
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
            var Faker = new Faker<MoneyBookViewModel>()
                     .RuleFor(o => o.Category, f => f.Random.Number(1, 2).ToString())
                     .RuleFor(o => o.Money, f => f.Random.Number(1, 10000))
                     .RuleFor(o => o.Date, f => f.Date.Between(DateTime.Today.AddDays(-30d), DateTime.Today).ToString("yyyy-MM-dd"));

            var MoneyBookFaker = new List<MoneyBookViewModel>();


            for (int i = 0; i < 50; i++)
            {
                MoneyBookFaker.Add(Faker);
            }

            return MoneyBookFaker;
        }
    }
}