using MoneyTemplateHW.Service;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTemplateHW.Models.ViewModels
{
    /// <summary>
    /// 記帳本 View Components
    /// </summary>
    public static class MoneyBookViewComponents
    {
        public static List<CategoryItem> CategoryListItem { get; set; }

        static MoneyBookViewComponents()
        {
            CategoryListItem = new List<CategoryItem>
            {
                new CategoryItem() {Name = "請選擇", Value = null},
                new CategoryItem() {Name = "支出", Value  = 0},
                new CategoryItem() {Name = "收入", Value  = 1},
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyBookViewComponents"/> class.
        /// </summary>
        public static IEnumerable<MoneyBookViewModel> GetFakeData()
        {
            MoneyBookService moneyBookService = new MoneyBookService();

            var dbQuery = (from data in moneyBookService.Lookup()
                           select new MoneyBookViewModel
                           {
                               Date = data.Dateee.ToString("yyyy-MM-dd"),
                               Money = data.Amounttt,
                               Description = data.Remarkkk,
                               Category = data.Categoryyy.ToString(),
                           });

            return dbQuery;
        }

        public class CategoryItem
        {
            public string Name { get; set; }
            public int? Value { get; set; }
        }
    }
}