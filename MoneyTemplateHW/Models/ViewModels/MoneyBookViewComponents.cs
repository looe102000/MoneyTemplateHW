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
    }
}