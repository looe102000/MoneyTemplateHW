using MoneyTemplateHW.Models;
using System;

namespace MoneyTemplateHW.Service
{
    public class MoneyBookService
    {
        private readonly SkillTreeHomeworkEntities _db;

        public MoneyBookService()
        {
            _db = new SkillTreeHomeworkEntities();
        }

        internal void Add(DailyRecord dailyRecord)
        {
            if (string.IsNullOrWhiteSpace(dailyRecord.Category) == false
               && string.IsNullOrWhiteSpace(dailyRecord.Date) == false
               && string.IsNullOrWhiteSpace(dailyRecord.Money.ToString()) == false
               && string.IsNullOrWhiteSpace(dailyRecord.Description) == false)
            {
                _db.AccountBook.Add(new AccountBook
                {
                    Id = Guid.NewGuid(),
                    Categoryyy = Convert.ToInt32(dailyRecord.Category),
                    Amounttt = Convert.ToInt32(dailyRecord.Money),
                    Dateee = Convert.ToDateTime(dailyRecord.Date),
                    Remarkkk = dailyRecord.Description
                });
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}